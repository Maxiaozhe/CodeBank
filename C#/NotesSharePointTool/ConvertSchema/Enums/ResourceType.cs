using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ.Tools.NotesTransfer.Engines.Enums
{
    /// <summary>
    /// リソースファイルの種別
    /// </summary>
    public enum ResourceType
    {
        /// <summary>
        /// データベースアイコン
        /// </summary>
        SmallDBIcon,
        /// <summary>
        /// 大きいデータベースアイコン
        /// </summary>
        LargeDBIcon,
        /// <summary>
        /// イメージリソース
        /// </summary>
        ImageResource,
        /// <summary>
        /// フォームDXLパス
        /// </summary>
        FormDxl,
        /// <summary>
        /// スタイルシートのパス
        /// </summary>
        StyleSheet,

    }
}
