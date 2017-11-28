using RJ.Tools.NotesTransfer.Engines.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ.Tools.NotesTransfer.Engines.Enums
{
    /// <summary>
    /// ロジック種別
    /// </summary>
    public enum LogicType
    {
        Or,
        And
    }

    /// <summary>
    /// 演算子の種別
    /// </summary>
    public enum OperatorType
    {
        /// <summary>
        /// 等しい
        /// </summary>
        [EnumName("次の値に等しい", OperatorType.Eq)]
        Eq,
        /// <summary>
        /// 等しくない
        /// </summary>
        [EnumName("次の値に等しくない", OperatorType.Neq)]
        Neq,
        /// <summary>
        /// より大きい
        /// </summary>
        [EnumName("次の値より大きい", OperatorType.Gt)]
        Gt,
        /// <summary>
        /// より小さい
        /// </summary>
        [EnumName("次の値より小さい", OperatorType.Lt)]
        Lt,
        /// <summary>
        /// 以上
        /// </summary>
        [EnumName("次の値以上", OperatorType.Geq)]
        Geq,
        /// <summary>
        /// 以下
        /// </summary>
        [EnumName("次の値以下", OperatorType.Leq)]
        Leq,
        /// <summary>
        /// 含む
        /// </summary>
        [EnumName("次の値を含む", OperatorType.Contains)]
        Contains,
        /// <summary>
        /// で始まる
        /// </summary>
        [EnumName("次の値で始まる", OperatorType.BeginsWith)]
        BeginsWith,
        /// <summary>
        /// 日付範囲
        /// </summary>
        DateRangesOverlap,
        In,
        Includes,
        NotIncludes,
        /// <summary>
        /// NULL
        /// </summary>
        IsNull,
        /// <summary>
        /// NOT NULL
        /// </summary>
        IsNotNull,
    }
}
