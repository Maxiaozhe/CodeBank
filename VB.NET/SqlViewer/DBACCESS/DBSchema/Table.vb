Imports utility = SQLViewer.DBAccess.Common.ToolUtility
Namespace DBSchema
    Public Class Table
        Implements iSqlObject
        Private mDatabase As String = ""
        Private mobjName As String = ""
        Private mOwner As String = ""
        Private mComment As String = ""
        Public Sub New(ByVal db As String, ByVal row As DataRow)
            mDatabase = db
            mobjName = utility.DBToString(row.Item("ObjName"))
            mOwner = utility.DBToString(row.Item("Owner"))
        End Sub

        Public Function GetColumns() As DataTable
            Return Nothing
        End Function

        Public ReadOnly Property DataBase() As String Implements SQLViewer.DBAccess.DBSchema.iSqlObject.DataBase
            Get
                Return mDatabase
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
                Return SqlObjectType.Table
            End Get
        End Property
        Public Function ChangeObjname(ByVal newName As String) As Boolean Implements SQLViewer.DBAccess.DBSchema.iSqlObject.ChangeObjname
            Return False
        End Function
        Public Function GetDatas() As DataTable
            Dim dbs As DataBase.SqlServer = Nothing
            Dim strSql As String = ""
            Try
                strSql = "Use " & Me.DataBase & vbCrLf
                strSql &= "Select top 1000 * from " & Me.GetFullName
                dbs = New DataBase.SqlServer()
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
