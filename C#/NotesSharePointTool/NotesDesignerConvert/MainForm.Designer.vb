<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnOpen = New System.Windows.Forms.ToolStripButton()
        Me.btnExportAll = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.mnuForm = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuView = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDocument = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAction = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAgent = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFolder = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuImgsource = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuIcon = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabForm = New System.Windows.Forms.TabPage()
        Me.treForm = New System.Windows.Forms.TreeView()
        Me.tabView = New System.Windows.Forms.TabPage()
        Me.treView = New System.Windows.Forms.TreeView()
        Me.tabAction = New System.Windows.Forms.TabPage()
        Me.treeAction = New System.Windows.Forms.TreeView()
        Me.tabDocument = New System.Windows.Forms.TabPage()
        Me.treeDoc = New System.Windows.Forms.TreeView()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.treeServer = New System.Windows.Forms.TreeView()
        Me.PropertyGrid1 = New System.Windows.Forms.PropertyGrid()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.mnuAllDesignItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tabForm.SuspendLayout()
        Me.tabView.SuspendLayout()
        Me.tabAction.SuspendLayout()
        Me.tabDocument.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Filter = "データベースファイル|*.nsf"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnOpen, Me.btnExportAll, Me.ToolStripButton1, Me.ToolStripButton5, Me.ToolStripButton2, Me.ToolStripDropDownButton1, Me.ToolStripButton3, Me.ToolStripButton4, Me.ToolStripButton6, Me.ToolStripButton7})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(886, 25)
        Me.ToolStrip1.TabIndex = 5
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnOpen
        '
        Me.btnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnOpen.Image = CType(resources.GetObject("btnOpen.Image"), System.Drawing.Image)
        Me.btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(108, 22)
        Me.btnOpen.Text = "データベース選択"
        Me.btnOpen.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        '
        'btnExportAll
        '
        Me.btnExportAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnExportAll.Image = CType(resources.GetObject("btnExportAll.Image"), System.Drawing.Image)
        Me.btnExportAll.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExportAll.Name = "btnExportAll"
        Me.btnExportAll.Size = New System.Drawing.Size(89, 22)
        Me.btnExportAll.Text = "DBすべて出力"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(108, 22)
        Me.ToolStripButton1.Text = "DXLエクスポート"
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"), System.Drawing.Image)
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(132, 22)
        Me.ToolStripButton5.Text = "フォームエクスポート"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(78, 22)
        Me.ToolStripButton2.Text = "XSLTで変換"
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuForm, Me.mnuView, Me.mnuDocument, Me.mnuAction, Me.mnuAgent, Me.mnuFolder, Me.mnuImgsource, Me.mnuIcon, Me.mnuAllDesignItem})
        Me.ToolStripDropDownButton1.Image = CType(resources.GetObject("ToolStripDropDownButton1.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(81, 22)
        Me.ToolStripDropDownButton1.Text = "オプション"
        '
        'mnuForm
        '
        Me.mnuForm.Checked = True
        Me.mnuForm.CheckOnClick = True
        Me.mnuForm.CheckState = System.Windows.Forms.CheckState.Checked
        Me.mnuForm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.mnuForm.Name = "mnuForm"
        Me.mnuForm.Size = New System.Drawing.Size(160, 22)
        Me.mnuForm.Text = "フォーム"
        '
        'mnuView
        '
        Me.mnuView.Checked = True
        Me.mnuView.CheckOnClick = True
        Me.mnuView.CheckState = System.Windows.Forms.CheckState.Checked
        Me.mnuView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.mnuView.Name = "mnuView"
        Me.mnuView.Size = New System.Drawing.Size(160, 22)
        Me.mnuView.Text = "ビュー"
        '
        'mnuDocument
        '
        Me.mnuDocument.CheckOnClick = True
        Me.mnuDocument.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.mnuDocument.Name = "mnuDocument"
        Me.mnuDocument.Size = New System.Drawing.Size(160, 22)
        Me.mnuDocument.Text = "文書"
        '
        'mnuAction
        '
        Me.mnuAction.CheckOnClick = True
        Me.mnuAction.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.mnuAction.Name = "mnuAction"
        Me.mnuAction.Size = New System.Drawing.Size(160, 22)
        Me.mnuAction.Text = "アクション"
        '
        'mnuAgent
        '
        Me.mnuAgent.CheckOnClick = True
        Me.mnuAgent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.mnuAgent.Name = "mnuAgent"
        Me.mnuAgent.Size = New System.Drawing.Size(160, 22)
        Me.mnuAgent.Text = "エージェント"
        '
        'mnuFolder
        '
        Me.mnuFolder.CheckOnClick = True
        Me.mnuFolder.Name = "mnuFolder"
        Me.mnuFolder.Size = New System.Drawing.Size(160, 22)
        Me.mnuFolder.Text = "フォルダー"
        '
        'mnuImgsource
        '
        Me.mnuImgsource.CheckOnClick = True
        Me.mnuImgsource.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.mnuImgsource.Name = "mnuImgsource"
        Me.mnuImgsource.Size = New System.Drawing.Size(160, 22)
        Me.mnuImgsource.Text = "イメージソース"
        '
        'mnuIcon
        '
        Me.mnuIcon.CheckOnClick = True
        Me.mnuIcon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.mnuIcon.Name = "mnuIcon"
        Me.mnuIcon.Size = New System.Drawing.Size(160, 22)
        Me.mnuIcon.Text = "アイコン"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(60, 22)
        Me.ToolStripButton3.Text = "設計文書"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(60, 22)
        Me.ToolStripButton4.Text = "DXL解析"
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton6.Image = CType(resources.GetObject("ToolStripButton6.Image"), System.Drawing.Image)
        Me.ToolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.Size = New System.Drawing.Size(60, 22)
        Me.ToolStripButton6.Text = "文書取得"
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton7.Image = CType(resources.GetObject("ToolStripButton7.Image"), System.Drawing.Image)
        Me.ToolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(58, 22)
        Me.ToolStripButton7.Text = "Address"
        Me.ToolStripButton7.ToolTipText = "Address"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 25)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.TabControl1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.PropertyGrid1)
        Me.SplitContainer1.Size = New System.Drawing.Size(886, 564)
        Me.SplitContainer1.SplitterDistance = 355
        Me.SplitContainer1.SplitterWidth = 6
        Me.SplitContainer1.TabIndex = 6
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tabForm)
        Me.TabControl1.Controls.Add(Me.tabView)
        Me.TabControl1.Controls.Add(Me.tabAction)
        Me.TabControl1.Controls.Add(Me.tabDocument)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.HotTrack = True
        Me.TabControl1.ItemSize = New System.Drawing.Size(48, 18)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.ShowToolTips = True
        Me.TabControl1.Size = New System.Drawing.Size(355, 564)
        Me.TabControl1.TabIndex = 3
        '
        'tabForm
        '
        Me.tabForm.Controls.Add(Me.treForm)
        Me.tabForm.Location = New System.Drawing.Point(4, 22)
        Me.tabForm.Name = "tabForm"
        Me.tabForm.Padding = New System.Windows.Forms.Padding(3)
        Me.tabForm.Size = New System.Drawing.Size(347, 538)
        Me.tabForm.TabIndex = 0
        Me.tabForm.Text = "フォーム"
        Me.tabForm.UseVisualStyleBackColor = True
        '
        'treForm
        '
        Me.treForm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.treForm.Location = New System.Drawing.Point(3, 3)
        Me.treForm.Name = "treForm"
        Me.treForm.Size = New System.Drawing.Size(341, 532)
        Me.treForm.TabIndex = 0
        '
        'tabView
        '
        Me.tabView.Controls.Add(Me.treView)
        Me.tabView.Location = New System.Drawing.Point(4, 22)
        Me.tabView.Name = "tabView"
        Me.tabView.Padding = New System.Windows.Forms.Padding(3)
        Me.tabView.Size = New System.Drawing.Size(347, 538)
        Me.tabView.TabIndex = 1
        Me.tabView.Text = "ビュー"
        Me.tabView.UseVisualStyleBackColor = True
        '
        'treView
        '
        Me.treView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.treView.Location = New System.Drawing.Point(3, 3)
        Me.treView.Name = "treView"
        Me.treView.Size = New System.Drawing.Size(341, 532)
        Me.treView.TabIndex = 0
        '
        'tabAction
        '
        Me.tabAction.Controls.Add(Me.treeAction)
        Me.tabAction.Location = New System.Drawing.Point(4, 22)
        Me.tabAction.Name = "tabAction"
        Me.tabAction.Size = New System.Drawing.Size(347, 538)
        Me.tabAction.TabIndex = 3
        Me.tabAction.Text = "コード"
        Me.tabAction.UseVisualStyleBackColor = True
        '
        'treeAction
        '
        Me.treeAction.Dock = System.Windows.Forms.DockStyle.Fill
        Me.treeAction.Location = New System.Drawing.Point(0, 0)
        Me.treeAction.Name = "treeAction"
        Me.treeAction.Size = New System.Drawing.Size(347, 538)
        Me.treeAction.TabIndex = 0
        '
        'tabDocument
        '
        Me.tabDocument.Controls.Add(Me.treeDoc)
        Me.tabDocument.Location = New System.Drawing.Point(4, 22)
        Me.tabDocument.Name = "tabDocument"
        Me.tabDocument.Size = New System.Drawing.Size(347, 538)
        Me.tabDocument.TabIndex = 2
        Me.tabDocument.Text = "設計文書"
        Me.tabDocument.UseVisualStyleBackColor = True
        '
        'treeDoc
        '
        Me.treeDoc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.treeDoc.Location = New System.Drawing.Point(0, 0)
        Me.treeDoc.Name = "treeDoc"
        Me.treeDoc.Size = New System.Drawing.Size(347, 538)
        Me.treeDoc.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.treeServer)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(347, 538)
        Me.TabPage1.TabIndex = 4
        Me.TabPage1.Text = "サーバー"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'treeServer
        '
        Me.treeServer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.treeServer.Location = New System.Drawing.Point(0, 0)
        Me.treeServer.Name = "treeServer"
        Me.treeServer.Size = New System.Drawing.Size(347, 538)
        Me.treeServer.TabIndex = 1
        '
        'PropertyGrid1
        '
        Me.PropertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PropertyGrid1.Location = New System.Drawing.Point(0, 0)
        Me.PropertyGrid1.Name = "PropertyGrid1"
        Me.PropertyGrid1.Size = New System.Drawing.Size(525, 564)
        Me.PropertyGrid1.TabIndex = 2
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.DefaultExt = "dxl"
        Me.SaveFileDialog1.Filter = "DXLファイル(*.dxl)|*.dxl"
        '
        'mnuAllDesignItem
        '
        Me.mnuAllDesignItem.CheckOnClick = True
        Me.mnuAllDesignItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.mnuAllDesignItem.Name = "mnuAllDesignItem"
        Me.mnuAllDesignItem.Size = New System.Drawing.Size(160, 22)
        Me.mnuAllDesignItem.Text = "すべて設計情報"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(886, 589)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "MainForm"
        Me.Text = "Form1"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.tabForm.ResumeLayout(False)
        Me.tabView.ResumeLayout(False)
        Me.tabAction.ResumeLayout(False)
        Me.tabDocument.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnOpen As System.Windows.Forms.ToolStripButton
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabForm As System.Windows.Forms.TabPage
    Friend WithEvents tabView As System.Windows.Forms.TabPage
    Friend WithEvents PropertyGrid1 As System.Windows.Forms.PropertyGrid
    Friend WithEvents treForm As System.Windows.Forms.TreeView
    Friend WithEvents treView As System.Windows.Forms.TreeView
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents tabDocument As System.Windows.Forms.TabPage
    Friend WithEvents treeDoc As System.Windows.Forms.TreeView
    Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents mnuForm As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuView As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDocument As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuImgsource As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAction As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFolder As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAgent As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnExportAll As System.Windows.Forms.ToolStripButton
    Friend WithEvents tabAction As System.Windows.Forms.TabPage
    Friend WithEvents treeAction As System.Windows.Forms.TreeView
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuIcon As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton6 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripButton
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents treeServer As System.Windows.Forms.TreeView
    Friend WithEvents mnuAllDesignItem As System.Windows.Forms.ToolStripMenuItem

End Class
