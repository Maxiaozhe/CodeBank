namespace RJ.Tools.NotesTransfer.UI.Forms
{
    partial class FormSelectDialog
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSelectDialog));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lsvFormList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.cmbTaskList = new System.Windows.Forms.ComboBox();
            this.btnOK = new RJ.Tools.NotesTransfer.UI.Component.StyleButton();
            this.btnCancel = new RJ.Tools.NotesTransfer.UI.Component.StyleButton();
            this.styleLabel5 = new RJ.Tools.NotesTransfer.UI.Component.StyleLabel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lsvFormList);
            this.panel1.Location = new System.Drawing.Point(11, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(438, 428);
            this.panel1.TabIndex = 0;
            // 
            // lsvFormList
            // 
            this.lsvFormList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lsvFormList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvFormList.FullRowSelect = true;
            this.lsvFormList.GridLines = true;
            this.lsvFormList.HideSelection = false;
            this.lsvFormList.Location = new System.Drawing.Point(0, 0);
            this.lsvFormList.Name = "lsvFormList";
            this.lsvFormList.Size = new System.Drawing.Size(438, 428);
            this.lsvFormList.SmallImageList = this.imageList1;
            this.lsvFormList.TabIndex = 15;
            this.lsvFormList.UseCompatibleStateImageBehavior = false;
            this.lsvFormList.View = System.Windows.Forms.View.Details;
            this.lsvFormList.SelectedIndexChanged += new System.EventHandler(this.lsvFormList_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "フォーム名";
            this.columnHeader1.Width = 210;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "別名";
            this.columnHeader2.Width = 205;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "defaultMark");
            this.imageList1.Images.SetKeyName(1, "empty");
            // 
            // cmbTaskList
            // 
            this.cmbTaskList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTaskList.FormattingEnabled = true;
            this.cmbTaskList.Location = new System.Drawing.Point(179, 11);
            this.cmbTaskList.Name = "cmbTaskList";
            this.cmbTaskList.Size = new System.Drawing.Size(270, 20);
            this.cmbTaskList.TabIndex = 13;
            this.cmbTaskList.SelectedIndexChanged += new System.EventHandler(this.cmbTaskList_SelectedIndexChanged);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.btnOK.CategoryName = null;
            this.btnOK.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(141)))), ((int)(((byte)(212)))));
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(250, 481);
            this.btnOK.Margin = new System.Windows.Forms.Padding(0);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(95, 31);
            this.btnOK.StyleName = "FormButton";
            this.btnOK.TabIndex = 15;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.btnCancel.CategoryName = null;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(141)))), ((int)(((byte)(212)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(354, 481);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 31);
            this.btnCancel.StyleName = "FormButton";
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "キャンセル";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // styleLabel5
            // 
            this.styleLabel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.styleLabel5.CategoryName = null;
            this.styleLabel5.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.styleLabel5.ForeColor = System.Drawing.Color.White;
            this.styleLabel5.Location = new System.Drawing.Point(12, 9);
            this.styleLabel5.Name = "styleLabel5";
            this.styleLabel5.Size = new System.Drawing.Size(161, 24);
            this.styleLabel5.StyleName = "Caption";
            this.styleLabel5.TabIndex = 12;
            this.styleLabel5.Text = "データベース設定";
            this.styleLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormSelectDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 521);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cmbTaskList);
            this.Controls.Add(this.styleLabel5);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSelectDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "対象フォームの選択";
            this.Load += new System.EventHandler(this.FormSelectDialog_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Component.StyleLabel styleLabel5;
        private System.Windows.Forms.ComboBox cmbTaskList;
        private Component.StyleButton btnOK;
        private Component.StyleButton btnCancel;
        private System.Windows.Forms.ListView lsvFormList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ImageList imageList1;
    }
}