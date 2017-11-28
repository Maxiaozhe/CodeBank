Namespace My

    ' 次のイベントは MyApplication に対して利用できます:
    ' 
    ' Startup: アプリケーションが開始されたとき、スタートアップ フォームが作成される前に発生します。
    ' Shutdown: アプリケーション フォームがすべて閉じられた後に発生します。このイベントは、通常の終了以外の方法でアプリケーションが終了されたときには発生しません。
    ' UnhandledException: ハンドルされていない例外がアプリケーションで発生したときに発生するイベントです。
    ' StartupNextInstance: 単一インスタンス アプリケーションが起動され、それが既にアクティブであるときに発生します。 
    ' NetworkAvailabilityChanged: ネットワーク接続が接続されたとき、または切断されたときに発生します。
    Partial Friend Class MyApplication

        Private Sub MyApplication_Shutdown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shutdown
            Dim TempDatas As String = My.Settings.Templates
            Dim TopMost As Boolean = My.Settings.TopMost
            My.Settings.Reload()
            My.Settings.Templates = TempDatas
            My.Settings.TopMost = TopMost
            My.Settings.Save()
        End Sub

        Private Sub MyApplication_Startup(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup
            If Me.CommandLineArgs.Count > 0 Then
                If DoBatch() = True Then
                    System.Environment.Exit(0)
                End If
            End If

        End Sub
        ''' <summary>
        ''' コマンドラインモード実行
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function DoBatch() As Boolean
            Dim Flag As String = ""
            Dim TempFilePath As String = ""
            Dim Batch As New BatchWork
            For Each Arg As String In My.Application.CommandLineArgs

                Select Case Arg.ToUpper
                    Case "-R", "-Z"
                        Flag = Arg.ToUpper
                        Continue For
                    Case "-?"
                        Flag = Arg.ToUpper
                        Batch.ShowHelp()
                        Return True
                    Case "-S"
                        Batch.IsSilent = True
                    Case Else
                        TempFilePath = Arg
                End Select
            Next
            Try
                If TempFilePath = "" OrElse System.IO.File.Exists(TempFilePath) = False Then
                    Batch.ShowHelp()
                    Return Batch.IsSilent
                End If
                Dim TempItem As TemplateItem = CType(Utility.OpenObjectFromFile(TempFilePath), TemplateItem)
                Select Case Flag
                    Case "-R"
                        Batch.DoReleaseWork(TempItem)
                        Return True
                    Case "-Z"
                        Batch.DoZipwork(TempItem)
                        Return True
                    Case Else
                        Batch.ShowHelp()
                        Return Batch.IsSilent
                End Select
            Catch ex As Exception
                If Batch.IsSilent = False Then
                    MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                Return Batch.IsSilent
            End Try
        End Function
    End Class

End Namespace

