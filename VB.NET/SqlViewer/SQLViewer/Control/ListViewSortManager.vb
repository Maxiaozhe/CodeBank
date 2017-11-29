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
    ''' 矢印の種類を表します。
    ''' </summary>
    ''' -----------------------------------------------------------------------------
    Private Enum ArrowType
        ''' <summary>
        ''' 昇順の矢印
        ''' </summary>
        Ascending
        ''' <summary>
        ''' 降順の矢印
        ''' </summary>
        Descending
    End Enum
#End Region
#Region "Method"
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' リストビューマネジャーのインスタンスを生成する。
    ''' </summary>
    ''' <param name="srclist">管理するリストビューのインスタンス</param>
    ''' -----------------------------------------------------------------------------
    Public Sub New(ByVal srclist As ListView)
        Me.mlistView = srclist
        Me.mcolumn = 0
        Me.msortOrder = SortOrder.None
        '矢印のビットマップを生成して、イメジリストに追加する
        Me.mimageList = New ImageList()
        Me.mimageList.ImageSize = New Size(8, 8)
        Me.mimageList.TransparentColor = System.Drawing.Color.Magenta
        Me.mimageList.Images.Add(GetArrowBitmap(ArrowType.Ascending))
        Me.mimageList.Images.Add(GetArrowBitmap(ArrowType.Descending))
        'ヘッダのイメージリストを設定する
        SetHeaderImageList(mimageList)
        'カラムクリックエベントをハンドリングする。
        AddHandler mlistView.ColumnClick, AddressOf OnColumnClick
        'ソートする
        Me.Sort(Me.mcolumn)
    End Sub
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' ヘッダのイメージリストを設定する
    ''' </summary>
    ''' <param name="imgList">イメージリスト</param>
    ''' -----------------------------------------------------------------------------
    Public Sub SetHeaderImageList(ByVal imgList As ImageList)
        Dim hHeader As IntPtr = SendMessage(Me.mlistView.Handle, LVM_GETHEADER, IntPtr.Zero, IntPtr.Zero)
        Dim ret As IntPtr = SendMessage(hHeader, HDM_SETIMAGELIST, IntPtr.Zero, imgList.Handle)
    End Sub
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' リストビューをソートする
    ''' </summary>
    ''' <param name="column">カラムのインディクス値</param>
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
    ''' ソート矢印のビットマップを作成する
    ''' </summary>
    ''' <param name="arrow">矢印の種類</param>
    ''' <returns>ビットマップ</returns>
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
    ''' リストビューのヘッダにソート矢印（▲▼）を表示する
    ''' </summary>
    ''' <param name="columnIndex">カラムのインディクス</param>
    ''' <param name="sortOrder">ソート順</param>
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
    ''' リストビューのヘッダをクリックするとき、ソートを処理する
    ''' </summary>
    ''' <param name="sender">イベントのソース。</param>
    ''' <param name="e">イベント データを格納しているColumnClickEventArgs</param>
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
''' リストビューの比較子を公開します。  
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
    '''  2 つのオブジェクトを比較し、一方が他方より小さいか、等しいか、大きいかを示す値を返します。  
    ''' </summary>
    ''' <param name="x">比較対象の第 1 オブジェクト。 </param>
    ''' <param name="y">比較対象の第 2 オブジェクト。</param>
    ''' <returns>
    ''' 0 より小さい値 x が y より小さい。
    ''' 0 x と y は等しい。
    ''' 0 より大きい値   x が y より大きい。   
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
