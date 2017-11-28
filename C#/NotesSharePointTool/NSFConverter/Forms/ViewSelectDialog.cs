using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RJ.Tools.NotesTransfer.Engines.Interfaces;
using RJ.Tools.NotesTransfer.Engines.SqlServer;
using RJ.Tools.NotesTransfer.Engines.SqlServer.Entity;
using RS = RJ.Tools.NotesTransfer.Engines.Resources;
using RSM = RJ.Tools.NotesTransfer.Engines.Resource.ResourceManager;
using RJ.Tools.NotesTransfer.Engines.Common;

namespace RJ.Tools.NotesTransfer.UI.Forms
{
    public partial class ViewSelectDialog : FormBase
    {
        
        private MigrateTask _selectedTask;
        private IView _selectedView;

        public ViewSelectDialog()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 選択されたビュー
        /// </summary>
        public IView SelectedView
        {
            get
            {
                return this._selectedView;
            }
        }

        private void InitTaskList()
        {
            this.cmbTaskList.Items.Clear();
            this.cmbTaskList.DisplayMember = "TASK_NAME";
            DataTable dttSource = GetTaskList();
            this.cmbTaskList.DataSource = dttSource;
        }

        private void InitViewList(MigrateTask task)
        {
            this.lsvViewList.Items.Clear();
            //フォームリスト
            foreach (IView view in task.TargetViews)
            {
                ListViewItem item = this.lsvViewList.Items.Add(view.Name);
                item.ImageIndex = (view.IsDefault) ? 0 : 1;
                item.SubItems.Add(view.GetAliasesString());
                item.Tag = view;
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
                    task = accessor.GetMigrateTaskById(taskId,SqlAccessor.DataKind.ViewOnly);
                }
                if (task == null)
                {
                    return;
                }
                this._selectedTask = task;
                this.InitViewList(task);
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
            if (this.lsvViewList.SelectedItems == null || this.lsvViewList.SelectedItems.Count == 0)
            {
                return;
            }
            IView viewItem = this.lsvViewList.SelectedItems[0].Tag as IView;
            if (viewItem == null)
            {
                return;
            }
            this._selectedView = viewItem;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void lsvViewList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lsvViewList.SelectedItems == null || this.lsvViewList.SelectedItems.Count == 0)
            {
                this.btnOK.Enabled = false;
            }
            else
            {
                this.btnOK.Enabled = true;
            }
        }

        private void ViewSelectDialog_Load(object sender, EventArgs e)
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
    }
}
