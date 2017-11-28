Public Class BatchWork

    Private mIsSilent As Boolean = False

    Public Property IsSilent() As Boolean
        Get
            Return mIsSilent
        End Get
        Set(ByVal value As Boolean)
            mIsSilent = value
        End Set
    End Property
    Public Sub DoReleaseWork(ByVal TempItem As TemplateItem)
        Try
            Dim totalCount As Integer = TempItem.GetFileCount
            If totalCount = 0 Then
                Return
            End If

            Dim CurrentOption As OptionData = TempItem.TempOption
            If CurrentOption.ReleaseFolder = "" OrElse CurrentOption.ReleaseNameSeting.GetFolderName = "" Then
                Return
            End If
            Dim NewFolder As String = My.Computer.FileSystem.CombinePath(CurrentOption.ReleaseFolder, CurrentOption.ReleaseNameSeting.GetFolderName())
            If System.IO.Directory.Exists(NewFolder) = False Then
                My.Computer.FileSystem.CreateDirectory(NewFolder)
            End If
            '一時フォルダを作成する
            Dim Basepath As String = NewFolder
            AddAllFiles(Basepath, TempItem.TreeRoot)
            If mIsSilent = False Then
                Process.Start(My.Computer.FileSystem.GetParentPath(Basepath))
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub DoZipwork(ByVal TempItem As TemplateItem)
        Dim Basepath As String = ""
        Try
            Dim totalCount As Integer = TempItem.GetFileCount
            If totalCount = 0 Then
                Return
            End If
            Dim Options As OptionData = TempItem.TempOption

            Dim NewFolder As String = My.Computer.FileSystem.CombinePath(Options.OutputFold, DateTime.Today.ToString("yyyyMMdd"))
            If System.IO.Directory.Exists(NewFolder) = False Then
                My.Computer.FileSystem.CreateDirectory(NewFolder)
            End If
            'アーカイブファイル名
            Dim archiveFileName As String = Options.ZipFileNameSetting.Getname
            Dim archiveFile As String = My.Computer.FileSystem.CombinePath(NewFolder, archiveFileName)
            '一時フォルダを作成する
            Basepath = My.Computer.FileSystem.CombinePath(My.Computer.FileSystem.SpecialDirectories.Temp, System.IO.Path.GetFileNameWithoutExtension(archiveFileName))

            AddAllFiles(Basepath, TempItem.TreeRoot)
            CreateZipFile(Basepath, archiveFile, Options)
            If mIsSilent = False Then
                Process.Start(My.Computer.FileSystem.GetParentPath(archiveFile))
            End If

        Catch ex As Exception
            Throw ex
        Finally
            If System.IO.File.Exists(Basepath) Then
                Dim IsDeleted As Boolean = False
                Dim RetryCount As Integer = 0

                While IsDeleted = False AndAlso RetryCount <= 10
                    Try
                        My.Computer.FileSystem.DeleteDirectory(Basepath, FileIO.DeleteDirectoryOption.DeleteAllContents)
                        IsDeleted = True
                    Catch ex As Exception
                        RetryCount += 1
                        Threading.Thread.Sleep(1000)
                    End Try
                End While
            End If
        End Try
    End Sub

    Private Function CreateZipFile(ByVal BasePath As String, ByVal archiveFile As String, ByVal options As OptionData) As String
        Dim sbCmd As System.Text.StringBuilder = Nothing
        Dim index As Integer = 0
        sbCmd = New System.Text.StringBuilder
        sbCmd.Append("a -ed -ep1 -r")
        If options.Password <> "" Then
            sbCmd.Append(" -p" & options.Password)
        End If
        sbCmd.Append(" """ & archiveFile & """")
        sbCmd.Append(" """ & BasePath & """")
        Dim rarPro As New Process()
        Dim ProcessInfo As ProcessStartInfo = rarPro.StartInfo
        ProcessInfo.FileName = options.WinrarPath
        ProcessInfo.Arguments = sbCmd.ToString
        ProcessInfo.WindowStyle = ProcessWindowStyle.Hidden
        ProcessInfo.RedirectStandardOutput = True
        ProcessInfo.UseShellExecute = False
        ProcessInfo.CreateNoWindow = True
        rarPro.Start()
        rarPro.BeginOutputReadLine()
        While rarPro.WaitForExit(100) = False
        End While
        rarPro.Close()
        Return archiveFile
    End Function

    Private Sub AddAllFiles(ByVal BasePath As String, ByVal ParentNode As TreeNode)
        If ParentNode.Tag IsNot Nothing AndAlso TypeOf ParentNode.Tag Is String Then
            Dim path As String = CStr(ParentNode.Tag)
            If path = "" Then
                Dim Fold As String = My.Computer.FileSystem.CombinePath(BasePath, GetNodeFullPath("", ParentNode))
                If My.Computer.FileSystem.DirectoryExists(Fold) = False Then
                    My.Computer.FileSystem.CreateDirectory(Fold)
                End If
            ElseIf My.Computer.FileSystem.FileExists(path) Then
                Dim disPath As String = My.Computer.FileSystem.CombinePath(BasePath, GetNodeFullPath("", ParentNode))
                My.Computer.FileSystem.CopyFile(path, disPath, False)
                Dim finfo As New System.IO.FileInfo(disPath)
                If (finfo.Attributes And IO.FileAttributes.ReadOnly) = IO.FileAttributes.ReadOnly Then
                    finfo.Attributes = IO.FileAttributes.Normal
                End If
            End If
        End If
        If ParentNode.Nodes.Count > 0 Then
            For Each subNode As TreeNode In ParentNode.Nodes
                AddAllFiles(BasePath, subNode)
            Next
        End If
    End Sub

    Private Function GetNodeFullPath(ByVal Currpath As String, ByVal Node As TreeNode) As String
        Dim Path As String = ""
        If String.IsNullOrEmpty(Currpath) = True Then
            Path = Node.Text
        ElseIf String.IsNullOrEmpty(Node.Text) = True Then
            Path = Currpath
        Else
            Path = System.IO.Path.Combine(Node.Text, Currpath)
        End If
        If Node.Parent IsNot Nothing AndAlso Node.Parent.Tag IsNot Nothing Then
            Path = GetNodeFullPath(Path, Node.Parent)
        End If
        Return Path
    End Function

    Public Sub ShowHelp()
        If Me.mIsSilent = True Then Return
        Dim Sbhelp As New System.Text.StringBuilder
        Sbhelp.AppendLine("使用方法：")
        Sbhelp.AppendLine("ReleaseUtility [テンプレートファイルパス] [-R | -Z] [-S]")
        Sbhelp.AppendLine("------------------------------------------------------")
        Sbhelp.AppendLine("引数：")
        Sbhelp.AppendLine("     -Z ：圧縮ファイルを作成する")
        Sbhelp.AppendLine("     -R ：リリースフォルダへコピー")
        Sbhelp.AppendLine("     -S ：サイレントモード")
        Sbhelp.AppendLine("     -? ：ヘルプ")
        Sbhelp.AppendLine("------------------------------------------------------")
        Sbhelp.AppendLine("使用例：")
        Sbhelp.AppendLine("１．テンプレートで圧縮ファイルを作成する：")
        Sbhelp.AppendLine("     ReleaseUtility -Z C:\Templeate.rut")
        Sbhelp.AppendLine("２．テンプレートでファイルをリリースする：")
        Sbhelp.AppendLine("     ReleaseUtility -R C:\Templeate.rut")
        MessageBox.Show(Sbhelp.ToString, "ヘルプ", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class
