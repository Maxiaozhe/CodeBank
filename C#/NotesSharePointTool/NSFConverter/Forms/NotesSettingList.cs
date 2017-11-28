using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RJ.Tools.NotesTransfer.Engines.SqlServer.Entity;
using RJ.Tools.NotesTransfer.Engines.SqlServer;
using RJ.Tools.NotesTransfer.Engines.Enums;
using RS = RJ.Tools.NotesTransfer.Engines.Resources;
using RSM = RJ.Tools.NotesTransfer.Engines.Resource.ResourceManager;
using RJ.Tools.NotesTransfer.Engines.Common;

namespace RJ.Tools.NotesTransfer.UI.Forms
{
    public partial class NotesSettingList : FormBase
    {
        public NotesSettingList()
        {
            InitializeComponent();
        }


        private void InitNotesSettingList()
        {
            DataTable dtt = GetSettingList();
            this.TaskList.AutoGenerateColumns = false;
            this.TaskList.DataSource = dtt;
        }

        private DataTable GetSettingList()
        {
            DataTable result = null;
            using (SqlAccessor accessor = Accessor.AccessorFactory.GetSqlAccessor())
            {
                result = accessor.GetMigrateTasks();
            }
            return result;
        }

        private void NotesSettingList_Load(object sender, EventArgs e)
        {
            try
            {
                InitNotesSettingList();
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                RSM.ShowMessage(this, ex);
            }

        }


        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                //状態
                if (e.Value != null && e.Value is int)
                {
                    TaskState state = (TaskState)((int)e.Value);
                    e.FormattingApplied = true;
                    switch (state)
                    {
                        case TaskState.NotExecute:
                            e.Value = RSM.GetMessage(RS.StringTable.TaskState_NotExecute);
                            break;
                        case TaskState.Executed:
                            e.Value = RSM.GetMessage(RS.StringTable.TaskState_Executed);
                            break;
                        case TaskState.ExecutFailed:
                            e.Value = RSM.GetMessage(RS.StringTable.TaskState_ExecutFailed);
                            break;
                        default:
                            e.Value = string.Empty;
                            break;
                    }
                }
            }
        }


        /// <summary>
        /// 新規作成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewButton_Click(object sender, EventArgs e)
        {
            MigrateTask taskInfo = new MigrateTask();
            using (DataBaseSeting dbSetting = new DataBaseSeting())
            {
                dbSetting.TaskInfo = taskInfo;
                dbSetting.ShowDialog(this.Owner);
            }
            InitNotesSettingList();
        }

        /// <summary>
        /// 設定を編集する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditButton_Click(object sender, EventArgs e)
        {
            if (this.TaskList.SelectedRows == null || this.TaskList.SelectedRows.Count == 0)
            {
                return;
            }
            var seleRow = this.TaskList.SelectedRows[0];
            var item = seleRow.DataBoundItem as DataRowView;
            if (item == null) return;
            string taskId = item["TASK_ID"] as string;
            MigrateTask taskInfo = null;
            using (SqlAccessor accessor = Accessor.AccessorFactory.GetSqlAccessor())
            {
                taskInfo = accessor.GetMigrateTaskById(taskId,SqlAccessor.DataKind.All);
            }
            if (taskInfo == null) return;
            using (DataBaseSeting dbSetting = new DataBaseSeting())
            {
                dbSetting.TaskInfo = taskInfo;
                dbSetting.ShowDialog(this.Owner);
            }
            InitNotesSettingList();
        }

        /// <summary>
        /// 削除ボタンを押す処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (this.TaskList.SelectedRows == null || this.TaskList.SelectedRows.Count == 0)
            {
                return;
            }
            try
            {
                var seleRow = this.TaskList.SelectedRows[0];
                var item = seleRow.DataBoundItem as DataRowView;
                if (item == null) return;
                string taskId = item["TASK_ID"] as string;
                string taskName = item["TASK_NAME"] as string;
                using (SqlAccessor accessor = Accessor.AccessorFactory.GetSqlAccessor())
                {
                    accessor.DeleteMigrateTask(taskId);
                }
                Log.Write(taskId, RSM.GetMessage(RS.Informations.DatabaseDeleted, taskName, taskId));                
                InitNotesSettingList();
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                RSM.ShowMessage(this, ex);
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
