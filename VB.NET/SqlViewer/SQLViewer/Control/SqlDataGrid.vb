Imports System.Collections.Generic
Imports SQLViewer.DBAccess.Common
Public Class SqlDataGrid
    Inherits DataGrid

    Friend WithEvents mnuSqlOutput As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dlgSaveFile As System.Windows.Forms.SaveFileDialog
    Friend WithEvents mnuStript As System.Windows.Forms.ContextMenuStrip

    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.mnuStript = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuSqlOutput = New System.Windows.Forms.ToolStripMenuItem
        Me.dlgSaveFile = New System.Windows.Forms.SaveFileDialog
        Me.mnuStript.SuspendLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'mnuStript
        '
        Me.mnuStript.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSqlOutput})
        Me.mnuStript.Name = "ContextMenuStrip1"
        Me.mnuStript.Size = New System.Drawing.Size(180, 26)
        '
        'mnuSqlOutput
        '
        Me.mnuSqlOutput.Name = "mnuSqlOutput"
        Me.mnuSqlOutput.Size = New System.Drawing.Size(179, 22)
        Me.mnuSqlOutput.Text = "Insert SQL 出力..."
        '
        'dlgSaveFile
        '
        Me.dlgSaveFile.Filter = "SQLファイル(*.SQL)|*.sql"
        Me.dlgSaveFile.Title = "SQLスクリプトを出力"
        '
        'SqlDataGrid
        '
        Me.ContextMenuStrip = Me.mnuStript
        Me.mnuStript.ResumeLayout(False)
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private components As System.ComponentModel.IContainer
    Public Sub New()
        InitializeComponent()
        Me.ContextMenuStrip = Me.mnuStript
    End Sub
    '出力
    Private Sub mnuSqlOutput_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuSqlOutput.Click
        If Me.DataSource Is Nothing Then Return
        Dim frmSetTab As New frmSetTableName
        Dim dts As DataSet = Nothing
        If TypeOf Me.DataSource Is DataSet Then
            dts = CType(Me.DataSource, DataSet)
        ElseIf TypeOf Me.DataSource Is DataTable Then
            dts = CType(Me.DataSource, DataTable).DataSet
        End If
        frmSetTab.DataSource = dts
        If frmSetTab.ShowDialog(Me.FindForm) = DialogResult.OK Then
            If frmSetTab.SelectedTables.Count > 0 Then
                Dim strsql As String = ConvertToInsertSql(dts, frmSetTab.SelectedTables, frmSetTab.IsSkipReadonlyColumn)
                If Me.dlgSaveFile.ShowDialog(Me.FindForm) = Windows.Forms.DialogResult.OK Then
                    My.Computer.FileSystem.WriteAllText(dlgSaveFile.FileName, strsql, False, System.Text.Encoding.UTF8)
                End If
            End If
            If frmSetTab.DataSource.Tables.Count = 1 Then
                MyBase.DataSource = Nothing
                MyBase.DataSource = frmSetTab.DataSource.Tables(0)
            Else
                MyBase.DataSource = Nothing
                MyBase.DataSource = frmSetTab.DataSource
                MyBase.Expand(-1)
            End If
        End If

    End Sub


    ''' <summary>
    ''' データセットからINSERT SQLへ変換する
    ''' </summary>
    ''' <param name="dataSource"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ConvertToInsertSql(ByVal dataSource As DataSet, ByVal OutputTables As List(Of String), ByVal IsSkipReadonly As Boolean) As String
        Dim SbSql As New System.Text.StringBuilder
        For Each dtt As DataTable In dataSource.Tables
            If OutputTables.IndexOf(dtt.TableName) = -1 Then
                Continue For
            End If
            If dtt.Rows.Count > 0 Then
                'Columns
                Dim columns As String = ""
                For Each column As DataColumn In dtt.Columns
                    If column.AutoIncrement = False AndAlso Not (column.ReadOnly = True AndAlso IsSkipReadonly = True) Then
                        If columns <> "" Then
                            columns &= ","
                        End If
                        columns &= column.ColumnName
                    End If
                Next
                'ヘッダ出力
                SbSql.AppendLine("-- " & dtt.TableName)
                ' データ
                For Each row As DataRow In dtt.Rows
                    Dim values As String = ""
                    For Each column As DataColumn In dtt.Columns
                        If column.AutoIncrement = False AndAlso Not (column.ReadOnly = True AndAlso IsSkipReadonly = True) Then
                            If values <> "" Then
                                values &= ","
                            End If
                            If row.Item(column.ColumnName) Is DBNull.Value Then
                                values &= "NULL"
                            Else
                                Dim buf As String = GetValue(row, column)
                                If buf.Length > 100 Then
                                    values &= vbCrLf
                                End If
                                values &= buf
                            End If
                        End If
                    Next
                    SbSql.AppendFormat("INSERT INTO [{0}] ( ", dtt.TableName)
                    SbSql.Append(columns & ") VALUES( ")
                    SbSql.Append(values & ")" & vbCrLf)
                Next
                SbSql.AppendLine("")
            End If
        Next
        Return SbSql.ToString
    End Function

    Private Function GetValue(ByVal row As DataRow, ByVal Column As DataColumn) As String
        Dim strValue As String = ""
        Dim objValue As Object = row.Item(Column.ColumnName)
        If objValue Is DBNull.Value Then
            strValue = "NULL"
        ElseIf Column.DataType Is GetType(String) Then
            strValue = ToolUtility.Quot(ToolUtility.DBToString(objValue))
        ElseIf Column.DataType Is GetType(Integer) Then
            strValue = CStr(objValue)
        ElseIf Column.DataType Is GetType(Decimal) Then
            strValue = CStr(objValue)
        ElseIf Column.DataType Is GetType(DateTime) Then
            strValue = "'" & CDate(objValue).ToString("yyyy/MM/dd HH:mm:dd") & "'"
        ElseIf Column.DataType Is GetType(Byte()) Then
            strValue = "'" & ToolUtility.BinaryToString(CType(objValue, Byte())) & "'"
        Else
            strValue = ToolUtility.Quot(ToolUtility.DBToString(objValue))
        End If
        Return strValue
    End Function



End Class
