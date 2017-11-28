Imports RTS.Common.ActiveDirctroy
Imports System.Collections.Generic
Public Class Form4

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim AD As New AdAccess("", "", "")
        Dim dts As DataSet = AD.GetAllUser("", "", True)
        Dim Owner As String = ""
        Dim Users As New List(Of String)
        Dim index As Integer = 0
        Dim maxusers As Integer = CInt(Me.TextBox1.Text)
        For Each row As DataRow In dts.Tables(0).Rows
            Dim Sid As String = CStr(row.Item("objectsid"))
            Users.Add(Sid)
            If index = 0 Then
                Owner = Sid
            End If
            index += 1
            If index >= maxusers Then
                Exit For
            End If
        Next
        Dim SecCtrl As New AceApi.PHSecurityDescriptor
        SecCtrl.LoadSecurity(Owner, Users.ToArray(), True)
        Dim buffersize As Integer = SecCtrl.GetBuffer().Length
        Me.TextBox2.Text = CStr(buffersize)
        SecCtrl.Dispose()
        SecCtrl = Nothing
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim ConnFormat As String = "User ID={0};Password={1};Initial Catalog={2};Data Source={3};Connect Timeout=30"
        Dim ConnFormatWin As String = "Data Source={0};Initial Catalog={1};Integrated Security=True"
        Dim Server As String = txtServer.Text
        Dim user As String = Me.txtUser.Text
        Dim psw As String = Me.txtPsw.Text
        Dim db As String = Me.txtDB.Text
        Dim strConn As String = ""
        If Me.chkWindows.Checked = False Then
            strConn = String.Format(ConnFormat, user, psw, db, Server)
        Else
            strConn = String.Format(ConnFormatWin, Server, db)
        End If
        Dim dbconn As New SqlClient.SqlConnection(strConn)
        Dim sqlcmd As SqlClient.SqlCommand = Nothing
        Dim reader As SqlClient.SqlDataReader = Nothing
        Dim SerAce As Microsoft.Win32.Security.SecurityDescriptor = Nothing
        Try
            dbconn.Open()
            sqlcmd = dbconn.CreateCommand()
            sqlcmd.CommandText = "Select sd from MSSSecurityDescriptors Where SDID=" & Me.txtSdid.Text
            reader = sqlcmd.ExecuteReader()
            Dim buffer() As Byte
            If reader.Read() Then
                buffer = CType(reader.GetValue(0), Byte())
            Else
                Return
            End If
            Dim dts As DataSet = Nothing
            Try
                SerAce = AceApi.PHSecurityDescriptor.GetSecurityDescriptor(buffer)
                 dts = GetAclData(SerAce)
            Finally
                If SerAce IsNot Nothing Then
                    SerAce.Dispose()
                    SerAce = Nothing
                End If
            End Try
            If dts Is Nothing OrElse dts.Tables.Count = 0 Then
                Return
            End If
            Dim frm As New Form2
            frm.showproperty(Me, dts)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If reader IsNot Nothing Then
                reader.Close()
                reader = Nothing
            End If
            If dbconn IsNot Nothing Then
                dbconn.Close()
                dbconn.Dispose()
                dbconn = Nothing
            End If
        End Try
    End Sub
    Private Function GetAclData(ByVal SerAce As Microsoft.Win32.Security.SecurityDescriptor) As DataSet

        Dim dts As DataSet = Me.CreateDataset()
        Dim dtt As DataTable = dts.Tables(0)
        Dim ace As Microsoft.Win32.Security.Ace = Nothing
        Dim Dacl As Microsoft.Win32.Security.Dacl = SerAce.Dacl
        For index As Integer = 0 To Dacl.AceCount - 1
            ace = Dacl.GetAce(index)
            Dim row As DataRow = dtt.NewRow()
            row.Item(0) = ace.Sid.CanonicalName
            row.Item(1) = ace.Sid.SidString
            row.Item(2) = ace.Sid.DomainName
            row.Item(3) = ace.Sid.IsValid
            row.Item(4) = ace.AccessType 'Me.GetAccessAclType(ace)
            row.Item(5) = ace.Flags
            row.Item(6) = ace.Type
            dtt.Rows.Add(row)
            ace = Nothing
        Next
        Dacl = Nothing
        dtt.AcceptChanges()
        Return dts

    End Function
    Private Function CreateDataset() As DataSet
        Dim dts As New DataSet
        Dim dtt As New DataTable("MSSSecurityDescriptors")
        dtt.Columns.Add("UserID", GetType(String))
        dtt.Columns.Add("SID", GetType(String))
        dtt.Columns.Add("DomainName", GetType(String))
        dtt.Columns.Add("IsValid", GetType(Boolean))
        dtt.Columns.Add("AccessType", GetType(String))
        dtt.Columns.Add("Flags", GetType(String))
        dtt.Columns.Add("Type", GetType(String))
        dts.Tables.Add(dtt)
        Return dts
    End Function
    Private Function GetAccessAclType(ByVal ace As Microsoft.Win32.Security.Ace) As String
        Dim AclType As String = ""
        If (ace.AccessType And Microsoft.Win32.Security.AccessType.DELETE) = Microsoft.Win32.Security.AccessType.DELETE Then
            AclType = "DELETE"
        End If
        If (ace.AccessType And Microsoft.Win32.Security.AccessType.ACCESS_SYSTEM_SECURITY) = Microsoft.Win32.Security.AccessType.ACCESS_SYSTEM_SECURITY Then
            If AclType <> "" Then
                AclType &= "|"
            End If
            AclType &= "ACCESS_SYSTEM_SECURITY"
        End If
        If (ace.AccessType And Microsoft.Win32.Security.AccessType.GENERIC_ALL) = Microsoft.Win32.Security.AccessType.GENERIC_ALL Then
            If AclType <> "" Then
                AclType &= "|"
            End If
            AclType &= "GENERIC_ALL"
        End If
        If (ace.AccessType And Microsoft.Win32.Security.AccessType.GENERIC_EXECUTE) = Microsoft.Win32.Security.AccessType.GENERIC_EXECUTE Then
            If AclType <> "" Then
                AclType &= "|"
            End If
            AclType &= "GENERIC_EXECUTE"
        End If
        If (ace.AccessType And Microsoft.Win32.Security.AccessType.GENERIC_READ) = Microsoft.Win32.Security.AccessType.GENERIC_READ Then
            If AclType <> "" Then
                AclType &= "|"
            End If
            AclType &= "GENERIC_READ"
        End If
        If (ace.AccessType And Microsoft.Win32.Security.AccessType.GENERIC_WRITE) = Microsoft.Win32.Security.AccessType.GENERIC_WRITE Then
            If AclType <> "" Then
                AclType &= "|"
            End If
            AclType &= "GENERIC_WRITE"
        End If
        If (ace.AccessType And Microsoft.Win32.Security.AccessType.MAXIMUM_ALLOWED) = Microsoft.Win32.Security.AccessType.MAXIMUM_ALLOWED Then
            If AclType <> "" Then
                AclType &= "|"
            End If
            AclType &= "MAXIMUM_ALLOWED"
        End If
        If (ace.AccessType And Microsoft.Win32.Security.AccessType.READ_CONTROL) = Microsoft.Win32.Security.AccessType.READ_CONTROL Then
            If AclType <> "" Then
                AclType &= "|"
            End If
            AclType &= "READ_CONTROL"
        End If
        If (ace.AccessType And Microsoft.Win32.Security.AccessType.SPECIFIC_RIGHTS_ALL) = Microsoft.Win32.Security.AccessType.SPECIFIC_RIGHTS_ALL Then
            If AclType <> "" Then
                AclType &= "|"
            End If
            AclType &= "SPECIFIC_RIGHTS_ALL"
        End If
        If (ace.AccessType And Microsoft.Win32.Security.AccessType.STANDARD_RIGHTS_ALL) = Microsoft.Win32.Security.AccessType.STANDARD_RIGHTS_ALL Then
            If AclType <> "" Then
                AclType &= "|"
            End If
            AclType &= "STANDARD_RIGHTS_ALL"
        End If
        If (ace.AccessType And Microsoft.Win32.Security.AccessType.STANDARD_RIGHTS_EXECUTE) = Microsoft.Win32.Security.AccessType.STANDARD_RIGHTS_EXECUTE Then
            If AclType <> "" Then
                AclType &= "|"
            End If
            AclType &= "STANDARD_RIGHTS_EXECUTE"
        End If
        If (ace.AccessType And Microsoft.Win32.Security.AccessType.STANDARD_RIGHTS_READ) = Microsoft.Win32.Security.AccessType.STANDARD_RIGHTS_READ Then
            If AclType <> "" Then
                AclType &= "|"
            End If
            AclType &= "STANDARD_RIGHTS_READ"
        End If
        If (ace.AccessType And Microsoft.Win32.Security.AccessType.STANDARD_RIGHTS_REQUIRED) = Microsoft.Win32.Security.AccessType.STANDARD_RIGHTS_REQUIRED Then
            If AclType <> "" Then
                AclType &= "|"
            End If
            AclType &= "STANDARD_RIGHTS_REQUIRED"
        End If
        If (ace.AccessType And Microsoft.Win32.Security.AccessType.STANDARD_RIGHTS_WRITE) = Microsoft.Win32.Security.AccessType.STANDARD_RIGHTS_WRITE Then
            If AclType <> "" Then
                AclType &= "|"
            End If
            AclType &= "STANDARD_RIGHTS_WRITE"
        End If
        If (ace.AccessType And Microsoft.Win32.Security.AccessType.SYNCHRONIZE) = Microsoft.Win32.Security.AccessType.SYNCHRONIZE Then
            If AclType <> "" Then
                AclType &= "|"
            End If
            AclType &= "SYNCHRONIZE"
        End If
        If (ace.AccessType And Microsoft.Win32.Security.AccessType.WRITE_DAC) = Microsoft.Win32.Security.AccessType.WRITE_DAC Then
            If AclType <> "" Then
                AclType &= "|"
            End If
            AclType &= "WRITE_DAC"
        End If
        If (ace.AccessType And Microsoft.Win32.Security.AccessType.WRITE_OWNER) = Microsoft.Win32.Security.AccessType.WRITE_OWNER Then
            If AclType <> "" Then
                AclType &= "|"
            End If
            AclType &= "WRITE_OWNER"
        End If
        If (ace.AccessType And Microsoft.Win32.Security.FileAccessType.FILE_READ_DATA) = Microsoft.Win32.Security.FileAccessType.FILE_READ_DATA Then
            If AclType <> "" Then
                AclType &= "|"
            End If
            AclType &= "FILE_READ_DATA"
        End If
        If (ace.AccessType And Microsoft.Win32.Security.FileAccessType.FILE_READ_ATTRIBUTES) = Microsoft.Win32.Security.FileAccessType.FILE_READ_ATTRIBUTES Then
            If AclType <> "" Then
                AclType &= "|"
            End If
            AclType &= "FILE_READ_ATTRIBUTES"
        End If
        Return AclType
    End Function

    Private Sub chkWindows_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkWindows.CheckStateChanged
        Me.txtUser.Enabled = Not Me.chkWindows.Checked
        Me.txtPsw.Enabled = Not Me.chkWindows.Checked
    End Sub

  
    Private Sub Form4_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        My.Settings.DB = Me.txtDB.Text
        My.Settings.DBServer = Me.txtServer.Text
        My.Settings.DBUser = Me.txtUser.Text
        My.Settings.DBPsw = Me.txtPsw.Text
        My.Settings.WindowsAuthen = Me.chkWindows.Checked
    End Sub

    Private Sub Form4_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.txtDB.Text = My.Settings.DB
        Me.txtServer.Text = My.Settings.DBServer
        Me.txtUser.Text = My.Settings.DBUser
        Me.txtPsw.Text = My.Settings.DBPsw
        Me.chkWindows.Checked = My.Settings.WindowsAuthen
    End Sub
End Class