Imports System.Collections.Generic
Public Class frmSetTableName

    Private mDts As DataSet
    Private mSelectTable As New List(Of String)
    Private mIsSkipReadonlyColumn As Boolean = False
    Public Property DataSource() As DataSet
        Get
            Return mDts
        End Get
        Set(ByVal value As DataSet)
            mDts = value
        End Set
    End Property

    Public Property SelectedTables() As List(Of String)
        Get
            Return mSelectTable
        End Get
        Set(ByVal value As List(Of String))
            mSelectTable = value
        End Set
    End Property

    Public ReadOnly Property IsSkipReadonlyColumn() As Boolean
        Get
            Return mIsSkipReadonlyColumn
        End Get
    End Property

    Private Sub InitControls()
        Dim DttTablename As New DataTable
        DttTablename.Columns.Add("Col0", GetType(Boolean))
        DttTablename.Columns.Add("Col1", GetType(String))
        DttTablename.Columns.Add("Col2", GetType(String))
        DttTablename.Columns.Add("Col3", GetType(String))
        Dim index As Integer = 0
        For Each dtt As DataTable In Me.mDts.Tables
            index += 1
            Dim row As DataRow = DttTablename.NewRow
            row.Item(0) = True
            row.Item(1) = "テーブル" & index & ":"
            row.Item(2) = dtt.TableName
            row.Item(3) = dtt.TableName
            DttTablename.Rows.Add(row)
        Next
        Dim vwTblname As New DataView(DttTablename)
        vwTblname.AllowEdit = True
        vwTblname.AllowNew = False
        vwTblname.AllowDelete = False
        Me.DataGridView1.DataSource = vwTblname

    End Sub

    Private Sub frmSetTableName_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        InitControls()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        mIsSkipReadonlyColumn = Me.chkSkipReadonly.Checked
        Dim vwTblname As DataView = CType(Me.DataGridView1.DataSource, DataView)
        For Each item As DataRowView In vwTblname
            Dim isCheck As Boolean = CBool(item.Item(0))
            Dim TblName As String = CStr(item.Item(2))
            Dim OrgTblName As String = CStr(item.Item(3))

            If TblName = "" Then
                MessageBox.Show("テーブル名を入力してください。")
                Return
            End If
            If isCheck Then
                Me.DataSource.Tables(OrgTblName).TableName = TblName
                mSelectTable.Add(TblName)
            End If
        Next
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
End Class
