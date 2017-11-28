Imports System.IO

Public Class NotesDir
    Private _root As NotesDir
    Private _parent As NotesDir
    Private _folders As List(Of NotesDir)
    Private _databases As List(Of Domino.NotesDatabase)
    Private _path As String
    Private _isRoot As Boolean

    Public ReadOnly Property Parent() As NotesDir
        Get
            Return Me._parent
        End Get
    End Property

    Public ReadOnly Property Folders() As List(Of NotesDir)
        Get
            Return Me._folders
        End Get
    End Property

    Private Function Comparison(ByVal x As NotesDir, y As NotesDir) As Integer
        Return x.Name.CompareTo(y.Name)
    End Function

    Private Function ComparisonDB(ByVal x As Domino.NotesDatabase, y As Domino.NotesDatabase) As Integer
        If (x Is Nothing OrElse y Is Nothing) Then
            Return -1
        End If
        Dim xtitle As String = CStr(IIf(String.IsNullOrEmpty(x.Title), x.FileName, x.Title))
        Dim ytitle As String = CStr(IIf(String.IsNullOrEmpty(y.Title), y.FileName, y.Title))
        Return xtitle.CompareTo(ytitle)
    End Function


    Public ReadOnly Property Name() As String
        Get
            Dim pos As Integer = Me._path.LastIndexOf("\")
            If pos < 0 OrElse pos >= Me._path.Length - 1 Then
                Return Me._path
            End If
            Return Me._path.Substring(pos + 1)
        End Get
    End Property


    Public ReadOnly Property Databases() As List(Of Domino.NotesDatabase)
        Get
            Return Me._databases
        End Get
    End Property

    Public ReadOnly Property Path() As String
        Get
            Return _path
        End Get
    End Property

    Public ReadOnly Property IsRoot() As Boolean
        Get
            Return Me._parent Is Nothing
        End Get
    End Property

    Public Sub New(ByVal DbDir As Domino.NotesDbDirectory)
        Me._parent = Nothing
        Me._folders = New List(Of NotesDir)()
        Me._databases = New List(Of Domino.NotesDatabase)
        InitDirectory(DbDir)
    End Sub

    Private Sub New(ByVal db As Domino.NotesDatabase, ByVal parent As NotesDir)
        Me._parent = parent
        Me._folders = New List(Of NotesDir)()
        Me._databases = New List(Of Domino.NotesDatabase)
        Me._path = System.IO.Path.GetDirectoryName(db.FilePath).ToLower()
        Me._databases.Add(db)
    End Sub

    Private Sub New(ByVal path As String)
        Me._parent = Nothing
        Me._folders = New List(Of NotesDir)()
        Me._databases = New List(Of Domino.NotesDatabase)
        Me._path = path
    End Sub



    Private Sub AddDataBase(ByVal db As Domino.NotesDatabase)
        Dim dirparth As String = System.IO.Path.GetDirectoryName(db.FilePath).ToLower()
        Dim Folder As NotesDir = Me.GetFolder(dirparth)
        If Not Folder Is Nothing Then
            Folder.Databases.Add(db)
            Return
        End If
    End Sub

    Private Function FindFolder(ByVal root As NotesDir, ByVal dirpath As String) As NotesDir
        If root.Path.Equals(dirpath) Then
            Return root
        End If
        For Each folder As NotesDir In root.Folders
            Dim subFolder As NotesDir = FindFolder(folder, dirpath)
            If Not subFolder Is Nothing Then
                Return subFolder
            End If
        Next
        Return Nothing
    End Function

    Private Function GetFolder(ByVal dirpath As String) As NotesDir
        Dim folder As NotesDir = FindFolder(Me.GetRoot(), dirpath)
        If Not folder Is Nothing Then
            Return folder
        End If
        folder = New NotesDir(dirpath)
        Dim parentPath As String = GetParent(dirpath)
        Dim parent As NotesDir = GetFolder(parentPath)
        If Not parent Is Nothing Then
            folder._parent = parent
            parent.Folders.Add(folder)
        End If
        Return folder
    End Function


    Private Function GetParent(ByVal path As String) As String
        If String.IsNullOrEmpty(path) OrElse path.Contains("\") = False Then
            Return String.Empty
        End If
        Dim pos As Integer = path.LastIndexOf("\")
        If pos <= 0 Then
            Return String.Empty
        End If
        Return path.Substring(0, pos - 1)
    End Function


    Public Function GetRoot() As NotesDir
        If Not Me._root Is Nothing Then
            Return Me._root
        End If
        If Me.Parent Is Nothing Then
            Me._root = Me
            Return Me._root
        End If
        Me._root = Me.Parent.GetRoot()
        Return Me._root
    End Function


    Private Sub InitDirectory(ByVal DbDir As Domino.NotesDbDirectory)
        Dim db As Domino.NotesDatabase = DbDir.GetFirstDatabase(Domino.DB_TYPES.DATABASE)
        Me._path = System.IO.Path.GetDirectoryName(db.FilePath).ToLower()
        While Not db Is Nothing
            Me.AddDataBase(db)
            db = DbDir.GetNextDatabase()
        End While
        Me._folders.Sort(AddressOf Comparison)
        Me._databases.Sort(AddressOf ComparisonDB)
    End Sub


End Class
