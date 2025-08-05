using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Affine_Transformer
{
    class RegistryManager
    {
        #region 出力値
        /// <summary>
        /// 出力のa
        /// </summary>
        public int outputA { get; set; }
        /// <summary>
        /// 出力のb
        /// </summary>
        public int outputB { get; set; }
        /// <summary>
        /// 出力のc
        /// </summary>
        public int outputC { get; set; }
        /// <summary>
        /// 出力のd
        /// </summary>
        public int outputD { get; set; }
        /// <summary>
        /// 出力のX
        /// </summary>
        public int outputX { get; set; }
        /// <summary>
        /// 出力のY
        /// </summary>
        public int outputY { get; set; }
        /// <summary>
        /// 出力のE
        /// </summary>
        public int outputE { get;  set; }
        /// <summary>
        /// 出力のF
        /// </summary>
        public int outputF { get;  set; }
        /// <summary>
        /// アドレスの差
        /// </summary>
        public int difference { get; internal set; }
        /// <summary>
        /// 回転中心が入った場合のY方向オフセット値
        /// </summary>
        public int offsetCenterY { get; set; }
        #endregion
        #region Calculation
        /// <summary>
        /// 開始Yアドレス
        /// </summary>
        public int[] yAddress { get; set; }
        /// <summary>
        /// b/d
        /// </summary>
        public int outputBigA { get; internal set; }
        /// <summary>
        /// (A*y0)-x0
        /// </summary>
        public int outputBigB { get; internal set; }
        /// <summary>
        /// c/a
        /// </summary>
        public int outputBigC { get; internal set; }
        /// <summary>
        /// (C *x0)-y0
        /// </summary>
        public int outputBigD { get; internal set; }
        /// <summary>
        /// 最大のブロック数
        /// </summary>
        public int maxBlockNum { get; set; }
        #endregion
        /// <summary>
        /// ctor
        /// </summary>
        public RegistryManager()
        {
            //出力値の初期化
            outputA = 0;
            outputB = 0;
            outputC = 0;
            outputD = 0;
            outputE = 0;
            outputF = 0;
            outputX = 0;
            outputY = 0;
            yAddress = new int[maxBlockNum];
        }

    }
}
