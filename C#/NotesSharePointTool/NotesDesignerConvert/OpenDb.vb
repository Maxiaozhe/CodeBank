Public Class OpenDb
    Private _session As Domino.NotesSession
    Private _server As String
    Private _selectedDb As Domino.NotesDatabase

    Public Property Session() As Domino.NotesSession
        Get
            Return Me._session
        End Get
        Set(ByVal value As Domino.NotesSession)
            _session = value
        End Set
    End Property


    Public Property ServerName() As String
        Get
            Return Me._server
        End Get
        Set(ByVal value As String)
            Me._server = value
        End Set
    End Property

    Public ReadOnly Property SelectedDatabase() As Domino.NotesDatabase
        Get
            Return Me._selectedDb
        End Get
    End Property



    Private Sub InitControls()
        If String.IsNullOrEmpty(Me._server) Then
            Me._server = Me._session.ServerName
        End If

        Dim DbDir As Domino.NotesDbDirectory = Me._session.GetDbDirectory(Me._server)
        Dim notesDir As New NotesDir(DbDir)
        InitDbDir(notesDir)
    End Sub

    Private Sub InitDbDir(ByVal dir As NotesDir)
        Me.TreeView1.Nodes.Clear()
        For Each db As Domino.NotesDatabase In dir.Databases
            AddDb(TreeView1.Nodes, db)
        Next
        For Each fld As NotesDir In dir.Folders
            AddFolder(TreeView1.Nodes, fld)
        Next
    End Sub

    Private Sub AddFolder(ByVal parentNodes As TreeNodeCollection, ByVal dir As NotesDir)
        Dim subnode As TreeNode = parentNodes.Add(dir.Name, dir.Name, "Folder", "OpenFolder")
        subnode.Tag = dir
        For Each db As Domino.NotesDatabase In dir.Databases
            AddDb(subnode.Nodes, db)
        Next
        For Each fld As NotesDir In dir.Folders
            AddFolder(subnode.Nodes, fld)
        Next
    End Sub

    Private Sub AddDb(ByVal parentNodes As TreeNodeCollection, ByVal db As Domino.NotesDatabase)
        Dim dbName As String = CStr(IIf(String.IsNullOrEmpty(db.Title), db.FileName, db.Title))
        Dim node As TreeNode = parentNodes.Add(db.Title, db.Title, "NotesDb", "NotesDb")
        node.Tag = db

    End Sub

    Private Sub OpenDb_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Try
            InitControls()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        Try
            Me._selectedDb = Me._session.GetDatabase(Me._server, Me.txtDbPath.Text, False)
            If Me._selectedDb.IsOpen = False Then
                Me._selectedDb.Open()
            End If
            If Me._selectedDb Is Nothing Then
                MessageBox.Show("データベースを選択してください。")
                Return
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return
        End Try
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnGetDir_Click(sender As System.Object, e As System.EventArgs) Handles btnGetDir.Click
        Me._server = Me.txtServer.Text
        Me._selectedDb = Nothing
        Me.txtDbPath.Text = ""
        Me.InitControls()
    End Sub

    Private Sub TreeView1_AfterSelect(sender As Object, e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect

        If Me.TreeView1.SelectedNode Is Nothing OrElse Not TypeOf Me.TreeView1.SelectedNode.Tag Is Domino.NotesDatabase Then
            Return
        End If
        Me._selectedDb = CType(Me.TreeView1.SelectedNode.Tag, Domino.NotesDatabase)
        Me.txtDbPath.Text = Me._selectedDb.FilePath
        Me._server = Me._selectedDb.Server
    End Sub

    Private Sub btnOpen_Click(sender As System.Object, e As System.EventArgs) Handles btnOpen.Click
        If Me.OpenFileDialog1.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Me.txtDbPath.Text = Me.OpenFileDialog1.FileName
            Me._selectedDb = Me._session.GetDatabase("", Me.txtDbPath.Text, False)
            Me._server = ""
        End If
    End Sub
End Class