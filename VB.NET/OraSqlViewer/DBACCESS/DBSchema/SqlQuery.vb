Imports System.Text.RegularExpressions
Imports System.Collections.Generic
Imports Oracle.DataAccess.Client

Public Class SqlQuery
    Implements DBSchema.iSqlObject
    Private mUser As String = ""
    Private mobjName As String = ""
    Private mOwner As String = ""
    Private mComment As String = ""
    Private mSql As String = ""
    Private _getParameterHandler As GetParameter
    Private _Parameters As List(Of DBParameter) = Nothing
    Private _currentDba As DataBase.OraSqlServer = Nothing

    Public Delegate Sub GetParameter(ByRef parameters As List(Of DBParameter))

    Public Property GetParameterHandler As GetParameter
        Get
            Return Me._getParameterHandler
        End Get
        Set(value As GetParameter)
            Me._getParameterHandler = value
        End Set
    End Property

    Public Function ChangeObjname(ByVal newName As String) As Boolean Implements SQLViewer.DBAccess.DBSchema.iSqlObject.ChangeObjname
        mobjName = newName
    End Function

    Public ReadOnly Property Comment() As String Implements SQLViewer.DBAccess.DBSchema.iSqlObject.Comment
        Get
            Return ""
        End Get
    End Property

    Public ReadOnly Property User() As String Implements SQLViewer.DBAccess.DBSchema.iSqlObject.User
        Get
            Return mUser
        End Get
    End Property

    Public Function GetFullName() As String Implements SQLViewer.DBAccess.DBSchema.iSqlObject.GetFullName
        Return mobjName
    End Function

    Public ReadOnly Property ObjName() As String Implements SQLViewer.DBAccess.DBSchema.iSqlObject.ObjName
        Get
            Return mobjName
        End Get
    End Property

    Public ReadOnly Property ObjType() As SQLViewer.DBAccess.DBSchema.SqlObjectType Implements SQLViewer.DBAccess.DBSchema.iSqlObject.ObjType
        Get
            Return DBSchema.SqlObjectType.SqlQuery
        End Get
    End Property

    Public ReadOnly Property Owner() As String Implements SQLViewer.DBAccess.DBSchema.iSqlObject.Owner
        Get
            Return ""
        End Get
    End Property
    Public Property SqlText() As String
        Get
            Return Me.mSql
        End Get
        Set(ByVal Value As String)
            mSql = Value
        End Set
    End Property
    Public Sub UpdateComment(ByVal newComment As String) Implements SQLViewer.DBAccess.DBSchema.iSqlObject.UpdateComment
        'doNothing
    End Sub
    Public Sub New(ByVal dbName As String, ByVal sqlText As String, ByVal queryName As String, ByVal handler As GetParameter)
        mUser = dbName
        mSql = sqlText
        Me.mobjName = queryName
        Me._getParameterHandler = handler
    End Sub
    Public Function ExecSql(ByVal Sql As String, ByRef ErrMessage As String) As DataSet
        Dim dba As DataBase.OraSqlServer = Nothing
        Dim result As DataSet = Nothing
        Try
            dba = New DataBase.OraSqlServer()
            Me._currentDba = dba
            Dim sb As New System.Text.StringBuilder()
            sb.AppendLine(Sql)
            dba.BeginTransaction()
            Dim cmd As OracleCommand = GetParameters(dba, Sql)
            If cmd Is Nothing Then
                result = dba.SelectSql(sb.ToString)
            Else
                cmd.CommandText = Sql
                result = dba.SelectSql(cmd)
            End If

            dba.Commit()
            Return result
        Catch ex As Oracle.DataAccess.Client.OracleException
            dba.Rollback()
            ErrMessage &= "エラー番号:" & ex.Number & vbCrLf
            ' ErrMessage &= "行数:" & ex.LineNumber & vbCrLf
            ErrMessage &= ex.Message
            Return Nothing
        Finally
            dba.Close()
            Me._currentDba = Nothing
            dba = Nothing
        End Try
    End Function
    ''' <summary>
    ''' DDLを実行する
    ''' </summary>
    ''' <param name="Sql"></param>
    ''' <param name="ErrMessage"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ExecDDL(ByVal Sql As String, ByRef ErrMessage As String) As Integer
        Dim dba As DataBase.OraSqlServer = Nothing
        Dim result As Integer = 0
        Try
            dba = New DataBase.OraSqlServer()
            Me._currentDba = dba
            dba.BeginTransaction()
            Dim cmd As OracleCommand = dba.CreateCommand()
            cmd.CommandText = Sql
            cmd.CommandType = CommandType.Text
            result = cmd.ExecuteNonQuery()
            dba.Commit()
            Return result
        Catch ex As Oracle.DataAccess.Client.OracleException
            dba.Rollback()
            ErrMessage &= "エラー番号:" & ex.Number & vbCrLf
            ErrMessage &= ex.Message
            Return Nothing
        Finally
            dba.Close()
            Me._currentDba = Nothing
            dba = Nothing
        End Try
    End Function

    Public Function ExecProcedureSql(ByVal Sql As String, ByRef ErrMessage As String) As DataSet
        Dim dba As DataBase.OraSqlServer = Nothing
        Dim result As DataSet = Nothing
        Try
            dba = New DataBase.OraSqlServer()
            Me._currentDba = dba
            Dim sb As New System.Text.StringBuilder()
            sb.AppendLine(Sql)
            dba.BeginTransaction()
            Dim cmd As OracleCommand = GetProcedureParameters(dba, Sql)
            If cmd Is Nothing Then
                result = dba.SelectSql(sb.ToString)
            Else
                dba.ExecuteOracleCommand(cmd)
                result = New DataSet
            End If

            Dim dttResult As DataTable = Nothing
            For Each param As OracleParameter In cmd.Parameters
                If Not (param.Direction = ParameterDirection.Output OrElse param.Direction = ParameterDirection.InputOutput) Then
                    Continue For
                End If
                If param.OracleDbType = OracleDbType.RefCursor Then
                    If (param.Value Is Nothing) OrElse (TypeOf param.Value Is DBNull) Then
                        Continue For
                    End If
                    dttResult = New DataTable(param.ParameterName)
                    Using reader As IDataReader = CType(param.Value, Oracle.DataAccess.Types.OracleRefCursor).GetDataReader()
                        If reader Is Nothing Then
                            Continue For
                        End If
                        dttResult.Load(reader)
                    End Using

                Else
                    dttResult = New DataTable(param.ParameterName)
                    dttResult.Columns.Add(param.ParameterName)
                    Dim newRow As DataRow = dttResult.NewRow()
                    newRow.Item(0) = param.Value
                    dttResult.Rows.Add(newRow)
                End If
                result.Tables.Add(dttResult)
            Next
            dba.Commit()
            Return result
        Catch ex As Oracle.DataAccess.Client.OracleException
            dba.Rollback()
            ErrMessage &= "エラー番号:" & ex.Number & vbCrLf
            ' ErrMessage &= "行数:" & ex.LineNumber & vbCrLf
            ErrMessage &= ex.Message
            Return Nothing
        Finally
            dba.Close()
            Me._currentDba = Nothing
            dba = Nothing
        End Try
    End Function

    Public Sub Cancel()
        Try
            If Me._currentDba Is Nothing Then
                Return
            End If
            Me._currentDba.Cancel()
        Catch ex As Exception

        End Try
    End Sub

    Private Function GetProcedureParameters(ByVal dba As DataBase.OraSqlServer, ByVal SqlTxt As String) As Oracle.DataAccess.Client.OracleCommand

        Dim schemas() As String = SqlTxt.Split("."c)
        Dim owner As String = ""
        Dim package As String = ""
        Dim procedure As String = ""
        If schemas.Length = 3 Then
            owner = schemas(0)
            package = schemas(1)
            procedure = schemas(2)

        ElseIf schemas.Length = 2 Then
            If IsPackage(dba, schemas(0)) Then
                package = schemas(0)
            Else
                owner = schemas(0)
            End If
            procedure = schemas(1)
        ElseIf schemas.Length = 1 Then
            owner = Me.User
            package = ""
            procedure = schemas(0)
        End If
        Dim lstParams As List(Of SqlArguement) = GetArguement(dba, owner, package, procedure)
        Dim sendParams As New List(Of DBParameter)
        For Each Arg As SqlArguement In lstParams
            If Arg.IOType = ParameterDirection.Input OrElse Arg.IOType = ParameterDirection.InputOutput Then
                Dim param As DBParameter = New DBParameter(Arg.GetFullName(), Arg.DataType)
                sendParams.Add(param)
            End If
        Next
        Me._Parameters = sendParams
        Me._getParameterHandler.Invoke(Me._Parameters)
        Dim cmd As OracleCommand = dba.CreateCommand()
        cmd.CommandText = SqlTxt
        cmd.CommandType = CommandType.StoredProcedure
        cmd.BindByName = True
        For Each arg As SqlArguement In lstParams
            Dim paramName As String = arg.GetFullName()
            Dim param As OracleParameter = cmd.Parameters.Add(paramName, arg.DataType, arg.IOType)
            If arg.IOType = ParameterDirection.Input OrElse arg.IOType = ParameterDirection.InputOutput Then
                Dim InParam As DBParameter = Me._Parameters.Find(
                    Function(paramter)
                        If paramter.Name = paramName Then
                            Return True
                        End If
                    End Function)
                If Not InParam Is Nothing Then
                    param.Value = InParam.GetDataValue()
                End If
            Else
                If param.OracleDbType = OracleDbType.Varchar2 OrElse param.OracleDbType = OracleDbType.NVarchar2 Then
                    param.Size = 4000
                End If
            End If
        Next

        Return cmd

    End Function


    Private Function GetParameters(ByVal dba As DataBase.OraSqlServer, ByVal sql As String) As Oracle.DataAccess.Client.OracleCommand
        Dim regex1 As New Regex("\/\*[\w\W]*?\*\/")
        Dim regex2 As New Regex("\:\w+")
        sql = regex1.Replace(sql, "")
        Dim matches As MatchCollection = regex2.Matches(sql)
        Dim parameters As New List(Of String)
        For Each mat As Match In matches
            If parameters.Contains(mat.Value.ToUpper()) = False Then
                parameters.Add(mat.Value.ToUpper())
            End If
        Next
        If parameters.Count = 0 Then
            Return Nothing
        End If
        If Me._getParameterHandler Is Nothing Then
            Return Nothing
        End If
        If Me._Parameters Is Nothing Then
            Me._Parameters = New List(Of DBParameter)
        End If
        Dim sendParams As New List(Of DBParameter)

        For Each name As String In parameters
            Dim param As DBParameter = New DBParameter(name.ToUpper(), OracleDbType.NVarchar2)
            If Me._Parameters.Exists(AddressOf param.Match) = False Then
                sendParams.Add(param)
            Else
                sendParams.Add(Me._Parameters.Find(AddressOf param.Match))
            End If
        Next
        Me._Parameters = sendParams
        Me._getParameterHandler.Invoke(Me._Parameters)
        Dim cmd As OracleCommand = dba.CreateCommand()
        cmd.CommandText = sql
        cmd.CommandType = CommandType.Text
        cmd.BindByName = True
        For Each param As DBParameter In Me._Parameters
            cmd.Parameters.Add(param.Name, param.Value)
        Next
        Return cmd
    End Function

    Private Function IsPackage(ByVal dba As DataBase.OraSqlServer, ByVal name As String) As Boolean
        Dim cmd As OracleCommand = Nothing
        Try
            cmd = dba.CreateCommand()
            cmd.CommandText = My.Resources.GetPackage
            cmd.Parameters.Add(":OWNER", Me.User)
            cmd.Parameters.Add(":OBJNAME", name)
            Dim objRet As Object = cmd.ExecuteScalar()
            If IsNumeric(objRet) AndAlso CInt(objRet) > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        Finally
            If Not cmd Is Nothing Then
                cmd.Dispose()
                cmd = Nothing
            End If
        End Try
    End Function
    Public Function GetArguement(ByVal dba As DataBase.OraSqlServer, ByVal owner As String, ByVal package As String, ByVal produce As String) As List(Of SqlArguement)
       Dim cmd As OracleCommand = Nothing
        Dim retList As New List(Of SqlArguement)
        Try
            cmd = dba.CreateCommand()
            cmd.CommandText = My.Resources.GetArguement2
            cmd.Parameters.Add(":OWNER", owner)
            cmd.Parameters.Add(":PACKAGENAME", package)
            cmd.Parameters.Add(":OBJECTNAME", produce)
            cmd.BindByName = True
            Dim dtt As DataTable = dba.SelectSql(cmd, "Arguement")
            For Each row As DataRow In dtt.Rows
                Dim Arg As New SqlArguement(Me.User, row)
                retList.Add(Arg)
            Next
            Return retList
        Catch ex As Exception
            Throw ex
        Finally
            If Not cmd Is Nothing Then
                cmd.Dispose()
                cmd = Nothing
            End If
            If Not dba Is Nothing Then
                dba.Close()
            End If
        End Try
    End Function
End Class

Public Class DBParameter
    Private _type As OracleDbType
    Private _value As String
    Private _ParamName As String
  
    Public Property Name As String
        Get
            Return Me._ParamName
        End Get
        Set(value As String)
            Me._ParamName = value
        End Set
    End Property

    Public Property Value As String
        Get
            Return Me._value
        End Get
        Set(value As String)
            Me._value = value
        End Set
    End Property

    Public Function GetDataValue() As Object
        If String.IsNullOrEmpty(CStr(Me._value)) Then
            Return DBNull.Value
        End If
        Select Case Me._type
            Case OracleDbType.Decimal, OracleDbType.Int16, OracleDbType.Int32, OracleDbType.Int64, OracleDbType.Long, OracleDbType.Double
                Return Convert.ToDecimal(Me._value)
            Case OracleDbType.Date
                Return CDate(Me._value)
            Case OracleDbType.NVarchar2, OracleDbType.Varchar2
                Return Convert.ToString(Me._value)
            Case Else
                Return Convert.ToString(Me._value)
        End Select
    End Function

    Public Property Type As String
        Get

            Select Case Me._type
                Case OracleDbType.Decimal, OracleDbType.Int16, OracleDbType.Int32, OracleDbType.Int64, OracleDbType.Long, OracleDbType.Double
                    Return "数字"
                Case OracleDbType.Date
                    Return "日付"
                Case OracleDbType.NVarchar2, OracleDbType.Varchar2
                    Return "文字"
                Case Else
                    Return "文字"
            End Select
        End Get
        Set(value As String)
            Select Case value.ToUpper
                Case "数字"
                    Me._type = OracleDbType.Decimal
                Case "日付"
                    Me._type = OracleDbType.Date
                Case "文字"
                    Me._type = OracleDbType.NVarchar2
                Case Else
                    Me._type = OracleDbType.NVarchar2
            End Select
        End Set
    End Property

    Public Function Match(ByVal obj As DBParameter) As Boolean
        If Me.Name = obj.Name Then
            Return True
        Else
            Return False
        End If
    End Function


    Public Sub New(ByVal name As String, ByVal type As OracleDbType)
        Me._ParamName = name
        Me._type = type
        Me._value = ""
    End Sub
    Public Sub New(ByVal name As String, ByVal type As OracleDbType, ByVal value As String)
        Me._ParamName = name
        Me._type = type
        Me._value = value
    End Sub
End Class