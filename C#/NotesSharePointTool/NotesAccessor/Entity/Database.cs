
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RJ.Tools.NotesTransfer.Engines;
using RJ.Tools.NotesTransfer.Engines.Enums;
using RJ.Tools.NotesTransfer.Engines.Notes.Controls;
using RJ.Tools.NotesTransfer.Engines.Interfaces;

namespace RJ.Tools.NotesTransfer.Engines.Notes.Entity
{
    public class Database : IDatabase
    {
        #region Fields
        private Domino.NotesDatabase _notesDb;
        private NotesAccessor _accessor;
        private string _title;
        private string _server;
        private string _notesUrl;
        private string _replicaId;
        private NotesDbType _sourceType;
        private SPListType _targetType;
        private string _fileName;
        private string _sourcePath;
        private List<IForm> _forms;
        private List<IView> _views;
        
        private IDxlReader _dxlReader;
        private List<IField> _sharedFields;

        #endregion
        #region Property
        /// <summary>
        /// 内部オブジェクト
        /// </summary>
        public object InnerObject
        {
            get
            {
                return this._notesDb; 
            }
        }
        
        /// <summary>
        /// タイトル
        /// </summary>
        public string Title
        {
            get
            {
                return this._title;
            }
        }


        public NotesDbType SourceType
        {
            get
            {
                return this._sourceType;
            }
        }


        public SPListType TargetType
        {
            get
            {
                return this._targetType;
            }
            set
            {
                this._targetType = value;
            }
        }

        public string Server
        {
            get
            {
                return this._server;
            }
        }

        public string FileName
        {
            get
            {
                return this._fileName;
            }
        }


        public string FilePath
        {
            get
            {
                return this._sourcePath;
            }
        }

        public string DxlPath
        {
            get;
            set;
        }

        public string NotesUrl
        {
            get
            {
                return this._notesUrl;
            }
        }

        public string TargetSiteUrl
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public IForm DefaultForm
        {
            get {
               return  this.Forms.Find(new Predicate<IForm>(form => form.IsDefault));
            }
        }

        public IView DefaultNotesView
        {
            get
            {
                return this.Views.Find(new Predicate<IView>(view => view.IsDefault));
            }
        }

        public List<IForm> Forms
        {
            get
            {
                if (this._forms == null)
                {
                   this._forms = this._accessor.GetForms(this);
                }
                return this._forms;
            }

        }

        public List<IView> Views
        {
            get
            {
                if (this._views == null)
                {
                    this._views = this._accessor.GetViews(this);
                }
                return this._views;
            }

        }

        public string ReplicaId
        {
            get 
            {
                return this._replicaId;
            }
        }
        #endregion

        #region Construct
        internal Database(NotesAccessor accessor, Domino.NotesDatabase notesDb)
        {
            if (!notesDb.IsOpen)
            {
                notesDb.Open();
            }
            this._accessor = accessor;
            this._notesDb = notesDb;
            this._title=notesDb.Title;
            this._server = notesDb.Server;
            this._sourceType= (NotesDbType)(int)notesDb.type;
            this._targetType= MappingInfo.GetTagetDbType(this._sourceType);
            this._fileName=notesDb.FileName;
            this._notesUrl = notesDb.NotesURL;
            this._replicaId = notesDb.ReplicaID;
            this._sourcePath = notesDb.FilePath;
        }
        #endregion


        /// <summary>
        /// すべてフィールドリストを取得する
        /// </summary>
        public List<IField> SharedFields
        {
            get
            {
                if (this._sharedFields == null)
                {
                    this._sharedFields = this.DxlReader.GetSharedFields();
                }
                return this._sharedFields;
            }
        }

        /// <summary>
        /// DXLリーダー
        /// </summary>
        public IDxlReader DxlReader
        {
            get {
                if (this._dxlReader == null)
                {
                    string xml = this._accessor.ExportDxl(this, NotesAccessor.ExportMode.Forms);
                    this._dxlReader = new DxlReader(xml);
                }
                return this._dxlReader;
            }
            set
            {
                this._dxlReader = value;
            }
        }

        /// <summary>
        /// フィールドを取得する
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public IFieldRef FindField(string fieldName)
        {
            foreach(IField fld in this.SharedFields)
            {
                if (fld.Name.Equals(fieldName))
                {
                    return fld;
                }
            }
            foreach (IForm form in this.Forms)
            {
                foreach (IField fld in form.Fields)
                {
                    if (fld.Name.Equals(fieldName))
                    {
                        return fld;
                    }
                }
            }
            return null;
        }

    }
}
