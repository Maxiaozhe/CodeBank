namespace Rex.Tools.Test.DataCheck.Forms
{
    partial class MenuForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
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
            this.ProgressPanel = new System.Windows.Forms.Panel();
            this.lblParcentage = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.mnuPanel = new System.Windows.Forms.Panel();
            this.dtnDenshowInsertDataCreate = new System.Windows.Forms.Button();
            this.btnDenshow = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.openExcelDialog = new System.Windows.Forms.OpenFileDialog();
            this.ProgressPanel.SuspendLayout();
            this.mnuPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProgressPanel
            // 
            this.ProgressPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ProgressPanel.Controls.Add(this.lblParcentage);
            this.ProgressPanel.Controls.Add(this.lblMessage);
            this.ProgressPanel.Controls.Add(this.progressBar1);
            this.ProgressPanel.Location = new System.Drawing.Point(12, 156);
            this.ProgressPanel.Name = "ProgressPanel";
            this.ProgressPanel.Size = new System.Drawing.Size(554, 101);
            this.ProgressPanel.TabIndex = 5;
            this.ProgressPanel.Visible = false;
            // 
            // lblParcentage
            // 
            this.lblParcentage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblParcentage.Location = new System.Drawing.Point(406, 69);
            this.lblParcentage.Name = "lblParcentage";
            this.lblParcentage.Size = new System.Drawing.Size(134, 16);
            this.lblParcentage.TabIndex = 2;
            this.lblParcentage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(14, 8);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 12);
            this.lblMessage.TabIndex = 1;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(12, 43);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(528, 23);
            this.progressBar1.TabIndex = 0;
            // 
            // mnuPanel
            // 
            this.mnuPanel.Controls.Add(this.dtnDenshowInsertDataCreate);
            this.mnuPanel.Controls.Add(this.btnDenshow);
            this.mnuPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mnuPanel.Location = new System.Drawing.Point(0, 0);
            this.mnuPanel.Name = "mnuPanel";
            this.mnuPanel.Size = new System.Drawing.Size(578, 417);
            this.mnuPanel.TabIndex = 6;
            // 
            // dtnDenshowInsertDataCreate
            // 
            this.dtnDenshowInsertDataCreate.Location = new System.Drawing.Point(122, 69);
            this.dtnDenshowInsertDataCreate.Name = "dtnDenshowInsertDataCreate";
            this.dtnDenshowInsertDataCreate.Size = new System.Drawing.Size(307, 25);
            this.dtnDenshowInsertDataCreate.TabIndex = 11;
            this.dtnDenshowInsertDataCreate.Text = "伝匠 初期化スクリプト作成";
            this.dtnDenshowInsertDataCreate.UseVisualStyleBackColor = true;
            this.dtnDenshowInsertDataCreate.Click += new System.EventHandler(this.dtnDenshowInsertDataCreate_Click);
            // 
            // btnDenshow
            // 
            this.btnDenshow.Location = new System.Drawing.Point(122, 38);
            this.btnDenshow.Name = "btnDenshow";
            this.btnDenshow.Size = new System.Drawing.Size(307, 25);
            this.btnDenshow.TabIndex = 10;
            this.btnDenshow.Text = "伝匠 データ入力シート作成";
            this.btnDenshow.UseVisualStyleBackColor = true;
            this.btnDenshow.Click += new System.EventHandler(this.btnDenshow_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.Worker_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Worker_RunWorkerCompleted);
            // 
            // openExcelDialog
            // 
            this.openExcelDialog.Filter = "Excelファイル(*.xls;*.xlsx,*.xlsm)|*.xls;*.xlsx;*.xlsm";
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 417);
            this.Controls.Add(this.mnuPanel);
            this.Controls.Add(this.ProgressPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MenuForm";
            this.Text = "伝匠データ作成ツール";
            this.Load += new System.EventHandler(this.MenuForm_Load);
            this.ProgressPanel.ResumeLayout(false);
            this.ProgressPanel.PerformLayout();
            this.mnuPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ProgressPanel;
        private System.Windows.Forms.Label lblParcentage;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Panel mnuPanel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.OpenFileDialog openExcelDialog;
        private System.Windows.Forms.Button btnDenshow;
        private System.Windows.Forms.Button dtnDenshowInsertDataCreate;
    }
}

