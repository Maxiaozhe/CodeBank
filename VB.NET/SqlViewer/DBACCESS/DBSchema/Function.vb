Imports utility = SQLViewer.DBAccess.Common.ToolUtility
Namespace DBSchema
    Public Class [Function]
        Implements iSqlObject
        Private mDatabase As String = ""
        Private mobjName As String = ""
        Private mOwner As String = ""
        Private mType As String = ""
        Private mComment As String = ""

        Public Sub New(ByVal db As String, ByVal row As DataRow)
            mDatabase = db
            mobjName = utility.DBToString(row.Item("OBJNAME"))
            mOwner = utility.DBToString(row.Item("OWNER"))
            mType = utility.DBToString(row.Item("TYPE"))
        End Sub

        Public ReadOnly Property DataBase() As String Implements SQLViewer.DBAccess.DBSchema.iSqlObject.DataBase
            Get
                Return mDatabase
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
        Public Function GetFnCode() As String
            Dim dba As New DataBase.SqlServer()
            Dim sb As New System.Text.StringBuilder()
            sb.Append(" USE " & DataBase & vbCrLf)
            sb.AppendFormat(" exec sp_helptext N'{0}' ", Me.GetFullName)
            Dim dtt As DataTable = dba.SelectSql(sb.ToString, "FNCODE")
            Dim code As New System.Text.StringBuilder()
            Dim row As DataRow = Nothing
            Dim Dbs(dtt.Rows.Count - 1) As String
            Dim i As Integer = 0
            For Each row In dtt.Rows
                code.Append(utility.DBToString(row.Item(0)))
            Next
            Return code.ToString
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
            Dim dba As New DataBase.SqlServer()
            Dim sb As New System.Text.StringBuilder()
            sb.AppendLine(" USE " & DataBase)
            sb.AppendLine(FnCode)
            dba.ExecuteSqlCommand(sb.ToString)
        End Sub
    End Class
End Namespace
