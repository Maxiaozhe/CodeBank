using RJ.Tools.NotesTransfer.Engines.Enums;
using RJ.Tools.NotesTransfer.Engines.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RS = RJ.Tools.NotesTransfer.Engines.Resources;
using RSM = RJ.Tools.NotesTransfer.Engines.Resource.ResourceManager;


namespace RJ.Tools.NotesTransfer.Engines.Design
{
    #region FieldDescriptionProvider
    /// <summary>
    /// IField のTypeDescriptionProviderを実装する
    /// </summary>
    public class FieldDescriptionProvider : TypeDescriptionProvider
    {
        private TypeDescriptionProvider _parent;

        public FieldDescriptionProvider()
            : base()
        {

        }
        public FieldDescriptionProvider(TypeDescriptionProvider parent)
            : base(parent)
        {
            this._parent = parent;
        }

        public override ICustomTypeDescriptor GetTypeDescriptor(Type objectType, object instance)
        {
            if (instance == null || !(instance is IField))
            {
                return base.GetTypeDescriptor(objectType, instance);
            }
            return new FieldDescriptor(base.GetTypeDescriptor(objectType, instance), (IField)instance);
        }
    }
    #endregion

    #region FieldDescriptor
    /// <summary>
    /// IFieldのCustomTypeDescriptorを実装する
    /// </summary>
    public class FieldDescriptor : CustomTypeDescriptor
    {
        private IField _instance;
        public IField Instance
        {
            get
            {
                return this._instance;
            }
        }

        public FieldDescriptor(ICustomTypeDescriptor parent, IField instance)
            : base(parent)
        {
            this._instance = instance;
        }

        public override PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            PropertyDescriptorCollection props = base.GetProperties(attributes);
            List<PropertyDescriptor> myprops = new List<PropertyDescriptor>();
            List<string> displayPropNames = GetPropertyNames(this._instance.TargetType);
            foreach (PropertyDescriptor prop in props)
            {
                if (displayPropNames.Contains(prop.Name))
                {
                    myprops.Add(prop);
                }
            }
           PropertyDescriptorCollection propCol =  new PropertyDescriptorCollection(myprops.ToArray());
           return  propCol.Sort(displayPropNames.ToArray());
        }
        /// <summary>
        /// フィールド種別による表示する属性名を取得する
        /// </summary>
        /// <param name="fieldType"></param>
        /// <returns></returns>
        private List<string> GetPropertyNames(SPFieldType fieldType)
        {
            List<string> propNames = new List<string>();
            propNames.Add("Name");
            propNames.Add("Title");
            propNames.Add("Description");
            propNames.Add("DefaultValue");
            propNames.Add("DefaultValueFormula");
            propNames.Add("InputValidationFormula");
            propNames.Add("SourceType");
            propNames.Add("TargetType");
            propNames.Add("Hidden");
            propNames.Add("Required");
            propNames.Add("ReadOnlyField");
            propNames.Add("Computed");
            propNames.Add("ValidationFormula");
            propNames.Add("ValidationMessage");
            switch (fieldType)
            {
                case SPFieldType.Number:
                    propNames.Add("MinimumValue");
                    propNames.Add("MaximumValue");
                    propNames.Add("Percentage");
                    propNames.Add("Decimals");
                    break;
                case SPFieldType.Currency:
                    propNames.Add("MinimumValue");
                    propNames.Add("MaximumValue");
                    propNames.Add("Decimals");
                    propNames.Add("CurrencyLocaleId");
                    break;
                case SPFieldType.Text:
                    propNames.Add("MaxLength");
                    break;
                case SPFieldType.Note:
                    propNames.Add("NumberOfLines");
                    propNames.Add("RichText");
                    break;
                case SPFieldType.DateTime:
                    propNames.Add("DisplayFormat");
                    break;
                case SPFieldType.Choice:
                case SPFieldType.MultiChoice:
                    propNames.Add("keywordUIType");
                    propNames.Add("Choices");
                    propNames.Add("FillInChoice");
                    propNames.Add("EditFormat");
                    break;
                case SPFieldType.User:
                    propNames.Add("AllowMultipleValues");
                    propNames.Add("SelectionMode");
                    break;
                default:
                    break;
            }
            return propNames;
        }

    }
    #endregion

    #region FieldPropertyDescripter
    public class FieldPropertyDescripter : PropertyDescriptor
    {
        // Fields
        private IField _instance;
        private PropertyDescriptor _parent;

        // Methods
        public FieldPropertyDescripter(PropertyDescriptor parent, IField instance)
            : base(parent)
        {
            this._instance = instance;
            this._parent = parent;
        }

        public override bool CanResetValue(object component)
        {
            return this._parent.CanResetValue(component);
        }

        public override object GetEditor(Type editorBaseType)
        {
            return base.GetEditor(editorBaseType);
        }

        public override object GetValue(object component)
        {
            return this._parent.GetValue(component);
        }

        public override void ResetValue(object component)
        {
            this._parent.ResetValue(component);
        }

        public override void SetValue(object component, object value)
        {
            try
            {
                this._parent.SetValue(component, value);
            }
            catch
            {
            }
        }

        public override bool ShouldSerializeValue(object component)
        {
            return this._parent.ShouldSerializeValue(component);
        }

        // Properties
        public override Type ComponentType
        {
            get
            {
                return this._parent.ComponentType;
            }
        }

        public IField Instance
        {
            get
            {
                return this._instance;
            }
        }

        public override bool IsReadOnly
        {
            get
            {
                return this._parent.IsReadOnly;
            }
        }

        public PropertyDescriptor Parent
        {
            get
            {
                return this._parent;
            }
        }

        public override Type PropertyType
        {
            get
            {
                return this._parent.PropertyType;
            }
        }

    }


    #endregion

    #region FieldCategoryAttribute
    public class FieldCategoryAttribute : CategoryAttribute
    {
        // Fields
        private RS.FieldNames _Key;

        // Methods
        public FieldCategoryAttribute(RS.FieldNames keyType)
            : base(keyType.ToString())
        {
            this._Key = keyType;
        }

        protected override string GetLocalizedString(string value)
        {
            return RSM.GetMessage(this._Key);
        }
    }
    #endregion

    #region FieldPropertyAttribute
    public class PropNameAttribute : DisplayNameAttribute
    {
        // Fields
        private RS.FieldNames _Key;

        // Methods
        public PropNameAttribute(RS.FieldNames key)
        {
            this._Key = key;
            base.DisplayNameValue = this.GetLocalizedString();
        }

        private string GetLocalizedString()
        {
            return RSM.GetMessage(this._Key);
        }
    }
    #endregion

    #region FieldPropertyAttribute
    public class PropDescAttribute : DescriptionAttribute
    {
        // Fields
        private RS.FieldNames _Key;

        // Methods
        public PropDescAttribute(RS.FieldNames key)
        {
            this._Key = key;
            base.DescriptionValue = GetLocalizedString();
        }

        private string GetLocalizedString()
        {
            return RSM.GetMessage(this._Key);
        }
    }
    #endregion

}
