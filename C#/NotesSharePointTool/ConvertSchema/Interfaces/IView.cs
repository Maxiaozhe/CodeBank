using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RJ.Tools.NotesTransfer.Engines.Enums;
using RJ.Tools.NotesTransfer.Engines.Entity;
namespace RJ.Tools.NotesTransfer.Engines.Interfaces
{
    public interface IView
    {

        string TaskId { get; }

        /// <summary>
        /// ビューの名前です
        /// </summary>
        string Name
        {
            get;
        }
        /// <summary>
        /// ビューの表示名
        /// </summary>
        string DisplayName
        {
            get;
            set;
        }

        /// <summary>
        /// 別名
        /// </summary>
        List<string> Aliases
        {
            get;
        }
        /// <summary>
        /// ビューのURL
        /// </summary>
        string NotesUrl
        {
            get;
        }
        /// <summary>
        /// 変換元ビューの種別
        /// </summary>
        NotesViewType SourceType
        {
            get;
        }
        /// <summary>
        /// 変換先ビューの種別
        /// </summary>
        SPViewType TargetType
        {
            get;
        }

        /// <summary>
        /// デフォルトビューかどうか
        /// </summary>
        bool IsDefault
        {
            get;
        }
        /// <summary>
        /// 既定のビュー
        /// </summary>
        bool IsDefaultView
        {
            get;
            set;
        }
        /// <summary>
        /// ビュー抽出数式
        /// </summary>
        string SelectionFormula { get; }
        /// <summary>
        /// 変換元列コレクション
        /// </summary>
        List<IViewColumn> SourceViewColumns
        {
            get;
        }
        /// <summary>
        /// 表示列
        /// </summary>
        List<IViewColumn> ViewColumns
        {
            get;
        }
        /// <summary>
        /// ソート列
        /// </summary>
        List<IViewColumn> SortColumns
        {
            get;
        }
        /// <summary>
        /// グループ列
        /// </summary>
        List<IViewColumn> GroupColumns
        {
            get;
        }
        /// <summary>
        /// ビューの条件式
        /// </summary>
        LogicItem ViewCondition
        {
            get;
        }
        /// <summary>
        /// 変換対象かどうか
        /// </summary>
        bool IsTarget
        {
            get;
            set;
        }
        /// <summary>
        /// ページングするか
        /// </summary>
        bool IsPaged
        {
            get;
            set;
        }

        /// <summary>
        /// １ページの表示件数
        /// </summary>
        int RowLimit { get; set; }
        /// <summary>
        /// チェックボックスを表示するか
        /// </summary>
        bool ShowChecked { get; set; }
        /// <summary>
        /// 別名の文字列を取得する
        /// </summary>
        /// <returns></returns>
        string GetAliasesString();

        /// <summary>
        /// 参照フォーム一覧を取得する
        /// </summary>
        /// <returns></returns>
        string[] ReferForms{get;}

        /// <summary>
        /// SharePoint側生成されたGUID
        /// </summary>
        string SpId
        {
            get;
            set;
        }
        /// <summary>
        /// SharePoint側のServerRelativeUrl
        /// </summary>
        string SpUrl
        {
            get;
            set;
        }

        /// <summary>
        /// Field参照を更新する
        /// </summary>
        /// <param name="findField"></param>
        void RefreshFieldRef(Func<string, IFieldRef> findField);

    }
}
