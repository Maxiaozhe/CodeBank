
Public Class SqlQuery
    Implements DBSchema.iSqlObject
    Private mDatabase As String = ""
    Private mobjName As String = ""
    Private mOwner As String = ""
    Private mComment As String = ""
    Private mSql As String = ""
    Public Function ChangeObjname(ByVal newName As String) As Boolean Implements SQLViewer.DBAccess.DBSchema.iSqlObject.ChangeObjname
        mobjName = newName
    End Function

    Public ReadOnly Property Comment() As String Implements SQLViewer.DBAccess.DBSchema.iSqlObject.Comment
        Get
            Return ""
        End Get
    End Property

    Public ReadOnly Property DataBase() As String Implements SQLViewer.DBAccess.DBSchema.iSqlObject.DataBase
        Get
            Return mDatabase
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
    Public Sub New(ByVal dbName As String, ByVal sqlText As String, ByVal queryName As String)
        mDatabase = dbName
        mSql = SqlText
        Me.mobjName = queryName
    End Sub
    Public Function ExecSql(ByVal Sql As String, ByRef ErrMessage As String) As DataSet
        Dim dba As New DataBase.SqlServer()

        Try
            Dim sb As New System.Text.StringBuilder()

            sb.AppendLine(" USE " & DataBase)
            sb.AppendLine(Sql)
            dba.BeginTransaction()
            Dim dts As DataSet = dba.SelectSql(sb.ToString)
            dba.Commit()
         
            Return dts
        Catch ex As SqlClient.SqlException
            dba.Rollback()
            ErrMessage &= "ÉGÉâÅ[î‘çÜ:" & ex.Number & vbCrLf
            ErrMessage &= "çsêî:" & ex.LineNumber & vbCrLf
            ErrMessage &= ex.Message
            Return Nothing
        Finally
            dba.Close()
        End Try
    End Function
End Class
