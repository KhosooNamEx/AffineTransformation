using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Affine_Transformer
{
    public class ImageProcessor :IDisposable
    {
        #region InitValues
        private RegistryManager m_regManager;
        /// <summary>
        /// 変換を行うMAX値
        /// </summary>
        private readonly int rom_MaxLineLength = 14 ;
        /// <summary>
        /// ビットシフトする値
        /// </summary>
        private readonly int rom_BitShifter = 13;
        /// <summary>
        /// アフィン変換バッファ
        /// </summary>
        private byte[] m_affineBuffer;
        /// <summary>
        /// 他の処理に使うバッファ
        /// </summary>
        private byte[] m_processBuffer;
        /// <summary>
        /// 出力Rバッファ
        /// </summary>
        byte[] m_OutputRValue;
        /// <summary>
        /// 出力Gバッファ
        /// </summary>
        byte[] m_OutputGValue;
        /// <summary>
        /// 出力Bバッファ
        /// </summary>
        byte[] m_OutputBValue;
        /// <summary>
        /// Monocolorの場合使う
        /// </summary>
        byte[] m_OutputPixelValue;
        /// <summary>
        /// 無効データのXアドレス
        /// </summary>
        internal List<int> m_ListemptyXCoordinate;
        /// <summary>
        /// 無効データのYアドレス
        /// </summary>
        internal List<int> m_ListemptyYCoordinate;
        /// <summary>
        /// bitmapImage
        /// </summary>
        Bitmap m_InputImage;
        /// <summary>
        /// Output Image
        /// </summary>
        public Bitmap m_OutputImage;
        #endregion
        /// <summary>
        /// ctor
        /// </summary>
        public ImageProcessor()
        {
            m_regManager = null;
            m_InputImage = null;
            m_OutputImage = null;
            m_affineBuffer = null;
            m_processBuffer = null;
            m_OutputRValue = null;
            m_OutputGValue = null;
            m_OutputBValue = null;
            m_OutputPixelValue = null;
            m_ListemptyXCoordinate = null;
            m_ListemptyYCoordinate = null;
        }
        /// <summary>
        /// 出力値をもらいます
        /// </summary>
        /// <param name="regManager"></param>
        internal ProgramCode GetValues(RegistryManager regManager)
        {
            ProgramCode progCode = ProgramCode.Done;
            if (regManager == null) {
                progCode = ProgramCode.RegistryError;
            } else {
                m_regManager = regManager;
            }
            return progCode;
        }
        /// <summary>
        /// 本処理
        /// </summary>
        /// <param name="bmpImage"></param>
        /// <returns></returns>
        public ProgramCode ImageProcess(Bitmap bmpImage, int blockLength, int lastBlockDifference, int bitShiftinValue)
        {
            ProgramCode progCode = ProgramCode.Done;
            //Init variables
            m_InputImage = new Bitmap(bmpImage);
            int maxLineLength = bmpImage.Height;
            int width = bmpImage.Width;
            byte[] bufferR =new byte[width * maxLineLength];
            byte[] bufferG =new byte[width * maxLineLength];
            byte[] bufferB =new byte[width * maxLineLength];
            m_OutputPixelValue = new byte[width * maxLineLength];
            #region Check Rgb or not 
            if (m_InputImage.PixelFormat == PixelFormat.Format32bppArgb) {
                //画像をバッファとして保存しています
                for (int y = 0; y < maxLineLength; y++) {
                    for (int x = 0; x < width; x++) {
                        Color clrValue = m_InputImage.GetPixel(x, y);
                        bufferR[x + (y * width)] = clrValue.R;
                        bufferG[x + (y * width)] = clrValue.G;
                        bufferB[x + (y * width)] = clrValue.B;
                    }
                }
            } else {
                //画像をバッファとして保存しています
                Rectangle rect = new Rectangle(0, 0, width, maxLineLength);
                BitmapData bmpData = bmpImage.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
                //バッファとコピー処理手伝い
                IntPtr imgptr = bmpData.Scan0;
                int bytes = width * maxLineLength;
                m_processBuffer = new byte[bytes];
                Marshal.Copy(imgptr, m_processBuffer, 0, bytes);

                bmpImage.UnlockBits(bmpData);
            }
            #endregion
            //本処理色の画像の場合
            if (m_InputImage.PixelFormat == PixelFormat.Format32bppArgb) {
                //RGB毎にバッファ準備
                Dictionary<int, byte[]> arrayNum = new Dictionary<int, byte[]>(){
                            { 0 , bufferR },
                            { 1 , bufferG },
                            { 2 , bufferB }
                        };
                for (int colorNum = 0; colorNum < arrayNum.Keys.Count; colorNum++) {
                    arrayNum.TryGetValue(colorNum, out byte[] inputBuffer);
                    Array.Clear(m_OutputPixelValue, 0, m_OutputPixelValue.Length);
                    //Main Loop
                    for (int line = 0; line < maxLineLength; line++) {
                        m_affineBuffer = ParallelogramChanger(inputBuffer, maxLineLength, blockLength, m_regManager.maxBlockNum, line, width, lastBlockDifference);
                        if (m_affineBuffer != null) {
                            progCode = AffineTransformer(m_affineBuffer, line, width, maxLineLength, bitShiftinValue);
                        } else {
                            progCode = ProgramCode.AffineBufferError;
                        }
                    }
                    //RGB buffer毎にコピーしています
                    if (colorNum == 0) {
                        m_OutputRValue = (byte[])m_OutputPixelValue.Clone();
                    }
                    if (colorNum == 1) {
                        m_OutputGValue = (byte[])m_OutputPixelValue.Clone(); 
                    }
                    if (colorNum == 2) {
                        m_OutputBValue = (byte[])m_OutputPixelValue.Clone();
                    }
                }
            } else {
                //本処理
                for (int line = 0; line < maxLineLength; line++) {
                    m_affineBuffer = ParallelogramChanger(m_processBuffer, maxLineLength, blockLength, m_regManager.maxBlockNum, line, width, lastBlockDifference);
                    if (m_affineBuffer != null) {
                        AffineTransformer(m_affineBuffer, line, width, maxLineLength, bitShiftinValue);
                    } else {
                        progCode = ProgramCode.AffineBufferError;
                    }
                }
            }
            //After Process
            if (progCode == ProgramCode.Done) {
                progCode = CreateImageFile(maxLineLength, width);
            }
            if (progCode == ProgramCode.Done) {
                m_affineBuffer = null;
                m_processBuffer = null;
                m_OutputRValue = null;
                m_OutputGValue = null;
                m_OutputBValue = null;
                m_OutputPixelValue = null;
            }
            return progCode;
        }
        /// <summary>
        /// 平行四辺形する
        /// </summary>
        /// <param name="processBuffer"></param>
        /// <param name="maxLength"></param>
        /// <param name="blockLength"></param>
        /// <param name="bitmapMaxBlockNum"></param>
        /// <param name="mainLine"></param>
        /// <param name="width"></param>
        /// <param name="lastBlockDifference"></param>
        /// <returns></returns>
        public byte[] ParallelogramChanger(byte[] processBuffer, int maxLength, int blockLength, int bitmapMaxBlockNum, int mainLine, int width, int lastBlockDifference)
        {
            //Init Value
            var affineBuffer = new byte[(rom_MaxLineLength) * width];
            int copyAddress = 0;
            int tempconstBlockLength = blockLength;

            int dbgOffset = (m_regManager.difference * mainLine - m_regManager.offsetCenterY) >> rom_BitShifter;
            int degreePls = 0;

            //本処理
            if (m_regManager.yAddress.Min() >= 0) {
            } else {
                degreePls = rom_MaxLineLength - 1;
            }

            int firstLine = mainLine;
            int lineLengthMaxForParallelogram = rom_MaxLineLength + mainLine;

            int maxIdx = maxLength * width;

            for (int line = firstLine; line < lineLengthMaxForParallelogram; line++) {
                    int processBufferAddressSub = (width * (line - firstLine));
                for (int blockNum = 0; blockNum < bitmapMaxBlockNum; blockNum++) {
                    if (lastBlockDifference != 0) {
                        if (blockNum + 1 == bitmapMaxBlockNum) {
                            tempconstBlockLength = width;
                        }
                    }
                    int startAddress = line + m_regManager.yAddress[blockNum] - degreePls ;
                    startAddress += dbgOffset;
                    startAddress *= width;
                    //Block中のコピー処理
                    for (int i = copyAddress; i < tempconstBlockLength; i++) {
                        int processBufferAddress = startAddress + i - processBufferAddressSub;
                        if ((startAddress >= 0) && (processBufferAddress < maxIdx)) {
                            //もしゼロだった場合1を入れる処理
                            if (processBuffer[processBufferAddress] == 0) {
                                affineBuffer[i] = 1;
                            } else {
                                affineBuffer[i] = processBuffer[processBufferAddress];
                            }
                        } else {
                            affineBuffer[i] = 0;
                        }
                    }
                    copyAddress += blockLength;
                    tempconstBlockLength += blockLength;

                    if (lastBlockDifference != 0) {
                        if (blockNum + 1 == bitmapMaxBlockNum) {
                            copyAddress = width;
                        }
                    }
                }
            }
            return affineBuffer;
        }
        /// <summary>
        /// アフィン変換処理
        /// </summary>
        /// <param name="affineBuffer"></param>
        /// <param name="mainLine"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="bitShiftValue"></param>
        /// <returns></returns>
        private ProgramCode AffineTransformer(byte[] affineBuffer, int mainLine, int width, int height, int bitShiftValue)
        {
            var progCode = ProgramCode.Done;
            int blockNum = 0;
            int tempBlockNum =0;

            if ((height == 0) || (width == 0)) {
                progCode = ProgramCode.InputImageError;
            }
            if ((m_regManager.outputE == 0) || (m_regManager.outputF == 0)) {
                progCode = ProgramCode.InputValueError;
            }
            long lineNum = mainLine<< rom_BitShifter;
            if (progCode == ProgramCode.Done) {
                for (int x = 0; x < width; x++) {
                    //Affine Calculation
                    int rowX = x<< rom_BitShifter;
                    long affineX = ((long)bitShiftValue * (rowX - (mainLine * m_regManager.outputBigA) + m_regManager.outputBigB ))/m_regManager.outputE;
                    long affineY = ((long)bitShiftValue * (lineNum-(x*m_regManager.outputBigC) + m_regManager.outputBigD))/m_regManager.outputF;
                    int coorX = (int)(affineX >> rom_BitShifter);
                    int coorY = (int)(affineY >> rom_BitShifter);
                    blockNum = (int)(coorX >> 7);
                    if ((blockNum >= m_regManager.yAddress.Length) || (blockNum < 0)) {
                        blockNum = 0;
                    }
                    tempBlockNum = (int)((coorX + 1) >> 7);
                    if (tempBlockNum >= m_regManager.yAddress.Length || tempBlockNum < 0) {
                        tempBlockNum = 0;
                    }
                    long poweredTwoX = coorX<< rom_BitShifter;
                    long poweredTwoY = coorY<< rom_BitShifter;
                    int fractionX = (int)(affineX-poweredTwoX);
                    int fractionY = (int)(affineY-poweredTwoY);
                    m_OutputPixelValue = BilinearInterPolation(affineBuffer, width, fractionX, fractionY, x, mainLine, coorX, coorY, blockNum, tempBlockNum);
                }
            }
            return progCode;
        }
        /// <summary>
        /// バイリニア行います
        /// </summary>
        /// <param name="affineBuffer"></param>
        /// <param name="width"></param>
        /// <param name="fractionX"></param>
        /// <param name="fractionY"></param>
        /// <param name="mainX"></param>
        /// <param name="mainY"></param>
        /// <param name="coorX"></param>
        /// <param name="coorY"></param>
        /// <param name="blockNum"></param>
        /// <param name="halfBlockNum"></param>
        /// <returns></returns>
        private byte[] BilinearInterPolation(byte[] affineBuffer, int width, int fractionX, int fractionY, int mainX, int mainY, int coorX, int coorY, int blockNum, int halfBlockNum)
        {
            int cX0Yplus1 = 0;
            int cXplus1Yplus1 = 0;
            int cX0Y0 = 0;
            int cXplus1Y0 = 0;

            int dbgOffset = (m_regManager.difference * mainY - m_regManager.offsetCenterY) >> rom_BitShifter;
            int degreePls = 0;

            if (m_regManager.yAddress.Min() >= 0) {

            } else {
                degreePls = rom_MaxLineLength - 1;
            }
            int coolYPara = (coorY - (mainY - degreePls));
            coolYPara -= dbgOffset;

            int paraY1 = coolYPara - m_regManager.yAddress[blockNum];
            int paraY2 = coolYPara - m_regManager.yAddress[halfBlockNum];

            if ((width * paraY1 + coorX) < affineBuffer.Length) {
                if ((width * paraY1) + coorX >= 0) {
                    cX0Y0 = affineBuffer[(width * paraY1) + coorX];
                } else {
                    cX0Y0 = 0;
                }
            } else {
                cX0Y0 = 0;
            }
            if ((width * (paraY2)) + coorX + 1 < affineBuffer.Length) {
                if ((width * (paraY2)) + coorX + 1 >= 0) {

                    cXplus1Y0 = affineBuffer[(width * (paraY2)) + coorX + 1];
                } else {
                    cXplus1Y0 = 0;
                }
            } else {
                cXplus1Y0 = 0;
            }
            if (coorX >= 0) {
                if ((width * (paraY1 + 1)) + coorX < affineBuffer.Length) {

                    if ((width * (paraY1 + 1)) + coorX >= 0) {
                        cX0Yplus1 = affineBuffer[(width * (paraY1 + 1)) + coorX];
                    } else {
                        cX0Yplus1 = 0;
                    }
                } else {
                    cX0Yplus1 = 0;
                }
                if ((width * (paraY2 + 1)) + coorX + 1 < affineBuffer.Length) {
                    if ((width * (paraY2 + 1)) + coorX + 1 >= 0) {

                        cXplus1Yplus1 = affineBuffer[(width * (paraY2 + 1)) + coorX + 1];
                    } else {
                        cXplus1Yplus1 = 0;
                    }
                } else {
                    cXplus1Yplus1 = 0;
                }
            }
            long pixelValue = InterpolCalculation(cX0Y0, cXplus1Y0, cX0Yplus1, cXplus1Yplus1, fractionX, fractionY);
            long bitshifted =pixelValue >>rom_BitShifter;
            m_OutputPixelValue[(width * mainY) + mainX] = (byte)bitshifted;
            return m_OutputPixelValue;
        }
        /// <summary>
        /// バイリニアの計算処理
        /// </summary>
        /// <param name="cX0Y0"></param>
        /// <param name="cXplus1Y0"></param>
        /// <param name="cX0Yplus1"></param>
        /// <param name="cXplus1Yplus1"></param>
        /// <param name="deltaX"></param>
        /// <param name="deltaY"></param>
        /// <returns></returns>
        private long InterpolCalculation(int cX0Y0, int cXplus1Y0, int cX0Yplus1, int cXplus1Yplus1, int deltaX, int deltaY)
        {
            long bitshiftedcX0Y0 = cX0Y0<<rom_BitShifter ;
            long bitshiftedcX0Yplus1 = cX0Yplus1 << rom_BitShifter;
            long halfX0Value = bitshiftedcX0Y0 + (cXplus1Y0 - cX0Y0) * deltaX;
            long halfx1Value = bitshiftedcX0Yplus1 + (cXplus1Yplus1 - cX0Yplus1) * deltaX;
            long retValue = halfX0Value +(((halfx1Value - halfX0Value) * deltaY ) >> rom_BitShifter);
            return retValue;
        }
        /// <summary>
        /// 最後に画像を作ります。
        /// </summary>
        /// <param name="height"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        private ProgramCode CreateImageFile(int height, int width)
        {
            ProgramCode progCode = ProgramCode.Done;
            int outputX =0;
            int outputY =0;
            if (m_OutputImage != null) {
                m_OutputImage = null;
            }
            m_ListemptyXCoordinate = new List<int>();
            m_ListemptyYCoordinate = new List<int>();
            if (m_InputImage.PixelFormat == PixelFormat.Format32bppArgb) {
                m_OutputImage = new Bitmap(width, height, PixelFormat.Format32bppArgb);
                for (int i = 0; i < width * height; i++) {
                    Color clr = Color.FromArgb(m_OutputRValue[i], m_OutputGValue[i], m_OutputBValue[i]);
                    m_OutputImage.SetPixel(outputX, outputY, clr);
                    if ((outputX > width / 4) && (outputX < width - width / 4) && (outputY > height / 4) && (outputY < height - height / 4)) {
                        if ((m_OutputRValue[i] == 0) && (m_OutputGValue[i] == 0) && (m_OutputBValue[i] == 0)) {
                            m_ListemptyXCoordinate.Add(outputX);
                            m_ListemptyYCoordinate.Add(outputY);
                        }
                    }
                    outputX++;
                    if (outputX == width) {
                        outputX = 0;
                        outputY += 1;
                    }
                }
            } else {
                m_OutputImage = new Bitmap(width, height, PixelFormat.Format32bppArgb);
                for (int i = 0; i < width * height; i++) {
                    Color clr = Color.FromArgb(m_OutputPixelValue[i], m_OutputPixelValue[i], m_OutputPixelValue[i]);
                    m_OutputImage.SetPixel(outputX, outputY, clr);
                    if ((outputX > width / 4) && (outputX < width - width / 4) && (outputY > height / 4) && (outputY < height - height / 4)) {
                        if ((m_OutputPixelValue[i] == 0) && (m_OutputPixelValue[i] == 0) && (m_OutputPixelValue[i] == 0)) {
                            m_ListemptyXCoordinate.Add(outputX);
                            m_ListemptyYCoordinate.Add(outputY);
                        }
                    }
                    outputX++;
                    if (outputX == width) {
                        outputX = 0;
                        outputY += 1;
                    }
                }
            }
            return progCode;
        }
        #region Logger
        /// <summary>
        /// Directory Checker
        /// </summary>
        /// <param name="path"></param>
        public static void VerifyDir(string path)
        {
            try {
                DirectoryInfo dir = new DirectoryInfo(path);
                if (!dir.Exists) {
                    dir.Create();
                }
            } catch { }
        }

        public static void Logger(int xcoor, int lineNUm, int mainY, int startaddress, int pbufferAddress,  byte affineBufferValue, byte processbufferValue)
        {
            string path = @"C:\Users\Khos\Desktop\New folder\";
            VerifyDir(path);
            string fileName = DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + "Parallelogram.csv";
            try {
                System.IO.StreamWriter file = new System.IO.StreamWriter(path + fileName, true);
                file.WriteLine(DateTime.Now.ToString()+ ": " + ", " + "iCoordinate: " + ", " + xcoor +  ", " + "lineNum: " + ", " + lineNUm + ", " + "yCoordinate:" + ", " + mainY + ", " + "StartAddress: " + ", " + startaddress + ", " + "StartAddress+i: " + ", " + pbufferAddress + ", " + "affineBufferValue: " + ", " + affineBufferValue + ", " + "processBufferValue: " + ", " + processbufferValue);
                file.Close();
            } catch (Exception) { }
        }
        #endregion
        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue) {
                if (disposing) {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~ImageProcessor() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
#endregion
    }
}