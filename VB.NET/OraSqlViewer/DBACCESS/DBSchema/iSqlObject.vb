Namespace DBSchema
    Public Interface iSqlObject
        ReadOnly Property User() As String
        ReadOnly Property ObjName() As String
        ReadOnly Property Owner() As String
        ReadOnly Property ObjType() As SqlObjectType
        ReadOnly Property Comment() As String
        Function ChangeObjname(ByVal newName As String) As Boolean
        Function GetFullName() As String
        Sub UpdateComment(ByVal newComment As String)
    End Interface
    Public Enum SqlObjectType As Integer
        CateGoly
        Table
        View
        Procedure
        [Function]
        Index
        SqlQuery
        Package
        PackageBody
        Seqence
        Arguement
    End Enum
    Public Enum CateGolyType As Integer
        TABLE
        VIEW
        PROCEDURE
        [FUNCTION]
        Package
        PackageBody
    End Enum
End Namespace
