Imports utility = SQLViewer.DBAccess.Common.ToolUtility
Public Class SqlArguement
    Implements DBSchema.iSqlObject

    Private _ArguementName As String
    Private _ObjectName As String
    Private _ownerName As String
    Private _user As String
    Private _IOType As Data.ParameterDirection
    Private _DataType As String

    Public Sub New(ByVal user As String, ByVal row As DataRow)
        Me._user = user
        Me._ArguementName = utility.DBToString(row.Item("ARGUMENT_NAME"))
        Me._ObjectName = utility.DBToString(row.Item("OBJECT_NAME"))
        Me._ownerName = user
        Me._DataType = utility.DBToString(row.Item("DATA_TYPE"))
        Dim iotype As String = utility.DBToString(row.Item("IN_OUT"))
        If iotype.ToUpper() = "OUT" Then
            Me._IOType = ParameterDirection.Output
        ElseIf iotype.ToUpper() = "IN/OUT" Then
            Me._IOType = ParameterDirection.InputOutput
        Else
            Me._IOType = ParameterDirection.Input
        End If
    End Sub

    Public ReadOnly Property DataType As Oracle.DataAccess.Client.OracleDbType
        Get
            Select Case Me._DataType.ToUpper()
                Case "NUMBER", "INT", "FLOAT", "LONG"
                    Return Oracle.DataAccess.Client.OracleDbType.Decimal
                Case "VARCHAR2", "NVARCHAR2"
                    Return Oracle.DataAccess.Client.OracleDbType.Varchar2
                Case "DATE"
                    Return Oracle.DataAccess.Client.OracleDbType.Date
                Case "REF CURSOR"
                    Return Oracle.DataAccess.Client.OracleDbType.RefCursor
                Case Else
                    Return Oracle.DataAccess.Client.OracleDbType.NVarchar2
            End Select
        End Get
    End Property


    Public Function ChangeObjname(newName As String) As Boolean Implements DBSchema.iSqlObject.ChangeObjname
        Throw New NotImplementedException("このメソッドがサポートされません。")
    End Function

    Public ReadOnly Property Comment As String Implements DBSchema.iSqlObject.Comment
        Get
            Throw New NotImplementedException("このメソッドがサポートされません。")
        End Get
    End Property

    Public Function GetFullName() As String Implements DBSchema.iSqlObject.GetFullName
        Return Me._ArguementName
    End Function

    Public ReadOnly Property IOType As ParameterDirection
        Get
            Return Me._IOType
        End Get
    End Property


    Public ReadOnly Property ObjName As String Implements DBSchema.iSqlObject.ObjName
        Get
            Return Me._ObjectName
        End Get
    End Property

    Public ReadOnly Property ObjType As DBSchema.SqlObjectType Implements DBSchema.iSqlObject.ObjType
        Get
            Return DBSchema.SqlObjectType.Arguement
        End Get
    End Property

    Public ReadOnly Property Owner As String Implements DBSchema.iSqlObject.Owner
        Get
            Return Me._ownerName
        End Get
    End Property

    Public Sub UpdateComment(newComment As String) Implements DBSchema.iSqlObject.UpdateComment
        Throw New NotImplementedException("このメソッドがサポートされません。")
    End Sub

    Public ReadOnly Property User As String Implements DBSchema.iSqlObject.User
        Get
            Return Me._user
        End Get
    End Property

End Class
