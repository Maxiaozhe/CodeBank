
using System;
using System.Collections.Generic;
using System.Xml;
using RJ.Tools.NotesTransfer.Engines.Enums;
using RJ.Tools.NotesTransfer.Engines.Interfaces;
using RS = RJ.Tools.NotesTransfer.Engines.Resources;
using RSM = RJ.Tools.NotesTransfer.Engines.Resource.ResourceManager;
using RJ.Tools.NotesTransfer.Engines.Design;
using System.ComponentModel;
using System.Drawing.Design;
namespace RJ.Tools.NotesTransfer.Engines.Notes.Entity
{
    [Serializable]
    public class Field : IField
    {
        #region Field
        private bool _isReadonly = false;
        private const int DEFAULT_LENGTH = 255;
        private const int DEFAULT_LINES = 6;
        private string _defaultValueFormula = "";
        private string _inputValidationFormula = "";
        private KeywordUIType _keywordUIType;
        private string _keywordsFormula;
        private NotesFieldType _sourceType;
        private bool _computed;
        private bool _isSharedField;
        private string _name;
        private bool _required;
        #endregion

        #region Property
        #region Common

        [FieldCategory(RS.FieldNames.CommonCategory), PropName(RS.FieldNames.Name)]
        public string Name
        {
            get
            {
                return this._name;
            }
        }

        [FieldCategory(RS.FieldNames.CommonCategory), PropName(RS.FieldNames.Title)]
        public string Title { get; set; }

        [FieldCategory(RS.FieldNames.CommonCategory), PropName(RS.FieldNames.Description)]
        public string Description { get; set; }

        [FieldCategory(RS.FieldNames.ReferCategory), PropName(RS.FieldNames.SourceType)]
        public NotesFieldType SourceType
        {
            get
            {
                return this._sourceType;
            }
        }

        [FieldCategory(RS.FieldNames.CommonCategory), PropName(RS.FieldNames.TargetType)]
        public SPFieldType TargetType { get; set; }

        [Browsable(false)]
        public string Id { get; set; }

        [FieldCategory(RS.FieldNames.CommonCategory), PropName(RS.FieldNames.DefaultValue)]
        public string DefaultValue { get; set; }
        [Browsable(false)]
        public bool ShowInDisplayForm { get; set; }
        [Browsable(false)]
        public bool ShowInEditForm { get; set; }
        [Browsable(false)]
        public bool ShowInNewForm { get; set; }
        [FieldCategory(RS.FieldNames.CommonCategory), PropName(RS.FieldNames.Hidden)]
        public bool Hidden { get; set; }
        [FieldCategory(RS.FieldNames.CommonCategory), PropName(RS.FieldNames.Required)]
        public bool Required {

            get
            {
                return this._required;
            }
            set
            {
                if (value && this.ReadOnlyField)
                {
                    throw RSM.GetException(RS.Exceptions.ReadOnlyFieldCantRequired);
                }
                this._required = value;
            }
        }
        [FieldCategory(RS.FieldNames.ReferCategory), PropName(RS.FieldNames.Computed)]
        public bool Computed
        {
            get
            {
                return this._computed;
            }
        }
        [FieldCategory(RS.FieldNames.ReferCategory), PropName(RS.FieldNames.DefaultValueFormula)]
        public string DefaultValueFormula
        {
            get
            {
                return this._defaultValueFormula;
            }
        }
        [FieldCategory(RS.FieldNames.ReferCategory), PropName(RS.FieldNames.InputValidationFormula)]
        public string InputValidationFormula
        {
            get
            {
                return this._inputValidationFormula;
            }
        }
        /// <summary>
        /// 選択肢の式
        /// </summary>
        public string keywordsFormula
        {
            get
            {
                return this._keywordsFormula;
            }
        }

        /// <summary>
        /// 読み取り専用かどうかを取得する
        /// </summary>
        [FieldCategory(RS.FieldNames.CommonCategory), PropName(RS.FieldNames.ReadOnlyField)]
        public bool ReadOnlyField
        {
            get
            {
                return this._isReadonly;
            }
            set
            {
                this._isReadonly = value;
            }
        }
        public string RealName
        {
            get;
            set;
        }

        public bool IsSharedField
        {
            get
            {
                return this._isSharedField;
            }
        }
        #endregion

        #region Validation
        /// <summary>
        /// 検証数式
        /// </summary>
        [FieldCategory(RS.FieldNames.ValidationCaterory), 
         PropName(RS.FieldNames.ValidationFormula),
         PropDesc(RS.FieldNames.ValidationFormulaDesc)]
        public string ValidationFormula
        {
            get;
            set;
        }
        /// <summary>
        /// 検証メッセージ
        /// </summary>
        [FieldCategory(RS.FieldNames.ValidationCaterory), 
         PropName(RS.FieldNames.ValidationMessage),
         PropDesc(RS.FieldNames.ValidationMessageDesc)]
        public string ValidationMessage
        {
            get;
            set;
        }
        #endregion

        #region Text
        [FieldCategory(RS.FieldNames.OtherCategory), PropName(RS.FieldNames.MaxLength)]
        public int MaxLength { get; set; }
        #endregion

        #region MultiLineText
        [FieldCategory(RS.FieldNames.OtherCategory), PropName(RS.FieldNames.NumberOfLines)]
        public int NumberOfLines { get; set; }

        [FieldCategory(RS.FieldNames.OtherCategory), PropName(RS.FieldNames.RichText)]
        public bool RichText { get; set; }

        #endregion

        #region Number
        [FieldCategory(RS.FieldNames.OtherCategory), PropName(RS.FieldNames.MaximumValue)]
        public double? MaximumValue { get; set; }
        [FieldCategory(RS.FieldNames.OtherCategory), PropName(RS.FieldNames.MinimumValue)]
        public double? MinimumValue { get; set; }
        [FieldCategory(RS.FieldNames.OtherCategory), PropName(RS.FieldNames.Percentage)]
        public bool Percentage { get; set; }
        [FieldCategory(RS.FieldNames.OtherCategory), PropName(RS.FieldNames.Decimals)]
        public int Decimals { get; set; }

        public string NumberFormat { get; set; }
        #endregion

        #region DateTime
        [FieldCategory(RS.FieldNames.OtherCategory), PropName(RS.FieldNames.DisplayFormat)]
        public DateTimeFormatType DisplayFormat { get; set; }

        #endregion

        #region Currency
        [FieldCategory(RS.FieldNames.OtherCategory),
         PropName(RS.FieldNames.CurrencyLocaleId),
         Editor(typeof(CurrencyIdUIEditor), typeof(UITypeEditor))]
        public int CurrencyLocaleId { get; set; }

        #endregion

        #region Choice
        [FieldCategory(RS.FieldNames.OtherCategory), PropName(RS.FieldNames.EditFormat)]
        public ChoiceUIType EditFormat { get; set; }
        [FieldCategory(RS.FieldNames.OtherCategory), PropName(RS.FieldNames.Choices)]
        public string[] Choices { get; set; }
        [FieldCategory(RS.FieldNames.OtherCategory), PropName(RS.FieldNames.FillInChoice)]
        public bool FillInChoice { get; set; }
        [FieldCategory(RS.FieldNames.ReferCategory), PropName(RS.FieldNames.keywordUIType)]
        public KeywordUIType keywordUIType
        {
            get
            {
                return this._keywordUIType;
            }
        }


        #endregion

        #region User
        [Browsable(false)]
        public bool AllowDisplay { get; set; }

        [FieldCategory(RS.FieldNames.OtherCategory), PropName(RS.FieldNames.SelectionMode)]
        public UserSelectionMode SelectionMode { get; set; }

        [FieldCategory(RS.FieldNames.OtherCategory), PropName(RS.FieldNames.AllowMultipleValues)]
        public bool AllowMultipleValues { get; set; }

        #endregion
        #endregion

        #region Constructor

        internal Field()
        {

        }

        internal Field(XmlNode node, XmlNamespaceManager xm)
        {
            InitField(node, xm, false); 
        }

        internal Field(XmlNode node, XmlNamespaceManager xm,bool isSharedField)
        {
            InitField(node, xm, isSharedField);
        }

        private void InitField(XmlNode node, XmlNamespaceManager xm, bool isSharedField)
        {
            this._name = GetAttribute(node, "name");
            this.Title = GetAttribute(node, "name");
            this.Description = GetAttribute(node, "description");
            string type = GetAttribute(node, "type");
            this._sourceType = this.GetSourceType(type);
            string kind = GetAttribute(node, "kind");
            this.ShowInDisplayForm = true;
            this.ShowInEditForm = true;
            this.ShowInNewForm = true;
            this.Required = false;
            this.Hidden = false;
            this._isSharedField = isSharedField;
            switch (kind)
            {
                case "computed":
                case "computedfordisplay":
                case "computedwhencomposed":
                    this._computed = true;
                    this._isReadonly = true;
                    break;
                default:
                    this._isReadonly = false;
                    break;
            }
            this.TargetType = MappingInfo.GetTargetFieldType(this.SourceType);
            //Codeを取得
            if (node.NodeType == XmlNodeType.Element)
            {
                this.GetCodes((XmlElement)node, xm);
            }
            //フィールド別の個別属性を取得する
            this.GetFieldInfo(node, xm);
        }

        #endregion

        #region Method

        private void GetFieldInfo(XmlNode node, XmlNamespaceManager xm)
        {
            switch (this.SourceType)
            {
                case NotesFieldType.Unknow:
                    this.TargetType = SPFieldType.Invalid;

                    break;
                case NotesFieldType.Text:
                    this.MaxLength = DEFAULT_LENGTH;
                    break;
                case NotesFieldType.Number:
                    XmlNode formatNode = node.SelectSingleNode("./x:numberformat", xm);
                    GetNumberFormat(formatNode);
                    break;
                case NotesFieldType.Datetime:
                    XmlNode dateFormatNode = node.SelectSingleNode("./x:datetimeformat", xm);
                    GetDateTimeFormat(dateFormatNode);
                    break;
                case NotesFieldType.Richtext:
                    this.NumberOfLines = DEFAULT_LINES;
                    break;
                case NotesFieldType.KeyWord:
                    XmlNode keywordNode = node.SelectSingleNode("./x:keywords", xm);
                    GetKeywordInfo(keywordNode, xm);

                    break;
                case NotesFieldType.Names:
                    this.SelectionMode = UserSelectionMode.PeopleOnly;
                    bool allowmultivalues = this.GetBoolean(node, "allowmultivalues");
                    this.AllowMultipleValues = allowmultivalues;
                    break;
                case NotesFieldType.Authors:
                    break;
                case NotesFieldType.Readers:
                    break;
                case NotesFieldType.Password:
                    this.MaxLength = DEFAULT_LENGTH;
                    break;
                case NotesFieldType.Formula:
                    this._isReadonly = true;
                    break;
                case NotesFieldType.Timezone:
                    break;
                case NotesFieldType.Richtextlite:
                    break;
                case NotesFieldType.Color:
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// キーワードの属性を取得する
        /// </summary>
        /// <param name="keywordNode"></param>
        /// <param name="xm"></param>
        private void GetKeywordInfo(XmlNode keywordNode, XmlNamespaceManager xm)
        {

            string ui = GetAttribute(keywordNode, "ui");
            switch (ui)
            {
                case "dialoglist":
                    this._keywordUIType = KeywordUIType.dialoglist;
                    this.EditFormat = ChoiceUIType.Dropdown;
                    break;
                case "checkbox":
                    this._keywordUIType = KeywordUIType.checkbox;
                    this.EditFormat = ChoiceUIType.CheckBox;
                    this.TargetType = SPFieldType.MultiChoice;
                    break;
                case "radiobutton":
                    this._keywordUIType = KeywordUIType.radiobutton;
                    this.EditFormat = ChoiceUIType.RadioButtons;
                    break;
                case "combobox":
                    this._keywordUIType = KeywordUIType.combobox;
                    this.EditFormat = ChoiceUIType.Dropdown;
                    break;
                case "listbox":
                    this._keywordUIType = KeywordUIType.listbox;
                    this.EditFormat = ChoiceUIType.Dropdown;
                    break;
                default:
                    break;
            }
            //複数選択を許可するか
            bool allowMultiValues = GetBoolean(keywordNode, "allowmultivalues");
            if (allowMultiValues)
            {
                this.TargetType = SPFieldType.MultiChoice;
            }
            //選択肢に値追加を許可するか
            bool allownew = GetBoolean(keywordNode, "allownew");
            this.FillInChoice = allownew;

            //選択肢
            List<string> choiseList = new List<string>();
            XmlNodeList textList = keywordNode.SelectNodes("./x:textlist/x:text", xm);
            foreach (XmlNode textNode in textList)
            {
                string value = textNode.InnerText;
                choiseList.Add(value);
            }
            this.Choices = choiseList.ToArray();
            //選択肢の式
            XmlNode formula = keywordNode.SelectSingleNode("./x:formula", xm);
            if (formula != null)
            {
                this._keywordsFormula = formula.InnerText;
            }


        }

        /// <summary>
        /// 日付フォーマットを取得する
        /// </summary>
        /// <param name="dateFormatNode"></param>
        private void GetDateTimeFormat(XmlNode dateFormatNode)
        {
            string show = this.GetAttribute(dateFormatNode, "show");
            switch (show)
            {
                case "datetime":
                case "time":
                    this.DisplayFormat = DateTimeFormatType.DateTime;
                    break;
                default:
                    this.DisplayFormat = DateTimeFormatType.DateOnly;
                    break;
            }
        }
        /// <summary>
        /// 数値フォーマット情報を取得する
        /// </summary>
        /// <param name="fmtNode"></param>
        private void GetNumberFormat(XmlNode fmtNode)
        {
            string format = GetAttribute(fmtNode, "format");
            if ("currency".Equals(format))
            {
                this.TargetType = SPFieldType.Currency;
            }
            string numformat = "";
            //3 桁ごとの区切り記号を使用する
            bool punctuated = GetBoolean(fmtNode, "punctuated");
            //負の数値をカッコで囲んで表示する
            bool parens = GetBoolean(fmtNode, "parens");
            //値をパーセンテージとして表示する
            bool percent = GetBoolean(fmtNode, "percent");
            int? digit = GetInteger(fmtNode, "digit");
            this.Percentage = percent;
            if (punctuated)
            {
                numformat = "###,#";
            }
            if (digit.HasValue && digit.Value > 0)
            {
                this.Decimals = digit.Value;
                string strDigit = new string('#', digit.Value);
                numformat += "." + strDigit;
            }
            if (percent)
            {
                numformat += "%";
            }
            if (parens)
            {
                numformat = numformat + ";(" + numformat + ");" + numformat;
            }
            this.NumberFormat = numformat;

        }

        /// <summary>
        /// フィールドのノーツ種別を取得
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private NotesFieldType GetSourceType(string type)
        {
            switch (type.ToLower())
            {
                case "text":
                    return NotesFieldType.Text;
                case "number":
                    return NotesFieldType.Number;
                case "datetime":
                    return NotesFieldType.Datetime;
                case "richtext":
                    return NotesFieldType.Richtext;
                case "keyword":
                    return NotesFieldType.KeyWord;
                case "names":
                    return NotesFieldType.Names;
                case "authors":
                    return NotesFieldType.Readers;
                case "readers":
                    return NotesFieldType.Readers;
                case "password":
                    return NotesFieldType.Password;
                case "formula":
                    return NotesFieldType.Formula;
                case "timezone":
                    return NotesFieldType.Timezone;
                case "richtextlite":
                    return NotesFieldType.Richtextlite;
                case "color":
                    return NotesFieldType.Color;
                default:
                    return NotesFieldType.Unknow;
            }
        }

        /// <summary>
        /// 属性の値を取得する
        /// </summary>
        /// <param name="node"></param>
        /// <param name="attrName"></param>
        /// <returns></returns>
        private string GetAttribute(XmlNode node, string attrName)
        {
            var attr = node.Attributes[attrName];
            if (attr == null)
            {
                return string.Empty;
            }
            return attr.Value;
        }
        /// <summary>
        /// 整数の値を取得する
        /// </summary>
        /// <param name="node"></param>
        /// <param name="attrName"></param>
        /// <returns></returns>
        private int? GetInteger(XmlNode node, string attrName)
        {
            string attr = GetAttribute(node, attrName);
            int value = 0;
            if (int.TryParse(attr, out value))
            {
                return value;
            }
            return null;
        }
        /// <summary>
        /// ブールの値を取得
        /// </summary>
        /// <param name="node"></param>
        /// <param name="attrName"></param>
        /// <returns></returns>
        private bool GetBoolean(XmlNode node, string attrName)
        {
            string attr = GetAttribute(node, attrName);
            bool value = false;
            if (bool.TryParse(attr, out value))
            {
                return value;
            }
            return false;
        }


        /// <summary>
        /// コード式を取得
        /// </summary>
        /// <param name="node"></param>
        /// <param name="xm"></param>
        private void GetCodes(XmlElement elem, XmlNamespaceManager xm)
        {
            try
            {
                XmlNodeList codeNodes = elem.GetElementsByTagName("code");
                foreach (XmlNode codeNode in codeNodes)
                {
                    string eventName = this.GetAttribute(codeNode, "event");
                    XmlNode formulaNode = codeNode.SelectSingleNode("./x:formula", xm);
                    if (formulaNode == null)
                    {
                        continue;
                    }
                    string formula = formulaNode.InnerText;
                    if (!string.IsNullOrEmpty(eventName)
                        && !string.IsNullOrEmpty(formula))
                    {
                        //default値を取得する
                        switch (eventName)
                        {
                            case "defaultvalue":
                                this._defaultValueFormula = formula;
                                break;
                            case "inputvalidation":
                                this._inputValidationFormula = formula;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// IViewColumnへ変換する
        /// </summary>
        /// <returns></returns>
        public IViewColumn ToViewColumn()
        {
            return new ViewColumn(this);
        }


        #endregion


     
    }
}
