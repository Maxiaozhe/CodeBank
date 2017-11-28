Namespace My

    ' ���̃C�x���g�� MyApplication �ɑ΂��ė��p�ł��܂�:
    ' 
    ' Startup: �A�v���P�[�V�������J�n���ꂽ�Ƃ��A�X�^�[�g�A�b�v �t�H�[�����쐬�����O�ɔ������܂��B
    ' Shutdown: �A�v���P�[�V���� �t�H�[�������ׂĕ���ꂽ��ɔ������܂��B���̃C�x���g�́A�ʏ�̏I���ȊO�̕��@�ŃA�v���P�[�V�������I�����ꂽ�Ƃ��ɂ͔������܂���B
    ' UnhandledException: �n���h������Ă��Ȃ���O���A�v���P�[�V�����Ŕ��������Ƃ��ɔ�������C�x���g�ł��B
    ' StartupNextInstance: �P��C���X�^���X �A�v���P�[�V�������N������A���ꂪ���ɃA�N�e�B�u�ł���Ƃ��ɔ������܂��B 
    ' NetworkAvailabilityChanged: �l�b�g���[�N�ڑ����ڑ����ꂽ�Ƃ��A�܂��͐ؒf���ꂽ�Ƃ��ɔ������܂��B
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
        ''' �R�}���h���C�����[�h���s
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
                    MessageBox.Show(ex.Message, "�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                Return Batch.IsSilent
            End Try
        End Function
    End Class

End Namespace

