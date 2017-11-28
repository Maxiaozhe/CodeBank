namespace RJ.Tools.NotesTransfer.UI.Forms
{
    partial class LogAdmin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtgEventLog = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.styleButton1 = new RJ.Tools.NotesTransfer.UI.Component.StyleButton();
            this.button3 = new RJ.Tools.NotesTransfer.UI.Component.StyleButton();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.styleLabel1 = new RJ.Tools.NotesTransfer.UI.Component.StyleLabel();
            this.btnDelete = new RJ.Tools.NotesTransfer.UI.Component.StyleButton();
            this.btnCsvSave = new RJ.Tools.NotesTransfer.UI.Component.StyleButton();
            this.cmbLogType = new System.Windows.Forms.ComboBox();
            this.styleLabel6 = new RJ.Tools.NotesTransfer.UI.Component.StyleLabel();
            this.dtgSystemLog = new System.Windows.Forms.DataGridView();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colsource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coldetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colComputer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEventLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSystemLog)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgEventLog
            // 
            this.dtgEventLog.AllowUserToAddRows = false;
            this.dtgEventLog.AllowUserToDeleteRows = false;
            this.dtgEventLog.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            this.dtgEventLog.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgEventLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgEventLog.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dtgEventLog.ColumnHeadersHeight = 24;
            this.dtgEventLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtgEventLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.dtgEventLog.EnableHeadersVisualStyles = false;
            this.dtgEventLog.Location = new System.Drawing.Point(7, 106);
            this.dtgEventLog.Name = "dtgEventLog";
            this.dtgEventLog.ReadOnly = true;
            this.dtgEventLog.RowHeadersVisible = false;
            this.dtgEventLog.RowTemplate.Height = 21;
            this.dtgEventLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgEventLog.Size = new System.Drawing.Size(820, 446);
            this.dtgEventLog.TabIndex = 29;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "EVENT_TIME";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "G";
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn1.HeaderText = "日付";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 120;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "TASK_ID";
            dataGridViewCellStyle3.NullValue = null;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn6.HeaderText = "対象ID";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 140;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "TASK_NAME";
            this.dataGridViewTextBoxColumn4.HeaderText = "対象";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "MESSAGE";
            this.dataGridViewTextBoxColumn5.HeaderText = "内容";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 240;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "USER_NAME";
            dataGridViewCellStyle4.Format = "G";
            dataGridViewCellStyle4.NullValue = null;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn2.HeaderText = "ユーザー";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "COMPUTER_NAME";
            this.dataGridViewTextBoxColumn3.HeaderText = "コンピュータ";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // styleButton1
            // 
            this.styleButton1.CategoryName = null;
            this.styleButton1.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.styleButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.styleButton1.Location = new System.Drawing.Point(491, 73);
            this.styleButton1.Margin = new System.Windows.Forms.Padding(0);
            this.styleButton1.Name = "styleButton1";
            this.styleButton1.Size = new System.Drawing.Size(69, 24);
            this.styleButton1.StyleName = "ActionButton";
            this.styleButton1.TabIndex = 28;
            this.styleButton1.Text = "検索";
            this.styleButton1.UseVisualStyleBackColor = false;
            this.styleButton1.Click += new System.EventHandler(this.styleButton1_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.button3.CategoryName = null;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(141)))), ((int)(((byte)(212)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold);
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(732, 562);
            this.button3.Margin = new System.Windows.Forms.Padding(0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(95, 31);
            this.button3.StyleName = "FormButton";
            this.button3.TabIndex = 27;
            this.button3.Text = "閉じる";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(334, 76);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.ShowCheckBox = true;
            this.dtpEndDate.Size = new System.Drawing.Size(140, 19);
            this.dtpEndDate.TabIndex = 17;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(168, 76);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.ShowCheckBox = true;
            this.dtpStartDate.Size = new System.Drawing.Size(140, 19);
            this.dtpStartDate.TabIndex = 16;
            // 
            // styleLabel1
            // 
            this.styleLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.styleLabel1.CategoryName = null;
            this.styleLabel1.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.styleLabel1.ForeColor = System.Drawing.Color.White;
            this.styleLabel1.Location = new System.Drawing.Point(10, 73);
            this.styleLabel1.Name = "styleLabel1";
            this.styleLabel1.Size = new System.Drawing.Size(148, 24);
            this.styleLabel1.StyleName = "Caption";
            this.styleLabel1.TabIndex = 15;
            this.styleLabel1.Text = "表示期間";
            this.styleLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnDelete
            // 
            this.btnDelete.CategoryName = null;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Location = new System.Drawing.Point(90, 9);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(69, 24);
            this.btnDelete.StyleName = "ActionButton";
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "削除";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCsvSave
            // 
            this.btnCsvSave.CategoryName = null;
            this.btnCsvSave.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnCsvSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCsvSave.Location = new System.Drawing.Point(7, 9);
            this.btnCsvSave.Margin = new System.Windows.Forms.Padding(0);
            this.btnCsvSave.Name = "btnCsvSave";
            this.btnCsvSave.Size = new System.Drawing.Size(69, 24);
            this.btnCsvSave.StyleName = "ActionButton";
            this.btnCsvSave.TabIndex = 12;
            this.btnCsvSave.Text = "CSV出力";
            this.btnCsvSave.UseVisualStyleBackColor = false;
            this.btnCsvSave.Click += new System.EventHandler(this.btnCsvSave_Click);
            // 
            // cmbLogType
            // 
            this.cmbLogType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLogType.FormattingEnabled = true;
            this.cmbLogType.Location = new System.Drawing.Point(165, 44);
            this.cmbLogType.Name = "cmbLogType";
            this.cmbLogType.Size = new System.Drawing.Size(147, 20);
            this.cmbLogType.TabIndex = 8;
            // 
            // styleLabel6
            // 
            this.styleLabel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.styleLabel6.CategoryName = null;
            this.styleLabel6.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.styleLabel6.ForeColor = System.Drawing.Color.White;
            this.styleLabel6.Location = new System.Drawing.Point(11, 41);
            this.styleLabel6.Name = "styleLabel6";
            this.styleLabel6.Size = new System.Drawing.Size(148, 24);
            this.styleLabel6.StyleName = "Caption";
            this.styleLabel6.TabIndex = 7;
            this.styleLabel6.Text = "ログ種別";
            this.styleLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtgSystemLog
            // 
            this.dtgSystemLog.AllowUserToAddRows = false;
            this.dtgSystemLog.AllowUserToDeleteRows = false;
            this.dtgSystemLog.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LightGray;
            this.dtgSystemLog.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dtgSystemLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgSystemLog.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dtgSystemLog.ColumnHeadersHeight = 24;
            this.dtgSystemLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtgSystemLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDate,
            this.colsource,
            this.colMessage,
            this.coldetail,
            this.colUser,
            this.colComputer});
            this.dtgSystemLog.EnableHeadersVisualStyles = false;
            this.dtgSystemLog.Location = new System.Drawing.Point(7, 106);
            this.dtgSystemLog.Name = "dtgSystemLog";
            this.dtgSystemLog.ReadOnly = true;
            this.dtgSystemLog.RowHeadersVisible = false;
            this.dtgSystemLog.RowTemplate.Height = 21;
            this.dtgSystemLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgSystemLog.Size = new System.Drawing.Size(820, 446);
            this.dtgSystemLog.TabIndex = 1;
            // 
            // colDate
            // 
            this.colDate.DataPropertyName = "EVENT_TIME";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Format = "G";
            dataGridViewCellStyle6.NullValue = null;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.colDate.DefaultCellStyle = dataGridViewCellStyle6;
            this.colDate.HeaderText = "日付";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            this.colDate.Width = 120;
            // 
            // colsource
            // 
            this.colsource.DataPropertyName = "SOURCE";
            this.colsource.HeaderText = "対象";
            this.colsource.Name = "colsource";
            this.colsource.ReadOnly = true;
            // 
            // colMessage
            // 
            this.colMessage.DataPropertyName = "MESSAGE";
            this.colMessage.HeaderText = "内容";
            this.colMessage.Name = "colMessage";
            this.colMessage.ReadOnly = true;
            this.colMessage.Width = 240;
            // 
            // coldetail
            // 
            this.coldetail.DataPropertyName = "STACK_TRACE";
            this.coldetail.HeaderText = "詳細";
            this.coldetail.Name = "coldetail";
            this.coldetail.ReadOnly = true;
            this.coldetail.Width = 140;
            // 
            // colUser
            // 
            this.colUser.DataPropertyName = "USER_NAME";
            dataGridViewCellStyle7.Format = "G";
            dataGridViewCellStyle7.NullValue = null;
            this.colUser.DefaultCellStyle = dataGridViewCellStyle7;
            this.colUser.HeaderText = "ユーザー";
            this.colUser.Name = "colUser";
            this.colUser.ReadOnly = true;
            // 
            // colComputer
            // 
            this.colComputer.DataPropertyName = "COMPUTER_NAME";
            this.colComputer.HeaderText = "コンピュータ";
            this.colComputer.Name = "colComputer";
            this.colComputer.ReadOnly = true;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "csvファイル|*.csv";
            // 
            // LogAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 602);
            this.Controls.Add(this.dtgEventLog);
            this.Controls.Add(this.styleButton1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.styleLabel1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCsvSave);
            this.Controls.Add(this.cmbLogType);
            this.Controls.Add(this.styleLabel6);
            this.Controls.Add(this.dtgSystemLog);
            this.Name = "LogAdmin";
            this.StyleName = "Form";
            this.Text = "ログ一覧";
            this.Load += new System.EventHandler(this.LogAdmin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgEventLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSystemLog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgSystemLog;
        private Component.StyleLabel styleLabel6;
        private System.Windows.Forms.ComboBox cmbLogType;
        private Component.StyleButton btnDelete;
        private Component.StyleButton btnCsvSave;
        private Component.StyleLabel styleLabel1;
        internal System.Windows.Forms.DateTimePicker dtpEndDate;
        internal System.Windows.Forms.DateTimePicker dtpStartDate;
        private Component.StyleButton button3;
        private Component.StyleButton styleButton1;
        private System.Windows.Forms.DataGridView dtgEventLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colsource;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMessage;
        private System.Windows.Forms.DataGridViewTextBoxColumn coldetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn colComputer;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}