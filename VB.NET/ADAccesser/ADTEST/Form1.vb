Imports RTS.Common.ActiveDirctroy
Public Class Form1
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
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtUser As System.Windows.Forms.TextBox
    Friend WithEvents txtpassword As System.Windows.Forms.TextBox
    Friend WithEvents ADTree As System.Windows.Forms.TreeView
    Friend WithEvents btnAllUser As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents txtKeyword As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDomain As System.Windows.Forms.TextBox
    Friend WithEvents btnLogin As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents txtLDAP As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button
        Me.txtUser = New System.Windows.Forms.TextBox
        Me.txtpassword = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.ADTree = New System.Windows.Forms.TreeView
        Me.btnAllUser = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.txtKeyword = New System.Windows.Forms.TextBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtLDAP = New System.Windows.Forms.TextBox
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtDomain = New System.Windows.Forms.TextBox
        Me.btnLogin = New System.Windows.Forms.Button
        Me.Button6 = New System.Windows.Forms.Button
        Me.Button7 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(439, 33)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "GetDircroy"
        '
        'txtUser
        '
        Me.txtUser.Location = New System.Drawing.Point(45, 5)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(100, 19)
        Me.txtUser.TabIndex = 1
        Me.txtUser.Text = "maxz"
        '
        'txtpassword
        '
        Me.txtpassword.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpassword.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.txtpassword.Location = New System.Drawing.Point(207, 4)
        Me.txtpassword.Name = "txtpassword"
        Me.txtpassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtpassword.Size = New System.Drawing.Size(104, 21)
        Me.txtpassword.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "User"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(153, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 12)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Password"
        '
        'ADTree
        '
        Me.ADTree.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ADTree.Location = New System.Drawing.Point(0, 99)
        Me.ADTree.Name = "ADTree"
        Me.ADTree.Size = New System.Drawing.Size(755, 476)
        Me.ADTree.TabIndex = 5
        '
        'btnAllUser
        '
        Me.btnAllUser.Location = New System.Drawing.Point(597, 66)
        Me.btnAllUser.Name = "btnAllUser"
        Me.btnAllUser.Size = New System.Drawing.Size(75, 23)
        Me.btnAllUser.TabIndex = 6
        Me.btnAllUser.Text = "AllUser"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(416, 70)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "Search"
        '
        'txtKeyword
        '
        Me.txtKeyword.Location = New System.Drawing.Point(18, 70)
        Me.txtKeyword.Name = "txtKeyword"
        Me.txtKeyword.Size = New System.Drawing.Size(392, 19)
        Me.txtKeyword.TabIndex = 8
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(678, 8)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 9
        Me.Button3.Text = "Department"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 33)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 16)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "LDAP："
        '
        'txtLDAP
        '
        Me.txtLDAP.Location = New System.Drawing.Point(53, 30)
        Me.txtLDAP.Name = "txtLDAP"
        Me.txtLDAP.Size = New System.Drawing.Size(380, 19)
        Me.txtLDAP.TabIndex = 11
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(626, 37)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(127, 23)
        Me.Button4.TabIndex = 12
        Me.Button4.Text = "MossSearchDB"
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(678, 66)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 23)
        Me.Button5.TabIndex = 13
        Me.Button5.Text = "CreateUser"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(324, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 12)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Domain"
        '
        'txtDomain
        '
        Me.txtDomain.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDomain.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.txtDomain.Location = New System.Drawing.Point(367, 4)
        Me.txtDomain.Name = "txtDomain"
        Me.txtDomain.Size = New System.Drawing.Size(66, 21)
        Me.txtDomain.TabIndex = 14
        '
        'btnLogin
        '
        Me.btnLogin.Location = New System.Drawing.Point(439, 3)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(75, 23)
        Me.btnLogin.TabIndex = 16
        Me.btnLogin.Text = "Login"
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(497, 70)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(94, 23)
        Me.Button6.TabIndex = 17
        Me.Button6.Text = "構成検索"
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(520, 33)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(71, 23)
        Me.Button7.TabIndex = 18
        Me.Button7.Text = "構成"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
        Me.ClientSize = New System.Drawing.Size(763, 581)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.btnLogin)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtDomain)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.txtLDAP)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.txtKeyword)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btnAllUser)
        Me.Controls.Add(Me.ADTree)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtpassword)
        Me.Controls.Add(Me.txtUser)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "Active Directory TreeView"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Private AD As AdAccess
    Private username As String
    Private password As String
    Private Domain As String
    Private UserLogin As New UserLogin()
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            ADTree.Nodes.Clear()
            username = txtUser.Text
            password = txtpassword.Text
            Dim ldap As String = Me.txtLDAP.Text
            AD = New AdAccess(username, password, ldap)
            Dim nod As TreeNode = ADTree.Nodes.Add(AD.DefaultDomain)
            nod.Tag = ""

            'Dim users As AdEntrys = AD.GetChilds()
            Dim user As New AdEntry()
            user.Path = ""
            user.UserName = username
            user.Password = password
            'For Each user In users
            AddTree(nod, user)
            nod.Expand()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        'Next
    End Sub
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Try
            ADTree.Nodes.Clear()
            username = txtUser.Text
            password = txtpassword.Text
            Dim ldap As String = Me.txtLDAP.Text
            AD = New AdAccess(username, password, ldap)
            Dim Adroot As AdEntry = AD.rootDSE
            Dim nod As TreeNode = ADTree.Nodes.Add(Adroot.Name)
            nod.Tag = Adroot.Path

            AddTree(nod, Adroot)
            nod.Expand()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim keyword As String = Me.txtKeyword.Text
        username = txtUser.Text
        password = txtpassword.Text
        Dim ldap As String = Me.txtLDAP.Text
        AD = New AdAccess(username, password, ldap)
        Dim dts As DataSet = AD.GetGlobalAddressList(keyword)
        Dim form2 As New Form2()
        form2.showproperty(Me, dts)
    End Sub
    Private Sub AddTree(ByVal ParentNode As TreeNode, ByVal user As AdEntry)
        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Dim users As AdEntrys = AD.GetChilds(user)
        Dim child As AdEntry
        For Each child In users
            'AddTree(nod, child)
            Dim nod As TreeNode = ParentNode.Nodes.Add(child.Name)
            nod.Tag = child.Path
            If child.HaveChild Then
                Dim subnode As TreeNode = nod.Nodes.Add("CHILD")
                subnode.Tag = "HIDE"
            End If
        Next
        Windows.Forms.Cursor.Current = Cursors.Default

    End Sub

    Private Sub ADTree_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ADTree.DoubleClick
        Dim path As String = CStr(ADTree.SelectedNode.Tag)
        Dim user As New AdEntry()
        Dim buf As String() = path.Split("\\".ToCharArray)
        user.Path = buf(0)
        user.UserName = username
        user.Password = password
        user.Name = ADTree.SelectedNode.Text
        Dim prop As System.DirectoryServices.PropertyCollection = AD.GetPropertys(user)
        Dim key As String
        Dim dtset As New DataSet()
        Dim dttab As New DataTable(user.Name)
        Dim row As DataRow
        dttab.Columns.Add("PropertyName", GetType(System.String))
        dttab.Columns.Add("PropertyValue", GetType(System.Object))
        row = dttab.NewRow
        row.Item("PropertyName") = "Path"
        row.Item("PropertyValue") = user.Path
        dttab.Rows.Add(row)
        For Each key In prop.PropertyNames
            Dim value As System.DirectoryServices.PropertyValueCollection = prop(key)
            row = dttab.NewRow
            row.Item("PropertyName") = key
            If value.Count > 1 Then
                Dim subtab As New DataTable(key)
                subtab.Columns.Add("Value", GetType(System.String))
                Dim subval As Object
                For Each subval In value
                    If subval.GetType() Is GetType(System.String) Then
                        Dim subrow As DataRow = subtab.NewRow()
                        subrow.Item(0) = subval
                        subtab.Rows.Add(subrow)
                    End If
                Next
                dtset.Tables.Add(subtab)
            Else
                'If value.Value.GetType Is GetType(System.String) Then
                If key.ToLower = "objectsid" Then
                    Dim sid As New System.Security.Principal.SecurityIdentifier(CType(value.Value, Byte()), 0)
                    row.Item("PropertyValue") = sid.Value
                Else
                    row.Item("PropertyValue") = value.Value
                End If
                'End If
            End If
            dttab.Rows.Add(row)
        Next
        dtset.Tables.Add(dttab)
        Dim form2 As New Form2()
        form2.showproperty(Me, dtset)
    End Sub

    Private Sub ADTree_BeforeExpand(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles ADTree.BeforeExpand
        Dim path As String = CStr(e.Node.Tag)
        Dim user As New AdEntry()
        user.Path = path
        user.UserName = username
        user.Password = password
        user.Name = e.Node.Text
        If CStr(e.Node.Nodes.Item(0).Tag) = "HIDE" Then
            e.Node.Nodes.Item(0).Remove()
            AddTree(e.Node, user)
        End If
    End Sub

    Private Sub btnAllUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAllUser.Click
        username = txtUser.Text
        password = txtpassword.Text
        Dim ldap As String = Me.txtLDAP.Text
        AD = New AdAccess(username, password, ldap)
        Dim dts As DataSet = AD.GetAllUser(username, password, True)
        Dim form2 As New Form2()
        form2.showproperty(Me, dts)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim keyword As String = Me.txtKeyword.Text
        username = txtUser.Text
        password = txtpassword.Text
        Dim ldap As String = Me.txtLDAP.Text
        AD = New AdAccess(username, password, ldap)
        Dim dts As DataSet = AD.Search(keyword, username, password, ldap)
        Dim form2 As New Form2()
        form2.showproperty(Me, dts)

    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        username = txtUser.Text
        password = txtpassword.Text
        Dim ldap As String = Me.txtLDAP.Text
        AD = New AdAccess(username, password, ldap)
        Dim dts As DataSet = AD.GetAllUser(username, password, True)
        Dim WorkGroup As New ArrayList()
        Dim dtw As DataRow = Nothing
        For Each dtw In dts.Tables(0).Select("", "department")
            Dim group As String = CStr(dtw.Item("department"))
            If WorkGroup.Contains(group) = False AndAlso group <> "" Then
                WorkGroup.Add(group)
            End If
        Next
        Dim form2 As New Form2()
        form2.showproperty(Me, CType(WorkGroup.ToArray(GetType(String)), String()))
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim frmMosstest As New Form4
        frmMosstest.ShowDialog(Me)
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        My.Settings.ADUser = Me.txtUser.Text
        My.Settings.ADPsw = Me.txtpassword.Text
        My.Settings.Domain = Me.txtDomain.Text
        My.Settings.LDAP = Me.txtLDAP.Text
        If Me.UserLogin IsNot Nothing Then
            Me.UserLogin.LogOff()
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.txtUser.Text = My.Settings.ADUser
        Me.txtpassword.Text = My.Settings.ADPsw
        Me.txtLDAP.Text = My.Settings.LDAP
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try
            Dim path As String = ""
            If ADTree.SelectedNode IsNot Nothing Then
                path = CStr(ADTree.SelectedNode.Tag)

            End If
            Using frmUser As New FrmCreateUser
                frmUser.RootLDAP = path
                frmUser.ShowDialog()
            End Using
        Catch ex As Exception

        End Try
    End Sub


    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Try
            Me.username = Me.txtUser.Text
            Me.password = Me.txtpassword.Text
            Me.Domain = Me.txtDomain.Text
            UserLogin = New UserLogin
            UserLogin.Login(Me.username, Me.password, Me.Domain)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


   
End Class
