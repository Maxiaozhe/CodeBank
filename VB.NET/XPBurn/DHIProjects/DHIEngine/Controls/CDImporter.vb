Imports System.IO
Imports System.Xml
Imports System.Xml.Schema
Public Class CDImporter
    Private mIsXMLOK As Boolean

    Public Event ProcessMessage(ByVal sender As Object, ByVal e As ProcessEventsArgs)
    ''' <summary>
    ''' XMLの整合性をチェックします
    ''' </summary>
    ''' <param name="FilePath"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CheckXmlFile(ByVal FilePath As String) As Boolean
        mIsXMLOK = True
        If System.IO.File.Exists(FilePath) = False Then
            Throw New ApplicationException(String.Format(My.Resources.Messages.NotFindFile, FilePath))
        End If
        Dim xsdPath As String = Env.XSDFilePath
        Dim XsdStream As System.IO.FileStream
        Dim XmlSc As XmlSchema = Nothing
        If System.IO.File.Exists(xsdPath) Then
            XsdStream = New System.IO.FileStream(xsdPath, FileMode.Open, FileAccess.Read)
            XmlSc = XmlSchema.Read(XsdStream, AddressOf ValidationEventHandler)
            XsdStream.Close()
        End If
        Dim XmlSetting As New XmlReaderSettings
        XmlSetting.ValidationType = ValidationType.Schema
        If XmlSc IsNot Nothing Then
            XmlSetting.Schemas.Add(XmlSc)
        End If
        XmlSetting.ValidationFlags = XmlSchemaValidationFlags.ProcessInlineSchema
        AddHandler XmlSetting.ValidationEventHandler, AddressOf ValidationEventHandler
        Dim xmlReader As XmlReader = xmlReader.Create(FilePath, XmlSetting)
        Dim buf As New System.Text.StringBuilder
        RaiseEvent ProcessMessage(Me, New ProcessEventsArgs(My.Resources.Messages.XMLChecking, 90, ProcessEventsArgs.ProcessTypes.XMLCHeck, True))
        While xmlReader.Read

        End While
        If Me.mIsXMLOK = True Then
            RaiseEvent ProcessMessage(Me, New ProcessEventsArgs(My.Resources.Messages.XmlCheckComplete, 99, ProcessEventsArgs.ProcessTypes.CDReadComplete, True))
        Else
            RaiseEvent ProcessMessage(Me, New ProcessEventsArgs(My.Resources.Messages.XmlCheckFailed, 99, ProcessEventsArgs.ProcessTypes.CDReadComplete, True))
        End If

        Return mIsXMLOK
    End Function

    Private Sub ValidationEventHandler(ByVal sender As Object, ByVal e As System.Xml.Schema.ValidationEventArgs)
        mIsXMLOK = False
        Dim NameSpaceUri As String = ""
        If TypeOf sender Is XmlReader Then
            Dim reader As XmlReader = CType(sender, XmlReader)
            NameSpaceUri = reader.NamespaceURI
        End If
        Dim message As String = e.Exception.Message
        If NameSpaceUri <> "" Then
            message = e.Exception.Message.Replace(NameSpaceUri, "")
        End If
        Dim msg As String = e.Exception.LineNumber & "行 " & e.Exception.LinePosition & "列" & message
        RaiseEvent ProcessMessage(Me, New ProcessEventsArgs(msg, 0, ProcessEventsArgs.ProcessTypes.XMLCHeck, True))
    End Sub

    ''' <summary>
    ''' ファイルを出力する
    ''' </summary>
    ''' <param name="FilePath"></param>
    ''' <remarks></remarks>
    Public Sub ImportFile(ByVal FilePath As String)
        If System.IO.File.Exists(FilePath) = False Then
            Throw New ApplicationException(String.Format(My.Resources.Messages.NotFindFile, FilePath))
        End If
        Dim bts() As Byte
        Try
            RaiseEvent ProcessMessage(Me, New ProcessEventsArgs(My.Resources.Messages.XmlImporting, 0, ProcessEventsArgs.ProcessTypes.CDReading, True))
            Dim InfileStream As New System.IO.FileStream(FilePath, FileMode.Open, FileAccess.Read)
            ReDim bts(CInt(InfileStream.Length) - 1)
            InfileStream.Read(bts, 0, CInt(InfileStream.Length))
            InfileStream.Close()
        Catch ex As Exception
            RaiseEvent ProcessMessage(Me, New ProcessEventsArgs(My.Resources.Messages.CantReadFile, 0, ProcessEventsArgs.ProcessTypes.CDReading, True))
            Return
        End Try
        Dim outFile As String = ""
        Dim deBuffer As String = ""
        Try
            Dim Encryptor As New Encryptor
            deBuffer = Encryptor.DecodeFromByte(bts)
        Catch ex As Exception
            RaiseEvent ProcessMessage(Me, New ProcessEventsArgs(My.Resources.Messages.CantRecognizeFormat, 90, ProcessEventsArgs.ProcessTypes.CDReading, True))
            Return
        End Try
        Try
            outFile = Env.importFilepath
            Dim outfileStream As New System.IO.FileStream(outFile, FileMode.Create, FileAccess.Write)
            Dim debts() As Byte = System.Text.Encoding.UTF8.GetBytes(deBuffer)
            outfileStream.Write(debts, 0, debts.Length)
            outfileStream.Close()
            RaiseEvent ProcessMessage(Me, New ProcessEventsArgs(My.Resources.Messages.XmlImported, 90, ProcessEventsArgs.ProcessTypes.CDReading, True))

        Catch ex As Exception
            RaiseEvent ProcessMessage(Me, New ProcessEventsArgs(ex.Message, 90, ProcessEventsArgs.ProcessTypes.CDReading, True))
            Return
        End Try

        If CheckXmlFile(outFile) = True Then
            RaiseEvent ProcessMessage(Me, New ProcessEventsArgs(My.Resources.Messages.XmlImported, 100, ProcessEventsArgs.ProcessTypes.CDReadComplete, True))

        End If
    End Sub
End Class
