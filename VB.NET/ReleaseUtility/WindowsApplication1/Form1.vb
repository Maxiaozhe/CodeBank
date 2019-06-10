Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Me.OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Try
                Dim fileName As String = Me.OpenFileDialog1.FileName
                Dim IconBig As Icon = Win32.GetLargeIcon(fileName)
                Dim IconSmall As Icon = Win32.GetSmallIcon(fileName)
                Dim iconName As String = System.IO.Path.GetFileNameWithoutExtension(fileName)
                Dim iconNormal As Icon = Icon.ExtractAssociatedIcon(fileName)
                Dim iconPathsmall As String = iconName & "_small.ico"
                Dim iconPathbig As String = iconName & "_big.ico"
                Dim iconPath = iconName & ".ico"
                Using stream As System.IO.FileStream = New IO.FileStream(iconPathsmall, IO.FileMode.Create)
                    IconSmall.Save(stream)
                End Using
                Using stream As System.IO.FileStream = New IO.FileStream(iconPathbig, IO.FileMode.Create)
                    IconBig.Save(stream)
                End Using
                Using stream As System.IO.FileStream = New IO.FileStream(iconPath, IO.FileMode.Create)
                    iconNormal.Save(stream)
                End Using

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

        End If
    End Sub
End Class
