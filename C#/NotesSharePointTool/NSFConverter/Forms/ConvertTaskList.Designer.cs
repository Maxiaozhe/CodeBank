namespace RJ.Tools.NotesTransfer.UI.Forms
{
    partial class ConvertTaskList
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TaskList = new System.Windows.Forms.DataGridView();
            this.colCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDatabaseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDBPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExecDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new RJ.Tools.NotesTransfer.UI.Component.StyleButton();
            this.btnRun = new RJ.Tools.NotesTransfer.UI.Component.StyleButton();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.ProgressPanel = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblRate = new System.Windows.Forms.Label();
            this.lblTaskName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TaskList)).BeginInit();
            this.ProgressPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TaskList
            // 
            this.TaskList.AllowUserToAddRows = false;
            this.TaskList.AllowUserToDeleteRows = false;
            this.TaskList.AllowUserToResizeRows = false;
            this.TaskList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TaskList.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.TaskList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TaskList.ColumnHeadersHeight = 24;
            this.TaskList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.TaskList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCheck,
            this.colName,
            this.colDatabaseName,
            this.colDBPath,
            this.colStatus,
            this.colExecDate});
            this.TaskList.EnableHeadersVisualStyles = false;
            this.TaskList.Location = new System.Drawing.Point(6, 10);
            this.TaskList.MultiSelect = false;
            this.TaskList.Name = "TaskList";
            this.TaskList.RowHeadersVisible = false;
            this.TaskList.RowTemplate.Height = 21;
            this.TaskList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TaskList.Size = new System.Drawing.Size(826, 527);
            this.TaskList.TabIndex = 0;
            this.TaskList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // colCheck
            // 
            this.colCheck.HeaderText = "実行";
            this.colCheck.Name = "colCheck";
            this.colCheck.Width = 40;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "TASK_NAME";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.colName.DefaultCellStyle = dataGridViewCellStyle1;
            this.colName.HeaderText = "変換設定名";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 160;
            // 
            // colDatabaseName
            // 
            this.colDatabaseName.DataPropertyName = "NS_DB_TITLE";
            this.colDatabaseName.HeaderText = "データベース名";
            this.colDatabaseName.Name = "colDatabaseName";
            this.colDatabaseName.ReadOnly = true;
            this.colDatabaseName.Width = 160;
            // 
            // colDBPath
            // 
            this.colDBPath.DataPropertyName = "NS_FILE_PATH";
            this.colDBPath.HeaderText = "ファイルパス";
            this.colDBPath.Name = "colDBPath";
            this.colDBPath.ReadOnly = true;
            this.colDBPath.Width = 260;
            // 
            // colStatus
            // 
            this.colStatus.DataPropertyName = "STATE";
            this.colStatus.HeaderText = "変換状態";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Width = 80;
            // 
            // colExecDate
            // 
            this.colExecDate.DataPropertyName = "EXECUTE_DATE";
            dataGridViewCellStyle2.Format = "G";
            dataGridViewCellStyle2.NullValue = null;
            this.colExecDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.colExecDate.HeaderText = "最終変換日";
            this.colExecDate.Name = "colExecDate";
            this.colExecDate.ReadOnly = true;
            this.colExecDate.Width = 120;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.btnClose.CategoryName = null;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(141)))), ((int)(((byte)(212)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(737, 540);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(95, 30);
            this.btnClose.StyleName = "FormButton";
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "閉じる";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // btnRun
            // 
            this.btnRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRun.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.btnRun.CategoryName = null;
            this.btnRun.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnRun.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(141)))), ((int)(((byte)(212)))));
            this.btnRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRun.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnRun.ForeColor = System.Drawing.Color.White;
            this.btnRun.Location = new System.Drawing.Point(629, 540);
            this.btnRun.Margin = new System.Windows.Forms.Padding(0);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(95, 30);
            this.btnRun.StyleName = "FormButton";
            this.btnRun.TabIndex = 9;
            this.btnRun.Text = "実行";
            this.btnRun.UseVisualStyleBackColor = false;
            this.btnRun.Click += new System.EventHandler(this.ExecuteButton_Click);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.TaskWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.TaskWorker_RunWorkerCompleted);
            // 
            // ProgressPanel
            // 
            this.ProgressPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ProgressPanel.Controls.Add(this.lblTaskName);
            this.ProgressPanel.Controls.Add(this.lblRate);
            this.ProgressPanel.Controls.Add(this.progressBar1);
            this.ProgressPanel.Controls.Add(this.lblMessage);
            this.ProgressPanel.Location = new System.Drawing.Point(140, 201);
            this.ProgressPanel.Name = "ProgressPanel";
            this.ProgressPanel.Size = new System.Drawing.Size(581, 112);
            this.ProgressPanel.TabIndex = 10;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(24, 54);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(536, 27);
            this.progressBar1.TabIndex = 1;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(26, 33);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(50, 12);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "メッセージ";
            // 
            // lblRate
            // 
            this.lblRate.Location = new System.Drawing.Point(371, 84);
            this.lblRate.Name = "lblRate";
            this.lblRate.Size = new System.Drawing.Size(185, 18);
            this.lblRate.TabIndex = 2;
            this.lblRate.Text = "1/20";
            this.lblRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTaskName
            // 
            this.lblTaskName.AutoSize = true;
            this.lblTaskName.Location = new System.Drawing.Point(16, 9);
            this.lblTaskName.Name = "lblTaskName";
            this.lblTaskName.Size = new System.Drawing.Size(74, 12);
            this.lblTaskName.TabIndex = 3;
            this.lblTaskName.Text = "データベース名";
            // 
            // ConvertTaskList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(844, 582);
            this.Controls.Add(this.ProgressPanel);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.TaskList);
            this.Controls.Add(this.btnClose);
            this.Name = "ConvertTaskList";
            this.StyleName = "Form";
            this.Text = "変換タスク一覧";
            this.Load += new System.EventHandler(this.NotesSettingList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TaskList)).EndInit();
            this.ProgressPanel.ResumeLayout(false);
            this.ProgressPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView TaskList;
        private Component.StyleButton btnClose;
        private Component.StyleButton btnRun;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDatabaseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDBPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExecDate;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.Panel ProgressPanel;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label lblRate;
        private System.Windows.Forms.Label lblTaskName;
    }
}
