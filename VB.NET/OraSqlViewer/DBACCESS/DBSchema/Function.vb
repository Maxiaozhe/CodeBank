Imports utility = SQLViewer.DBAccess.Common.ToolUtility
Imports SQLViewer.DBAccess.DataBase
Imports Oracle.DataAccess.Client

Namespace DBSchema
    Public Class [Function]
        Implements iSqlObject
        Private mUser As String = ""
        Private mobjName As String = ""
        Private mOwner As String = ""
        Private mType As String = ""
        Private mComment As String = ""

        Public Sub New(ByVal db As String, ByVal row As DataRow)
            mUser = db
            mobjName = utility.DBToString(row.Item("OBJNAME"))
            mOwner = utility.DBToString(row.Item("OWNER"))
            mType = utility.DBToString(row.Item("TYPE"))
        End Sub

        Public ReadOnly Property User() As String Implements SQLViewer.DBAccess.DBSchema.iSqlObject.User
            Get
                Return mUser
            End Get
        End Property
        Public ReadOnly Property Type() As String
            Get
                Return mType
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
            Return String.Format("[{0}].[{1}]", Owner, mobjName)
        End Function
        Public ReadOnly Property ObjType() As SQLViewer.DBAccess.DBSchema.SqlObjectType Implements SQLViewer.DBAccess.DBSchema.iSqlObject.ObjType
            Get
                Return SqlObjectType.Function
            End Get
        End Property

        Public Function GetArguement() As DataTable
            Dim dba As DataBase.OraSqlServer = Nothing
            Dim cmd As OracleCommand = Nothing
            Try
                dba = New DataBase.OraSqlServer()
                cmd = dba.CreateCommand()
                cmd.CommandText = My.Resources.GetArguement
                cmd.Parameters.Add(":OWNER", Me.mOwner)
                cmd.Parameters.Add(":OBJECTNAME", Me.mobjName)
                Dim dtt As DataTable = dba.SelectSql(cmd, "Arguement")
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

        Public Function GetFnCode() As String
            Dim cmd As Oracle.DataAccess.Client.OracleCommand = Nothing
            Dim dba As DataBase.OraSqlServer = Nothing

            Try
                dba = New OraSqlServer()
                cmd = dba.CreateCommand()
                cmd.CommandText = My.Resources.GetDDL
                cmd.Parameters.Add(":OBJTYPE", "FUNCTION")
                cmd.Parameters.Add(":OBJNAME", Me.ObjName)
                cmd.Parameters.Add(":SCHEMA", Me.mUser)
                Dim dtt As DataTable = dba.SelectSql(cmd, "FNCODE")
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
        Public Function ChangeObjname(ByVal newName As String) As Boolean Implements SQLViewer.DBAccess.DBSchema.iSqlObject.ChangeObjname
            Return False
        End Function

        Public ReadOnly Property Comment() As String Implements SQLViewer.DBAccess.DBSchema.iSqlObject.Comment
            Get
                Return mComment
            End Get
        End Property

        Public Sub UpdateComment(ByVal newComment As String) Implements SQLViewer.DBAccess.DBSchema.iSqlObject.UpdateComment
            mComment = newComment
        End Sub
        Public Sub Update(ByVal FnCode As String)
            Dim dba As New DataBase.OraSqlServer()
            Dim sb As New System.Text.StringBuilder()
            sb.AppendLine(FnCode)
            dba.ExecuteOracleCommand(sb.ToString)
        End Sub
    End Class
End Namespace
