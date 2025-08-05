using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Affine_Transformer
{
    public enum ProgramCode
    {
        /// <summary>
        /// 正常は「0」です
        /// </summary>
        Done = 0,
        /// <summary>
        /// 入力値エラー
        /// </summary>
        InputValueError = 1,
        /// <summary>
        /// 入力画像エラー
        /// </summary>
        InputImageError,
        /// <summary>
        /// 画像はBitmapとして保存されてない
        /// </summary>
        ImageIsNull,
        /// <summary>
        /// 計算エラー
        /// </summary>
        CalculationError,
        /// <summary>
        /// 出力値がゼロ
        /// </summary>
        OutputValueIsZero,
        /// <summary>
        /// アフィン変換行うバッファエラー
        /// </summary>
        AffineBufferError,
        /// <summary>
        /// 計算値エラー
        /// </summary>
        OutputValueError,
        /// <summary>
        /// レジストリマネージャーを読み取りエラー
        /// </summary>
        RegistryError,
    }
    /// <summary>
    /// プログラムの状態確認
    /// </summary>
    public static class ProgramCondition
    {
        public static string ToStringMessage(this ProgramCode progCode)
        {
            string message = "";

            switch (progCode) {
            case ProgramCode.Done:
                message = "正常";
                break;
            case ProgramCode.InputImageError:
                message = "入力画像エラー";
                break;
            case ProgramCode.InputValueError:
                message = "入力値エラー";
                break;
            case ProgramCode.ImageIsNull:
                message = "画像はBitmapとして保存されてない";
                break;
            case ProgramCode.CalculationError:
                message = "計算エラー";
                break;
            case ProgramCode.OutputValueIsZero:
                message = "出力値がゼロ";
                break;
            case ProgramCode.AffineBufferError:
                message = "アフィン変換行うバッファエラー";
                break;
            case ProgramCode.OutputValueError:
                message = "計算値エラー";
                break;
            case ProgramCode.RegistryError:
                message = "レジストリマネージャーを読み取りエラー";
                break;
            default:
                break;
            }
            return message;
        }
    }
}
