
Imports System.Runtime.InteropServices
Public Class FileView
    Inherits TreeView

    Private components As System.ComponentModel.IContainer
    Public Event FileAdded(ByVal Sender As Object, ByVal e As FileAddedEvetnArgs)
    Public Event FileAddCompleted(ByVal Sender As Object, ByVal e As EventArgs)

#Region "メソッド"
    Public Sub New()
        MyBase.new()
        Me.AllowDrop = True
        Me.ImageList = New ImageList()
        Me.ImageList.Images.Add("Folder", My.Resources.Folder)
        Me.ImageList.Images.Add("Folder_Open", My.Resources.Folder_Open)
    End Sub
    Public Sub newFolder(ByVal ParentNode As TreeNode, ByVal FoldName As String)
        Dim foldNode As New TreeNode
        foldNode.ImageIndex = 0
        foldNode.SelectedImageIndex = 1
        foldNode.Text = FoldName
        If ParentNode IsNot Nothing Then
            foldNode.Tag = ""
            ParentNode.Nodes.Add(foldNode)
            ParentNode.Expand()
        Else
            foldNode.Tag = ""
            Me.Nodes.Add(foldNode)
        End If
       foldNode.BeginEdit()
    End Sub
    Public Sub AddFolder(ByVal ParentNode As TreeNode, ByVal FoldName As String)
        If System.IO.Directory.Exists(FoldName) Then
            Dim foldNode As TreeNode = Nothing
            If System.IO.Path.GetPathRoot(FoldName) <> FoldName Then
                If Me.CheckFolder(System.IO.Path.GetFileName(FoldName)) = False Then
                    Return
                End If
                foldNode = New TreeNode
                foldNode.ImageIndex = 0
                foldNode.SelectedImageIndex = 1
                foldNode.Text = System.IO.Path.GetFileName(FoldName)
                If ParentNode IsNot Nothing Then
                    foldNode.Tag = ""
                    ParentNode.Nodes.Add(foldNode)
                Else
                    foldNode.Tag = ""
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
            Dim filename As String = System.IO.Path.GetFileName(FilePath)
            If Me.CheckExt(filename) = False Then
                Return
            End If
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

            fileNode.Text = filename
            fileNode.ToolTipText = FilePath
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
    Private Function CheckExt(ByVal filename As String) As Boolean
        Dim exts() As String = My.Settings.FileFilter.Split(";,|".ToCharArray, StringSplitOptions.RemoveEmptyEntries)
        For Each ext As String In exts
            If filename.ToLower Like ext.ToLower Then
                Return True
            End If
        Next
        Return False
    End Function
    Private Function CheckFolder(ByVal FolderName As String) As Boolean
        Dim Parrtens() As String = My.Settings.FolderFilter.Split(";,|".ToCharArray, StringSplitOptions.RemoveEmptyEntries)
        For Each Parrten As String In Parrtens
            If FolderName.ToLower Like Parrten.ToLower Then
                Return False
            End If
        Next
        Return True
    End Function
    Public Function GetTemplate() As TemplateItem
        Dim TempItem As New TemplateItem
        If Me.Nodes.Count = 0 Then
            Throw New Exception("フォルダかファイルが設定されていません。")
        End If
        For Each node As TreeNode In Me.Nodes
            TempItem.TreeRoot.Nodes.Add(CType(node.Clone(), TreeNode))
        Next
        Return TempItem
    End Function
    Public Sub SetTempLate(ByVal TempItem As TemplateItem)
        Dim NodeClone As TreeNode
        CheckFileIcon(TempItem.TreeRoot)
        For Each node As TreeNode In TempItem.TreeRoot.Nodes
            NodeClone = CType(node.Clone, TreeNode)
            If NodeClone.ToolTipText <> "" _
                                        AndAlso NodeClone.Tag IsNot Nothing _
                                        AndAlso TypeOf NodeClone.Tag Is String _
                                        AndAlso CStr(NodeClone.Tag) <> "" Then
                NodeClone.ToolTipText = CStr(NodeClone.Tag)
            End If
            Me.Nodes.Add(NodeClone)
        Next
    End Sub
    Private Sub CheckFileIcon(ByVal node As TreeNode)
        If node.ImageKey <> "" AndAlso node.Tag IsNot Nothing AndAlso CStr(node.Tag) <> "" Then
            Dim Filepath As String = CStr(node.Tag)
            Dim ext As String = System.IO.Path.GetExtension(Filepath)
            Dim image As Icon = Win32.GetSmallIcon(Filepath)
            If image IsNot Nothing Then
                Me.ImageList.Images.Add(ext, image)
            End If
            node.ToolTipText = Filepath
        End If
        If node.Nodes.Count > 0 Then
            For Each child As TreeNode In node.Nodes
                CheckFileIcon(child)
            Next
        End If
    End Sub
#End Region

    Public Function GetFileCount() As Integer
        Dim countNumber As Integer = 0
        For Each node As TreeNode In Me.Nodes
            CountFiles(node, countNumber)
        Next
        Return countNumber
    End Function

    Private Sub CountFiles(ByVal ParentNode As TreeNode, ByRef CountNumber As Integer)
        If ParentNode.Tag IsNot Nothing AndAlso TypeOf ParentNode.Tag Is String Then
            Dim path As String = CStr(ParentNode.Tag)
            If path <> "" Then
                CountNumber += 1
            End If
        End If
        If ParentNode.Nodes.Count > 0 Then
            For Each subNode As TreeNode In ParentNode.Nodes
                CountFiles(subNode, CountNumber)
            Next
        End If
    End Sub
    Private Sub FileView_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragDrop
        Dim ClientPoint As Point = Me.PointToClient(New Point(e.X, e.Y))
        Dim node As TreeNode = Me.HitTest(ClientPoint).Node
      
        Dim FileData As Object = GetDropData(e.Data)

        If FileData Is Nothing Then
            Return
        End If
        Dim targetNode As TreeNode
        If node Is Nothing Then
            targetNode = Nothing
        Else
            targetNode = node
        End If
        If TypeOf FileData Is Array Then
            For Each folder As Object In CType(FileData, Array)
                If TypeOf folder Is String Then
                    AddFolder(targetNode, CStr(folder).TrimEnd("\"c))
                End If
            Next
            RaiseEvent FileAddCompleted(Me, New EventArgs)
        ElseIf TypeOf FileData Is TreeNode Then
            'ノード移動　OR　コピー
            Dim CopyNode As TreeNode = Nothing
            If targetNode Is Nothing Then
                If CType(FileData, TreeNode).Parent Is Nothing Then
                    Return
                End If
                If (e.KeyState And 8) = 8 Then
                    'Ctrlキーを押す時、コピー
                    CopyNode = CType(CType(FileData, TreeNode).Clone(), TreeNode)
                    Me.Nodes.Add(CopyNode)
                    Me.SelectedNode = CopyNode
                Else
                    '移動
                    CopyNode = CType(CType(FileData, TreeNode).Clone(), TreeNode)
                    CType(FileData, TreeNode).Remove()
                    Me.Nodes.Add(CopyNode)
                    Me.SelectedNode = CopyNode
                End If
            Else
                If targetNode Is CType(FileData, TreeNode) OrElse targetNode Is CType(FileData, TreeNode).Parent Then
                    Return
                End If
                If (e.KeyState And 8) = 8 Then
                    'Ctrlキーを押す時、コピー
                    CopyNode = CType(CType(FileData, TreeNode).Clone(), TreeNode)
                    targetNode.Nodes.Add(CopyNode)
                    targetNode.Expand()
                    Me.SelectedNode = CopyNode
                Else
                    '移動
                    CopyNode = CType(CType(FileData, TreeNode).Clone(), TreeNode)
                    CType(FileData, TreeNode).Remove()
                    targetNode.Nodes.Add(CopyNode)
                    targetNode.Expand()
                    Me.SelectedNode = CopyNode
                End If
            End If

        End If

    End Sub
    Private Function GetDropData(ByVal data As System.Windows.Forms.IDataObject) As Object
        Dim fmts() As String = data.GetFormats(True)
        Dim FileData As Object
        If Array.IndexOf(fmts, "FileViewNode") > -1 Then
            Return data.GetData("FileViewNode")
        End If
        If Array.IndexOf(fmts, "FileDrop") > -1 Then
            FileData = data.GetData("FileDrop")
            Return FileData
        End If
        If Array.IndexOf(fmts, "System.String") > -1 Then
            FileData = data.GetData("System.String")
            If TypeOf FileData Is Array Then
                Return FileData
            ElseIf TypeOf FileData Is String Then
                Return New String() {CStr(FileData)}
            End If
        End If
        If Array.IndexOf(fmts, "Visual InterDev DBProject") > -1 Then

            FileData = data.GetData("Visual InterDev DBProject")
        
            If TypeOf FileData Is System.IO.MemoryStream Then
                Dim Buf As String = ""
                Dim stream As System.IO.MemoryStream = CType(FileData, System.IO.MemoryStream)
                Dim reader As New System.IO.StreamReader(stream, System.Text.Encoding.Default, True)
                While reader.Peek > 0
                    reader.Read()
                End While
                Buf = reader.ReadToEnd()
                Buf = Buf.Replace(Chr(0), "*").Replace("**", vbCrLf).Replace("*", "").Trim(vbCrLf.ToCharArray)
                Return Buf.Split(vbCrLf.ToCharArray, StringSplitOptions.RemoveEmptyEntries)
            End If
        End If
        If Array.IndexOf(fmts, "CF_VSREFPROJECTS") > -1 Then
            FileData = data.GetData("CF_VSREFPROJECTS")
            If TypeOf FileData Is System.IO.MemoryStream Then
                Dim Buf As String = ""
                Dim stream As System.IO.MemoryStream = CType(FileData, System.IO.MemoryStream)
                Dim reader As New System.IO.StreamReader(stream, System.Text.Encoding.Default, True)
                While reader.Peek > 0
                    reader.Read()
                End While
                Buf = reader.ReadToEnd()
                Buf = Buf.Replace(Chr(0), "*").Replace("**", vbCrLf).Replace("*", "").Trim(vbCrLf.ToCharArray)
                Return Buf.Split("|"c)
            End If
        End If

        Return Nothing
    End Function


    Private Sub FileView_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragEnter
        Dim ClientPoint As Point = Me.PointToClient(New Point(e.X, e.Y))
        Dim node As TreeNode = Me.HitTest(ClientPoint).Node
        If Not node Is Nothing Then
            If System.IO.File.Exists(CStr(node.Tag)) = True Then
                e.Effect = DragDropEffects.None
            Else
                e.Effect = DragDropEffects.Copy Or DragDropEffects.Move
            End If
        Else
            e.Effect = DragDropEffects.Copy Or DragDropEffects.Move
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
                e.Effect = DragDropEffects.Copy Or DragDropEffects.Move
            End If
        Else
            e.Effect = DragDropEffects.Copy Or DragDropEffects.Move
        End If
    End Sub

    Private Sub FileView_ItemDrag(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemDragEventArgs) Handles Me.ItemDrag
        Dim DataObj As New DataObject("FileViewNode", e.Item)
        If Control.ModifierKeys = Keys.Control Then
            Me.DoDragDrop(DataObj, DragDropEffects.Copy)
        Else
            Me.DoDragDrop(DataObj, DragDropEffects.Move)
        End If
    End Sub

    Private Sub FileView_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Delete Then
            If Me.SelectedNode Is Nothing Then
                Return
            End If
            Me.SelectedNode.Remove()
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
