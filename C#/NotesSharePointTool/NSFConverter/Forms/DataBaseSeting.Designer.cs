using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ.Tools.NotesTransfer.UI.Forms
{
    partial class DataBaseSeting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataBaseSeting));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.rdoNotDefIcon = new System.Windows.Forms.RadioButton();
            this.rdoDefaultIcon = new System.Windows.Forms.RadioButton();
            this.styleLabel6 = new RJ.Tools.NotesTransfer.UI.Component.StyleLabel();
            this.txtDescription = new RJ.Tools.NotesTransfer.UI.Component.StyleTextBox();
            this.styleLabel2 = new RJ.Tools.NotesTransfer.UI.Component.StyleLabel();
            this.txtDisplayName = new RJ.Tools.NotesTransfer.UI.Component.StyleTextBox();
            this.styleLabel4 = new RJ.Tools.NotesTransfer.UI.Component.StyleLabel();
            this.txtListName = new RJ.Tools.NotesTransfer.UI.Component.StyleTextBox();
            this.lblTitle = new RJ.Tools.NotesTransfer.UI.Component.StyleLabel();
            this.txtWebSite = new RJ.Tools.NotesTransfer.UI.Component.StyleTextBox();
            this.styleLabel18 = new RJ.Tools.NotesTransfer.UI.Component.StyleLabel();
            this.lblConvertDate = new RJ.Tools.NotesTransfer.UI.Component.StyleLabel();
            this.styleLabel16 = new RJ.Tools.NotesTransfer.UI.Component.StyleLabel();
            this.cmbSPType = new System.Windows.Forms.ComboBox();
            this.styleLabel11 = new RJ.Tools.NotesTransfer.UI.Component.StyleLabel();
            this.lblStatus = new RJ.Tools.NotesTransfer.UI.Component.StyleLabel();
            this.styleLabel9 = new RJ.Tools.NotesTransfer.UI.Component.StyleLabel();
            this.txtTaskName = new RJ.Tools.NotesTransfer.UI.Component.StyleTextBox();
            this.styleLabel7 = new RJ.Tools.NotesTransfer.UI.Component.StyleLabel();
            this.txtFileName = new RJ.Tools.NotesTransfer.UI.Component.StyleLabel();
            this.styleLabel3 = new RJ.Tools.NotesTransfer.UI.Component.StyleLabel();
            this.txtServer = new RJ.Tools.NotesTransfer.UI.Component.StyleLabel();
            this.styleLabel1 = new RJ.Tools.NotesTransfer.UI.Component.StyleLabel();
            this.btnSelectDb = new RJ.Tools.NotesTransfer.UI.Component.StyleButton();
            this.styleLabel5 = new RJ.Tools.NotesTransfer.UI.Component.StyleLabel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.styleLabel12 = new RJ.Tools.NotesTransfer.UI.Component.StyleLabel();
            this.styleLabel13 = new RJ.Tools.NotesTransfer.UI.Component.StyleLabel();
            this.styleButton4 = new RJ.Tools.NotesTransfer.UI.Component.StyleButton();
            this.styleButton5 = new RJ.Tools.NotesTransfer.UI.Component.StyleButton();
            this.listFormTarget = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listForm = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.styleLabel14 = new RJ.Tools.NotesTransfer.UI.Component.StyleLabel();
            this.styleLabel15 = new RJ.Tools.NotesTransfer.UI.Component.StyleLabel();
            this.styleButton6 = new RJ.Tools.NotesTransfer.UI.Component.StyleButton();
            this.styleButton7 = new RJ.Tools.NotesTransfer.UI.Component.StyleButton();
            this.listViewTarget = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSave = new RJ.Tools.NotesTransfer.UI.Component.StyleButton();
            this.button3 = new RJ.Tools.NotesTransfer.UI.Component.StyleButton();
            this.tabMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "defaultMark");
            this.imageList1.Images.SetKeyName(1, "empty");
            // 
            // tabMain
            // 
            this.tabMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMain.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabMain.Controls.Add(this.tabPage1);
            this.tabMain.Controls.Add(this.tabPage2);
            this.tabMain.Controls.Add(this.tabPage3);
            this.tabMain.HotTrack = true;
            this.tabMain.Location = new System.Drawing.Point(8, 12);
            this.tabMain.Multiline = true;
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(759, 500);
            this.tabMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabMain.TabIndex = 29;
            // 
            // tabPage1
            // 
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage1.Controls.Add(this.rdoNotDefIcon);
            this.tabPage1.Controls.Add(this.rdoDefaultIcon);
            this.tabPage1.Controls.Add(this.styleLabel6);
            this.tabPage1.Controls.Add(this.txtDescription);
            this.tabPage1.Controls.Add(this.styleLabel2);
            this.tabPage1.Controls.Add(this.txtDisplayName);
            this.tabPage1.Controls.Add(this.styleLabel4);
            this.tabPage1.Controls.Add(this.txtListName);
            this.tabPage1.Controls.Add(this.lblTitle);
            this.tabPage1.Controls.Add(this.txtWebSite);
            this.tabPage1.Controls.Add(this.styleLabel18);
            this.tabPage1.Controls.Add(this.lblConvertDate);
            this.tabPage1.Controls.Add(this.styleLabel16);
            this.tabPage1.Controls.Add(this.cmbSPType);
            this.tabPage1.Controls.Add(this.styleLabel11);
            this.tabPage1.Controls.Add(this.lblStatus);
            this.tabPage1.Controls.Add(this.styleLabel9);
            this.tabPage1.Controls.Add(this.txtTaskName);
            this.tabPage1.Controls.Add(this.styleLabel7);
            this.tabPage1.Controls.Add(this.txtFileName);
            this.tabPage1.Controls.Add(this.styleLabel3);
            this.tabPage1.Controls.Add(this.txtServer);
            this.tabPage1.Controls.Add(this.styleLabel1);
            this.tabPage1.Controls.Add(this.btnSelectDb);
            this.tabPage1.Controls.Add(this.styleLabel5);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(751, 471);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "データベース";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // rdoNotDefIcon
            // 
            this.rdoNotDefIcon.AutoSize = true;
            this.rdoNotDefIcon.Location = new System.Drawing.Point(219, 316);
            this.rdoNotDefIcon.Name = "rdoNotDefIcon";
            this.rdoNotDefIcon.Size = new System.Drawing.Size(52, 16);
            this.rdoNotDefIcon.TabIndex = 71;
            this.rdoNotDefIcon.TabStop = true;
            this.rdoNotDefIcon.Text = "しない";
            this.rdoNotDefIcon.UseVisualStyleBackColor = true;
            // 
            // rdoDefaultIcon
            // 
            this.rdoDefaultIcon.AutoSize = true;
            this.rdoDefaultIcon.Location = new System.Drawing.Point(171, 316);
            this.rdoDefaultIcon.Name = "rdoDefaultIcon";
            this.rdoDefaultIcon.Size = new System.Drawing.Size(42, 16);
            this.rdoDefaultIcon.TabIndex = 70;
            this.rdoDefaultIcon.TabStop = true;
            this.rdoDefaultIcon.Text = "する";
            this.rdoDefaultIcon.UseVisualStyleBackColor = true;
            // 
            // styleLabel6
            // 
            this.styleLabel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.styleLabel6.CategoryName = null;
            this.styleLabel6.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.styleLabel6.ForeColor = System.Drawing.Color.White;
            this.styleLabel6.Location = new System.Drawing.Point(15, 312);
            this.styleLabel6.Name = "styleLabel6";
            this.styleLabel6.Size = new System.Drawing.Size(148, 24);
            this.styleLabel6.StyleName = "Caption";
            this.styleLabel6.TabIndex = 69;
            this.styleLabel6.Text = "既定のアイコンの使用";
            this.styleLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDescription
            // 
            this.txtDescription.CategoryName = null;
            this.txtDescription.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtDescription.Location = new System.Drawing.Point(169, 214);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(261, 21);
            this.txtDescription.StyleName = "TextInput";
            this.txtDescription.TabIndex = 68;
            // 
            // styleLabel2
            // 
            this.styleLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.styleLabel2.CategoryName = null;
            this.styleLabel2.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.styleLabel2.ForeColor = System.Drawing.Color.White;
            this.styleLabel2.Location = new System.Drawing.Point(15, 214);
            this.styleLabel2.Name = "styleLabel2";
            this.styleLabel2.Size = new System.Drawing.Size(148, 24);
            this.styleLabel2.StyleName = "Caption";
            this.styleLabel2.TabIndex = 67;
            this.styleLabel2.Text = "説明";
            this.styleLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDisplayName
            // 
            this.txtDisplayName.CategoryName = null;
            this.txtDisplayName.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtDisplayName.Location = new System.Drawing.Point(169, 185);
            this.txtDisplayName.Name = "txtDisplayName";
            this.txtDisplayName.Size = new System.Drawing.Size(261, 21);
            this.txtDisplayName.StyleName = "TextInput";
            this.txtDisplayName.TabIndex = 66;
            // 
            // styleLabel4
            // 
            this.styleLabel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.styleLabel4.CategoryName = null;
            this.styleLabel4.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.styleLabel4.ForeColor = System.Drawing.Color.White;
            this.styleLabel4.Location = new System.Drawing.Point(15, 185);
            this.styleLabel4.Name = "styleLabel4";
            this.styleLabel4.Size = new System.Drawing.Size(148, 24);
            this.styleLabel4.StyleName = "Caption";
            this.styleLabel4.TabIndex = 65;
            this.styleLabel4.Text = "タイトル";
            this.styleLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtListName
            // 
            this.txtListName.CategoryName = null;
            this.txtListName.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtListName.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtListName.Location = new System.Drawing.Point(169, 153);
            this.txtListName.Name = "txtListName";
            this.txtListName.Size = new System.Drawing.Size(261, 21);
            this.txtListName.StyleName = "TextInput";
            this.txtListName.TabIndex = 64;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.lblTitle.CategoryName = null;
            this.lblTitle.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(15, 153);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(148, 24);
            this.lblTitle.StyleName = "Caption";
            this.lblTitle.TabIndex = 63;
            this.lblTitle.Text = "リスト名(半角英数)";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtWebSite
            // 
            this.txtWebSite.CategoryName = null;
            this.txtWebSite.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtWebSite.Location = new System.Drawing.Point(169, 275);
            this.txtWebSite.Name = "txtWebSite";
            this.txtWebSite.Size = new System.Drawing.Size(261, 21);
            this.txtWebSite.StyleName = "TextInput";
            this.txtWebSite.TabIndex = 62;
            // 
            // styleLabel18
            // 
            this.styleLabel18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.styleLabel18.CategoryName = null;
            this.styleLabel18.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.styleLabel18.ForeColor = System.Drawing.Color.White;
            this.styleLabel18.Location = new System.Drawing.Point(15, 275);
            this.styleLabel18.Name = "styleLabel18";
            this.styleLabel18.Size = new System.Drawing.Size(148, 24);
            this.styleLabel18.StyleName = "Caption";
            this.styleLabel18.TabIndex = 61;
            this.styleLabel18.Text = "移行先Webサイト";
            this.styleLabel18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblConvertDate
            // 
            this.lblConvertDate.BackColor = System.Drawing.Color.White;
            this.lblConvertDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblConvertDate.CategoryName = null;
            this.lblConvertDate.Location = new System.Drawing.Point(169, 382);
            this.lblConvertDate.Name = "lblConvertDate";
            this.lblConvertDate.Size = new System.Drawing.Size(171, 24);
            this.lblConvertDate.StyleName = "TextDisplay";
            this.lblConvertDate.TabIndex = 60;
            this.lblConvertDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // styleLabel16
            // 
            this.styleLabel16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.styleLabel16.CategoryName = null;
            this.styleLabel16.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.styleLabel16.ForeColor = System.Drawing.Color.White;
            this.styleLabel16.Location = new System.Drawing.Point(15, 382);
            this.styleLabel16.Name = "styleLabel16";
            this.styleLabel16.Size = new System.Drawing.Size(148, 24);
            this.styleLabel16.StyleName = "Caption";
            this.styleLabel16.TabIndex = 59;
            this.styleLabel16.Text = "最終変換日";
            this.styleLabel16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbSPType
            // 
            this.cmbSPType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSPType.FormattingEnabled = true;
            this.cmbSPType.Items.AddRange(new object[] {
            "基本リスト",
            "ドキュメントライブラリ",
            "連絡先",
            "ディスカッションボード"});
            this.cmbSPType.Location = new System.Drawing.Point(169, 245);
            this.cmbSPType.MaxDropDownItems = 10;
            this.cmbSPType.Name = "cmbSPType";
            this.cmbSPType.Size = new System.Drawing.Size(261, 20);
            this.cmbSPType.TabIndex = 57;
            // 
            // styleLabel11
            // 
            this.styleLabel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.styleLabel11.CategoryName = null;
            this.styleLabel11.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.styleLabel11.ForeColor = System.Drawing.Color.White;
            this.styleLabel11.Location = new System.Drawing.Point(15, 243);
            this.styleLabel11.Name = "styleLabel11";
            this.styleLabel11.Size = new System.Drawing.Size(148, 24);
            this.styleLabel11.StyleName = "Caption";
            this.styleLabel11.TabIndex = 56;
            this.styleLabel11.Text = "移行先種別";
            this.styleLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.White;
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatus.CategoryName = null;
            this.lblStatus.Location = new System.Drawing.Point(169, 347);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(171, 24);
            this.lblStatus.StyleName = "TextDisplay";
            this.lblStatus.TabIndex = 55;
            this.lblStatus.Text = "未変換";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // styleLabel9
            // 
            this.styleLabel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.styleLabel9.CategoryName = null;
            this.styleLabel9.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.styleLabel9.ForeColor = System.Drawing.Color.White;
            this.styleLabel9.Location = new System.Drawing.Point(15, 347);
            this.styleLabel9.Name = "styleLabel9";
            this.styleLabel9.Size = new System.Drawing.Size(148, 24);
            this.styleLabel9.StyleName = "Caption";
            this.styleLabel9.TabIndex = 54;
            this.styleLabel9.Text = "変換状態";
            this.styleLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTaskName
            // 
            this.txtTaskName.CategoryName = null;
            this.txtTaskName.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtTaskName.Location = new System.Drawing.Point(169, 17);
            this.txtTaskName.Name = "txtTaskName";
            this.txtTaskName.Size = new System.Drawing.Size(261, 21);
            this.txtTaskName.StyleName = "TextInput";
            this.txtTaskName.TabIndex = 52;
            // 
            // styleLabel7
            // 
            this.styleLabel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.styleLabel7.CategoryName = null;
            this.styleLabel7.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.styleLabel7.ForeColor = System.Drawing.Color.White;
            this.styleLabel7.Location = new System.Drawing.Point(15, 15);
            this.styleLabel7.Name = "styleLabel7";
            this.styleLabel7.Size = new System.Drawing.Size(148, 24);
            this.styleLabel7.StyleName = "Caption";
            this.styleLabel7.TabIndex = 51;
            this.styleLabel7.Text = "変換名";
            this.styleLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFileName
            // 
            this.txtFileName.CategoryName = null;
            this.txtFileName.Location = new System.Drawing.Point(169, 120);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(574, 24);
            this.txtFileName.StyleName = "TextDisplay";
            this.txtFileName.TabIndex = 49;
            this.txtFileName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // styleLabel3
            // 
            this.styleLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.styleLabel3.CategoryName = null;
            this.styleLabel3.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.styleLabel3.ForeColor = System.Drawing.Color.White;
            this.styleLabel3.Location = new System.Drawing.Point(15, 120);
            this.styleLabel3.Name = "styleLabel3";
            this.styleLabel3.Size = new System.Drawing.Size(148, 24);
            this.styleLabel3.StyleName = "Caption";
            this.styleLabel3.TabIndex = 48;
            this.styleLabel3.Text = "ファイル名";
            this.styleLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtServer
            // 
            this.txtServer.CategoryName = null;
            this.txtServer.Location = new System.Drawing.Point(169, 85);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(261, 24);
            this.txtServer.StyleName = "TextDisplay";
            this.txtServer.TabIndex = 47;
            this.txtServer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // styleLabel1
            // 
            this.styleLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.styleLabel1.CategoryName = null;
            this.styleLabel1.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.styleLabel1.ForeColor = System.Drawing.Color.White;
            this.styleLabel1.Location = new System.Drawing.Point(15, 85);
            this.styleLabel1.Name = "styleLabel1";
            this.styleLabel1.Size = new System.Drawing.Size(148, 24);
            this.styleLabel1.StyleName = "Caption";
            this.styleLabel1.TabIndex = 46;
            this.styleLabel1.Text = "サーバー名";
            this.styleLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSelectDb
            // 
            this.btnSelectDb.CategoryName = null;
            this.btnSelectDb.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnSelectDb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectDb.Location = new System.Drawing.Point(169, 50);
            this.btnSelectDb.Margin = new System.Windows.Forms.Padding(0);
            this.btnSelectDb.Name = "btnSelectDb";
            this.btnSelectDb.Size = new System.Drawing.Size(69, 24);
            this.btnSelectDb.StyleName = "ActionButton";
            this.btnSelectDb.TabIndex = 45;
            this.btnSelectDb.Text = "選択";
            this.btnSelectDb.UseVisualStyleBackColor = false;
            this.btnSelectDb.Click += new System.EventHandler(this.SelectDb_Click);
            // 
            // styleLabel5
            // 
            this.styleLabel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.styleLabel5.CategoryName = null;
            this.styleLabel5.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.styleLabel5.ForeColor = System.Drawing.Color.White;
            this.styleLabel5.Location = new System.Drawing.Point(15, 50);
            this.styleLabel5.Name = "styleLabel5";
            this.styleLabel5.Size = new System.Drawing.Size(148, 24);
            this.styleLabel5.StyleName = "Caption";
            this.styleLabel5.TabIndex = 44;
            this.styleLabel5.Text = "変換対象";
            this.styleLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage2
            // 
            this.tabPage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage2.Controls.Add(this.styleLabel12);
            this.tabPage2.Controls.Add(this.styleLabel13);
            this.tabPage2.Controls.Add(this.styleButton4);
            this.tabPage2.Controls.Add(this.styleButton5);
            this.tabPage2.Controls.Add(this.listFormTarget);
            this.tabPage2.Controls.Add(this.listForm);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(751, 471);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "対象フォーム";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // styleLabel12
            // 
            this.styleLabel12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.styleLabel12.CategoryName = null;
            this.styleLabel12.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.styleLabel12.ForeColor = System.Drawing.Color.White;
            this.styleLabel12.Location = new System.Drawing.Point(414, 20);
            this.styleLabel12.Name = "styleLabel12";
            this.styleLabel12.Size = new System.Drawing.Size(311, 24);
            this.styleLabel12.StyleName = "Caption";
            this.styleLabel12.TabIndex = 19;
            this.styleLabel12.Text = "移行対象フォーム一覧";
            this.styleLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // styleLabel13
            // 
            this.styleLabel13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.styleLabel13.CategoryName = null;
            this.styleLabel13.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.styleLabel13.ForeColor = System.Drawing.Color.White;
            this.styleLabel13.Location = new System.Drawing.Point(20, 20);
            this.styleLabel13.Name = "styleLabel13";
            this.styleLabel13.Size = new System.Drawing.Size(311, 24);
            this.styleLabel13.StyleName = "Caption";
            this.styleLabel13.TabIndex = 18;
            this.styleLabel13.Text = "フォーム一覧";
            this.styleLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // styleButton4
            // 
            this.styleButton4.CategoryName = null;
            this.styleButton4.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.styleButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.styleButton4.Location = new System.Drawing.Point(336, 242);
            this.styleButton4.Margin = new System.Windows.Forms.Padding(0);
            this.styleButton4.Name = "styleButton4";
            this.styleButton4.Size = new System.Drawing.Size(69, 24);
            this.styleButton4.StyleName = "ActionButton";
            this.styleButton4.TabIndex = 17;
            this.styleButton4.Text = "< 削除";
            this.styleButton4.UseVisualStyleBackColor = false;
            this.styleButton4.Click += new System.EventHandler(this.RemoveForm_Click);
            // 
            // styleButton5
            // 
            this.styleButton5.CategoryName = null;
            this.styleButton5.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.styleButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.styleButton5.Location = new System.Drawing.Point(336, 202);
            this.styleButton5.Margin = new System.Windows.Forms.Padding(0);
            this.styleButton5.Name = "styleButton5";
            this.styleButton5.Size = new System.Drawing.Size(69, 24);
            this.styleButton5.StyleName = "ActionButton";
            this.styleButton5.TabIndex = 16;
            this.styleButton5.Text = "追加　>";
            this.styleButton5.UseVisualStyleBackColor = false;
            this.styleButton5.Click += new System.EventHandler(this.AddForm_Click);
            // 
            // listFormTarget
            // 
            this.listFormTarget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listFormTarget.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.listFormTarget.FullRowSelect = true;
            this.listFormTarget.GridLines = true;
            this.listFormTarget.HideSelection = false;
            this.listFormTarget.Location = new System.Drawing.Point(414, 46);
            this.listFormTarget.Name = "listFormTarget";
            this.listFormTarget.Size = new System.Drawing.Size(311, 405);
            this.listFormTarget.SmallImageList = this.imageList1;
            this.listFormTarget.TabIndex = 15;
            this.listFormTarget.UseCompatibleStateImageBehavior = false;
            this.listFormTarget.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "フォーム名";
            this.columnHeader3.Width = 159;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "別名";
            this.columnHeader4.Width = 148;
            // 
            // listForm
            // 
            this.listForm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listForm.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listForm.FullRowSelect = true;
            this.listForm.GridLines = true;
            this.listForm.HideSelection = false;
            this.listForm.Location = new System.Drawing.Point(20, 46);
            this.listForm.Name = "listForm";
            this.listForm.Size = new System.Drawing.Size(311, 405);
            this.listForm.SmallImageList = this.imageList1;
            this.listForm.TabIndex = 14;
            this.listForm.UseCompatibleStateImageBehavior = false;
            this.listForm.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "フォーム名";
            this.columnHeader1.Width = 159;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "別名";
            this.columnHeader2.Width = 148;
            // 
            // tabPage3
            // 
            this.tabPage3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage3.Controls.Add(this.styleLabel14);
            this.tabPage3.Controls.Add(this.styleLabel15);
            this.tabPage3.Controls.Add(this.styleButton6);
            this.tabPage3.Controls.Add(this.styleButton7);
            this.tabPage3.Controls.Add(this.listViewTarget);
            this.tabPage3.Controls.Add(this.listView);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(751, 471);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "対象ビュー";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // styleLabel14
            // 
            this.styleLabel14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.styleLabel14.CategoryName = null;
            this.styleLabel14.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.styleLabel14.ForeColor = System.Drawing.Color.White;
            this.styleLabel14.Location = new System.Drawing.Point(419, 20);
            this.styleLabel14.Name = "styleLabel14";
            this.styleLabel14.Size = new System.Drawing.Size(311, 24);
            this.styleLabel14.StyleName = "Caption";
            this.styleLabel14.TabIndex = 25;
            this.styleLabel14.Text = "移行対象ビュー一覧";
            this.styleLabel14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // styleLabel15
            // 
            this.styleLabel15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.styleLabel15.CategoryName = null;
            this.styleLabel15.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.styleLabel15.ForeColor = System.Drawing.Color.White;
            this.styleLabel15.Location = new System.Drawing.Point(20, 20);
            this.styleLabel15.Name = "styleLabel15";
            this.styleLabel15.Size = new System.Drawing.Size(311, 24);
            this.styleLabel15.StyleName = "Caption";
            this.styleLabel15.TabIndex = 24;
            this.styleLabel15.Text = "ビュー一覧";
            this.styleLabel15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // styleButton6
            // 
            this.styleButton6.CategoryName = null;
            this.styleButton6.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.styleButton6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.styleButton6.Location = new System.Drawing.Point(341, 242);
            this.styleButton6.Margin = new System.Windows.Forms.Padding(0);
            this.styleButton6.Name = "styleButton6";
            this.styleButton6.Size = new System.Drawing.Size(69, 24);
            this.styleButton6.StyleName = "ActionButton";
            this.styleButton6.TabIndex = 23;
            this.styleButton6.Text = "< 削除";
            this.styleButton6.UseVisualStyleBackColor = false;
            this.styleButton6.Click += new System.EventHandler(this.RemoveView_Click);
            // 
            // styleButton7
            // 
            this.styleButton7.CategoryName = null;
            this.styleButton7.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.styleButton7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.styleButton7.Location = new System.Drawing.Point(341, 202);
            this.styleButton7.Margin = new System.Windows.Forms.Padding(0);
            this.styleButton7.Name = "styleButton7";
            this.styleButton7.Size = new System.Drawing.Size(69, 24);
            this.styleButton7.StyleName = "ActionButton";
            this.styleButton7.TabIndex = 22;
            this.styleButton7.Text = "追加　>";
            this.styleButton7.UseVisualStyleBackColor = false;
            this.styleButton7.Click += new System.EventHandler(this.AddView_Click);
            // 
            // listViewTarget
            // 
            this.listViewTarget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listViewTarget.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6});
            this.listViewTarget.FullRowSelect = true;
            this.listViewTarget.GridLines = true;
            this.listViewTarget.HideSelection = false;
            this.listViewTarget.Location = new System.Drawing.Point(419, 46);
            this.listViewTarget.Name = "listViewTarget";
            this.listViewTarget.Size = new System.Drawing.Size(311, 405);
            this.listViewTarget.SmallImageList = this.imageList1;
            this.listViewTarget.TabIndex = 21;
            this.listViewTarget.UseCompatibleStateImageBehavior = false;
            this.listViewTarget.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "ビュー名";
            this.columnHeader5.Width = 159;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "別名";
            this.columnHeader6.Width = 148;
            // 
            // listView
            // 
            this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8});
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(20, 46);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(311, 405);
            this.listView.SmallImageList = this.imageList1;
            this.listView.TabIndex = 20;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "ビュー名";
            this.columnHeader7.Width = 159;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "別名";
            this.columnHeader8.Width = 148;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.btnSave.CategoryName = null;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(141)))), ((int)(((byte)(212)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(564, 515);
            this.btnSave.Margin = new System.Windows.Forms.Padding(0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 31);
            this.btnSave.StyleName = "FormButton";
            this.btnSave.TabIndex = 26;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            this.button3.Location = new System.Drawing.Point(668, 515);
            this.button3.Margin = new System.Windows.Forms.Padding(0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(95, 31);
            this.button3.StyleName = "FormButton";
            this.button3.TabIndex = 25;
            this.button3.Text = "閉じる";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // DataBaseSeting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(779, 555);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.button3);
            this.Name = "DataBaseSeting";
            this.StyleName = "Form";
            this.Text = "データベース変換設定";
            this.Load += new System.EventHandler(this.DataBaseSeting_Load);
            this.tabMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private Component.StyleButton btnSave;
        private Component.StyleButton button3;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox cmbSPType;
        private Component.StyleLabel styleLabel11;
        private Component.StyleLabel lblStatus;
        private Component.StyleLabel styleLabel9;
        private Component.StyleTextBox txtTaskName;
        private Component.StyleLabel styleLabel7;
        private Component.StyleLabel txtFileName;
        private Component.StyleLabel styleLabel3;
        private Component.StyleLabel txtServer;
        private Component.StyleLabel styleLabel1;
        private Component.StyleButton btnSelectDb;
        private Component.StyleLabel styleLabel5;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private Component.StyleLabel styleLabel12;
        private Component.StyleLabel styleLabel13;
        private Component.StyleButton styleButton4;
        private Component.StyleButton styleButton5;
        private System.Windows.Forms.ListView listFormTarget;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ListView listForm;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private Component.StyleLabel styleLabel14;
        private Component.StyleLabel styleLabel15;
        private Component.StyleButton styleButton6;
        private Component.StyleButton styleButton7;
        private System.Windows.Forms.ListView listViewTarget;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private Component.StyleLabel styleLabel16;
        private Component.StyleLabel lblConvertDate;
        private Component.StyleTextBox txtWebSite;
        private Component.StyleLabel styleLabel18;
        private Component.StyleTextBox txtDescription;
        private Component.StyleLabel styleLabel2;
        private Component.StyleTextBox txtDisplayName;
        private Component.StyleLabel styleLabel4;
        private Component.StyleTextBox txtListName;
        private Component.StyleLabel lblTitle;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.RadioButton rdoNotDefIcon;
        private System.Windows.Forms.RadioButton rdoDefaultIcon;
        private Component.StyleLabel styleLabel6;
    }
}
