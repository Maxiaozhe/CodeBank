namespace RJ.Tools.NotesTransfer.UI.Forms
{
    partial class ViewSelectDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewSelectDialog));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.cmbTaskList = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lsvViewList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnOK = new RJ.Tools.NotesTransfer.UI.Component.StyleButton();
            this.btnCancel = new RJ.Tools.NotesTransfer.UI.Component.StyleButton();
            this.styleLabel5 = new RJ.Tools.NotesTransfer.UI.Component.StyleLabel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            this.cmbTaskList.Location = new System.Drawing.Point(197, 15);
            this.cmbTaskList.Name = "cmbTaskList";
            this.cmbTaskList.Size = new System.Drawing.Size(270, 20);
            this.cmbTaskList.TabIndex = 18;
            this.cmbTaskList.SelectedIndexChanged += new System.EventHandler(this.cmbTaskList_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lsvViewList);
            this.panel1.Location = new System.Drawing.Point(29, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(438, 428);
            this.panel1.TabIndex = 16;
            // 
            // lsvViewList
            // 
            this.lsvViewList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lsvViewList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvViewList.FullRowSelect = true;
            this.lsvViewList.GridLines = true;
            this.lsvViewList.HideSelection = false;
            this.lsvViewList.Location = new System.Drawing.Point(0, 0);
            this.lsvViewList.Name = "lsvViewList";
            this.lsvViewList.Size = new System.Drawing.Size(438, 428);
            this.lsvViewList.SmallImageList = this.imageList1;
            this.lsvViewList.TabIndex = 15;
            this.lsvViewList.UseCompatibleStateImageBehavior = false;
            this.lsvViewList.View = System.Windows.Forms.View.Details;
            this.lsvViewList.SelectedIndexChanged += new System.EventHandler(this.lsvViewList_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ビュー名";
            this.columnHeader1.Width = 210;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "別名";
            this.columnHeader2.Width = 205;
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
            this.btnOK.Location = new System.Drawing.Point(268, 483);
            this.btnOK.Margin = new System.Windows.Forms.Padding(0);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(95, 31);
            this.btnOK.StyleName = "FormButton";
            this.btnOK.TabIndex = 20;
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
            this.btnCancel.Location = new System.Drawing.Point(372, 483);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 31);
            this.btnCancel.StyleName = "FormButton";
            this.btnCancel.TabIndex = 19;
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
            this.styleLabel5.Location = new System.Drawing.Point(30, 11);
            this.styleLabel5.Name = "styleLabel5";
            this.styleLabel5.Size = new System.Drawing.Size(161, 24);
            this.styleLabel5.StyleName = "Caption";
            this.styleLabel5.TabIndex = 17;
            this.styleLabel5.Text = "移行対象データベース";
            this.styleLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ViewSelectDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 524);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cmbTaskList);
            this.Controls.Add(this.styleLabel5);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ViewSelectDialog";
            this.Text = "対象ビューの選択";
            this.Load += new System.EventHandler(this.ViewSelectDialog_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Component.StyleButton btnOK;
        private Component.StyleButton btnCancel;
        private System.Windows.Forms.ComboBox cmbTaskList;
        private Component.StyleLabel styleLabel5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView lsvViewList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ImageList imageList1;
    }
}