namespace RJ.Tools.NotesTransfer.UI.Forms
{
    partial class EnvSettingForm
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
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.btnSave = new RJ.Tools.NotesTransfer.UI.Component.StyleButton();
            this.btnClose = new RJ.Tools.NotesTransfer.UI.Component.StyleButton();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabNotes = new System.Windows.Forms.TabPage();
            this.lblUserId = new RJ.Tools.NotesTransfer.UI.Component.StyleLabel();
            this.txtOutputFolder = new RJ.Tools.NotesTransfer.UI.Component.StyleTextBox();
            this.btnOpenFolder = new RJ.Tools.NotesTransfer.UI.Component.StyleButton();
            this.styleLabel12 = new RJ.Tools.NotesTransfer.UI.Component.StyleLabel();
            this.lblUserName = new System.Windows.Forms.Label();
            this.styleLabel5 = new RJ.Tools.NotesTransfer.UI.Component.StyleLabel();
            this.btnTryAccessNotes = new RJ.Tools.NotesTransfer.UI.Component.StyleButton();
            this.txtNotesPassword = new RJ.Tools.NotesTransfer.UI.Component.StyleTextBox();
            this.styleLabel1 = new RJ.Tools.NotesTransfer.UI.Component.StyleLabel();
            this.tabSharePoint = new System.Windows.Forms.TabPage();
            this.btnTryAccessSP = new RJ.Tools.NotesTransfer.UI.Component.StyleButton();
            this.txtSPUser = new RJ.Tools.NotesTransfer.UI.Component.StyleTextBox();
            this.txtSPPassword = new RJ.Tools.NotesTransfer.UI.Component.StyleTextBox();
            this.styleLabel4 = new RJ.Tools.NotesTransfer.UI.Component.StyleLabel();
            this.styleLabel3 = new RJ.Tools.NotesTransfer.UI.Component.StyleLabel();
            this.txtSPWebSite = new RJ.Tools.NotesTransfer.UI.Component.StyleTextBox();
            this.styleLabel2 = new RJ.Tools.NotesTransfer.UI.Component.StyleLabel();
            this.tabDataBase = new System.Windows.Forms.TabPage();
            this.btnTryAccessDB = new RJ.Tools.NotesTransfer.UI.Component.StyleButton();
            this.cmbDataBase = new System.Windows.Forms.ComboBox();
            this.styleLabel10 = new RJ.Tools.NotesTransfer.UI.Component.StyleLabel();
            this.txtDbUserId = new RJ.Tools.NotesTransfer.UI.Component.StyleTextBox();
            this.txtDBPassword = new RJ.Tools.NotesTransfer.UI.Component.StyleTextBox();
            this.styleLabel9 = new RJ.Tools.NotesTransfer.UI.Component.StyleLabel();
            this.cmbAuthMode = new System.Windows.Forms.ComboBox();
            this.styleLabel8 = new RJ.Tools.NotesTransfer.UI.Component.StyleLabel();
            this.styleLabel7 = new RJ.Tools.NotesTransfer.UI.Component.StyleLabel();
            this.txtSqlServer = new RJ.Tools.NotesTransfer.UI.Component.StyleTextBox();
            this.styleLabel6 = new RJ.Tools.NotesTransfer.UI.Component.StyleLabel();
            this.tabMain.SuspendLayout();
            this.tabNotes.SuspendLayout();
            this.tabSharePoint.SuspendLayout();
            this.tabDataBase.SuspendLayout();
            this.SuspendLayout();
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
            this.btnSave.Location = new System.Drawing.Point(557, 496);
            this.btnSave.Margin = new System.Windows.Forms.Padding(0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 31);
            this.btnSave.StyleName = "FormButton";
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.SaveButton_Click);
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
            this.btnClose.Location = new System.Drawing.Point(661, 496);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(95, 31);
            this.btnClose.StyleName = "FormButton";
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "閉じる";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tabMain
            // 
            this.tabMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMain.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabMain.Controls.Add(this.tabNotes);
            this.tabMain.Controls.Add(this.tabSharePoint);
            this.tabMain.Controls.Add(this.tabDataBase);
            this.tabMain.HotTrack = true;
            this.tabMain.Location = new System.Drawing.Point(12, 12);
            this.tabMain.Multiline = true;
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(748, 481);
            this.tabMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabMain.TabIndex = 1;
            // 
            // tabNotes
            // 
            this.tabNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabNotes.Controls.Add(this.lblUserId);
            this.tabNotes.Controls.Add(this.txtOutputFolder);
            this.tabNotes.Controls.Add(this.btnOpenFolder);
            this.tabNotes.Controls.Add(this.styleLabel12);
            this.tabNotes.Controls.Add(this.lblUserName);
            this.tabNotes.Controls.Add(this.styleLabel5);
            this.tabNotes.Controls.Add(this.btnTryAccessNotes);
            this.tabNotes.Controls.Add(this.txtNotesPassword);
            this.tabNotes.Controls.Add(this.styleLabel1);
            this.tabNotes.Location = new System.Drawing.Point(4, 25);
            this.tabNotes.Name = "tabNotes";
            this.tabNotes.Padding = new System.Windows.Forms.Padding(3);
            this.tabNotes.Size = new System.Drawing.Size(740, 452);
            this.tabNotes.TabIndex = 0;
            this.tabNotes.Text = "ノーツ設定";
            this.tabNotes.UseVisualStyleBackColor = true;
            // 
            // lblUserId
            // 
            this.lblUserId.CategoryName = null;
            this.lblUserId.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblUserId.Location = new System.Drawing.Point(174, 22);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(283, 21);
            this.lblUserId.StyleName = "TextDisplay";
            this.lblUserId.TabIndex = 66;
            this.lblUserId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtOutputFolder
            // 
            this.txtOutputFolder.CategoryName = null;
            this.txtOutputFolder.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtOutputFolder.Location = new System.Drawing.Point(174, 92);
            this.txtOutputFolder.Name = "txtOutputFolder";
            this.txtOutputFolder.Size = new System.Drawing.Size(359, 21);
            this.txtOutputFolder.StyleName = "TextInput";
            this.txtOutputFolder.TabIndex = 65;
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.CategoryName = null;
            this.btnOpenFolder.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnOpenFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenFolder.Location = new System.Drawing.Point(538, 90);
            this.btnOpenFolder.Margin = new System.Windows.Forms.Padding(0);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(69, 24);
            this.btnOpenFolder.StyleName = "ActionButton";
            this.btnOpenFolder.TabIndex = 64;
            this.btnOpenFolder.Text = "選択";
            this.btnOpenFolder.UseVisualStyleBackColor = false;
            this.btnOpenFolder.Click += new System.EventHandler(this.OpenFolder_Click);
            // 
            // styleLabel12
            // 
            this.styleLabel12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.styleLabel12.CategoryName = null;
            this.styleLabel12.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.styleLabel12.ForeColor = System.Drawing.Color.White;
            this.styleLabel12.Location = new System.Drawing.Point(20, 90);
            this.styleLabel12.Name = "styleLabel12";
            this.styleLabel12.Size = new System.Drawing.Size(148, 24);
            this.styleLabel12.StyleName = "Caption";
            this.styleLabel12.TabIndex = 62;
            this.styleLabel12.Text = "出力先フォルダ";
            this.styleLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUserName
            // 
            this.lblUserName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblUserName.Location = new System.Drawing.Point(174, 14);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(285, 21);
            this.lblUserName.TabIndex = 12;
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // styleLabel5
            // 
            this.styleLabel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.styleLabel5.CategoryName = null;
            this.styleLabel5.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.styleLabel5.ForeColor = System.Drawing.Color.White;
            this.styleLabel5.Location = new System.Drawing.Point(20, 20);
            this.styleLabel5.Name = "styleLabel5";
            this.styleLabel5.Size = new System.Drawing.Size(148, 24);
            this.styleLabel5.StyleName = "Caption";
            this.styleLabel5.TabIndex = 11;
            this.styleLabel5.Text = "ユーザー名";
            this.styleLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnTryAccessNotes
            // 
            this.btnTryAccessNotes.CategoryName = null;
            this.btnTryAccessNotes.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnTryAccessNotes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTryAccessNotes.Location = new System.Drawing.Point(388, 55);
            this.btnTryAccessNotes.Margin = new System.Windows.Forms.Padding(0);
            this.btnTryAccessNotes.Name = "btnTryAccessNotes";
            this.btnTryAccessNotes.Size = new System.Drawing.Size(69, 24);
            this.btnTryAccessNotes.StyleName = "ActionButton";
            this.btnTryAccessNotes.TabIndex = 10;
            this.btnTryAccessNotes.Text = "接続";
            this.btnTryAccessNotes.UseVisualStyleBackColor = false;
            this.btnTryAccessNotes.Click += new System.EventHandler(this.btnTryAccessNotes_Click);
            // 
            // txtNotesPassword
            // 
            this.txtNotesPassword.CategoryName = null;
            this.txtNotesPassword.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtNotesPassword.Location = new System.Drawing.Point(174, 57);
            this.txtNotesPassword.Name = "txtNotesPassword";
            this.txtNotesPassword.PasswordChar = '*';
            this.txtNotesPassword.Size = new System.Drawing.Size(209, 21);
            this.txtNotesPassword.StyleName = "TextInput";
            this.txtNotesPassword.TabIndex = 1;
            // 
            // styleLabel1
            // 
            this.styleLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.styleLabel1.CategoryName = null;
            this.styleLabel1.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.styleLabel1.ForeColor = System.Drawing.Color.White;
            this.styleLabel1.Location = new System.Drawing.Point(20, 55);
            this.styleLabel1.Name = "styleLabel1";
            this.styleLabel1.Size = new System.Drawing.Size(148, 24);
            this.styleLabel1.StyleName = "Caption";
            this.styleLabel1.TabIndex = 0;
            this.styleLabel1.Text = "パスワード";
            this.styleLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabSharePoint
            // 
            this.tabSharePoint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabSharePoint.Controls.Add(this.btnTryAccessSP);
            this.tabSharePoint.Controls.Add(this.txtSPUser);
            this.tabSharePoint.Controls.Add(this.txtSPPassword);
            this.tabSharePoint.Controls.Add(this.styleLabel4);
            this.tabSharePoint.Controls.Add(this.styleLabel3);
            this.tabSharePoint.Controls.Add(this.txtSPWebSite);
            this.tabSharePoint.Controls.Add(this.styleLabel2);
            this.tabSharePoint.Location = new System.Drawing.Point(4, 25);
            this.tabSharePoint.Name = "tabSharePoint";
            this.tabSharePoint.Padding = new System.Windows.Forms.Padding(3);
            this.tabSharePoint.Size = new System.Drawing.Size(740, 452);
            this.tabSharePoint.TabIndex = 1;
            this.tabSharePoint.Text = "SharePoint設定";
            this.tabSharePoint.UseVisualStyleBackColor = true;
            // 
            // btnTryAccessSP
            // 
            this.btnTryAccessSP.CategoryName = null;
            this.btnTryAccessSP.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnTryAccessSP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTryAccessSP.Location = new System.Drawing.Point(353, 89);
            this.btnTryAccessSP.Margin = new System.Windows.Forms.Padding(0);
            this.btnTryAccessSP.Name = "btnTryAccessSP";
            this.btnTryAccessSP.Size = new System.Drawing.Size(69, 24);
            this.btnTryAccessSP.StyleName = "ActionButton";
            this.btnTryAccessSP.TabIndex = 11;
            this.btnTryAccessSP.Text = "接続";
            this.btnTryAccessSP.UseVisualStyleBackColor = false;
            this.btnTryAccessSP.Click += new System.EventHandler(this.btnTryAccessSP_Click);
            // 
            // txtSPUser
            // 
            this.txtSPUser.CategoryName = null;
            this.txtSPUser.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtSPUser.Location = new System.Drawing.Point(174, 55);
            this.txtSPUser.Name = "txtSPUser";
            this.txtSPUser.Size = new System.Drawing.Size(359, 21);
            this.txtSPUser.StyleName = "TextInput";
            this.txtSPUser.TabIndex = 8;
            // 
            // txtSPPassword
            // 
            this.txtSPPassword.CategoryName = null;
            this.txtSPPassword.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtSPPassword.Location = new System.Drawing.Point(174, 92);
            this.txtSPPassword.Name = "txtSPPassword";
            this.txtSPPassword.PasswordChar = '*';
            this.txtSPPassword.Size = new System.Drawing.Size(176, 21);
            this.txtSPPassword.StyleName = "TextInput";
            this.txtSPPassword.TabIndex = 7;
            // 
            // styleLabel4
            // 
            this.styleLabel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.styleLabel4.CategoryName = null;
            this.styleLabel4.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.styleLabel4.ForeColor = System.Drawing.Color.White;
            this.styleLabel4.Location = new System.Drawing.Point(20, 90);
            this.styleLabel4.Name = "styleLabel4";
            this.styleLabel4.Size = new System.Drawing.Size(148, 24);
            this.styleLabel4.StyleName = "Caption";
            this.styleLabel4.TabIndex = 6;
            this.styleLabel4.Text = "パスワード";
            this.styleLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // styleLabel3
            // 
            this.styleLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.styleLabel3.CategoryName = null;
            this.styleLabel3.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.styleLabel3.ForeColor = System.Drawing.Color.White;
            this.styleLabel3.Location = new System.Drawing.Point(20, 55);
            this.styleLabel3.Name = "styleLabel3";
            this.styleLabel3.Size = new System.Drawing.Size(148, 24);
            this.styleLabel3.StyleName = "Caption";
            this.styleLabel3.TabIndex = 5;
            this.styleLabel3.Text = "ユーザー名";
            this.styleLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSPWebSite
            // 
            this.txtSPWebSite.CategoryName = null;
            this.txtSPWebSite.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtSPWebSite.Location = new System.Drawing.Point(174, 22);
            this.txtSPWebSite.Name = "txtSPWebSite";
            this.txtSPWebSite.Size = new System.Drawing.Size(359, 21);
            this.txtSPWebSite.StyleName = "TextInput";
            this.txtSPWebSite.TabIndex = 4;
            // 
            // styleLabel2
            // 
            this.styleLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.styleLabel2.CategoryName = null;
            this.styleLabel2.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.styleLabel2.ForeColor = System.Drawing.Color.White;
            this.styleLabel2.Location = new System.Drawing.Point(20, 20);
            this.styleLabel2.Name = "styleLabel2";
            this.styleLabel2.Size = new System.Drawing.Size(148, 24);
            this.styleLabel2.StyleName = "Caption";
            this.styleLabel2.TabIndex = 3;
            this.styleLabel2.Text = "既定のWeb サイト";
            this.styleLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabDataBase
            // 
            this.tabDataBase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabDataBase.Controls.Add(this.btnTryAccessDB);
            this.tabDataBase.Controls.Add(this.cmbDataBase);
            this.tabDataBase.Controls.Add(this.styleLabel10);
            this.tabDataBase.Controls.Add(this.txtDbUserId);
            this.tabDataBase.Controls.Add(this.txtDBPassword);
            this.tabDataBase.Controls.Add(this.styleLabel9);
            this.tabDataBase.Controls.Add(this.cmbAuthMode);
            this.tabDataBase.Controls.Add(this.styleLabel8);
            this.tabDataBase.Controls.Add(this.styleLabel7);
            this.tabDataBase.Controls.Add(this.txtSqlServer);
            this.tabDataBase.Controls.Add(this.styleLabel6);
            this.tabDataBase.Location = new System.Drawing.Point(4, 25);
            this.tabDataBase.Name = "tabDataBase";
            this.tabDataBase.Size = new System.Drawing.Size(740, 452);
            this.tabDataBase.TabIndex = 2;
            this.tabDataBase.Text = "データベース";
            this.tabDataBase.UseVisualStyleBackColor = true;
            // 
            // btnTryAccessDB
            // 
            this.btnTryAccessDB.CategoryName = null;
            this.btnTryAccessDB.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnTryAccessDB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTryAccessDB.Location = new System.Drawing.Point(400, 160);
            this.btnTryAccessDB.Margin = new System.Windows.Forms.Padding(0);
            this.btnTryAccessDB.Name = "btnTryAccessDB";
            this.btnTryAccessDB.Size = new System.Drawing.Size(69, 24);
            this.btnTryAccessDB.StyleName = "ActionButton";
            this.btnTryAccessDB.TabIndex = 17;
            this.btnTryAccessDB.Text = "接続";
            this.btnTryAccessDB.UseVisualStyleBackColor = false;
            this.btnTryAccessDB.Click += new System.EventHandler(this.btnTryAccessDB_Click);
            // 
            // cmbDataBase
            // 
            this.cmbDataBase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDataBase.FormattingEnabled = true;
            this.cmbDataBase.Location = new System.Drawing.Point(173, 162);
            this.cmbDataBase.Name = "cmbDataBase";
            this.cmbDataBase.Size = new System.Drawing.Size(224, 20);
            this.cmbDataBase.TabIndex = 16;
            // 
            // styleLabel10
            // 
            this.styleLabel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.styleLabel10.CategoryName = null;
            this.styleLabel10.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.styleLabel10.ForeColor = System.Drawing.Color.White;
            this.styleLabel10.Location = new System.Drawing.Point(20, 160);
            this.styleLabel10.Name = "styleLabel10";
            this.styleLabel10.Size = new System.Drawing.Size(148, 24);
            this.styleLabel10.StyleName = "Caption";
            this.styleLabel10.TabIndex = 15;
            this.styleLabel10.Text = "データベース";
            this.styleLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDbUserId
            // 
            this.txtDbUserId.CategoryName = null;
            this.txtDbUserId.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtDbUserId.Location = new System.Drawing.Point(173, 92);
            this.txtDbUserId.Name = "txtDbUserId";
            this.txtDbUserId.Size = new System.Drawing.Size(222, 21);
            this.txtDbUserId.StyleName = "TextInput";
            this.txtDbUserId.TabIndex = 14;
            this.txtDbUserId.Leave += new System.EventHandler(this.txtSqlServer_Leave);
            // 
            // txtDBPassword
            // 
            this.txtDBPassword.CategoryName = null;
            this.txtDBPassword.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtDBPassword.Location = new System.Drawing.Point(173, 127);
            this.txtDBPassword.Name = "txtDBPassword";
            this.txtDBPassword.PasswordChar = '*';
            this.txtDBPassword.Size = new System.Drawing.Size(222, 21);
            this.txtDBPassword.StyleName = "TextInput";
            this.txtDBPassword.TabIndex = 13;
            this.txtDBPassword.Leave += new System.EventHandler(this.txtSqlServer_Leave);
            // 
            // styleLabel9
            // 
            this.styleLabel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.styleLabel9.CategoryName = null;
            this.styleLabel9.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.styleLabel9.ForeColor = System.Drawing.Color.White;
            this.styleLabel9.Location = new System.Drawing.Point(20, 125);
            this.styleLabel9.Name = "styleLabel9";
            this.styleLabel9.Size = new System.Drawing.Size(148, 24);
            this.styleLabel9.StyleName = "Caption";
            this.styleLabel9.TabIndex = 12;
            this.styleLabel9.Text = "パスワード";
            this.styleLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbAuthMode
            // 
            this.cmbAuthMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAuthMode.FormattingEnabled = true;
            this.cmbAuthMode.Location = new System.Drawing.Point(173, 57);
            this.cmbAuthMode.Name = "cmbAuthMode";
            this.cmbAuthMode.Size = new System.Drawing.Size(164, 20);
            this.cmbAuthMode.TabIndex = 11;
            this.cmbAuthMode.SelectionChangeCommitted += new System.EventHandler(this.cmbAuthMode_SelectionChangeCommitted);
            // 
            // styleLabel8
            // 
            this.styleLabel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.styleLabel8.CategoryName = null;
            this.styleLabel8.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.styleLabel8.ForeColor = System.Drawing.Color.White;
            this.styleLabel8.Location = new System.Drawing.Point(20, 90);
            this.styleLabel8.Name = "styleLabel8";
            this.styleLabel8.Size = new System.Drawing.Size(148, 24);
            this.styleLabel8.StyleName = "Caption";
            this.styleLabel8.TabIndex = 11;
            this.styleLabel8.Text = "ログイン";
            this.styleLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // styleLabel7
            // 
            this.styleLabel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.styleLabel7.CategoryName = null;
            this.styleLabel7.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.styleLabel7.ForeColor = System.Drawing.Color.White;
            this.styleLabel7.Location = new System.Drawing.Point(20, 55);
            this.styleLabel7.Name = "styleLabel7";
            this.styleLabel7.Size = new System.Drawing.Size(148, 24);
            this.styleLabel7.StyleName = "Caption";
            this.styleLabel7.TabIndex = 10;
            this.styleLabel7.Text = "認証";
            this.styleLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSqlServer
            // 
            this.txtSqlServer.CategoryName = null;
            this.txtSqlServer.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtSqlServer.Location = new System.Drawing.Point(173, 22);
            this.txtSqlServer.Name = "txtSqlServer";
            this.txtSqlServer.Size = new System.Drawing.Size(224, 21);
            this.txtSqlServer.StyleName = "TextInput";
            this.txtSqlServer.TabIndex = 9;
            this.txtSqlServer.Leave += new System.EventHandler(this.txtSqlServer_Leave);
            // 
            // styleLabel6
            // 
            this.styleLabel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.styleLabel6.CategoryName = null;
            this.styleLabel6.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.styleLabel6.ForeColor = System.Drawing.Color.White;
            this.styleLabel6.Location = new System.Drawing.Point(20, 20);
            this.styleLabel6.Name = "styleLabel6";
            this.styleLabel6.Size = new System.Drawing.Size(148, 24);
            this.styleLabel6.StyleName = "Caption";
            this.styleLabel6.TabIndex = 6;
            this.styleLabel6.Text = "サーバー名";
            this.styleLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EnvSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 536);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tabMain);
            this.Name = "EnvSettingForm";
            this.StyleName = "Form";
            this.Text = "システム設定";
            this.Load += new System.EventHandler(this.EnvSettingForm_Load);
            this.tabMain.ResumeLayout(false);
            this.tabNotes.ResumeLayout(false);
            this.tabNotes.PerformLayout();
            this.tabSharePoint.ResumeLayout(false);
            this.tabSharePoint.PerformLayout();
            this.tabDataBase.ResumeLayout(false);
            this.tabDataBase.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Component.StyleLabel styleLabel1;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabNotes;
        private System.Windows.Forms.TabPage tabSharePoint;
        private Component.StyleTextBox txtNotesPassword;
        private Component.StyleButton btnClose;
        private Component.StyleButton btnSave;
        private Component.StyleTextBox txtSPUser;
        private Component.StyleTextBox txtSPPassword;
        private Component.StyleLabel styleLabel4;
        private Component.StyleLabel styleLabel3;
        private Component.StyleTextBox txtSPWebSite;
        private Component.StyleLabel styleLabel2;
        private Component.StyleButton btnTryAccessNotes;
        private Component.StyleButton btnTryAccessSP;
        private System.Windows.Forms.Label lblUserName;
        private Component.StyleLabel styleLabel5;
        private System.Windows.Forms.TabPage tabDataBase;
        private Component.StyleButton btnTryAccessDB;
        private System.Windows.Forms.ComboBox cmbDataBase;
        private Component.StyleLabel styleLabel10;
        private Component.StyleTextBox txtDbUserId;
        private Component.StyleTextBox txtDBPassword;
        private Component.StyleLabel styleLabel9;
        private System.Windows.Forms.ComboBox cmbAuthMode;
        private Component.StyleLabel styleLabel8;
        private Component.StyleLabel styleLabel7;
        private Component.StyleTextBox txtSqlServer;
        private Component.StyleLabel styleLabel6;
        private Component.StyleTextBox txtOutputFolder;
        private Component.StyleButton btnOpenFolder;
        private Component.StyleLabel styleLabel12;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private Component.StyleLabel lblUserId;
    }
}