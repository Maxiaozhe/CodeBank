Imports System.Xml
Imports RJ.Tools.NotesTransfer.Components

Public Class MainForm
    Dim session As Domino.NotesSession
    Dim selectedDb As Domino.NotesDatabase
    Dim lastExportFile As String

    Private Sub InitFormList(ByVal db As Domino.IDatabase)
        Me.treForm.Nodes.Clear()
        Dim forms() As Object = CType(db.Forms, Object())
        If forms Is Nothing OrElse forms.Length = 0 Then
            Return
        End If
        Dim dbNode As TreeNode = Me.treForm.Nodes.Add(db.Title)
        dbNode.Tag = db
        Dim formEnum = forms.Cast(Of Domino.NotesForm)().OrderBy(Function(key) key.Name)
        For Each Form As Domino.IForm In formEnum
            AddFormNode(dbNode, Form)
        Next
    End Sub



    Private Sub InitViewList(ByVal db As Domino.IDatabase)
        Me.treView.Nodes.Clear()
        Dim views() As Object = CType(db.Views, Object())
        If views Is Nothing OrElse views.Length = 0 Then
            Return
        End If

        Dim viewEnum = views.Cast(Of Domino.NotesView)().OrderBy(Function(key) key.Name)
        For Each view As Domino.IView In viewEnum
            AddViewNode(Nothing, view)
        Next
    End Sub

    Private Sub InitAgents(ByVal db As Domino.IDatabase)
        Me.treeAction.Nodes.Clear()
        Dim agents() As Object = CType(db.Agents, Object())
        If agents Is Nothing Then
            Return
        End If
        Dim codeNode As TreeNode = Me.treeAction.Nodes.Add("エージェント")
        For Each agent As Domino.NotesAgent In agents
            AddAgentNode(codeNode, agent)
        Next
    End Sub


    Private Sub InitActions(ByVal db As Domino.IDatabase)


    End Sub


    Private Sub AddFormNode(ByVal parent As TreeNode, form As Domino.IForm)
        Dim node As TreeNode = New TreeNode()
        node.Text = form.Name
        node.Tag = form
        node.Nodes.Add(New TreeNode("items"))

        If parent Is Nothing Then
            Me.treForm.Nodes.Add(node)
        Else
            parent.Nodes.Add(node)
        End If
    End Sub

    Private Sub AddAgentNode(ByVal parent As TreeNode, agent As Domino.IAgent)
        Dim node As TreeNode = New TreeNode()
        node.Text = agent.Name
        node.Tag = agent
        If parent Is Nothing Then
            Me.treeAction.Nodes.Add(node)
        Else
            parent.Nodes.Add(node)
        End If
    End Sub



    Private Sub AddViewNode(ByVal parent As TreeNode, view As Domino.IView)
        Dim node As TreeNode = New TreeNode()
        node.Text = view.Name
        node.Tag = view
        node.Nodes.Add(New TreeNode("columns"))

        If parent Is Nothing Then
            Me.treView.Nodes.Add(node)
        Else
            parent.Nodes.Add(node)
        End If
    End Sub




    Private Sub Form1_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        session = New Domino.NotesSession()
        session.Initialize("maxz1205")

    End Sub


    Private Sub btnOpen_Click(sender As System.Object, e As System.EventArgs) Handles btnOpen.Click
        Try

            Dim books() As Object = CType(session.AddressBooks, Object())
            For Each book As Domino.NotesDatabase In books
                MessageBox.Show(book.FileName)
            Next
            Dim dbPicker As NsfPicker = New NsfPicker()
            dbPicker.NotesPassword = "maxz1205"
            If dbPicker.ShowNsfPicker(Me, True) = Windows.Forms.DialogResult.OK Then
                Dim nsfDb As NsfInfo = dbPicker.SelectNsfDb
                Me.selectedDb = Me.session.GetDatabase(nsfDb.Server, nsfDb.FilePath, False)
                If Me.selectedDb Is Nothing Then
                    MessageBox.Show("データベースがありません。")
                    Return
                End If
                If Not Me.selectedDb.IsOpen Then
                    Me.selectedDb.Open()
                End If
                Me.InitFormList(Me.selectedDb)
                'Me.InitFieldList(Me.selectedDb)
                Me.InitViewList(Me.selectedDb)
                Me.InitAgents(Me.selectedDb)

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub treForm_AfterSelect(sender As Object, e As System.Windows.Forms.TreeViewEventArgs) Handles treForm.AfterSelect, treView.AfterSelect, treeAction.AfterSelect
        If e.Node.Tag Is Nothing Then
            Return
        End If
        Me.PropertyGrid1.SelectedObject = e.Node.Tag
    End Sub

    Private Sub treForm_BeforeExpand(sender As Object, e As System.Windows.Forms.TreeViewCancelEventArgs) Handles treForm.BeforeExpand
        If e.Node.Tag Is Nothing OrElse Not TypeOf e.Node.Tag Is Domino.NotesForm Then
            Return
        End If
        Dim form As Domino.IForm = CType(e.Node.Tag, Domino.IForm)
        If e.Node.Nodes.Count = 1 AndAlso e.Node.Nodes.Item(0).Tag Is Nothing Then
            e.Node.Nodes.Clear()
            Dim fields() As Object = CType(form.Fields, Object())
            Dim fieldEnum = fields.Cast(Of String).OrderBy(Function(key) key)
            For Each fld As String In fieldEnum
                e.Node.Nodes.Add(fld)
            Next
        End If
    End Sub

    Private Sub treView_BeforeExpand(sender As Object, e As System.Windows.Forms.TreeViewCancelEventArgs) Handles treView.BeforeExpand
        If e.Node.Tag Is Nothing Then
            Return
        End If
        Dim view As Domino.IView = CType(e.Node.Tag, Domino.IView)
        Dim node As TreeNode
        If e.Node.Nodes.Count = 1 AndAlso e.Node.Nodes.Item(0).Tag Is Nothing Then
            e.Node.Nodes.Clear()
            Dim columns() As Object = CType(view.Columns, Object())
            If (columns Is Nothing OrElse columns.Length = 0) Then
                Return
            End If
            Dim columnEnum = columns.Cast(Of Domino.IViewColumn).OrderBy(Function(key) key.Title)
            For Each col As Domino.IViewColumn In columnEnum
                node = e.Node.Nodes.Add(CStr(IIf(String.IsNullOrEmpty(col.Title), col.ItemName, col.Title)))
                node.Tag = col
            Next
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        Try
            If Me.selectedDb Is Nothing Then
                Return
            End If
            If Me.treeDoc.SelectedNode Is Nothing Then
                Return
            End If
            Dim exportObj As Object = Me.treeDoc.SelectedNode.Tag
            Me.SaveFileDialog1.FileName = Me.treeDoc.SelectedNode.Text & ".dxl"
            If Me.SaveFileDialog1.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                If TypeOf exportObj Is Domino.NotesDocument Then
                    Dim doc As Domino.NotesDocument = CType(Me.treeDoc.SelectedNode.Tag, Domino.NotesDocument)

                    If ExportDxlFile(Me.SaveFileDialog1.FileName, doc) = False Then
                        MessageBox.Show("エクスポートが失敗しました。")
                    End If
                    lastExportFile = Me.SaveFileDialog1.FileName
                ElseIf TypeOf exportObj Is Domino.NotesNoteCollection Then
                    Dim notes As Domino.NotesNoteCollection = CType(Me.treeDoc.SelectedNode.Tag, Domino.NotesNoteCollection)
                    If ExportDxlFile(Me.SaveFileDialog1.FileName, notes) = False Then
                        MessageBox.Show("エクスポートが失敗しました。")
                    End If
                    lastExportFile = Me.SaveFileDialog1.FileName
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbCrLf & ex.StackTrace)
        End Try

    End Sub

    Private Sub btnExportAll_Click(sender As System.Object, e As System.EventArgs) Handles btnExportAll.Click
        Try
            If Me.selectedDb Is Nothing Then
                Return
            End If
            Me.SaveFileDialog1.FileName = Me.selectedDb.Title & ".dxl"
            If Me.SaveFileDialog1.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                If ExportDxlFile(Me.SaveFileDialog1.FileName) = False Then
                    MessageBox.Show("エクスポートが失敗しました。")
                End If
                lastExportFile = Me.SaveFileDialog1.FileName
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub
    Private Function ExportDxlFile(ByVal fileName As String) As Boolean
        Dim exporter As Domino.NotesDXLExporter
        exporter = session.CreateDXLExporter()
        exporter.ForceNoteFormat = False
        exporter.OutputDOCTYPE = False

        Dim tempDbPath As String = My.Computer.FileSystem.GetTempFileName()

        Dim newDbName As String = System.IO.Path.ChangeExtension(tempDbPath, ".nsf")

        Dim newDB As Domino.NotesDatabase = Me.selectedDb.CreateCopy("", newDbName)
        Dim xml As String = exporter.Export(newDB)
        My.Computer.FileSystem.WriteAllText(fileName, xml, False, System.Text.Encoding.UTF8)
        Return True
    End Function

    Private Function ExportDxlFile(ByVal fileName As String, ByVal doc As Domino.NotesDocument) As Boolean
        Dim exporter As Domino.NotesDXLExporter
        exporter = session.CreateDXLExporter()
        exporter.ForceNoteFormat = False
        exporter.OutputDOCTYPE = False
        Dim xml As String = exporter.Export(doc)
        My.Computer.FileSystem.WriteAllText(fileName, xml, False, System.Text.Encoding.UTF8)
        Return True
    End Function

    Private Function ExportDxlFile(ByVal fileName As String, ByVal notes As Domino.NotesNoteCollection) As Boolean
        Dim exporter As Domino.NotesDXLExporter

        exporter = session.CreateDXLExporter()
        exporter.ConvertNotesbitmapsToGIF = True
        exporter.OutputDOCTYPE = False
        Dim xml As String = exporter.Export(notes)
        My.Computer.FileSystem.WriteAllText(fileName, xml, False, System.Text.Encoding.UTF8)
        Return True
    End Function

    Private Sub GetSubForms(ByVal nodes As Domino.NotesNoteCollection, ByVal formName As String, ByVal allForms As List(Of Domino.NotesDocument))
        Dim formNames() As String = formName.Split("|"c)

        Dim docForm = allForms.Where( _
            Function(form)
                Dim names As String() = GetValues("$TITLE", form)
                For Each name As String In names
                    For Each targetName As String In formNames
                        If name.Trim().ToLower().Equals(targetName.Trim().ToLower()) Then
                            Return True
                        End If
                    Next
                Next
                Return False
            End Function)
        If docForm.Count() = 0 Then
            Return
        End If
        Dim formDoc As Domino.NotesDocument = docForm.First()
        nodes.Add(formDoc)
        Dim subforms() As String = Me.GetValues("$SubForms", formDoc)
        If Not subforms Is Nothing AndAlso subforms.Length > 0 Then
            For Each subformName As String In subforms
                If Not String.IsNullOrEmpty(subformName) Then
                    GetSubForms(nodes, subformName, allForms)
                End If
            Next
        End If
    End Sub




    Private Function GetAllForms() As List(Of Domino.NotesDocument)
        Dim notes As Domino.NotesNoteCollection = Me.selectedDb.CreateNoteCollection(False)
        notes.SelectForms = True
        notes.SelectSubforms = True
        notes.BuildCollection()
        Return GetDocumentList(notes)
    End Function

    Private Function TransformDxl(ByVal inputFile As String) As Boolean
        Try
            Dim xsltUri As String = ".\xlst\core.xsl"
            Dim xslt As New System.Xml.Xsl.XslCompiledTransform()
            Dim outputFile As String = System.IO.Path.ChangeExtension(inputFile, ".xml")
            'セキュリティ上の理由から、DTD はこの XML ドキュメントでは使用できません。
            'DTD 処理を有効にするには、XmlReaderSettings の ProhibitDtd プロパティを False に設定し、XmlReader.Create メソッドにその設定を渡してください。
            xslt.Load(xsltUri)

            Dim readerSettings As New Xml.XmlReaderSettings
            readerSettings.DtdProcessing = DtdProcessing.Ignore
            readerSettings.ValidationType = ValidationType.None
            readerSettings.ConformanceLevel = ConformanceLevel.Fragment
            Dim writeSetting As New XmlWriterSettings()
            writeSetting.Indent = True
            writeSetting.OmitXmlDeclaration = False
            writeSetting.ConformanceLevel = ConformanceLevel.Fragment
            Dim arguments As New Xml.Xsl.XsltArgumentList()

            Using inStream As XmlReader = XmlReader.Create(inputFile, readerSettings)
                Using writer = XmlWriter.Create(outputFile, writeSetting)

                    xslt.Transform(inStream, writer)
                End Using
            End Using
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try

    End Function

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click
        Me.OpenFileDialog1.Filter = "DXLファイル|*.dxl"
        If Me.OpenFileDialog1.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            TransformDxl(Me.OpenFileDialog1.FileName)
        End If
    End Sub

    Private Sub AddDocuments(ByVal db As Domino.NotesDatabase, ByVal form As Domino.NotesForm)
        Try
            Dim formula As String = "@Contains(Form; """ & form.Name & """"
            Dim alais() As Object = CType(form.Aliases, Object())
            If Not alais Is Nothing AndAlso alais.Length > 0 Then
                Dim aliasesNames = alais.Cast(Of String)()
                For Each Name As String In aliasesNames
                    formula &= ":""" & Name & """"
                Next
            End If
            formula &= ")"
            Dim docs As Domino.NotesDocumentCollection = db.Search(formula, Nothing, 0)
            Me.treeDoc.Nodes.Clear()
            Dim formNode As TreeNode = Me.treeDoc.Nodes.Add(form.Name & "(" & docs.Count & ")")
            AddDocumentCollection(formNode, docs)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub AddDocuments(ByVal db As Domino.NotesDatabase, ByVal view As Domino.NotesView)
        Try
            Dim navi As Domino.NotesViewNavigator = view.CreateViewNav()
            Me.treeDoc.Nodes.Clear()
            Dim viewNode As TreeNode = Me.treeDoc.Nodes.Add(view.Name & "(" & navi.Count & ")")
            AddViewNavigator(viewNode, navi)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Try
            Me.treeDoc.Nodes.Clear()

            Dim notes As Domino.NotesNoteCollection
            Dim docList As List(Of Domino.NotesDocument)
            'フォーム
            If mnuForm.Checked Then
                notes = CreateFormNoteCollection()
                docList = GetDocumentList(notes)
                Dim formNode As TreeNode = Me.treeDoc.Nodes.Add("Form")
                formNode.Tag = notes
                AddDocumentList(formNode, docList)
            End If
            'ビュー
            If mnuView.Checked Then
                notes = CreateViewNoteCollection()
                docList = GetDocumentList(notes)
                Dim viewNode As TreeNode = Me.treeDoc.Nodes.Add("View")
                viewNode.Tag = notes
                AddDocumentList(viewNode, docList)

            End If
            'Document
            If mnuDocument.Checked Then
                notes = CreateDoumentNoteCollection()
                docList = GetDocumentList(notes)
                Dim docNode As TreeNode = Me.treeDoc.Nodes.Add("Document")
                docNode.Tag = notes
                AddDocumentList(docNode, docList)
            End If
            'Action
            If mnuAction.Checked Then
                notes = CreateActionNoteCollection()
                docList = GetDocumentList(notes)
                Dim docNode As TreeNode = Me.treeDoc.Nodes.Add("Action")
                docNode.Tag = notes
                AddDocumentList(docNode, docList)
            End If
            'Agent
            If mnuAgent.Checked Then
                notes = Me.CreateAgentNoteCollection()
                docList = GetDocumentList(notes)
                Dim docNode As TreeNode = Me.treeDoc.Nodes.Add("Agent")
                docNode.Tag = notes
                AddDocumentList(docNode, docList)
            End If
            'イメージリソース
            If mnuImgsource.Checked Then
                notes = Me.CreateImageNoteCollection()
                docList = GetDocumentList(notes)
                Dim docNode As TreeNode = Me.treeDoc.Nodes.Add("Image Resources")
                docNode.Tag = notes
                AddDocumentList(docNode, docList)

            End If
            'Folder
            If Me.mnuFolder.Checked Then
                notes = Me.CreateFolderNoteCollection()
                docList = GetDocumentList(notes)
                Dim docNode As TreeNode = Me.treeDoc.Nodes.Add("Folders")
                docNode.Tag = notes
                AddDocumentList(docNode, docList)
            End If
            'アイコン
            If Me.mnuIcon.Checked Then
                notes = Me.CreateIconNoteCollection()
                docList = GetDocumentList(notes)
                Dim docNode As TreeNode = Me.treeDoc.Nodes.Add("Icons")
                docNode.Tag = notes
                AddDocumentList(docNode, docList)
            End If
            'すべて
            If Me.mnuAllDesignItem.Checked Then
                notes = Me.CreateAllNoteCollection()
                docList = GetDocumentList(notes)
                Dim docNode As TreeNode = Me.treeDoc.Nodes.Add("すべて設計要素")
                docNode.Tag = notes
                AddDocumentList(docNode, docList)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Function GetDocumentList(notes As Domino.NotesNoteCollection) As List(Of Domino.NotesDocument)
        Dim docList As List(Of Domino.NotesDocument) = New List(Of Domino.NotesDocument)()
        Dim notesId As String = notes.GetFirstNoteId()
        While (Not String.IsNullOrEmpty(notesId))
            docList.Add(Me.selectedDb.GetDocumentByID(notesId))
            notesId = notes.GetNextNoteId(notesId)
        End While
        Return docList
    End Function



    Private Function CreateFormNoteCollection() As Domino.NotesNoteCollection
        Dim notes As Domino.NotesNoteCollection = Me.selectedDb.CreateNoteCollection(False)
        notes.SelectForms = True
        notes.SelectSubforms = True
        notes.BuildCollection()
        Return notes
    End Function

    Private Function CreateViewNoteCollection() As Domino.NotesNoteCollection
        Dim notes As Domino.NotesNoteCollection = Me.selectedDb.CreateNoteCollection(False)
        notes.SelectViews = True
        notes.BuildCollection()
        Return notes
    End Function

    Private Function CreateDoumentNoteCollection() As Domino.NotesNoteCollection
        Dim notes As Domino.NotesNoteCollection = Me.selectedDb.CreateNoteCollection(False)
        notes.SelectDocuments = True
        notes.BuildCollection()
        Return notes
    End Function

    Private Function CreateActionNoteCollection() As Domino.NotesNoteCollection
        Dim notes As Domino.NotesNoteCollection = Me.selectedDb.CreateNoteCollection(False)
        notes.SelectActions = True
        notes.SelectAllCodeElements(True)
        notes.BuildCollection()
        Return notes
    End Function

    Private Function CreateAllNoteCollection() As Domino.NotesNoteCollection
        Dim notes As Domino.NotesNoteCollection = Me.selectedDb.CreateNoteCollection(False)
        notes.SelectAllDesignElements(True)
        notes.BuildCollection()
        Return notes
    End Function

    Private Function CreateImageNoteCollection() As Domino.NotesNoteCollection
        Dim notes As Domino.NotesNoteCollection = Me.selectedDb.CreateNoteCollection(False)
        notes.SelectImageResources = True
        notes.BuildCollection()
        Return notes
    End Function


    Private Function CreateAgentNoteCollection() As Domino.NotesNoteCollection
        Dim notes As Domino.NotesNoteCollection = Me.selectedDb.CreateNoteCollection(False)
        notes.SelectAgents = True
        notes.BuildCollection()
        Return notes
    End Function

    Private Function CreateFolderNoteCollection() As Domino.NotesNoteCollection
        Dim notes As Domino.NotesNoteCollection = Me.selectedDb.CreateNoteCollection(False)
        notes.SelectFolders = True
        notes.BuildCollection()
        Return notes
    End Function

    Private Function CreateIconNoteCollection() As Domino.NotesNoteCollection
        Dim notes As Domino.NotesNoteCollection = Me.selectedDb.CreateNoteCollection(False)
        notes.SelectIcon = True
        notes.BuildCollection()
        Return notes
    End Function

    Private Sub AddDocumentList(ByVal parent As TreeNode, ByVal docs As List(Of Domino.NotesDocument))
        For Each doc As Domino.NotesDocument In docs
            Dim name As String = GetValue("$TITLE", doc)
            Dim title As String = CStr(IIf(String.IsNullOrEmpty(name), doc.NoteID, name))
            Dim node As TreeNode = parent.Nodes.Add(title)
            node.Tag = doc
            node.Nodes.Add("__items")
        Next
    End Sub

    Private Sub AddDocumentCollection(ByVal parent As TreeNode, ByVal docs As Domino.NotesDocumentCollection)
        If (docs Is Nothing) Then Return
        Dim doc As Domino.NotesDocument = docs.GetFirstDocument()
        While Not doc Is Nothing
            Dim name As String = GetValue("$TITLE", doc)
            Dim title As String = CStr(IIf(String.IsNullOrEmpty(name), doc.NoteID, name))
            Dim node As TreeNode = parent.Nodes.Add(title)
            node.Tag = doc
            node.Nodes.Add("__items")
            doc = docs.GetNextDocument(doc)
        End While
    End Sub


    Private Sub AddViewNavigator(ByVal parent As TreeNode, ByVal navi As Domino.NotesViewNavigator)
        If (navi Is Nothing) Then Return

        Dim entry As Domino.NotesViewEntry = navi.GetFirstDocument
        While Not entry Is Nothing
            Dim doc As Domino.NotesDocument = entry.Document
            Dim name As String = GetValue("$TITLE", doc)
            Dim title As String = CStr(IIf(String.IsNullOrEmpty(name), doc.NoteID, name))
            Dim node As TreeNode = parent.Nodes.Add(title)
            node.Tag = doc
            node.Nodes.Add("__items")
            entry = navi.GetNextDocument(entry)
        End While
    End Sub


    Private Sub treeDoc_BeforeExpand(sender As Object, e As TreeViewCancelEventArgs) Handles treeDoc.BeforeExpand
        Try
            If Not (e.Node.Nodes.Count = 1 AndAlso TypeOf e.Node.Tag Is Domino.NotesDocument AndAlso e.Node.Nodes.Item(0).Tag Is Nothing) Then
                Return
            End If
            Dim node As TreeNode = e.Node
            Dim doc As Domino.NotesDocument = CType(node.Tag, Domino.NotesDocument)
            Dim items() As Object = CType(doc.Items, Object())
            node.Nodes.Clear()
            For Each item As Domino.NotesItem In items
                Dim value As String = GetValue(item)
                node.Nodes.Add(String.Format("{0} = ""{1}""", item.Name, value)).Tag = item
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub treeDoc_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles treeDoc.AfterSelect
        If e.Node.Tag Is Nothing Then
            Return
        End If
        PropertyGrid1.SelectedObject = e.Node.Tag
    End Sub

    Private Function GetValue(ByVal fieldName As String, ByVal doc As Domino.NotesDocument) As String
        Try
            If doc.HasItem(fieldName) = False Then
                Return Nothing
            End If
            Dim items() As Object = CType(doc.Items, Object())
            Dim retItems = items.Cast(Of Domino.NotesItem)().Where(Function(item) item.Name.Equals(fieldName))
            If retItems.Count() > 0 Then
                Return GetValue(retItems.First())
            End If
            Return String.Empty
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Function GetValues(ByVal fieldName As String, ByVal doc As Domino.NotesDocument) As String()
        Try
            If doc.HasItem(fieldName) = False Then
                Return Nothing
            End If

            Dim items() As Object = CType(doc.Items, Object())
            Dim retItems = items.Cast(Of Domino.NotesItem)().Where(Function(item) item.Name.Equals(fieldName))
            If retItems.Count() > 0 Then
                Return GetValues(retItems.First())
            End If
            Return Nothing
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Function GetValue(ByVal item As Domino.NotesItem) As String
        Try
            If item.Values Is Nothing Then Return ""
            If TypeOf item.Values Is Object() Then
                Dim values As Object() = CType(item.Values, Object())
                For Each Val As Object In values
                    If Not Val Is Nothing Then
                        Return Val.ToString()
                    End If
                Next
            Else
                Return item.Values.ToString()
            End If
            Return String.Empty

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function GetValues(ByVal item As Domino.NotesItem) As String()
        Try
            Dim valuesList As New List(Of String)
            If item.Values Is Nothing Then
                Return valuesList.ToArray()
            End If
            If TypeOf item.Values Is Object() Then
                Dim values As Object() = CType(item.Values, Object())
                For Each Val As Object In values
                    If Not Val Is Nothing Then
                        valuesList.Add(Val.ToString())
                    End If
                Next
            Else
                valuesList.Add(item.Values.ToString())
            End If
            Return valuesList.ToArray()

        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Private Sub ToolStripButton4_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton4.Click
        Using XPath As New XPathTest
            If System.IO.File.Exists(Me.lastExportFile) Then
                XPath.ReadDxl(Me.lastExportFile)
            End If
            XPath.ShowDialog(Me)
        End Using
    End Sub

    Private Sub ToolStripButton5_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton5.Click
        Try
            If (Me.treForm.SelectedNode Is Nothing) OrElse (Not TypeOf Me.treForm.SelectedNode.Tag Is Domino.NotesForm) Then
                Return
            End If
            Dim form As Domino.NotesForm = CType(Me.treForm.SelectedNode.Tag, Domino.NotesForm)
            Dim allForms As List(Of Domino.NotesDocument) = Me.GetAllForms()
            Dim formExport As Domino.NotesNoteCollection = Me.selectedDb.CreateNoteCollection(False)
            Me.GetSubForms(formExport, form.Name, allForms)
            Me.SaveFileDialog1.FileName = form.Name & ".dxl"
            If Me.SaveFileDialog1.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Me.ExportDxlFile(Me.SaveFileDialog1.FileName, formExport)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub OpenDatabaseByNotesUrl()
        Me.session.GetEnvironmentString("MailServer", True)
        Dim id As String = InputBox("DB ID")
        Dim theURL As String = "notes:///" + id + "?OpenDatabase"

        Dim objDb As Domino.NotesDatabase = CType(Me.session.Resolve(theURL), Domino.NotesDatabase)
        If objDb Is Nothing Then
            Return
        End If
        Me.selectedDb = objDb
        If Not Me.selectedDb.IsOpen Then
            Me.selectedDb.Open()
        End If
        Me.InitFormList(Me.selectedDb)
        Me.InitViewList(Me.selectedDb)
        Me.InitAgents(Me.selectedDb)
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        Try
            If TabControl1.SelectedTab Is Me.tabForm Then
                If (Me.treForm.SelectedNode Is Nothing) OrElse (Me.treForm.SelectedNode.Tag Is Nothing) Or (Not TypeOf Me.treForm.SelectedNode.Tag Is Domino.NotesForm) Then
                    Return
                End If

                Dim form As Domino.NotesForm = CType(Me.treForm.SelectedNode.Tag, Domino.NotesForm)
                Me.AddDocuments(Me.selectedDb, form)
            ElseIf TabControl1.SelectedTab Is Me.tabView Then
                If (Me.treView.SelectedNode Is Nothing) OrElse (Me.treView.SelectedNode.Tag Is Nothing) Or (Not TypeOf Me.treView.SelectedNode.Tag Is Domino.NotesView) Then
                    Return
                End If

                Dim view As Domino.NotesView = CType(Me.treView.SelectedNode.Tag, Domino.NotesView)
                Me.AddDocuments(Me.selectedDb, view)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub SetServerList()
        Dim mailServer As String = Me.session.GetEnvironmentString("MailServer", True)
        Dim dir As Domino.NotesDbDirectory = Me.session.GetDbDirectory(mailServer)
        Dim userId As String = Me.session.GetEnvironmentString("$SANotesId")
        Dim db As Domino.NotesDatabase = dir.GetFirstDatabase(Domino.DB_TYPES.DATABASE)
        Dim serverList As HashSet(Of String) = Nothing
        dir.OpenMailDatabase()
        While Not db Is Nothing
            If db.IsOpen = False Then
                db.Open()
            End If
            If db.QueryAccessPrivileges(userId) >= Domino.ACLLEVEL.ACLLEVEL_READER Then
                If db.IsPublicAddressBook Then
                    serverList = New HashSet(Of String)
                    Dim start As Date = Date.Now
                    Dim docs As Domino.NotesDocumentCollection = db.Search("Form=""Server""", Nothing, 0)
                    'Dim doc As Domino.NotesDocument = docs.GetFirstDocument()
                    'While Not doc Is Nothing
                    '    Dim serverName As String = FindServerName(doc)
                    '    If Not String.IsNullOrEmpty(serverName) AndAlso serverList.Contains(serverName) = False Then
                    '        serverList.Add(serverName)
                    '    End If
                    '    doc = docs.GetNthDocument
                    'End While
                    MessageBox.Show((Date.Now - start).TotalMilliseconds.ToString())
                    start = Date.Now
                    For i As Integer = 1 To docs.Count
                        Dim doc As Domino.NotesDocument = docs.GetNthDocument(i)

                        Dim serverName As String = FindServerName(doc)
                        If Not String.IsNullOrEmpty(serverName) AndAlso serverList.Contains(serverName) = False Then
                            serverList.Add(serverName)
                        End If
                        MessageBox.Show((Date.Now - start).TotalMilliseconds.ToString())
                        start = Date.Now
                    Next
                    MessageBox.Show((Date.Now - start).TotalMilliseconds.ToString())
                    Dim servers = serverList.OrderBy(Function(key) key)
                    Dim addressNode As TreeNode = Me.treeServer.Nodes.Add(db.Title + "(" + CStr(servers.Count()) + ")")
                    For Each server As String In servers
                        addressNode.Nodes.Add(server)
                    Next
                    Return
                End If
            End If
            db = dir.GetNextDatabase()
        End While

    End Sub

    Private Sub SetAllServerList()
        Dim address As Object() = CType(Me.session.AddressBooks, Object())
        Dim serverList As HashSet(Of String) = Nothing
        Me.treeServer.Nodes.Clear()
        For Each db As Domino.NotesDatabase In address
            If db.IsOpen = False Then
                db.Open()
            End If
            If db.IsPublicAddressBook Then
                serverList = New HashSet(Of String)
                Dim start As Date = Date.Now
                Dim docs As Domino.NotesDocumentCollection = db.Search("Form=""Server""", Nothing, 0)
                'Dim docs As Domino.NotesDocumentCollection = db.Search("@Contains(NetWork;""DENSAN"":""MRJPCluster05"")", Nothing, 50)
                Dim doc As Domino.NotesDocument = docs.GetFirstDocument()
                While Not doc Is Nothing
                    Dim serverName As String = FindServerName(doc)
                    If Not String.IsNullOrEmpty(serverName) AndAlso serverList.Contains(serverName) = False Then
                        serverList.Add(serverName)
                    End If
                    doc = docs.GetNextDocument(doc)
                End While

                MessageBox.Show((Date.Now - start).TotalMilliseconds.ToString())

                Dim servers = serverList.OrderBy(Function(key) key)
                Dim addressNode As TreeNode = Me.treeServer.Nodes.Add(db.Title + "(" + CStr(servers.Count()) + ")")
                For Each server As String In servers
                    addressNode.Nodes.Add(server)
                Next
                Return
            End If
        Next
    End Sub

    Private Sub SetServerListByView()
        Dim address As Object() = CType(Me.session.AddressBooks, Object())
        Dim serverList As HashSet(Of String) = Nothing
        Me.treeServer.Nodes.Clear()
        For Each db As Domino.NotesDatabase In address
            If db.IsOpen = False Then
                db.Open()
            End If
            If db.IsPublicAddressBook Then
                serverList = New HashSet(Of String)
                Dim start As Date = Date.Now
                'Dim docs As Domino.NotesDocumentCollection = db.Search("Form=""Server""", Nothing, 0)
                'Dim docs As Domino.NotesDocumentCollection = db.Search("@Contains(NetWork;""DENSAN"":""MRJPCluster05"")", Nothing, 50)
                Dim view As Domino.NotesView = db.GetView("Servers")
                Dim navi As Domino.NotesViewNavigator = view.CreateViewNav()
                Dim entry As Domino.NotesViewEntry = navi.GetFirstDocument()
                While Not entry Is Nothing
                    Dim doc As Domino.NotesDocument = entry.Document
                    Dim serverName As String = FindServerName(doc)
                    If Not String.IsNullOrEmpty(serverName) AndAlso serverList.Contains(serverName) = False Then
                        serverList.Add(serverName)
                    End If
                    entry = navi.GetNextDocument(entry)
                End While

                MessageBox.Show((Date.Now - start).TotalMilliseconds.ToString())

                Dim servers = serverList.OrderBy(Function(key) key)
                Dim addressNode As TreeNode = Me.treeServer.Nodes.Add(db.Title + "(" + CStr(servers.Count()) + ")")
                For Each server As String In servers
                    addressNode.Nodes.Add(server)
                Next
                Return
            End If
        Next
    End Sub


    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        Try
            Dim db As Domino.NotesDatabase = Me.session.GetDatabase("", "subscriptions", False)
            If db Is Nothing Then
                Return
            End If
            If db.IsOpen = False Then
                db.Open()
            End If
            Dim docs As Domino.NotesDocumentCollection = db.Search("$Title=""swish.gif""", Nothing, 0)
            Dim xml = Me.ExportDxlFile(docs)
            My.Computer.FileSystem.DeleteDirectory("", FileIO.DeleteDirectoryOption.DeleteAllContents)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Function ExportDxlFile(ByVal docs As Domino.NotesDocumentCollection) As String
        Dim exporter As Domino.NotesDXLExporter
        exporter = session.CreateDXLExporter()
        exporter.ForceNoteFormat = False
        exporter.OutputDOCTYPE = False
        exporter.ConvertNotesbitmapsToGIF = True
        Dim xml As String = exporter.Export(docs)
        Return xml
    End Function

    Private Function FindServerName(ByVal doc As Domino.NotesDocument) As String
        'If doc.HasItem("ServerName") = False Then
        '    Return String.Empty
        'End If
        'Dim value As Object = Me.session.Evaluate("@ServerName", doc)
        Dim value As Object = doc.GetItemValue("ServerName")
        If value Is Nothing Then
            Return String.Empty
        End If
        Dim serverName As String = CStr(CType(value, Object())(0))
        Dim nsName As Domino.NotesName = session.CreateName(serverName)
        Return nsName.Abbreviated
        'Return serverName
    End Function

    
End Class
