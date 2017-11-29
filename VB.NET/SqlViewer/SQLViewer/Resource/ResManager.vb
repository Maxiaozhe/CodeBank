Namespace Resources
    Public Class ResManager
        Private Shared currentculture As Global.System.Globalization.CultureInfo
        Public Shared Function GetErrorMessage(ByVal err As Errors) As String
            Try
                Return My.Resources.Errors.ResourceManager.GetString(err.ToString, Culture)
            Catch ex As Exception
                Return ""
            End Try
        End Function
        Public Shared Function GetErrorMessage(ByVal err As Errors, ByVal ParamArray args As String()) As String
            Try
                Dim strBuf As String = My.Resources.Errors.ResourceManager.GetString(err.ToString, Culture)
                Return String.Format(strBuf, args)
            Catch ex As Exception
                Return ""
            End Try
        End Function
        Public Shared Function GetWarningMessage(ByVal Warning As Warnings) As String
            Try
                Return My.Resources.Warnings.ResourceManager.GetString(Warning.ToString, Culture)
            Catch ex As Exception
                Return ""
            End Try
        End Function
        Public Shared Function GetExclamationMessage(ByVal Warning As Warnings, ByVal ParamArray args As String()) As String
            Try
                Dim strBuf As String = My.Resources.Warnings.ResourceManager.GetString(Warning.ToString, Culture)
                Return String.Format(strBuf, args)
            Catch ex As Exception
                Return ""
            End Try
        End Function
        Public Shared Function GetInformationMessage(ByVal info As Informations) As String
            Try
                Return My.Resources.Informations.ResourceManager.GetString(info.ToString, Culture)
            Catch ex As Exception
                Return ""
            End Try
        End Function
        Public Shared Function GetInformationMessage(ByVal info As Informations, ByVal ParamArray args As String()) As String
            Try
                Dim strBuf As String = My.Resources.Informations.ResourceManager.GetString(info.ToString, Culture)
                Return String.Format(strBuf, args)
            Catch ex As Exception
                Return ""
            End Try
        End Function
        Public Shared Function GetQuestionMessage(ByVal Quest As Questions) As String
            Try
                Return My.Resources.Questions.ResourceManager.GetString(Quest.ToString, Culture)
            Catch ex As Exception
                Return ""
            End Try
        End Function
        Public Shared Function GetQuestionMessage(ByVal Quest As Questions, ByVal ParamArray args As String()) As String
            Try
                Dim strBuf As String = My.Resources.Questions.ResourceManager.GetString(Quest.ToString, Culture)
                Return String.Format(strBuf, args)
            Catch ex As Exception
                Return ""
            End Try
        End Function
      

        Public Shared Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return currentculture
            End Get
            Set(ByVal value As Global.System.Globalization.CultureInfo)
                currentculture = value
            End Set
        End Property
    End Class

End Namespace
