using Excel = Microsoft.Office.Interop.Excel;
using Rex.Tools.Test.DataCheck.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rex.Tools.Test.DataCheck.Common;
using Rex.Tools.Test.DataCheck.Enums;

namespace Rex.Tools.Test.DataCheck.Forms
{
    public partial class SelectDbLayoutForm : BaseForm
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
                Logging.Exception("", ex);
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
                //テーブル一覧表示
                this.cmbTableSheets.Items.Clear();
                using (ExcelHelp xls = new ExcelHelp(Config.DbTableListSettingFile))
                {
                    foreach (Excel.Worksheet sheet in xls.WorkBook.Sheets)
                    {
                        if (sheet.Visible == Excel.XlSheetVisibility.xlSheetVisible)
                        {
                            this.cmbTableSheets.Items.Add(sheet.Name);
                        }
                    }
                }
                if (this.cmbTableSheets.Items.Count > 0)
                {
                    this.cmbTableSheets.SelectedIndex = 0;
                }
                //設計書種別
                List<BindListItem> layoutTypes = new List<BindListItem>();
                layoutTypes.Add(new BindListItem("データベース設計書(LIVE用)", LayoutType.Live));
                layoutTypes.Add(new BindListItem("データベース設計書(SEED用)", LayoutType.Seed));
                this.cmbLayoutType.Items.Clear();
                this.cmbLayoutType.DisplayMember = "DisplayName";
                this.cmbLayoutType.ValueMember = "Value";
                foreach (BindListItem item in layoutTypes)
                {
                    this.cmbLayoutType.Items.Add(item);
                }
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
            if (this.cmbTableSheets.SelectedIndex == -1)
            {
                MessageBox.Show(this,"テーブル一覧を選択してください。","警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
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
            this._settingInfo.TableListSheetName = (string)this.cmbTableSheets.SelectedItem;
            this._settingInfo.LayoutFileName = this.txtFileName.Text;
            BindListItem item = (BindListItem)this.cmbLayoutType.SelectedItem;
            this._settingInfo.LayoutKind = (LayoutType)item.Value;
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
