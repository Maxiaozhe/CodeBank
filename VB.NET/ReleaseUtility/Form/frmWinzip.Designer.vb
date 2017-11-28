<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWinzip
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

    'Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使用して変更できます。  
    'コード エディタを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmWinzip))
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker
        Me.chkTop = New System.Windows.Forms.CheckBox
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btnRelease = New System.Windows.Forms.ToolStripButton
        Me.btnWinZip = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.btnNewFloder = New System.Windows.Forms.ToolStripButton
        Me.btnDelete = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSplitButton1 = New System.Windows.Forms.ToolStripSeparator
        Me.lstTemplate = New System.Windows.Forms.ToolStripDropDownButton
        Me.btnSaveTemp = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.btnOption = New System.Windows.Forms.ToolStripButton
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ProgressBar1 = New System.Windows.Forms.ToolStripProgressBar
        Me.LblProgressMsg = New System.Windows.Forms.ToolStripStatusLabel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.FileView = New ReleaseUtility.FileView
        Me.ToolStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'chkTop
        '
        Me.chkTop.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkTop.AutoSize = True
        Me.chkTop.BackColor = System.Drawing.Color.WhiteSmoke
        Me.chkTop.Location = New System.Drawing.Point(693, 8)
        Me.chkTop.Name = "chkTop"
        Me.chkTop.Size = New System.Drawing.Size(93, 16)
        Me.chkTop.TabIndex = 7
        Me.chkTop.Text = "常にトップ表示"
        Me.chkTop.UseVisualStyleBackColor = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnRelease, Me.btnWinZip, Me.ToolStripSeparator1, Me.btnNewFloder, Me.btnDelete, Me.ToolStripSplitButton1, Me.lstTemplate, Me.btnSaveTemp, Me.ToolStripSeparator2, Me.btnOption})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 2)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(675, 25)
        Me.ToolStrip1.TabIndex = 8
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnRelease
        '
        Me.btnRelease.Image = Global.ReleaseUtility.My.Resources.Resources.Release
        Me.btnRelease.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRelease.Name = "btnRelease"
        Me.btnRelease.Size = New System.Drawing.Size(76, 22)
        Me.btnRelease.Text = "リリース"
        '
        'btnWinZip
        '
        Me.btnWinZip.Image = Global.ReleaseUtility.My.Resources.Resources.Winzip
        Me.btnWinZip.ImageTransparentColor = System.Drawing.Color.White
        Me.btnWinZip.Name = "btnWinZip"
        Me.btnWinZip.Size = New System.Drawing.Size(52, 22)
        Me.btnWinZip.Text = "圧縮"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btnNewFloder
        '
        Me.btnNewFloder.Image = Global.ReleaseUtility.My.Resources.Resources.AddFolder
        Me.btnNewFloder.ImageTransparentColor = System.Drawing.Color.White
        Me.btnNewFloder.Name = "btnNewFloder"
        Me.btnNewFloder.Size = New System.Drawing.Size(100, 22)
        Me.btnNewFloder.Text = "新規フォルダ"
        '
        'btnDelete
        '
        Me.btnDelete.Image = Global.ReleaseUtility.My.Resources.Resources.Delete
        Me.btnDelete.ImageTransparentColor = System.Drawing.Color.White
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(52, 22)
        Me.btnDelete.Text = "削除"
        '
        'ToolStripSplitButton1
        '
        Me.ToolStripSplitButton1.Name = "ToolStripSplitButton1"
        Me.ToolStripSplitButton1.Size = New System.Drawing.Size(6, 25)
        '
        'lstTemplate
        '
        Me.lstTemplate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.lstTemplate.Image = CType(resources.GetObject("lstTemplate.Image"), System.Drawing.Image)
        Me.lstTemplate.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.lstTemplate.Name = "lstTemplate"
        Me.lstTemplate.Size = New System.Drawing.Size(117, 22)
        Me.lstTemplate.Text = "テンプレート追加"
        '
        'btnSaveTemp
        '
        Me.btnSaveTemp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnSaveTemp.Image = CType(resources.GetObject("btnSaveTemp.Image"), System.Drawing.Image)
        Me.btnSaveTemp.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSaveTemp.Name = "btnSaveTemp"
        Me.btnSaveTemp.Size = New System.Drawing.Size(120, 22)
        Me.btnSaveTemp.Text = "テンプレート保存..."
        Me.btnSaveTemp.ToolTipText = "テンプレート保存..."
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'btnOption
        '
        Me.btnOption.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnOption.Image = CType(resources.GetObject("btnOption.Image"), System.Drawing.Image)
        Me.btnOption.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnOption.Name = "btnOption"
        Me.btnOption.Size = New System.Drawing.Size(108, 22)
        Me.btnOption.Text = "オプション設定..."
        Me.btnOption.ToolTipText = "オプション設定"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProgressBar1, Me.LblProgressMsg})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 541)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(798, 22)
        Me.StatusStrip1.TabIndex = 9
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.AutoSize = False
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(200, 16)
        '
        'LblProgressMsg
        '
        Me.LblProgressMsg.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
        Me.LblProgressMsg.Name = "LblProgressMsg"
        Me.LblProgressMsg.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never
        Me.LblProgressMsg.Size = New System.Drawing.Size(0, 17)
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.chkTop)
        Me.Panel1.Controls.Add(Me.ToolStrip1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(798, 31)
        Me.Panel1.TabIndex = 10
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.BalloonTipTitle = "リリースツール"
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "リリースツール"
        Me.NotifyIcon1.Visible = True
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.Filter = "テンプレートファイル(*.RUT)|*.RUT"
        Me.SaveFileDialog1.Title = "テンプレートファイルの出力場所を指定してください"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Filter = "テンプレートファイル(*.RUT)|*.RUT"
        Me.OpenFileDialog1.Title = "テンプレートファイルを選択"
        '
        'FileView
        '
        Me.FileView.AllowDrop = True
        Me.FileView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FileView.ImageIndex = 0
        Me.FileView.LabelEdit = True
        Me.FileView.Location = New System.Drawing.Point(0, 34)
        Me.FileView.Name = "FileView"
        Me.FileView.SelectedImageIndex = 0
        Me.FileView.ShowNodeToolTips = True
        Me.FileView.Size = New System.Drawing.Size(798, 505)
        Me.FileView.TabIndex = 3
        '
        'frmWinzip
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(798, 563)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.FileView)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(800, 600)
        Me.Name = "frmWinzip"
        Me.Text = "リリースツール"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FileView As FileView
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents chkTop As System.Windows.Forms.CheckBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnNewFloder As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnOption As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnWinZip As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents LblProgressMsg As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents ToolStripSplitButton1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnSaveTemp As System.Windows.Forms.ToolStripButton
    Friend WithEvents lstTemplate As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents btnRelease As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog

End Class
