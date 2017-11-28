using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RJ.Tools.NotesTransfer.Engines.Interfaces
{
    public interface IViewColumn 
    {
        /// <summary>
        /// タイトル
        /// </summary>
        string Title { get; }

        /// <summary>
        /// フィールドか
        /// </summary>
        bool IsField { get; }

        /// <summary>
        /// 非表示するか
        /// </summary>
        bool IsHidden { get; }

        /// <summary>
        /// アイコンか
        /// </summary>
        bool IsIcon { get; }

        /// <summary>
        /// 式に基づいているか
        /// </summary>
        bool IsFormula { get; }

        /// <summary>
        /// 変換可能かどうか
        /// </summary>
        bool CanConvert { get; }
        /// <summary>
        /// 列のプログラム名。通常、フィールドに基づいた列のフィールド (アイテム) 名です
        /// </summary>
        string ItemName { get; }
        /// <summary>
        /// フィールド参照
        /// </summary>
        
        IFieldRef FieldRef { get; set; }
        /// <summary>
        /// グループ化かどうか
        /// </summary>
        bool IsCategory { get; }
        /// <summary>
        /// ソート項目かどうか
        /// </summary>
        bool IsSorted { get; }

        /// <summary>
        /// 自動ソート列が降順であるかどうかを示します。
        /// </summary>
        bool IsSortDescending { get; set; }

        /// <summary>
        /// 数式
        /// </summary>
        string Formula { get; }
    }
}
