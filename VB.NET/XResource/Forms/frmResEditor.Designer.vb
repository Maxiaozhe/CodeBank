<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmResEditor
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

    'Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使用して変更できます。  
    'コード エディタを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmResEditor))
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuOpen = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuCloseFile = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.mnuClose = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuSearch = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuSearchCancel = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.mnuAddResource = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuTools = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuBuild = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuBuildAll = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuBuildString = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuImport = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuExport = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuExportXml = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuExportCSV = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuExportResx = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuExportResource = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuSpliter1 = New System.Windows.Forms.ToolStripSeparator
        Me.mnuLanguage = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuOptions = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuHelp = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuVersion = New System.Windows.Forms.ToolStripMenuItem
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tabStringRes = New System.Windows.Forms.TabPage
        Me.tabOtherRes = New System.Windows.Forms.TabPage
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.lstOtherRes = New System.Windows.Forms.ListView
        Me.colName = New System.Windows.Forms.ColumnHeader
        Me.colValue = New System.Windows.Forms.ColumnHeader
        Me.colFile = New System.Windows.Forms.ColumnHeader
        Me.splProperty = New System.Windows.Forms.SplitContainer
        Me.PictureboxPreview = New System.Windows.Forms.PictureBox
        Me.PropertyGrid1 = New System.Windows.Forms.PropertyGrid
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.toolBar = New System.Windows.Forms.ToolStrip
        Me.toolOpen = New System.Windows.Forms.ToolStripButton
        Me.toolSpliter1 = New System.Windows.Forms.ToolStripSeparator
        Me.toolBuild = New System.Windows.Forms.ToolStripDropDownButton
        Me.toolBuildAll = New System.Windows.Forms.ToolStripMenuItem
        Me.toolBuildString = New System.Windows.Forms.ToolStripMenuItem
        Me.toolImport = New System.Windows.Forms.ToolStripButton
        Me.toolExport = New System.Windows.Forms.ToolStripSplitButton
        Me.toolExportXml = New System.Windows.Forms.ToolStripMenuItem
        Me.toolExportCsv = New System.Windows.Forms.ToolStripMenuItem
        Me.toolExportResx = New System.Windows.Forms.ToolStripMenuItem
        Me.toolExportResource = New System.Windows.Forms.ToolStripMenuItem
        Me.toolSpliter2 = New System.Windows.Forms.ToolStripSeparator
        Me.toolAddRes = New System.Windows.Forms.ToolStripButton
        Me.toolDelete = New System.Windows.Forms.ToolStripButton
        Me.toolSpliter3 = New System.Windows.Forms.ToolStripSeparator
        Me.toolLabel = New System.Windows.Forms.ToolStripLabel
        Me.cmblaguage = New System.Windows.Forms.ToolStripComboBox
        Me.dlgSaveToFolder = New System.Windows.Forms.FolderBrowserDialog
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tabStringRes.SuspendLayout()
        Me.tabOtherRes.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.splProperty.Panel1.SuspendLayout()
        Me.splProperty.Panel2.SuspendLayout()
        Me.splProperty.SuspendLayout()
        CType(Me.PictureboxPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.toolBar.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        resources.ApplyResources(Me.DataGridView1, "DataGridView1")
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 21
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.DefaultExt = "xml"
        resources.ApplyResources(Me.SaveFileDialog1, "SaveFileDialog1")
        Me.SaveFileDialog1.FilterIndex = 2
        Me.SaveFileDialog1.SupportMultiDottedExtensions = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.MenuBar
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile, Me.mnuEdit, Me.mnuTools, Me.mnuHelp})
        resources.ApplyResources(Me.MenuStrip1, "MenuStrip1")
        Me.MenuStrip1.Name = "MenuStrip1"
        '
        'mnuFile
        '
        Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuOpen, Me.mnuCloseFile, Me.ToolStripSeparator1, Me.mnuClose})
        Me.mnuFile.Name = "mnuFile"
        resources.ApplyResources(Me.mnuFile, "mnuFile")
        '
        'mnuOpen
        '
        Me.mnuOpen.Image = Global.XResource.My.Resources.Resources.Open
        resources.ApplyResources(Me.mnuOpen, "mnuOpen")
        Me.mnuOpen.Name = "mnuOpen"
        '
        'mnuCloseFile
        '
        Me.mnuCloseFile.Name = "mnuCloseFile"
        resources.ApplyResources(Me.mnuCloseFile, "mnuCloseFile")
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        resources.ApplyResources(Me.ToolStripSeparator1, "ToolStripSeparator1")
        '
        'mnuClose
        '
        Me.mnuClose.Name = "mnuClose"
        resources.ApplyResources(Me.mnuClose, "mnuClose")
        '
        'mnuEdit
        '
        Me.mnuEdit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSearch, Me.mnuSearchCancel, Me.ToolStripSeparator2, Me.mnuAddResource, Me.mnuDelete})
        Me.mnuEdit.Name = "mnuEdit"
        resources.ApplyResources(Me.mnuEdit, "mnuEdit")
        '
        'mnuSearch
        '
        Me.mnuSearch.Name = "mnuSearch"
        resources.ApplyResources(Me.mnuSearch, "mnuSearch")
        '
        'mnuSearchCancel
        '
        Me.mnuSearchCancel.Name = "mnuSearchCancel"
        resources.ApplyResources(Me.mnuSearchCancel, "mnuSearchCancel")
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        resources.ApplyResources(Me.ToolStripSeparator2, "ToolStripSeparator2")
        '
        'mnuAddResource
        '
        Me.mnuAddResource.Image = Global.XResource.My.Resources.Resources.AddResource
        Me.mnuAddResource.Name = "mnuAddResource"
        resources.ApplyResources(Me.mnuAddResource, "mnuAddResource")
        '
        'mnuDelete
        '
        Me.mnuDelete.Image = Global.XResource.My.Resources.Resources.Delete
        resources.ApplyResources(Me.mnuDelete, "mnuDelete")
        Me.mnuDelete.Name = "mnuDelete"
        '
        'mnuTools
        '
        Me.mnuTools.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuBuild, Me.mnuImport, Me.mnuExport, Me.mnuSpliter1, Me.mnuLanguage, Me.mnuOptions})
        Me.mnuTools.Name = "mnuTools"
        resources.ApplyResources(Me.mnuTools, "mnuTools")
        '
        'mnuBuild
        '
        Me.mnuBuild.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuBuildAll, Me.mnuBuildString})
        Me.mnuBuild.Image = Global.XResource.My.Resources.Resources.Build
        resources.ApplyResources(Me.mnuBuild, "mnuBuild")
        Me.mnuBuild.Name = "mnuBuild"
        '
        'mnuBuildAll
        '
        Me.mnuBuildAll.Name = "mnuBuildAll"
        resources.ApplyResources(Me.mnuBuildAll, "mnuBuildAll")
        '
        'mnuBuildString
        '
        Me.mnuBuildString.Name = "mnuBuildString"
        resources.ApplyResources(Me.mnuBuildString, "mnuBuildString")
        '
        'mnuImport
        '
        Me.mnuImport.Image = Global.XResource.My.Resources.Resources.Import
        resources.ApplyResources(Me.mnuImport, "mnuImport")
        Me.mnuImport.Name = "mnuImport"
        '
        'mnuExport
        '
        Me.mnuExport.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuExportXml, Me.mnuExportCSV, Me.mnuExportResx, Me.mnuExportResource})
        Me.mnuExport.Image = Global.XResource.My.Resources.Resources.Export
        resources.ApplyResources(Me.mnuExport, "mnuExport")
        Me.mnuExport.Name = "mnuExport"
        '
        'mnuExportXml
        '
        Me.mnuExportXml.Name = "mnuExportXml"
        resources.ApplyResources(Me.mnuExportXml, "mnuExportXml")
        '
        'mnuExportCSV
        '
        Me.mnuExportCSV.Name = "mnuExportCSV"
        resources.ApplyResources(Me.mnuExportCSV, "mnuExportCSV")
        '
        'mnuExportResx
        '
        Me.mnuExportResx.Name = "mnuExportResx"
        resources.ApplyResources(Me.mnuExportResx, "mnuExportResx")
        '
        'mnuExportResource
        '
        Me.mnuExportResource.Name = "mnuExportResource"
        resources.ApplyResources(Me.mnuExportResource, "mnuExportResource")
        '
        'mnuSpliter1
        '
        Me.mnuSpliter1.Name = "mnuSpliter1"
        resources.ApplyResources(Me.mnuSpliter1, "mnuSpliter1")
        '
        'mnuLanguage
        '
        Me.mnuLanguage.Name = "mnuLanguage"
        resources.ApplyResources(Me.mnuLanguage, "mnuLanguage")
        '
        'mnuOptions
        '
        Me.mnuOptions.Name = "mnuOptions"
        resources.ApplyResources(Me.mnuOptions, "mnuOptions")
        '
        'mnuHelp
        '
        Me.mnuHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuVersion})
        Me.mnuHelp.Name = "mnuHelp"
        resources.ApplyResources(Me.mnuHelp, "mnuHelp")
        '
        'mnuVersion
        '
        Me.mnuVersion.Name = "mnuVersion"
        resources.ApplyResources(Me.mnuVersion, "mnuVersion")
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tabStringRes)
        Me.TabControl1.Controls.Add(Me.tabOtherRes)
        resources.ApplyResources(Me.TabControl1, "TabControl1")
        Me.TabControl1.ImageList = Me.ImageList1
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        '
        'tabStringRes
        '
        Me.tabStringRes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tabStringRes.Controls.Add(Me.DataGridView1)
        resources.ApplyResources(Me.tabStringRes, "tabStringRes")
        Me.tabStringRes.Name = "tabStringRes"
        Me.tabStringRes.UseVisualStyleBackColor = True
        '
        'tabOtherRes
        '
        Me.tabOtherRes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tabOtherRes.Controls.Add(Me.SplitContainer1)
        resources.ApplyResources(Me.tabOtherRes, "tabOtherRes")
        Me.tabOtherRes.Name = "tabOtherRes"
        Me.tabOtherRes.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        resources.ApplyResources(Me.SplitContainer1, "SplitContainer1")
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.lstOtherRes)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.splProperty)
        '
        'lstOtherRes
        '
        Me.lstOtherRes.AllowColumnReorder = True
        Me.lstOtherRes.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colName, Me.colValue, Me.colFile})
        resources.ApplyResources(Me.lstOtherRes, "lstOtherRes")
        Me.lstOtherRes.FullRowSelect = True
        Me.lstOtherRes.GridLines = True
        Me.lstOtherRes.HideSelection = False
        Me.lstOtherRes.MultiSelect = False
        Me.lstOtherRes.Name = "lstOtherRes"
        Me.lstOtherRes.Sorting = System.Windows.Forms.SortOrder.Descending
        Me.lstOtherRes.UseCompatibleStateImageBehavior = False
        Me.lstOtherRes.View = System.Windows.Forms.View.Details
        '
        'colName
        '
        resources.ApplyResources(Me.colName, "colName")
        '
        'colValue
        '
        resources.ApplyResources(Me.colValue, "colValue")
        '
        'colFile
        '
        resources.ApplyResources(Me.colFile, "colFile")
        '
        'splProperty
        '
        resources.ApplyResources(Me.splProperty, "splProperty")
        Me.splProperty.Name = "splProperty"
        '
        'splProperty.Panel1
        '
        Me.splProperty.Panel1.Controls.Add(Me.PictureboxPreview)
        '
        'splProperty.Panel2
        '
        Me.splProperty.Panel2.Controls.Add(Me.PropertyGrid1)
        '
        'PictureboxPreview
        '
        Me.PictureboxPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.PictureboxPreview, "PictureboxPreview")
        Me.PictureboxPreview.Name = "PictureboxPreview"
        Me.PictureboxPreview.TabStop = False
        '
        'PropertyGrid1
        '
        resources.ApplyResources(Me.PropertyGrid1, "PropertyGrid1")
        Me.PropertyGrid1.Name = "PropertyGrid1"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.White
        Me.ImageList1.Images.SetKeyName(0, "StringRes.bmp")
        Me.ImageList1.Images.SetKeyName(1, "OtherRes.bmp")
        '
        'toolBar
        '
        Me.toolBar.BackgroundImage = Global.XResource.My.Resources.Resources.ToolBarBack
        Me.toolBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolOpen, Me.toolSpliter1, Me.toolBuild, Me.toolImport, Me.toolExport, Me.toolSpliter2, Me.toolAddRes, Me.toolDelete, Me.toolSpliter3, Me.toolLabel, Me.cmblaguage})
        Me.toolBar.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow
        resources.ApplyResources(Me.toolBar, "toolBar")
        Me.toolBar.Name = "toolBar"
        '
        'toolOpen
        '
        Me.toolOpen.Image = Global.XResource.My.Resources.Resources.Open
        resources.ApplyResources(Me.toolOpen, "toolOpen")
        Me.toolOpen.Name = "toolOpen"
        '
        'toolSpliter1
        '
        Me.toolSpliter1.Name = "toolSpliter1"
        resources.ApplyResources(Me.toolSpliter1, "toolSpliter1")
        '
        'toolBuild
        '
        Me.toolBuild.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolBuildAll, Me.toolBuildString})
        Me.toolBuild.Image = Global.XResource.My.Resources.Resources.Build
        resources.ApplyResources(Me.toolBuild, "toolBuild")
        Me.toolBuild.Name = "toolBuild"
        '
        'toolBuildAll
        '
        Me.toolBuildAll.Name = "toolBuildAll"
        resources.ApplyResources(Me.toolBuildAll, "toolBuildAll")
        '
        'toolBuildString
        '
        Me.toolBuildString.Name = "toolBuildString"
        resources.ApplyResources(Me.toolBuildString, "toolBuildString")
        '
        'toolImport
        '
        Me.toolImport.Image = Global.XResource.My.Resources.Resources.Import
        resources.ApplyResources(Me.toolImport, "toolImport")
        Me.toolImport.Name = "toolImport"
        '
        'toolExport
        '
        Me.toolExport.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolExportXml, Me.toolExportCsv, Me.toolExportResx, Me.toolExportResource})
        Me.toolExport.Image = Global.XResource.My.Resources.Resources.Export
        resources.ApplyResources(Me.toolExport, "toolExport")
        Me.toolExport.Name = "toolExport"
        '
        'toolExportXml
        '
        Me.toolExportXml.Name = "toolExportXml"
        resources.ApplyResources(Me.toolExportXml, "toolExportXml")
        '
        'toolExportCsv
        '
        Me.toolExportCsv.Name = "toolExportCsv"
        resources.ApplyResources(Me.toolExportCsv, "toolExportCsv")
        '
        'toolExportResx
        '
        Me.toolExportResx.Name = "toolExportResx"
        resources.ApplyResources(Me.toolExportResx, "toolExportResx")
        '
        'toolExportResource
        '
        Me.toolExportResource.Name = "toolExportResource"
        resources.ApplyResources(Me.toolExportResource, "toolExportResource")
        '
        'toolSpliter2
        '
        Me.toolSpliter2.Name = "toolSpliter2"
        resources.ApplyResources(Me.toolSpliter2, "toolSpliter2")
        '
        'toolAddRes
        '
        Me.toolAddRes.Image = Global.XResource.My.Resources.Resources.AddResource
        resources.ApplyResources(Me.toolAddRes, "toolAddRes")
        Me.toolAddRes.Name = "toolAddRes"
        '
        'toolDelete
        '
        Me.toolDelete.Image = Global.XResource.My.Resources.Resources.Delete
        resources.ApplyResources(Me.toolDelete, "toolDelete")
        Me.toolDelete.Name = "toolDelete"
        '
        'toolSpliter3
        '
        Me.toolSpliter3.Name = "toolSpliter3"
        resources.ApplyResources(Me.toolSpliter3, "toolSpliter3")
        '
        'toolLabel
        '
        Me.toolLabel.Margin = New System.Windows.Forms.Padding(0, 6, 0, 2)
        Me.toolLabel.Name = "toolLabel"
        resources.ApplyResources(Me.toolLabel, "toolLabel")
        '
        'cmblaguage
        '
        Me.cmblaguage.AutoToolTip = True
        Me.cmblaguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmblaguage.DropDownWidth = 288
        resources.ApplyResources(Me.cmblaguage, "cmblaguage")
        Me.cmblaguage.Margin = New System.Windows.Forms.Padding(1, 1, 1, 0)
        Me.cmblaguage.Name = "cmblaguage"
        '
        'frmResEditor
        '
        Me.AllowDrop = True
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.toolBar)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmResEditor"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.tabStringRes.ResumeLayout(False)
        Me.tabOtherRes.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.splProperty.Panel1.ResumeLayout(False)
        Me.splProperty.Panel2.ResumeLayout(False)
        Me.splProperty.ResumeLayout(False)
        CType(Me.PictureboxPreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.toolBar.ResumeLayout(False)
        Me.toolBar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuOpen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuImport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuClose As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTools As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuBuild As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuExport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuExportXml As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuExportCSV As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSpliter1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuOptions As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuVersion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolBar As System.Windows.Forms.ToolStrip
    Friend WithEvents toolOpen As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolImport As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSpliter1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolSpliter3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolExport As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents toolExportXml As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolExportCsv As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolSpliter2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolLabel As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cmblaguage As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents mnuSearchCancel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabStringRes As System.Windows.Forms.TabPage
    Friend WithEvents tabOtherRes As System.Windows.Forms.TabPage
    Friend WithEvents lstOtherRes As System.Windows.Forms.ListView
    Friend WithEvents PropertyGrid1 As System.Windows.Forms.PropertyGrid
    Friend WithEvents colName As System.Windows.Forms.ColumnHeader
    Friend WithEvents colValue As System.Windows.Forms.ColumnHeader
    Friend WithEvents colFile As System.Windows.Forms.ColumnHeader
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents mnuBuildAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuBuildString As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolBuild As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents toolBuildAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolBuildString As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents toolAddRes As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuAddResource As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuExportResx As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolExportResx As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dlgSaveToFolder As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents splProperty As System.Windows.Forms.SplitContainer
    Friend WithEvents PictureboxPreview As System.Windows.Forms.PictureBox
    Friend WithEvents mnuDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuExportResource As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolExportResource As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCloseFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLanguage As System.Windows.Forms.ToolStripMenuItem

End Class
