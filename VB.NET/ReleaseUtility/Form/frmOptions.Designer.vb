<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOptions
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
        Me.txtFileFilter = New System.Windows.Forms.TextBox
        Me.txtOutput = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnSelect = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmbFormat = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmbExt = New System.Windows.Forms.ComboBox
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.Button1 = New System.Windows.Forms.Button
        Me.txtWinrar = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.txtFoldFilter = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtSuffix = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtPerfix = New System.Windows.Forms.TextBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txtReleaseSuffix = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.cmbReleaseFormat = New System.Windows.Forms.ComboBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtReleasePerfix = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.btnReleaseSelect = New System.Windows.Forms.Button
        Me.txtReleaseFolder = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "下記ファイルのみ取り扱う"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtFileFilter
        '
        Me.txtFileFilter.Location = New System.Drawing.Point(10, 90)
        Me.txtFileFilter.Name = "txtFileFilter"
        Me.txtFileFilter.Size = New System.Drawing.Size(507, 19)
        Me.txtFileFilter.TabIndex = 1
        '
        'txtOutput
        '
        Me.txtOutput.Location = New System.Drawing.Point(86, 22)
        Me.txtOutput.Name = "txtOutput"
        Me.txtOutput.Size = New System.Drawing.Size(404, 19)
        Me.txtOutput.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "出力フォルダ："
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnSelect
        '
        Me.btnSelect.Location = New System.Drawing.Point(496, 23)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(20, 20)
        Me.btnSelect.TabIndex = 4
        Me.btnSelect.Text = "..."
        Me.btnSelect.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 12)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "命名方法："
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(186, 79)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(17, 12)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "＋"
        '
        'cmbFormat
        '
        Me.cmbFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFormat.FormattingEnabled = True
        Me.cmbFormat.Items.AddRange(New Object() {"yyyyMMdd_HHmm", "yyyyMMdd_HHmmss", "yyyyMMdd-HHmm", "yyyyMMdd-HHmmss", "yyyyMMddHHmmss", "yyyyMMddHHmm", "yyyyMMddHH", "yyyyMMdd", "yyMMdd_HHmmss", "yyMMdd_HHmm", "yyMMdd_HH", "yyMMdd-HHmmss", "yyMMdd-HHmm", "yyMMdd-HH", "yyMMddHHmmss", "yyMMddHHmm", "yyMMddHH", "yyMMdd", "なし"})
        Me.cmbFormat.Location = New System.Drawing.Point(203, 75)
        Me.cmbFormat.Name = "cmbFormat"
        Me.cmbFormat.Size = New System.Drawing.Size(121, 20)
        Me.cmbFormat.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(441, 79)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(17, 12)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "＋"
        '
        'cmbExt
        '
        Me.cmbExt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbExt.FormattingEnabled = True
        Me.cmbExt.Items.AddRange(New Object() {"zip", "rar"})
        Me.cmbExt.Location = New System.Drawing.Point(458, 75)
        Me.cmbExt.Name = "cmbExt"
        Me.cmbExt.Size = New System.Drawing.Size(58, 20)
        Me.cmbExt.TabIndex = 10
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(371, 363)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 11
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(458, 363)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 12
        Me.btnCancel.Text = "キャンセル"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(496, 48)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(20, 20)
        Me.Button1.TabIndex = 15
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtWinrar
        '
        Me.txtWinrar.Location = New System.Drawing.Point(86, 49)
        Me.txtWinrar.Name = "txtWinrar"
        Me.txtWinrar.Size = New System.Drawing.Size(404, 19)
        Me.txtWinrar.TabIndex = 14
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(10, 50)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 12)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "WinRAR："
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(11, 105)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 12)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "パスワード："
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(86, 102)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(143, 19)
        Me.txtPassword.TabIndex = 17
        '
        'txtFoldFilter
        '
        Me.txtFoldFilter.Location = New System.Drawing.Point(10, 41)
        Me.txtFoldFilter.Name = "txtFoldFilter"
        Me.txtFoldFilter.Size = New System.Drawing.Size(507, 19)
        Me.txtFoldFilter.TabIndex = 19
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(8, 20)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(149, 12)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "下記フォルダフィルタを無視する"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GroupBox1.Controls.Add(Me.txtFoldFilter)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtFileFilter)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(533, 129)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "フィルター設定"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GroupBox2.Controls.Add(Me.txtSuffix)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.txtPassword)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.txtWinrar)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.cmbExt)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.cmbFormat)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtPerfix)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.btnSelect)
        Me.GroupBox2.Controls.Add(Me.txtOutput)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 139)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(532, 133)
        Me.GroupBox2.TabIndex = 21
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "圧縮設定"
        '
        'txtSuffix
        '
        Me.txtSuffix.Location = New System.Drawing.Point(341, 76)
        Me.txtSuffix.Name = "txtSuffix"
        Me.txtSuffix.Size = New System.Drawing.Size(100, 19)
        Me.txtSuffix.TabIndex = 19
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(324, 79)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(17, 12)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "＋"
        '
        'txtPerfix
        '
        Me.txtPerfix.Location = New System.Drawing.Point(86, 76)
        Me.txtPerfix.Name = "txtPerfix"
        Me.txtPerfix.Size = New System.Drawing.Size(100, 19)
        Me.txtPerfix.TabIndex = 6
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GroupBox3.Controls.Add(Me.txtReleaseSuffix)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.cmbReleaseFormat)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.txtReleasePerfix)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.btnReleaseSelect)
        Me.GroupBox3.Controls.Add(Me.txtReleaseFolder)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Location = New System.Drawing.Point(5, 278)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(532, 79)
        Me.GroupBox3.TabIndex = 22
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "発行設定"
        '
        'txtReleaseSuffix
        '
        Me.txtReleaseSuffix.Location = New System.Drawing.Point(341, 48)
        Me.txtReleaseSuffix.Name = "txtReleaseSuffix"
        Me.txtReleaseSuffix.Size = New System.Drawing.Size(100, 19)
        Me.txtReleaseSuffix.TabIndex = 19
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(324, 51)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(17, 12)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "＋"
        '
        'cmbReleaseFormat
        '
        Me.cmbReleaseFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbReleaseFormat.FormattingEnabled = True
        Me.cmbReleaseFormat.Items.AddRange(New Object() {"yyyyMMdd_HHmm", "yyyyMMdd_HHmmss", "yyyyMMdd-HHmm", "yyyyMMdd-HHmmss", "yyyyMMddHHmmss", "yyyyMMddHHmm", "yyyyMMddHH", "yyyyMMdd", "yyMMdd_HHmmss", "yyMMdd_HHmm", "yyMMdd_HH", "yyMMdd-HHmmss", "yyMMdd-HHmm", "yyMMdd-HH", "yyMMddHHmmss", "yyMMddHHmm", "yyMMddHH", "yyMMdd", "なし"})
        Me.cmbReleaseFormat.Location = New System.Drawing.Point(203, 47)
        Me.cmbReleaseFormat.Name = "cmbReleaseFormat"
        Me.cmbReleaseFormat.Size = New System.Drawing.Size(121, 20)
        Me.cmbReleaseFormat.TabIndex = 8
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(186, 51)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(17, 12)
        Me.Label14.TabIndex = 7
        Me.Label14.Text = "＋"
        '
        'txtReleasePerfix
        '
        Me.txtReleasePerfix.Location = New System.Drawing.Point(86, 48)
        Me.txtReleasePerfix.Name = "txtReleasePerfix"
        Me.txtReleasePerfix.Size = New System.Drawing.Size(100, 19)
        Me.txtReleasePerfix.TabIndex = 6
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(10, 48)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(59, 12)
        Me.Label15.TabIndex = 5
        Me.Label15.Text = "命名方法："
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnReleaseSelect
        '
        Me.btnReleaseSelect.Location = New System.Drawing.Point(496, 23)
        Me.btnReleaseSelect.Name = "btnReleaseSelect"
        Me.btnReleaseSelect.Size = New System.Drawing.Size(20, 20)
        Me.btnReleaseSelect.TabIndex = 4
        Me.btnReleaseSelect.Text = "..."
        Me.btnReleaseSelect.UseVisualStyleBackColor = True
        '
        'txtReleaseFolder
        '
        Me.txtReleaseFolder.Location = New System.Drawing.Point(86, 22)
        Me.txtReleaseFolder.Name = "txtReleaseFolder"
        Me.txtReleaseFolder.Size = New System.Drawing.Size(404, 19)
        Me.txtReleaseFolder.TabIndex = 3
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(10, 23)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(70, 12)
        Me.Label16.TabIndex = 2
        Me.Label16.Text = "出力フォルダ："
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmOptions
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(545, 396)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOptions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "オプション設定"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFileFilter As System.Windows.Forms.TextBox
    Friend WithEvents txtOutput As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnSelect As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbFormat As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbExt As System.Windows.Forms.ComboBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtWinrar As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtFoldFilter As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtSuffix As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtPerfix As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtReleaseSuffix As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmbReleaseFormat As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtReleasePerfix As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents btnReleaseSelect As System.Windows.Forms.Button
    Friend WithEvents txtReleaseFolder As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
End Class
