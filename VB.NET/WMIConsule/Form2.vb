Imports System.Management
Public Class Form2
    Inherits System.Windows.Forms.Form

#Region " Windows フォーム デザイナで生成されたコード "

    Public Sub New()
        MyBase.New()

        ' この呼び出しは Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後に初期化を追加します。

    End Sub

    ' Form は、コンポーネント一覧に後処理を実行するために dispose をオーバーライドします。
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
    'Windows フォーム デザイナを使って変更してください。  
    ' コード エディタを使って変更しないでください。
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents Splitter2 As System.Windows.Forms.Splitter
    Friend WithEvents txtWsql As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.TreeView1 = New System.Windows.Forms.TreeView
        Me.Splitter1 = New System.Windows.Forms.Splitter
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.Splitter2 = New System.Windows.Forms.Splitter
        Me.txtWsql = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnSearch = New System.Windows.Forms.Button
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TreeView1
        '
        Me.TreeView1.Dock = System.Windows.Forms.DockStyle.Left
        Me.TreeView1.ImageIndex = -1
        Me.TreeView1.Location = New System.Drawing.Point(0, 0)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.SelectedImageIndex = -1
        Me.TreeView1.Size = New System.Drawing.Size(296, 573)
        Me.TreeView1.TabIndex = 0
        '
        'Splitter1
        '
        Me.Splitter1.Location = New System.Drawing.Point(296, 0)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(3, 573)
        Me.Splitter1.TabIndex = 1
        Me.Splitter1.TabStop = False
        '
        'DataGrid1
        '
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.Dock = System.Windows.Forms.DockStyle.Top
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(299, 0)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.Size = New System.Drawing.Size(461, 304)
        Me.DataGrid1.TabIndex = 2
        '
        'Splitter2
        '
        Me.Splitter2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Splitter2.Location = New System.Drawing.Point(299, 304)
        Me.Splitter2.Name = "Splitter2"
        Me.Splitter2.Size = New System.Drawing.Size(461, 3)
        Me.Splitter2.TabIndex = 3
        Me.Splitter2.TabStop = False
        '
        'txtWsql
        '
        Me.txtWsql.Location = New System.Drawing.Point(8, 8)
        Me.txtWsql.Multiline = True
        Me.txtWsql.Name = "txtWsql"
        Me.txtWsql.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtWsql.Size = New System.Drawing.Size(448, 192)
        Me.txtWsql.TabIndex = 4
        Me.txtWsql.Text = ""
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnSearch)
        Me.Panel1.Controls.Add(Me.txtWsql)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(299, 307)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(461, 266)
        Me.Panel1.TabIndex = 5
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(328, 224)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(112, 32)
        Me.btnSearch.TabIndex = 5
        Me.btnSearch.Text = "検索"
        '
        'Form2
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
        Me.ClientSize = New System.Drawing.Size(760, 573)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Splitter2)
        Me.Controls.Add(Me.DataGrid1)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.TreeView1)
        Me.Name = "Form2"
        Me.Text = "Form2"
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim WmiClasses As New WMIAPI.WMIClasses
        Dim TopNode As New TreeNode("Root")
        Me.TreeView1.Nodes.Add(TopNode)
        Dim CIMV2 As New TreeNode("CIMV2")
        TopNode.Nodes.Add(CIMV2)
        

        Dim Mobjs As ManagementObjectCollection = WmiClasses.GetCIMV2Classes
        SetTreeNodes(CIMV2, Mobjs)
        Dim DALP As New TreeNode("LDAP")
        TopNode.Nodes.Add(DALP)
        Mobjs = WmiClasses.GetLDAPClasses
        SetTreeNodes(DALP, Mobjs)

    End Sub
    Private Function GetSubClass(ByVal mobj As ManagementObject) As ManagementObjectCollection
        If mobj.ClassPath.IsClass Then
            Dim newclass As New ManagementClass(mobj.ClassPath)
            Dim opt As New EnumerationOptions
            opt.Rewindable = True
            Dim msubObjs As ManagementObjectCollection = newclass.GetSubclasses(opt)
            If msubObjs Is Nothing Then Return Nothing
            Return msubObjs
        End If
    End Function
    Private Sub SetTreeNodes(ByVal ParentNode As TreeNode, ByVal mObjs As ManagementObjectCollection)
        'Dim count As Integer = mObjs.Count
        Try
            For Each mobj As ManagementObject In mObjs

                Dim Node As New TreeNode(mobj.ClassPath.ClassName)
                Node.Tag = mobj.ClassPath
                Dim subClasses As ManagementObjectCollection = GetSubClass(mobj)
                If Not subClasses Is Nothing Then
                    SetTreeNodes(Node, subClasses)
                End If
                ParentNode.Nodes.Add(Node)
            Next mobj

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TreeView1_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect
        Try
            Dim node As TreeNode = e.Node
            If Not node.Tag Is Nothing Then
                Dim classpath As ManagementPath = DirectCast(node.Tag, ManagementPath)
                'Dim newclass As New ManagementClass(classpath)
                ' Me.txtWsql.Text = newclass.GetText(TextFormat.Mof)
                Dim wsql As String = " Select * from " & classpath.ClassName
                Me.txtWsql.Text = wsql
                'Dim mobjs As ManagementObjectCollection = WMIAPI.WMIQuery.Search(wsql)

                'Dim dtt As DataTable = ConvertMobjectToDatatanle(mobjs)
                'Dim dtview As New DataView(dtt)
                'dtview.AllowEdit = False
                'dtview.AllowNew = False
                'dtview.AllowDelete = False
                'Me.DataGrid1.DataSource = dtview
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Function ConvertMobjectToDatatanle(ByVal mObjs As ManagementObjectCollection) As DataTable
        Dim Dtt As New DataTable
        Dim index As Integer = 0
        For Each mobj As ManagementObject In mObjs
            If index = 0 Then
                AddColumn(Dtt, mobj)
            End If
            Dim row As DataRow = Dtt.NewRow
            For Each column As DataColumn In Dtt.Columns
                Dim value As Object = mobj.Item(column.ColumnName)
                row.Item(column.ColumnName) = SetRow(value)
            Next
            Dtt.Rows.Add(row)
            index += 1
        Next
        Return Dtt
    End Function
    Private Sub AddColumn(ByVal dtt As DataTable, ByVal mobj As ManagementObject)
        For Each prop As Management.PropertyData In mobj.Properties
            If dtt.Columns.Contains(prop.Name) = False Then

                Dim column As New DataColumn(prop.Name)
                Dim datatype As System.Type
                Select Case prop.Type
                    Case CimType.Boolean
                        column.DataType = GetType(System.Boolean)
                        dtt.Columns.Add(column)
                    Case CimType.Char16
                        column.DataType = GetType(System.String)
                        dtt.Columns.Add(column)
                    Case CimType.DateTime
                        'column.DataType = GetType(System.DateTime)
                        dtt.Columns.Add(column)
                    Case CimType.Object
                        'column.DataType = prop.Value.GetType
                        dtt.Columns.Add(column)
                    Case CimType.Real32
                        'column.DataType = GetType(System.Double)
                        dtt.Columns.Add(column)
                    Case CimType.Real64
                        'column.DataType = GetType(System.Double)
                        dtt.Columns.Add(column)
                    Case CimType.Reference
                        'column.DataType = prop.Value.GetType
                        dtt.Columns.Add(column)
                    Case CimType.SInt16
                        'column.DataType = GetType(System.Int16)
                        dtt.Columns.Add(column)
                    Case CimType.SInt32
                        'column.DataType = GetType(System.Int32)
                        dtt.Columns.Add(column)
                    Case CimType.SInt64
                        'column.DataType = GetType(System.Int64)
                        dtt.Columns.Add(column)
                    Case CimType.SInt8
                        'column.DataType = GetType(System.Int16)
                        dtt.Columns.Add(column)
                    Case CimType.String
                        column.DataType = GetType(System.String)
                        dtt.Columns.Add(column)
                    Case CimType.UInt16
                        'column.DataType = GetType(System.UInt16)
                        dtt.Columns.Add(column)
                    Case CimType.UInt32
                        'column.DataType = GetType(System.UInt32)
                        dtt.Columns.Add(column)
                    Case CimType.UInt64
                        'column.DataType = GetType(System.UInt64)
                        dtt.Columns.Add(column)
                    Case CimType.UInt8
                        'column.DataType = GetType(System.UInt16)
                        dtt.Columns.Add(column)
                End Select
            End If
        Next
    End Sub
    Private Function SetRow(ByVal obj As Object) As Object
        If obj Is Nothing Then
            Return DBNull.Value
        Else
            Return obj
        End If
    End Function

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try
            Dim wsql As String = Me.txtWsql.Text
            Dim mobjs As ManagementObjectCollection = WMIAPI.WMIQuery.Search(wsql)

            Dim dtt As DataTable = ConvertMobjectToDatatanle(mobjs)
            Dim dtview As New DataView(dtt)
            dtview.AllowEdit = False
            dtview.AllowNew = False
            dtview.AllowDelete = False
            Me.DataGrid1.DataSource = dtview

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
