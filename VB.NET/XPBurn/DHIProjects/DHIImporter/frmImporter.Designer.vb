<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImporter
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbCdDriver = New System.Windows.Forms.ComboBox
        Me.btnImport = New System.Windows.Forms.Button
        Me.btnReport = New System.Windows.Forms.Button
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.btnDetail = New System.Windows.Forms.Button
        Me.txtLog = New System.Windows.Forms.TextBox
        Me.lblLog = New System.Windows.Forms.Label
        Me.lblLogTitle = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "CD ドライブ:"
        '
        'cmbCdDriver
        '
        Me.cmbCdDriver.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCdDriver.FormattingEnabled = True
        Me.cmbCdDriver.Location = New System.Drawing.Point(82, 13)
        Me.cmbCdDriver.Name = "cmbCdDriver"
        Me.cmbCdDriver.Size = New System.Drawing.Size(121, 20)
        Me.cmbCdDriver.TabIndex = 1
        '
        'btnImport
        '
        Me.btnImport.Location = New System.Drawing.Point(209, 13)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(75, 23)
        Me.btnImport.TabIndex = 2
        Me.btnImport.Text = "取り込み"
        Me.btnImport.UseVisualStyleBackColor = True
        '
        'btnReport
        '
        Me.btnReport.Location = New System.Drawing.Point(436, 41)
        Me.btnReport.Name = "btnReport"
        Me.btnReport.Size = New System.Drawing.Size(85, 23)
        Me.btnReport.TabIndex = 7
        Me.btnReport.Text = "報告"
        Me.btnReport.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 70)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(509, 12)
        Me.ProgressBar1.TabIndex = 8
        '
        'btnDetail
        '
        Me.btnDetail.Location = New System.Drawing.Point(436, 88)
        Me.btnDetail.Name = "btnDetail"
        Me.btnDetail.Size = New System.Drawing.Size(85, 23)
        Me.btnDetail.TabIndex = 9
        Me.btnDetail.Text = "詳細 >>"
        Me.btnDetail.UseVisualStyleBackColor = True
        '
        'txtLog
        '
        Me.txtLog.BackColor = System.Drawing.Color.White
        Me.txtLog.Location = New System.Drawing.Point(12, 117)
        Me.txtLog.MaxLength = 268435455
        Me.txtLog.Multiline = True
        Me.txtLog.Name = "txtLog"
        Me.txtLog.ReadOnly = True
        Me.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtLog.Size = New System.Drawing.Size(507, 282)
        Me.txtLog.TabIndex = 10
        '
        'lblLog
        '
        Me.lblLog.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblLog.Location = New System.Drawing.Point(12, 88)
        Me.lblLog.Name = "lblLog"
        Me.lblLog.Size = New System.Drawing.Size(418, 20)
        Me.lblLog.TabIndex = 11
        '
        'lblLogTitle
        '
        Me.lblLogTitle.AutoSize = True
        Me.lblLogTitle.Location = New System.Drawing.Point(13, 93)
        Me.lblLogTitle.Name = "lblLogTitle"
        Me.lblLogTitle.Size = New System.Drawing.Size(47, 12)
        Me.lblLogTitle.TabIndex = 12
        Me.lblLogTitle.Text = "処理ログ"
        '
        'frmImporter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(529, 404)
        Me.Controls.Add(Me.lblLogTitle)
        Me.Controls.Add(Me.lblLog)
        Me.Controls.Add(Me.txtLog)
        Me.Controls.Add(Me.btnDetail)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.btnReport)
        Me.Controls.Add(Me.btnImport)
        Me.Controls.Add(Me.cmbCdDriver)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.Name = "frmImporter"
        Me.Text = "ファイル取り込み"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbCdDriver As System.Windows.Forms.ComboBox
    Friend WithEvents btnImport As System.Windows.Forms.Button
    Friend WithEvents btnReport As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents btnDetail As System.Windows.Forms.Button
    Friend WithEvents txtLog As System.Windows.Forms.TextBox
    Friend WithEvents lblLog As System.Windows.Forms.Label
    Friend WithEvents lblLogTitle As System.Windows.Forms.Label

End Class
