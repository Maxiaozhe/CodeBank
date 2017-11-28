Public Class Utility
    ''' <summary>
    ''' Object���V���A�������āABase64������ɕϊ�����
    ''' </summary>
    ''' <param name="Obj"></param>
    ''' <returns></returns>
    ''' <remarks>[ObjectData]�V���A�����\��Object�iSerializable) �����t���A
    ''' �����ISerializable�̃C���^�[�t�F�[�X�������Ă���Class</remarks>
    Public Shared Function ObjectToString(ByVal Obj As Object) As String
        Dim StrSerializ As String = ""
        Dim Formater As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter()
        Dim Stream As New System.IO.MemoryStream()
        Formater.Serialize(Stream, Obj)
        Dim bts() As Byte
        bts = Stream.ToArray()
        StrSerializ = System.Convert.ToBase64String(bts)
        Stream.Close()
        Return StrSerializ
    End Function
   ''' <summary>
    ''' Object�̋t�V���A����
    ''' </summary>
    ''' <param name="StrSerializ"></param>
    ''' <returns></returns>
    ''' <remarks>�V���A�������ꂽ�������Object�ɊҌ�����</remarks>
    Public Shared Function StringToObject(ByVal StrSerializ As String) As Object
        Try
            If StrSerializ = "" Then
                Return New NamingSetting
            End If
            Dim ObjReturn As Object
            Dim Formater As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter()
            Dim Stream As New System.IO.MemoryStream()
            Dim bts() As Byte
            bts = System.Convert.FromBase64String(StrSerializ)
            Stream.Write(bts, 0, bts.Length)
            Stream.Position = 0
            ObjReturn = Formater.Deserialize(Stream)
            Stream.Close()
            Return ObjReturn
        Catch ex As Exception
            Return New NamingSetting
        Finally

        End Try
    End Function
    ''' <summary>
    ''' Object���V���A�������āA�t�@�C���Ƃ��ĕۑ�����
    ''' </summary>
    ''' <param name="FileName"></param>
    ''' <param name="obj"></param>
    ''' <remarks></remarks>
    Public Shared Sub SaveObjectAsFile(ByVal FileName As String, ByVal obj As Object)
        Dim Stream As System.IO.FileStream = Nothing
        Try
            Dim StrSerializ As String = ""
            Dim Formater As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter()
            Stream = New System.IO.FileStream(FileName, IO.FileMode.Create)
            Formater.Serialize(Stream, obj)
        Finally
            If Stream IsNot Nothing Then
                Stream.Close()
                Stream = Nothing
            End If
        End Try
     
    End Sub
    ''' <summary>
    ''' �t�@�C������I�u�W�F�N�g�̃C���X�^���X�𕜌�����
    ''' </summary>
    ''' <param name="FileName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function OpenObjectFromFile(ByVal FileName As String) As Object
        Dim Stream As System.IO.FileStream = Nothing
        Try
            Dim ObjReturn As Object = Nothing
            Dim Formater As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter()
            Stream = New System.IO.FileStream(FileName, IO.FileMode.Open)
            ObjReturn = Formater.Deserialize(Stream)
            Return ObjReturn
        Finally
            If Stream IsNot Nothing Then
                Stream.Close()
                Stream = Nothing
            End If
        End Try
    End Function

End Class
