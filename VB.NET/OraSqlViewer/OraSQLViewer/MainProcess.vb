Public Class MainProcess
    Public Shared Sub main()
        Dim frmLogin As New frmLogin()
        If frmLogin.ShowDialog() = DialogResult.OK Then
            Dim frmMain As New frmMain()
            frmMain.ShowDialog()
        End If
    End Sub
End Class
