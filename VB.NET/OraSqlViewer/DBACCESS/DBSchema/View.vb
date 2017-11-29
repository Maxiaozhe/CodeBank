Imports utility = SQLViewer.DBAccess.Common.ToolUtility
Imports SQLViewer.DBAccess.DataBase
Imports Oracle.DataAccess.Client

Namespace DBSchema
    Public Class View
        Implements iSqlObject
        Private mUser As String = ""
        Private mObjName As String = ""
        Private mOwner As String = ""
        Private mComment As String = ""
        Public Sub New(ByVal db As String, ByVal row As DataRow)
            mUser = db
            mObjName = utility.DBToString(row.Item("VIEW_NAME"))
            mOwner = utility.DBToString(row.Item("OWNER"))
        End Sub

        Public ReadOnly Property User() As String Implements SQLViewer.DBAccess.DBSchema.iSqlObject.User
            Get
                Return mUser
            End Get
        End Property

        Public ReadOnly Property ObjName() As String Implements SQLViewer.DBAccess.DBSchema.iSqlObject.ObjName
            Get
                Return mObjName
            End Get
        End Property

        Public ReadOnly Property Owner() As String Implements SQLViewer.DBAccess.DBSchema.iSqlObject.Owner
            Get
                Return mOwner
            End Get
        End Property

        Public ReadOnly Property ObjType() As SQLViewer.DBAccess.DBSchema.SqlObjectType Implements SQLViewer.DBAccess.DBSchema.iSqlObject.ObjType
            Get
                Return SqlObjectType.View
            End Get
        End Property

        Public Function GetFullName() As String Implements SQLViewer.DBAccess.DBSchema.iSqlObject.GetFullName
            Return String.Format("""{0}"".""{1}""", Owner, mObjName)
        End Function
        Public Function GetViewCode() As String
            Dim cmd As Oracle.DataAccess.Client.OracleCommand = Nothing
            Dim dba As DataBase.OraSqlServer = Nothing

            Try
                dba = New OraSqlServer()
                cmd = dba.CreateCommand()
                cmd.CommandText = My.Resources.GetDDL
                cmd.Parameters.Add(":OBJTYPE", "VIEW")
                cmd.Parameters.Add(":OBJNAME", Me.ObjName)
                cmd.Parameters.Add(":SCHEMA", Me.mUser)
                Dim dtt As DataTable = dba.SelectSql(cmd, "VIEW")
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
        Public Function GetOpenSql() As String
            Return "Select * From " & Me.GetFullName & " Where rownum<=1000"
        End Function
        Public Function ChangeObjname(ByVal newName As String) As Boolean Implements SQLViewer.DBAccess.DBSchema.iSqlObject.ChangeObjname
            Return False
        End Function
        Public ReadOnly Property Comment() As String Implements SQLViewer.DBAccess.DBSchema.iSqlObject.Comment
            Get
                Return mComment
            End Get
        End Property

        Public Function GetColumns() As DataTable
            Dim dba As DataBase.OraSqlServer = Nothing
            Dim cmd As OracleCommand = Nothing
            Try
                dba = New DataBase.OraSqlServer()
                cmd = dba.CreateCommand()
                cmd.CommandText = My.Resources.GetColumns
                cmd.Parameters.Add(":OWNER", Me.mOwner)
                cmd.Parameters.Add(":TABLENAME", Me.mObjName)
                Dim dtt As DataTable = dba.SelectSql(cmd, "COLUMNS")
                Return dtt

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

        Public Function GetSelectCode() As String
            Dim columns As DataTable = Me.GetColumns
            Dim sbSql As New System.Text.StringBuilder
            sbSql.AppendLine("SELECT")
            Dim i As Integer = 0
            For Each row As DataRow In columns.Rows
                Dim column As String = utility.DBToString(row.Item("—ñ–¼"))
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

        Public Sub UpdateComment(ByVal newComment As String) Implements SQLViewer.DBAccess.DBSchema.iSqlObject.UpdateComment
            mComment = newComment
        End Sub
    End Class
End Namespace
