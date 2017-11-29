
Option Compare Binary
Option Explicit On 
Option Strict On
Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types
Imports Env = SQLViewer.DBAccess.Common.Enviroment
Imports Utility = SQLViewer.DBAccess.Common.ToolUtility
Namespace DataBase
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' データアクセスを補助します。
    ''' </summary>
    ''' -----------------------------------------------------------------------------
    Public Class OraSqlServer
        Private connectString As String = ""
        Protected Shared sqlConnection As OracleConnection
        Protected tran As OracleTransaction
        Protected currentCommand As OracleCommand = Nothing
        Private retryCount As Integer = 0
        Public Sub New()
            Try
                If sqlConnection Is Nothing Then
                    Instance()
                End If
                If sqlConnection.State <> ConnectionState.Open Then
                    sqlConnection.Open()
                End If
                AddHandler sqlConnection.InfoMessage, _
                    Sub(ender As Object, eventArgs As Oracle.DataAccess.Client.OracleInfoMessageEventArgs)
                        Dim number As Integer = eventArgs.Errors.Item(0).Number
                    End Sub
            Catch ex As Oracle.DataAccess.Client.OracleException
                sqlConnection = Nothing
                Throw ex
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
            Catch ex As Oracle.DataAccess.Client.OracleException
                sqlConnection = Nothing
                Throw ex
            Catch ex As Exception
                sqlConnection = Nothing
                Throw ex
            End Try
        End Sub
        Private Sub Instance()
            If sqlConnection Is Nothing Then
                connectString = Env.ConnectString
                sqlConnection = New OracleConnection()
                sqlConnection.ConnectionString = connectString
            End If
        End Sub

        

        Private Sub Instance(ByVal ConnectString As String)
            If sqlConnection Is Nothing Then
                ConnectString = ConnectString
                sqlConnection = New OracleConnection()
                sqlConnection.ConnectionString = ConnectString
            Else
                sqlConnection.Close()
                ConnectString = ConnectString
                sqlConnection.ConnectionString = ConnectString
            End If
        End Sub

        Public Function CreateCommand() As Oracle.DataAccess.Client.OracleCommand
            Dim cmd As OracleCommand = Nothing
            cmd = sqlConnection.CreateCommand()
            cmd.CommandTimeout = Env.CommandTimeout
            If Not tran Is Nothing Then
                cmd.Transaction = tran
            End If
            currentCommand = cmd
            AddHandler currentCommand.Disposed, _
                Sub(sender As Object, e As System.EventArgs)
                    currentCommand = Nothing
                End Sub
            Return cmd
        End Function

        Public Sub Cancel()
            If Me.currentCommand Is Nothing Then
                Return
            End If
            Me.currentCommand.Cancel()
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
            If Not tran Is Nothing AndAlso Not tran.Connection Is Nothing Then
                tran.Commit()
                sqlConnection.Close()
                tran.Dispose()
                tran = Nothing
            End If
        End Sub

        Public Function ResetConnection() As Boolean
            Try
                OracleConnection.ClearAllPools()
                sqlConnection.Dispose()
                sqlConnection = Nothing
                Instance()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' データベーストランザクションをロールバックします。
        ''' </summary>
        Public Sub Rollback()
            Try

                ' Nothingチェック
                If Not tran Is Nothing Then

                    tran.Rollback()
                    sqlConnection.Close()
                    tran.Dispose()
                    tran = Nothing
                End If
            Catch ex As Oracle.DataAccess.Client.OracleException
                If ex.Number = 3114 Then
                    ResetConnection()
                End If
            Catch ex As Exception
            End Try

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
            Dim command As OracleCommand = Nothing
            Dim adapter As OracleDataAdapter = Nothing
            Try
                If sqlConnection.State <> ConnectionState.Open Then
                    sqlConnection.Open()
                End If
                command = Me.CreateCommand()
                command.CommandText = sql
                adapter = New OracleDataAdapter(command)
                Dim dts As DataSet = New DataSet()
                adapter.Fill(dts, "$QueryTable")
                Try
                    adapter.FillSchema(dts, SchemaType.Mapped, "$QueryTable")
                Catch
                End Try
                retryCount = 0
                Return dts
            Catch ex As Oracle.DataAccess.Client.OracleException When ex.Number = 3114
                ResetConnection()
                Throw ex
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
            Dim command As OracleCommand = Nothing
            Dim adapter As OracleDataAdapter = Nothing
            Try
                If sqlConnection.State <> ConnectionState.Open Then
                    sqlConnection.Open()
                End If
                command = Me.CreateCommand()
                command.CommandText = sql
                adapter = New OracleDataAdapter(command)
                Dim dts As New DataSet
                adapter.Fill(dts, TableName)
                Try
                    adapter.FillSchema(dts, SchemaType.Mapped, TableName)
                Catch
                End Try
                retryCount = 0
                Return dts.Tables(0)
            Catch ex As Oracle.DataAccess.Client.OracleException When ex.Number = 3114
                ResetConnection()
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
        Public Function SelectSql(ByVal sql As String, ByVal TableName As String, ByVal startRecord As Integer, ByVal MaxRecode As Integer) As System.Data.DataTable
            Dim command As OracleCommand = Nothing
            Dim adapter As OracleDataAdapter = Nothing
            Try
                If sqlConnection.State <> ConnectionState.Open Then
                    sqlConnection.Open()
                End If
                command = Me.CreateCommand()
                command.CommandText = sql

                adapter = New OracleDataAdapter(command)
                Dim dts As New DataSet()
                adapter.Fill(dts, startRecord, MaxRecode, TableName)
                Try
                    adapter.FillSchema(dts, SchemaType.Mapped, TableName)
                Catch
                End Try
                retryCount = 0
                Return dts.Tables(TableName)
            Catch ex As Oracle.DataAccess.Client.OracleException When ex.Number = 3114
                ResetConnection()
                Throw ex
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
        Public Function SelectSql(ByVal sql As String, ByVal TableName As String, ByVal Params() As OracleParameter) As System.Data.DataSet
            Dim command As OracleCommand = Nothing
            Dim adapter As OracleDataAdapter = Nothing
            Try
                If sqlConnection.State <> ConnectionState.Open Then
                    sqlConnection.Open()
                End If
                command = Me.CreateCommand()
                command.CommandText = sql
                If Not Params Is Nothing AndAlso Params.Length > 0 Then
                    Dim param As OracleParameter = Nothing
                    For Each param In Params
                        If command.Parameters.Contains(param.ParameterName) = False Then
                            command.Parameters.Add(param)
                        End If
                    Next param
                End If
                command.CommandTimeout = Env.CommandTimeout
                adapter = New OracleDataAdapter(command)
                Dim dts As New DataSet()
                adapter.Fill(dts, TableName)
                Try
                    adapter.FillSchema(dts, SchemaType.Mapped, TableName)
                Catch
                End Try
                retryCount = 0
                Return dts
            Catch ex As Oracle.DataAccess.Client.OracleException When ex.Number = 3114
                ResetConnection()
                Throw ex
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
        ''' <summary>
        ''' SQL　Select検索を実行しDataTableを返します。
        ''' </summary>
        ''' <param name="command">SQL Command</param>
        ''' <returns>データテープル</returns>
        Public Function SelectSql(ByVal command As OracleCommand) As System.Data.DataSet
            Dim adapter As OracleDataAdapter = Nothing
            Try
                If sqlConnection.State <> ConnectionState.Open Then
                    sqlConnection.Open()
                End If
                command.CommandTimeout = Env.CommandTimeout
                adapter = New OracleDataAdapter(command)
                Dim dts As New DataSet()
                adapter.Fill(dts)
                Try
                    adapter.FillSchema(dts, SchemaType.Mapped)
                Catch
                End Try
                retryCount = 0
                Return dts
            Catch ex As Oracle.DataAccess.Client.OracleException When ex.Number = 3114
                ResetConnection()
                Throw ex
            Catch ex As Exception
                Throw ex
            Finally
                If adapter IsNot Nothing Then
                    adapter.Dispose()
                End If
            End Try
        End Function
        ''' <summary>
        ''' SQL　Select検索を実行しDataTableを返します。
        ''' </summary>
        ''' <param name="command">SQL Command</param>
        ''' <returns>データテープル</returns>
        Public Function SelectSql(ByVal command As OracleCommand, ByVal TableName As String) As System.Data.DataTable
            Dim adapter As OracleDataAdapter = Nothing
            Try
                If sqlConnection.State <> ConnectionState.Open Then
                    sqlConnection.Open()
                End If
                command.CommandTimeout = Env.CommandTimeout
                adapter = New OracleDataAdapter(command)
                Dim dts As New DataSet()
                adapter.Fill(dts)
                Try
                    adapter.FillSchema(dts, SchemaType.Mapped, TableName)
                Catch
                End Try
                retryCount = 0
                Return dts.Tables(0)
            Catch ex As Oracle.DataAccess.Client.OracleException When ex.Number = 3114
                ResetConnection()
                Throw ex
            Catch ex As Exception
                Throw ex
            Finally
                If adapter IsNot Nothing Then
                    adapter.Dispose()
                End If
            End Try
        End Function
        Public Function ExecuteOracleCommand(ByVal Sql As String) As Integer
            Dim command As OracleCommand = Nothing
            Try

                If sqlConnection.State <> ConnectionState.Open Then
                    sqlConnection.Open()
                End If
                command = Me.CreateCommand()
                command.CommandText = Sql
                Dim retCode As Integer = command.ExecuteNonQuery()
                retryCount = 0
                Return retCode
            Catch ex As Oracle.DataAccess.Client.OracleException When ex.Number = 3114
                ResetConnection()
                Throw ex
            Catch ex As Exception
                Throw ex
            Finally
                If command IsNot Nothing Then
                    command.Dispose()
                End If
            End Try
        End Function

        Public Function ExecuteOracleCommand(ByVal Sql As String, ByVal CommandTimeOut As Integer) As Integer
            Dim command As OracleCommand = Nothing
            Try
                If sqlConnection.State <> ConnectionState.Open Then
                    sqlConnection.Open()
                End If
                command = Me.CreateCommand()
                command.CommandText = Sql


                Dim retCode As Integer = command.ExecuteNonQuery()
                retryCount = 0
                Return retCode
            Catch ex As Oracle.DataAccess.Client.OracleException When ex.Number = 3114
                If ResetConnection() Then
                    retryCount += 1
                    If retryCount <= 3 Then
                        Return ExecuteOracleCommand(Sql, CommandTimeOut)
                    End If
                End If
                Throw ex
            Catch ex As Exception
                Throw ex
            Finally
                If command IsNot Nothing Then
                    command.Dispose()
                End If
            End Try
        End Function

        Public Function ExecuteOracleCommand(ByVal Sql As String, ByVal params As OracleParameter()) As Integer
            Dim command As OracleCommand = Nothing
            Try
                If sqlConnection.State <> ConnectionState.Open Then
                    sqlConnection.Open()
                End If
                command = Me.CreateCommand()
                command.CommandText = Sql

                If Not params Is Nothing AndAlso params.Length > 0 Then
                    Dim param As OracleParameter
                    For Each param In params
                        If command.Parameters.Contains(param.ParameterName) = False Then
                            command.Parameters.Add(param)
                        End If
                    Next param
                End If
                Dim retCode As Integer = command.ExecuteNonQuery()
                retryCount = 0
                Return retCode
            Catch ex As Oracle.DataAccess.Client.OracleException When ex.Number = 3114
                ResetConnection()
                Throw ex
            Catch ex As Exception
                Throw ex
            Finally
                If command IsNot Nothing Then
                    command.Parameters.Clear()
                    command.Dispose()
                End If
            End Try
        End Function
        Public Function ExecuteOracleCommand(ByVal command As OracleCommand) As Integer
            Try
                If sqlConnection.State <> ConnectionState.Open Then
                    sqlConnection.Open()
                End If
                Dim retCode As Integer = command.ExecuteNonQuery()
                retryCount = 0
                Return retCode
            Catch ex As Oracle.DataAccess.Client.OracleException When ex.Number = 3114
                ResetConnection
                Throw ex
            Catch ex As Exception
                Throw ex

            End Try
        End Function
        Public Function GetSchema(ByVal Sql As String, ByVal TableName As String) As System.Data.DataTable
            Dim command As OracleCommand = Nothing
            Dim adapter As OracleDataAdapter = Nothing
            Try
                If sqlConnection.State <> ConnectionState.Open Then
                    sqlConnection.Open()
                End If
                command = New OracleCommand(Sql, sqlConnection)
                command.CommandTimeout = Env.CommandTimeout
                If Not Me.tran Is Nothing Then
                    command.Transaction = tran
                End If
                adapter = New OracleDataAdapter(command)
                Dim dtt As DataTable = New DataTable(TableName)
                adapter.FillSchema(dtt, SchemaType.Mapped)
                retryCount = 0
                Return dtt
            Catch ex As Oracle.DataAccess.Client.OracleException When ex.Number = 3114
                ResetConnection()
                Throw ex
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
        Public Function ExecuteReader(ByVal sql As String) As OracleDataReader
            Dim command As OracleCommand = Nothing
            Try
                If sqlConnection.State <> ConnectionState.Open Then
                    sqlConnection.Open()
                End If
                command = Me.CreateCommand()
                command.CommandText = sql

                Dim rd As OracleDataReader = command.ExecuteReader()
                retryCount = 0
                Return rd
            Catch ex As Oracle.DataAccess.Client.OracleException When ex.Number = 3114
                ResetConnection()
                Throw ex
            Catch ex As Exception
                Throw ex
            Finally
                If command IsNot Nothing Then
                    command.Dispose()
                End If
            End Try
        End Function
        Public Function ExecuteReader(ByVal sql As String, ByVal CommandBehavior As CommandBehavior) As OracleDataReader
            Dim command As OracleCommand = Nothing
            Try
                If sqlConnection.State <> ConnectionState.Open Then
                    sqlConnection.Open()
                End If
                command = Me.CreateCommand()
                command.CommandText = sql

                Dim rd As OracleDataReader = command.ExecuteReader(CommandBehavior)
                retryCount = 0
                Return rd
            Catch ex As Oracle.DataAccess.Client.OracleException When ex.Number = 3114
                ResetConnection()
                Throw ex
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
            Dim Reader As OracleDataReader = Nothing
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

        Public Function GetDbSchemas(ByVal collectionType As DatabaseCollections) As DataTable
            Try
                If sqlConnection.State <> ConnectionState.Open Then
                    sqlConnection.Open()
                End If
                Dim result As DataTable = Nothing
                If collectionType = DatabaseCollections.all Then
                    result = sqlConnection.GetSchema()
                Else
                    result = sqlConnection.GetSchema(collectionType.ToString())
                End If
                retryCount = 0
                Return result
            Catch ex As Oracle.DataAccess.Client.OracleException When ex.Number = 3114
                ResetConnection()
                Throw ex
            Catch ex As Exception
                Throw ex
            Finally

            End Try
        End Function

    End Class


    Public Enum DatabaseCollections
        all = -1
        MetaDataCollections = 0
        DataSourceInformation = 1
        DataTypes = 2
        Restrictions = 3
        ReservedWords = 4
        Users = 5
        Tables = 6
        Columns = 7
        Views = 8
        Synonyms = 9
        Sequences = 10
        Functions = 11
        Procedures = 12
        Packages = 13
        PackageBodies = 14
        IndexColumns = 15
        Indexes = 16
        ProcedureParameters = 17
        Arguments = 18
        UniqueKeys = 19
        PrimaryKeys = 20
        ForeignKeys = 21
        ForeignKeyColumns = 22
        JavaClasses = 23
        XMLSchemas = 24
    End Enum
End Namespace
