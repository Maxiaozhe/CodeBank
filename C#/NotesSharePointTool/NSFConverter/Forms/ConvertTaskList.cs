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
using RJ.Tools.NotesTransfer.Engines.Interfaces;
using RJ.Tools.NotesTransfer.Engines.Common;

namespace RJ.Tools.NotesTransfer.UI.Forms
{
    public partial class ConvertTaskList : FormBase
    {
        public ConvertTaskList()
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
                this.ProgressPanel.Visible = false;
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
                taskInfo = accessor.GetMigrateTaskById(taskId, SqlAccessor.DataKind.All);
            }
            if (taskInfo == null) return;
            using (DataBaseSeting dbSetting = new DataBaseSeting())
            {
                dbSetting.TaskInfo = taskInfo;
                dbSetting.ShowDialog(this.Owner);
            }
            InitNotesSettingList();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ExecuteButton_Click(object sender, EventArgs e)
        {
            List<string> taskIds = new List<string>();
            foreach (DataGridViewRow row in this.TaskList.Rows)
            {
                bool isChecked = false;
                object cellValue = row.Cells[0].Value;
                if (cellValue != null && bool.TryParse(cellValue.ToString(), out isChecked))
                {
                    if (isChecked)
                    {
                        DataRowView dataItem = row.DataBoundItem as DataRowView;
                        if (dataItem == null) continue;
                        string taskid = dataItem["TASK_ID"] as string;
                        taskIds.Add(taskid);
                    }
                }
            }
            if (taskIds.Count == 0) return;
            //プログレスバー表示
            this.ProgressPanel.Visible = true;
            this.TaskList.Enabled = false;
            this.btnRun.Enabled = false;
            this.btnClose.Enabled = false;
            this.lblMessage.Text = "";
            this.lblTaskName.Text = "";
            this.lblRate.Text = "";
            //変換開始
            this.backgroundWorker.RunWorkerAsync(taskIds);
        }
        /// <summary>
        /// ワーカーを実行する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Accessor.Convertor convert = new Accessor.Convertor();
            List<string> taskIds = (List<string>)e.Argument;
            MigrateTask task = null;
            using (SqlAccessor sqlAccessor = Accessor.AccessorFactory.GetSqlAccessor())
            {
                foreach (string id in taskIds)
                {
                    //開始時間
                    DateTime sdate = DateTime.Now;
                    try
                    {
                        task = sqlAccessor.GetMigrateTaskById(id, SqlAccessor.DataKind.All);
                        ProgressReporter reporter = new ProgressReporter(task.TaskName, OnReported);
                        convert.DoConvert(task, reporter);
                        //終了時間
                        DateTime edate=DateTime.Now;
                        sqlAccessor.UpdateMigrate(task, true);
                        Log.Write(task, RSM.GetMessage(RS.Informations.ConvertCompleted, task.TaskName), true, sdate, edate);
                    }
                    catch (Exception)
                    {
                        if (task != null)
                        {
                            sqlAccessor.UpdateMigrate(task, false);
                        }
                        //終了時間
                        DateTime edate = DateTime.Now;
                        Log.Write(task, RSM.GetMessage(RS.Informations.ConvertFailed, task.TaskName), true, sdate, edate);
                        throw;
                    }
                }
            }
        }

        private void OnReported(object sender, ReportEventArgs args)
        {
            this.backgroundWorker.ReportProgress(args.ProgressPercentage, args);
        }
        /// <summary>
        /// ワーカーの進歩報告
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TaskWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState is ReportEventArgs)
            {
                ReportEventArgs arg = (ReportEventArgs)e.UserState;
                this.lblTaskName.Text = arg.TaskName;
                this.lblMessage.Text = arg.Message;
                this.lblRate.Text = string.Format("{0} / {1}", arg.ProcessedCount, arg.SetpCount);
            }
            else if (e.UserState is string)
            {
                this.lblMessage.Text = (string)e.UserState;
            }

            this.progressBar1.Value = e.ProgressPercentage;
        }
        /// <summary>
        /// ワーカー処理完了
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TaskWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.ProgressPanel.Visible = false;
            this.TaskList.Enabled = true;
            this.btnRun.Enabled = true;
            this.btnClose.Enabled = true;
            if (e.Error != null)
            {
                Log.Write(e.Error);
                RSM.ShowMessage(this, e.Error);
            }
            InitNotesSettingList();
        }
    }
}
