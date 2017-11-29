Public Class Messages
    Public Shared Sub ShowInfomation(ByVal info As Informations)
        Dim msg As String = Resources.ResManager.GetInformationMessage(info)
        MessageBox.Show(msg, "SQLViewer", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Public Shared Sub ShowWaring(ByVal Warning As Warnings)
        Dim msg As String = Resources.ResManager.GetWarningMessage(Warning)
        MessageBox.Show(msg, "SQLViewer", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub
    Public Shared Function ShowQuery(ByVal Quest As Questions) As DialogResult
        Dim msg As String = Resources.ResManager.GetQuestionMessage(Quest)
        Return MessageBox.Show(msg, "SQLViewer", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
    End Function
    Public Shared Function ShowError(ByVal Err As Errors) As DialogResult
        Dim msg As String = Resources.ResManager.GetErrorMessage(Err)
        Return MessageBox.Show(msg, "SQLViewer", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Function
    Public Shared Function ShowExcption(ByVal ex As Exception) As DialogResult
        Dim msg As String = ex.Message
        Return MessageBox.Show(msg, "SQLViewer", MessageBoxButtons.OK, MessageBoxIcon.Stop)
    End Function
End Class
