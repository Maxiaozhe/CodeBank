namespace RJ.Tools.NotesTransfer.UI.Forms
{
    partial class NotesSettingList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TaskList = new System.Windows.Forms.DataGridView();
            this.styleButton4 = new RJ.Tools.NotesTransfer.UI.Component.StyleButton();
            this.styleButton3 = new RJ.Tools.NotesTransfer.UI.Component.StyleButton();
            this.btnNew = new RJ.Tools.NotesTransfer.UI.Component.StyleButton();
            this.styleButton1 = new RJ.Tools.NotesTransfer.UI.Component.StyleButton();
            this.colNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDatabaseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDBPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExecDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.TaskList)).BeginInit();
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
            this.colNo,
            this.colName,
            this.colDatabaseName,
            this.colDBPath,
            this.colStatus,
            this.colExecDate});
            this.TaskList.EnableHeadersVisualStyles = false;
            this.TaskList.Location = new System.Drawing.Point(6, 36);
            this.TaskList.MultiSelect = false;
            this.TaskList.Name = "TaskList";
            this.TaskList.RowHeadersVisible = false;
            this.TaskList.RowTemplate.Height = 21;
            this.TaskList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TaskList.Size = new System.Drawing.Size(826, 501);
            this.TaskList.TabIndex = 0;
            this.TaskList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // styleButton4
            // 
            this.styleButton4.CategoryName = null;
            this.styleButton4.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.styleButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.styleButton4.Location = new System.Drawing.Point(150, 9);
            this.styleButton4.Margin = new System.Windows.Forms.Padding(0);
            this.styleButton4.Name = "styleButton4";
            this.styleButton4.Size = new System.Drawing.Size(69, 24);
            this.styleButton4.StyleName = "ActionButton";
            this.styleButton4.TabIndex = 11;
            this.styleButton4.Text = "削除";
            this.styleButton4.UseVisualStyleBackColor = false;
            this.styleButton4.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // styleButton3
            // 
            this.styleButton3.CategoryName = null;
            this.styleButton3.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.styleButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.styleButton3.Location = new System.Drawing.Point(77, 9);
            this.styleButton3.Margin = new System.Windows.Forms.Padding(0);
            this.styleButton3.Name = "styleButton3";
            this.styleButton3.Size = new System.Drawing.Size(69, 24);
            this.styleButton3.StyleName = "ActionButton";
            this.styleButton3.TabIndex = 10;
            this.styleButton3.Text = "編集";
            this.styleButton3.UseVisualStyleBackColor = false;
            this.styleButton3.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // btnNew
            // 
            this.btnNew.CategoryName = null;
            this.btnNew.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Location = new System.Drawing.Point(4, 9);
            this.btnNew.Margin = new System.Windows.Forms.Padding(0);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(69, 24);
            this.btnNew.StyleName = "ActionButton";
            this.btnNew.TabIndex = 9;
            this.btnNew.Text = "新規";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.NewButton_Click);
            // 
            // styleButton1
            // 
            this.styleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.styleButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.styleButton1.CategoryName = null;
            this.styleButton1.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.styleButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(141)))), ((int)(((byte)(212)))));
            this.styleButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.styleButton1.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold);
            this.styleButton1.ForeColor = System.Drawing.Color.White;
            this.styleButton1.Location = new System.Drawing.Point(737, 542);
            this.styleButton1.Margin = new System.Windows.Forms.Padding(0);
            this.styleButton1.Name = "styleButton1";
            this.styleButton1.Size = new System.Drawing.Size(95, 30);
            this.styleButton1.StyleName = "FormButton";
            this.styleButton1.TabIndex = 8;
            this.styleButton1.Text = "閉じる";
            this.styleButton1.UseVisualStyleBackColor = false;
            this.styleButton1.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // colNo
            // 
            this.colNo.DataPropertyName = "No";
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colNo.DefaultCellStyle = dataGridViewCellStyle22;
            this.colNo.HeaderText = "No";
            this.colNo.Name = "colNo";
            this.colNo.Width = 24;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "TASK_NAME";
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.colName.DefaultCellStyle = dataGridViewCellStyle23;
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
            dataGridViewCellStyle24.Format = "G";
            dataGridViewCellStyle24.NullValue = null;
            this.colExecDate.DefaultCellStyle = dataGridViewCellStyle24;
            this.colExecDate.HeaderText = "最終変換日";
            this.colExecDate.Name = "colExecDate";
            this.colExecDate.ReadOnly = true;
            this.colExecDate.Width = 120;
            // 
            // NotesSettingList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(844, 582);
            this.Controls.Add(this.TaskList);
            this.Controls.Add(this.styleButton4);
            this.Controls.Add(this.styleButton3);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.styleButton1);
            this.Name = "NotesSettingList";
            this.StyleName = "Form";
            this.Text = "データベース設定一覧";
            this.Load += new System.EventHandler(this.NotesSettingList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TaskList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView TaskList;
        private Component.StyleButton styleButton1;
        private Component.StyleButton btnNew;
        private Component.StyleButton styleButton3;
        private Component.StyleButton styleButton4;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDatabaseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDBPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExecDate;
    }
}
