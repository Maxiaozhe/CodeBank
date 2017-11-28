Public Class Utility
    ''' <summary>
    ''' Objectをシリアル化して、Base64文字列に変換する
    ''' </summary>
    ''' <param name="Obj"></param>
    ''' <returns></returns>
    ''' <remarks>[ObjectData]シリアル化可能のObject（Serializable) 属性付く、
    ''' およびISerializableのインターフェースを持っているClass</remarks>
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
    ''' Objectの逆シリアル化
    ''' </summary>
    ''' <param name="StrSerializ"></param>
    ''' <returns></returns>
    ''' <remarks>シリアル化された文字列をObjectに還元する</remarks>
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
    ''' Objectをシリアル化して、ファイルとして保存する
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
    ''' ファイルからオブジェクトのインスタンスを復元する
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
