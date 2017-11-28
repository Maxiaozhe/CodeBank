<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form4
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
        Me.Button1 = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.txtServer = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtUser = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtPsw = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtDB = New System.Windows.Forms.TextBox
        Me.lblSdid = New System.Windows.Forms.Label
        Me.txtSdid = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkWindows = New System.Windows.Forms.CheckBox
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(118, 64)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "GetLength"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(12, 26)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 19)
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.Text = "10"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(12, 66)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(100, 19)
        Me.TextBox2.TabIndex = 2
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(155, 188)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "検索 >"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'txtServer
        '
        Me.txtServer.Location = New System.Drawing.Point(70, 12)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.Size = New System.Drawing.Size(270, 19)
        Me.txtServer.TabIndex = 4
        Me.txtServer.Text = "rr95"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 12)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Server"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 12)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "User"
        '
        'txtUser
        '
        Me.txtUser.Location = New System.Drawing.Point(70, 37)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(100, 19)
        Me.txtUser.TabIndex = 6
        Me.txtUser.Text = "sa"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 12)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Password"
        '
        'txtPsw
        '
        Me.txtPsw.Location = New System.Drawing.Point(70, 62)
        Me.txtPsw.Name = "txtPsw"
        Me.txtPsw.Size = New System.Drawing.Size(100, 19)
        Me.txtPsw.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(21, 12)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "DB"
        '
        'txtDB
        '
        Me.txtDB.Location = New System.Drawing.Point(70, 87)
        Me.txtDB.Name = "txtDB"
        Me.txtDB.Size = New System.Drawing.Size(270, 19)
        Me.txtDB.TabIndex = 10
        Me.txtDB.Text = "SharedServices1_Search_DB"
        '
        'lblSdid
        '
        Me.lblSdid.AutoSize = True
        Me.lblSdid.Location = New System.Drawing.Point(10, 191)
        Me.lblSdid.Name = "lblSdid"
        Me.lblSdid.Size = New System.Drawing.Size(26, 12)
        Me.lblSdid.TabIndex = 13
        Me.lblSdid.Text = "sdid"
        '
        'txtSdid
        '
        Me.txtSdid.Location = New System.Drawing.Point(49, 188)
        Me.txtSdid.Name = "txtSdid"
        Me.txtSdid.Size = New System.Drawing.Size(100, 19)
        Me.txtSdid.TabIndex = 12
        Me.txtSdid.Text = "1"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkWindows)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtDB)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtPsw)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtUser)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtServer)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(346, 150)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "DB接続設定"
        '
        'chkWindows
        '
        Me.chkWindows.AutoSize = True
        Me.chkWindows.Location = New System.Drawing.Point(8, 120)
        Me.chkWindows.Name = "chkWindows"
        Me.chkWindows.Size = New System.Drawing.Size(144, 16)
        Me.chkWindows.TabIndex = 12
        Me.chkWindows.Text = "Windows認証を使用する"
        Me.chkWindows.UseVisualStyleBackColor = True
        '
        'Form4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(362, 250)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblSdid)
        Me.Controls.Add(Me.txtSdid)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form4"
        Me.Text = "MossSearchDB ACL解析"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents txtServer As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtUser As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPsw As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDB As System.Windows.Forms.TextBox
    Friend WithEvents lblSdid As System.Windows.Forms.Label
    Friend WithEvents txtSdid As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkWindows As System.Windows.Forms.CheckBox
End Class
