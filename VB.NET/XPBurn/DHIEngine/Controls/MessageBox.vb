Public Class MessageBox
    Private Const mAppName As String = "DHI Exporter"
    Public Shared Function ShowWarrning(ByVal msg As String) As DialogResult
        Return System.Windows.Forms.MessageBox.Show(msg, mAppName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Function
    Public Shared Function ShowInfomation(ByVal msg As String) As DialogResult
        Return System.Windows.Forms.MessageBox.Show(msg, mAppName, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Function
    Public Shared Function ShowQuestion(ByVal msg As String) As DialogResult
        Return System.Windows.Forms.MessageBox.Show(msg, mAppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
    End Function
    Public Shared Function ShowError(ByVal msg As String) As DialogResult
        Return System.Windows.Forms.MessageBox.Show(msg, mAppName, MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Function

End Class
