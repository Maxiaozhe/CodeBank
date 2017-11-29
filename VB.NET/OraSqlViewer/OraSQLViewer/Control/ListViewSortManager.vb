Option Strict On
Option Explicit On 
Option Compare Binary
Imports System.Runtime.InteropServices
Public Class ListViewSortManager
#Region "Attribute"
    Private mlistView As ListView = Nothing
    Private mcolumn As Integer = 0
    Private msortOrder As SortOrder = SortOrder.None
    Private mimageList As ImageList = Nothing
#End Region
#Region "API Declare"
    Private Const LVM_FIRST As Int32 = &H1000
    Private Const LVM_GETHEADER As Int32 = LVM_FIRST + 31

    Private Const HDI_FORMAT As Int32 = &H4
    Private Const HDI_IMAGE As Int32 = &H20

    Private Const HDF_LEFT As Int32 = &H0
    Private Const HDF_RIGHT As Int32 = &H1
    Private Const HDF_CENTER As Int32 = &H2
    Private Const HDF_STRING As Int32 = &H4000
    Private Const HDF_BITMAP_ON_RIGHT As Int32 = &H1000
    Private Const HDF_IMAGE As Int32 = &H800

    Private Const HDM_FIRST As Int32 = &H1200
    Private Const HDM_SETIMAGELIST As Int32 = HDM_FIRST + 8
    Private Const HDM_SETITEM As Int32 = HDM_FIRST + 12
    <DllImport("user32")> _
    Private Shared Function SendMessage(ByVal Handle As IntPtr, ByVal msg As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
    End Function
    <DllImport("user32", EntryPoint:="SendMessage")> _
    Private Shared Function SendMessage2(ByVal Handle As IntPtr, ByVal msg As Integer, ByVal wParam As IntPtr, ByRef lParam As HDITEM) As IntPtr
    End Function
    <StructLayout(LayoutKind.Sequential)> _
    Private Structure HDITEM
        ' Fields
        Public mask As Int32
        Public cxy As Int32
        <MarshalAs(UnmanagedType.LPTStr)> _
        Public pszText As String
        Public hbm As IntPtr
        Public cchTextMax As Int32
        Public fmt As Int32
        Public lParam As Int32
        Public iImage As Int32
        Public iOrder As Int32
    End Structure

#End Region
#Region "Enum"
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' ���̎�ނ�\���܂��B
    ''' </summary>
    ''' -----------------------------------------------------------------------------
    Private Enum ArrowType
        ''' <summary>
        ''' �����̖��
        ''' </summary>
        Ascending
        ''' <summary>
        ''' �~���̖��
        ''' </summary>
        Descending
    End Enum
#End Region
#Region "Method"
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' ���X�g�r���[�}�l�W���[�̃C���X�^���X�𐶐�����B
    ''' </summary>
    ''' <param name="srclist">�Ǘ����郊�X�g�r���[�̃C���X�^���X</param>
    ''' -----------------------------------------------------------------------------
    Public Sub New(ByVal srclist As ListView)
        Me.mlistView = srclist
        Me.mcolumn = 0
        Me.msortOrder = SortOrder.None
        '���̃r�b�g�}�b�v�𐶐����āA�C���W���X�g�ɒǉ�����
        Me.mimageList = New ImageList()
        Me.mimageList.ImageSize = New Size(8, 8)
        Me.mimageList.TransparentColor = System.Drawing.Color.Magenta
        Me.mimageList.Images.Add(GetArrowBitmap(ArrowType.Ascending))
        Me.mimageList.Images.Add(GetArrowBitmap(ArrowType.Descending))
        '�w�b�_�̃C���[�W���X�g��ݒ肷��
        SetHeaderImageList(mimageList)
        '�J�����N���b�N�G�x���g���n���h�����O����B
        AddHandler mlistView.ColumnClick, AddressOf OnColumnClick
        '�\�[�g����
        Me.Sort(Me.mcolumn)
    End Sub
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' �w�b�_�̃C���[�W���X�g��ݒ肷��
    ''' </summary>
    ''' <param name="imgList">�C���[�W���X�g</param>
    ''' -----------------------------------------------------------------------------
    Public Sub SetHeaderImageList(ByVal imgList As ImageList)
        Dim hHeader As IntPtr = SendMessage(Me.mlistView.Handle, LVM_GETHEADER, IntPtr.Zero, IntPtr.Zero)
        Dim ret As IntPtr = SendMessage(hHeader, HDM_SETIMAGELIST, IntPtr.Zero, imgList.Handle)
    End Sub
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' ���X�g�r���[���\�[�g����
    ''' </summary>
    ''' <param name="column">�J�����̃C���f�B�N�X�l</param>
    ''' -----------------------------------------------------------------------------
    Private Sub Sort(ByVal column As Integer)
        If ((column < 0) OrElse (column >= Me.mlistView.Columns.Count)) Then
            Return
        End If
        If (column <> Me.mcolumn) Then
            Me.ShowHeaderIcon(Me.mcolumn, SortOrder.None)
            Me.mcolumn = column
            Me.msortOrder = SortOrder.Ascending
        Else
            Select Case Me.msortOrder
                Case SortOrder.None
                    Me.msortOrder = SortOrder.Ascending
                Case SortOrder.Ascending
                    Me.msortOrder = SortOrder.Descending
                Case SortOrder.Descending
                    Me.msortOrder = SortOrder.Ascending
            End Select
        End If
        Me.ShowHeaderIcon(Me.mcolumn, Me.msortOrder)
        Me.mlistView.ListViewItemSorter = New ListViewItemComparer(Me.mcolumn, Me.msortOrder)
    End Sub
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' �\�[�g���̃r�b�g�}�b�v���쐬����
    ''' </summary>
    ''' <param name="arrow">���̎��</param>
    ''' <returns>�r�b�g�}�b�v</returns>
    ''' -----------------------------------------------------------------------------
    Private Function GetArrowBitmap(ByVal arrow As ArrowType) As Bitmap
        Dim bmp As New Bitmap(8, 8)
        Dim gc As Graphics = Graphics.FromImage(bmp)
        Dim pen As Pen = System.Drawing.SystemPens.ControlDarkDark
        Dim brush As Brush = System.Drawing.SystemBrushes.ControlDarkDark
        Dim backBrush As Brush = System.Drawing.Brushes.Magenta
        gc.FillRectangle(backBrush, 0, 0, 8, 8)
        Dim pts() As Point = Nothing
        If arrow = ArrowType.Ascending Then
            pts = New Point() {New Point(1, 3), New Point(5, 3), New Point(3, 1)}
        Else
            pts = New Point() {New Point(1, 3), New Point(5, 3), New Point(3, 5)}
        End If
        gc.DrawPolygon(pen, pts)
        gc.FillPolygon(brush, pts)
        gc.Dispose()
        Return bmp
    End Function
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' ���X�g�r���[�̃w�b�_�Ƀ\�[�g���i�����j��\������
    ''' </summary>
    ''' <param name="columnIndex">�J�����̃C���f�B�N�X</param>
    ''' <param name="sortOrder">�\�[�g��</param>
    ''' -----------------------------------------------------------------------------
    Private Sub ShowHeaderIcon(ByVal columnIndex As Integer, ByVal sortOrder As SortOrder)
        If (columnIndex < 0) OrElse (columnIndex >= Me.mlistView.Columns.Count) Then
            Return
        End If
        Dim hHeader As IntPtr = SendMessage(Me.mlistView.Handle, LVM_GETHEADER, IntPtr.Zero, IntPtr.Zero)
        Dim colHeader As ColumnHeader = Me.mlistView.Columns.Item(columnIndex)
        Dim hd As HDITEM = New HDITEM()
        hd.mask = HDI_FORMAT
        Dim align As HorizontalAlignment = colHeader.TextAlign
        If align = HorizontalAlignment.Left Then
            hd.fmt = HDF_LEFT Or HDF_STRING Or HDF_BITMAP_ON_RIGHT
        ElseIf align = HorizontalAlignment.Center Then
            hd.fmt = HDF_CENTER Or HDF_STRING Or HDF_BITMAP_ON_RIGHT
        Else
            hd.fmt = HDF_RIGHT Or HDF_STRING
        End If
        hd.mask = hd.mask Or HDI_IMAGE

        If sortOrder <> sortOrder.None Then
            hd.fmt = hd.fmt Or HDF_IMAGE
        End If
        hd.iImage = CInt(sortOrder) - 1
        SendMessage2(hHeader, HDM_SETITEM, New IntPtr(columnIndex), hd)
    End Sub
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' ���X�g�r���[�̃w�b�_���N���b�N����Ƃ��A�\�[�g����������
    ''' </summary>
    ''' <param name="sender">�C�x���g�̃\�[�X�B</param>
    ''' <param name="e">�C�x���g �f�[�^���i�[���Ă���ColumnClickEventArgs</param>
    ''' -----------------------------------------------------------------------------
    Private Sub OnColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs)
        Try
            Dim column As Integer = e.Column
            Me.Sort(column)
        Catch ex As Exception
            'SKIP
        End Try
    End Sub

#End Region

End Class
''' -----------------------------------------------------------------------------
''' Project	 : RTS.Rabit.Options
''' Class	 : Rabit.Options.Component.ListViewItemComparer
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' ���X�g�r���[�̔�r�q�����J���܂��B  
''' </summary>
''' -----------------------------------------------------------------------------
Public Class ListViewItemComparer
    Implements IComparer
#Region "Attribute"
    Private col As Integer
    Private order As SortOrder = SortOrder.None
#End Region
#Region "Method"
    Public Sub New()
        col = 0
        order = SortOrder.None
    End Sub

    Public Sub New(ByVal column As Integer, ByVal sortorder As SortOrder)
        col = column
        order = sortorder
    End Sub
    '''  -----------------------------------------------------------------------------
    ''' <summary>
    '''  2 �̃I�u�W�F�N�g���r���A�����������菬�������A���������A�傫�����������l��Ԃ��܂��B  
    ''' </summary>
    ''' <param name="x">��r�Ώۂ̑� 1 �I�u�W�F�N�g�B </param>
    ''' <param name="y">��r�Ώۂ̑� 2 �I�u�W�F�N�g�B</param>
    ''' <returns>
    ''' 0 ��菬�����l x �� y ��菬�����B
    ''' 0 x �� y �͓������B
    ''' 0 ���傫���l   x �� y ���傫���B   
    ''' </returns>
    ''' -----------------------------------------------------------------------------
    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
        Dim ret As Integer = [String].Compare(CType(x, ListViewItem).SubItems(col).Text, CType(y, ListViewItem).SubItems(col).Text)
        Select Case order
            Case SortOrder.None, SortOrder.Ascending
                Return ret
            Case SortOrder.Descending
                Return ret * -1
        End Select
    End Function
#End Region
End Class
