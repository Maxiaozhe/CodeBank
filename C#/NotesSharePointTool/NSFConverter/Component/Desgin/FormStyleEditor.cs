using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace RJ.Tools.NotesTransfer.UI.Component.Desgin
{
    public class FormStyleEditor: UITypeEditor, IDisposable
    {
        // Fields
        private StyleListBox _styleNameList;

        // Properties
        public override bool IsDropDownResizable
        {
            get
            {
                return false;
            }
        }

      
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (provider != null)
            {
                IWindowsFormsEditorService edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
                if (edSvc == null || context == null || (context.Instance == null))
                {
                    return value;
                }
                if (this._styleNameList == null)
                {
                    this._styleNameList = new StyleListBox(this);
                }
                this._styleNameList.Start(edSvc, value);
                edSvc.DropDownControl(this._styleNameList);
                if (this._styleNameList.Value != null)
                {
                    value = this._styleNameList.Value;
                }
                this._styleNameList.End();
              
            }
            return value;
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        #region IDisposable

        private bool disposedValue;

        // Methods
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if ((!this.disposedValue && disposing) && (this._styleNameList != null))
            {
                this._styleNameList.Dispose();
                this._styleNameList = null;
            }
            this.disposedValue = true;
        }

        #endregion

        #region Inner Class StyleListBox
        // Nested Types
        private class StyleListBox : ListBox
        {
            // Fields
            private FormStyleEditor _editor;
            private IWindowsFormsEditorService _edSvr;
            private object _value;
          

            // Methods
            public StyleListBox(FormStyleEditor editor)
            {
                base.SelectedIndexChanged += new EventHandler(this.DataFieldListBox_SelectedIndexChanged);
                this._editor = editor;
                this.IntegralHeight = true;
                this.BorderStyle = BorderStyle.None;
            }

            private void DataFieldListBox_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (this.SelectedIndex != -1)
                {
                    this._value = this.SelectedItem;
                    this._edSvr.CloseDropDown();
                }
            }

            public void End()
            {
                this._edSvr = null;
                this._value = null;
            }

            private void InitStyleNameList()
            {
                if (this.Items.Count == 0)
                {
                    this.IntegralHeight = true;
                    this.DataSource = null;
                    string[] styles = ControlStyleHelper.GetStyleNames();
                    foreach (string style in styles)
                    {
                        this.Items.Add(style);
                    }
                    int height = this.GetItemHeight(0);
                    this.Height = height * 20;
                }
                if (this.Value != null && Value is string)
                {
                    this.SelectedIndex = this.FindString(this.Value.ToString());
                }
            }

            public void Start(IWindowsFormsEditorService edSvc, object value)
            {
                this._edSvr = edSvc;
                this._value = value;
                this.InitStyleNameList();
            }

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
        }
        #endregion


    }
}
