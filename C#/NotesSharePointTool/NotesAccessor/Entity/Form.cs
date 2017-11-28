using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RJ.Tools.NotesTransfer.Engines.Enums;
using RJ.Tools.NotesTransfer.Engines.Interfaces;
using RJ.Tools.NotesTransfer.Engines.Notes.Controls;
using RJ.Tools.NotesTransfer.Engines.Common;
namespace RJ.Tools.NotesTransfer.Engines.Notes.Entity
{
    public class Form : IForm
    {
        #region Field
        private Domino.NotesForm _form;
        private string _name;
        private List<string> _aliases;
        private List<IField> _fields;
        private bool _isDefault;
        private string _notesUrl;
        private string _formDxl;
        private string _taskId=string.Empty;
        private int _formNo;
        #endregion

        #region Property

        public int FormNo
        {
            get
            {
                return this._formNo;
            }
        }

        public string TaskId
        {
            get
            {
                return this._taskId;
            }
        }

        public string Name
        {
            get
            {
                return this._name;
            }
        }

        public string DisplayName { get; set; }

        public bool IsDefault
        {
            get
            {
                return this._isDefault;
            }
            internal set
            {
                this._isDefault = value;
                this.IsDefaultDispForm = this._isDefault;
                this.IsDefaultEditForm = this._isDefault;
                this.IsDefaultNewForm = this._isDefault;
            }
        }

        public List<string> Aliases
        {
            get
            {
                if (this._aliases == null)
                {
                    this._aliases = GetAliases(this._form);
                }
                return this._aliases;
            }
        }

        public List<IField> Fields
        {
            get
            {
               return this._fields;
            }
        }

        public bool IsDefaultNewForm { get; set; }

        public bool IsDefaultEditForm { get; set; }

        public bool IsDefaultDispForm { get; set; }

        public bool HasNewForm { get; set; }

        public bool HasEditForm { get; set; }

        public bool HasDispForm { get; set; }

        public string NewFormName { get; set; }

        public string EditFormName { get; set; }

        public string DispFormName { get; set; }

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

        public string FormDxl
        {
            get {
                return this._formDxl; 
            }
            set
            {
                this._formDxl = value;
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// NotesFormからインスタンスを生成する
        /// </summary>
        /// <param name="form"></param>
        internal Form(int formNo, Domino.NotesForm form, IDatabase db)
        {
            this._form = form;
            this._formNo = formNo;
            this._name = form.Name;
            this.DisplayName = form.Name;
            this._notesUrl = form.NotesURL;
            this._aliases = GetAliases(form);
            this._formDxl = string.Empty;
            this._formDxl = db.DxlReader.GetFormDxl(this._name);
            this.HasDispForm = true;
            this.HasEditForm = true;
            this.HasNewForm = true;
            this.DispFormName = "DispForm_" + formNo + ".aspx";
            this.NewFormName = "NewForm_" + formNo + ".aspx";
            this.EditFormName = "EditForm_" + formNo + ".aspx";
            this._fields = GetFields(db);
        }


        private List<string> GetAliases(Domino.NotesForm form)
        {
            List<string> aliases = new List<string>();
            string[] names = ((object[])form.Aliases).Cast<string>().ToArray();
            aliases.AddRange(names);
            return aliases;
        }

        /// <summary>
        /// 共通フィールド含むフィールドリストを取得する
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        private List<IField> GetFields( IDatabase db)
        {
            List<IField> fldList = db.DxlReader.GetFields(this.Name);
            List<string> sharedFieldrefs = db.DxlReader.GetSharedFieldRef(this.Name);
            foreach (string fieldName in sharedFieldrefs)
            {
                IField sharedFld = (IField)db.FindField(fieldName);
                fldList.Add(sharedFld);
            }
            fldList.Sort((x, y) => {
                if (x.IsSharedField == y.IsSharedField)
                {
                    return x.Name.CompareTo(y.Name);
                }
                else if(x.IsSharedField){
                    return -1;
                }else{
                    return 1;
                }
            });
            return fldList;
        }

        public string SerializFields()
        {
            if (this._fields == null)
            {
                return null;
            }
            return Utility.ObjectToString(this._fields);
        }

        public List<IField> DeSerializFields(string serializeStr)
        {
            if (string.IsNullOrEmpty(serializeStr))
            {
                return null;
            }
            List<IField> fields = Utility.StringToObject(serializeStr) as List<IField>;
            return fields;
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

        #endregion


        public bool IsTarget
        {
            get;
            set;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is IForm))
            {
                return false;
            }
            IForm objForm =(IForm)obj;
            if (this._name == null || this._notesUrl == null)
            {
                return false;
            }
            return this._name.Equals(objForm.Name) && this._notesUrl.Equals(objForm.NotesUrl);
        }

        public override int GetHashCode()
        {
            if (this._name == null || this._notesUrl == null)
            {
                return base.GetHashCode();
            }
            return Utility.CombineHashCode( this._name.GetHashCode(), 
                                            this._notesUrl.GetHashCode());
        }

        public string NotesUrl
        {
            get {
                return this._notesUrl;
            }
        }




        public string FormLayout
        {
            get;
            set;
        }
    }
}
