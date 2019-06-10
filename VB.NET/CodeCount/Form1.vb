Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows フォーム デザイナで生成されたコード "

    Public Sub New()
        MyBase.New()

        ' この呼び出しは Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後に初期化を追加します。

    End Sub

    ' Form は、コンポーネント一覧に後処理を実行するために dispose をオーバーライドします。
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    ' メモ : 以下のプロシージャは、Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使って変更してください。  
    ' コード エディタを使って変更しないでください。
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents rdbCSharp As System.Windows.Forms.RadioButton
    Friend WithEvents rdbVbNet As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents rdbJava As System.Windows.Forms.RadioButton
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.DataGrid1 = New System.Windows.Forms.DataGrid()
        Me.rdbCSharp = New System.Windows.Forms.RadioButton()
        Me.rdbVbNet = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.rdbJava = New System.Windows.Forms.RadioButton()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(104, 16)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(312, 19)
        Me.TextBox1.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(424, 16)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(56, 24)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "参照"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "ソースフォルダ"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(16, 48)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(88, 24)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "実行"
        '
        'DataGrid1
        '
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(8, 88)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.Size = New System.Drawing.Size(512, 336)
        Me.DataGrid1.TabIndex = 5
        '
        'rdbCSharp
        '
        Me.rdbCSharp.AutoSize = True
        Me.rdbCSharp.Location = New System.Drawing.Point(278, 60)
        Me.rdbCSharp.Name = "rdbCSharp"
        Me.rdbCSharp.Size = New System.Drawing.Size(37, 16)
        Me.rdbCSharp.TabIndex = 6
        Me.rdbCSharp.TabStop = True
        Me.rdbCSharp.Text = "C#"
        Me.rdbCSharp.UseVisualStyleBackColor = True
        '
        'rdbVbNet
        '
        Me.rdbVbNet.AutoSize = True
        Me.rdbVbNet.Location = New System.Drawing.Point(334, 60)
        Me.rdbVbNet.Name = "rdbVbNet"
        Me.rdbVbNet.Size = New System.Drawing.Size(63, 16)
        Me.rdbVbNet.TabIndex = 7
        Me.rdbVbNet.TabStop = True
        Me.rdbVbNet.Text = "VB.NET"
        Me.rdbVbNet.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(228, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 12)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "言語"
        '
        'rdbJava
        '
        Me.rdbJava.AutoSize = True
        Me.rdbJava.Location = New System.Drawing.Point(403, 60)
        Me.rdbJava.Name = "rdbJava"
        Me.rdbJava.Size = New System.Drawing.Size(48, 16)
        Me.rdbJava.TabIndex = 9
        Me.rdbJava.TabStop = True
        Me.rdbJava.Text = "Java"
        Me.rdbJava.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
        Me.ClientSize = New System.Drawing.Size(536, 437)
        Me.Controls.Add(Me.rdbJava)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.rdbVbNet)
        Me.Controls.Add(Me.rdbCSharp)
        Me.Controls.Add(Me.DataGrid1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Private mSourcePath As String = ""
    Private mRegexVb As New System.Text.RegularExpressions.Regex("^\s*\'.*")
    Private mRegexCSharp As New System.Text.RegularExpressions.Regex("^(\s*//.*)")
    Private mRegexJava As New System.Text.RegularExpressions.Regex("^(\s*//.*)")
    Private mFileFilter As String = ""
    Private mRegex As System.Text.RegularExpressions.Regex
    Private mSourceDtt As DataTable = Nothing

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Me.FolderBrowserDialog1.ShowDialog(Me) = DialogResult.OK Then
            Me.TextBox1.Text = Me.FolderBrowserDialog1.SelectedPath
            mSourcePath = Me.FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        mSourceDtt = New DataTable
        mSourceDtt.Columns.Add("パス", GetType(String))
        mSourceDtt.Columns.Add("ファイル名", GetType(String))
        mSourceDtt.Columns.Add("ステップ数", GetType(Integer))
        GetFiles(mSourcePath)

        Dim count As Integer = 0
        Try
            If mSourceDtt.Rows.Count > 0 Then
                count = CInt(mSourceDtt.Compute("sum([ステップ数])", ""))
            Else
                count = 0
            End If
        Catch ex As Exception

        End Try
        Dim row As DataRow = mSourceDtt.NewRow
        row.Item(0) = ""
        row.Item(1) = "合計"
        row.Item(2) = count
        mSourceDtt.Rows.Add(row)
        Me.DataGrid1.DataSource = mSourceDtt
    End Sub
    Private Sub GetFiles(ByVal parentPath As String)
        If rdbCSharp.Checked Then
            mFileFilter = "*.CS"
            Me.mRegex = Me.mRegexCSharp
        ElseIf rdbVbNet.Checked Then
            mFileFilter = "*.vb"
            Me.mRegex = Me.mRegexVb
        Else
            mFileFilter = "*.java"
            Me.mRegex = Me.mRegexVb
        End If
        Dim files() As String = System.IO.Directory.GetFiles(parentPath, mFileFilter)
        For Each fl As String In files
            Dim row As DataRow = mSourceDtt.NewRow
            row.Item(0) = System.IO.Path.GetDirectoryName(fl)
            row.Item(1) = System.IO.Path.GetFileName(fl)
            Dim num As Integer = 0
            Dim strem As New System.IO.FileStream(fl, IO.FileMode.Open, IO.FileAccess.Read)
            Dim reader As New System.IO.StreamReader(strem, System.Text.Encoding.GetEncoding("shift-jis"))
            Dim buf As String = reader.ReadLine()
            Do While Not buf Is Nothing
                If mRegex.IsMatch(buf) = False Then
                    num += 1
                End If
                buf = reader.ReadLine
            Loop
            reader.Close()
            strem.Close()
            row.Item(2) = num
            mSourceDtt.Rows.Add(row)
        Next
        Dim dirs() As String = System.IO.Directory.GetDirectories(parentPath)
        For Each folder As String In dirs
            GetFiles(folder)
        Next
    End Sub

    Public Structure SourceData
        Public Filename As String
        Public StepNum As Integer
    End Structure
End Class
