using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RJ.Tools.NotesTransfer.Engines.SqlServer;
using RS = RJ.Tools.NotesTransfer.Engines.Resources;
using RSM = RJ.Tools.NotesTransfer.Engines.Resource.ResourceManager;
using RJ.Tools.NotesTransfer.Engines.Interfaces;
using RJ.Tools.NotesTransfer.Engines.Common;
using RJ.Tools.NotesTransfer.Engines.SqlServer.Entity;

namespace RJ.Tools.NotesTransfer.UI.Forms
{
    public partial class FormSelectDialog : Form
    {
        private MigrateTask _selectedTask;
        private IForm _selectedForm;
        public FormSelectDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 選択されたフォーム
        /// </summary>
        public IForm SelectedForm
        {
            get
            {
                return this._selectedForm;
            }
        }

        private void InitTaskList()
        {
            this.cmbTaskList.Items.Clear();
            this.cmbTaskList.DisplayMember = "TASK_NAME";
            DataTable dttSource = GetTaskList();
            this.cmbTaskList.DataSource = dttSource;
        }

        private void InitFormList(MigrateTask task)
        {
            this.lsvFormList.Items.Clear();
            //フォームリスト
            foreach (IForm form in task.TargetForms)
            {
                ListViewItem item = this.lsvFormList.Items.Add(form.Name);
                item.ImageIndex = (form.IsDefault) ? 0 : 1;
                item.SubItems.Add(form.GetAliasesString());
                item.Tag = form;
            }
        }

        private DataTable GetTaskList()
        {
            DataTable result = null;
            using (SqlAccessor accessor = Accessor.AccessorFactory.GetSqlAccessor())
            {
                result = accessor.GetMigrateTasks();
            }
            return result;
        }

        private void FormSelectDialog_Load(object sender, EventArgs e)
        {
            try
            {
                this.btnOK.Enabled = false;
                InitTaskList();
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                RSM.ShowMessage(this, ex);
            }
        }

        private void cmbTaskList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbTaskList.SelectedItem == null)
            {
                return;
            }
            try
            {
                DataRowView row = (DataRowView)this.cmbTaskList.SelectedItem;
                string taskId = Utility.DBToString(row["TASK_ID"]);
                MigrateTask task = null;
                using (SqlAccessor accessor = Accessor.AccessorFactory.GetSqlAccessor())
                {
                    task = accessor.GetMigrateTaskById(taskId,SqlAccessor.DataKind.FormOnly);
                }
                if (task == null)
                {
                    return;
                }
                this._selectedTask = task;
                this.InitFormList(task);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                RSM.ShowMessage(this, ex);
            }

        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if(this._selectedTask==null)
            {
                return;
            }
            if (this.lsvFormList.SelectedItems == null || this.lsvFormList.SelectedItems.Count == 0)
            {
                return;
            }
            IForm formItem = this.lsvFormList.SelectedItems[0].Tag as IForm;
            if (formItem == null)
            {
                return;
            }
            this._selectedForm=formItem;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void lsvFormList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lsvFormList.SelectedItems == null || this.lsvFormList.SelectedItems.Count == 0)
            {
                this.btnOK.Enabled = false;
            }
            else
            {
                this.btnOK.Enabled = true;
            }
        }

    }
}
