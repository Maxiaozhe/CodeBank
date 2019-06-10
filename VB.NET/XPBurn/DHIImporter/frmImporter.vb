Imports DHI.Engine
Public Class frmImporter
    Private mIsExpand As Boolean
    Private mReportPath As String = ""
    Private WithEvents mImporter As CDImporter
    Private Sub frmImporter_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            mImporter = New CDImporter
            InitControls()
        Catch ex As Exception
            MessageBox.ShowError(ex.Message)
        End Try
    End Sub
    Private Sub InitControls()

        'CDドライブ
        Dim Drivers() As System.IO.DriveInfo = System.IO.DriveInfo.GetDrives()
        cmbCdDriver.Items.Clear()
        cmbCdDriver.DisplayMember = "name"
        cmbCdDriver.ValueMember = "RootDirectory"
        For Each drv As System.IO.DriveInfo In Drivers
            If drv.DriveType = IO.DriveType.CDRom Then
                cmbCdDriver.Items.Add(drv)
            End If
        Next
        If cmbCdDriver.Items.Count > 0 Then
            cmbCdDriver.SelectedIndex = 0
        End If
        mIsExpand = False
        ChangeExpand()
    End Sub
    Private Sub ChangeExpand()

        If Me.mIsExpand Then
            '拡大
            Me.Height = 432
            Me.lblLogTitle.Visible = True
            Me.lblLog.Visible = False
            Me.txtLog.Visible = True
            Me.btnDetail.Text = "<< 非表示"
        Else
            '小
            Me.Height = 140
            Me.lblLogTitle.Visible = False
            Me.lblLog.Visible = True
            Me.txtLog.Visible = False
            Me.btnDetail.Text = "詳細 >>"
        End If
    End Sub
    Private Sub OnExporting()
        Me.btnImport.Enabled = False
        Me.btnReport.Enabled = False
        Me.btnDetail.Visible = True
        Me.cmbCdDriver.Enabled = False
    End Sub
    Private Sub OnNotExport()
        Me.btnImport.Enabled = True
        Me.btnReport.Enabled = True
        Me.cmbCdDriver.Enabled = True
    End Sub

    Private Sub btnDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetail.Click
        Try
            mIsExpand = True
            ChangeExpand()
        Catch ex As Exception
            MessageBox.ShowError(ex.Message)
        End Try
    End Sub

    Private Sub btnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Try
            Dim ProcInfo As New ProcessStartInfo
            ProcInfo.FileName = "Notepad"
            ProcInfo.Arguments = mReportPath
            System.Diagnostics.Process.Start(ProcInfo)
        Catch ex As Exception
            MessageBox.ShowError(ex.Message)
        End Try
      
    End Sub

    Private Sub mImporter_ProcessMessage(ByVal sender As Object, ByVal e As Engine.ProcessEventsArgs) Handles mImporter.ProcessMessage
        If e.ProcessParcent > 0 Then
            If Me.ProgressBar1.Visible = False Then
                Me.ProgressBar1.Visible = True
                Me.ProgressBar1.Maximum = 100
                Me.ProgressBar1.Minimum = 0
            End If
            If e.ProcessParcent <= 100 Then
                Me.ProgressBar1.Value = e.ProcessParcent
            Else
                Me.ProgressBar1.Value = 100
            End If
        End If
        Me.lblLog.Text = e.Message
        Me.txtLog.AppendText(e.Message)
        Me.txtLog.AppendText(vbCrLf)
        If e.IsWriteLog Then
            logger.Writer(e.Message)
        End If
        If e.ProcessType = ProcessEventsArgs.ProcessTypes.CDReadComplete Then
            Me.ProgressBar1.Visible = False
            mReportPath = logger.flush()
        End If
        Application.DoEvents()
    End Sub

    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        Try
            If Me.cmbCdDriver.Items.Count = 0 Then
                MessageBox.ShowError(Messages.NotCDROM)
                Return
            End If
            Dim drv As System.IO.DriveInfo = CType(Me.cmbCdDriver.SelectedItem, System.IO.DriveInfo)
            Dim root As String = drv.RootDirectory.Name
            Dim importFilename As String = System.IO.Path.GetFileName(Env.OutPutFilePath)
            importFilename = System.IO.Path.Combine(root, importFilename)
            If System.IO.File.Exists(importFilename) = False Then
                MessageBox.ShowError(String.Format(Messages.NotFindFile, importFilename))
                Return
            End If
            Me.mImporter.ImportFile(importFilename)
        Catch ex As Exception
            MessageBox.ShowError(ex.Message)
        End Try
       
    End Sub
End Class
