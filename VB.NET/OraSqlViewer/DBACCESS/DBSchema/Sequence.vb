Imports utility = SQLViewer.DBAccess.Common.ToolUtility
Imports SQLViewer.DBAccess.DataBase
Imports Oracle.DataAccess.Client

Namespace DBSchema
    Public Class Sequence
        Implements iSqlObject
        Private mUser As String = ""
        Private mobjName As String = ""
        Private mOwner As String = ""
        Private mType As String = ""
        Private mComment As String = ""
        Private _minValue As Decimal
        Private _maxValue As Decimal
        Private _Increment As Decimal
        Private _CycleFlag As Boolean
        Private _CacheSize As Decimal
        Private _LastNumber As Decimal

        Public Sub New(ByVal user As String, ByVal row As DataRow)
            mUser = user
            mobjName = utility.DBToString(row.Item("OBJNAME"))
            mOwner = utility.DBToString(row.Item("OWNER"))
            Me._minValue = utility.DBToDecimal(row.Item("MIN_VALUE"))
            Me._maxValue = utility.DBToDecimal(row.Item("MAX_VALUE"))
            Me._Increment = utility.DBToDecimal(row.Item("INCREMENT_BY"))
            Me._CycleFlag = utility.DBToBoolean(row.Item("CYCLE_FLAG"))

            Me._CacheSize = utility.DBToDecimal(row.Item("CACHE_SIZE"))
            Me._LastNumber = utility.DBToDecimal(row.Item("LAST_NUMBER"))
        End Sub

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
            Return String.Format("""{0}"".""{1}""", Owner, mobjName)
        End Function
        Public ReadOnly Property ObjType() As SQLViewer.DBAccess.DBSchema.SqlObjectType Implements SQLViewer.DBAccess.DBSchema.iSqlObject.ObjType
            Get
                Return SqlObjectType.Seqence
            End Get
        End Property

        Public Function GetPropertys() As DataTable
            Dim dtt As New DataTable
            dtt.Columns.Add("ëÆê´", GetType(String))
            dtt.Columns.Add("íl", GetType(String))
            Dim row As DataRow = dtt.NewRow()
            row.Item(0) = "MAXVALUE "
            row.Item(1) = Me._maxValue.ToString()
            dtt.Rows.Add(row)
            row = dtt.NewRow()
            row.Item(0) = "MINVALUE"
            row.Item(1) = Me._minValue.ToString()
            dtt.Rows.Add(row)
            row = dtt.NewRow()
            row.Item(0) = "CYCLE"
            row.Item(1) = Me._CycleFlag.ToString()
            dtt.Rows.Add(row)
            row = dtt.NewRow()
            row.Item(0) = "CACHE"
            row.Item(1) = Me._CacheSize.ToString()
            dtt.Rows.Add(row)
            row = dtt.NewRow()
            row.Item(0) = "INCREMENT BY"
            row.Item(1) = Me._Increment.ToString()
            dtt.Rows.Add(row)
            row = dtt.NewRow()
            row.Item(0) = "LAST_NUMBER"
            row.Item(1) = Me._LastNumber.ToString()
            dtt.Rows.Add(row)
            Return dtt

        End Function
        Public Function GetDDLCode() As String
            Dim cmd As Oracle.DataAccess.Client.OracleCommand = Nothing
            Dim dba As DataBase.OraSqlServer = Nothing

            Try
                dba = New OraSqlServer()
                cmd = dba.CreateCommand()
                cmd.CommandText = My.Resources.GetDDL
                cmd.Parameters.Add(":OBJTYPE", "SEQUENCE")
                cmd.Parameters.Add(":OBJNAME", Me.ObjName)
                cmd.Parameters.Add(":SCHEMA", Me.mUser)
                Dim dtt As DataTable = dba.SelectSql(cmd, "SEQUENCE")
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
        Public Sub Update(ByVal ddlCode As String)
            Dim dba As New DataBase.OraSqlServer()
            Dim sb As New System.Text.StringBuilder()
            sb.AppendLine(ddlCode)
            dba.ExecuteOracleCommand(sb.ToString)
        End Sub
    End Class
End Namespace
