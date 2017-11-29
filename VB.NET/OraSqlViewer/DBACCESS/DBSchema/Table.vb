Imports utility = SQLViewer.DBAccess.Common.ToolUtility
Imports SQLViewer.DBAccess.DataBase
Imports Oracle.DataAccess.Client
Imports System.Collections.Generic

Namespace DBSchema
    Public Class Table
        Implements iSqlObject
        Private mUser As String = ""
        Private mobjName As String = ""
        Private mOwner As String = ""
        Private mComment As String = ""
        Public Sub New(ByVal user As String, ByVal row As DataRow)
            mUser = user
            mobjName = utility.DBToString(row.Item("TABLE_NAME"))
            mOwner = utility.DBToString(row.Item("OWNER"))
        End Sub

        Public Function GetColumns() As DataTable
            Dim dba As DataBase.OraSqlServer = Nothing
            Dim cmd As OracleCommand = Nothing
            Try
                dba = New DataBase.OraSqlServer()
                cmd = dba.CreateCommand()
                cmd.CommandText = My.Resources.GetColumns
                cmd.Parameters.Add(":OWNER", Me.mOwner)
                cmd.Parameters.Add(":TABLENAME", Me.mobjName)
                Dim dtt As DataTable = dba.SelectSql(cmd, "COLUMNS")
                cmd.CommandText = My.Resources.GetIndexes
                Dim dttIndex As DataTable = dba.SelectSql(cmd, "index")
                Return MergeTableColumn(dtt, dttIndex)

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

        Private Function MergeTableColumn(ByVal dttColumn As DataTable, ByVal dttIndex As DataTable) As DataTable
            Dim retTable As DataTable = dttColumn.Copy
            Dim IndexColumns As List(Of String) = Nothing
            Dim Indexes As New Dictionary(Of String, IEnumerable)
            For Each row As DataRow In dttIndex.Rows
                Dim indexName As String = utility.DBToString(row.Item("INDEX_NAME"))
                If Indexes.ContainsKey(indexName) = False Then
                    IndexColumns = New List(Of String)()
                    Indexes.Add(indexName, IndexColumns)
                End If
                Dim ColName As String = utility.DBToString(row.Item("COLUMN_NAME"))
                IndexColumns.Add(ColName)
            Next
            Dim index As Integer = 0
            For Each key As String In Indexes.Keys
                Dim columnName As String = ""
                If index = 0 Then
                    columnName = "PK"
                Else
                    columnName = "IX" & index
                End If
                Dim column As DataColumn = retTable.Columns.Add(columnName, GetType(String))

                For Each colName As String In CType(Indexes.Item(key), List(Of String))
                    Dim rows() As DataRow = retTable.Select("óÒñº=" & utility.Quot(colName))
                    If rows.Length > 0 Then
                        rows(0).Item(column) = "Åõ"
                    End If
                Next
                index += 1
            Next
            Return retTable
        End Function

        Public ReadOnly Property User() As String Implements SQLViewer.DBAccess.DBSchema.iSqlObject.User
            Get
                Return mUser
            End Get
        End Property

        Public ReadOnly Property ObjName() As String Implements SQLViewer.DBAccess.DBSchema.iSqlObject.ObjName
            Get
                Return mobjName
            End Get
        End Property

        Public ReadOnly Property Owner() As String Implements SQLViewer.DBAccess.DBSchema.iSqlObject.Owner
            Get
                Return mOwner
            End Get
        End Property

        Public Function GetFullName() As String Implements SQLViewer.DBAccess.DBSchema.iSqlObject.GetFullName
            Return String.Format("{0}.{1}", Owner, mobjName)
        End Function

        Public ReadOnly Property ObjType() As SQLViewer.DBAccess.DBSchema.SqlObjectType Implements SQLViewer.DBAccess.DBSchema.iSqlObject.ObjType
            Get
                Return SqlObjectType.Table
            End Get
        End Property
        Public Function ChangeObjname(ByVal newName As String) As Boolean Implements SQLViewer.DBAccess.DBSchema.iSqlObject.ChangeObjname
            Return False
        End Function


        Public Function GetDatas() As DataTable
            Dim dbs As DataBase.OraSqlServer = Nothing
            Dim strSql As String = ""
            Try
                strSql &= "Select  * from " & Me.GetFullName
                strSql &= " WHERE ROWNUM<=1000"
                dbs = New DataBase.OraSqlServer()
                Dim dtt As DataTable = dbs.SelectSql(strSql, Me.ObjName)
                Return dtt
            Catch ex As Exception
                Throw ex
            Finally
                If Not dbs Is Nothing Then
                    dbs.Close()
                End If
            End Try

        End Function


        Public Function GetSelectCode() As String
            Dim columns As DataTable = Me.GetColumns
            Dim sbSql As New System.Text.StringBuilder
            sbSql.AppendLine("SELECT")
            Dim i As Integer = 0
            For Each row As DataRow In columns.Rows
                Dim column As String = utility.DBToString(row.Item("óÒñº"))
                If i > 0 Then
                    sbSql.Append(",")
                End If
                sbSql.AppendLine(column)
                i += 1
            Next
            sbSql.AppendLine("FROM")
            sbSql.AppendLine(Me.GetFullName())
            Return sbSql.ToString()
        End Function

        Public Function GetDDLCode() As String
            Dim cmd As Oracle.DataAccess.Client.OracleCommand = Nothing
            Dim dba As DataBase.OraSqlServer = Nothing

            Try
                dba = New OraSqlServer()
                cmd = dba.CreateCommand()
                cmd.CommandText = My.Resources.GetDDL
                cmd.Parameters.Add(":OBJTYPE", "TABLE")
                cmd.Parameters.Add(":OBJNAME", Me.ObjName)
                cmd.Parameters.Add(":SCHEMA", Me.mUser)
                Dim dtt As DataTable = dba.SelectSql(cmd, "TABLEDDL")
                Dim code As New System.Text.StringBuilder()
                Dim row As DataRow = Nothing
                Dim Dbs(dtt.Rows.Count - 1) As String
                Dim i As Integer = 0
                For Each row In dtt.Rows
                    code.Append(utility.DBToString(row.Item(0)))
                Next
                Return code.ToString
            Catch ex As Exception
                Throw
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
        Public ReadOnly Property Comment() As String Implements SQLViewer.DBAccess.DBSchema.iSqlObject.Comment
            Get
                Return mComment
            End Get
        End Property

        Public Sub UpdateComment(ByVal newComment As String) Implements SQLViewer.DBAccess.DBSchema.iSqlObject.UpdateComment
            mComment = newComment
        End Sub
    End Class
End Namespace
