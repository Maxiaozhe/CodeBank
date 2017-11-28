using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TableDesignInfo.Controls;
using TableDesignInfo.Entity;

namespace TableDesignInfo.Forms
{
    public partial class DocumentCreateForm : Form
    {
        private DbDocumentInfo _createInfo;

        public DocumentCreateForm()
        {
            InitializeComponent();
            this._createInfo = new DbDocumentInfo();

        }

        public DbDocumentInfo CreateInfo
        {
            get
            {
                return this._createInfo;
            }
        }

        private void DocumentCreateForm_Load(object sender, EventArgs e)
        {
            try
            {
                InitControls();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InitControls()
        {
            //テンプレート一覧
            TemplateInfo.DocumentTemplateDataTable templates = TemplateInfo.LoadTemplate();
            this.cmbTemplate.DisplayMember = "TemplateFileName";
            this.cmbTemplate.DataSource = templates;
            //テーブル一覧
            SearchOptions opts = SearchOptions.None;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.DataSource = LinqSqlHelp.Search("", SearchModes.Contain, opts);
            //選択状態
            SetDataViewState(true);
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtFileName.Text))
            {
                MessageBox.Show(this, "設計書ファイル名を指定してください。", "", MessageBoxButtons.OK);
                return;
            }
            if(this.cmbTemplate.SelectedItem==null){
                MessageBox.Show(this, "テンプレートを選択してください。", "", MessageBoxButtons.OK);
                return;
            }
            this._createInfo.FileName = this.txtFileName.Text;
            this._createInfo.SystemName = this.txtSystemName.Text;
            this._createInfo.SubSystemName = this.txtSubSystemName.Text;
            this._createInfo.TemplateInfo = (TemplateInfo.DocumentTemplateRow)((DataRowView)this.cmbTemplate.SelectedItem).Row;
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                bool isChecked =(bool) row.Cells[0].FormattedValue;
                if (isChecked)
                {
                    TableList selectedTable =  row.DataBoundItem as TableList;
                    this._createInfo.TableNames.Add(selectedTable.TableName);
                }
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            SetDataViewState(true);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            SetDataViewState(false);
        }

        private void SetDataViewState(bool check)
        {
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                row.Cells[0].Value = check;
            }
        }

        private void btnFileName_Click(object sender, EventArgs e)
        {

            this.openFileDialog1.FileName = string.Format("データベース設計書({0}).xlsx",GetDatabaseName());
            if (this.openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                this.txtFileName.Text = this.openFileDialog1.FileName;
            }
        }

        private string GetDatabaseName()
        {
            string pattern = @"initial catalog=(?<value>[^;\=]+);{0,1}";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            string conn=LinqSqlHelp.CurrentConnection;
            Match match = regex.Match(conn);
            if (match.Success)
            {
                return match.Groups["value"].Value;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
