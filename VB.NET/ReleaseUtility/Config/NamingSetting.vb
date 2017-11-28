<Serializable()> _
Public Class NamingSetting
    Public Perfix As String = ""
    Public suffix As String = ""
    Public Format As String = ""
    Public Ext As String = ""
    Public Function Getname() As String
        Dim name As String = ""
        If Format = "" Then
            name = Perfix & suffix & "." & Ext
        Else
            name = Perfix & DateTime.Now.ToString(Format) & suffix & "." & Ext
        End If
        Return name
    End Function

    Public Function GetFolderName() As String
        Dim name As String = ""
        If Format = "" Then
            name = Perfix & suffix
        Else
            name = Perfix & DateTime.Now.ToString(Format) & suffix
        End If
        Return name
    End Function

    '======================[ObjectToString�@�\����]==========================================
    '==�@Object���V���A�������āABase64������ɕϊ�����
    '==[ObjectData]�V���A�����\��Object�i<Serializable()> �����t���A�����ISerializable��
    '==�C���^�[�t�F�[�X�������Ă���Class
    '===================================================================
    Public Function ObjectToString() As String
        Dim StrSerializ As String = ""
        Dim Formater As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter()
        Dim Stream As New System.IO.MemoryStream()
        Formater.Serialize(Stream, Me)
        Dim bts() As Byte
        bts = Stream.ToArray()
        StrSerializ = System.Convert.ToBase64String(bts)
        Stream.Close()
        Return StrSerializ
    End Function
    '======================[StringToObject�@�\����]==========================================
    '==�@Object�̋t�V���A����
    '==�V���A�������ꂽ�������Object�ɊҌ�����
    '===================================================================
    Public Shared Function StringToObject(ByVal StrSerializ As String) As NamingSetting
        Try
            If StrSerializ = "" Then
                Return New NamingSetting
            End If
            Dim ObjReturn As NamingSetting
            Dim Formater As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter()
            Dim Stream As New System.IO.MemoryStream()
            Dim bts() As Byte
            bts = System.Convert.FromBase64String(StrSerializ)
            Stream.Write(bts, 0, bts.Length)
            Stream.Position = 0
            ObjReturn = CType(Formater.Deserialize(Stream), NamingSetting)
            Stream.Close()
            Return ObjReturn
        Catch ex As Exception
            Return New NamingSetting
        End Try
    End Function
End Class
