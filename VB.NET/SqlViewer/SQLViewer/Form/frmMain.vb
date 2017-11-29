Imports SQLViewer.DBAccess
Imports Utility = SQLViewer.DBAccess.Common.ToolUtility
Imports SQLViewer.DBAccess.DBSchema
Imports Env = SQLViewer.DBAccess.Common.Enviroment
Public Class frmMain
    Inherits System.Windows.Forms.Form

#Region " Windows フォーム デザイナで生成されたコード "

    Public Sub New()
        MyBase.New()

        ' この呼び出しは Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後に初期化を追加します。

    End Sub

    ' Form は dispose をオーバーライドしてコンポーネント一覧を消去します。
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    ' メモ : 以下のプロシージャは、Windows フォーム デザイナで必要です。
    ' Windows フォーム デザイナを使って変更してください。  
    ' コード エディタは使用しないでください。
    Friend WithEvents StatusBar1 As System.Windows.Forms.StatusBar
    Friend WithEvents ToolBar1 As System.Windows.Forms.ToolBar
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents tvwDb As System.Windows.Forms.TreeView
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbDataBase As IconCombBox
    Friend WithEvents tabMain As MyTabControl
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
    Friend WithEvents MenuItem7 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem9 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuAbout As System.Windows.Forms.MenuItem
    Friend WithEvents mnuF1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem10 As System.Windows.Forms.MenuItem
    Friend WithEvents mnu_OpenObject As System.Windows.Forms.MenuItem
    Friend WithEvents mnu_OpenView As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem8 As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.StatusBar1 = New System.Windows.Forms.StatusBar
        Me.ToolBar1 = New System.Windows.Forms.ToolBar
        Me.tvwDb = New System.Windows.Forms.TreeView
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Splitter1 = New System.Windows.Forms.Splitter
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.mnuTabMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MNU_TAB_COLSE = New System.Windows.Forms.ToolStripMenuItem
        Me.MNU_TAB_COLSEALL = New System.Windows.Forms.ToolStripMenuItem
        Me.Label1 = New System.Windows.Forms.Label
        Me.mnuTree = New System.Windows.Forms.ContextMenu
        Me.mnu_OpenObject = New System.Windows.Forms.MenuItem
        Me.mnu_OpenView = New System.Windows.Forms.MenuItem
        Me.MNU_ADD_CATE = New System.Windows.Forms.MenuItem
        Me.MNU_ADD_CATEITEM = New System.Windows.Forms.MenuItem
        Me.MNU_DELETE_CATE = New System.Windows.Forms.MenuItem
        Me.MNU_MOVETO_CATE = New System.Windows.Forms.MenuItem
        Me.MNU_REFRASH = New System.Windows.Forms.MenuItem
        Me.MNU_CHANGE_NAME = New System.Windows.Forms.MenuItem
        Me.MainMenu1 = New System.Windows.Forms.MainMenu(Me.components)
        Me.mnuFile = New System.Windows.Forms.MenuItem
        Me.mnuConnect = New System.Windows.Forms.MenuItem
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.mnuNew = New System.Windows.Forms.MenuItem
        Me.mnuOpen = New System.Windows.Forms.MenuItem
        Me.mnuSave = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.mnuClose = New System.Windows.Forms.MenuItem
        Me.MenuItem6 = New System.Windows.Forms.MenuItem
        Me.MenuItem7 = New System.Windows.Forms.MenuItem
        Me.MenuItem8 = New System.Windows.Forms.MenuItem
        Me.MenuItem3 = New System.Windows.Forms.MenuItem
        Me.mnuRun = New System.Windows.Forms.MenuItem
        Me.MenuItem4 = New System.Windows.Forms.MenuItem
        Me.MenuItem9 = New System.Windows.Forms.MenuItem
        Me.mnuF1 = New System.Windows.Forms.MenuItem
        Me.MenuItem10 = New System.Windows.Forms.MenuItem
        Me.mnuAbout = New System.Windows.Forms.MenuItem
        Me.cmbDataBase = New SQLViewer.IconCombBox
        Me.tabMain = New SQLViewer.MyTabControl
        Me.Panel1.SuspendLayout()
        Me.mnuTabMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 330)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Size = New System.Drawing.Size(808, 22)
        Me.StatusBar1.TabIndex = 0
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
        Me.tvwDb.Dock = System.Windows.Forms.DockStyle.Left
        Me.tvwDb.HideSelection = False
        Me.tvwDb.ImageIndex = 0
        Me.tvwDb.ImageList = Me.ImageList1
        Me.tvwDb.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.tvwDb.Location = New System.Drawing.Point(0, 32)
        Me.tvwDb.Name = "tvwDb"
        Me.tvwDb.SelectedImageIndex = 0
        Me.tvwDb.Size = New System.Drawing.Size(208, 298)
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
        '
        'Splitter1
        '
        Me.Splitter1.Location = New System.Drawing.Point(208, 32)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(3, 298)
        Me.Splitter1.TabIndex = 3
        Me.Splitter1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.tabMain)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(211, 32)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(597, 298)
        Me.Panel1.TabIndex = 4
        '
        'mnuTabMenu
        '
        Me.mnuTabMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MNU_TAB_COLSE, Me.MNU_TAB_COLSEALL})
        Me.mnuTabMenu.Name = "mnuTabMenu"
        Me.mnuTabMenu.Size = New System.Drawing.Size(149, 48)
        '
        'MNU_TAB_COLSE
        '
        Me.MNU_TAB_COLSE.Name = "MNU_TAB_COLSE"
        Me.MNU_TAB_COLSE.Size = New System.Drawing.Size(148, 22)
        Me.MNU_TAB_COLSE.Text = "閉じる"
        '
        'MNU_TAB_COLSEALL
        '
        Me.MNU_TAB_COLSEALL.Name = "MNU_TAB_COLSEALL"
        Me.MNU_TAB_COLSEALL.Size = New System.Drawing.Size(148, 22)
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
        Me.mnuTree.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnu_OpenObject, Me.mnu_OpenView, Me.MNU_ADD_CATE, Me.MNU_ADD_CATEITEM, Me.MNU_DELETE_CATE, Me.MNU_MOVETO_CATE, Me.MNU_REFRASH, Me.MNU_CHANGE_NAME})
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
        Me.MenuItem6.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem7, Me.MenuItem8})
        Me.MenuItem6.Text = "編集"
        '
        'MenuItem7
        '
        Me.MenuItem7.Index = 0
        Me.MenuItem7.Shortcut = System.Windows.Forms.Shortcut.CtrlF3
        Me.MenuItem7.Text = "検索"
        '
        'MenuItem8
        '
        Me.MenuItem8.Index = 1
        Me.MenuItem8.Shortcut = System.Windows.Forms.Shortcut.F3
        Me.MenuItem8.Text = "次検索"
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 2
        Me.MenuItem3.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuRun})
        Me.MenuItem3.Text = "クエリ(&Q)"
        '
        'mnuRun
        '
        Me.mnuRun.Index = 0
        Me.mnuRun.Shortcut = System.Windows.Forms.Shortcut.CtrlE
        Me.mnuRun.Text = "実行(&R)"
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
        Me.tabMain.Size = New System.Drawing.Size(597, 298)
        Me.tabMain.TabIndex = 2
        '
        'frmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
        Me.ClientSize = New System.Drawing.Size(808, 352)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbDataBase)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.tvwDb)
        Me.Controls.Add(Me.ToolBar1)
        Me.Controls.Add(Me.StatusBar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Menu = Me.MainMenu1
        Me.Name = "frmMain"
        Me.Text = "SQL Viewer"
        Me.Panel1.ResumeLayout(False)
        Me.mnuTabMenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
#Region "Enum"
    Public Enum NodeTypes As Integer
        DataBase = 0
        Tables = 1
        Views = 2
        Sps = 3
        Functions = 4
        Table = 5
        View = 6
        Sp = 7
        Fn = 8
        IFN = 9
        Categoly = 10
        SQL = 11
    End Enum
#End Region
#Region "Private変数"
    Private mDataBase As String = ""
    Private mCateGolys() As String = {"テープル,1", "ビュー,2", "ストアド プロシージャ,3", "関数,4"}
    Private mIsNewCreate As Boolean = False
    Private mTableNode As TreeNode = Nothing
    Private mViewNode As TreeNode = Nothing
    Private mSpNode As TreeNode = Nothing
    Private mFnNode As TreeNode = Nothing
#End Region
#Region "メッソト"
    Private Sub InitDataBase()
        Dim DbSchema As New DBSchemaControler()
        Dim dbs() As String = DbSchema.GetDataBases
        Dim db As String = ""
        Me.cmbDataBase.Items.Clear()
        Me.cmbDataBase.Icon = Me.ImageList1.Images.Item(NodeTypes.DataBase)
        For Each db In dbs
            Me.cmbDataBase.Items.Add(db)
        Next
        Dim mDataBase As String = Env.GetSetting("database")
        Dim selIndex As Integer = 0
        If mDataBase <> "" Then
            selIndex = Me.cmbDataBase.Items.IndexOf(mDataBase)
            If selIndex = -1 Then
                selIndex = 0
            End If
        End If
        Me.cmbDataBase.SelectedIndex = selIndex
        mDataBase = CStr(Me.cmbDataBase.Items(selIndex))

    End Sub
    Private Sub initTreeFolder(ByVal DataBase As String)
        Me.tvwDb.Nodes.Clear()
        Dim root As New TreeNode(DataBase)
        root.ImageIndex = NodeTypes.DataBase
        root.SelectedImageIndex = NodeTypes.DataBase
        Me.tvwDb.Nodes.Add(root)
        Dim cate As String = ""
        For Each cate In Me.mCateGolys
            Dim txts() As String = cate.Split(","c)
            Dim node As New TreeNode(txts(0))
            node.ImageIndex = CInt(txts(1))
            node.SelectedImageIndex = CInt(txts(1))
            node.Tag = CInt(txts(1))
            Select Case CType(node.ImageIndex, NodeTypes)
                Case NodeTypes.Tables
                    mTableNode = node
                    initTables(node)
                Case NodeTypes.Views
                    mViewNode = node
                    initViews(node)
                Case NodeTypes.Sps
                    mSpNode = node
                    initSPs(node)
                Case NodeTypes.Functions
                    mFnNode = node
                    initFunctions(node)
            End Select
            root.Nodes.Add(node)
        Next
        root.Expand()
        Me.Text = "SQL Viewer - [" & Env.GetSetting("server") & "].[" & DataBase & "]"
    End Sub
    Private Sub initTables(ByVal parentNode As TreeNode)
        initCateGolys(parentNode, CateGolyType.TABLE)
        Dim DbSchema As New DBSchemaControler()
        Dim dtt As DataTable = DbSchema.GetTables(Me.mDataBase)
        Dim row As DataRow = Nothing
        For Each row In dtt.Rows
            Dim table As New DBSchema.Table(Me.mDataBase, row)
            Dim node As New TreeNode(table.ObjName, NodeTypes.Table, NodeTypes.Table)
            node.Tag = table
            parentNode.Nodes.Add(node)
        Next
    End Sub
    Private Sub initTables(ByVal parentNode As TreeNode, ByVal categolyName As String)
        Dim DbSchema As New DBSchemaControler()
        Dim dtt As DataTable = DbSchema.GetTables(Me.mDataBase, categolyName)
        Dim row As DataRow = Nothing
        For Each row In dtt.Rows
            Dim table As New DBSchema.Table(Me.mDataBase, row)
            Dim node As New TreeNode(table.ObjName, NodeTypes.Table, NodeTypes.Table)
            node.Tag = table
            parentNode.Nodes.Add(node)
        Next
    End Sub
    Private Sub initViews(ByVal parentNode As TreeNode)
        initCateGolys(parentNode, CateGolyType.VIEW)
        Dim DbSchema As New DBSchemaControler()
        Dim dtt As DataTable = DbSchema.GetViews(Me.mDataBase)
        Dim row As DataRow = Nothing
        For Each row In dtt.Rows
            Dim view As New DBSchema.View(Me.mDataBase, row)
            Dim node As New TreeNode(view.ObjName, NodeTypes.View, NodeTypes.View)
            node.Tag = view
            parentNode.Nodes.Add(node)
        Next
    End Sub
    Private Sub initViews(ByVal parentNode As TreeNode, ByVal categolyName As String)
        Dim DbSchema As New DBSchemaControler()
        Dim dtt As DataTable = DbSchema.GetViews(Me.mDataBase, categolyName)
        Dim row As DataRow = Nothing
        For Each row In dtt.Rows
            Dim view As New DBSchema.View(Me.mDataBase, row)
            Dim node As New TreeNode(view.ObjName, NodeTypes.View, NodeTypes.View)
            node.Tag = view
            parentNode.Nodes.Add(node)
        Next
    End Sub
    Private Sub initSPs(ByVal parentNode As TreeNode)
        initCateGolys(parentNode, CateGolyType.PROCEDURE)
        Dim DbSchema As New DBSchemaControler()
        Dim dtt As DataTable = DbSchema.GetStoreProcedures(Me.mDataBase)
        Dim row As DataRow = Nothing
        For Each row In dtt.Rows
            Dim sp As New DBSchema.StoreProcedure(Me.mDataBase, row)
            Dim node As New TreeNode(sp.ObjName, NodeTypes.Sp, NodeTypes.Sp)
            node.Tag = sp
            parentNode.Nodes.Add(node)
        Next
    End Sub
    Private Sub initSPs(ByVal parentNode As TreeNode, ByVal categolyName As String)
        Dim DbSchema As New DBSchemaControler()
        Dim dtt As DataTable = DbSchema.GetStoreProcedures(Me.mDataBase, categolyName)
        Dim row As DataRow = Nothing
        For Each row In dtt.Rows
            Dim sp As New DBSchema.StoreProcedure(Me.mDataBase, row)
            Dim node As New TreeNode(sp.ObjName, NodeTypes.Sp, NodeTypes.Sp)
            node.Tag = sp
            parentNode.Nodes.Add(node)
        Next
    End Sub
    Private Sub initFunctions(ByVal parentNode As TreeNode)
        initCateGolys(parentNode, CateGolyType.FUNCTION)
        Dim DbSchema As New DBSchemaControler()
        Dim dtt As DataTable = DbSchema.GetFunctions(Me.mDataBase)
        Dim row As DataRow = Nothing
        For Each row In dtt.Rows
            Dim fn As New DBSchema.Function(Me.mDataBase, row)
            Dim node As New TreeNode(fn.ObjName)
            If fn.Type.ToUpper = "FN" Then
                node.ImageIndex = NodeTypes.Sp
                node.SelectedImageIndex = NodeTypes.Sp

            Else
                node.ImageIndex = NodeTypes.IFN
                node.SelectedImageIndex = NodeTypes.IFN
            End If
            node.Tag = fn
            parentNode.Nodes.Add(node)
        Next
    End Sub
    Private Sub initFunctions(ByVal parentNode As TreeNode, ByVal categolyname As String)
        Dim DbSchema As New DBSchemaControler()
        Dim dtt As DataTable = DbSchema.GetFunctions(Me.mDataBase, categolyname)
        Dim row As DataRow = Nothing
        For Each row In dtt.Rows
            Dim fn As New DBSchema.Function(Me.mDataBase, row)
            Dim node As New TreeNode(fn.ObjName)
            If fn.Type.ToUpper = "FN" Then
                node.ImageIndex = NodeTypes.Sp
                node.SelectedImageIndex = NodeTypes.Sp

            Else
                node.ImageIndex = NodeTypes.IFN
                node.SelectedImageIndex = NodeTypes.IFN
            End If
            node.Tag = fn
            parentNode.Nodes.Add(node)
        Next
    End Sub
    Private Sub initCateGolys(ByVal parentNode As TreeNode, ByVal type As CateGolyType)
        Dim DbSchema As New DBSchemaControler()
        Dim dtt As DataTable = DbSchema.GetCateGolys(Me.mDataBase, type)
        Dim row As DataRow = Nothing
        For Each row In dtt.Rows
            Dim cate As New DBSchema.CateGoly(Me.mDataBase, row)
            Dim node As New TreeNode(cate.ObjName)
            node.ImageIndex = NodeTypes.Categoly
            node.SelectedImageIndex = NodeTypes.Categoly
            node.Tag = cate
            Select Case type
                Case CateGolyType.TABLE
                    Me.initTables(node, cate.ObjName)
                Case CateGolyType.VIEW
                    Me.initViews(node, cate.ObjName)
                Case CateGolyType.PROCEDURE
                    Me.initSPs(node, cate.ObjName)
                Case CateGolyType.FUNCTION
                    Me.initFunctions(node, cate.ObjName)
            End Select
            parentNode.Nodes.Add(node)
        Next
    End Sub
    Private Sub ShowPopMenu(ByVal node As TreeNode, ByVal pt As Point)
        Dim mnuCont As ContextMenu = Nothing
        Select Case CType(node.ImageIndex, NodeTypes)
            Case NodeTypes.DataBase
                Dim mnu As MenuItem = Me.MNU_REFRASH.CloneMenu()
                mnuCont = New ContextMenu(New MenuItem() {mnu})
            Case NodeTypes.Tables, NodeTypes.Views, NodeTypes.Functions, NodeTypes.Sps
                mnuCont = New ContextMenu(New MenuItem() {MNU_ADD_CATE.CloneMenu(), Me.MNU_REFRASH.CloneMenu()})
            Case NodeTypes.View
                Dim mnuCate As MenuItem = MNU_MOVETO_CATE.CloneMenu()
                mnuCont = New ContextMenu(New MenuItem() {mnu_OpenObject.CloneMenu(), Me.mnu_OpenView.CloneMenu(), mnuCate})
                Dim cate As CateGoly = Nothing
                Dim parentNode As TreeNode = node.Parent
                Dim nd As TreeNode = Nothing
                Dim index As Integer = 0
                For Each nd In parentNode.Nodes
                    If CType(nd.ImageIndex, NodeTypes) = NodeTypes.Categoly Then
                        cate = CType(nd.Tag, CateGoly)
                        Dim submnu As MenuItem = New MenuItem()
                        submnu.Text = cate.ObjName
                        submnu.Visible = True
                        submnu.Index = index
                        mnuCate.MenuItems.Add(submnu)
                        index += 1
                    End If
                Next
            Case NodeTypes.Table, NodeTypes.Fn, NodeTypes.IFN, NodeTypes.Sp
                Dim mnuCate As MenuItem = MNU_MOVETO_CATE.CloneMenu()
                mnuCont = New ContextMenu(New MenuItem() {mnu_OpenObject.CloneMenu(), mnuCate})
                Dim cate As CateGoly = Nothing
                Dim parentNode As TreeNode = node.Parent
                Dim nd As TreeNode = Nothing
                Dim index As Integer = 0
                For Each nd In parentNode.Nodes
                    If CType(nd.ImageIndex, NodeTypes) = NodeTypes.Categoly Then
                        cate = CType(nd.Tag, CateGoly)
                        Dim submnu As MenuItem = New MenuItem()
                        submnu.Text = cate.ObjName
                        submnu.Visible = True
                        submnu.Index = index
                        mnuCate.MenuItems.Add(submnu)
                        index += 1
                    End If
                Next
            Case NodeTypes.Categoly
                mnuCont = New ContextMenu(New MenuItem() {MNU_ADD_CATEITEM.CloneMenu(), Me.MNU_CHANGE_NAME.CloneMenu(), MNU_DELETE_CATE.CloneMenu()})
        End Select
        Me.tvwDb.SelectedNode = node
        mnuCont.Show(Me.tvwDb, pt)
    End Sub
    Private Function CreateSqlEditer(ByVal code As String) As SplitContainer
        Dim pnlSplit As New SplitContainer
        pnlSplit.Dock = DockStyle.Fill
        pnlSplit.Orientation = Orientation.Horizontal
        pnlSplit.Panel2Collapsed = True
        Dim txtEditor As New SqlEditor()
        txtEditor.Document.HighlightingStrategy = ICSharpCode.TextEditor.Document.HighlightingStrategyFactory.CreateHighlightingStrategy("SQL")
        txtEditor.ShowEOLMarkers = False
        txtEditor.ShowTabs = True
        txtEditor.ShowInvalidLines = False
        txtEditor.Text = code
        pnlSplit.Panel1.Controls.Add(txtEditor)
        txtEditor.Dock = DockStyle.Fill
        Return pnlSplit
    End Function
    Private Sub AddDataGrid(ByVal parentTab As TabPage, ByVal dtt As DataTable)
        Dim dtgData As SqlDataGrid = New SqlDataGrid()
        dtgData.CaptionVisible = False
        parentTab.Controls.Add(dtgData)
        dtgData.Size = parentTab.Size
        dtgData.ResetText()
        dtgData.Dock = DockStyle.Fill
        tabMain.AddTabPage(parentTab)
        dtgData.DataSource = dtt
    End Sub
    Private Sub ShowDataGrid(ByVal Panel As SplitContainer, ByVal dts As DataSet)
        Dim dtgData As SqlDataGrid = New SqlDataGrid()
        dtgData.CaptionVisible = False

        Panel.Panel2.Controls.Clear()
        Panel.Panel2.Controls.Add(dtgData)
        dtgData.Dock = DockStyle.Fill
        If dts.Tables.Count > 1 Then
            dtgData.AllowNavigation = True
            dtgData.DataSource = dts
            dtgData.Expand(-1)
        Else
            dtgData.AllowNavigation = False
            dtgData.DataSource = dts.Tables(0)
        End If
        Panel.Panel2Collapsed = False
    End Sub
    '現在のSQL文を取得する
    Private Function GetCurrentSqlText() As String
        If Me.tabMain.SelectedTab Is Nothing Then
            Return ""
        End If
        Dim ctrl As Object = Me.tabMain.SelectedTab.Controls(0)
        If Not TypeOf ctrl Is SplitContainer Then
            Return ""
        End If
        Dim spliter As SplitContainer = DirectCast(ctrl, SplitContainer)
        Dim sqlEditor As SqlEditor = CType(spliter.Panel1.Controls.Item(0), SqlEditor)
        Dim selText As String = sqlEditor.Document.SelectedText
        If selText = "" Then
            Return sqlEditor.Text
        Else
            Return selText
        End If

    End Function
    ''' <summary>
    ''' SQLオブジェクトを開く
    ''' </summary>
    ''' <param name="sqlObj"></param>
    ''' <remarks></remarks>
    Private Sub OpenSqlObject(ByVal sqlObj As iSqlObject)
        Select Case sqlObj.ObjType
            Case SqlObjectType.SqlQuery
                Dim objQuery As SqlQuery = DirectCast(sqlObj, SqlQuery)
                Dim tab As New TabPage(objQuery.ObjName)
                tab.ToolTipText = objQuery.ObjName
                tab.ImageIndex = NodeTypes.SQL
                tab.Tag = objQuery
                Dim Panel As SplitContainer = Me.CreateSqlEditer(objQuery.SqlText)
                tab.Controls.Add(Panel)
                Panel.Dock = DockStyle.Fill
                tabMain.AddTabPage(tab)
            Case SqlObjectType.Table
                Dim objTable As DBSchema.Table = DirectCast(sqlObj, DBSchema.Table)
                Dim dtt As DataTable = objTable.GetDatas
                Dim tab As New TabPage(objTable.ObjName)
                tab.ImageIndex = NodeTypes.Table
                tab.Tag = objTable
                AddDataGrid(tab, dtt)

            Case SqlObjectType.View
                Dim view As DBSchema.View = DirectCast(sqlObj, DBSchema.View)
                Dim code As String = view.GetViewCode()
                Dim tab As New TabPage(view.ObjName)
                tab.ImageIndex = NodeTypes.View
                tab.Tag = view
                Dim Panel As SplitContainer = Me.CreateSqlEditer(code)
                tab.Controls.Add(Panel)
                Panel.Dock = DockStyle.Fill
                tabMain.AddTabPage(tab)

            Case SqlObjectType.StoreProcedure
                Dim sp As DBSchema.StoreProcedure = DirectCast(sqlObj, DBSchema.StoreProcedure)
                Dim code As String = sp.GetSPCode()
                Dim tab As New TabPage(sp.ObjName)
                tab.ImageIndex = NodeTypes.Sp
                tab.Tag = sp
                Dim Panel As SplitContainer = Me.CreateSqlEditer(code)
                tab.Controls.Add(Panel)
                Panel.Dock = DockStyle.Fill
                tabMain.AddTabPage(tab)

            Case SqlObjectType.Function
                Dim Fn As DBSchema.Function = DirectCast(sqlObj, DBSchema.Function)
                Dim code As String = Fn.GetFnCode()
                Dim tab As New TabPage(Fn.ObjName)
                tab.Tag = Fn
                If Fn.Type.ToLower = "ifn" Then
                    tab.ImageIndex = NodeTypes.IFN
                Else
                    tab.ImageIndex = NodeTypes.Fn
                End If
                Dim Panel As SplitContainer = Me.CreateSqlEditer(code)
                tab.Controls.Add(Panel)
                Panel.Dock = DockStyle.Fill
                tabMain.AddTabPage(tab)

        End Select
    End Sub
    Private Sub RunSqlQuery(ByVal sqlObj As iSqlObject, ByVal SqlText As String)
        Select Case sqlObj.ObjType
            Case SqlObjectType.StoreProcedure
                If Messages.ShowQuery(Questions.IsExcuteOk) = Windows.Forms.DialogResult.Yes Then
                    CType(sqlObj, StoreProcedure).Update(SqlText)
                End If
            Case SqlObjectType.Function
                If Messages.ShowQuery(Questions.IsExcuteOk) = Windows.Forms.DialogResult.Yes Then
                    CType(sqlObj, [Function]).Update(SqlText)
                End If
            Case SqlObjectType.SqlQuery
                Dim errmsg As String = ""
                Dim dts As DataSet = CType(sqlObj, SqlQuery).ExecSql(SqlText, errmsg)
                If dts IsNot Nothing AndAlso dts.Tables.Count > 0 Then
                    Dim spliter As SplitContainer = TryCast(Me.tabMain.SelectedTab.Controls.Item(0), SplitContainer)
                    If spliter IsNot Nothing Then
                        Me.ShowDataGrid(spliter, dts)
                    End If
                Else
                    Dim spliter As SplitContainer = TryCast(Me.tabMain.SelectedTab.Controls.Item(0), SplitContainer)
                    If spliter IsNot Nothing Then
                        spliter.Panel2.Controls.Clear()
                        If errmsg <> "" Then
                            Dim txtMsg As New TextBox
                            txtMsg.Multiline = True
                            txtMsg.ReadOnly = True
                            txtMsg.ForeColor = Color.Red
                            txtMsg.BorderStyle = BorderStyle.Fixed3D
                            txtMsg.BackColor = Color.White
                            txtMsg.Text = errmsg
                            spliter.Panel2.Controls.Add(txtMsg)
                            txtMsg.Dock = DockStyle.Fill
                            spliter.Panel2Collapsed = False
                        Else
                            spliter.Panel2Collapsed = True
                        End If
                    End If
                End If

            Case SqlObjectType.View

            Case Else

        End Select
    End Sub
#End Region
#Region "フォームエベント"
    Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitDataBase()
        initTreeFolder(mDataBase)
        mnuNew_Click(Me, Nothing)
    End Sub
#End Region
#Region "メニューエベント"

    Private Sub mnuF1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuF1.Click
        Dim Key As String = Me.GetCurrentSqlText
        Dim StartInfo As New ProcessStartInfo("dexplore")
        If Key <> "" Then
            StartInfo.Arguments = "/LaunchFKeywordTopic" & " " & Key
        End If
        Process.Start(StartInfo)
    End Sub
    Private Sub MNU_TAB_COLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MNU_TAB_COLSE.Click
        If Me.tabMain.SelectedTab Is Nothing Then
            Return
        End If
        Me.tabMain.TabPages.Remove(Me.tabMain.SelectedTab)

    End Sub
    Private Sub MNU_TAB_COLSEALL_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MNU_TAB_COLSEALL.Click
        Me.tabMain.TabPages.Clear()
    End Sub
    Private Sub mnu_OpenObject_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnu_OpenObject.Click
        If Me.tvwDb.SelectedNode Is Nothing Then
            Return
        End If
        Dim tag As Object = Me.tvwDb.SelectedNode.Tag
        If Not TypeOf tag Is iSqlObject Then Return
        Dim isqlObj As iSqlObject = CType(tag, iSqlObject)
        OpenSqlObject(isqlObj)
    End Sub
    Private Sub mnu_OpenView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnu_OpenView.Click
        If Me.tvwDb.SelectedNode Is Nothing Then
            Return
        End If
        Dim tag As Object = Me.tvwDb.SelectedNode.Tag
        If Not TypeOf tag Is DBSchema.View Then Return
        Dim code As String = CType(tag, DBSchema.View).GetOpenSql()
        Dim filename As String = Me.mDataBase & "-クエリ" & Me.tabMain.GetNewQueryIndex
        Dim query As New SqlQuery(Me.mDataBase, code, filename)
        Me.OpenSqlObject(query)
        Me.RunSqlQuery(query, query.SqlText)
    End Sub
    Private Sub MNU_ADD_CATE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MNU_ADD_CATE.Click
        If Me.tvwDb.SelectedNode Is Nothing Then Return
        Dim node As TreeNode = Me.tvwDb.SelectedNode
        Dim cateType As CateGolyType
        Select Case CType(node.ImageIndex, NodeTypes)
            Case NodeTypes.Tables
                cateType = CateGolyType.TABLE
            Case NodeTypes.Views
                cateType = CateGolyType.VIEW
            Case NodeTypes.Sps
                cateType = CateGolyType.PROCEDURE
            Case NodeTypes.Functions
                cateType = CateGolyType.FUNCTION
        End Select
        Dim cate As New CateGoly(Me.mDataBase, "新しいカテゴリ", cateType)
        Dim newnode As New TreeNode(cate.ObjName)
        newnode.ImageIndex = NodeTypes.Categoly
        newnode.Tag = cate
        newnode.SelectedImageIndex = NodeTypes.Categoly
        node.Nodes.Insert(0, newnode)
        Me.tvwDb.SelectedNode = newnode
        Me.tvwDb.LabelEdit = True
        mIsNewCreate = True
        newnode.BeginEdit()
    End Sub
    Private Sub MNU_ADD_CATEITEM_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MNU_ADD_CATEITEM.Click
        If Me.tvwDb.SelectedNode Is Nothing Then Return
        Dim Selnode As TreeNode = Me.tvwDb.SelectedNode
        Dim sqlObjs As New ArrayList()
        If Selnode.ImageIndex = NodeTypes.Categoly Then
            Dim node As TreeNode = Nothing
            For Each node In Selnode.Parent.Nodes
                If Not node.Tag Is Nothing AndAlso TypeOf node.Tag Is iSqlObject Then
                    Dim obj As iSqlObject = CType(node.Tag, iSqlObject)
                    If obj.ObjType <> SqlObjectType.CateGoly Then
                        sqlObjs.Add(obj)
                    End If
                End If
            Next node
            Dim frm As New frmSelectObject()
            frm.SqlObjectList = CType(sqlObjs.ToArray(GetType(iSqlObject)), iSqlObject())
            If frm.ShowDialog(Me) = DialogResult.OK Then
                Dim cate As CateGoly = DirectCast(Selnode.Tag, CateGoly)
                Dim obj As iSqlObject = Nothing
                For Each obj In frm.SelectedObjects
                    cate.SetCateGoly(obj)
                Next obj
                Dim parentnode As TreeNode = Selnode.Parent
                parentnode.Nodes.Clear()
                Select Case CType(parentnode.ImageIndex, NodeTypes)
                    Case NodeTypes.Tables
                        Me.initTables(parentnode)
                    Case NodeTypes.Views
                        Me.initViews(parentnode)
                    Case NodeTypes.Sps
                        Me.initSPs(parentnode)
                    Case NodeTypes.Functions
                        Me.initFunctions(parentnode)
                End Select
                parentnode.Expand()
            End If
        End If
    End Sub
    Private Sub MNU_DELETE_CATE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MNU_DELETE_CATE.Click
        If Me.tvwDb.SelectedNode Is Nothing Then Return
        Dim Selnode As TreeNode = Me.tvwDb.SelectedNode
        If Selnode.ImageIndex = NodeTypes.Categoly Then
            Dim cate As CateGoly = DirectCast(Selnode.Tag, CateGoly)
            cate.Remove()
            Dim parentNode As TreeNode = Selnode.Parent
            parentNode.Nodes.Clear()
            Select Case CType(parentNode.ImageIndex, NodeTypes)
                Case NodeTypes.Tables
                    Me.initTables(parentNode)
                Case NodeTypes.Views
                    Me.initViews(parentNode)
                Case NodeTypes.Sps
                    Me.initSPs(parentNode)
                Case NodeTypes.Functions
                    Me.initFunctions(parentNode)
                Case Else
                    Return
            End Select
            parentNode.Expand()
        End If
    End Sub
    Private Sub MNU_CHANGE_NAME_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MNU_CHANGE_NAME.Click
        If Me.tvwDb.SelectedNode Is Nothing Then Return
        Dim Selnode As TreeNode = Me.tvwDb.SelectedNode
        If Selnode.ImageIndex = NodeTypes.Categoly Then
            Me.tvwDb.LabelEdit = True
            mIsNewCreate = True
            Selnode.BeginEdit()
        End If
    End Sub
    Private Sub mnuAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAbout.Click
        Dim frmAbout As New AboutBox1
        frmAbout.ShowDialog(Me)
    End Sub
    Private Sub mnuNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNew.Click
        Dim code As String = ""
        Dim filename As String = Me.mDataBase & "-クエリ" & Me.tabMain.GetNewQueryIndex
        Dim query As New SqlQuery(Me.mDataBase, "", filename)
        Me.OpenSqlObject(query)
        'Dim tab As New TabPage(filename)
        'tab.ToolTipText = filename
        'tab.ImageIndex = NodeTypes.SQL
        'tab.Tag = query
        'Dim Panel As SplitContainer = Me.CreateSqlEditer(code)
        'tab.Controls.Add(Panel)
        'Panel.Dock = DockStyle.Fill
        'tabMain.AddTabPage(tab)
    End Sub
    'SQL 実行
    Private Sub mnuRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRun.Click
        Try
            If Me.tabMain.SelectedTab Is Nothing Then
                Return
            End If
            Dim sqltxt As String = Me.GetCurrentSqlText
            Dim tag As Object = Me.tabMain.SelectedTab.Tag
            If tag IsNot Nothing And TypeOf tag Is iSqlObject Then
                Dim sqlObj As iSqlObject = DirectCast(tag, iSqlObject)
                Me.RunSqlQuery(sqlObj, sqltxt)
                'Select Case sqlObj.ObjType
                '    Case SqlObjectType.StoreProcedure
                '        If Messages.ShowQuery(Questions.IsExcuteOk) = Windows.Forms.DialogResult.Yes Then
                '            CType(sqlObj, StoreProcedure).Update(sqltxt)
                '        End If
                '    Case SqlObjectType.Function
                '        If Messages.ShowQuery(Questions.IsExcuteOk) = Windows.Forms.DialogResult.Yes Then
                '            CType(sqlObj, [Function]).Update(sqltxt)
                '        End If
                '    Case SqlObjectType.SqlQuery
                '        Dim errmsg As String = ""
                '        Dim dts As DataSet = CType(sqlObj, SqlQuery).ExecSql(sqltxt, errmsg)
                '        If dts IsNot Nothing AndAlso dts.Tables.Count > 0 Then
                '            Dim spliter As SplitContainer = TryCast(Me.tabMain.SelectedTab.Controls.Item(0), SplitContainer)
                '            If spliter IsNot Nothing Then
                '                Me.ShowDataGrid(spliter, dts)
                '            End If
                '        Else
                '            Dim spliter As SplitContainer = TryCast(Me.tabMain.SelectedTab.Controls.Item(0), SplitContainer)
                '            If spliter IsNot Nothing Then
                '                spliter.Panel2.Controls.Clear()
                '                If errmsg <> "" Then
                '                    Dim txtMsg As New TextBox
                '                    txtMsg.Multiline = True
                '                    txtMsg.ReadOnly = True
                '                    txtMsg.ForeColor = Color.Red
                '                    txtMsg.BorderStyle = BorderStyle.Fixed3D
                '                    txtMsg.BackColor = Color.White
                '                    txtMsg.Text = errmsg
                '                    spliter.Panel2.Controls.Add(txtMsg)
                '                    txtMsg.Dock = DockStyle.Fill
                '                    spliter.Panel2Collapsed = False
                '                Else
                '                    spliter.Panel2Collapsed = True
                '                End If
                '            End If
                '        End If

                '    Case SqlObjectType.View

                '    Case Else

                'End Select
            End If
        Catch ex As Exception
            Messages.ShowExcption(ex)
        End Try
    End Sub
 
#End Region
#Region "コントロールエベント"
    Private Sub cmbDataBase_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbDataBase.SelectedIndexChanged
        If Me.cmbDataBase.SelectedIndex <> -1 Then
            Me.mDataBase = CStr(Me.cmbDataBase.Items(cmbDataBase.SelectedIndex))
            initTreeFolder(mDataBase)
        End If
    End Sub
    
    Private Sub tvwDb_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvwDb.DoubleClick
        If Me.tvwDb.SelectedNode Is Nothing Then
            Return
        End If
        Dim tag As Object = Me.tvwDb.SelectedNode.Tag
        If Not TypeOf tag Is iSqlObject Then Return
        Dim isqlObj As iSqlObject = CType(tag, iSqlObject)
        OpenSqlObject(isqlObj)
        'Select Case isqlObj.ObjType
        '    Case SqlObjectType.Table
        '        Dim objTable As DBSchema.Table = DirectCast(tag, DBSchema.Table)
        '        Dim dtt As DataTable = objTable.GetDatas
        '        Dim tab As New TabPage(objTable.ObjName)
        '        tab.ImageIndex = NodeTypes.Table
        '        tab.Tag = objTable
        '        AddDataGrid(tab, dtt)

        '    Case SqlObjectType.View
        '        Dim view As DBSchema.View = DirectCast(tag, DBSchema.View)
        '        Dim code As String = view.GetViewCode()
        '        Dim tab As New TabPage(view.ObjName)
        '        tab.ImageIndex = NodeTypes.View
        '        tab.Tag = view
        '        Dim Panel As SplitContainer = Me.CreateSqlEditer(code)
        '        tab.Controls.Add(Panel)
        '        Panel.Dock = DockStyle.Fill
        '        tabMain.AddTabPage(tab)

        '    Case SqlObjectType.StoreProcedure
        '        Dim sp As DBSchema.StoreProcedure = DirectCast(tag, DBSchema.StoreProcedure)
        '        Dim code As String = sp.GetSPCode()
        '        Dim tab As New TabPage(sp.ObjName)
        '        tab.ImageIndex = NodeTypes.Sp
        '        tab.Tag = sp
        '        Dim Panel As SplitContainer = Me.CreateSqlEditer(code)
        '        tab.Controls.Add(Panel)
        '        Panel.Dock = DockStyle.Fill
        '        tabMain.AddTabPage(tab)

        '    Case SqlObjectType.Function
        '        Dim Fn As DBSchema.Function = DirectCast(tag, DBSchema.Function)
        '        Dim code As String = Fn.GetFnCode()
        '        Dim tab As New TabPage(Fn.ObjName)
        '        tab.Tag = Fn
        '        If Fn.Type.ToLower = "ifn" Then
        '            tab.ImageIndex = NodeTypes.IFN
        '        Else
        '            tab.ImageIndex = NodeTypes.Fn
        '        End If
        '        Dim Panel As SplitContainer = Me.CreateSqlEditer(code)
        '        tab.Controls.Add(Panel)
        '        Panel.Dock = DockStyle.Fill
        '        tabMain.AddTabPage(tab)

        'End Select

    End Sub
    Private Sub tvwDb_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tvwDb.MouseDown
        If e.Button = MouseButtons.Right Then
            Dim node As TreeNode = Me.tvwDb.GetNodeAt(e.X, e.Y)
            If node Is Nothing Then Return
            ShowPopMenu(node, New Point(e.X, e.Y))
        End If

    End Sub
    Private Sub tvwDb_AfterLabelEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.NodeLabelEditEventArgs) Handles tvwDb.AfterLabelEdit
        If Not (e.Label Is Nothing) Then
            If e.Label.Length > 0 Then
                If e.Label.IndexOfAny(New Char() {"@"c, "."c, ","c, "!"c}) = -1 Then
                    If TypeOf e.Node.Tag Is iSqlObject Then
                        Dim tag As iSqlObject = CType(e.Node.Tag, iSqlObject)
                        tag.ChangeObjname(e.Label)
                    End If
                    e.Node.EndEdit(False)
                    Me.tvwDb.LabelEdit = False
                Else
                    e.CancelEdit = True
                    e.Node.BeginEdit()
                End If
            Else
                e.CancelEdit = True
                e.Node.BeginEdit()
            End If
            Me.tvwDb.LabelEdit = False
        ElseIf mIsNewCreate Then
            e.CancelEdit = False
            mIsNewCreate = False
            e.Node.BeginEdit()
        Else
            Me.tvwDb.LabelEdit = False
        End If
    End Sub
    Private Sub mnuConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuConnect.Click
        Dim frmLogin As New frmLogin()
        If frmLogin.ShowDialog() = DialogResult.OK Then
            InitDataBase()
            initTreeFolder(mDataBase)
            mnuNew_Click(Me, Nothing)
        End If
    End Sub

 
#End Region




 
   
  
End Class
