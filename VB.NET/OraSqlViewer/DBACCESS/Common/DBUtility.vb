Option Compare Binary
Option Explicit On 
Option Strict On
Namespace Common
    Public NotInheritable Class ToolUtility
#Region "データ変換関数集合"
        ''' <summary>
        ''' 値DBNULLおよびNothingの場合、デフォルト値に変換する
        ''' </summary>
        ''' <param name="value">変換対象値</param>
        ''' <param name="Defval">デフォルト値</param>
        ''' <returns>変換後の値を戻す</returns>
        Public Shared Function NVL(ByVal value As Object, ByVal Defval As Object) As Object
            If value Is Nothing OrElse TypeOf value Is DBNull Then
                Return Defval
            Else
                Return value
            End If
        End Function
        ''' <summary>
        ''' 変換(String)
        ''' </summary>
        ''' <param name="value">値</param>
        ''' <returns>変換後の値</returns>
        Public Shared Function DBToString(ByVal value As Object) As String

            If value Is Nothing OrElse TypeOf value Is DBNull Then
                Return ""
            Else
                Return CType(value, String)
            End If

        End Function
        ''' <summary>
        ''' 変換(DateTime)
        ''' </summary>
        ''' <param name="value">値</param>
        ''' <returns>変換後の値</returns>
        Public Shared Function DBToDateTime(ByVal value As Object) As Date

            If value Is Nothing OrElse TypeOf value Is DBNull Then
                Return Date.MinValue
            Else
                Return CType(value, Date)
            End If

        End Function
        ''' <summary>
        ''' 変換(Byte)
        ''' </summary>
        ''' <param name="value">値</param>
        ''' <returns>変換後の値</returns>
        Public Shared Function DBToByte(ByVal value As Object) As Byte
         
            If value Is Nothing OrElse TypeOf value Is DBNull Then
                Return 0
            Else
                Return CType(value, Byte)
            End If

        End Function
        ''' <summary>
        ''' 変換(Byte)
        ''' </summary>
        ''' <param name="value">値</param>
        ''' <returns>変換後の値</returns>
        Public Shared Function DBToByteList(ByVal value As Object) As Byte()
         
            If value Is Nothing OrElse TypeOf value Is DBNull Then
                Dim byteList(0) As Byte
                Return byteList
            Else
                Return CType(value, Byte())
            End If

        End Function
        ''' <summary>
        ''' 変換(Integer)
        ''' </summary>
        ''' <param name="value">値</param>
        ''' <returns>変換後の値</returns>
        Public Shared Function DBToInteger(ByVal value As Object) As Integer

            If value Is Nothing OrElse TypeOf value Is DBNull Then
                Return 0
            Else
                Return CInt(value)
            End If

        End Function
        ''' <summary>
        ''' 変換(Long)
        ''' </summary>
        ''' <param name="value">値</param>
        ''' <returns>変換後の値</returns>
        Public Shared Function DBToLong(ByVal value As Object) As Long

          
            If value Is Nothing OrElse TypeOf value Is DBNull Then
                Return 0
            Else
                Return CLng(value)
            End If

        End Function
        ''' <summary>
        ''' 変換(Boolean)
        ''' </summary>
        ''' <param name="value">値</param>
        ''' <returns>変換後の値</returns>
        Public Shared Function DBToBoolean(ByVal value As Object) As Boolean

         
            If value Is Nothing OrElse TypeOf value Is DBNull Then
                Return False
            End If
            Dim result As Boolean
            If Boolean.TryParse(value.ToString(), result) = True Then
                Return result
            Else
                If CStr(value) = "N" Then
                    Return False
                ElseIf CStr(value) = "Y" Then
                    Return True
                End If
            End If
        End Function
        ''' <summary>
        ''' 変換(Double)
        ''' </summary>
        ''' <param name="value">値</param>
        ''' <returns>変換後の値</returns>
        Public Shared Function DBToDouble(ByVal value As Object) As Double

            If value Is Nothing OrElse TypeOf value Is DBNull Then
                Return 0
            Else
                Return CDbl(value)
            End If

        End Function
        ''' <summary>
        ''' 変換(Single)
        ''' </summary>
        ''' <param name="value">値</param>
        ''' <returns>変換後の値</returns>
        Public Shared Function DBToSingle(ByVal value As Object) As Single

           
            If value Is Nothing OrElse TypeOf value Is DBNull Then
                Return 0
            Else
                Return CType(value, Single)
            End If

        End Function
        ''' <summary>
        ''' 変換(Decimal)
        ''' </summary>
        ''' <param name="value">値</param>
        ''' <returns>変換後の値</returns>
        Public Shared Function DBToDecimal(ByVal value As Object) As Decimal

           
            If value Is Nothing OrElse TypeOf value Is DBNull Then
                Return 0
            Else
                Return CDec(value)
            End If

        End Function
        ''' <summary>
        ''' 変換(DBNull)
        ''' </summary>
        ''' <param name="value">値</param>
        ''' <returns>変換後の値</returns>
        Public Shared Function ToDBNull(ByVal value As String) As Object

            If value Is Nothing OrElse value = "" Then
                Return System.DBNull.Value
            Else
                Return value
            End If

        End Function
        ''' <summary>
        ''' 変換(DBNull)
        ''' </summary>
        ''' <param name="value">値</param>
        ''' <returns>変換後の値</returns>
        Public Shared Function ToDBNull(ByVal value As Date) As Object

            If value = Date.MinValue Then
                Return System.DBNull.Value
            Else
                Return value
            End If

        End Function
        ''' <summary>
        ''' 変換(DBNull)
        ''' </summary>
        ''' <param name="value">値</param>
        ''' <returns>変換後の値</returns>
        Public Shared Function ToDBNull(ByVal value As Integer) As Object

           
            If value = 0 Then
                Return System.DBNull.Value
            Else
                Return value
            End If

        End Function
        ''' <summary>
        ''' 変換(DBNull)
        ''' </summary>
        ''' <param name="value">値</param>
        ''' <returns>変換後の値</returns>
        Public Shared Function ToDBNull(ByVal value As Long) As Object
          
            If value = 0 Then
                Return System.DBNull.Value
            Else
                Return value
            End If

        End Function
        ''' <summary>
        ''' 変換(DBNull)
        ''' </summary>
        ''' <param name="value">値</param>
        ''' <returns>変換後の値</returns>
        Public Shared Function ToDBNull(ByVal value As Object) As Object

            If value Is Nothing Then
                Return System.DBNull.Value
            Else
                Return value
            End If

        End Function
        Public Shared Function EditDate(ByVal vDate As DateTime, ByVal Format As String) As String
            Try
                If vDate = Nothing OrElse vDate = DateTime.MinValue Then
                    Return ""
                Else
                    Return vDate.ToString(Format)
                End If
            Catch ex As Exception
                Return ""
            End Try
        End Function
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        '''   CSV文字列に変換する
        ''' </summary>
        ''' <param name="value">変換対象文字列</param>
        ''' <history>
        ''' 	[馬]	2005/03/22	Ridoc連携の文書名禁則文字対応
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Shared Function ToCSV(ByVal value As String) As String
            If value Is Nothing Then Return ""
            If value.IndexOf("""") > -1 Then
                value = value.Replace("""", """""")
            End If
            If value.IndexOf(vbCrLf) > -1 Then
                value = value.Replace(vbCrLf, " ")
            End If
            If value.IndexOf(","c) > -1 OrElse value.IndexOf(vbCrLf) <> -1 Then
                value = """" & value & """"
            End If
            Return value
        End Function
        Public Shared Function ToCSV2(ByVal value As String) As String
            If value Is Nothing Then Return ""
            If value.IndexOf("""") > -1 Then
                value = value.Replace("""", """""")
            End If
            If value.IndexOf(vbCrLf) > -1 Then
                value = value.Replace(vbCrLf, " ")
            End If
            If value.IndexOf(","c) > -1 OrElse value.IndexOf(vbCrLf) > -1 OrElse value.IndexOf("""") > -1 Then
                value = """" & value & """"
            End If
            Return value
        End Function

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        '''   SQL文字列に変換する
        ''' </summary>
        ''' <param name="rstrSQL">変換対象文字列</param>
        ''' <returns></returns>
        ''' -----------------------------------------------------------------------------
        Public Shared Function Quot(ByVal rstrSQL As String) As String
            Try
                If rstrSQL = Nothing Then
                    Return "''"
                End If
                '「'」があれば「''」に差替
                Return "'" & rstrSQL.Replace("'", "''") & "'"
            Catch e As Exception
                Return rstrSQL
            End Try
        End Function
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' ファイルパスの禁則文字を全角文字に変換する
        ''' 禁則文字は『\/:*?"＜＞|』及び文字列先頭と最後の「.」になります。
        ''' </summary>
        ''' <param name="strPath">変換する文字列</param>
        ''' <returns></returns>
        ''' -----------------------------------------------------------------------------
        Public Shared Function EncodePath(ByVal strPath As String) As String
            Try
                Dim reg As New System.Text.RegularExpressions.Regex("[\\\/\:\*\?\""\<\>\|]|(?<=.+)\.$|^\.")
                Dim strRet As String = reg.Replace(strPath, AddressOf CapText)

                Return strRet
            Catch ex As Exception
                Return ""
            End Try
        End Function
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        '''　正規表現と一致する対象が見つかるたびに呼び出されるデリゲート
        ''' </summary>
        ''' <param name="m">正規表現と一致する対象</param>
        ''' <returns>全角に変換した文字列を返す</returns>
        ''' -----------------------------------------------------------------------------
        Private Shared Function CapText(ByVal m As System.Text.RegularExpressions.Match) As String
            Dim x As String = m.ToString()
            If x = "\" Then Return "￥"
            Return StrConv(x, VbStrConv.Wide)
        End Function
        Public Shared Function GetStringByteCount(ByVal buf As String) As Integer
            If buf = Nothing OrElse buf = "" Then Return 0
            Dim Count As Integer = System.Text.Encoding.GetEncoding("shift-jis").GetByteCount(buf)
            Return Count
        End Function
        Public Shared Function CutStringbyByte(ByVal buf As String, ByVal MaxLength As Integer) As String
            Dim Length As Integer = GetStringByteCount(buf)
            If Length <= MaxLength Then
                Return buf
            End If
            Dim bts() As Byte = System.Text.Encoding.GetEncoding("shift-jis").GetBytes(buf)
            Dim cutstr As String = System.Text.Encoding.GetEncoding("shift-jis").GetString(bts, 0, MaxLength)
            Return cutstr
        End Function

        Public Shared Function BinaryToString(ByVal Data() As Byte) As String
            Dim sb As New System.Text.StringBuilder
            sb.Append("0x")
            For Each bt As Byte In Data
                sb.Append(Right("00" & Hex(bt), 2))
            Next
            Return sb.ToString
        End Function
#End Region
#Region "データのシリアル変換関連"
        ''' <summary>
        ''' Objectをシリアル化して、Base64文字列に変換する
        ''' [ObjectData]シリアル化可能のObject（Serializable()属性付く、およびISerializableの
        ''' </summary>
        ''' <param name="ObjectData">
        '''   シリアル化対象(シリアル化可能のObject（Serializable() 属性付く、およびISerializableの)
        '''</param>
        ''' <returns>変換後のBase64文字列を戻す</returns>
        Public Shared Function ObjectToString(ByVal objectData As Object) As String
            Try
                Dim strSerializ As String = ""
                Dim Formater As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
                Dim Stream As New System.IO.MemoryStream
                Formater.Serialize(Stream, objectData)
                Dim bts() As Byte
                bts = Stream.ToArray()
                strSerializ = System.Convert.ToBase64String(bts)
                Stream.Close()
                Return strSerializ
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        '''======================[StringToObject機能説明]==========================================
        '''==　Objectの逆シリアル化
        '''==シリアル化された文字列をObjectに還元する
        '''===================================================================
        ''' <summary>
        ''' Objectの逆シリアル化
        ''' </summary>
        ''' <param name="SerializString">
        '''   シリアル化対象(シリアル化可能のObject（Serializable()属性付く、およびISerializableの)
        '''</param>
        ''' <returns>シリアル化された文字列をObjectに還元して返す</returns>
        Public Shared Function StringToObject(ByVal serializString As String) As Object
            Try
                Dim ObjReturn As Object
                Dim Formater As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
                Dim Stream As New System.IO.MemoryStream
                Dim bts() As Byte
                bts = System.Convert.FromBase64String(serializString)
                Stream.Write(bts, 0, bts.Length)
                Stream.Position = 0
                ObjReturn = Formater.Deserialize(Stream)
                Stream.Close()
                Return ObjReturn
            Catch ex As Exception
                Throw ex
            End Try
        End Function

#End Region
    End Class
End Namespace
