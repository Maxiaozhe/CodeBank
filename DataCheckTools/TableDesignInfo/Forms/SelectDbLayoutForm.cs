using Excel = Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TableDesignInfo.Controls;
using TableDesignInfo.Entity;

namespace TableDesignInfo.Forms
{
    public partial class SelectDbLayoutForm : Form
    {
        private TableCreateInfo _settingInfo;

        public SelectDbLayoutForm()
        {
            InitializeComponent();
        }


        public TableCreateInfo SettingInfo
        {
            get
            {
                return this._settingInfo;
            }
        }
   

        private void SheetSelectForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.InitControls();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       
        /// <summary>
        /// 画面初期化する
        /// </summary>
        private void InitControls()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                //設計書種別
                TemplateInfo.DocumentTemplateDataTable Templates = TemplateInfo.LoadTemplate();
                this.cmbLayoutType.Items.Clear();
                this.cmbLayoutType.DisplayMember = "TemplateFileName";
                this.cmbLayoutType.DataSource = Templates;
                if (this.cmbLayoutType.Items.Count > 0)
                {
                    this.cmbLayoutType.SelectedIndex = 0;
                }
                //オプションズ
                List<BindListItem> options = new List<BindListItem>();
                options.Add(new BindListItem("テーブルの削除スクリプトを生成する", ScriptOptions.DropTables));
                options.Add(new BindListItem("コメントの削除スクリプトを生成する", ScriptOptions.DropDropDescriptions));
                options.Add(new BindListItem("テーブルの作成スクリプトを生成する", ScriptOptions.CreateTables));
                options.Add(new BindListItem("コメントの作成スクリプトを生成する", ScriptOptions.CreateDropDescriptions));
                this.chkOptions.Items.Clear();
                foreach (BindListItem item in options)
                {
                    this.chkOptions.Items.Add(item,true);
                }

            }
            finally
            {
                this.Cursor = Cursors.Default;
            }


        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.cmbLayoutType.SelectedItem == null)
            {
                MessageBox.Show("設計書の種別を選択してください。");
                return;
            }
            if (this.chkOptions.CheckedItems.Count == 0)
            {
                MessageBox.Show("SQLスクリプト作成オプションをチェックしてください。");
                return;
            }
            if (string.IsNullOrEmpty(this.txtFileName.Text)||!System.IO.File.Exists(this.txtFileName.Text))
            {
                MessageBox.Show("データベース設計書を選択してください。");
                return;
            }

            this._settingInfo = new TableCreateInfo();
            this._settingInfo.LayoutFileName = this.txtFileName.Text;
            TemplateInfo.DocumentTemplateRow tempInfo = 
                (TemplateInfo.DocumentTemplateRow)((DataRowView)this.cmbLayoutType.SelectedItem).Row;
            this._settingInfo.TemplateInfo = tempInfo;
            foreach (BindListItem optItem in this.chkOptions.CheckedItems)
            {
                this._settingInfo.Options |= (ScriptOptions)optItem.Value;
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }


        public class BindListItem
        {
            public string DisplayName
            {
                get;
                set;
            }
            public object Value
            {
                get;
                set;
            }

            public BindListItem(string displayName, object value)
            {
                this.DisplayName = displayName;
                this.Value = value;

            }

            public override string ToString()
            {
                return this.DisplayName;
            }

        }

        private void FileNameSelectButton_Click(object sender, EventArgs e)
        {
            if (this.openExcelDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                this.txtFileName.Text = this.openExcelDialog.FileName;
            }
        }

    }
}
