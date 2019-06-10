<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExporter
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
        Me.btnSelectFile = New System.Windows.Forms.Button
        Me.txtFile = New System.Windows.Forms.TextBox
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.btnOutput = New System.Windows.Forms.Button
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.btnDetail = New System.Windows.Forms.Button
        Me.txtLog = New System.Windows.Forms.TextBox
        Me.btnReport = New System.Windows.Forms.Button
        Me.lblLogTitle = New System.Windows.Forms.Label
        Me.lblLog = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'btnSelectFile
        '
        Me.btnSelectFile.Location = New System.Drawing.Point(470, 14)
        Me.btnSelectFile.Name = "btnSelectFile"
        Me.btnSelectFile.Size = New System.Drawing.Size(52, 23)
        Me.btnSelectFile.TabIndex = 0
        Me.btnSelectFile.Text = "選択"
        Me.btnSelectFile.UseVisualStyleBackColor = True
        '
        'txtFile
        '
        Me.txtFile.Location = New System.Drawing.Point(13, 16)
        Me.txtFile.Name = "txtFile"
        Me.txtFile.Size = New System.Drawing.Size(451, 19)
        Me.txtFile.TabIndex = 1
        '
        'btnOutput
        '
        Me.btnOutput.Location = New System.Drawing.Point(13, 41)
        Me.btnOutput.Name = "btnOutput"
        Me.btnOutput.Size = New System.Drawing.Size(85, 23)
        Me.btnOutput.TabIndex = 2
        Me.btnOutput.Text = "出力する "
        Me.btnOutput.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(13, 70)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(509, 12)
        Me.ProgressBar1.TabIndex = 3
        '
        'btnDetail
        '
        Me.btnDetail.Location = New System.Drawing.Point(437, 88)
        Me.btnDetail.Name = "btnDetail"
        Me.btnDetail.Size = New System.Drawing.Size(85, 23)
        Me.btnDetail.TabIndex = 4
        Me.btnDetail.Text = "詳細 >>"
        Me.btnDetail.UseVisualStyleBackColor = True
        '
        'txtLog
        '
        Me.txtLog.BackColor = System.Drawing.Color.White
        Me.txtLog.Location = New System.Drawing.Point(15, 117)
        Me.txtLog.MaxLength = 268435455
        Me.txtLog.Multiline = True
        Me.txtLog.Name = "txtLog"
        Me.txtLog.ReadOnly = True
        Me.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtLog.Size = New System.Drawing.Size(507, 282)
        Me.txtLog.TabIndex = 5
        '
        'btnReport
        '
        Me.btnReport.Location = New System.Drawing.Point(437, 43)
        Me.btnReport.Name = "btnReport"
        Me.btnReport.Size = New System.Drawing.Size(85, 23)
        Me.btnReport.TabIndex = 6
        Me.btnReport.Text = "報告"
        Me.btnReport.UseVisualStyleBackColor = True
        '
        'lblLogTitle
        '
        Me.lblLogTitle.AutoSize = True
        Me.lblLogTitle.Location = New System.Drawing.Point(13, 96)
        Me.lblLogTitle.Name = "lblLogTitle"
        Me.lblLogTitle.Size = New System.Drawing.Size(47, 12)
        Me.lblLogTitle.TabIndex = 7
        Me.lblLogTitle.Text = "処理ログ"
        '
        'lblLog
        '
        Me.lblLog.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblLog.Location = New System.Drawing.Point(13, 89)
        Me.lblLog.Name = "lblLog"
        Me.lblLog.Size = New System.Drawing.Size(418, 20)
        Me.lblLog.TabIndex = 8
        '
        'frmExporter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(529, 405)
        Me.Controls.Add(Me.lblLog)
        Me.Controls.Add(Me.lblLogTitle)
        Me.Controls.Add(Me.btnReport)
        Me.Controls.Add(Me.txtLog)
        Me.Controls.Add(Me.btnDetail)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.btnOutput)
        Me.Controls.Add(Me.txtFile)
        Me.Controls.Add(Me.btnSelectFile)
        Me.MaximizeBox = False
        Me.Name = "frmExporter"
        Me.Text = "ファイル出力画面"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSelectFile As System.Windows.Forms.Button
    Friend WithEvents txtFile As System.Windows.Forms.TextBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnOutput As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents btnDetail As System.Windows.Forms.Button
    Friend WithEvents txtLog As System.Windows.Forms.TextBox
    Friend WithEvents btnReport As System.Windows.Forms.Button
    Friend WithEvents lblLogTitle As System.Windows.Forms.Label
    Friend WithEvents lblLog As System.Windows.Forms.Label

End Class
