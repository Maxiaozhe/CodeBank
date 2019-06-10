Imports XPBurn
Public Class Form1
    Private WithEvents xpBurn As XPBurn.XPBurnCD
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try

            xpBurn.RecordDisc(False, False)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            xpBurn.Erase(EraseKind.ekFull)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
          
            xpBurn = New XPBurn.XPBurnCD
            Dim sb As New System.Text.StringBuilder
            sb.AppendLine("BurnerDrive=" & xpBurn.BurnerDrive)
            sb.AppendLine("DiscSpace=" & xpBurn.DiscSpace)
            sb.AppendLine("FreeDiscSpace=" & xpBurn.FreeDiscSpace)
            sb.AppendLine("MaxWriteSpeed=" & xpBurn.MaxWriteSpeed)
            sb.AppendLine("NumberOfDrives=" & xpBurn.NumberOfDrives)
            sb.AppendLine("RecorderType=" & xpBurn.RecorderType.ToString)
            sb.AppendLine("MediaInfo:")
            sb.AppendLine("          isBlank=" & xpBurn.MediaInfo.isBlank)
            sb.AppendLine("          isReadWrite=" & xpBurn.MediaInfo.isReadWrite)
            sb.AppendLine("          isUsable=" & xpBurn.MediaInfo.isUsable)
            sb.AppendLine("          isWritable=" & xpBurn.MediaInfo.isWritable)
            sb.AppendLine("ProductID=" & xpBurn.ProductID)
            sb.AppendLine("RecorderDrives:")
            For Each Drv As String In xpBurn.RecorderDrives
                sb.AppendLine("          " & Drv)
            Next
            sb.AppendLine("Vendor:" & xpBurn.Vendor)
            sb.AppendLine("VolumeName:" & xpBurn.VolumeName)
            sb.AppendLine("WriteSpeed:" & xpBurn.WriteSpeed)
            sb.AppendLine("Revision:" & xpBurn.Revision)
            Me.TextBox1.Text = sb.ToString

        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub xpBurn_BlockProgress(ByVal nCompletedSteps As Integer, ByVal nTotalSteps As Integer) Handles xpBurn.BlockProgress
        Me.ProgressBar1.Maximum = nTotalSteps
        Me.ProgressBar1.Minimum = 0
        If nCompletedSteps < nTotalSteps Then
            Me.ProgressBar1.Value = nCompletedSteps
        Else
            Me.ProgressBar1.Value = nTotalSteps
        End If

    End Sub

    Private Sub xpBurn_BurnComplete(ByVal status As UInteger) Handles xpBurn.BurnComplete
        MessageBox.Show("CD‚Ì‘‚«ž‚Ý‚ªŠ®—¹‚µ‚Ü‚µ‚½B")
        xpBurn.ClearFiles()
        Me.ProgressBar1.Visible = False
    End Sub

    Private Sub xpBurn_ClosingDisc(ByVal nEstimatedSeconds As Integer) Handles xpBurn.ClosingDisc

    End Sub

    Private Sub xpBurn_PreparingBurn(ByVal nEstimatedSeconds As Integer) Handles xpBurn.PreparingBurn

    End Sub


    Private Sub TreeView1_FileAdded(ByVal Sender As System.Object, ByVal e As CDBurner.FileView.FileAddedEvetnArgs) Handles TreeView1.FileAdded
        xpBurn.AddFile(e.FilePath, e.NameOnCD)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        xpBurn.Eject()
    End Sub

    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            Me.Hide()
            Me.NotifyIcon1.Icon = My.Resources.Icon
            Me.NotifyIcon1.Text = "CD Easy Burn!"
            Me.NotifyIcon1.Visible = True
        End If
    End Sub

   
    Private Sub NotifyIcon1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles NotifyIcon1.DoubleClick
        Me.Show()
        Me.WindowState = FormWindowState.Normal
    End Sub
End Class
