Public Class SqlObjView
    Inherits System.Windows.Forms.UserControl

#Region " Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h "

    Public Sub New()
        MyBase.New()

        ' ���̌Ăяo���� Windows �t�H�[�� �f�U�C�i�ŕK�v�ł��B
        InitializeComponent()

        ' InitializeComponent() �Ăяo���̌�ɏ�������ǉ����܂��B

    End Sub

    'UserControl �̓R���|�[�l���g�ꗗ���������邽�߂� dispose ���I�[�o�[���C�h���܂��B
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' Windows �t�H�[�� �f�U�C�i�ŕK�v�ł��B
    Private components As System.ComponentModel.IContainer

    ' ���� : �ȉ��̃v���V�[�W���́AWindows �t�H�[�� �f�U�C�i�ŕK�v�ł��B
    ' Windows �t�H�[�� �f�U�C�i���g���ĕύX���Ă��������B  
    ' �R�[�h �G�f�B�^�͎g�p���Ȃ��ł��������B
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
