Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim conn As New SqlClient.SqlConnection
        Try
            conn.ConnectionString = "Data Source=(local)\SQLEXPRESS1;Initial Catalog=master;Integrated Security=SSPI;Persist Security Info=False"
            conn.Open()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub
End Class
