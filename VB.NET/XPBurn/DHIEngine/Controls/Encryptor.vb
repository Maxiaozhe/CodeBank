Option Compare Binary
Option Explicit On 
Option Strict On

Imports System.Security.Cryptography
''' -----------------------------------------------------------------------------
''' Project	 : DHI.Tools.SLExporter
''' Class	 : DHI.Tools.SLExporter.Encryptor
''' -----------------------------------------------------------------------------
''' <summary>
''' 暗号化・復元クラスを実装します。
''' </summary>
''' <remarks>
''' </remarks>
''' -----------------------------------------------------------------------------
Friend Class Encryptor
    'キー
    Private strkey As String = "igob+EOiq5hdHpm4ziSYhTQDba0imyvhcVT8s1OKam8="
    'IV
    Private striv As String = "DDMUISXyDoLajDJ8dNXnoA=="
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 文字列を暗号化文字列にする
    ''' </summary>
    ''' <param name="buffer"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' -----------------------------------------------------------------------------
    Public Function Encode(ByVal buffer As String) As String
        Dim bts() As Byte = System.Text.Encoding.UTF8.GetBytes(buffer)
        Dim deBts() As Byte = EncodeByteArray(bts)
        Dim strReturn As String = Convert.ToBase64String(deBts)
        Return strReturn
    End Function
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 文字列を暗号化配列に変換する
    ''' </summary>
    ''' <param name="buffer"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' -----------------------------------------------------------------------------
    Public Function EncodeToByte(ByVal buffer As String) As Byte()
        Dim bts() As Byte = System.Text.Encoding.UTF8.GetBytes(buffer)
        Dim deBts() As Byte = EncodeByteArray(bts)
        Return deBts
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' バイト配列を暗号化する
    ''' </summary>
    ''' <param name="ByteArray"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' -----------------------------------------------------------------------------
    Public Function EncodeByteArray(ByVal ByteArray() As Byte) As Byte()
        Dim rijn As New RijndaelManaged
        Dim key() As Byte = Convert.FromBase64String(strkey)
        Dim iv() As Byte = Convert.FromBase64String(striv)
        Dim encryptor As ICryptoTransform = rijn.CreateEncryptor(key, iv)
        'encrypt the data.
        Dim msEncrypt As New System.io.MemoryStream
        Dim csEncrypt As New CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write)
        'convert the data to a byte array.
        csEncrypt.Write(ByteArray, 0, ByteArray.Length)
        csEncrypt.FlushFinalBlock()
        Dim debts() As Byte = msEncrypt.ToArray()
        Return debts
    End Function
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 暗号化文字列を復元する
    ''' </summary>
    ''' <param name="buffer">暗号化する文字列</param>
    ''' <returns>復元される文字列</returns>
    ''' <remarks>
    ''' </remarks>
    ''' -----------------------------------------------------------------------------
    Public Function Decode(ByVal buffer As String) As String
        Dim debts() As Byte = Convert.FromBase64String(buffer)
        Dim bts() As Byte = DecodeByteArray(debts)
        Dim strReturn As String = System.Text.Encoding.UTF8.GetString(bts).TrimEnd(Chr(0))
        Return strReturn
    End Function
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 暗号化バイト配列から文字列に復元する
    ''' </summary>
    ''' <param name="buffer">暗号化するバイト配列</param>
    ''' <returns>復元される文字列</returns>
    ''' <remarks>
    ''' </remarks>
    ''' -----------------------------------------------------------------------------
    Public Function DecodeFromByte(ByVal buffer() As Byte) As String
        Dim bts() As Byte = DecodeByteArray(buffer)
        Dim strReturn As String = System.Text.Encoding.UTF8.GetString(bts).TrimEnd(Chr(0))
        Return strReturn
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 暗号化バイト配列を復元する
    ''' </summary>
    ''' <param name="ByteArray">暗号化するバイト配列</param>
    ''' <returns>復元されるバイト配列</returns>
    ''' <remarks>
    ''' </remarks>
    ''' -----------------------------------------------------------------------------
    Public Function DecodeByteArray(ByVal ByteArray() As Byte) As Byte()
        Dim rijn As New RijndaelManaged
        Dim key() As Byte = Convert.FromBase64String(strkey)
        Dim iv() As Byte = Convert.FromBase64String(striv)
        Dim deCryptor As ICryptoTransform = rijn.CreateDecryptor(key, iv)

        Dim msDecrypt As New System.IO.MemoryStream(ByteArray)
        Dim csDecrypt As New CryptoStream(msDecrypt, deCryptor, CryptoStreamMode.Read)
        Dim returnBytes(CInt(msDecrypt.Length) - 1) As Byte
        csDecrypt.Read(returnBytes, 0, returnBytes.Length)
        Return returnBytes
    End Function

End Class
