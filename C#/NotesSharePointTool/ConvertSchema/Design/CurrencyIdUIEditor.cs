using RJ.Tools.NotesTransfer.Engines.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    public class CurrencyIdUIEditor : UITypeEditor, IDisposable
    {
        // Fields
        private CurrencyIdListBox _dataFieldList;

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
                if (edSvc == null || context == null)
                {
                    return value;
                }
                if ((context.Instance == null) || !(context.Instance is IField))
                {
                    return base.EditValue(context, provider);
                }
                if (this._dataFieldList == null)
                {
                    this._dataFieldList = new CurrencyIdListBox(this);
                }
                this._dataFieldList.Start(edSvc, value);
                edSvc.DropDownControl(this._dataFieldList);
                if (this._dataFieldList.Value != null)
                {
                    value = this._dataFieldList.Value;
                }
                this._dataFieldList.End();
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
            if ((!this.disposedValue && disposing) && (this._dataFieldList != null))
            {
                this._dataFieldList.Dispose();
                this._dataFieldList = null;
            }
            this.disposedValue = true;
        }

        #endregion

        #region Inner Class CurrencyIdListBox
        // Nested Types
        private class CurrencyIdListBox : ListBox
        {
            // Fields
            private CurrencyIdUIEditor _editor;
            private IWindowsFormsEditorService _edSvr;
            private object _value;
            private int[] currencyIds = { 1164,1052,5121,11274,1067,3081,3079,1068,2092,15361,2117,1133,1059,2067,10249,
                                        16394,8218,5146,1046,2110,1026,1107,3084,4105,13322,9226,5130,1050,1029,1030,
                                        7178,12298,3073,17418,1061,1118,1080,1035,1036,1079,1031,1032,1135,4106,18442,
                                        3076,1038,1039,1081,1057,1065,2049,6153,1040,1037,8201,1041,11265,1087,1089,
                                        1042,13313,1088,1108,1062,12289,4097,5127,1063,5132,5124,1071,1086,1125,1082,
                                        2058,6156,1104,6145,1121,1043,5129,19466,1128,1044,8193,1056,6154,15370,2052,
                                        10250,13321,1045,2070,20490,16385,1048,1049,1159,1025,1160,9242,12314,10266,
                                        4100,1051,1060,7177,3082,1115,1053,2055,10241,1028,1064,1054,11273,7169,1055,
                                        1090,1058,14337,2057,1033,14346,1091,2115,8202,1066,9217,12297};

            // Methods
            public CurrencyIdListBox(CurrencyIdUIEditor editor)
            {
                base.SelectedIndexChanged += new EventHandler(this.DataFieldListBox_SelectedIndexChanged);
                this._editor = editor;
                this.IntegralHeight = true;
                this.BorderStyle = BorderStyle.None;
            }


            private void DataFieldListBox_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (this.SelectedItem != null)
                {
                    DataRowView row = this.SelectedItem as DataRowView;
                    this._value = row["ID"];
                    this._edSvr.CloseDropDown();
                }
            }

            public void End()
            {
                this._edSvr = null;
                this._value = null;
            }

            private void InitFieldList()
            {
                if (this.Items.Count==0)
                {
                    this.IntegralHeight = true;
                    this.DisplayMember = "NAME";
                    this.ValueMember = "ID";
                    this.DataSource=null;
                    DataTable source = GetDataSource();
                    foreach (DataRowView row in source.DefaultView)
                    {
                        this.Items.Add(row);
                    }
                    int height = this.GetItemHeight(0);
                    this.Height = height * 20;
                }
                SetSelectItem();
            }

            private void SetSelectItem()
            {
                if (this._value == null || !(this._value is int))
                {
                    return;
                }
                int id=(int)this._value;
                foreach (DataRowView row in this.Items)
                {
                    if ((int)row["ID"] == id)
                    {
                        this.SelectedItem = row;
                        return;
                    }
                }
            }

          
            private DataTable GetDataSource()
            {
                DataTable dttsource = new DataTable();
                dttsource.Columns.Add("ID", typeof(int));
                dttsource.Columns.Add("NAME", typeof(string));
                double sampleVal = 123456.00D;
                foreach (int id in currencyIds)
                {
                    DataRow row = dttsource.NewRow();
                    CultureInfo culture = CultureInfo.GetCultureInfo(id);
                    RegionInfo region = new RegionInfo(id);
                    string name = sampleVal.ToString("C", culture.NumberFormat) + " (" + region.DisplayName + ")";
                    row["ID"] = id;
                    row["NAME"] = name;
                    dttsource.Rows.Add(row);
                }
                dttsource.AcceptChanges();
                return dttsource;
            }

            public void Start(IWindowsFormsEditorService edSvc, object value)
            {
                this._edSvr = edSvc;
                this._value = value;
                this.InitFieldList();
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
