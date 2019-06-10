Imports System.Runtime.InteropServices
Public Class FileView
    Inherits TreeView

    Private components As System.ComponentModel.IContainer
    Public Event FileAdded(ByVal Sender As Object, ByVal e As FileAddedEvetnArgs)
#Region "ÉÅÉ\ÉbÉh"
    Public Sub New()
        MyBase.new()
        Me.AllowDrop = True
        Me.ImageList = New ImageList()
        Me.ImageList.Images.Add("Folder", My.Resources.Folder)
        Me.ImageList.Images.Add("Folder_Open", My.Resources.Folder_Open)

    End Sub
    Public Sub AddFolder(ByVal ParentNode As TreeNode, ByVal FoldName As String)
        If System.IO.Directory.Exists(FoldName) Then
            Dim foldNode As TreeNode = Nothing
            If System.IO.Path.GetPathRoot(FoldName) <> FoldName Then
                foldNode = New TreeNode
                foldNode.ImageIndex = 0
                foldNode.SelectedImageIndex = 1
                foldNode.Text = System.IO.Path.GetFileName(FoldName)
                If ParentNode IsNot Nothing Then
                    foldNode.Tag = CStr(ParentNode.Tag) & "\" & foldNode.Text
                    ParentNode.Nodes.Add(foldNode)
                Else
                    foldNode.Tag = foldNode.Text
                    Me.Nodes.Add(foldNode)
                End If
            End If
            Dim subFolds() As String = System.IO.Directory.GetDirectories(FoldName, "*", IO.SearchOption.TopDirectoryOnly)
            If subFolds.Length > 0 Then
                For Each subFold As String In subFolds
                    AddFolder(foldNode, subFold)
                Next
            End If
            Dim files() As String = System.IO.Directory.GetFiles(FoldName, "*.*", IO.SearchOption.TopDirectoryOnly)
            For Each file As String In files
                AddFile(foldNode, file)
            Next
        ElseIf System.IO.File.Exists(FoldName) Then
            AddFile(ParentNode, FoldName)
        End If

    End Sub
    Public Sub AddFile(ByVal ParentNode As TreeNode, ByVal FilePath As String)
        If System.IO.File.Exists(FilePath) Then
            Dim fileNode As New TreeNode
            Dim ext As String = System.IO.Path.GetExtension(FilePath)
            If Me.ImageList.Images.ContainsKey(ext) Then
                fileNode.ImageKey = ext
                fileNode.SelectedImageKey = ext
            Else
                Dim image As Icon = Win32.GetSmallIcon(FilePath)
                If image IsNot Nothing Then
                    Me.ImageList.Images.Add(ext, image)
                    fileNode.ImageKey = ext
                    fileNode.SelectedImageKey = ext
                End If
            End If
            Dim filename As String = System.IO.Path.GetFileName(FilePath)
            fileNode.Text = filename
            If ParentNode IsNot Nothing Then
                fileNode.Tag = FilePath
                ParentNode.Nodes.Add(fileNode)
            Else
                fileNode.Tag = FilePath
                Me.Nodes.Add(fileNode)
            End If
            RaiseEvent FileAdded(Me, New FileAddedEvetnArgs(FilePath, CStr(ParentNode.Tag) & "\" & filename))
        End If
    End Sub
#End Region

    Private Sub FileView_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragDrop
        Dim ClientPoint As Point = Me.PointToClient(New Point(e.X, e.Y))
        Dim node As TreeNode = Me.HitTest(ClientPoint).Node
        Dim FileData As Object = e.Data.GetData("FileDrop")
        If FileData Is Nothing Then
            Return
        End If
        Dim targetNode As TreeNode
        If node Is Nothing Then
            targetNode = Nothing
        Else
            targetNode = node
        End If
        For Each folder As Object In CType(FileData, Array)
            If TypeOf folder Is String Then
                AddFolder(targetNode, CStr(folder))
            End If
        Next

    End Sub

    Private Sub FileView_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragEnter
        Dim ClientPoint As Point = Me.PointToClient(New Point(e.X, e.Y))
        Dim node As TreeNode = Me.HitTest(ClientPoint).Node
        If Not node Is Nothing Then
            If System.IO.File.Exists(CStr(node.Tag)) = True Then
                e.Effect = DragDropEffects.None
            Else
                e.Effect = DragDropEffects.Copy
            End If
        Else
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'FileView
        '
        Me.LineColor = System.Drawing.Color.Black
        Me.ResumeLayout(False)

    End Sub
    Public Class FileAddedEvetnArgs
        Inherits EventArgs
        Public FilePath As String
        Public NameOnCD As String
        Public Sub New(ByVal FlName As String, ByVal nmOnCd As String)
            FilePath = FlName
            NameOnCD = nmOnCd
        End Sub
    End Class

    Private Sub FileView_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragOver
        Dim ClientPoint As Point = Me.PointToClient(New Point(e.X, e.Y))
        Dim node As TreeNode = Me.HitTest(ClientPoint).Node
        If Not node Is Nothing Then
            Me.SelectedNode = node
            If System.IO.File.Exists(CStr(node.Tag)) = True Then
                e.Effect = DragDropEffects.None
            Else
                e.Effect = DragDropEffects.Copy
            End If
        Else
            e.Effect = DragDropEffects.Copy
        End If
    End Sub
End Class
<StructLayout(LayoutKind.Sequential)> _
Public Structure SHFILEINFO
    Public hIcon As IntPtr
    Public iIcon As IntPtr
    Public dwAttributes As Integer
    <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=260)> _
    Public szDisplayName As String
    <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=80)> _
    Public szTypeName As String
End Structure

Public Class Win32

    Public Const SHGFI_ICON As Integer = &H100
    Public Const SHGFI_LARGEICON As Integer = &H0  'Large icon
    Public Const SHGFI_SMALLICON As Integer = &H1  'Small icon

    <DllImport("shell32.dll")> _
    Private Shared Function SHGetFileInfo(ByVal pszPath As String, ByVal dwFileAttributes As Integer, ByRef psfi As SHFILEINFO, ByVal cbSizeFileInfo As Integer, ByVal uFlags As Integer) As IntPtr

    End Function

    Public Shared Function GetSmallIcon(ByVal filePath As String) As Icon
        If System.IO.File.Exists(filePath) = False Then
            Return Nothing
        End If
        Dim shinfo As New SHFILEINFO()
        Dim hImgSmall As IntPtr = Win32.SHGetFileInfo(filePath, 0, shinfo, Marshal.SizeOf(shinfo), Win32.SHGFI_ICON Or Win32.SHGFI_SMALLICON)
        Dim SmallIcon As Icon = System.Drawing.Icon.FromHandle(shinfo.hIcon)
        Return SmallIcon
    End Function

    Public Shared Function GetLargeIcon(ByVal filePath As String) As Icon
        If System.IO.File.Exists(filePath) = False Then
            Return Nothing
        End If
        Dim shinfo As New SHFILEINFO()
        Dim hImgSmall As IntPtr = Win32.SHGetFileInfo(filePath, 0, shinfo, Marshal.SizeOf(shinfo), Win32.SHGFI_ICON Or Win32.SHGFI_LARGEICON)
        Dim SmallIcon As Icon = System.Drawing.Icon.FromHandle(shinfo.hIcon)
        Return SmallIcon
    End Function
End Class
