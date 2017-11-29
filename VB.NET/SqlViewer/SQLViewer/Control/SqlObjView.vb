Public Class SqlObjView
    Inherits System.Windows.Forms.UserControl

#Region " Windows フォーム デザイナで生成されたコード "

    Public Sub New()
        MyBase.New()

        ' この呼び出しは Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後に初期化を追加します。

    End Sub

    'UserControl はコンポーネント一覧を消去するために dispose をオーバーライドします。
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
    Friend WithEvents dtgView As System.Windows.Forms.DataGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.dtgView = New System.Windows.Forms.DataGrid()
        CType(Me.dtgView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtgView
        '
        Me.dtgView.DataMember = ""
        Me.dtgView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtgView.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dtgView.Name = "dtgView"
        Me.dtgView.Size = New System.Drawing.Size(632, 496)
        Me.dtgView.TabIndex = 0
        '
        'SqlObjView
        '
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.dtgView})
        Me.Name = "SqlObjView"
        Me.Size = New System.Drawing.Size(632, 496)
        CType(Me.dtgView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

End Class
