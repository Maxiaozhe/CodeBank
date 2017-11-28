namespace RJ.Tools.NotesTransfer.UI.Forms
{
    partial class FormSetting
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
            this.btnSave = new RJ.Tools.NotesTransfer.UI.Component.StyleButton();
            this.button3 = new RJ.Tools.NotesTransfer.UI.Component.StyleButton();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.DispFormPanel = new System.Windows.Forms.Panel();
            this.styleLabel5 = new RJ.Tools.NotesTransfer.UI.Component.StyleLabel();
            this.chkDefaultDisp = new System.Windows.Forms.CheckBox();
            this.txtDispFormName = new RJ.Tools.NotesTransfer.UI.Component.StyleTextBox();
            this.EditFormPanel = new System.Windows.Forms.Panel();
            this.styleLabel4 = new RJ.Tools.NotesTransfer.UI.Component.StyleLabel();
            this.chkDefaultEdit = new System.Windows.Forms.CheckBox();
            this.txtEditFormName = new RJ.Tools.NotesTransfer.UI.Component.StyleTextBox();
            this.NewFormPanel = new System.Windows.Forms.Panel();
            this.styleLabel3 = new RJ.Tools.NotesTransfer.UI.Component.StyleLabel();
            this.chkDefaultNew = new System.Windows.Forms.CheckBox();
            this.txtNewFormName = new RJ.Tools.NotesTransfer.UI.Component.StyleTextBox();
            this.rdoNotTarget = new System.Windows.Forms.RadioButton();
            this.rdoIsTarget = new System.Windows.Forms.RadioButton();
            this.styleLabel6 = new RJ.Tools.NotesTransfer.UI.Component.StyleLabel();
            this.chkHasDispForm = new System.Windows.Forms.CheckBox();
            this.chkHasEditForm = new System.Windows.Forms.CheckBox();
            this.chkHasNewForm = new System.Windows.Forms.CheckBox();
            this.txtAliases = new RJ.Tools.NotesTransfer.UI.Component.StyleTextBox();
            this.styleLabel1 = new RJ.Tools.NotesTransfer.UI.Component.StyleLabel();
            this.txtDisplayName = new RJ.Tools.NotesTransfer.UI.Component.StyleTextBox();
            this.styleLabel7 = new RJ.Tools.NotesTransfer.UI.Component.StyleLabel();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colRequired = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colConvert = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colFieldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coSrclType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTargetType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.styleLabel8 = new RJ.Tools.NotesTransfer.UI.Component.StyleLabel();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.styleLabel13 = new RJ.Tools.NotesTransfer.UI.Component.StyleLabel();
            this.btnPreview = new RJ.Tools.NotesTransfer.UI.Component.StyleButton();
            this.tabMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.DispFormPanel.SuspendLayout();
            this.EditFormPanel.SuspendLayout();
            this.NewFormPanel.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.btnSave.Location = new System.Drawing.Point(615, 531);
            this.btnSave.Margin = new System.Windows.Forms.Padding(0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 31);
            this.btnSave.StyleName = "FormButton";
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.SaveButton_Click);
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
            this.button3.Location = new System.Drawing.Point(719, 531);
            this.button3.Margin = new System.Windows.Forms.Padding(0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(95, 31);
            this.button3.StyleName = "FormButton";
            this.button3.TabIndex = 9;
            this.button3.Text = "閉じる";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.CloseBUtton_Click);
            // 
            // tabMain
            // 
            this.tabMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMain.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabMain.Controls.Add(this.tabPage1);
            this.tabMain.Controls.Add(this.tabPage3);
            this.tabMain.HotTrack = true;
            this.tabMain.Location = new System.Drawing.Point(12, 12);
            this.tabMain.Multiline = true;
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(806, 516);
            this.tabMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabMain.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage1.Controls.Add(this.DispFormPanel);
            this.tabPage1.Controls.Add(this.EditFormPanel);
            this.tabPage1.Controls.Add(this.NewFormPanel);
            this.tabPage1.Controls.Add(this.rdoNotTarget);
            this.tabPage1.Controls.Add(this.rdoIsTarget);
            this.tabPage1.Controls.Add(this.styleLabel6);
            this.tabPage1.Controls.Add(this.chkHasDispForm);
            this.tabPage1.Controls.Add(this.chkHasEditForm);
            this.tabPage1.Controls.Add(this.chkHasNewForm);
            this.tabPage1.Controls.Add(this.txtAliases);
            this.tabPage1.Controls.Add(this.styleLabel1);
            this.tabPage1.Controls.Add(this.txtDisplayName);
            this.tabPage1.Controls.Add(this.styleLabel7);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(798, 487);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "対象フォーム";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // DispFormPanel
            // 
            this.DispFormPanel.Controls.Add(this.styleLabel5);
            this.DispFormPanel.Controls.Add(this.chkDefaultDisp);
            this.DispFormPanel.Controls.Add(this.txtDispFormName);
            this.DispFormPanel.Location = new System.Drawing.Point(19, 308);
            this.DispFormPanel.Name = "DispFormPanel";
            this.DispFormPanel.Size = new System.Drawing.Size(579, 41);
            this.DispFormPanel.TabIndex = 84;
            // 
            // styleLabel5
            // 
            this.styleLabel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.styleLabel5.CategoryName = null;
            this.styleLabel5.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.styleLabel5.ForeColor = System.Drawing.Color.White;
            this.styleLabel5.Location = new System.Drawing.Point(6, 7);
            this.styleLabel5.Name = "styleLabel5";
            this.styleLabel5.Size = new System.Drawing.Size(148, 24);
            this.styleLabel5.StyleName = "Caption";
            this.styleLabel5.TabIndex = 75;
            this.styleLabel5.Text = "ファイル名";
            this.styleLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkDefaultDisp
            // 
            this.chkDefaultDisp.AutoSize = true;
            this.chkDefaultDisp.Location = new System.Drawing.Point(427, 11);
            this.chkDefaultDisp.Name = "chkDefaultDisp";
            this.chkDefaultDisp.Size = new System.Drawing.Size(112, 16);
            this.chkDefaultDisp.TabIndex = 72;
            this.chkDefaultDisp.Text = "既定フォームにする";
            this.chkDefaultDisp.UseVisualStyleBackColor = true;
            // 
            // txtDispFormName
            // 
            this.txtDispFormName.CategoryName = null;
            this.txtDispFormName.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtDispFormName.Location = new System.Drawing.Point(160, 9);
            this.txtDispFormName.Name = "txtDispFormName";
            this.txtDispFormName.Size = new System.Drawing.Size(261, 21);
            this.txtDispFormName.StyleName = "TextInput";
            this.txtDispFormName.TabIndex = 66;
            // 
            // EditFormPanel
            // 
            this.EditFormPanel.Controls.Add(this.styleLabel4);
            this.EditFormPanel.Controls.Add(this.chkDefaultEdit);
            this.EditFormPanel.Controls.Add(this.txtEditFormName);
            this.EditFormPanel.Location = new System.Drawing.Point(19, 241);
            this.EditFormPanel.Name = "EditFormPanel";
            this.EditFormPanel.Size = new System.Drawing.Size(579, 38);
            this.EditFormPanel.TabIndex = 83;
            // 
            // styleLabel4
            // 
            this.styleLabel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.styleLabel4.CategoryName = null;
            this.styleLabel4.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.styleLabel4.ForeColor = System.Drawing.Color.White;
            this.styleLabel4.Location = new System.Drawing.Point(8, 8);
            this.styleLabel4.Name = "styleLabel4";
            this.styleLabel4.Size = new System.Drawing.Size(148, 24);
            this.styleLabel4.StyleName = "Caption";
            this.styleLabel4.TabIndex = 74;
            this.styleLabel4.Text = "ファイル名";
            this.styleLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkDefaultEdit
            // 
            this.chkDefaultEdit.AutoSize = true;
            this.chkDefaultEdit.Location = new System.Drawing.Point(429, 12);
            this.chkDefaultEdit.Name = "chkDefaultEdit";
            this.chkDefaultEdit.Size = new System.Drawing.Size(112, 16);
            this.chkDefaultEdit.TabIndex = 71;
            this.chkDefaultEdit.Text = "既定フォームにする";
            this.chkDefaultEdit.UseVisualStyleBackColor = true;
            // 
            // txtEditFormName
            // 
            this.txtEditFormName.CategoryName = null;
            this.txtEditFormName.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtEditFormName.Location = new System.Drawing.Point(162, 10);
            this.txtEditFormName.Name = "txtEditFormName";
            this.txtEditFormName.Size = new System.Drawing.Size(261, 21);
            this.txtEditFormName.StyleName = "TextInput";
            this.txtEditFormName.TabIndex = 63;
            // 
            // NewFormPanel
            // 
            this.NewFormPanel.Controls.Add(this.styleLabel3);
            this.NewFormPanel.Controls.Add(this.chkDefaultNew);
            this.NewFormPanel.Controls.Add(this.txtNewFormName);
            this.NewFormPanel.Location = new System.Drawing.Point(19, 173);
            this.NewFormPanel.Name = "NewFormPanel";
            this.NewFormPanel.Size = new System.Drawing.Size(579, 41);
            this.NewFormPanel.TabIndex = 82;
            // 
            // styleLabel3
            // 
            this.styleLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.styleLabel3.CategoryName = null;
            this.styleLabel3.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.styleLabel3.ForeColor = System.Drawing.Color.White;
            this.styleLabel3.Location = new System.Drawing.Point(10, 8);
            this.styleLabel3.Name = "styleLabel3";
            this.styleLabel3.Size = new System.Drawing.Size(148, 24);
            this.styleLabel3.StyleName = "Caption";
            this.styleLabel3.TabIndex = 73;
            this.styleLabel3.Text = "ファイル名";
            this.styleLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkDefaultNew
            // 
            this.chkDefaultNew.AutoSize = true;
            this.chkDefaultNew.Location = new System.Drawing.Point(431, 12);
            this.chkDefaultNew.Name = "chkDefaultNew";
            this.chkDefaultNew.Size = new System.Drawing.Size(112, 16);
            this.chkDefaultNew.TabIndex = 70;
            this.chkDefaultNew.Text = "既定フォームにする";
            this.chkDefaultNew.UseVisualStyleBackColor = true;
            // 
            // txtNewFormName
            // 
            this.txtNewFormName.CategoryName = null;
            this.txtNewFormName.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtNewFormName.Location = new System.Drawing.Point(164, 10);
            this.txtNewFormName.Name = "txtNewFormName";
            this.txtNewFormName.Size = new System.Drawing.Size(261, 21);
            this.txtNewFormName.StyleName = "TextInput";
            this.txtNewFormName.TabIndex = 60;
            // 
            // rdoNotTarget
            // 
            this.rdoNotTarget.AutoSize = true;
            this.rdoNotTarget.Location = new System.Drawing.Point(224, 91);
            this.rdoNotTarget.Name = "rdoNotTarget";
            this.rdoNotTarget.Size = new System.Drawing.Size(47, 16);
            this.rdoNotTarget.TabIndex = 69;
            this.rdoNotTarget.TabStop = true;
            this.rdoNotTarget.Text = "無効";
            this.rdoNotTarget.UseVisualStyleBackColor = true;
            // 
            // rdoIsTarget
            // 
            this.rdoIsTarget.AutoSize = true;
            this.rdoIsTarget.Location = new System.Drawing.Point(171, 91);
            this.rdoIsTarget.Name = "rdoIsTarget";
            this.rdoIsTarget.Size = new System.Drawing.Size(47, 16);
            this.rdoIsTarget.TabIndex = 68;
            this.rdoIsTarget.TabStop = true;
            this.rdoIsTarget.Text = "有効";
            this.rdoIsTarget.UseVisualStyleBackColor = true;
            // 
            // styleLabel6
            // 
            this.styleLabel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.styleLabel6.CategoryName = null;
            this.styleLabel6.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.styleLabel6.ForeColor = System.Drawing.Color.White;
            this.styleLabel6.Location = new System.Drawing.Point(16, 87);
            this.styleLabel6.Name = "styleLabel6";
            this.styleLabel6.Size = new System.Drawing.Size(148, 24);
            this.styleLabel6.StyleName = "Caption";
            this.styleLabel6.TabIndex = 67;
            this.styleLabel6.Text = "変換対象フラグ";
            this.styleLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkHasDispForm
            // 
            this.chkHasDispForm.AutoSize = true;
            this.chkHasDispForm.Location = new System.Drawing.Point(19, 288);
            this.chkHasDispForm.Name = "chkHasDispForm";
            this.chkHasDispForm.Size = new System.Drawing.Size(173, 16);
            this.chkHasDispForm.TabIndex = 64;
            this.chkHasDispForm.Text = "アイテム表示フォームを作成する";
            this.chkHasDispForm.UseVisualStyleBackColor = true;
            this.chkHasDispForm.CheckedChanged += new System.EventHandler(this.HasDispForm_CheckedChanged);
            // 
            // chkHasEditForm
            // 
            this.chkHasEditForm.AutoSize = true;
            this.chkHasEditForm.Location = new System.Drawing.Point(19, 222);
            this.chkHasEditForm.Name = "chkHasEditForm";
            this.chkHasEditForm.Size = new System.Drawing.Size(173, 16);
            this.chkHasEditForm.TabIndex = 61;
            this.chkHasEditForm.Text = "アイテム編集フォームを作成する";
            this.chkHasEditForm.UseVisualStyleBackColor = true;
            this.chkHasEditForm.CheckedChanged += new System.EventHandler(this.HasEditForm_CheckedChanged);
            // 
            // chkHasNewForm
            // 
            this.chkHasNewForm.AutoSize = true;
            this.chkHasNewForm.Location = new System.Drawing.Point(19, 154);
            this.chkHasNewForm.Name = "chkHasNewForm";
            this.chkHasNewForm.Size = new System.Drawing.Size(173, 16);
            this.chkHasNewForm.TabIndex = 58;
            this.chkHasNewForm.Text = "アイテム作成フォームを作成する";
            this.chkHasNewForm.UseVisualStyleBackColor = true;
            this.chkHasNewForm.CheckedChanged += new System.EventHandler(this.HasNewForm_CheckedChanged);
            // 
            // txtAliases
            // 
            this.txtAliases.CategoryName = null;
            this.txtAliases.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtAliases.Location = new System.Drawing.Point(170, 52);
            this.txtAliases.Name = "txtAliases";
            this.txtAliases.ReadOnly = true;
            this.txtAliases.Size = new System.Drawing.Size(261, 21);
            this.txtAliases.StyleName = "TextDisplay";
            this.txtAliases.TabIndex = 55;
            // 
            // styleLabel1
            // 
            this.styleLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.styleLabel1.CategoryName = null;
            this.styleLabel1.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.styleLabel1.ForeColor = System.Drawing.Color.White;
            this.styleLabel1.Location = new System.Drawing.Point(16, 50);
            this.styleLabel1.Name = "styleLabel1";
            this.styleLabel1.Size = new System.Drawing.Size(148, 24);
            this.styleLabel1.StyleName = "Caption";
            this.styleLabel1.TabIndex = 54;
            this.styleLabel1.Text = "別名";
            this.styleLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDisplayName
            // 
            this.txtDisplayName.CategoryName = null;
            this.txtDisplayName.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtDisplayName.Location = new System.Drawing.Point(170, 17);
            this.txtDisplayName.Name = "txtDisplayName";
            this.txtDisplayName.Size = new System.Drawing.Size(261, 21);
            this.txtDisplayName.StyleName = "TextInput";
            this.txtDisplayName.TabIndex = 53;
            // 
            // styleLabel7
            // 
            this.styleLabel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.styleLabel7.CategoryName = null;
            this.styleLabel7.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.styleLabel7.ForeColor = System.Drawing.Color.White;
            this.styleLabel7.Location = new System.Drawing.Point(16, 15);
            this.styleLabel7.Name = "styleLabel7";
            this.styleLabel7.Size = new System.Drawing.Size(148, 24);
            this.styleLabel7.StyleName = "Caption";
            this.styleLabel7.TabIndex = 52;
            this.styleLabel7.Text = "フォーム タイトル";
            this.styleLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage3
            // 
            this.tabPage3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage3.Controls.Add(this.dataGridView1);
            this.tabPage3.Controls.Add(this.styleLabel8);
            this.tabPage3.Controls.Add(this.propertyGrid1);
            this.tabPage3.Controls.Add(this.styleLabel13);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(798, 487);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "フィールド";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRequired,
            this.colConvert,
            this.colFieldName,
            this.coSrclType,
            this.colTargetType});
            this.dataGridView1.Location = new System.Drawing.Point(17, 43);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(414, 437);
            this.dataGridView1.TabIndex = 23;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // colRequired
            // 
            this.colRequired.DataPropertyName = "Required";
            this.colRequired.Frozen = true;
            this.colRequired.HeaderText = "必須";
            this.colRequired.Name = "colRequired";
            this.colRequired.ReadOnly = true;
            this.colRequired.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colRequired.Width = 36;
            // 
            // colConvert
            // 
            this.colConvert.DataPropertyName = "TargetType";
            this.colConvert.Frozen = true;
            this.colConvert.HeaderText = "変換";
            this.colConvert.Name = "colConvert";
            this.colConvert.ReadOnly = true;
            this.colConvert.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colConvert.Width = 36;
            // 
            // colFieldName
            // 
            this.colFieldName.DataPropertyName = "Name";
            this.colFieldName.HeaderText = "フィールド名";
            this.colFieldName.Name = "colFieldName";
            this.colFieldName.ReadOnly = true;
            this.colFieldName.Width = 120;
            // 
            // coSrclType
            // 
            this.coSrclType.DataPropertyName = "SourceType";
            this.coSrclType.HeaderText = "種別";
            this.coSrclType.Name = "coSrclType";
            this.coSrclType.ReadOnly = true;
            // 
            // colTargetType
            // 
            this.colTargetType.DataPropertyName = "TargetType";
            this.colTargetType.HeaderText = "変換先種別";
            this.colTargetType.Name = "colTargetType";
            this.colTargetType.ReadOnly = true;
            // 
            // styleLabel8
            // 
            this.styleLabel8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.styleLabel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.styleLabel8.CategoryName = null;
            this.styleLabel8.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.styleLabel8.ForeColor = System.Drawing.Color.White;
            this.styleLabel8.Location = new System.Drawing.Point(437, 16);
            this.styleLabel8.Name = "styleLabel8";
            this.styleLabel8.Size = new System.Drawing.Size(346, 24);
            this.styleLabel8.StyleName = "Caption";
            this.styleLabel8.TabIndex = 22;
            this.styleLabel8.Text = "フィールド属性設定";
            this.styleLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyGrid1.Location = new System.Drawing.Point(437, 43);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.propertyGrid1.Size = new System.Drawing.Size(346, 438);
            this.propertyGrid1.TabIndex = 21;
            this.propertyGrid1.ToolbarVisible = false;
            this.propertyGrid1.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.OnPropertyValueChanged);
            // 
            // styleLabel13
            // 
            this.styleLabel13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.styleLabel13.CategoryName = null;
            this.styleLabel13.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.styleLabel13.ForeColor = System.Drawing.Color.White;
            this.styleLabel13.Location = new System.Drawing.Point(16, 16);
            this.styleLabel13.Name = "styleLabel13";
            this.styleLabel13.Size = new System.Drawing.Size(415, 24);
            this.styleLabel13.StyleName = "Caption";
            this.styleLabel13.TabIndex = 20;
            this.styleLabel13.Text = "フィールド一覧";
            this.styleLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.btnPreview.CategoryName = null;
            this.btnPreview.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnPreview.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(141)))), ((int)(((byte)(212)))));
            this.btnPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreview.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnPreview.ForeColor = System.Drawing.Color.White;
            this.btnPreview.Location = new System.Drawing.Point(16, 531);
            this.btnPreview.Margin = new System.Windows.Forms.Padding(0);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(144, 31);
            this.btnPreview.StyleName = "FormButton";
            this.btnPreview.TabIndex = 27;
            this.btnPreview.Text = "フォームレイアウト";
            this.btnPreview.UseVisualStyleBackColor = false;
            this.btnPreview.Click += new System.EventHandler(this.Preview_Click);
            // 
            // FormSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 578);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.tabMain);
            this.Name = "FormSetting";
            this.StyleName = "Form";
            this.Text = "フォーム出力設定";
            this.Load += new System.EventHandler(this.FormSetting_Load);
            this.tabMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.DispFormPanel.ResumeLayout(false);
            this.DispFormPanel.PerformLayout();
            this.EditFormPanel.ResumeLayout(false);
            this.EditFormPanel.PerformLayout();
            this.NewFormPanel.ResumeLayout(false);
            this.NewFormPanel.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private Component.StyleButton btnSave;
        private Component.StyleButton button3;
        private Component.StyleLabel styleLabel7;
        private Component.StyleTextBox txtDispFormName;
        private System.Windows.Forms.CheckBox chkHasDispForm;
        private Component.StyleTextBox txtEditFormName;
        private System.Windows.Forms.CheckBox chkHasEditForm;
        private Component.StyleTextBox txtNewFormName;
        private System.Windows.Forms.CheckBox chkHasNewForm;
        private Component.StyleTextBox txtAliases;
        private Component.StyleLabel styleLabel1;
        private Component.StyleTextBox txtDisplayName;
        private System.Windows.Forms.RadioButton rdoNotTarget;
        private System.Windows.Forms.RadioButton rdoIsTarget;
        private Component.StyleLabel styleLabel6;
        private System.Windows.Forms.CheckBox chkDefaultDisp;
        private System.Windows.Forms.CheckBox chkDefaultEdit;
        private System.Windows.Forms.CheckBox chkDefaultNew;
        private Component.StyleLabel styleLabel8;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private Component.StyleLabel styleLabel13;
        private System.Windows.Forms.Panel DispFormPanel;
        private Component.StyleLabel styleLabel5;
        private System.Windows.Forms.Panel EditFormPanel;
        private Component.StyleLabel styleLabel4;
        private System.Windows.Forms.Panel NewFormPanel;
        private Component.StyleLabel styleLabel3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private Component.StyleButton btnPreview;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colRequired;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colConvert;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFieldName;
        private System.Windows.Forms.DataGridViewTextBoxColumn coSrclType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTargetType;
    }
}