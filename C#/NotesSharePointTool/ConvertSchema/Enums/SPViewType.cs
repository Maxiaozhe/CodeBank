using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RJ.Tools.NotesTransfer.Engines.Enums
{
    /// <summary>
    /// ビューの種別
    /// </summary>
    public enum SPViewType:int
    {
        None = 0,
        /// <summary>
        /// 標準ビュー
        /// </summary>
        Html = 1,
        /// <summary>
        /// データシート ビュー 
        /// </summary>
        Grid = 2048,
        /// <summary>
        /// 再発リスト
        /// </summary>
        Recurrence = 8193,
        /// <summary>
        /// チャット
        /// </summary>
        Chart = 131072,
        /// <summary>
        /// 予定表ビュー 
        /// </summary>
        Calendar = 524288,
        /// <summary>
        /// ガントビュー
        /// </summary>
        Gantt = 67108864,
    }
}
