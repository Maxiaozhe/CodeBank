Imports RTS.Common.ActiveDirctroy
Public Class FrmCreateUser
    Private mRootLDAP As String
    Public Property RootLDAP() As String
        Get
            Return Me.mRootLDAP
        End Get
        Set(ByVal value As String)
            Me.mRootLDAP = value
        End Set
    End Property
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim AD As New AdAccess(My.Settings.ADUser, My.Settings.ADPsw, "")
            Dim ldap As String = Me.txtLDAP.Text
            Dim name As String = Me.txtName.Text
            Dim displayname As String = Me.txtDisplayName.Text
            Dim email As String = Me.txtEmail.Text
            Dim notesid As String = Me.txtNotesID.Text
            AD.CreateContact(ldap, name, displayname, email, notesid)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub FrmCreateUser_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.txtLDAP.Text = Me.mRootLDAP
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Dim AD As New AdAccess(My.Settings.ADUser, My.Settings.ADPsw, "")
            Dim ldap As String = Me.txtLDAP.Text
            Dim name As String = Me.txtName.Text
            Dim displayname As String = Me.txtDisplayName.Text
            Dim email As String = Me.txtEmail.Text
            Dim notesid As String = Me.txtNotesID.Text
            AD.CreateUser(ldap, name, displayname, email, notesid)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class