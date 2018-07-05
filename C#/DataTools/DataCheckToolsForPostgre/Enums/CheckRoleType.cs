using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rex.Tools.Test.DataCheck.Enums
{
    /// <summary>
    /// データ処理の種別
    /// </summary>
    public enum DataProcessType
    {
        /// <summary>
        /// 生産計画Noへ変換する
        /// </summary>
        PRODUCTION_PLAN_NO,
        /// <summary>
        /// 稼動計画Noへ変換する
        /// </summary>
        OPERATION_PLAN_NO,
        /// <summary>
        /// 自動採番列の番号をリセットする
        /// </summary>
        RESET,
        /// <summary>
        /// 比較しない列（列を削除する）
        /// </summary>
        SKIP
    }
    /// <summary>
    /// データ処理の対象
    /// </summary>
    public enum ProcessTarget
    {
        /// <summary>
        /// 期待データ
        /// </summary>
        ExpectData,
        /// <summary>
        /// 結果データ
        /// </summary>
        ResultData,
        /// <summary>
        /// 両方
        /// </summary>
        Both
    }
}
