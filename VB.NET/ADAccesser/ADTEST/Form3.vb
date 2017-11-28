Imports System.Collections.Generic
Public Class Form3
    Inherits System.Windows.Forms.Form

#Region " Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h "

    Public Sub New()
        MyBase.New()

        ' ���̌Ăяo���� Windows �t�H�[�� �f�U�C�i�ŕK�v�ł��B
        InitializeComponent()

        ' InitializeComponent() �Ăяo���̌�ɏ�������ǉ����܂��B

    End Sub

    ' Form �́A�R���|�[�l���g�ꗗ�Ɍ㏈�������s���邽�߂� dispose ���I�[�o�[���C�h���܂��B
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub
    Friend WithEvents lstColumn As System.Windows.Forms.ListBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog

    ' Windows �t�H�[�� �f�U�C�i�ŕK�v�ł��B
    Private components As System.ComponentModel.IContainer

    ' ���� : �ȉ��̃v���V�[�W���́AWindows �t�H�[�� �f�U�C�i�ŕK�v�ł��B
    'Windows �t�H�[�� �f�U�C�i���g���ĕύX���Ă��������B  
    ' �R�[�h �G�f�B�^���g���ĕύX���Ȃ��ł��������B
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lstColumn = New System.Windows.Forms.ListBox
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.SuspendLayout()
        '
        'lstColumn
        '
        Me.lstColumn.FormattingEnabled = True
        Me.lstColumn.ItemHeight = 12
        Me.lstColumn.Location = New System.Drawing.Point(12, 12)
        Me.lstColumn.Name = "lstColumn"
        Me.lstColumn.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstColumn.Size = New System.Drawing.Size(330, 304)
        Me.lstColumn.TabIndex = 0
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(157, 319)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(239, 319)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "�L�����Z��"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.Filter = "CSV�t�@�C��(*.csv)|*.csv"
        '
        'Form3
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(358, 354)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.lstColumn)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form3"
        Me.Text = "�J�����I��"
        Me.ResumeLayout(False)

    End Sub

#End Region
    Private mdatasource As DataTable

    Public Property DataSource() As DataTable
        Get
            Return mdatasource
        End Get
        Set(ByVal value As DataTable)
            mdatasource = value
        End Set
    End Property

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Try
            If Me.lstColumn.SelectedItems.Count = 0 Then
                Return
            End If
            Dim Columns As New List(Of DataColumn)
            For Each item As DataColumn In Me.lstColumn.SelectedItems
                Columns.Add(item)
            Next
            If Me.SaveFileDialog1.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Dim filename As String = Me.SaveFileDialog1.FileName
                Dim DireName As String = System.IO.Path.GetDirectoryName(filename)
                If My.Computer.FileSystem.DirectoryExists(DireName) = False Then
                    My.Computer.FileSystem.CreateDirectory(DireName)
                End If
                Dim buf As String = Me.GetCsvFile(Columns)
                My.Computer.FileSystem.WriteAllText(filename, buf, False, System.Text.Encoding.GetEncoding("shift-jis"))
                Me.Close()
            Else
                Return
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function GetCsvFile(ByVal Columns As List(Of DataColumn)) As String
        Dim sb As New System.Text.StringBuilder
        Dim Index As Integer = 0
        Dim value As String = ""
        For Each col As DataColumn In Columns
            If Index > 0 Then
                sb.Append(",")
            End If
            sb.Append(ToCsv(col.ColumnName))
            Index += 1
        Next
        For Each row As DataRow In Me.mdatasource.Rows
            Index = 0
            sb.Append(vbCrLf)
            For Each col As DataColumn In Columns
                If Index > 0 Then
                    sb.Append(",")
                End If
                value = DBToString(row.Item(col).ToString)
                sb.Append(ToCsv(value))
                Index += 1
            Next
        Next
        Return sb.ToString


    End Function
    Private Function ToCsv(ByVal value As String) As String
        If value Is Nothing Then Return ""
        Dim strbuf As String = value
        strbuf = strbuf.Replace("""", """""")
        If strbuf.IndexOf(",") > -1 OrElse strbuf.IndexOf(vbCrLf) > -1 Then
            strbuf = """" & strbuf & """"
        End If
        Return strbuf
    End Function
    Private Function DBToString(ByVal value As Object) As String


        If value Is Nothing OrElse TypeOf value Is DBNull Then
            Return ""
        Else
            Return CType(value, String)
        End If

    End Function
    Private Sub Form3_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.lstColumn.Items.Clear()
        Me.lstColumn.DisplayMember = "ColumnName"
        If Me.mdatasource IsNot Nothing Then
            For Each column As DataColumn In Me.mdatasource.Columns
                Me.lstColumn.Items.Add(column)
            Next
        End If
    End Sub
End Class
