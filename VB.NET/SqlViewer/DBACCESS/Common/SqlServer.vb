
Option Compare Binary
Option Explicit On 
Option Strict On
Imports System.Data
Imports System.Data.SqlClient
Imports Env = SQLViewer.DBAccess.Common.Enviroment
Imports Utility = SQLViewer.DBAccess.Common.ToolUtility
Namespace DataBase
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' データアクセスを補助します。
    ''' </summary>
    ''' -----------------------------------------------------------------------------
    Public Class SqlServer
        Private connectString As String = ""
        Protected Shared sqlConnection As System.Data.SqlClient.SqlConnection
        Protected tran As System.Data.SqlClient.SqlTransaction

        Public Sub New()
            Try
                If sqlConnection Is Nothing Then
                    Instance()
                End If
                If sqlConnection.State <> ConnectionState.Open Then
                    sqlConnection.Open()
                End If
            Catch ex As Exception
                sqlConnection = Nothing
                Throw ex
            End Try
        End Sub
        Public Sub New(ByVal strConnectString As String)
            Try
                Instance(strConnectString)
                If sqlConnection.State <> ConnectionState.Open Then
                    sqlConnection.Open()
                End If
            Catch ex As Exception
                sqlConnection = Nothing
                Throw ex
            End Try
        End Sub
        Private Sub Instance()
            If sqlConnection Is Nothing Then
                connectString = Env.ConnectString
                sqlConnection = New SqlConnection()
                sqlConnection.ConnectionString = connectString
            End If
        End Sub
        Private Sub Instance(ByVal ConnectString As String)
            If sqlConnection Is Nothing Then
                ConnectString = ConnectString
                sqlConnection = New SqlConnection()
                sqlConnection.ConnectionString = ConnectString
            Else
                sqlConnection.Close()
                ConnectString = ConnectString
                sqlConnection.ConnectionString = ConnectString
            End If
        End Sub
        ''' <summary>
        ''' データベーストランザクションを開始します。
        ''' </summary>
        Public Sub BeginTransaction()
            If sqlConnection.State <> ConnectionState.Open Then
                sqlConnection.Open()
            End If
            tran = sqlConnection.BeginTransaction()
        End Sub
        ''' <summary>
        ''' データベーストランザクションをコミットします。
        ''' </summary>
        Public Sub Commit()
            If Not tran Is Nothing Then
                tran.Commit()
                sqlConnection.Close()
                tran.Dispose()
                tran = Nothing
            End If
        End Sub
        ''' <summary>
        ''' データベーストランザクションをロールバックします。
        ''' </summary>
        Public Sub Rollback()
            ' Nothingチェック
            If Not tran Is Nothing Then
                tran.Rollback()
                sqlConnection.Close()
                tran.Dispose()
                tran = Nothing
            End If
        End Sub
        Public Sub Close()
            If (Not sqlConnection Is Nothing) AndAlso (sqlConnection.State <> ConnectionState.Closed) Then
                sqlConnection.Close()
            End If
        End Sub
        ''' <summary>
        ''' SQL　Select検索を実行しDataSetを返します。
        ''' </summary>
        ''' <param name="sql">SQL文</param>
        ''' <returns>データセット</returns>
        Public Function SelectSql(ByVal sql As String) As System.Data.DataSet
            Dim command As SqlCommand = Nothing
            Dim adapter As SqlDataAdapter = Nothing
            Try
                If sqlConnection.State <> ConnectionState.Open Then
                    sqlConnection.Open()
                End If
                command = New SqlCommand(sql, sqlConnection)
                If Not Me.tran Is Nothing Then
                    command.Transaction = tran
                End If
                command.CommandTimeout = Env.CommandTimeout
                adapter = New SqlDataAdapter(command)
                Dim dts As DataSet = New DataSet()
                adapter.Fill(dts, "$QueryTable")
                Try
                    adapter.FillSchema(dts, SchemaType.Mapped, "$QueryTable")
                Catch
                End Try
                Return dts
            Catch ex As Exception
                Throw ex
            Finally
                If command IsNot Nothing Then
                    command.Dispose()
                End If
                If adapter IsNot Nothing Then
                    adapter.Dispose()
                End If
            End Try
        End Function

        ''' <summary>
        ''' SQL　Select検索を実行しDataTableを返します。
        ''' </summary>
        ''' <param name="sql">SQL文</param>
        ''' <returns>データテープル</returns>
        Public Function SelectSql(ByVal sql As String, ByVal TableName As String) As System.Data.DataTable
            Dim command As SqlCommand = Nothing
            Dim adapter As SqlDataAdapter = Nothing
            Try
                If sqlConnection.State <> ConnectionState.Open Then
                    sqlConnection.Open()
                End If
                command = New SqlCommand(sql, sqlConnection)
                If Not Me.tran Is Nothing Then
                    command.Transaction = tran
                End If
                command.CommandTimeout = Env.CommandTimeout
                adapter = New SqlDataAdapter(command)
                Dim dts As New DataSet
                adapter.Fill(dts, TableName)
                Try
                    adapter.FillSchema(dts, SchemaType.Mapped, TableName)
                Catch
                End Try
                Return dts.Tables(0)
            Finally
                If command IsNot Nothing Then
                    command.Dispose()
                End If
                If adapter IsNot Nothing Then
                    adapter.Dispose()
                End If
            End Try
        End Function
        ''' <summary>
        ''' SQL　Select検索を実行しDataTableを返します。
        ''' </summary>
        ''' <param name="sql">SQL文</param>
        ''' <returns>データテープル</returns>
        Public Function SelectSql(ByVal sql As String, ByVal TableName As String, ByVal startRecord As Integer, ByVal MaxRecode As Integer) As System.Data.DataTable
            Dim command As SqlCommand = Nothing
            Dim adapter As SqlDataAdapter = Nothing
            Try
                If sqlConnection.State <> ConnectionState.Open Then
                    sqlConnection.Open()
                End If
                command = New SqlCommand(sql, sqlConnection)
                If Not Me.tran Is Nothing Then
                    command.Transaction = tran
                End If
                command.CommandTimeout = Env.CommandTimeout
                adapter = New SqlDataAdapter(command)
                Dim dts As New DataSet()
                adapter.Fill(dts, startRecord, MaxRecode, TableName)
                Try
                    adapter.FillSchema(dts, SchemaType.Mapped, TableName)
                Catch
                End Try
                Return dts.Tables(TableName)
            Catch ex As Exception
                Throw ex
            Finally
                If command IsNot Nothing Then
                    command.Dispose()
                End If
                If adapter IsNot Nothing Then
                    adapter.Dispose()
                End If
            End Try
        End Function
        ''' <summary>
        ''' SQL　Select検索を実行しDataTableを返します。
        ''' </summary>
        ''' <param name="sql">SQL文</param>
        ''' <returns>データテープル</returns>
        Public Function SelectSql(ByVal sql As String, ByVal TableName As String, ByVal Params() As SqlParameter) As System.Data.DataSet
            Dim command As SqlCommand = Nothing
            Dim adapter As SqlDataAdapter = Nothing
            Try
                If sqlConnection.State <> ConnectionState.Open Then
                    sqlConnection.Open()
                End If
                command = New SqlCommand(sql, sqlConnection)
                If Not Me.tran Is Nothing Then
                    command.Transaction = tran
                End If

                If Not Params Is Nothing AndAlso Params.Length > 0 Then
                    Dim param As SqlParameter = Nothing
                    For Each param In Params
                        If command.Parameters.Contains(param.ParameterName) = False Then
                            command.Parameters.Add(param)
                        End If
                    Next param
                End If
                command.CommandTimeout = Env.CommandTimeout
                adapter = New SqlDataAdapter(command)
                Dim dts As New DataSet()
                adapter.Fill(dts, TableName)
                Try
                    adapter.FillSchema(dts, SchemaType.Mapped, TableName)
                Catch
                End Try
                Return dts
            Catch ex As Exception
                Throw ex
            Finally
                If command IsNot Nothing Then
                    command.Parameters.Clear()
                    command.Dispose()
                End If
                If adapter IsNot Nothing Then
                    adapter.Dispose()
                End If
            End Try
        End Function


        Public Function ExecuteSqlCommand(ByVal Sql As String) As Integer
            Dim command As SqlCommand = Nothing
            Try

                If sqlConnection.State <> ConnectionState.Open Then
                    sqlConnection.Open()
                End If
                command = New SqlCommand(Sql, sqlConnection)
                command.CommandTimeout = Env.CommandTimeout
                If Not Me.tran Is Nothing Then
                    command.Transaction = tran
                End If

                command.ExecuteNonQuery()
            Catch ex As Exception
                Throw ex
            Finally
                If command IsNot Nothing Then
                    command.Dispose()
                End If
            End Try
        End Function

        Public Function ExecuteSqlCommand(ByVal Sql As String, ByVal CommandTimeOut As Integer) As Integer
            Dim command As SqlCommand = Nothing
            Try
                If sqlConnection.State <> ConnectionState.Open Then
                    sqlConnection.Open()
                End If
                command = New SqlCommand(Sql, sqlConnection)
                command.CommandTimeout = CommandTimeOut
                If Not Me.tran Is Nothing Then
                    command.Transaction = tran
                End If

                Return command.ExecuteNonQuery()
            Catch ex As Exception
                Throw ex
            Finally
                If command IsNot Nothing Then
                    command.Dispose()
                End If
            End Try
        End Function

        Public Function ExecuteSqlCommand(ByVal Sql As String, ByVal params As System.Data.SqlClient.SqlParameter()) As Integer
            Dim command As SqlCommand = Nothing
            Try
                If sqlConnection.State <> ConnectionState.Open Then
                    sqlConnection.Open()
                End If
                command = New SqlCommand(Sql, sqlConnection)
                command.CommandTimeout = Env.CommandTimeout
                If Not Me.tran Is Nothing Then
                    command.Transaction = tran
                End If
                If Not params Is Nothing AndAlso params.Length > 0 Then
                    Dim param As SqlParameter
                    For Each param In params
                        If command.Parameters.Contains(param.ParameterName) = False Then
                            command.Parameters.Add(param)
                        End If
                    Next param
                End If
                Return command.ExecuteNonQuery()
            Catch ex As Exception
                Throw ex
            Finally
                If command IsNot Nothing Then
                    command.Parameters.Clear()
                    command.Dispose()
                End If
            End Try
        End Function

        Public Function GetSchema(ByVal Sql As String, ByVal TableName As String) As System.Data.DataTable
            Dim command As SqlCommand = Nothing
            Dim adapter As SqlDataAdapter = Nothing
            Try
                If sqlConnection.State <> ConnectionState.Open Then
                    sqlConnection.Open()
                End If
                command = New SqlCommand(Sql, sqlConnection)
                command.CommandTimeout = Env.CommandTimeout
                If Not Me.tran Is Nothing Then
                    command.Transaction = tran
                End If
                adapter = New SqlDataAdapter(command)
                Dim dtt As DataTable = New DataTable(TableName)
                adapter.FillSchema(dtt, SchemaType.Mapped)
                Return dtt
            Catch ex As Exception
                Throw ex
            Finally
                If command IsNot Nothing Then
                    command.Dispose()
                End If
                If adapter IsNot Nothing Then
                    adapter.Dispose()
                End If
            End Try
        End Function
        Public Function ExecuteReader(ByVal sql As String) As System.Data.SqlClient.SqlDataReader
            Dim command As SqlCommand = Nothing
            Try
                If sqlConnection.State <> ConnectionState.Open Then
                    sqlConnection.Open()
                End If
                command = New SqlCommand(sql, sqlConnection)
                command.CommandTimeout = Env.CommandTimeout
                If Not Me.tran Is Nothing Then
                    command.Transaction = tran
                End If
                Dim rd As SqlDataReader = command.ExecuteReader()
                Return rd
            Catch ex As Exception
                Throw ex
            Finally
                If command IsNot Nothing Then
                    command.Dispose()
                End If
            End Try
        End Function
        Public Function ExecuteReader(ByVal sql As String, ByVal CommandBehavior As CommandBehavior) As System.Data.SqlClient.SqlDataReader
            Dim command As SqlCommand = Nothing
            Try
                If sqlConnection.State <> ConnectionState.Open Then
                    sqlConnection.Open()
                End If
                command = New SqlCommand(sql, sqlConnection)
                command.CommandTimeout = Env.CommandTimeout
                If Not Me.tran Is Nothing Then
                    command.Transaction = tran
                End If
                Dim rd As SqlDataReader = command.ExecuteReader(CommandBehavior)
                Return rd
            Catch ex As Exception
                Throw ex
            Finally
                If command IsNot Nothing Then
                    command.Dispose()
                End If
            End Try
        End Function

        ''' <summary>
        ''' 直前のインサートの際に振られたIDを返します。
        ''' </summary>
        ''' <returns>ID</returns>
        Public Function GetIdentityID() As Long
            Dim Reader As SqlDataReader = Nothing
            Try
                Dim strSql As String = "SELECT @@IDENTITY AS ID"
                Reader = ExecuteReader(strSql, CommandBehavior.SingleResult)
                Dim ID As Long = 0
                If Reader.Read Then
                    ID = Utility.DBToLong(Reader.GetValue(0))
                End If
                Return ID
            Catch ex As Exception
                Return 0
            Finally
                If Not Reader Is Nothing AndAlso Reader.IsClosed = False Then
                    Reader.Close()
                    Reader = Nothing
                End If
            End Try
        End Function


    End Class

End Namespace
