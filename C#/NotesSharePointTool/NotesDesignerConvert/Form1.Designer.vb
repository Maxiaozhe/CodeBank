<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnOpen = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabForm = New System.Windows.Forms.TabPage()
        Me.treForm = New System.Windows.Forms.TreeView()
        Me.tabView = New System.Windows.Forms.TabPage()
        Me.treView = New System.Windows.Forms.TreeView()
        Me.tabDocument = New System.Windows.Forms.TabPage()
        Me.treeDoc = New System.Windows.Forms.TreeView()
        Me.PropertyGrid1 = New System.Windows.Forms.PropertyGrid()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tabForm.SuspendLayout()
        Me.tabView.SuspendLayout()
        Me.tabDocument.SuspendLayout()
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Filter = "データベースファイル|*.nsf"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnOpen, Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripButton3, Me.ToolStripButton4})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(766, 25)
        Me.ToolStrip1.TabIndex = 5
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnOpen
        '
        Me.btnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnOpen.Image = CType(resources.GetObject("btnOpen.Image"), System.Drawing.Image)
        Me.btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(108, 22)
        Me.btnOpen.Text = "データベース選択"
        Me.btnOpen.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(108, 22)
        Me.ToolStripButton1.Text = "DXLエクスポート"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(78, 22)
        Me.ToolStripButton2.Text = "XSLTで変換"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(60, 22)
        Me.ToolStripButton3.Text = "設計文書"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 25)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.TabControl1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.PropertyGrid1)
        Me.SplitContainer1.Size = New System.Drawing.Size(766, 564)
        Me.SplitContainer1.SplitterDistance = 307
        Me.SplitContainer1.SplitterWidth = 6
        Me.SplitContainer1.TabIndex = 6
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tabForm)
        Me.TabControl1.Controls.Add(Me.tabView)
        Me.TabControl1.Controls.Add(Me.tabDocument)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(307, 564)
        Me.TabControl1.TabIndex = 3
        '
        'tabForm
        '
        Me.tabForm.Controls.Add(Me.treForm)
        Me.tabForm.Location = New System.Drawing.Point(4, 22)
        Me.tabForm.Name = "tabForm"
        Me.tabForm.Padding = New System.Windows.Forms.Padding(3)
        Me.tabForm.Size = New System.Drawing.Size(299, 538)
        Me.tabForm.TabIndex = 0
        Me.tabForm.Text = "フォーム"
        Me.tabForm.UseVisualStyleBackColor = True
        '
        'treForm
        '
        Me.treForm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.treForm.Location = New System.Drawing.Point(3, 3)
        Me.treForm.Name = "treForm"
        Me.treForm.Size = New System.Drawing.Size(293, 532)
        Me.treForm.TabIndex = 0
        '
        'tabView
        '
        Me.tabView.Controls.Add(Me.treView)
        Me.tabView.Location = New System.Drawing.Point(4, 22)
        Me.tabView.Name = "tabView"
        Me.tabView.Padding = New System.Windows.Forms.Padding(3)
        Me.tabView.Size = New System.Drawing.Size(299, 538)
        Me.tabView.TabIndex = 1
        Me.tabView.Text = "ビュー"
        Me.tabView.UseVisualStyleBackColor = True
        '
        'treView
        '
        Me.treView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.treView.Location = New System.Drawing.Point(3, 3)
        Me.treView.Name = "treView"
        Me.treView.Size = New System.Drawing.Size(293, 532)
        Me.treView.TabIndex = 0
        '
        'tabDocument
        '
        Me.tabDocument.Controls.Add(Me.treeDoc)
        Me.tabDocument.Location = New System.Drawing.Point(4, 22)
        Me.tabDocument.Name = "tabDocument"
        Me.tabDocument.Size = New System.Drawing.Size(299, 538)
        Me.tabDocument.TabIndex = 2
        Me.tabDocument.Text = "設計文書"
        Me.tabDocument.UseVisualStyleBackColor = True
        '
        'treeDoc
        '
        Me.treeDoc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.treeDoc.Location = New System.Drawing.Point(0, 0)
        Me.treeDoc.Name = "treeDoc"
        Me.treeDoc.Size = New System.Drawing.Size(299, 538)
        Me.treeDoc.TabIndex = 0
        '
        'PropertyGrid1
        '
        Me.PropertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PropertyGrid1.Location = New System.Drawing.Point(0, 0)
        Me.PropertyGrid1.Name = "PropertyGrid1"
        Me.PropertyGrid1.Size = New System.Drawing.Size(453, 564)
        Me.PropertyGrid1.TabIndex = 2
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.DefaultExt = "dxl"
        Me.SaveFileDialog1.Filter = "DXLファイル(*.dxl)|*.dxl"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(51, 22)
        Me.ToolStripButton4.Text = "Server"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(766, 589)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.tabForm.ResumeLayout(False)
        Me.tabView.ResumeLayout(False)
        Me.tabDocument.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnOpen As System.Windows.Forms.ToolStripButton
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabForm As System.Windows.Forms.TabPage
    Friend WithEvents tabView As System.Windows.Forms.TabPage
    Friend WithEvents PropertyGrid1 As System.Windows.Forms.PropertyGrid
    Friend WithEvents treForm As System.Windows.Forms.TreeView
    Friend WithEvents treView As System.Windows.Forms.TreeView
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents tabDocument As System.Windows.Forms.TabPage
    Friend WithEvents treeDoc As System.Windows.Forms.TreeView
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton

End Class
