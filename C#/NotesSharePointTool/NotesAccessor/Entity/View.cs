using RJ.Tools.NotesTransfer.Engines.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RJ.Tools.NotesTransfer.Engines.Interfaces;
using RJ.Tools.NotesTransfer.Engines.Entity;
using RJ.Tools.NotesTransfer.Engines.Common;

namespace RJ.Tools.NotesTransfer.Engines.Notes.Entity
{
    public class View:IView
    {
        #region Field
        private Domino.NotesView _view;
        private List<string> _aliases;
        private string _name;
        private NotesViewType _sourceType;
        private SPViewType _targetType;
        private List<IViewColumn> _sourceViewColumns;
        private bool _isDefualt;
        private IDatabase _parentDb;
        private string[] _referForms;
        private List<IViewColumn> _sortColumns;
        private List<IViewColumn> _groupColumns;
        private List<IViewColumn> _viewColumns;
        private string _taskId;
        private string _selectionFormula;
        private string _notesUrl;
        private LogicItem _viewCondition;
      
        #endregion
    
        #region Property

        public string TaskId
        {
            get { return this._taskId; }
        }


        public string Name
        {
            get {
                return this._name;
            }
        }
    
        public string DisplayName
        {
            get;
            set;
        }

        public string SelectionFormula
        {
            get { return this._selectionFormula; }
        }

        public List<string> Aliases
        {
            get
            {
                if (this._aliases == null)
                {
                    this._aliases = GetAliases(this._view);
                }
                return this._aliases;
            }
        }

        /// <summary>
        /// ビューのノーツURLを取得する
        /// </summary>
        public string NotesUrl
        {
            get { return this._notesUrl; }
        }

        public NotesViewType SourceType
        {
            get 
            {
                return this._sourceType;
            }
        }

        public SPViewType TargetType
        {
            get {
                return this._targetType;
            }
        }
        /// <summary>
        /// 既定のビューかどうか(Notesの設定情報)
        /// </summary>
        public bool IsDefault
        {
            get {
                return this._isDefualt;
            }
        }
        /// <summary>
        /// 既定のビューを設定および取得する
        /// </summary>
        public bool IsDefaultView
        {
            get;
            set;
        }

        /// <summary>
        /// 対象かどうか
        /// </summary>
        public bool IsTarget
        {
            get;
            set;
        }

        /// <summary>
        /// 変換元のビューカラム設定
        /// </summary>
        public List<IViewColumn> SourceViewColumns
        {
            get 
            {
                if (this._sourceViewColumns == null)
                {
                    this._sourceViewColumns = GetSourceViewColumns();
                }
                return this._sourceViewColumns;
            }
        }

        public string[] ReferForms
        {
            get
            {
                if (this._referForms == null)
                {
                    this._referForms = this.GetReferForms().ToArray();
                }
                return this._referForms;
            }
        }

        #endregion

        internal View(Domino.NotesView view,IDatabase parentDb)
        {
            this._parentDb = parentDb;
            this._view = view;
            if (this._view.IsCalendar) {
                this._sourceType= NotesViewType.Calendar;
            }else{
                this._sourceType= NotesViewType.Standard;
            }
            this._targetType = Enums.MappingInfo.GetTargetViewType(this.SourceType);
            this._name = this._view.Name;
            this.DisplayName = this._view.Name;
            this._isDefualt = view.IsDefaultView;
            this.IsDefaultView = view.IsDefaultView;
            this._selectionFormula = view.SelectionFormula;
            this._notesUrl = view.NotesURL;
            this._viewCondition = new LogicItem(LogicType.And);
            this._taskId = string.Empty;
            this.IsTarget = false;
            this.RowLimit = 30;
            this.ShowChecked = false;
            this.IsPaged = false;
        }

        private List<IViewColumn> GetSourceViewColumns()
        {
            List<IViewColumn> columns = new List<IViewColumn>();
            object[] colObjs = (object[])this._view.Columns;
            foreach (Domino.NotesViewColumn column in colObjs)
            {
                ViewColumn vcolumn = new ViewColumn(column);
                if (vcolumn.CanConvert)
                {
                    vcolumn.FieldRef = this._parentDb.FindField(column.ItemName);
                }
                columns.Add(vcolumn);
            }
            return columns;
        }

        private List<string> GetAliases(Domino.NotesView view)
        {
            List<string> aliases = new List<string>();
            string[] names = ((object[])view.Aliases).Cast<string>().ToArray();
            aliases.AddRange(names);
            return aliases;
        }

        public string GetAliasesString()
        {
            if (this._aliases == null || this._aliases.Count == 0)
            {
                return string.Empty;
            }
            string[] aliases = this._aliases.ToArray();
            string aliasesName = string.Join("|", aliases);
            return aliasesName;
        }

        public LogicItem ViewCondition
        {
            get { return _viewCondition; }
        }

        private List<string> GetReferForms()
        {
             List<string> fields = new List<string>();
            foreach (IViewColumn column in this.SourceViewColumns)
            {
                if ( column.CanConvert )
                {
                    fields.Add(column.ItemName);
                }     
            }
            if (fields.Count == 0)
            {
                return new List<string>();
            }
            return FindRefForms(fields);
        }

        private List<string> FindRefForms(List<string> fieldNames)
        {
            List<string> refForms = new List<string>();
          
            foreach (IForm form in this._parentDb.Forms)
            {
                foreach (IField fld in form.Fields)
                {
                    if (fieldNames.Contains(fld.Name))
                    {
                        refForms.Add(form.Name);
                        break;
                    }
                }
            }
            return refForms;
        }

    
        public List<IViewColumn> SortColumns
        {
            get {
                if (this._sortColumns == null)
                {
                    this._sortColumns = GetSortColumns();
                }
                return this._sortColumns;
            }
        }

        public List<IViewColumn> GroupColumns
        {
            get {
                if (this._groupColumns == null)
                {
                    this._groupColumns = GetGroupColumns();
                }
                return this._groupColumns;
            }
        }

        public List<IViewColumn> ViewColumns
        {
            get
            {
                if (this._viewColumns == null)
                {
                    this._viewColumns = GetViewColumns();
                }
                return this._viewColumns;
            }
        }
        /// <summary>
        /// 表示項目を取得する
        /// </summary>
        /// <returns></returns>
        private List<IViewColumn> GetViewColumns()
        {
            List<ViewColumn> viewColumns = new List<ViewColumn>();
            foreach (ViewColumn column in this.SourceViewColumns)
            {
                if (column.CanConvert)
                {
                    viewColumns.Add(column);
                }
            }
            //Position情報でソートする
            viewColumns.Sort((x, y) => x.Position.CompareTo(y.Position));
            return viewColumns.Cast<IViewColumn>().ToList();
        }

        /// <summary>
        /// グループ化項目を取得する
        /// </summary>
        /// <returns></returns>
        private List<IViewColumn> GetGroupColumns()
        {
            List<ViewColumn> groupColumns = new List<ViewColumn>();
            foreach (ViewColumn column in this.SourceViewColumns)
            {
                if (column.CanConvert && column.IsCategory)
                {
                    groupColumns.Add(column);
                }
            }
            //Position情報でソートする
            groupColumns.Sort((x, y) => x.Position.CompareTo(y.Position));
            return groupColumns.Cast<IViewColumn>().ToList();
        }

        /// <summary>
        /// 並び替えカラムを取得する
        /// </summary>
        /// <returns></returns>
        private List<IViewColumn> GetSortColumns()
        {
            List<ViewColumn> sortColumns = new List<ViewColumn>();
            foreach (ViewColumn column in this.SourceViewColumns)
            {
                if (column.CanConvert && column.IsSorted)
                {
                    sortColumns.Add(column);
                }
            }
            //Position情報でソートする
            sortColumns.Sort((x, y) => x.Position.CompareTo(y.Position));
            return sortColumns.Cast<IViewColumn>().ToList();
        }

        public int RowLimit
        {
            get;
            set;
        }

        public bool ShowChecked
        {
            get;
            set;
        }


        public bool IsPaged
        {
            get;
            set;
        }

        public void RefreshFieldRef(Func<string, IFieldRef> findField)
        {
            return;
        }

        public string SpId
        {
            get;
            set;
        }

        public string SpUrl
        {
            get;
            set;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is IView))
            {
                return false;
            }
            IView objView = (IView)obj;
            if (this._name == null || this._notesUrl == null)
            {
                return false;
            }
            return this._name.Equals(objView.Name) && this._notesUrl.Equals(objView.NotesUrl);
        }

        public override int GetHashCode()
        {
            if (this._name == null || this._notesUrl == null)
            {
                return base.GetHashCode();
            }
            return Utility.CombineHashCode(this._name.GetHashCode(),
                                            this._notesUrl.GetHashCode());
        }

    }
}
