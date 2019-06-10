Imports DHI.Engine
Public Class frmExporter
#Region "内部変数"
    Private mXmlFilePath As String = ""
    Private WithEvents mCDWriter As CDExporter
    Private mIsExpand As Boolean = False
    Private mReportPath As String = ""
#End Region
#Region "エベント"
    Private Sub frmExporter_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        mIsExpand = False
        Me.ProgressBar1.Visible = False
        Me.OpenFileDialog1.Filter = "XMLファイル(.XML)|すべてファイル(*.*)"
        Me.OpenFileDialog1.FileName = Env.XmlFilePath
        Me.txtFile.Text = Env.XmlFilePath
        OnNotExport()
        InitControls()
    End Sub
    Private Sub InitControls()

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
        Me.btnOutput.Enabled = False
        Me.btnSelectFile.Enabled = False
        Me.btnDetail.Visible = True

        Me.txtFile.ReadOnly = True
        Me.lblLog.Visible = True
    End Sub
    Private Sub OnNotExport()
        Me.btnOutput.Enabled = True
        Me.btnSelectFile.Enabled = True
        Me.txtFile.ReadOnly = False
        Me.lblLog.Visible = False
    End Sub

    Private Sub btnSelectFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectFile.Click
        If Me.OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Me.OpenFileDialog1.FileName <> "" Then
                mXmlFilePath = Me.OpenFileDialog1.FileName
                Me.txtFile.Text = mXmlFilePath
            End If
        End If
    End Sub
    Private Sub btnOutput_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOutput.Click
        Try
            Me.OnExporting()
            mXmlFilePath = Me.txtFile.Text
            If System.IO.File.Exists(Me.mXmlFilePath) = False Then
                MessageBox.ShowWarrning(Messages.NotSelectedFile)
            End If
            Try
                mCDWriter = New CDExporter
                If mCDWriter.CheckXmlFile(mXmlFilePath) = False Then
                    If MessageBox.ShowQuestion(Messages.IsContinue) = Windows.Forms.DialogResult.No Then
                        Return
                    End If
                End If
                mCDWriter.SaveFile(mXmlFilePath)
            Catch ex As Exception
                MessageBox.ShowError(ex.Message)
            End Try
            If mCDWriter.IsReady Then
                mCDWriter.CheckDriver()
                mCDWriter.SaveFile(mXmlFilePath)
            End If
        Catch ex As Exception
            MessageBox.ShowError(ex.Message)
        Finally
            Me.OnNotExport()
        End Try

    End Sub
    Private Sub btnDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetail.Click
        mIsExpand = Not mIsExpand
        InitControls()
    End Sub
    Private Sub mCDWriter_ProcessMessage(ByVal sender As Object, ByVal e As ProcessEventsArgs) Handles mCDWriter.ProcessMessage
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
        If e.ProcessType = ProcessEventsArgs.ProcessTypes.BurnComplete Then
            Me.ProgressBar1.Visible = False
            mReportPath = logger.flush()
        End If
        Application.DoEvents()
    End Sub
    ''' <summary>
    ''' レポート表示
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Dim ProcInfo As New ProcessStartInfo
        ProcInfo.FileName = "Notepad"
        ProcInfo.Arguments = mReportPath
        System.Diagnostics.Process.Start(ProcInfo)
    End Sub
#End Region


End Class
