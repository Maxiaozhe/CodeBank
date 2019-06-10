''' <summary>
''' ログ出力コントロール
''' </summary>
''' <remarks></remarks>
Public Class logger
    Private Shared sbLog As System.Text.StringBuilder

   
    Public Shared Sub Writer(ByVal Msg As String)
        If sbLog Is Nothing Then
            sbLog = New System.Text.StringBuilder
        End If
        sbLog.Append(Now.ToString("yyyy/MM/dd HH:mm:ss"))
        sbLog.Append(",")
        sbLog.Append("""" & Msg.Replace("""", """""") & """")
        sbLog.Append(vbCrLf)

    End Sub
    ''' <summary>
    ''' ログを記録する
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function flush() As String
        Dim logFile As System.IO.FileStream = Nothing
        Dim logPath As String = Env.LogFilePath
        Try

            logFile = New System.IO.FileStream(logPath, IO.FileMode.Create, IO.FileAccess.Write)
            Dim Buffer() As Byte = System.Text.Encoding.Default.GetBytes(sbLog.ToString)
            logFile.Write(Buffer, 0, Buffer.Length)
            sbLog = Nothing
            sbLog = New System.Text.StringBuilder
        Catch ex As Exception
            EventLog.WriteEntry("DHIExporter", ex.Message, EventLogEntryType.Warning)
            Return ""
        Finally
            If logFile IsNot Nothing Then
                logFile.Close()
            End If
        End Try
        Return logPath
    End Function

    Public Shadows Function toString() As String
        Return sbLog.ToString
    End Function
End Class
