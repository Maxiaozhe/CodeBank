Imports System.Drawing
Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim url As String = Me.TextBox1.Text
        Dim Convertor As New HtmlToImage
        Dim img As Bitmap = Convertor.ConvertToImage(url)
        Me.PictureBox1.Image = img
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim url As String = Me.TextBox1.Text
        Dim Convertor As New HtmlToImage
        Me.SaveFileDialog1.Filter = "イメージファイル(*.bmp,*.Jpg,*.gif)|*.bmp,*.Jpg,*.gif"
        If Me.SaveFileDialog1.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Dim filename As String = Me.SaveFileDialog1.FileName
            Convertor.JpegQuality = Me.TrackBar1.Value
            If Me.PictureBox1.Image Is Nothing Then
                Convertor.ConvertToImage(url, filename)
            Else
                Convertor.SaveImage(CType(Me.PictureBox1.Image, Bitmap), filename)
            End If
        End If
    End Sub

    Private Sub TrackBar1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrackBar1.ValueChanged
        Me.lblQulity.Text = CStr(Me.TrackBar1.Value)
    End Sub

    Private Sub TrackBar2_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrackBar2.ValueChanged
        Me.lblZoom.Text = CStr(Me.TrackBar2.Value)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim url As String = Me.TextBox1.Text
        Dim Convertor As New HtmlToImage
        Dim zoom As Integer = Me.TrackBar2.Value
        Dim bmp As Bitmap = Convertor.GetThumbnailImage(url, zoom)
        Me.PictureBox1.Image = bmp
    End Sub
End Class