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
            this.button3 = new System.Windows.Forms.Button();
            this.OperationDataCheckButton = new System.Windows.Forms.Button();
            this.LiveDBCreateButton = new System.Windows.Forms.Button();
            this.ProgressPanel = new System.Windows.Forms.Panel();
            this.lblParcentage = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.mnuPanel = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SeedInitDataCreateButton = new System.Windows.Forms.Button();
            this.LiveInitDataCreateButton = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.openExcelDialog = new System.Windows.Forms.OpenFileDialog();
            this.ProgressPanel.SuspendLayout();
            this.mnuPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(121, 252);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(307, 25);
            this.button3.TabIndex = 4;
            this.button3.Text = "生産計画・稼働データチェック";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.ProductionDataCheck_Click);
            // 
            // OperationDataCheckButton
            // 
            this.OperationDataCheckButton.Location = new System.Drawing.Point(121, 283);
            this.OperationDataCheckButton.Name = "OperationDataCheckButton";
            this.OperationDataCheckButton.Size = new System.Drawing.Size(307, 25);
            this.OperationDataCheckButton.TabIndex = 5;
            this.OperationDataCheckButton.Text = "設備計画・稼働データチェック";
            this.OperationDataCheckButton.UseVisualStyleBackColor = true;
            this.OperationDataCheckButton.Click += new System.EventHandler(this.OperationDataCheck_Click);
            // 
            // LiveDBCreateButton
            // 
            this.LiveDBCreateButton.Location = new System.Drawing.Point(121, 35);
            this.LiveDBCreateButton.Name = "LiveDBCreateButton";
            this.LiveDBCreateButton.Size = new System.Drawing.Size(307, 25);
            this.LiveDBCreateButton.TabIndex = 0;
            this.LiveDBCreateButton.Text = "データベース設計書からSQL スクリプト作成";
            this.LiveDBCreateButton.UseVisualStyleBackColor = true;
            this.LiveDBCreateButton.Click += new System.EventHandler(this.DatabaseCreateButton_Click);
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
            this.mnuPanel.Controls.Add(this.button5);
            this.mnuPanel.Controls.Add(this.button4);
            this.mnuPanel.Controls.Add(this.SeedInitDataCreateButton);
            this.mnuPanel.Controls.Add(this.LiveInitDataCreateButton);
            this.mnuPanel.Controls.Add(this.LiveDBCreateButton);
            this.mnuPanel.Controls.Add(this.OperationDataCheckButton);
            this.mnuPanel.Controls.Add(this.button3);
            this.mnuPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mnuPanel.Location = new System.Drawing.Point(0, 0);
            this.mnuPanel.Name = "mnuPanel";
            this.mnuPanel.Size = new System.Drawing.Size(578, 417);
            this.mnuPanel.TabIndex = 6;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(121, 200);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(307, 25);
            this.button5.TabIndex = 9;
            this.button5.Text = "データベース（LIVE） 初期化スクリプト作成";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.LiveInserSqlCreate_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(121, 169);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(307, 25);
            this.button4.TabIndex = 8;
            this.button4.Text = "データベース（SEED） 初期化スクリプト作成";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.SeedInserSqlCreate_Click);
            // 
            // SeedInitDataCreateButton
            // 
            this.SeedInitDataCreateButton.Location = new System.Drawing.Point(121, 85);
            this.SeedInitDataCreateButton.Name = "SeedInitDataCreateButton";
            this.SeedInitDataCreateButton.Size = new System.Drawing.Size(307, 25);
            this.SeedInitDataCreateButton.TabIndex = 6;
            this.SeedInitDataCreateButton.Text = "データベース（SEED）　データ入力シート作成";
            this.SeedInitDataCreateButton.UseVisualStyleBackColor = true;
            this.SeedInitDataCreateButton.Click += new System.EventHandler(this.SeedInitDataCreateButton_Click);
            // 
            // LiveInitDataCreateButton
            // 
            this.LiveInitDataCreateButton.Location = new System.Drawing.Point(121, 116);
            this.LiveInitDataCreateButton.Name = "LiveInitDataCreateButton";
            this.LiveInitDataCreateButton.Size = new System.Drawing.Size(307, 25);
            this.LiveInitDataCreateButton.TabIndex = 7;
            this.LiveInitDataCreateButton.Text = "データベース（LIVE）　データ入力シート作成";
            this.LiveInitDataCreateButton.UseVisualStyleBackColor = true;
            this.LiveInitDataCreateButton.Click += new System.EventHandler(this.LiveInitDataCreateButton_Click);
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
            this.Text = "データチェックツール";
            this.Load += new System.EventHandler(this.MenuForm_Load);
            this.ProgressPanel.ResumeLayout(false);
            this.ProgressPanel.PerformLayout();
            this.mnuPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button OperationDataCheckButton;
        private System.Windows.Forms.Button LiveDBCreateButton;
        private System.Windows.Forms.Panel ProgressPanel;
        private System.Windows.Forms.Label lblParcentage;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Panel mnuPanel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.OpenFileDialog openExcelDialog;
        private System.Windows.Forms.Button SeedInitDataCreateButton;
        private System.Windows.Forms.Button LiveInitDataCreateButton;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
    }
}

