using RJ.Tools.NotesTransfer.Engines.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RJ.Tools.NotesTransfer.Engines;
using RJ.Tools.NotesTransfer.Engines.Interfaces;
namespace RJ.Tools.NotesTransfer.Engines.Notes.Entity
{
    [Serializable]
    public class ViewColumn : IViewColumn
    {
        private string _formula;
        private bool _isField;
        private bool _isFormula;
        private bool _isHidden;
        private bool _IsIcon;
        private bool _isResponse;
        private bool _isSortDescending;
        private bool _isSorted;
        private string _itemName;
        private int _position;
        private string _title;
        private bool _canConvert;
        private bool _isCategory;
        [NonSerialized]
        private IFieldRef _fieldRef;
        #region Field

        #endregion
        #region Property
        public string Title
        {
            get { return this._title; }
        }

        public bool IsField
        {
            get { return this._isField; }
        }

        public bool IsHidden
        {
            get { return this._isHidden; }
        }

        public bool IsIcon
        {
            get { return this._IsIcon; }
        }

        public bool IsFormula
        {
            get { return this._isFormula; }
        }

        public string ItemName
        {
            get { return this._itemName; }
        }


        public IFieldRef FieldRef
        {
            get
            {
                return this._fieldRef;
            }
            set
            {
                this._fieldRef = value;
            }
        }

        public int Position
        {
            get { return this._position; }
        }

        public bool IsSorted
        {
            get { return this._isSorted; }
        }

        public bool IsSortDescending
        {
            get
            {
                return this._isSortDescending;
            }
            set
            {
                this._isSortDescending = value;
            }
        }

        public bool IsResponse
        {
            get { return this._isResponse; }
        }

        public string Formula
        {
            get { return this._formula; }
        }
        public bool CanConvert
        {
            get
            {
                return this._canConvert;
            }
            internal set
            {
                this._canConvert = value;
            }
        }

        public bool IsCategory
        {
            get
            {
                return this._isCategory;
            }
        }

        #endregion
        #region New
        internal ViewColumn(Domino.NotesViewColumn column)
        {
            this._title = column.Title;
            this._formula = column.Formula;
            this._isField = column.IsField;
            this._isFormula = column.IsFormula;
            this._isHidden = column.IsHidden;
            this._IsIcon = column.IsIcon;
            this._isResponse = column.IsResponse;
            this._isSortDescending = column.IsSortDescending;
            this._isSorted = column.IsSorted;
            this._itemName = column.ItemName;
            this._position = column.Position;
            this._isCategory = column.IsCategory;
            this._canConvert = this._isField && (!string.IsNullOrEmpty(column.ItemName));
        }

        public ViewColumn(IFieldRef fld)
        {
            this._title = fld.Title;
            this._itemName = fld.Name;
            this._isField = true;
            this._fieldRef = fld;
            this._canConvert = true;
        }

        public ViewColumn(IFieldRef fld, bool isDesc)
        {
            this._title = fld.Title;
            this._itemName = fld.Name;
            this._isField = true;
            this._fieldRef = fld;
            this._canConvert = true;
            this._isSortDescending = isDesc;
        }


        #endregion

    }
}
