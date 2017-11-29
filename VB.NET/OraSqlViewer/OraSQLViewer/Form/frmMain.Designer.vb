<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.ToolBar1 = New System.Windows.Forms.ToolBar()
        Me.tvwDb = New System.Windows.Forms.TreeView()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.mnuTabMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MNU_TAB_COLSE = New System.Windows.Forms.ToolStripMenuItem()
        Me.MNU_TAB_COLSEALL = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.mnuTree = New System.Windows.Forms.ContextMenu()
        Me.mnu_OpenObject = New System.Windows.Forms.MenuItem()
        Me.mnu_OpenView = New System.Windows.Forms.MenuItem()
        Me.MNU_ADD_CATE = New System.Windows.Forms.MenuItem()
        Me.MNU_ADD_CATEITEM = New System.Windows.Forms.MenuItem()
        Me.MNU_DELETE_CATE = New System.Windows.Forms.MenuItem()
        Me.MNU_MOVETO_CATE = New System.Windows.Forms.MenuItem()
        Me.MNU_REFRASH = New System.Windows.Forms.MenuItem()
        Me.MNU_CHANGE_NAME = New System.Windows.Forms.MenuItem()
        Me.mnuGetDDL = New System.Windows.Forms.MenuItem()
        Me.mnuSQLCreate = New System.Windows.Forms.MenuItem()
        Me.mnuSelectSql = New System.Windows.Forms.MenuItem()
        Me.MainMenu1 = New System.Windows.Forms.MainMenu(Me.components)
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuConnect = New System.Windows.Forms.MenuItem()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.mnuNew = New System.Windows.Forms.MenuItem()
        Me.mnuOpen = New System.Windows.Forms.MenuItem()
        Me.mnuSave = New System.Windows.Forms.MenuItem()
        Me.MenuItem2 = New System.Windows.Forms.MenuItem()
        Me.mnuClose = New System.Windows.Forms.MenuItem()
        Me.MenuItem6 = New System.Windows.Forms.MenuItem()
        Me.mnuFindPrev = New System.Windows.Forms.MenuItem()
        Me.mnuFindNext = New System.Windows.Forms.MenuItem()
        Me.mnuFindBegin = New System.Windows.Forms.MenuItem()
        Me.MenuItem3 = New System.Windows.Forms.MenuItem()
        Me.mnuRun = New System.Windows.Forms.MenuItem()
        Me.mnuProcedureRun = New System.Windows.Forms.MenuItem()
        Me.MenuItem7 = New System.Windows.Forms.MenuItem()
        Me.mnuCancel = New System.Windows.Forms.MenuItem()
        Me.MenuItem4 = New System.Windows.Forms.MenuItem()
        Me.MenuItem9 = New System.Windows.Forms.MenuItem()
        Me.mnuF1 = New System.Windows.Forms.MenuItem()
        Me.MenuItem10 = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.MainSplitContainer = New System.Windows.Forms.SplitContainer()
        Me.LeftSplitContainer = New System.Windows.Forms.SplitContainer()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.tabMain = New SQLViewer.MyTabControl()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.statusBarMessage = New System.Windows.Forms.ToolStripStatusLabel()
        Me.QueryWorker = New System.ComponentModel.BackgroundWorker()
        Me.txtFindWord = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnFindDown = New System.Windows.Forms.Button()
        Me.btnFindUp = New System.Windows.Forms.Button()
        Me.cmbDataBase = New SQLViewer.IconCombBox()
        Me.mnuDDLRun = New System.Windows.Forms.MenuItem()
        Me.mnuTabMenu.SuspendLayout()
        CType(Me.MainSplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MainSplitContainer.Panel1.SuspendLayout()
        Me.MainSplitContainer.Panel2.SuspendLayout()
        Me.MainSplitContainer.SuspendLayout()
        CType(Me.LeftSplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LeftSplitContainer.Panel1.SuspendLayout()
        Me.LeftSplitContainer.Panel2.SuspendLayout()
        Me.LeftSplitContainer.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolBar1
        '
        Me.ToolBar1.AutoSize = False
        Me.ToolBar1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ToolBar1.DropDownArrows = True
        Me.ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.ToolBar1.Name = "ToolBar1"
        Me.ToolBar1.ShowToolTips = True
        Me.ToolBar1.Size = New System.Drawing.Size(808, 32)
        Me.ToolBar1.TabIndex = 1
        Me.ToolBar1.Wrappable = False
        '
        'tvwDb
        '
        Me.tvwDb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvwDb.HideSelection = False
        Me.tvwDb.ImageIndex = 0
        Me.tvwDb.ImageList = Me.ImageList1
        Me.tvwDb.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.tvwDb.Location = New System.Drawing.Point(0, 0)
        Me.tvwDb.Name = "tvwDb"
        Me.tvwDb.SelectedImageIndex = 0
        Me.tvwDb.Size = New System.Drawing.Size(269, 218)
        Me.tvwDb.TabIndex = 2
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.White
        Me.ImageList1.Images.SetKeyName(0, "")
        Me.ImageList1.Images.SetKeyName(1, "")
        Me.ImageList1.Images.SetKeyName(2, "")
        Me.ImageList1.Images.SetKeyName(3, "")
        Me.ImageList1.Images.SetKeyName(4, "")
        Me.ImageList1.Images.SetKeyName(5, "")
        Me.ImageList1.Images.SetKeyName(6, "")
        Me.ImageList1.Images.SetKeyName(7, "")
        Me.ImageList1.Images.SetKeyName(8, "")
        Me.ImageList1.Images.SetKeyName(9, "")
        Me.ImageList1.Images.SetKeyName(10, "")
        Me.ImageList1.Images.SetKeyName(11, "")
        Me.ImageList1.Images.SetKeyName(12, "Packages.bmp")
        Me.ImageList1.Images.SetKeyName(13, "PackageBodies.bmp")
        Me.ImageList1.Images.SetKeyName(14, "Package.bmp")
        Me.ImageList1.Images.SetKeyName(15, "PackageBody.bmp")
        Me.ImageList1.Images.SetKeyName(16, "Sequences.bmp")
        Me.ImageList1.Images.SetKeyName(17, "Sequence.bmp")
        '
        'mnuTabMenu
        '
        Me.mnuTabMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MNU_TAB_COLSE, Me.MNU_TAB_COLSEALL})
        Me.mnuTabMenu.Name = "mnuTabMenu"
        Me.mnuTabMenu.Size = New System.Drawing.Size(130, 48)
        '
        'MNU_TAB_COLSE
        '
        Me.MNU_TAB_COLSE.Name = "MNU_TAB_COLSE"
        Me.MNU_TAB_COLSE.Size = New System.Drawing.Size(129, 22)
        Me.MNU_TAB_COLSE.Text = "閉じる"
        '
        'MNU_TAB_COLSEALL
        '
        Me.MNU_TAB_COLSEALL.Name = "MNU_TAB_COLSEALL"
        Me.MNU_TAB_COLSEALL.Size = New System.Drawing.Size(129, 22)
        Me.MNU_TAB_COLSEALL.Text = "すべて閉じる"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 12)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "データベース"
        '
        'mnuTree
        '
        Me.mnuTree.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnu_OpenObject, Me.mnu_OpenView, Me.MNU_ADD_CATE, Me.MNU_ADD_CATEITEM, Me.MNU_DELETE_CATE, Me.MNU_MOVETO_CATE, Me.MNU_REFRASH, Me.MNU_CHANGE_NAME, Me.mnuGetDDL, Me.mnuSQLCreate})
        '
        'mnu_OpenObject
        '
        Me.mnu_OpenObject.Index = 0
        Me.mnu_OpenObject.Text = "開く"
        '
        'mnu_OpenView
        '
        Me.mnu_OpenView.Index = 1
        Me.mnu_OpenView.Text = "ビューを開く..."
        '
        'MNU_ADD_CATE
        '
        Me.MNU_ADD_CATE.Index = 2
        Me.MNU_ADD_CATE.Text = "カテゴリ追加..."
        '
        'MNU_ADD_CATEITEM
        '
        Me.MNU_ADD_CATEITEM.Index = 3
        Me.MNU_ADD_CATEITEM.Text = "このカテゴリに追加..."
        '
        'MNU_DELETE_CATE
        '
        Me.MNU_DELETE_CATE.Index = 4
        Me.MNU_DELETE_CATE.Text = "カテゴリ削除"
        '
        'MNU_MOVETO_CATE
        '
        Me.MNU_MOVETO_CATE.Index = 5
        Me.MNU_MOVETO_CATE.Text = "カテゴリに移動"
        '
        'MNU_REFRASH
        '
        Me.MNU_REFRASH.Index = 6
        Me.MNU_REFRASH.Text = "最新の情報に更新"
        '
        'MNU_CHANGE_NAME
        '
        Me.MNU_CHANGE_NAME.Index = 7
        Me.MNU_CHANGE_NAME.Text = "名前の変更"
        '
        'mnuGetDDL
        '
        Me.mnuGetDDL.Index = 8
        Me.mnuGetDDL.Text = "DDLを取得"
        '
        'mnuSQLCreate
        '
        Me.mnuSQLCreate.Index = 9
        Me.mnuSQLCreate.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuSelectSql})
        Me.mnuSQLCreate.Text = "SQL文作成"
        '
        'mnuSelectSql
        '
        Me.mnuSelectSql.Index = 0
        Me.mnuSelectSql.Text = "Select文"
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFile, Me.MenuItem6, Me.MenuItem3, Me.MenuItem4, Me.MenuItem9})
        '
        'mnuFile
        '
        Me.mnuFile.Index = 0
        Me.mnuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuConnect, Me.MenuItem1, Me.mnuNew, Me.mnuOpen, Me.mnuSave, Me.MenuItem2, Me.mnuClose})
        Me.mnuFile.Text = "ファイル(&F)"
        '
        'mnuConnect
        '
        Me.mnuConnect.Index = 0
        Me.mnuConnect.Text = "接続..."
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 1
        Me.MenuItem1.Text = "-"
        '
        'mnuNew
        '
        Me.mnuNew.Index = 2
        Me.mnuNew.Shortcut = System.Windows.Forms.Shortcut.CtrlN
        Me.mnuNew.Text = "新規作成(&N)"
        '
        'mnuOpen
        '
        Me.mnuOpen.Index = 3
        Me.mnuOpen.Text = "開く(&O)"
        '
        'mnuSave
        '
        Me.mnuSave.Index = 4
        Me.mnuSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS
        Me.mnuSave.Text = "上書き保存(&S)"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 5
        Me.MenuItem2.Text = "-"
        '
        'mnuClose
        '
        Me.mnuClose.Index = 6
        Me.mnuClose.Shortcut = System.Windows.Forms.Shortcut.AltF4
        Me.mnuClose.Text = "終了(&X)"
        '
        'MenuItem6
        '
        Me.MenuItem6.Index = 1
        Me.MenuItem6.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFindPrev, Me.mnuFindNext, Me.mnuFindBegin})
        Me.MenuItem6.Text = "編集"
        '
        'mnuFindPrev
        '
        Me.mnuFindPrev.Index = 0
        Me.mnuFindPrev.Shortcut = System.Windows.Forms.Shortcut.ShiftF3
        Me.mnuFindPrev.Text = "前検索"
        '
        'mnuFindNext
        '
        Me.mnuFindNext.Index = 1
        Me.mnuFindNext.Shortcut = System.Windows.Forms.Shortcut.F3
        Me.mnuFindNext.Text = "次検索"
        '
        'mnuFindBegin
        '
        Me.mnuFindBegin.Index = 2
        Me.mnuFindBegin.Shortcut = System.Windows.Forms.Shortcut.CtrlF3
        Me.mnuFindBegin.Text = "検索..."
        Me.mnuFindBegin.Visible = False
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 2
        Me.MenuItem3.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuRun, Me.mnuProcedureRun, Me.mnuDDLRun, Me.MenuItem7, Me.mnuCancel})
        Me.MenuItem3.Text = "クエリ(&Q)"
        '
        'mnuRun
        '
        Me.mnuRun.Index = 0
        Me.mnuRun.Shortcut = System.Windows.Forms.Shortcut.CtrlE
        Me.mnuRun.ShowShortcut = False
        Me.mnuRun.Text = "実行(&R)"
        '
        'mnuProcedureRun
        '
        Me.mnuProcedureRun.Index = 1
        Me.mnuProcedureRun.Shortcut = System.Windows.Forms.Shortcut.F5
        Me.mnuProcedureRun.Text = "プロシージャ実行"
        '
        'MenuItem7
        '
        Me.MenuItem7.Index = 3
        Me.MenuItem7.Text = "-"
        '
        'mnuCancel
        '
        Me.mnuCancel.Index = 4
        Me.mnuCancel.Shortcut = System.Windows.Forms.Shortcut.CtrlQ
        Me.mnuCancel.Text = "キャンセル(&C)"
        '
        'MenuItem4
        '
        Me.MenuItem4.Index = 3
        Me.MenuItem4.Text = "ツール"
        '
        'MenuItem9
        '
        Me.MenuItem9.Index = 4
        Me.MenuItem9.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuF1, Me.MenuItem10, Me.mnuAbout})
        Me.MenuItem9.Text = "ヘルプ(&H)"
        '
        'mnuF1
        '
        Me.mnuF1.Index = 0
        Me.mnuF1.Shortcut = System.Windows.Forms.Shortcut.F1
        Me.mnuF1.Text = "ヘルプ(&H)"
        '
        'MenuItem10
        '
        Me.MenuItem10.Index = 1
        Me.MenuItem10.Text = "-"
        '
        'mnuAbout
        '
        Me.mnuAbout.Index = 2
        Me.mnuAbout.Text = "バージョン情報..."
        '
        'MainSplitContainer
        '
        Me.MainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainSplitContainer.Location = New System.Drawing.Point(0, 32)
        Me.MainSplitContainer.Name = "MainSplitContainer"
        '
        'MainSplitContainer.Panel1
        '
        Me.MainSplitContainer.Panel1.Controls.Add(Me.LeftSplitContainer)
        '
        'MainSplitContainer.Panel2
        '
        Me.MainSplitContainer.Panel2.Controls.Add(Me.tabMain)
        Me.MainSplitContainer.Size = New System.Drawing.Size(808, 364)
        Me.MainSplitContainer.SplitterDistance = 269
        Me.MainSplitContainer.TabIndex = 8
        '
        'LeftSplitContainer
        '
        Me.LeftSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LeftSplitContainer.Location = New System.Drawing.Point(0, 0)
        Me.LeftSplitContainer.Name = "LeftSplitContainer"
        Me.LeftSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'LeftSplitContainer.Panel1
        '
        Me.LeftSplitContainer.Panel1.Controls.Add(Me.tvwDb)
        '
        'LeftSplitContainer.Panel2
        '
        Me.LeftSplitContainer.Panel2.Controls.Add(Me.DataGridView1)
        Me.LeftSplitContainer.Size = New System.Drawing.Size(269, 364)
        Me.LeftSplitContainer.SplitterDistance = 218
        Me.LeftSplitContainer.TabIndex = 0
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.Window
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersWidth = 22
        Me.DataGridView1.RowTemplate.Height = 21
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DataGridView1.Size = New System.Drawing.Size(269, 142)
        Me.DataGridView1.TabIndex = 0
        '
        'tabMain
        '
        Me.tabMain.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.tabMain.ContextMenuStrip = Me.mnuTabMenu
        Me.tabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabMain.HotTrack = True
        Me.tabMain.ImageList = Me.ImageList1
        Me.tabMain.Location = New System.Drawing.Point(0, 0)
        Me.tabMain.Name = "tabMain"
        Me.tabMain.Padding = New System.Drawing.Point(2, 2)
        Me.tabMain.SelectedIndex = 0
        Me.tabMain.Size = New System.Drawing.Size(535, 364)
        Me.tabMain.TabIndex = 2
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.statusBarMessage})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 396)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(808, 22)
        Me.StatusStrip1.TabIndex = 10
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'statusBarMessage
        '
        Me.statusBarMessage.AutoSize = False
        Me.statusBarMessage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.statusBarMessage.Name = "statusBarMessage"
        Me.statusBarMessage.Size = New System.Drawing.Size(300, 17)
        Me.statusBarMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'QueryWorker
        '
        '
        'txtFindWord
        '
        Me.txtFindWord.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFindWord.Location = New System.Drawing.Point(617, 6)
        Me.txtFindWord.Name = "txtFindWord"
        Me.txtFindWord.Size = New System.Drawing.Size(126, 19)
        Me.txtFindWord.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(582, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 12)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "検索"
        '
        'btnFindDown
        '
        Me.btnFindDown.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFindDown.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnFindDown.Font = New System.Drawing.Font("MS UI Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnFindDown.Location = New System.Drawing.Point(747, 6)
        Me.btnFindDown.Name = "btnFindDown"
        Me.btnFindDown.Size = New System.Drawing.Size(21, 18)
        Me.btnFindDown.TabIndex = 14
        Me.btnFindDown.Text = "▼"
        Me.btnFindDown.UseVisualStyleBackColor = True
        '
        'btnFindUp
        '
        Me.btnFindUp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFindUp.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnFindUp.Font = New System.Drawing.Font("MS UI Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnFindUp.Location = New System.Drawing.Point(774, 6)
        Me.btnFindUp.Name = "btnFindUp"
        Me.btnFindUp.Size = New System.Drawing.Size(21, 18)
        Me.btnFindUp.TabIndex = 15
        Me.btnFindUp.Text = "▲"
        Me.btnFindUp.UseVisualStyleBackColor = True
        '
        'cmbDataBase
        '
        Me.cmbDataBase.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbDataBase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDataBase.Icon = Nothing
        Me.cmbDataBase.ItemHeight = 16
        Me.cmbDataBase.Location = New System.Drawing.Point(73, 3)
        Me.cmbDataBase.Name = "cmbDataBase"
        Me.cmbDataBase.Size = New System.Drawing.Size(151, 22)
        Me.cmbDataBase.TabIndex = 5
        '
        'mnuDDLRun
        '
        Me.mnuDDLRun.Index = 2
        Me.mnuDDLRun.Shortcut = System.Windows.Forms.Shortcut.F6
        Me.mnuDDLRun.Text = "DDL実行"
        '
        'frmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
        Me.ClientSize = New System.Drawing.Size(808, 418)
        Me.Controls.Add(Me.btnFindUp)
        Me.Controls.Add(Me.btnFindDown)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtFindWord)
        Me.Controls.Add(Me.MainSplitContainer)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbDataBase)
        Me.Controls.Add(Me.ToolBar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Menu = Me.MainMenu1
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Oracle SQL Viewer"
        Me.mnuTabMenu.ResumeLayout(False)
        Me.MainSplitContainer.Panel1.ResumeLayout(False)
        Me.MainSplitContainer.Panel2.ResumeLayout(False)
        CType(Me.MainSplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MainSplitContainer.ResumeLayout(False)
        Me.LeftSplitContainer.Panel1.ResumeLayout(False)
        Me.LeftSplitContainer.Panel2.ResumeLayout(False)
        CType(Me.LeftSplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LeftSplitContainer.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolBar1 As System.Windows.Forms.ToolBar
    Friend WithEvents tvwDb As System.Windows.Forms.TreeView
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbDataBase As IconCombBox
    Friend WithEvents mnuTabMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MNU_TAB_COLSE As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MNU_TAB_COLSEALL As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTree As System.Windows.Forms.ContextMenu
    Friend WithEvents MNU_ADD_CATE As System.Windows.Forms.MenuItem
    Friend WithEvents MNU_ADD_CATEITEM As System.Windows.Forms.MenuItem
    Friend WithEvents MNU_MOVETO_CATE As System.Windows.Forms.MenuItem
    Friend WithEvents MNU_DELETE_CATE As System.Windows.Forms.MenuItem
    Friend WithEvents MNU_REFRASH As System.Windows.Forms.MenuItem
    Friend WithEvents MNU_CHANGE_NAME As System.Windows.Forms.MenuItem
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents mnuFile As System.Windows.Forms.MenuItem
    Friend WithEvents mnuConnect As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuNew As System.Windows.Forms.MenuItem
    Friend WithEvents mnuOpen As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSave As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuClose As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuRun As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem6 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuFindPrev As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem9 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuAbout As System.Windows.Forms.MenuItem
    Friend WithEvents mnuF1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem10 As System.Windows.Forms.MenuItem
    Friend WithEvents mnu_OpenObject As System.Windows.Forms.MenuItem
    Friend WithEvents mnu_OpenView As System.Windows.Forms.MenuItem
    Friend WithEvents mnuGetDDL As System.Windows.Forms.MenuItem
    Friend WithEvents MainSplitContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents LeftSplitContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents tabMain As MyTabControl
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents mnuSQLCreate As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSelectSql As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCancel As System.Windows.Forms.MenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents statusBarMessage As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents QueryWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents mnuFindNext As System.Windows.Forms.MenuItem
    Friend WithEvents txtFindWord As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnFindDown As System.Windows.Forms.Button
    Friend WithEvents btnFindUp As System.Windows.Forms.Button
    Friend WithEvents mnuFindBegin As System.Windows.Forms.MenuItem
    Friend WithEvents mnuProcedureRun As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem7 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuDDLRun As System.Windows.Forms.MenuItem
End Class
