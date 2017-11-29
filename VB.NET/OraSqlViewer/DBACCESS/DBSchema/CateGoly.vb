Imports utility = SQLViewer.DBAccess.Common.ToolUtility
Namespace DBSchema
    'Public Class CateGoly
    '    Implements iSqlObject
    '    Private mDatabase As String = ""
    '    Private mobjName As String = ""
    '    Private mOwner As String = ""
    '    Private mType As String = ""
    '    Public Sub New(ByVal db As String, ByVal name As String, ByVal type As CateGolyType)
    '        mDatabase = db
    '        mobjName = name
    '        mOwner = "dbo"
    '        Select Case type
    '            Case CateGolyType.TABLE
    '                mType = "TABLE"
    '            Case CateGolyType.VIEW
    '                mType = "VIEW"
    '            Case CateGolyType.PROCEDURE
    '                mType = "PROCEDURE"
    '            Case CateGolyType.FUNCTION
    '                mType = "FUNCTION"
    '        End Select
    '    End Sub
    '    Public Sub New(ByVal db As String, ByVal row As DataRow)
    '        mDatabase = db
    '        mobjName = utility.DBToString(row.Item("value"))
    '        mOwner = "dbo"
    '        mType = utility.DBToString(row.Item("objType"))
    '    End Sub

    '    Public ReadOnly Property DataBase() As String Implements SQLViewer.DBAccess.DBSchema.iSqlObject.User
    '        Get
    '            Return mDatabase
    '        End Get
    '    End Property
    '    Public ReadOnly Property Type() As CateGolyType
    '        Get
    '            Select Case UCase(mType)
    '                Case "TABLE"
    '                    Return CateGolyType.TABLE
    '                Case "VIEW"
    '                    Return CateGolyType.VIEW
    '                Case "PROCEDURE"
    '                    Return CateGolyType.PROCEDURE
    '                Case "FUNCTION"
    '                    Return CateGolyType.FUNCTION
    '            End Select
    '        End Get
    '    End Property
    '    Public ReadOnly Property ObjName() As String Implements SQLViewer.DBAccess.DBSchema.iSqlObject.ObjName
    '        Get
    '            Return mobjName
    '        End Get
    '    End Property

    '    Public ReadOnly Property Owner() As String Implements SQLViewer.DBAccess.DBSchema.iSqlObject.Owner
    '        Get
    '            Return mOwner
    '        End Get
    '    End Property

    '    Public Function GetFullName() As String Implements SQLViewer.DBAccess.DBSchema.iSqlObject.GetFullName
    '        Return String.Format("[{0}].[{1}]", Owner, mobjName)
    '    End Function

    '    Public ReadOnly Property ObjType() As SQLViewer.DBAccess.DBSchema.SqlObjectType Implements SQLViewer.DBAccess.DBSchema.iSqlObject.ObjType
    '        Get
    '            Return SqlObjectType.CateGoly
    '        End Get
    '    End Property
    '    Public ReadOnly Property Comment() As String Implements SQLViewer.DBAccess.DBSchema.iSqlObject.Comment
    '        Get
    '            Return ""
    '        End Get
    '    End Property

    '    Public Sub SetCateGoly(ByVal SqlObject As iSqlObject)
    '        Dim sql As String = ""
    '        Dim sb As New System.Text.StringBuilder()
    '        sb.Append(" USE " & Me.DataBase & vbCrLf)
    '        sb.Append(" DECLARE @ISEXISTS AS INT " & vbCrLf)
    '        sb.Append(" IF EXISTS(")
    '        sb.Append(" SELECT   *")
    '        sb.Append(" FROM   ::FN_LISTEXTENDEDPROPERTY ('SV_CATEGOLY', 'USER','{0}', '{1}', '{2}',DEFAULT, DEFAULT))" & vbCrLf)
    '        sb.Append(" BEGIN" & vbCrLf)
    '        sb.Append("  EXEC SP_DROPEXTENDEDPROPERTY 'SV_CATEGOLY', 'USER', {0}, '{1}', '{2}', NULL, NULL" & vbCrLf)
    '        sb.Append(" END")
    '        sb.Append(" EXEC sp_addextendedproperty 'SV_CATEGOLY',{3},'USER', {0}, '{1}', '{2}', NULL, NULL " & vbCrLf)

    '        Select Case Me.Type
    '            Case CateGolyType.TABLE
    '                If SqlObject.ObjType <> SqlObjectType.Table Then
    '                    Return
    '                End If
    '                sql = String.Format(sb.ToString(), SqlObject.Owner, "TABLE", SqlObject.ObjName, utility.Quot(Me.ObjName))
    '            Case CateGolyType.VIEW
    '                If SqlObject.ObjType <> SqlObjectType.View Then
    '                    Return
    '                End If

    '                sql = String.Format(sb.ToString(), SqlObject.Owner, "VIEW", SqlObject.ObjName, utility.Quot(Me.ObjName))

    '            Case CateGolyType.PROCEDURE
    '                If SqlObject.ObjType <> SqlObjectType.StoreProcedure Then
    '                    Return
    '                End If

    '                sql = String.Format(sb.ToString(), SqlObject.Owner, "PROCEDURE", SqlObject.ObjName, utility.Quot(Me.ObjName))

    '            Case CateGolyType.FUNCTION
    '                If SqlObject.ObjType <> SqlObjectType.Function Then
    '                    Return
    '                End If
    '                sql = String.Format(sb.ToString(), SqlObject.Owner, "FUNCTION", SqlObject.ObjName, utility.Quot(Me.ObjName))

    '            Case Else
    '                Return
    '        End Select
    '        Dim dba As New DataBase.OraSqlServer()
    '        dba.ExecuteOracleCommand(sql)
    '    End Sub

    '    ' ''' -----------------------------------------------------------------------------
    '    ' ''' <summary>
    '    ' ''' カテゴリ名を変更する
    '    ' ''' </summary>
    '    ' ''' <param name="newName">新しいカテゴリ名</param>
    '    ' ''' <returns></returns>
    '    ' ''' <remarks>
    '    ' ''' </remarks>
    '    ' ''' <history>
    '    ' ''' 	[Administrator]	2006/06/29	Created
    '    ' ''' </history>
    '    ' ''' -----------------------------------------------------------------------------
    '    'Public Function ChangeObjname(ByVal newName As String) As Boolean Implements SQLViewer.DBAccess.DBSchema.iSqlObject.ChangeObjname
    '    '    Try

    '    '        Dim obj As iSqlObject = Nothing
    '    '        Dim dtt As DataTable = Nothing
    '    '        Dim row As DataRow = Nothing
    '    '        Dim dbSchema As New DBSchemaControler()
    '    '        Select Case Me.Type
    '    '            Case CateGolyType.TABLE
    '    '                dtt = dbSchema.GetTables(Me.DataBase, Me.ObjName)
    '    '                Me.mobjName = newName
    '    '                For Each row In dtt.Rows
    '    '                    Dim tab As New Table(Me.DataBase, row)
    '    '                    Me.SetCateGoly(tab)
    '    '                Next

    '    '            Case CateGolyType.VIEW
    '    '                dtt = dbSchema.GetViews(Me.DataBase, Me.ObjName)
    '    '                Me.mobjName = newName
    '    '                For Each row In dtt.Rows
    '    '                    Dim vw As New View(Me.DataBase, row)
    '    '                    Me.SetCateGoly(vw)
    '    '                Next
    '    '            Case CateGolyType.PROCEDURE
    '    '                dtt = dbSchema.GetStoreProcedures(Me.DataBase, Me.ObjName)
    '    '                Me.mobjName = newName
    '    '                For Each row In dtt.Rows
    '    '                    Dim sp As New StoreProcedure(Me.DataBase, row)
    '    '                    Me.SetCateGoly(sp)
    '    '                Next
    '    '            Case CateGolyType.FUNCTION
    '    '                dtt = dbSchema.GetFunctions(Me.DataBase, Me.ObjName)
    '    '                Me.mobjName = newName
    '    '                For Each row In dtt.Rows
    '    '                    Dim fn As New [Function](Me.DataBase, row)
    '    '                    Me.SetCateGoly(fn)
    '    '                Next
    '    '        End Select

    '    '        Return True
    '    '    Catch ex As Exception
    '    '        Throw ex
    '    '    End Try

    '    'End Function
    '    Public Sub RemoveCategoly(ByVal SqlObject As iSqlObject)
    '        Dim sql As String = ""
    '        Dim sb As New System.Text.StringBuilder()
    '        sb.Append(" USE " & Me.DataBase & vbCrLf)
    '        sb.Append(" DECLARE @ISEXISTS AS INT " & vbCrLf)
    '        sb.Append(" IF EXISTS(")
    '        sb.Append(" SELECT   *")
    '        sb.Append(" FROM   ::FN_LISTEXTENDEDPROPERTY ('SV_CATEGOLY', 'USER','{0}', '{1}', '{2}',DEFAULT, DEFAULT))" & vbCrLf)
    '        sb.Append(" BEGIN" & vbCrLf)
    '        sb.Append("  EXEC SP_DROPEXTENDEDPROPERTY 'SV_CATEGOLY', 'USER', {0}, '{1}', '{2}', NULL, NULL" & vbCrLf)
    '        sb.Append(" END")

    '        Select Case Me.Type
    '            Case CateGolyType.TABLE
    '                If SqlObject.ObjType <> SqlObjectType.Table Then
    '                    Return
    '                End If
    '                sql = String.Format(sb.ToString(), SqlObject.Owner, "TABLE", SqlObject.ObjName)
    '            Case CateGolyType.VIEW
    '                If SqlObject.ObjType <> SqlObjectType.View Then
    '                    Return
    '                End If

    '                sql = String.Format(sb.ToString(), SqlObject.Owner, "VIEW", SqlObject.ObjName)

    '            Case CateGolyType.PROCEDURE
    '                If SqlObject.ObjType <> SqlObjectType.StoreProcedure Then
    '                    Return
    '                End If

    '                sql = String.Format(sb.ToString(), SqlObject.Owner, "PROCEDURE", SqlObject.ObjName)

    '            Case CateGolyType.FUNCTION
    '                If SqlObject.ObjType <> SqlObjectType.Function Then
    '                    Return
    '                End If
    '                sql = String.Format(sb.ToString(), SqlObject.Owner, "FUNCTION", SqlObject.ObjName)

    '            Case Else
    '                Return
    '        End Select
    '        Dim dba As New DataBase.OraSqlServer()
    '        dba.ExecuteOracleCommand(sql)
    '    End Sub
    '    Public Sub Remove()
    '        Try
    '            Dim obj As iSqlObject = Nothing
    '            Dim dtt As DataTable = Nothing
    '            Dim row As DataRow = Nothing
    '            Dim dbSchema As New DBSchemaControler()
    '            Select Case Me.Type
    '                Case CateGolyType.TABLE
    '                    dtt = dbSchema.GetTables(Me.DataBase, Me.ObjName)
    '                    For Each row In dtt.Rows
    '                        Dim tab As New Table(Me.DataBase, row)
    '                        Me.RemoveCategoly(tab)
    '                    Next

    '                Case CateGolyType.VIEW
    '                    dtt = dbSchema.GetViews(Me.DataBase, Me.ObjName)
    '                    For Each row In dtt.Rows
    '                        Dim vw As New View(Me.DataBase, row)
    '                        Me.RemoveCategoly(vw)
    '                    Next
    '                Case CateGolyType.PROCEDURE
    '                    dtt = dbSchema.GetStoreProcedures(Me.DataBase, Me.ObjName)
    '                    For Each row In dtt.Rows
    '                        Dim sp As New StoreProcedure(Me.DataBase, row)
    '                        Me.RemoveCategoly(sp)
    '                    Next
    '                Case CateGolyType.FUNCTION
    '                    dtt = dbSchema.GetFunctions(Me.DataBase, Me.ObjName)
    '                    For Each row In dtt.Rows
    '                        Dim fn As New [Function](Me.DataBase, row)
    '                        Me.RemoveCategoly(fn)
    '                    Next
    '            End Select
    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '    End Sub
    '    Public Sub UpdateComment(ByVal newComment As String) Implements SQLViewer.DBAccess.DBSchema.iSqlObject.UpdateComment
    '        'Donothing
    '    End Sub
    'End Class
End Namespace
