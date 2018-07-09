Public Class dialog1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub image_ServerClick(sender As Object, e As ImageClickEventArgs) Handles image.ServerClick
        For i As Integer = 0 To 100
            System.Threading.Thread.Sleep(10)
        Next
    End Sub
End Class