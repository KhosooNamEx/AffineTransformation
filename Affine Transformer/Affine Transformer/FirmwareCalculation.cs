using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Affine_Transformer
{
    public class FirmwareCalculation :IDisposable
    {
        /// <summary>
        /// ctor
        /// </summary>
        public FirmwareCalculation()
        {

        }
        /// <summary>
        /// 角度をラジアンに変更する
        /// </summary>
        /// <returns></returns>
        public float ToRadianCalculation(float angle)
        {
            return Convert.ToSingle(Math.PI / 180 * angle);
        }
#region 出力値を計算します
        /// <summary>
        /// 出力のAを計算する
        /// </summary>
        /// <returns></returns>
        public float CalculateOutputA(float angleInRadians)
        {
            return Convert.ToSingle(Math.Cos(angleInRadians));
        }
        /// <summary>
        /// 出力のBを計算する
        /// </summary>
        /// <param name="angleInRadians"></param>
        /// <returns></returns>
        internal float CalculateOutputB(float angleInRadians)
        {
            return Convert.ToSingle(-Math.Sin(angleInRadians));
        }
        /// <summary>
        /// 出力のCを計算する
        /// </summary>
        /// <returns></returns>
        internal float CalculateOutputC(float angleInRadians)
        {
            return Convert.ToSingle(Math.Sin(angleInRadians));
        }
        /// <summary>
        /// 出力のDを計算する
        /// </summary>
        /// <returns></returns>
        internal float CalculateOutputD(float angleInRadians)
        {
            return Convert.ToSingle(Math.Cos(angleInRadians));
        }
        /// <summary>
        /// 出力のXを計算する
        /// </summary>
        /// <returns></returns>
        internal float CalculateOutputX(float centerX, float centerY, float outputA, float outputC)
        {
            return (centerX - (centerX * outputA) + (centerY * outputC));
        }
        /// <summary>
        /// 出力のYを計算する
        /// </summary>
        /// <returns></returns>
        internal float CalculateOutputY(float centerX, float centerY, float outputA, float outputC)
        {
            return (centerY - (centerX * outputC) - (centerY * outputA));
        }
        #endregion
        /// <summary>
        /// b/d
        /// </summary>
        /// <param name="outputB"></param>
        /// <param name="outputD"></param>
        /// <returns></returns>
        internal float CalculateBigA(float outputB, float outputD)
        {
            return outputB / outputD;
        }
        /// <summary>
        /// (A*y0)-x0
        /// </summary>
        /// <param name="outPutValueBigA"></param>
        /// <param name="outPutValueX"></param>
        /// <param name="outPutValueY"></param>
        /// <returns></returns>
        internal float CalculateBigB(float outPutValueBigA, float outPutValueX, float outPutValueY)
        {
            return (outPutValueBigA * outPutValueY) - outPutValueX;
        }
        /// <summary>
        /// c/a
        /// </summary>
        /// <param name="outPutValueA"></param>
        /// <param name="outPutValueC"></param>
        /// <returns></returns>
        internal float CalculateBigC(float outPutValueA, float outPutValueC)
        {
            return outPutValueC / outPutValueA;
        }
        /// <summary>
        /// (C *x0)-y0
        /// </summary>
        /// <param name="outPutValueBigC"></param>
        /// <param name="outPutValueX"></param>
        /// <param name="outPutValueY"></param>
        /// <returns></returns>
        internal float CalculateBigD(float outPutValueBigC, float outPutValueX, float outPutValueY)
        {
            return (outPutValueBigC * outPutValueX) - outPutValueY;
        }
        /// <summary>
        /// 出力のEを計算する
        /// </summary>
        /// <param name="outputA"></param>
        /// <param name="outputB"></param>
        /// <param name="outputC"></param>
        /// <param name="outputD"></param>
        /// <returns></returns>
        internal float CalculateOutputE(float outputA, float outputB, float outputC, float outputD)
        {
            return (outputA-((outputB*outputC)/outputD));
        }
        /// <summary>
        /// 出力のFを計算する
        /// </summary>
        /// <param name="outputA"></param>
        /// <param name="outputB"></param>
        /// <param name="outputC"></param>
        /// <param name="outputD"></param>
        /// <returns></returns>
        internal float CalculateOutputF(float outputA, float outputB, float outputC, float outputD)
        {
            return (outputD - ((outputB * outputC) / outputA));
        }
        /// <summary>
        /// Yaddress を計算します
        /// </summary>
        /// <param name="constBlockLength"></param>
        /// <param name="blockmaxNum"></param>
        /// <param name="angleInRadians"></param>
        /// <param name="difference"></param>
        /// <returns></returns>
        internal int[] CalculateYaddress(int constBlockLength, int blockmaxNum, float angleInRadians, out float difference, float angle)
        {
            int[] yAddress = new int[blockmaxNum];
            int blockLength =0;
            float angleIntan = Convert.ToSingle(Math.Tan(angleInRadians));

            float diffY1 = Convert.ToSingle(Math.Cos(angleInRadians));
            float diffX1 = Convert.ToSingle(Math.Tan(angleInRadians) * diffY1);
            float diff = Convert.ToSingle(Math.Tan(angleInRadians)* diffX1 - (1- diffY1)) ;

            int diffInt = (int)diff;
            difference = diff - diffInt;

            for (int blockNum = 0; blockNum < blockmaxNum; blockNum++) {
                if ((angleIntan > 0) && (blockNum != 0)) {
                    if ((angle>0.1f)|| (blockmaxNum>8)) {
                        yAddress[blockNum] = (int)((-1 * angleIntan * blockLength) + 1);
                    } else {
                        yAddress[blockNum] = (int)(-1 * angleIntan * blockLength);
                    }
                } else {
                    yAddress[blockNum] = (int)(-1 * angleIntan * blockLength);
                }
                blockLength += constBlockLength;
            }
            return yAddress;
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
        // ~FirmwareCalculation() {
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
