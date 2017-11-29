Imports SQLViewer.DBAccess.DBSchema
Imports Env = SQLViewer.DBAccess.Common.Enviroment
Public Class frmLogin
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents txtServer As System.Windows.Forms.TextBox
    Friend WithEvents txtUser As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtService As System.Windows.Forms.TextBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogin))
        Me.txtServer = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtUser = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.txtService = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txtServer
        '
        Me.txtServer.Location = New System.Drawing.Point(104, 16)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.Size = New System.Drawing.Size(176, 19)
        Me.txtServer.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "サーバー"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "ユーザー名"
        '
        'txtUser
        '
        Me.txtUser.Location = New System.Drawing.Point(104, 48)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(176, 19)
        Me.txtUser.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 83)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 12)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "パスワード"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(104, 80)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(176, 19)
        Me.txtPassword.TabIndex = 5
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(128, 152)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(72, 24)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "ログイン"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(216, 152)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(72, 24)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "キャンセル"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 117)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 12)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "サービス名"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "")
        '
        'txtService
        '
        Me.txtService.Location = New System.Drawing.Point(104, 114)
        Me.txtService.Name = "txtService"
        Me.txtService.Size = New System.Drawing.Size(180, 19)
        Me.txtService.TabIndex = 10
        '
        'frmLogin
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
        Me.ClientSize = New System.Drawing.Size(296, 190)
        Me.Controls.Add(Me.txtService)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtUser)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtServer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Oracle ログイン"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    'Private mConnectString As String = "data source={0};password={1};persist security info=True;user id={2};packet size=4096"
    Private mConnectString As String = "DATA SOURCE=(DESCRIPTION = (ADDRESS_LIST =(ADDRESS = (PROTOCOL = TCP)(HOST = {0})(PORT = 1521)))(CONNECT_DATA =(SERVER = DEDICATED)(SERVICE_NAME = {1})));PASSWORD={2};PERSIST SECURITY INFO=True;USER ID={3}"
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim host As String = Me.txtServer.Text
        Dim user As String = Me.txtUser.Text
        Dim password As String = Me.txtPassword.Text
        Dim DefaultDB As String = ""
        Dim service As String = Me.txtService.Text

        Dim conn As String = String.Format(mConnectString, host, service, password, user)
        Try
            Dim dbs As New SQLViewer.DBAccess.DataBase.OraSqlServer(conn)
            Env.ConnectString = conn
            Env.SetSetting("server", host)
            Env.SetSetting("userid", user)
            Env.SetSetting("psw", password)
            Env.SetSetting("service", service)
            MyBase.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub


    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtServer.Text = Env.GetSetting("server")
        Me.txtUser.Text = Env.GetSetting("userid")
        Me.txtPassword.Text = Env.GetSetting("psw")
        Me.txtService.Text = Env.GetSetting("service")
        Dim conn As String = String.Format(mConnectString, txtServer.Text, Me.txtService.Text, Me.txtPassword.Text, Me.txtUser.Text)
        Me.TryDatabase(conn)
    End Sub
  

  
    Private Function TryDatabase(ByVal conn As String) As Boolean

        Try
            Dim dbs As New SQLViewer.DBAccess.DataBase.OraSqlServer(conn)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
End Class
