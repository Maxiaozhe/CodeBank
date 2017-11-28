Imports Microsoft.VisualBasic.Devices
Imports Microsoft.VisualBasic.FileIO
Public Class frmWinzip
    Private WinRarPath As String = "D:\Program Files\WinRAR\Rar.exe"
    Private mFileCount As Integer = 0
    Private mZipedCount As Integer = 0
    Private mZipTotalCount As Integer
    Private Delegate Sub SetTextCallback(ByVal [text] As String)
    Private Delegate Sub SetProgressCallback(ByVal Progress As Integer)
    Private Sub frmWinzip_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.ProgressBar1.Visible = False
        Me.chkTop.Checked = My.Settings.TopMost
        InitSetting()
    End Sub

    Private Sub InitSetting()
        If My.Settings.OutputFold = "" Then
            My.Settings.OutputFold = My.Computer.FileSystem.SpecialDirectories.Desktop
        End If
        Dim nameSeting As NamingSetting = NamingSetting.StringToObject(My.Settings.NamingSetting)
        If nameSeting.Ext = "" Then
            nameSeting.Ext = "zip"
        End If
        My.Settings.NamingSetting = nameSeting.ObjectToString()
        InitTempList()
    End Sub
    ''' <summary>
    ''' 圧縮
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnWinZip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWinZip.Click
        Try
            Me.ProgressBar1.Visible = True
            Me.BackgroundWorker1.RunWorkerAsync(0)
            Me.ProgressBar1.Value = 0
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    ''' <summary>
    ''' 発行
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnRelease_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRelease.Click
        Try
            Dim CurrentOption As New OptionData
            If String.IsNullOrEmpty(CurrentOption.ReleaseFolder) = True Then
                MessageBox.Show("発行設定の出力フォルダを指定してください。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            If String.IsNullOrEmpty(CurrentOption.ReleaseNameSeting.GetFolderName) = True Then
                MessageBox.Show("発行設定の出力フォルダ名を指定してください。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Me.ProgressBar1.Visible = True
            Me.BackgroundWorker1.RunWorkerAsync(1)
            Me.ProgressBar1.Value = 0

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub AddAllFiles(ByVal BasePath As String, ByVal ParentNode As TreeNode, ByVal totalNumber As Integer)
        If ParentNode.Tag IsNot Nothing AndAlso TypeOf ParentNode.Tag Is String Then
            Dim path As String = CStr(ParentNode.Tag)
            If path = "" Then
                Dim Fold As String = My.Computer.FileSystem.CombinePath(BasePath, ParentNode.FullPath)
                If My.Computer.FileSystem.DirectoryExists(Fold) = False Then
                    My.Computer.FileSystem.CreateDirectory(Fold)
                End If
            ElseIf FileSystem.FileExists(path) Then
                Dim disPath As String = My.Computer.FileSystem.CombinePath(BasePath, ParentNode.FullPath)
                My.Computer.FileSystem.CopyFile(path, disPath, False)
                Dim finfo As New System.IO.FileInfo(disPath)
                If (finfo.Attributes And IO.FileAttributes.ReadOnly) = IO.FileAttributes.ReadOnly Then
                    finfo.Attributes = IO.FileAttributes.Normal
                End If
                Me.mFileCount += 1
                Dim progress As Integer = CInt(CDec(Me.mFileCount * 100) / CDec(totalNumber))
                Me.BackgroundWorker1.ReportProgress(progress, path)
            End If
        End If
        If ParentNode.Nodes.Count > 0 Then
            For Each subNode As TreeNode In ParentNode.Nodes
                AddAllFiles(BasePath, subNode, totalNumber)
            Next
        End If
    End Sub


    Private Function CreateZipFile(ByVal BasePath As String, ByVal archiveFile As String, ByVal ZipTotalCount As Integer) As String
        Dim sbCmd As System.Text.StringBuilder = Nothing
        Dim Count As Integer = 0
        Dim index As Integer = 0
        sbCmd = New System.Text.StringBuilder
        sbCmd.Append("a -ed -ep1 -r")
        If My.Settings.Password <> "" Then
            sbCmd.Append(" -p" & My.Settings.Password)
        End If
        sbCmd.Append(" """ & archiveFile & """")
        sbCmd.Append(" """ & BasePath & """")
        Dim rarPro As New Process()
        Dim ProcessInfo As ProcessStartInfo = rarPro.StartInfo
        ProcessInfo.FileName = My.Settings.WinrarPath
        ProcessInfo.Arguments = sbCmd.ToString
        ProcessInfo.WindowStyle = ProcessWindowStyle.Hidden
        ProcessInfo.RedirectStandardOutput = True
        ProcessInfo.UseShellExecute = False
        ProcessInfo.CreateNoWindow = True
        'Dim rarPro As Process = Process.Start(ProcessInfo)
        AddHandler rarPro.OutputDataReceived, AddressOf OnOutputDataReceived
        Me.mZipTotalCount = ZipTotalCount
        rarPro.Start()
        rarPro.BeginOutputReadLine()
        'rarPro.WaitForExit()
        'Dim progress As Integer = 50
        While rarPro.WaitForExit(100) = False

            '    If progress < 99 Then
            '        Me.BackgroundWorker1.ReportProgress(progress + 1, "リリースファイルを圧縮中....")
            '        progress += 1
            '    End If
        End While
        rarPro.Close()
        Return archiveFile
    End Function

    Private Sub OnOutputDataReceived(ByVal Sender As Object, ByVal e As System.Diagnostics.DataReceivedEventArgs)
        Try
            Me.mZipedCount += 1
            Dim Progress As Integer = CInt(CDec(mZipedCount) * 49 / CDec(Me.mZipTotalCount)) + 50
            If Progress > 99 Then
                Progress = 99
            End If
            Dim msg As String = ""
            If Not String.IsNullOrEmpty(e.Data) Then
                msg = System.Text.RegularExpressions.Regex.Replace(e.Data, "|[0-9]+\%|^Adding\s*|\s*OK\s*$", "").Trim()
                If System.IO.File.Exists(msg) Then
                    msg = System.IO.Path.GetFileName(msg)
                End If
                Me.BackgroundWorker1.ReportProgress(Progress, msg)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub SetTextSafe(ByVal [text] As String)

        If Me.StatusStrip1.InvokeRequired Then
            Dim d As New SetTextCallback(AddressOf SetTextSafe)
            Me.StatusStrip1.Invoke(d, New Object() {[text]})
        Else
            Me.LblProgressMsg.Text = [text]
        End If
    End Sub
    Private Sub SetProgressSafe(ByVal progress As Integer)

        If Me.StatusStrip1.InvokeRequired Then
            Dim d As New SetProgressCallback(AddressOf SetProgressSafe)
            Me.StatusStrip1.Invoke(d, New Object() {progress})
        Else
            Me.ProgressBar1.Value = progress
        End If
    End Sub
    Private Sub DoReleaseWork()
        Try
            Dim totalCount As Integer = Me.FileView.GetFileCount
            If totalCount = 0 Then
                Return
            End If
            Me.BackgroundWorker1.ReportProgress(0, "ファイル発行を準備中....")
            Dim CurrentOption As New OptionData

            Dim NewFolder As String = My.Computer.FileSystem.CombinePath(CurrentOption.ReleaseFolder, CurrentOption.ReleaseNameSeting.GetFolderName())
            If System.IO.Directory.Exists(NewFolder) = False Then
                My.Computer.FileSystem.CreateDirectory(NewFolder)
            End If
                '一時フォルダを作成する
            Dim Basepath As String = NewFolder
            mFileCount = 0
            Me.BackgroundWorker1.ReportProgress(10, "ファイル発行しています...")
            For Each node As TreeNode In Me.FileView.Nodes
                AddAllFiles(Basepath, node, totalCount)
            Next
            Me.BackgroundWorker1.ReportProgress(100, "ファイルの発行は完了しました。")
            Process.Start(My.Computer.FileSystem.GetParentPath(Basepath))
        Catch ex As Exception
            MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub DoZipwork()
        Try
            Dim totalCount As Integer = Me.FileView.GetFileCount
            If totalCount = 0 Then
                Return
            End If
            Me.BackgroundWorker1.ReportProgress(0, "ファイル圧縮を準備中....")
            Dim nameSetting As NamingSetting = NamingSetting.StringToObject(My.Settings.NamingSetting)
            Dim NewFolder As String = My.Computer.FileSystem.CombinePath(My.Settings.OutputFold, DateTime.Today.ToString("yyyyMMdd"))
            If System.IO.Directory.Exists(NewFolder) = False Then
                My.Computer.FileSystem.CreateDirectory(NewFolder)
            End If
            'アーカイブファイル名
            Dim archiveFileName As String = nameSetting.Getname
            Dim archiveFile As String = My.Computer.FileSystem.CombinePath(NewFolder, archiveFileName)
            '一時フォルダを作成する
            Dim Basepath As String = My.Computer.FileSystem.SpecialDirectories.Temp
            Basepath = My.Computer.FileSystem.CombinePath(Basepath, System.IO.Path.GetFileNameWithoutExtension(archiveFileName))
            mFileCount = 0

            For Each node As TreeNode In Me.FileView.Nodes
                AddAllFiles(Basepath, node, totalCount * 2)
            Next
            Me.BackgroundWorker1.ReportProgress(50, "ファイル圧縮を始めます。")
            CreateZipFile(Basepath, archiveFile, totalCount)
            Process.Start(My.Computer.FileSystem.GetParentPath(archiveFile))
            Dim IsDeleted As Boolean = False
            Dim RetryCount As Integer = 0
            While IsDeleted = False AndAlso RetryCount <= 10
                Try
                    My.Computer.FileSystem.DeleteDirectory(Basepath, DeleteDirectoryOption.DeleteAllContents)
                    IsDeleted = True
                Catch ex As Exception
                    RetryCount += 1
                    Me.BackgroundWorker1.ReportProgress(99, "一時ファイルを削除中....")
                    Threading.Thread.Sleep(1000)
                End Try
            End While
            Me.BackgroundWorker1.ReportProgress(100, "リリースファイルを作成しました。")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub btnNewFloder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewFloder.Click
        Dim ParentNode As TreeNode = Nothing
        If Me.FileView.SelectedNode IsNot Nothing Then
            ParentNode = Me.FileView.SelectedNode
            If CStr(ParentNode.Tag) <> "" Then
                If Me.FileView.SelectedNode.Parent Is Nothing Then
                    ParentNode = Nothing
                Else
                    ParentNode = Me.FileView.SelectedNode.Parent
                End If
            End If
        End If
        FileView.newFolder(ParentNode, "新規フォルダ")
    End Sub
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If Me.FileView.SelectedNode IsNot Nothing Then
            Me.FileView.SelectedNode.Remove()
        End If
    End Sub
    Private Sub btnOption_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOption.Click
        Dim frmOpt As New frmOptions
        Dim Options As New OptionData
        frmOpt.Options = Options
        If frmOpt.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            frmOpt.Options.SaveToMySetting()
        End If
    End Sub
    Private Sub frmWinzip_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            Me.Hide()
            Me.NotifyIcon1.Visible = True
        Else
            Me.NotifyIcon1.Visible = False
        End If
    End Sub

    Private Sub NotifyIcon1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles NotifyIcon1.DoubleClick
        Me.Show()
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub FileView_FileAddCompleted(ByVal Sender As Object, ByVal e As System.EventArgs) Handles FileView.FileAddCompleted
        Me.LblProgressMsg.Text = ""
        Application.DoEvents()
    End Sub

    Private Sub FileView_FileAdded(ByVal Sender As Object, ByVal e As FileView.FileAddedEvetnArgs) Handles FileView.FileAdded
        Me.LblProgressMsg.Text = e.FilePath
        Application.DoEvents()
    End Sub

    Private Sub btnSaveTemp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveTemp.Click
        Try
            Dim tempItem As TemplateItem = Me.FileView.GetTemplate()
            Dim frmSave As New frmSaveTemplate
            frmSave.TemplateData = tempItem
            If frmSave.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                InitTempList()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub
    Private Sub InitTempList()
        Dim Temps As TemplateCollection = Nothing
        Dim strSeriTemp As String = My.Settings.Templates
        If My.Settings.Templates = "" Then
            Temps = New TemplateCollection
        Else
            Temps = CType(Utility.StringToObject(strSeriTemp), TemplateCollection)
        End If
        lstTemplate.DropDownItems.Clear()
        For Each Temp As TemplateItem In Temps
            Dim DropItem As New ToolStripMenuItem(Temp.Name)
            DropItem.Image = My.Resources.Folder
            DropItem.ImageTransparentColor = Color.White
            DropItem.Tag = Temp
            lstTemplate.DropDownItems.Add(DropItem)
        Next
        Me.lstTemplate.DropDownItems.Add("-")
        Me.lstTemplate.DropDownItems.Add("エクスポート...", My.Resources.Export, AddressOf Template_ExportClicked)
        Me.lstTemplate.DropDownItems.Add("インポート...", My.Resources.Import, AddressOf Template_ImportClicked)
        Me.lstTemplate.DropDownItems.Add("-")
        Me.lstTemplate.DropDownItems.Add("編集...")
    End Sub
    Private Sub lstTemplate_DropDownItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles lstTemplate.DropDownItemClicked
        Dim DropItem As ToolStripItem = e.ClickedItem
        If DropItem.Tag IsNot Nothing AndAlso TypeOf DropItem.Tag Is TemplateItem Then
            Dim TempItem As TemplateItem = CType(DropItem.Tag, TemplateItem)
            Me.FileView.SetTempLate(TempItem)
            TempItem.TempOption.Apply()
        ElseIf DropItem.Text = "編集..." Then
            Dim frmEdit As New frmEditor
            If frmEdit.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                InitTempList()
            End If
        End If
    End Sub
    ''' <summary>
    ''' エクスポート
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Template_ExportClicked(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim tempItem As TemplateItem = Nothing
        Try
            tempItem = Me.FileView.GetTemplate()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End Try
        If Me.SaveFileDialog1.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Try
                Utility.SaveObjectAsFile(Me.SaveFileDialog1.FileName, tempItem)
            Catch ex As Exception
                MessageBox.Show("エクスポートが失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End If
    End Sub
    ''' <summary>
    ''' インポート
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Template_ImportClicked(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.OpenFileDialog1.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Try
                Dim TempItem As TemplateItem = CType(Utility.OpenObjectFromFile(Me.OpenFileDialog1.FileName), TemplateItem)
                Me.FileView.SetTempLate(TempItem)
                TempItem.TempOption.Apply()
            Catch ex As Exception
                MessageBox.Show("インポートが失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End If
    End Sub
#Region "DoWork"
    Private Sub BackgroundWorker1_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        If CInt(e.Argument) = 0 Then
            DoZipwork()
        ElseIf CInt(e.Argument) = 1 Then
            DoReleaseWork()
        End If
    End Sub
    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        Me.ProgressBar1.Value = e.ProgressPercentage
        If e.UserState IsNot Nothing AndAlso TypeOf e.UserState Is String Then
            Me.LblProgressMsg.Text = CStr(e.UserState)
        End If
    End Sub
    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted

        Me.ProgressBar1.Visible = False

    End Sub
    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTop.CheckedChanged
        Me.TopMost = Me.chkTop.Checked
        My.Settings.TopMost = Me.TopMost
    End Sub
#End Region










End Class
