Imports SQLViewer.DBAccess.DBSchema
Public Class frmSelectObject
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
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmSelectObject))
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader()
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ListView1
        '
        Me.ListView1.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.HideSelection = False
        Me.ListView1.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(448, 472)
        Me.ListView1.SmallImageList = Me.ImageList1
        Me.ListView1.TabIndex = 0
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "名称"
        Me.ColumnHeader1.Width = 200
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "説明"
        Me.ColumnHeader2.Width = 244
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.White
        '
        'btnOK
        '
        Me.btnOK.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnOK.Location = New System.Drawing.Point(248, 488)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(88, 24)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "ＯＫ"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(344, 488)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(88, 24)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "キャンセル"
        '
        'frmSelectObject
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(448, 526)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCancel, Me.btnOK, Me.ListView1})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSelectObject"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "オブジェクト選択"
        Me.ResumeLayout(False)

    End Sub

#End Region
    Private mSqlObjects() As iSqlObject
    Private mSelectedsqlObjects() As iSqlObject
    Public WriteOnly Property SqlObjectList() As iSqlObject()
        Set(ByVal Value As iSqlObject())
            mSqlObjects = Value
        End Set
    End Property
    Public ReadOnly Property SelectedObjects() As iSqlObject()
        Get
            Return mSelectedsqlObjects
        End Get
    End Property

    Private Sub frmSelectObject_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitControls()
    End Sub
    Private Sub InitControls()
        Dim Sortmanger As New ListViewSortManager(Me.ListView1)
        Dim obj As iSqlObject = Nothing
        Me.ListView1.Items.Clear()
        For Each obj In Me.mSqlObjects
            Dim litem As New ListViewItem()
            litem.Text = obj.ObjName
            litem.Tag = obj
            Select Case obj.ObjType
                Case SqlObjectType.Table
                    litem.ImageIndex = ImageTypes.Table
                Case SqlObjectType.View
                    litem.ImageIndex = ImageTypes.View
                Case SqlObjectType.Function
                    If CType(obj, [Function]).Type = "IF" Then
                        litem.ImageIndex = ImageTypes.IFN
                    Else
                        litem.ImageIndex = ImageTypes.Fn
                    End If
                Case SqlObjectType.StoreProcedure
                    litem.ImageIndex = ImageTypes.Sp
                Case SqlObjectType.CateGoly
                    litem.ImageIndex = ImageTypes.Categoly
            End Select
            Me.ListView1.Items.Add(litem)
        Next
    End Sub
    Public Enum ImageTypes As Integer
        DataBase = 0
        Tables = 1
        Views = 2
        Sps = 3
        Functions = 4
        Table = 5
        View = 6
        Sp = 7
        Fn = 8
        IFN = 9
        Categoly = 10
    End Enum

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If Me.ListView1.SelectedItems.Count = 0 Then
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
            Return
        End If
        Me.DialogResult = DialogResult.OK
        Dim sqlObjs As New ArrayList()
        Dim item As ListViewItem = Nothing
        For Each item In Me.ListView1.SelectedItems
            sqlObjs.Add(item.Tag)
        Next
        Me.mSelectedsqlObjects = CType(sqlObjs.ToArray(GetType(iSqlObject)), iSqlObject())
        Me.Close()
    End Sub
End Class
