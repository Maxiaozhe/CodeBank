<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class XPathTest
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLoad = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSaveGif = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTool = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDXLExport = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.PropertyGrid1 = New System.Windows.Forms.PropertyGrid()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(395, 29)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(55, 22)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Select"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(82, 31)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(307, 19)
        Me.TextBox1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 12)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "XPath:"
        '
        'TreeView1
        '
        Me.TreeView1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TreeView1.Location = New System.Drawing.Point(24, 57)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(365, 574)
        Me.TreeView1.TabIndex = 3
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(456, 28)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(55, 22)
        Me.btnSave.TabIndex = 4
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(517, 29)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(55, 22)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "SaveGif"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile, Me.mnuTool})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(891, 26)
        Me.MenuStrip1.TabIndex = 6
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mnuFile
        '
        Me.mnuFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuLoad, Me.mnuSaveGif})
        Me.mnuFile.Name = "mnuFile"
        Me.mnuFile.Size = New System.Drawing.Size(68, 22)
        Me.mnuFile.Text = "ファイル"
        '
        'mnuLoad
        '
        Me.mnuLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.mnuLoad.Name = "mnuLoad"
        Me.mnuLoad.Size = New System.Drawing.Size(157, 22)
        Me.mnuLoad.Text = "読み取り"
        '
        'mnuSaveGif
        '
        Me.mnuSaveGif.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.mnuSaveGif.Name = "mnuSaveGif"
        Me.mnuSaveGif.Size = New System.Drawing.Size(157, 22)
        Me.mnuSaveGif.Text = "GIFを保存する"
        '
        'mnuTool
        '
        Me.mnuTool.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDXLExport})
        Me.mnuTool.Name = "mnuTool"
        Me.mnuTool.Size = New System.Drawing.Size(56, 22)
        Me.mnuTool.Text = "ツール"
        '
        'mnuDXLExport
        '
        Me.mnuDXLExport.Name = "mnuDXLExport"
        Me.mnuDXLExport.Size = New System.Drawing.Size(172, 22)
        Me.mnuDXLExport.Text = "DXLエクスポート"
        '
        'PropertyGrid1
        '
        Me.PropertyGrid1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PropertyGrid1.Location = New System.Drawing.Point(411, 65)
        Me.PropertyGrid1.Name = "PropertyGrid1"
        Me.PropertyGrid1.Size = New System.Drawing.Size(464, 565)
        Me.PropertyGrid1.TabIndex = 7
        '
        'XPathTest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(891, 643)
        Me.Controls.Add(Me.PropertyGrid1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.TreeView1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "XPathTest"
        Me.Text = "XLSTTest"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLoad As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSaveGif As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents mnuTool As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDXLExport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PropertyGrid1 As System.Windows.Forms.PropertyGrid
End Class
