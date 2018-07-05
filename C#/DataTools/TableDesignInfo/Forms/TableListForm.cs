using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TableDesignInfo.Controls;
using TableDesignInfo.Entity;

namespace TableDesignInfo.Forms
{

    public partial class TableListForm : Form
    {

        public TableListForm()
        {
            InitializeComponent();
        }



        private void InitSearchMode()
        {
            this.cmbSearchMode.Items.Clear();
            this.cmbSearchMode.DisplayMember = "DisplayName";
            this.cmbSearchMode.ValueMember = "Value";
            this.cmbSearchMode.DataSource = GetSearchMode();
        }

        private void InitMenu()
        {
            ConnectionStringSettingsCollection conns = ConfigurationManager.ConnectionStrings;
            foreach (ConnectionStringSettings conn in conns)
            {
                string name = conn.Name.Replace("TableDesignInfo.Properties.Settings.", "");
                ToolStripMenuItem menuItem = (ToolStripMenuItem)this.mnuConnection.DropDownItems.Add(name);
                menuItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
                if (conn.ConnectionString.Equals(LinqSqlHelp.CurrentConnection))
                {
                    menuItem.Checked = true;
                }
                else
                {
                    menuItem.Checked = false;
                }
                menuItem.Tag = conn.ConnectionString;
                menuItem.Click += MenuItem_Click;
            }
        }

        private void MenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
            if (menuItem == null) return;
            string connectString = menuItem.Tag as string;
            if (!string.IsNullOrEmpty(connectString))
            {
                LinqSqlHelp.CurrentConnection = connectString;
            }
            menuItem.Checked = true;
            ToolStripMenuItem parent = menuItem.OwnerItem as ToolStripMenuItem;
            if (parent == null) return;
            foreach (ToolStripMenuItem item in parent.DropDownItems)
            {
                if (item != menuItem)
                {
                    item.Checked = false;
                }
            }
        }

        private List<ComboBoxItem> GetSearchMode()
        {
            List<ComboBoxItem> modes = new List<ComboBoxItem>();
            modes.Add(new ComboBoxItem() { DisplayName = "含む", Value = SearchModes.Contain });
            modes.Add(new ComboBoxItem() { DisplayName = "前方一致", Value = SearchModes.ForwardMatch });
            modes.Add(new ComboBoxItem() { DisplayName = "後方一致", Value = SearchModes.BackwardMatch });
            modes.Add(new ComboBoxItem() { DisplayName = "完全一致", Value = SearchModes.Equale });
            return modes;
        }

        private void TableSearchForm_Load(object sender, EventArgs e)
        {
            InitMenu();
            InitSearchMode();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string keyword = this.txtSearch.Text;
            SearchModes mode = (SearchModes)this.cmbSearchMode.SelectedValue;
            SearchOptions opts = (this.chkTableName.Checked ? SearchOptions.TableName : SearchOptions.None) |
                                (this.chkColumn.Checked ? SearchOptions.ColumnName : SearchOptions.None) |
                                  (this.chkComment.Checked ? SearchOptions.CommentName : SearchOptions.None);
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.DataSource = LinqSqlHelp.Search(keyword, mode, opts);
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (e.ColumnIndex != 0) return;
            int index = e.RowIndex;
            TableList selectedTable = this.dataGridView1.Rows[index].DataBoundItem as TableList;
            TableLayoutForm form = new TableLayoutForm() { Table = selectedTable };
            form.Show(this);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            int index = e.RowIndex;
            TableList selectedTable = this.dataGridView1.Rows[index].DataBoundItem as TableList;
            TableLayoutForm form = new TableLayoutForm() { Table = selectedTable };
            form.Show(this);

        }

        private void mnuUpdateDBInfo_Click(object sender, EventArgs e)
        {
            try
            {
                this.lblMessage.Text = "最新情報の更新中...";
                this.toolStripProgressBar1.Visible = true;
                this.Cursor = Cursors.WaitCursor;
                WorkArguments arg = new WorkArguments("UpdateTableInfo");
                backgroundWorker1.RunWorkerAsync(arg);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "例外", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            WorkArguments commandArg = e.Argument as WorkArguments;


            switch (commandArg.Command)
            {
                case "UpdateTableInfo":
                    LinqSqlHelp.UpdateTableInfo();
                    break;
                case "DocumentCreate":
                    DbDocumentCreator creator = new DbDocumentCreator();
                    creator.CreateDocument((DbDocumentInfo)commandArg.Args);
                    break;
                case "DocumentRead":
                    DbDocumentReader reader = new DbDocumentReader();
                    reader.CreateDBScript((TableCreateInfo)commandArg.Args);
                    break;
                default:
                    break;
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                this.lblMessage.Text = e.Error.Message;
                this.lblMessage.ForeColor = Color.Red;
            }
            else
            {
                this.lblMessage.ForeColor = Color.Black;
                this.lblMessage.Text = "";
            }
            this.toolStripProgressBar1.Visible = false;
            this.Cursor = Cursors.Default;
        }

        private void mnuDbDocumentCreate_Click(object sender, EventArgs e)
        {
            using (DocumentCreateForm docForm = new DocumentCreateForm())
            {
                if (docForm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    this.lblMessage.ForeColor = Color.Black;
                    this.lblMessage.Text = "データベース設計書を作成しています...";
                    this.toolStripProgressBar1.Visible = true;
                    this.Cursor = Cursors.WaitCursor;
                    WorkArguments arg = new WorkArguments("DocumentCreate");
                    arg.Args = docForm.CreateInfo;
                    backgroundWorker1.RunWorkerAsync(arg);
                }
            }
        }

        private void mnuDocumentImport_Click(object sender, EventArgs e)
        {
            using (SelectDbLayoutForm setForm = new SelectDbLayoutForm())
            {
                if (setForm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    this.lblMessage.ForeColor = Color.Black;
                    this.lblMessage.Text = "データベース設計書からスクリプトを作成しています...";

                    this.toolStripProgressBar1.Visible = true;
                    this.Cursor = Cursors.WaitCursor;
                    WorkArguments arg = new WorkArguments("DocumentRead");
                    arg.Args = setForm.SettingInfo;
                    backgroundWorker1.RunWorkerAsync(arg);
                }
            }
        }

    }

}