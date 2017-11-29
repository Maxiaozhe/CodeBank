Imports SQLViewer.DBAccess
Imports Utility = SQLViewer.DBAccess.Common.ToolUtility
Imports SQLViewer.DBAccess.DBSchema
Imports Env = SQLViewer.DBAccess.Common.Enviroment
Imports System.Collections.Generic
Imports ICSharpCode.TextEditor.Document

Public Class frmMain

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
        Packages = 12
        PackageBodies = 13
        Package = 14
        PackageBody = 15
        Sequeces = 16
        Seqence = 17
    End Enum
#End Region
#Region "Private変数"
    Private mDataBase As String = ""
    Private mCateGolys() As String = {"テープル,1", "ビュー,2", "プロシージャ,3", "関数,4", "パッケージ,12", "パッケージ本体,13", "順序,16"}
    Private mIsNewCreate As Boolean = False
    Private mTableNode As TreeNode = Nothing
    Private mViewNode As TreeNode = Nothing
    Private mSpNode As TreeNode = Nothing
    Private mFnNode As TreeNode = Nothing
    Private mRunningQuery As iSqlObject = Nothing
#End Region
#Region "メッソト"
    Private Sub InitDataBase()
        Dim DbSchema As New DBSchemaControler()
        Dim dbs() As String = DbSchema.GetUsers
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
                Case NodeTypes.Packages
                    initPackages(node)
                Case NodeTypes.PackageBodies
                    initPackageBodies(node)
                Case NodeTypes.Sequeces
                    initSeqences(node)
            End Select
            root.Nodes.Add(node)
        Next
        root.Expand()
        Me.Text = "SQL Viewer - [" & Env.GetSetting("server") & "].[" & DataBase & "]"
    End Sub
    Private Sub initTables(ByVal parentNode As TreeNode)
        'initCateGolys(parentNode, CateGolyType.TABLE)
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
        Dim dtt As DataTable = DbSchema.GetTables(Me.mDataBase)
        Dim row As DataRow = Nothing
        For Each row In dtt.Rows
            Dim table As New DBSchema.Table(Me.mDataBase, row)
            Dim node As New TreeNode(table.ObjName, NodeTypes.Table, NodeTypes.Table)
            node.Tag = table
            parentNode.Nodes.Add(node)
        Next
    End Sub
    Private Sub initViews(ByVal parentNode As TreeNode)
        'initCateGolys(parentNode, CateGolyType.VIEW)
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

    Private Sub initSPs(ByVal parentNode As TreeNode)
        'initCateGolys(parentNode, CateGolyType.PROCEDURE)
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
    'Private Sub initSPs(ByVal parentNode As TreeNode, ByVal categolyName As String)
    '    Dim DbSchema As New DBSchemaControler()
    '    Dim dtt As DataTable = DbSchema.GetStoreProcedures(Me.mDataBase, categolyName)
    '    Dim row As DataRow = Nothing
    '    For Each row In dtt.Rows
    '        Dim sp As New DBSchema.StoreProcedure(Me.mDataBase, row)
    '        Dim node As New TreeNode(sp.ObjName, NodeTypes.Sp, NodeTypes.Sp)
    '        node.Tag = sp
    '        parentNode.Nodes.Add(node)
    '    Next
    'End Sub
    Private Sub initFunctions(ByVal parentNode As TreeNode)
        'initCateGolys(parentNode, CateGolyType.FUNCTION)
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
    'Private Sub initFunctions(ByVal parentNode As TreeNode, ByVal categolyname As String)
    '    Dim DbSchema As New DBSchemaControler()
    '    Dim dtt As DataTable = DbSchema.GetFunctions(Me.mDataBase, categolyname)
    '    Dim row As DataRow = Nothing
    '    For Each row In dtt.Rows
    '        Dim fn As New DBSchema.Function(Me.mDataBase, row)
    '        Dim node As New TreeNode(fn.ObjName)
    '        If fn.Type.ToUpper = "FN" Then
    '            node.ImageIndex = NodeTypes.Sp
    '            node.SelectedImageIndex = NodeTypes.Sp

    '        Else
    '            node.ImageIndex = NodeTypes.IFN
    '            node.SelectedImageIndex = NodeTypes.IFN
    '        End If
    '        node.Tag = fn
    '        parentNode.Nodes.Add(node)
    '    Next
    'End Sub
    'Private Sub initCateGolys(ByVal parentNode As TreeNode, ByVal type As CateGolyType)
    '    Dim DbSchema As New DBSchemaControler()
    '    Dim dtt As DataTable = DbSchema.GetCateGolys(Me.mDataBase, type)
    '    Dim row As DataRow = Nothing
    '    For Each row In dtt.Rows
    '        Dim cate As New DBSchema.CateGoly(Me.mDataBase, row)
    '        Dim node As New TreeNode(cate.ObjName)
    '        node.ImageIndex = NodeTypes.Categoly
    '        node.SelectedImageIndex = NodeTypes.Categoly
    '        node.Tag = cate
    '        Select Case type
    '            Case CateGolyType.TABLE
    '                Me.initTables(node, cate.ObjName)
    '            Case CateGolyType.VIEW
    '                Me.initViews(node, cate.ObjName)
    '            Case CateGolyType.PROCEDURE
    '                Me.initSPs(node, cate.ObjName)
    '            Case CateGolyType.FUNCTION
    '                Me.initFunctions(node, cate.ObjName)
    '        End Select
    '        parentNode.Nodes.Add(node)
    '    Next
    'End Sub
    Private Sub initPackages(ByVal parentNode As TreeNode)
        'initCateGolys(parentNode, CateGolyType.FUNCTION)
        Dim DbSchema As New DBSchemaControler()
        Dim dtt As DataTable = DbSchema.GetPackages(Me.mDataBase)
        Dim row As DataRow = Nothing
        For Each row In dtt.Rows
            Dim package As New DBSchema.Package(Me.mDataBase, row)
            Dim node As New TreeNode(package.ObjName)

            node.ImageIndex = NodeTypes.Package
            node.SelectedImageIndex = NodeTypes.Package

            node.Tag = package
            parentNode.Nodes.Add(node)
        Next
    End Sub
    Private Sub initPackageBodies(ByVal parentNode As TreeNode)

        Dim DbSchema As New DBSchemaControler()
        Dim dtt As DataTable = DbSchema.GetPackageBodies(Me.mDataBase)
        Dim row As DataRow = Nothing
        For Each row In dtt.Rows
            Dim packageBody As New DBSchema.PackageBody(Me.mDataBase, row)
            Dim node As New TreeNode(packageBody.ObjName)

            node.ImageIndex = NodeTypes.PackageBody
            node.SelectedImageIndex = NodeTypes.PackageBody

            node.Tag = packageBody
            parentNode.Nodes.Add(node)
        Next
    End Sub
    Private Sub initSeqences(ByVal parentNode As TreeNode)

        Dim DbSchema As New DBSchemaControler()
        Dim dtt As DataTable = DbSchema.GetSeqences(Me.mDataBase)
        Dim row As DataRow = Nothing
        For Each row In dtt.Rows
            Dim seq As New DBSchema.Sequence(Me.mDataBase, row)
            Dim node As New TreeNode(seq.ObjName)

            node.ImageIndex = NodeTypes.Seqence
            node.SelectedImageIndex = NodeTypes.Seqence

            node.Tag = seq
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
                mnuCont = New ContextMenu(New MenuItem() {Me.MNU_REFRASH.CloneMenu()})
            Case NodeTypes.View
                mnuCont = New ContextMenu(New MenuItem() {mnu_OpenObject.CloneMenu(), Me.mnu_OpenView.CloneMenu()})
            Case NodeTypes.Table
                mnuCont = New ContextMenu(New MenuItem() {mnu_OpenObject.CloneMenu(), Me.mnuGetDDL.CloneMenu(), Me.mnuSQLCreate.CloneMenu()})
            Case NodeTypes.Fn, NodeTypes.IFN, NodeTypes.Sp
                mnuCont = New ContextMenu(New MenuItem() {mnu_OpenObject.CloneMenu()})
            Case NodeTypes.Package, NodeTypes.PackageBodies, NodeTypes.Seqence
                mnuCont = New ContextMenu(New MenuItem() {mnu_OpenObject.CloneMenu()})

        End Select
        Me.tvwDb.SelectedNode = node
        If Not mnuCont Is Nothing Then
            mnuCont.Show(Me.tvwDb, pt)
        End If
    End Sub
    Private Function CreateSqlEditer(ByVal code As String) As SplitContainer
        Dim pnlSplit As New SplitContainer
        pnlSplit.Dock = DockStyle.Fill
        pnlSplit.Orientation = Orientation.Horizontal
        pnlSplit.Panel2Collapsed = True
        Dim txtEditor As New SqlEditor()
        txtEditor.Document.HighlightingStrategy = ICSharpCode.TextEditor.Document.HighlightingStrategyFactory.CreateHighlightingStrategy("ORACLE")
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
            dtgData.CaptionVisible = True
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

            Case SqlObjectType.Procedure
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
            Case SqlObjectType.Package
                Dim pkg As DBSchema.Package = DirectCast(sqlObj, DBSchema.Package)
                Dim code As String = pkg.GetDDLCode
                Dim tab As New TabPage(pkg.ObjName)
                tab.Tag = pkg
                tab.ImageIndex = NodeTypes.Package
                Dim Panel As SplitContainer = Me.CreateSqlEditer(code)
                tab.Controls.Add(Panel)
                Panel.Dock = DockStyle.Fill
                tabMain.AddTabPage(tab)
            Case SqlObjectType.PackageBody
                Dim pkg As DBSchema.PackageBody = DirectCast(sqlObj, DBSchema.PackageBody)
                Dim code As String = pkg.GetDDLCode
                Dim tab As New TabPage(pkg.ObjName & "-本体")
                tab.Tag = pkg
                tab.ImageIndex = NodeTypes.PackageBody
                Dim Panel As SplitContainer = Me.CreateSqlEditer(code)
                tab.Controls.Add(Panel)
                Panel.Dock = DockStyle.Fill
                tabMain.AddTabPage(tab)
            Case SqlObjectType.Seqence
                Dim seq As DBSchema.Sequence = DirectCast(sqlObj, DBSchema.Sequence)
                Dim code As String = seq.GetDDLCode
                Dim tab As New TabPage(seq.ObjName)
                tab.Tag = seq
                tab.ImageIndex = NodeTypes.Seqence
                Dim Panel As SplitContainer = Me.CreateSqlEditer(code)
                tab.Controls.Add(Panel)
                Panel.Dock = DockStyle.Fill
                tabMain.AddTabPage(tab)
        End Select
    End Sub

    ''' <summary>
    ''' SQLオブジェクトを開く
    ''' </summary>
    ''' <param name="sqlObj"></param>
    ''' <remarks></remarks>
    Private Sub OpenSqlDDL(ByVal sqlObj As iSqlObject)
        Select Case sqlObj.ObjType
            Case SqlObjectType.Table
                Dim objTable As DBSchema.Table = DirectCast(sqlObj, DBSchema.Table)
                Dim code As String = objTable.GetDDLCode()
                Dim tab As New TabPage(objTable.ObjName)
                tab.ImageIndex = NodeTypes.View
                tab.Tag = objTable
                Dim Panel As SplitContainer = Me.CreateSqlEditer(code)
                tab.Controls.Add(Panel)
                Panel.Dock = DockStyle.Fill
                tabMain.AddTabPage(tab)

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

            Case SqlObjectType.Procedure
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
    ''' <summary>
    ''' SQLオブジェクトを開く
    ''' </summary>
    ''' <param name="sqlObj"></param>
    ''' <remarks></remarks>
    Private Sub OpenSelectSql(ByVal sqlObj As iSqlObject)
        Select Case sqlObj.ObjType
            Case SqlObjectType.Table
                Dim objTable As DBSchema.Table = DirectCast(sqlObj, DBSchema.Table)
                Dim code As String = objTable.GetSelectCode()
                Dim tab As New TabPage(objTable.ObjName)
                tab.ImageIndex = NodeTypes.SQL
                tab.Tag = New SqlQuery(Me.mDataBase, code, objTable.ObjName, AddressOf GetParameter)
                Dim Panel As SplitContainer = Me.CreateSqlEditer(code)
                tab.Controls.Add(Panel)
                Panel.Dock = DockStyle.Fill
                tabMain.AddTabPage(tab)

            Case SqlObjectType.View
                Dim view As DBSchema.Table = DirectCast(sqlObj, DBSchema.Table)
                Dim code As String = view.GetSelectCode()
                Dim tab As New TabPage(view.ObjName)
                tab.ImageIndex = NodeTypes.SQL
                tab.Tag = New SqlQuery(Me.mDataBase, code, view.ObjName, AddressOf GetParameter)
                Dim Panel As SplitContainer = Me.CreateSqlEditer(code)
                tab.Controls.Add(Panel)
                Panel.Dock = DockStyle.Fill
                tabMain.AddTabPage(tab)
            Case SqlObjectType.Procedure


            Case SqlObjectType.Function


        End Select
    End Sub
    ''' <summary>
    ''' SQLクエリを実行する
    ''' </summary>
    ''' <param name="sqlObj"></param>
    ''' <param name="SqlText"></param>
    ''' <remarks></remarks>
    Private Sub RunSqlQuery(ByVal sqlObj As iSqlObject, ByVal SqlText As String, ByVal cmdType As CommandType)
        Select Case sqlObj.ObjType
            Case SqlObjectType.Procedure
                If Messages.ShowQuery(Questions.IsExcuteOk) = Windows.Forms.DialogResult.Yes Then
                    CType(sqlObj, StoreProcedure).Update(SqlText)
                End If
            Case SqlObjectType.Function
                If Messages.ShowQuery(Questions.IsExcuteOk) = Windows.Forms.DialogResult.Yes Then
                    CType(sqlObj, [Function]).Update(SqlText)
                End If
            Case SqlObjectType.SqlQuery
                Dim errmsg As String = ""


                Me.QueryWorker.WorkerSupportsCancellation = True
                Me.QueryWorker.WorkerReportsProgress = True
                Me.QueryWorker.RunWorkerAsync(New SqlCommandArgs(sqlObj, SqlText, cmdType))

            Case SqlObjectType.View

            Case Else

        End Select
    End Sub


    ''' <summary>
    ''' SQLクエリを実行する
    ''' </summary>
    ''' <param name="sqlObj"></param>
    ''' <param name="SqlText"></param>
    ''' <remarks></remarks>
    Private Sub RunDDL(ByVal sqlObj As iSqlObject, ByVal SqlText As String, ByVal cmdType As CommandType)
        Select Case sqlObj.ObjType
            Case SqlObjectType.Procedure
                If Messages.ShowQuery(Questions.IsExcuteOk) = Windows.Forms.DialogResult.Yes Then
                    CType(sqlObj, StoreProcedure).Update(SqlText)
                End If
            Case SqlObjectType.Function
                If Messages.ShowQuery(Questions.IsExcuteOk) = Windows.Forms.DialogResult.Yes Then
                    CType(sqlObj, [Function]).Update(SqlText)
                End If
            Case SqlObjectType.SqlQuery
                Dim errmsg As String = ""
                Dim infomsg As String = ""
                Dim result As Integer = CType(sqlObj, SqlQuery).ExecDDL(SqlText, errmsg)
                If String.IsNullOrEmpty(errmsg) Then
                    If result > 0 Then
                        infomsg = String.Format("正常完了しました。({0}行を更新しました。)", result)
                    Else
                        infomsg = "正常完了しました。"
                    End If
                Else
                    infomsg = ""
                End If
                SetQueryResult(Nothing, errmsg, infomsg)
            Case SqlObjectType.View

            Case Else

        End Select
    End Sub

    Private Sub SetQueryResult(ByVal dts As DataSet, ByVal errmsg As String, ByVal infoMsg As String)


        If dts IsNot Nothing AndAlso dts.Tables.Count > 0 Then
            Dim spliter As SplitContainer = TryCast(Me.tabMain.SelectedTab.Controls.Item(0), SplitContainer)
            If spliter IsNot Nothing Then
                Me.ShowDataGrid(spliter, dts)
            End If
        ElseIf String.IsNullOrEmpty(errmsg) = False Then
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
        ElseIf String.IsNullOrEmpty(infoMsg) = False Then
            Dim spliter As SplitContainer = TryCast(Me.tabMain.SelectedTab.Controls.Item(0), SplitContainer)
            If spliter IsNot Nothing Then
                spliter.Panel2.Controls.Clear()
                If infoMsg <> "" Then
                    Dim txtMsg As New TextBox
                    txtMsg.Multiline = True
                    txtMsg.ReadOnly = True
                    txtMsg.ForeColor = Color.Black
                    txtMsg.BorderStyle = BorderStyle.Fixed3D
                    txtMsg.BackColor = Color.White
                    txtMsg.Text = infoMsg
                    spliter.Panel2.Controls.Add(txtMsg)
                    txtMsg.Dock = DockStyle.Fill
                    spliter.Panel2Collapsed = False
                Else
                    spliter.Panel2Collapsed = True
                End If
            End If
        End If
    End Sub
#End Region
#Region "フォームエベント"
    Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitDataBase()
        initTreeFolder(mDataBase)
        Me.LeftSplitContainer.Panel2Collapsed = True
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

    Private Sub mnuGetDDL_Click(sender As Object, e As System.EventArgs) Handles mnuGetDDL.Click
        If Me.tvwDb.SelectedNode Is Nothing Then
            Return
        End If
        Dim tag As Object = Me.tvwDb.SelectedNode.Tag
        If Not TypeOf tag Is iSqlObject Then Return
        Dim isqlObj As iSqlObject = CType(tag, iSqlObject)
        OpenSqlDDL(isqlObj)
    End Sub
    Private Sub mnuSelectSql_Click(sender As Object, e As System.EventArgs) Handles mnuSelectSql.Click
        If Me.tvwDb.SelectedNode Is Nothing Then
            Return
        End If
        Dim tag As Object = Me.tvwDb.SelectedNode.Tag
        If Not TypeOf tag Is iSqlObject Then Return
        Dim isqlObj As iSqlObject = CType(tag, iSqlObject)
        Me.OpenSelectSql(isqlObj)
    End Sub

    Private Sub mnu_OpenView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnu_OpenView.Click
        If Me.tvwDb.SelectedNode Is Nothing Then
            Return
        End If
        Dim tag As Object = Me.tvwDb.SelectedNode.Tag
        If Not TypeOf tag Is DBSchema.View Then Return
        Dim code As String = CType(tag, DBSchema.View).GetOpenSql()
        Dim filename As String = Me.mDataBase & "-クエリ" & Me.tabMain.GetNewQueryIndex
        Dim query As New SqlQuery(Me.mDataBase, code, filename, AddressOf GetParameter)
        Me.OpenSqlObject(query)
        Me.RunSqlQuery(query, query.SqlText, CommandType.Text)
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
        Dim query As New SqlQuery(Me.mDataBase, "", filename, AddressOf GetParameter)
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
                Me.RunSqlQuery(sqlObj, sqltxt, CommandType.Text)
            End If
        Catch ex As Exception
            Messages.ShowExcption(ex)
        End Try
    End Sub
    'DDL実行
    Private Sub mnuDDLRun_Click(sender As System.Object, e As System.EventArgs) Handles mnuDDLRun.Click
        Try
            If Me.tabMain.SelectedTab Is Nothing Then
                Return
            End If
            Dim sqltxt As String = Me.GetCurrentSqlText
            Dim tag As Object = Me.tabMain.SelectedTab.Tag
            If tag IsNot Nothing And TypeOf tag Is iSqlObject Then
                Dim sqlObj As iSqlObject = DirectCast(tag, iSqlObject)
                Me.RunDDL(sqlObj, sqltxt, CommandType.Text)
            End If
        Catch ex As Exception
            Messages.ShowExcption(ex)
        End Try
    End Sub

    ''' <summary>
    ''' SQLプロシージャ実行
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuProcedureRun_Click(sender As System.Object, e As System.EventArgs) Handles mnuProcedureRun.Click
        Try
            If Me.tabMain.SelectedTab Is Nothing Then
                Return
            End If
            Dim sqltxt As String = Me.GetCurrentSqlText
            Dim tag As Object = Me.tabMain.SelectedTab.Tag
            If tag IsNot Nothing And TypeOf tag Is iSqlObject Then
                Dim sqlObj As iSqlObject = DirectCast(tag, iSqlObject)
                Me.RunSqlQuery(sqlObj, sqltxt, CommandType.StoredProcedure)
            End If
        Catch ex As Exception
            Messages.ShowExcption(ex)
        End Try
    End Sub

    'SQLキャンセル
    Private Sub mnuCancel_Click(sender As System.Object, e As System.EventArgs) Handles mnuCancel.Click
        Try
            If Me.tabMain.SelectedTab Is Nothing Then
                Return
            End If
            If Me.QueryWorker.IsBusy AndAlso Me.QueryWorker.CancellationPending = False Then
                Me.QueryWorker.ReportProgress(50, New QueryResult(True))
            End If

        Catch ex As Exception
            Messages.ShowExcption(ex)
        End Try
    End Sub
#End Region
#Region "コントロールエベント"

    Private Sub cmbDataBase_RegionChanged(sender As Object, e As System.EventArgs) Handles cmbDataBase.RegionChanged

    End Sub
    Private Sub cmbDataBase_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbDataBase.SelectedIndexChanged
        If Me.cmbDataBase.SelectedIndex <> -1 Then
            Me.mDataBase = CStr(Me.cmbDataBase.Items(cmbDataBase.SelectedIndex))
            initTreeFolder(mDataBase)
        End If
    End Sub

    Private Sub tvwDb_AfterSelect(sender As Object, e As System.Windows.Forms.TreeViewEventArgs) Handles tvwDb.AfterSelect
        Try
            If Me.tvwDb.SelectedNode Is Nothing Then
                HideTableColumns()
                Return
            End If
            Dim tag As Object = Me.tvwDb.SelectedNode.Tag
            If Not TypeOf tag Is iSqlObject Then
                HideTableColumns()
                Return
            End If
            Dim isqlObj As iSqlObject = CType(tag, iSqlObject)

            ShowTableColumns(isqlObj)
        Catch ex As Exception
            Messages.ShowExcption(ex)
        End Try

    End Sub

    Private Sub tvwDb_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles tvwDb.KeyDown
        Try
            If Me.tvwDb.SelectedNode Is Nothing Then
                Return
            End If
            If e.KeyCode = Keys.C Then
                Dim tag As Object = Me.tvwDb.SelectedNode.Tag
                If e.Control AndAlso e.Shift Then
                    If TypeOf tag Is Table Then
                        Clipboard.SetText(CType(tag, Table).GetSelectCode)
                    ElseIf TypeOf tag Is View Then
                        Clipboard.SetText(CType(tag, View).GetSelectCode)
                    ElseIf TypeOf tag Is iSqlObject Then
                        Clipboard.SetText(CType(tag, iSqlObject).GetFullName)
                    End If
                ElseIf e.Control Then
                    If TypeOf tag Is iSqlObject Then
                        Clipboard.SetText(CType(tag, iSqlObject).ObjName)
                    End If

                End If
            End If
        Catch ex As Exception
            Messages.ShowExcption(ex)
        End Try

    End Sub

    Private Sub ShowTableColumns(ByVal obj As iSqlObject)
        Dim dttColumn As DataTable = Nothing
        DataGridView1.Columns.Clear()
        Select Case obj.ObjType
            Case SqlObjectType.Function
                dttColumn = CType(obj, [Function]).GetArguement()
            Case SqlObjectType.Procedure
                dttColumn = CType(obj, StoreProcedure).GetArguement()
            Case SqlObjectType.Table
                dttColumn = CType(obj, Table).GetColumns()
                SetTableColumnStyle(dttColumn)
            Case SqlObjectType.View
                dttColumn = CType(obj, View).GetColumns()
            Case SqlObjectType.Seqence
                dttColumn = CType(obj, Sequence).GetPropertys()
            Case Else
                HideTableColumns()
                Return
        End Select
        Me.DataGridView1.DataSource = dttColumn
        Me.LeftSplitContainer.Panel2Collapsed = False
    End Sub

    Private Sub SetTableColumnStyle(ByVal dttColumn As DataTable)
        Dim columns As New List(Of DataGridViewColumn)
        Dim index As Integer = 0
        For Each column As DataColumn In dttColumn.Columns
            Dim viewColumn As DataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
            viewColumn.ReadOnly = True
            viewColumn.DataPropertyName = column.ColumnName
            viewColumn.HeaderText = column.ColumnName
            If index > 1 Then
                viewColumn.Width = 25
            End If
            DataGridView1.Columns.Add(viewColumn)
            index += 1
        Next

    End Sub

    Private Sub HideTableColumns()

        Me.DataGridView1.DataSource = Nothing
        Me.LeftSplitContainer.Panel2Collapsed = True
    End Sub

    Private Sub tvwDb_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvwDb.DoubleClick
        Try
            If Me.tvwDb.SelectedNode Is Nothing Then
                Return
            End If
            Dim tag As Object = Me.tvwDb.SelectedNode.Tag
            If Not TypeOf tag Is iSqlObject Then Return
            Dim isqlObj As iSqlObject = CType(tag, iSqlObject)
            OpenSqlObject(isqlObj)

        Catch ex As Exception
            Messages.ShowExcption(ex)
        End Try


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
    <STAThread()>
    Public Sub GetParameter(ByRef parameters As List(Of DBParameter))
        Using frm As New frmSetParameters
            frm.DBParameters = parameters
            frm.ShowDialog()
        End Using

    End Sub


    ''' <summary>
    ''' クエリを実行する
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub QueryWorker_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles QueryWorker.DoWork
        If Not TypeOf e.Argument Is SqlCommandArgs Then
            Return
        End If
        Dim args As SqlCommandArgs = CType(e.Argument, SqlCommandArgs)
        If args Is Nothing Then Return
        Dim sqlobj As iSqlObject = args.SqlObject
        Dim sqltext As String = args.SqlText
        Dim sqlType As CommandType = args.CommandType
        Me.mRunningQuery = sqlobj
        Me.QueryWorker.ReportProgress(0, "クエリを実行しています...")
        Dim errmsg As String = ""
        Dim resultDts As DataSet = Nothing
        If sqlType = CommandType.Text Then
            resultDts = CType(sqlobj, SqlQuery).ExecSql(sqltext, errmsg)
        Else
            resultDts = CType(sqlobj, SqlQuery).ExecProcedureSql(sqltext, errmsg)
        End If
        Me.QueryWorker.ReportProgress(100, New QueryResult(resultDts, errmsg))

    End Sub

    Private Sub QueryWorker_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles QueryWorker.ProgressChanged
        If e.ProgressPercentage = 0 Then
            Me.statusBarMessage.Text = "クエリを実行しています..."
            Return
        End If
        If Not e.UserState Is Nothing AndAlso TypeOf e.UserState Is QueryResult Then
            Dim result As QueryResult = CType(e.UserState, QueryResult)
            If result.Canceled Then
                Me.statusBarMessage.Text = "処理をキャンセルしています。"
                If Me.mRunningQuery IsNot Nothing And TypeOf mRunningQuery Is SqlQuery Then
                    Dim sqlObj As SqlQuery = DirectCast(mRunningQuery, SqlQuery)
                    sqlObj.Cancel()
                End If
                QueryWorker.CancelAsync()
            Else
                Me.SetQueryResult(result.DataResult, result.ErrorMessage, "")
            End If
        End If

    End Sub

    ''' <summary>
    ''' 処理を取り消し
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub QueryWorker_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles QueryWorker.RunWorkerCompleted
        If e.Cancelled Then
            Me.statusBarMessage.Text = "処理をキャンセルしました。"
            Return
        End If
        If e.Error IsNot Nothing Then
            Me.statusBarMessage.Text = "異常が発生しました。" & e.Error.Message
            Return
        End If
        Me.statusBarMessage.Text = "正常完了しました。"
    End Sub


#End Region

    Public Class QueryResult
        Private _dataResult As DataSet
        Private _message As String
        Private _canceled As Boolean = False
        Public ReadOnly Property DataResult As DataSet
            Get
                Return Me._dataResult
            End Get
        End Property
        Public ReadOnly Property ErrorMessage As String
            Get
                Return Me._message
            End Get
        End Property
        Public ReadOnly Property HasError As Boolean
            Get
                Return String.IsNullOrEmpty(Me._message)
            End Get
        End Property
        Public ReadOnly Property Canceled As Boolean
            Get
                Return _canceled
            End Get
        End Property
        Public Sub New(ByVal dts As DataSet, ByVal errMsg As String)
            Me._dataResult = dts
            Me._message = errMsg
        End Sub
        Public Sub New(ByVal canceled As Boolean)
            _canceled = canceled
        End Sub
    End Class



#Region "テキスト検索"

    ''' <summary>
    ''' 検索
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnFindDown_Click(sender As System.Object, e As System.EventArgs) Handles btnFindDown.Click
        FindNext()
    End Sub

    Private Sub btnFindUp_Click(sender As System.Object, e As System.EventArgs) Handles btnFindUp.Click
        FindPrev()
    End Sub

    Private Sub mnuFindPrev_Click(sender As System.Object, e As System.EventArgs) Handles mnuFindPrev.Click
        FindPrev()
    End Sub

    Private Sub mnuFind_Click(sender As System.Object, e As System.EventArgs) Handles mnuFindNext.Click
        FindNext()
    End Sub

    Private Sub FindPrev()
        If Me.tabMain.SelectedTab Is Nothing Then
            Return
        End If
        Dim ctrl As Object = Me.tabMain.SelectedTab.Controls(0)
        If Not TypeOf ctrl Is SplitContainer Then
            Return
        End If
        Dim spliter As SplitContainer = DirectCast(ctrl, SplitContainer)
        Dim sqlEditor As SqlEditor = CType(spliter.Panel1.Controls.Item(0), SqlEditor)
        Dim findWord As String = Me.txtFindWord.Text
        If String.IsNullOrEmpty(findWord) Then Return
        sqlEditor.FindPrevWord(findWord)
    End Sub
    Private Sub FindNext()
        If Me.tabMain.SelectedTab Is Nothing Then
            Return
        End If
        Dim ctrl As Object = Me.tabMain.SelectedTab.Controls(0)
        If Not TypeOf ctrl Is SplitContainer Then
            Return
        End If
        Dim spliter As SplitContainer = DirectCast(ctrl, SplitContainer)
        Dim sqlEditor As SqlEditor = CType(spliter.Panel1.Controls.Item(0), SqlEditor)
        Dim findWord As String = Me.txtFindWord.Text
        If String.IsNullOrEmpty(findWord) Then Return
        sqlEditor.FindNextWord(findWord)
    End Sub
    Private Sub mnuFindBegin_Click(sender As System.Object, e As System.EventArgs) Handles mnuFindBegin.Click
        If Me.tabMain.SelectedTab Is Nothing Then
            Return
        End If
        Dim ctrl As Object = Me.tabMain.SelectedTab.Controls(0)
        If Not TypeOf ctrl Is SplitContainer Then
            Return
        End If
        Dim spliter As SplitContainer = DirectCast(ctrl, SplitContainer)
        Dim sqlEditor As SqlEditor = CType(spliter.Panel1.Controls.Item(0), SqlEditor)
        Dim txt As String = sqlEditor.Document.SelectedText
        If String.IsNullOrEmpty(txt) Then Return
        Me.txtFindWord.Text = txt
        sqlEditor.FindNextWord(txt)
    End Sub
#End Region
#Region "SqlCommandArgs Class"
    Public Class SqlCommandArgs
        Public Property SqlObject As iSqlObject
        Public Property SqlText As String
        Public Property CommandType As CommandType
        Public Sub New(sqlobj As iSqlObject, sql As String, type As CommandType)
            Me.SqlObject = sqlobj
            Me.SqlText = sql
            Me.CommandType = type
        End Sub
    End Class

#End Region

   
End Class
