namespace TableDesignInfo.Forms
{
    partial class TableLayoutForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colKey = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colColumnDisplayName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNullable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTable = new System.Windows.Forms.Label();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.txtDisplayName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCreateSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCreateInsertSql = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCreateSql = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuJoinCondition = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuShowDataView = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colKey,
            this.colColumnName,
            this.colColumnDisplayName,
            this.colType,
            this.colNullable,
            this.colComment});
            this.dataGridView1.Location = new System.Drawing.Point(13, 153);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(831, 493);
            this.dataGridView1.TabIndex = 0;
            // 
            // colKey
            // 
            this.colKey.DataPropertyName = "IsPrimaryKey";
            this.colKey.HeaderText = "キー";
            this.colKey.Name = "colKey";
            this.colKey.ReadOnly = true;
            this.colKey.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colKey.Width = 55;
            // 
            // colColumnName
            // 
            this.colColumnName.DataPropertyName = "ColumnName";
            this.colColumnName.HeaderText = "列名";
            this.colColumnName.Name = "colColumnName";
            this.colColumnName.ReadOnly = true;
            this.colColumnName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colColumnName.Width = 200;
            // 
            // colColumnDisplayName
            // 
            this.colColumnDisplayName.DataPropertyName = "ColumnDisplayName";
            this.colColumnDisplayName.HeaderText = "表示名";
            this.colColumnDisplayName.Name = "colColumnDisplayName";
            this.colColumnDisplayName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colColumnDisplayName.Width = 200;
            // 
            // colType
            // 
            this.colType.DataPropertyName = "SqlDataType";
            this.colType.HeaderText = "型";
            this.colType.Name = "colType";
            this.colType.ReadOnly = true;
            this.colType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colNullable
            // 
            this.colNullable.DataPropertyName = "Nullable";
            this.colNullable.HeaderText = "NULL許可";
            this.colNullable.Name = "colNullable";
            this.colNullable.ReadOnly = true;
            this.colNullable.Width = 70;
            // 
            // colComment
            // 
            this.colComment.DataPropertyName = "Comment";
            this.colComment.HeaderText = "説明";
            this.colComment.Name = "colComment";
            this.colComment.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colComment.Width = 200;
            // 
            // lblTable
            // 
            this.lblTable.AutoSize = true;
            this.lblTable.Location = new System.Drawing.Point(13, 34);
            this.lblTable.Name = "lblTable";
            this.lblTable.Size = new System.Drawing.Size(55, 12);
            this.lblTable.TabIndex = 1;
            this.lblTable.Text = "テーブル名";
            // 
            // txtTableName
            // 
            this.txtTableName.Location = new System.Drawing.Point(89, 32);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(755, 19);
            this.txtTableName.TabIndex = 2;
            // 
            // txtDisplayName
            // 
            this.txtDisplayName.Location = new System.Drawing.Point(89, 57);
            this.txtDisplayName.Name = "txtDisplayName";
            this.txtDisplayName.Size = new System.Drawing.Size(755, 19);
            this.txtDisplayName.TabIndex = 4;
            this.txtDisplayName.TextChanged += new System.EventHandler(this.txtDisplayName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "表示名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "説明";
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(89, 82);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(755, 63);
            this.txtComment.TabIndex = 6;
            this.txtComment.TextChanged += new System.EventHandler(this.txtComment_TextChanged);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(15, 122);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(55, 23);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "更新";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(856, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCreateSelect,
            this.mnuCreateInsertSql,
            this.mnuCreateSql,
            this.mnuJoinCondition,
            this.mnuShowDataView});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(62, 20);
            this.toolStripMenuItem1.Text = "スクリプト";
            // 
            // mnuCreateSelect
            // 
            this.mnuCreateSelect.Name = "mnuCreateSelect";
            this.mnuCreateSelect.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuCreateSelect.Size = new System.Drawing.Size(165, 22);
            this.mnuCreateSelect.Text = "SELECT文";
            this.mnuCreateSelect.Click += new System.EventHandler(this.mnuCreateSelect_Click);
            // 
            // mnuCreateInsertSql
            // 
            this.mnuCreateInsertSql.Name = "mnuCreateInsertSql";
            this.mnuCreateInsertSql.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.mnuCreateInsertSql.Size = new System.Drawing.Size(165, 22);
            this.mnuCreateInsertSql.Text = "INSERT文";
            this.mnuCreateInsertSql.Click += new System.EventHandler(this.mnuCreateInsertSql_Click);
            // 
            // mnuCreateSql
            // 
            this.mnuCreateSql.Name = "mnuCreateSql";
            this.mnuCreateSql.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.mnuCreateSql.Size = new System.Drawing.Size(165, 22);
            this.mnuCreateSql.Text = "CREATE文";
            this.mnuCreateSql.Click += new System.EventHandler(this.mnuCreateSql_Click);
            // 
            // mnuJoinCondition
            // 
            this.mnuJoinCondition.Name = "mnuJoinCondition";
            this.mnuJoinCondition.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.J)));
            this.mnuJoinCondition.Size = new System.Drawing.Size(165, 22);
            this.mnuJoinCondition.Text = "結合条件";
            this.mnuJoinCondition.Click += new System.EventHandler(this.mnuJoinCondition_Click);
            // 
            // mnuShowDataView
            // 
            this.mnuShowDataView.Name = "mnuShowDataView";
            this.mnuShowDataView.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.mnuShowDataView.Size = new System.Drawing.Size(165, 22);
            this.mnuShowDataView.Text = "データ表示";
            this.mnuShowDataView.Click += new System.EventHandler(this.ShowDataViewMenuItem_Click);
            // 
            // TableLayoutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 658);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDisplayName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTableName);
            this.Controls.Add(this.lblTable);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TableLayoutForm";
            this.Text = "テーブルレイアウト";
            this.Load += new System.EventHandler(this.TableLayout_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblTable;
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.TextBox txtDisplayName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn colColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colColumnDisplayName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colNullable;
        private System.Windows.Forms.DataGridViewTextBoxColumn colComment;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuCreateSelect;
        private System.Windows.Forms.ToolStripMenuItem mnuCreateInsertSql;
        private System.Windows.Forms.ToolStripMenuItem mnuCreateSql;
        private System.Windows.Forms.ToolStripMenuItem mnuJoinCondition;
        private System.Windows.Forms.ToolStripMenuItem mnuShowDataView;
    }
}