Public Class XlstTest

    Private Sub btnTransfer_Click(sender As System.Object, e As System.EventArgs) Handles btnTransfer.Click
        If String.IsNullOrEmpty(Me.txtDxl.Text) Then
            Return
        End If
    End Sub

    Private Sub btnDXL_Click(sender As System.Object, e As System.EventArgs) Handles btnDXL.Click
        Me.OpenFileDialog1.Filter = "DXLファイル|*.dxl;XMLファイル|*.xml"
        If Me.OpenFileDialog1.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Me.txtDxl.Text = Me.OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub btnXSL_Click(sender As System.Object, e As System.EventArgs) Handles btnXSL.Click
        Me.OpenFileDialog1.Filter = "XSLTファイル|*.XSLT;XMLファイル|*.xml"
        If Me.OpenFileDialog1.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Me.txtXSLT.Text = Me.OpenFileDialog1.FileName
        End If

    End Sub
End Class