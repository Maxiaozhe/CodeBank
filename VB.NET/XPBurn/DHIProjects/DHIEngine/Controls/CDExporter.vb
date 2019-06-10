Imports System.IO
Imports System.Xml
Imports System.Xml.Schema
''' <summary>
''' XMLファイル出力コントロール
''' </summary>
''' <remarks></remarks>
Public Class CDExporter
    Private WithEvents mCdBurner As XPBurn.XPBurnCD
    Private mIsXMLOK As Boolean
    Public Event ProcessMessage(ByVal sender As Object, ByVal e As ProcessEventsArgs)
    Public Sub New()
        mCdBurner = New XPBurn.XPBurnCD

    End Sub

    Public Function IsReady() As Boolean
        If mCdBurner.IsErasing OrElse mCdBurner.IsBurning Then
            Return False
        End If
        If mCdBurner.RecorderDrives.Count = 0 Then
            Return False
        End If
        If mCdBurner.MediaInfo.isWritable = False Then
            Return False
        End If
        Return True
    End Function

    Public Sub CheckDriver()
        If mCdBurner.RecorderDrives.Count = 0 Then
            Throw New XPBurn.XPBurnException("このシステムには書き込み可能なCDR/CDRWドライブがありません。")
        End If
        If mCdBurner.IsErasing OrElse mCdBurner.IsBurning Then
            Throw New XPBurn.XPBurnException("CDRWは既に書き込みています。")
        End If
        If mCdBurner.MediaInfo.isWritable = False Then
            Throw New XPBurn.XPBurnException("書き込み可能なCDをドライブに挿入してください。")
        End If
    End Sub
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
        RaiseEvent ProcessMessage(Me, New ProcessEventsArgs(My.Resources.Messages.XMLChecking, 0, ProcessEventsArgs.ProcessTypes.XMLCHeck, True))
        While xmlReader.Read

        End While
        If Me.mIsXMLOK = True Then
            RaiseEvent ProcessMessage(Me, New ProcessEventsArgs(My.Resources.Messages.XmlCheckComplete, 0, ProcessEventsArgs.ProcessTypes.BurnComplete, True))
        Else
            RaiseEvent ProcessMessage(Me, New ProcessEventsArgs(My.Resources.Messages.XmlCheckFailed, 0, ProcessEventsArgs.ProcessTypes.BurnComplete, True))
        End If

        Return mIsXMLOK
    End Function

    ''' <summary>
    ''' ファイルを出力する
    ''' </summary>
    ''' <param name="FilePath"></param>
    ''' <remarks></remarks>
    Public Sub SaveFile(ByVal FilePath As String)
        If System.IO.File.Exists(FilePath) = False Then
            Throw New ApplicationException(String.Format(My.Resources.Messages.NotFindFile, FilePath))
        End If
        Dim InfileStream As New System.IO.FileStream(FilePath, FileMode.Open, FileAccess.Read)
        Dim bts(CInt(InfileStream.Length) - 1) As Byte
        InfileStream.Read(bts, 0, CInt(InfileStream.Length))
        InfileStream.Close()
        Dim Encryptor As New Encryptor
        Dim enbts As Byte() = Encryptor.EncodeByteArray(bts)
        Dim outFile As String = Env.OutPutFilePath
        Dim outfileStream As New System.IO.FileStream(Env.OutPutFilePath, FileMode.Create, FileAccess.Write)
        outfileStream.Write(enbts, 0, enbts.Length)
        outfileStream.Close()
        Me.mCdBurner.AddFile(outFile, System.IO.Path.GetFileName(outFile))
        Me.mCdBurner.RecordDisc(False, True)
    End Sub

 
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

    Private Sub mCdBurner_BlockProgress(ByVal nCompletedSteps As Integer, ByVal nTotalSteps As Integer) Handles mCdBurner.BlockProgress
        Dim pst As Integer = CInt(nCompletedSteps * 100 / nTotalSteps)
        Dim msg As String = String.Format(My.Resources.Messages.BlockProgress, pst)
        RaiseEvent ProcessMessage(Me, New ProcessEventsArgs(msg, pst, ProcessEventsArgs.ProcessTypes.Burning, False))
    End Sub

    Private Sub mCdBurner_BurnComplete(ByVal status As UInteger) Handles mCdBurner.BurnComplete
        RaiseEvent ProcessMessage(Me, New ProcessEventsArgs(My.Resources.Messages.BurnComplete, 100, ProcessEventsArgs.ProcessTypes.BurnComplete, True))
    End Sub

    Private Sub mCdBurner_PreparingBurn(ByVal nEstimatedSeconds As Integer) Handles mCdBurner.PreparingBurn

        RaiseEvent ProcessMessage(Me, New ProcessEventsArgs(My.Resources.Messages.PreparingBurn, 0, ProcessEventsArgs.ProcessTypes.Burning, True))
    End Sub

    Private Sub mCdBurner_TrackProgress(ByVal nCompletedSteps As Integer, ByVal nTotalSteps As Integer) Handles mCdBurner.TrackProgress
        Dim pst As Integer = CInt(nCompletedSteps * 100 / nTotalSteps)
        Dim msg As String = String.Format(My.Resources.Messages.BlockProgress, pst)
        RaiseEvent ProcessMessage(Me, New ProcessEventsArgs(msg, pst, ProcessEventsArgs.ProcessTypes.Burning, False))
    End Sub
End Class
