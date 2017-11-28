<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class XlstTest
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
        Me.txtDxl = New System.Windows.Forms.TextBox()
        Me.txtXSLT = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnDXL = New System.Windows.Forms.Button()
        Me.btnXSL = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.btnTransfer = New System.Windows.Forms.Button()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.SuspendLayout()
        '
        'txtDxl
        '
        Me.txtDxl.Location = New System.Drawing.Point(106, 22)
        Me.txtDxl.Name = "txtDxl"
        Me.txtDxl.Size = New System.Drawing.Size(361, 19)
        Me.txtDxl.TabIndex = 0
        '
        'txtXSLT
        '
        Me.txtXSLT.Location = New System.Drawing.Point(106, 48)
        Me.txtXSLT.Name = "txtXSLT"
        Me.txtXSLT.Size = New System.Drawing.Size(361, 19)
        Me.txtXSLT.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(31, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 12)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "DXLファイル"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(33, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "XSLTファイル"
        '
        'btnDXL
        '
        Me.btnDXL.Location = New System.Drawing.Point(473, 21)
        Me.btnDXL.Name = "btnDXL"
        Me.btnDXL.Size = New System.Drawing.Size(27, 21)
        Me.btnDXL.TabIndex = 4
        Me.btnDXL.Text = "..."
        Me.btnDXL.UseVisualStyleBackColor = True
        '
        'btnXSL
        '
        Me.btnXSL.Location = New System.Drawing.Point(473, 46)
        Me.btnXSL.Name = "btnXSL"
        Me.btnXSL.Size = New System.Drawing.Size(27, 21)
        Me.btnXSL.TabIndex = 5
        Me.btnXSL.Text = "..."
        Me.btnXSL.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'btnTransfer
        '
        Me.btnTransfer.Location = New System.Drawing.Point(517, 45)
        Me.btnTransfer.Name = "btnTransfer"
        Me.btnTransfer.Size = New System.Drawing.Size(63, 22)
        Me.btnTransfer.TabIndex = 6
        Me.btnTransfer.Text = "変換"
        Me.btnTransfer.UseVisualStyleBackColor = True
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Location = New System.Drawing.Point(26, 97)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(631, 537)
        Me.WebBrowser1.TabIndex = 7
        '
        'XlstTest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(679, 652)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Controls.Add(Me.btnTransfer)
        Me.Controls.Add(Me.btnXSL)
        Me.Controls.Add(Me.btnDXL)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtXSLT)
        Me.Controls.Add(Me.txtDxl)
        Me.Name = "XlstTest"
        Me.Text = "XlstTest"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtDxl As System.Windows.Forms.TextBox
    Friend WithEvents txtXSLT As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnDXL As System.Windows.Forms.Button
    Friend WithEvents btnXSL As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnTransfer As System.Windows.Forms.Button
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
End Class
