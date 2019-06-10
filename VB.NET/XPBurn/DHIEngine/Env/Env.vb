Public Class Env
    Private Const LogPathKey As String = "LogPath"
    Private Const XmlPathKey As String = "XmlPath"
    Private Const XsdPathKey As String = "XsdPath"
    Private Const OutFileKey As String = "OutputFileName"
    Private Const ImportFileKey As String = "ImportFileName"


    ''' <summary>
    ''' ログファイルパス
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property LogFilePath() As String
        Get
            Dim logFile As String = System.Configuration.ConfigurationManager.AppSettings.Item(LogPathKey)
            If System.IO.Directory.Exists(logFile) = False Then
                logFile = AppDomain.CurrentDomain.SetupInformation.ApplicationBase
            End If
            
            Return System.IO.Path.Combine(logFile, "log_" & DateTime.Now.ToString("yyMMddHHmmss") & ".csv")

        End Get
    End Property
    ''' <summary>
    ''' XMLファイル
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property XmlFilePath() As String
        Get
            Dim xmlFile As String = System.Configuration.ConfigurationManager.AppSettings.Item(XmlPathKey)
            If System.IO.File.Exists(xmlFile) = False Then
                xmlFile = System.IO.Path.GetFileName(xmlFile)
                xmlFile = System.IO.Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, xmlFile)
            End If
            Return xmlFile
        End Get
    End Property
    ''' <summary>
    ''' XSDファイルパス
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property XSDFilePath() As String
        Get
            Dim xsdFile As String = System.Configuration.ConfigurationManager.AppSettings.Item(XsdPathKey)
            If System.IO.File.Exists(xsdFile) = False Then
                xsdFile = System.IO.Path.GetFileName(xsdFile)
                xsdFile = System.IO.Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, xsdFile)
            End If
            Return xsdFile
        End Get
    End Property

    ''' <summary>
    ''' 出力ファイル名
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property OutPutFilePath() As String
        Get
            Dim outFile As String = System.Configuration.ConfigurationManager.AppSettings.Item(OutFileKey)
            If outFile = "" Then
                Return "outfile.dhi"
            Else
                Return outFile
            End If
        End Get
    End Property
    ''' <summary>
    ''' 取り込みファイルパス
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property importFilepath() As String
        Get
            Dim inFile As String = System.Configuration.ConfigurationManager.AppSettings.Item(ImportFileKey)
            If System.IO.File.Exists(inFile) = False Then
                inFile = System.IO.Path.GetFileName(inFile)
                inFile = System.IO.Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, inFile)
            End If
            Return inFile
        End Get
    End Property

End Class
