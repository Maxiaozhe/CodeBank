Public Class Form2
    Inherits System.Windows.Forms.Form
    Private DataSource As DataSet
#Region " Windows フォーム デザイナで生成されたコード "

    Public Sub New()
        MyBase.New()

        ' この呼び出しは Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後に初期化を追加します。

    End Sub

    ' Form は dispose をオーバーライドしてコンポーネント一覧を消去します。
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
    ' Windows フォーム デザイナを使って変更してください。  
    ' コード エディタは使用しないでください。
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuTool As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCsvOutput As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.mnuTool = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuCsvOutput = New System.Windows.Forms.ToolStripMenuItem
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListBox1
        '
        Me.ListBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListBox1.ItemHeight = 12
        Me.ListBox1.Location = New System.Drawing.Point(0, 26)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(584, 376)
        Me.ListBox1.TabIndex = 0
        '
        'DataGrid1
        '
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(0, 26)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.Size = New System.Drawing.Size(584, 380)
        Me.DataGrid1.TabIndex = 1
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuTool})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(584, 26)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mnuTool
        '
        Me.mnuTool.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuCsvOutput})
        Me.mnuTool.Name = "mnuTool"
        Me.mnuTool.Size = New System.Drawing.Size(56, 22)
        Me.mnuTool.Text = "ツール"
        '
        'mnuCsvOutput
        '
        Me.mnuCsvOutput.Name = "mnuCsvOutput"
        Me.mnuCsvOutput.Size = New System.Drawing.Size(124, 22)
        Me.mnuCsvOutput.Text = "CSV出力"
        '
        'Form2
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
        Me.ClientSize = New System.Drawing.Size(584, 406)
        Me.Controls.Add(Me.DataGrid1)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "Form2"
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Public Sub showproperty(ByVal parent As Windows.Forms.Form, ByVal PropDatas As DataSet)
        Me.DataSource = PropDatas
        Me.DataGrid1.DataSource = DataSource
        DataGrid1.Visible = True
        ListBox1.Visible = False
        Me.ShowDialog(parent)
    End Sub

    Public Sub showproperty(ByVal parent As Windows.Forms.Form, ByVal PropDatas As String())
        Me.ListBox1.DataSource = PropDatas
        DataGrid1.Visible = False
        ListBox1.Visible = True
        Me.ShowDialog(parent)
    End Sub


    Private Sub mnuCsvOutput_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCsvOutput.Click
        If Me.DataSource Is Nothing OrElse Me.DataSource.Tables.Count = 0 Then
            Return
        End If
        Dim frmSave As New Form3
        'me.DataGrid1.DataSource
        frmSave.DataSource = Me.DataSource.Tables(0)
        frmSave.ShowDialog(Me)
    End Sub
End Class
