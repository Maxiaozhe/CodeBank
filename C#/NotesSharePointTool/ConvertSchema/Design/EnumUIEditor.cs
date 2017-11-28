using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace RJ.Tools.NotesTransfer.Engines.Design
{
    public class EnumUIEditor : UITypeEditor,IDisposable
    {

        // Fields
        private EnumListBox _EnumList;

        // Properties
        public override bool IsDropDownResizable
        {
            get
            {
                return false;
            }
        }
  
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (provider != null)
            {
                IWindowsFormsEditorService edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
                if (((edSvc == null) || (context.PropertyDescriptor == null)) || (context.PropertyDescriptor.PropertyType == null))
                {
                    return value;
                }
                if (this._EnumList == null)
                {
                    this._EnumList = new EnumListBox(this);
                }
                this._EnumList.Start(edSvc, context.PropertyDescriptor.PropertyType, value);
                edSvc.DropDownControl(this._EnumList);
                if (this._EnumList.Value != null)
                {
                    value = this._EnumList.Value;
                }
                this._EnumList.End();
            }
            return value;
        }

        public override bool GetPaintValueSupported(ITypeDescriptorContext context)
        {
            return false;
        }

        #region IDisposable
        private bool disposedValue = false;

        // Methods
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing && this._EnumList != null)
                {
                    this._EnumList.Dispose();
                    this._EnumList = null;
                }
            }
            this.disposedValue = true;
        }
        #endregion
   
        #region Inner Class EnumListBox
        // Nested Types
        private class EnumListBox : ListBox
        {
            // Fields
            private EnumUIEditor _editor;
            private IWindowsFormsEditorService _edSvr;
            private object _value;

            // Properties
            public object Value
            {
                get
                {
                    return this._value;
                }
                set
                {
                    this._value = value;
                }
            }

            // Methods
            public EnumListBox(EnumUIEditor editor)
            {
                this._editor = editor;
                base.SelectedIndexChanged += new EventHandler(this.EnumListBox_SelectedIndexChanged);
                this.IntegralHeight = true;
                this.BorderStyle = BorderStyle.None;
            }

            public void Start(IWindowsFormsEditorService edSvc, Type valueType, object value)
            {
                this._edSvr = edSvc;
                this._value = value;
                this.InitEnumList(valueType);
            }

            public void End()
            {
                this._edSvr = null;
                this._value = null;
            }

            private void InitEnumList(Type valueType)
            {
                this.Items.Clear();
                this.DisplayMember = "DisplayName";
                this.ValueMember = "EnumValue";
                var mems = valueType.GetMembers(BindingFlags.Public | BindingFlags.Static);
                foreach (MemberInfo info in mems)
                {
                    object[] customAttributes = info.GetCustomAttributes(typeof(EnumNameAttribute), true);
                    if (customAttributes.Count() > 0)
                    {
                        EnumNameAttribute item = (EnumNameAttribute)customAttributes[0];
                        this.Items.Add(item);
                        if (item.EnumValue.Equals(this._value))
                        {
                            this.SelectedItem = item;
                        }
                    }
                }
            }

            private void EnumListBox_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (this.SelectedItem != null)
                {
                    EnumNameAttribute selectedItem = (EnumNameAttribute)this.SelectedItem;
                    this._value = selectedItem.EnumValue;
                    this._edSvr.CloseDropDown();
                }
            }
        }
        #endregion
 
    }

    public class EnumNameAttribute : Attribute
    {
        private string _displayName;
        private object _enumValue;
        public string DisplayName
        {
            get
            {
                return this._displayName;
            }
        }
        public object EnumValue
        {
            get
            {
                return this._enumValue;
            }
        }
        public EnumNameAttribute(string name,object value)
        {
            this._displayName = name;
            this._enumValue = value;
        }
    }

    public class EnumNameConverter : EnumConverter
    {
        // Methods
        public EnumNameConverter(Type type)
            : base(type)
        {
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return false;
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string) && value is Enum)
            {
                MemberInfo[] mems = value.GetType().GetMember(value.ToString());
                if (mems != null && mems.Length > 0)
                {
                    object[] customAttributes = mems[0].GetCustomAttributes(typeof(EnumNameAttribute), true);
                    if (customAttributes.Count() > 0)
                    {
                        EnumNameAttribute attribute = (EnumNameAttribute)customAttributes[0];
                        return attribute.DisplayName;
                    }
                }
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }



}
