using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Affine_Transformer
{
    class InterfaceManager :IDisposable
    {
        /// <summary>
        /// 計算処理
        /// </summary>
        FirmwareCalculation m_FirmwareCalculation;
        /// <summary>
        /// 計算データ保存ところ
        /// </summary>
        public RegistryManager m_RegManager;
        /// <summary>
        /// 画像処理するクラス
        /// </summary>
        ImageProcessor m_ImageProcessor;
        #region Initial Values
        /// <summary>
        /// 処理する画像
        /// </summary>
        Bitmap m_bmpImage;
        /// <summary>
        /// Bitmap画像のファイル名前
        /// </summary>
        public string m_fileName { private get; set; }
        /// <summary>
        /// ブロックの長さ
        /// </summary>
        private readonly int rom_blockLength = 128;
        /// <summary>
        /// 二の十乗
        /// </summary>
        private readonly int rom_Bitshifter =8192;
        /// <summary>
        /// 最後のブロックの違え
        /// </summary>
        private int m_lastBlockDifference =0;
        /// <summary>
        /// 最大のブロックNo
        /// </summary>
        private int m_maxBlockNum {get; set; }
        /// <summary>
        /// 角度
        /// </summary>
        public float m_angle { get; set; }
        /// <summary>
        /// ラジアンで角度を保存する
        /// </summary>
        private float m_angleInRadians { get; set; }
        /// <summary>
        /// 中心X
        /// </summary>
        public float m_centerX { get; set; }
        /// <summary>
        /// 中心Y
        /// </summary>
        public float m_centerY { get; set; }
        #region For Screen Only
        /// <summary>
        /// 画面に出す値A
        /// </summary>
        public float m_OutPutValueA { get; private set; }
        /// <summary>
        /// 画面に出す値B
        /// </summary>
        public float m_OutPutValueB{get; private set;}
        /// <summary>
        /// 画面に出す値C
        /// </summary>
        public float m_OutPutValueC{get; private set;}
        /// <summary>
        /// 画面に出す値D
        /// </summary>
        public float m_OutPutValueD{get; private set;}
        /// <summary>
        /// 画面に出す値X
        /// </summary>
        public float m_OutPutValueX{get; private set;}
        /// <summary>
        /// 画面に出す値Y
        /// </summary>
        public float m_OutPutValueY{get; private set;}
        /// <summary>
        /// 画面に出す値E
        /// </summary>
        public float m_OutPutValueE{get; private set;}
        /// <summary>
        /// 画面に出す値F
        /// </summary>
        public float m_OutPutValueF{get; private set;}
        /// <summary>
        /// For Calculation only
        /// </summary>
        public float m_OutPutValueBigA { get; private set; }
        /// <summary>
        /// For Calculation only
        /// </summary>
        public float m_OutPutValueBigB { get; private set; }
        /// <summary>
        /// For Calculation only
        /// </summary>
        public float m_OutPutValueBigC { get; private set; }
        /// <summary>
        /// For Calculation only
        /// </summary>
        public float m_OutPutValueBigD { get; private set; }
        /// <summary>
        /// 画面に出す値差
        /// </summary>
        public float m_DifferenceValue { get; private set; }
        /// <summary>
        /// Output Image
        /// </summary>
        public Bitmap m_OutPutImage { get; internal set; }
        /// <summary>
        /// 無効データのX座標
        /// </summary>
        internal List<int> m_InvalidXCoordinateArray;
        /// <summary>
        /// 無効データのY座標
        /// </summary>
        internal List<int> m_InvalidYCoordinateArray;
        #endregion
        #endregion
        /// <summary>
        /// ctor
        /// </summary>
        public InterfaceManager()
        {
            m_fileName = "";
            m_FirmwareCalculation = new FirmwareCalculation();
            m_RegManager = new RegistryManager();
            m_ImageProcessor = new ImageProcessor();
            m_bmpImage = null;
            m_OutPutImage = null;
            m_angleInRadians = 0;
            m_InvalidXCoordinateArray = null;
            m_InvalidYCoordinateArray = null;
        }
        /// <summary>
        /// 出力の値を計算します
        /// </summary>
        /// <returns></returns>
        public ProgramCode InitialBackEnd()
        {
            ProgramCode progCode = ProgramCode.Done;
            if (string.IsNullOrWhiteSpace(m_fileName)) {
                progCode = ProgramCode.ImageIsNull;
            }
            if (progCode == ProgramCode.Done) {
                if(m_bmpImage != null) {
                    m_bmpImage.Dispose();
                    m_bmpImage = null;
                }
                m_bmpImage = new Bitmap(m_fileName);
                int width = m_bmpImage.Width;
                m_maxBlockNum = width / rom_blockLength;
                if (width % rom_blockLength != 0) {
                    m_maxBlockNum += 1;
                    m_lastBlockDifference = width % rom_blockLength;
                }
                m_RegManager.maxBlockNum = m_maxBlockNum;
                progCode = CalculateFactors();
            }
            if (progCode == ProgramCode.Done) {
                progCode = CalculateYaddress();
            }
            return progCode;
        }
        #region Calculation
        /// <summary>
        /// a, b, c, dを計算します
        /// </summary>
        /// <returns></returns>
        private ProgramCode CalculateFactors()
        {
            ProgramCode progCode = ProgramCode.Done;
            m_angleInRadians = m_FirmwareCalculation.ToRadianCalculation(m_angle);
            //計算処理
            m_OutPutValueA = m_FirmwareCalculation.CalculateOutputA(m_angleInRadians);
            m_OutPutValueB = m_FirmwareCalculation.CalculateOutputB(m_angleInRadians);
            m_OutPutValueC = m_FirmwareCalculation.CalculateOutputC(m_angleInRadians);
            m_OutPutValueD = m_FirmwareCalculation.CalculateOutputD(m_angleInRadians);
            m_OutPutValueX = m_FirmwareCalculation.CalculateOutputX(m_centerX, m_centerY, m_OutPutValueA, m_OutPutValueC);
            m_OutPutValueY = m_FirmwareCalculation.CalculateOutputY(m_centerX, m_centerY, m_OutPutValueA, m_OutPutValueC);
            m_OutPutValueE = m_FirmwareCalculation.CalculateOutputE(m_OutPutValueA, m_OutPutValueB, m_OutPutValueC, m_OutPutValueD);
            m_OutPutValueF = m_FirmwareCalculation.CalculateOutputF(m_OutPutValueA, m_OutPutValueB, m_OutPutValueC, m_OutPutValueD);
            m_OutPutValueBigA = m_FirmwareCalculation.CalculateBigA(m_OutPutValueB, m_OutPutValueD);
            m_OutPutValueBigB = m_FirmwareCalculation.CalculateBigB(m_OutPutValueBigA, m_OutPutValueX, m_OutPutValueY);
            m_OutPutValueBigC = m_FirmwareCalculation.CalculateBigC(m_OutPutValueA, m_OutPutValueC);
            m_OutPutValueBigD = m_FirmwareCalculation.CalculateBigD(m_OutPutValueBigC, m_OutPutValueX, m_OutPutValueY);
            //16bit left shift and saves it in INT
            m_RegManager.outputA = (int)(m_OutPutValueA * rom_Bitshifter);
            m_RegManager.outputB = (int)(m_OutPutValueB * rom_Bitshifter);
            m_RegManager.outputC = (int)(m_OutPutValueC * rom_Bitshifter);
            m_RegManager.outputD = (int)(m_OutPutValueD * rom_Bitshifter);
            m_RegManager.outputX = (int)(m_OutPutValueX * rom_Bitshifter);
            m_RegManager.outputY = (int)(m_OutPutValueY * rom_Bitshifter);
            m_RegManager.outputE = (int)(m_OutPutValueE * rom_Bitshifter);
            m_RegManager.outputF = (int)(m_OutPutValueF * rom_Bitshifter);
            m_RegManager.outputBigA = (int)(m_OutPutValueBigA * rom_Bitshifter);
            m_RegManager.outputBigB = (int)(m_OutPutValueBigB * rom_Bitshifter);
            m_RegManager.outputBigC = (int)(m_OutPutValueBigC * rom_Bitshifter);
            m_RegManager.outputBigD = (int)(m_OutPutValueBigD * rom_Bitshifter);
            m_RegManager.offsetCenterY = (int)((m_OutPutValueY / Math.Cos(m_angleInRadians)) * rom_Bitshifter);

            return progCode;
        }
        /// <summary>
        /// yAddressを計算します。次の開始アドレスとして使用します。
        /// </summary>
        /// <returns></returns>
        private ProgramCode CalculateYaddress()
        {
            ProgramCode progCode = ProgramCode.Done;
            m_angleInRadians = m_FirmwareCalculation.ToRadianCalculation(m_angle);
            float difference =0.0f;
            m_RegManager.yAddress = m_FirmwareCalculation.CalculateYaddress(rom_blockLength, m_maxBlockNum, m_angleInRadians, out difference, m_angle);
            m_DifferenceValue = difference;
            m_RegManager.difference = (int)(m_DifferenceValue * rom_Bitshifter);
            return progCode;
        }
        #endregion 
        /// <summary>
        /// 画像処理します
        /// </summary>
        /// <returns></returns>
        public ProgramCode ProcessImage()
        {
            ProgramCode progCode = ProgramCode.Done;
            
            //set Values to the Image Processor
            if (progCode == ProgramCode.Done) {
                progCode = m_ImageProcessor.GetValues(m_RegManager);
            } 
            if (progCode == ProgramCode.Done) {
                progCode = m_ImageProcessor.ImageProcess(m_bmpImage, rom_blockLength, m_lastBlockDifference, rom_Bitshifter);
            } else {
                progCode = ProgramCode.OutputValueError;
            }
            if(progCode == ProgramCode.Done) {
                m_OutPutImage = m_ImageProcessor.m_OutputImage;
                m_InvalidXCoordinateArray = m_ImageProcessor.m_ListemptyXCoordinate;
                m_InvalidYCoordinateArray = m_ImageProcessor.m_ListemptyYCoordinate;
            }
            return progCode;
        }
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
        // ~InterfaceManager() {
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
