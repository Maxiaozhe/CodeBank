Imports System.Xml

Public Class Form1
    Dim session As Domino.NotesSession
    Dim selectedDb As Domino.NotesDatabase


    Private Sub InitFormList(ByVal db As Domino.IDatabase)
        Me.treForm.Nodes.Clear()
        Dim forms() As Object = CType(db.Forms, Object())
        For Each Form As Domino.IForm In forms
            AddFormNode(Nothing, Form)
        Next
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


    Private Sub InitViewList(ByVal db As Domino.IDatabase)
        Me.treView.Nodes.Clear()
        Dim views() As Object = CType(db.Views, Object())
        For Each view As Domino.IView In views
            AddViewNode(Nothing, view)
        Next
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
        session.Initialize()

    End Sub


    Private Sub btnOpen_Click(sender As System.Object, e As System.EventArgs) Handles btnOpen.Click
        Try
            Me.OpenFileDialog1.Filter = "データベースファイル|*.nsf"
            If Me.OpenFileDialog1.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Dim fileName As String = Me.OpenFileDialog1.FileName
                Dim db As Domino.NotesDatabase = session.GetDatabase("", fileName, False)
                If db Is Nothing Then
                    Return
                End If
                Me.selectedDb = db
                Me.InitFormList(db)
                Me.InitViewList(db)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub treForm_AfterSelect(sender As Object, e As System.Windows.Forms.TreeViewEventArgs) Handles treForm.AfterSelect, treView.AfterSelect
        If e.Node.Tag Is Nothing Then
            Return
        End If
        Me.PropertyGrid1.SelectedObject = e.Node.Tag
    End Sub

    Private Sub treForm_BeforeExpand(sender As Object, e As System.Windows.Forms.TreeViewCancelEventArgs) Handles treForm.BeforeExpand
        If e.Node.Tag Is Nothing Then
            Return
        End If
        Dim form As Domino.IForm = CType(e.Node.Tag, Domino.IForm)
        If e.Node.Nodes.Count = 1 AndAlso e.Node.Nodes.Item(0).Tag Is Nothing Then
            e.Node.Nodes.Clear()
            Dim fields() As Object = CType(form.Fields, Object())
            For Each fld As String In fields
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
            For Each col As Domino.IViewColumn In columns
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

            If Me.SaveFileDialog1.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Dim docSelected As TreeNode = Me.treeDoc.SelectedNode
                If Not docSelected Is Nothing AndAlso TypeOf docSelected.tag Is Domino.NotesDocument Then
                    Dim doc As Domino.NotesDocument = CType(docSelected.Tag, Domino.NotesDocument)
                    If ExportDxlFile(Me.SaveFileDialog1.FileName, doc) = False Then
                        MessageBox.Show("エクスポートが失敗しました。")
                    End If
                ElseIf Not docSelected Is Nothing AndAlso TypeOf docSelected.Tag Is Domino.NotesNoteCollection Then
                    Dim notes As Domino.NotesNoteCollection = CType(docSelected.Tag, Domino.NotesNoteCollection)
                    If ExportDxlFile(Me.SaveFileDialog1.FileName, notes) = False Then
                        MessageBox.Show("エクスポートが失敗しました。")
                    End If
                Else
                    If ExportDxlFile(Me.SaveFileDialog1.FileName) = False Then
                        MessageBox.Show("エクスポートが失敗しました。")
                    End If

                End If
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

        Dim newDbName As String = System.IO.Path.GetFileNameWithoutExtension(Me.selectedDb.FileName) & "_2" & ".nsf"
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
        exporter.ForceNoteFormat = False
        exporter.OutputDOCTYPE = False
        Dim xml As String = exporter.Export(notes)
        My.Computer.FileSystem.WriteAllText(fileName, xml, False, System.Text.Encoding.UTF8)
        Return True
    End Function

    Private Function TransformDxl(ByVal inputFile As String) As Boolean
        Try
            Dim xsltUri As String = "C:\Program Files (x86)\lotus\notes\data\xsl\SPTransForm.xslt"
            Dim xslt As New System.Xml.Xsl.XslCompiledTransform()
            Dim outputFile As String = System.IO.Path.ChangeExtension(inputFile, ".xml")
            'セキュリティ上の理由から、DTD はこの XML ドキュメントでは使用できません。
            'DTD 処理を有効にするには、XmlReaderSettings の ProhibitDtd プロパティを False に設定し、XmlReader.Create メソッドにその設定を渡してください。
            xslt.Load(xsltUri)

            Dim readerSettings As New Xml.XmlReaderSettings
            readerSettings.ProhibitDtd = True
            readerSettings.ValidationType = ValidationType.None
            readerSettings.ConformanceLevel = ConformanceLevel.Fragment
            Dim writeSetting As New XmlWriterSettings()
            writeSetting.Indent = True
            writeSetting.OmitXmlDeclaration = False
            writeSetting.ConformanceLevel = ConformanceLevel.Fragment
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

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Try
 
            'フォーム
            Dim notes As Domino.NotesNoteCollection
            Dim docList As List(Of Domino.NotesDocument)

            notes = CreateFormNoteCollection()
            docList = GetDocumentList(notes)
            Dim formNode As TreeNode = Me.treeDoc.Nodes.Add("Form")
            formNode.Tag = notes
            AddDocumentList(formNode, docList)
            'ビュー
            notes = CreateViewNoteCollection()
            docList = GetDocumentList(notes)
            Dim viewNode As TreeNode = Me.treeDoc.Nodes.Add("View")
            viewNode.Tag = notes
            AddDocumentList(viewNode, docList)

            notes = CreateDoumentNoteCollection()
            docList = GetDocumentList(notes)
            Dim docNode As TreeNode = Me.treeDoc.Nodes.Add("Document")
            AddDocumentList(docNode, docList)

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

    Private Sub AddDocumentList(ByVal parent As TreeNode, ByVal docs As List(Of Domino.NotesDocument))
        For Each doc As Domino.NotesDocument In docs
            Dim name As String = GetValue("$TITLE", doc)
            Dim title As String = CStr(IIf(String.IsNullOrEmpty(name), doc.NoteID, name))
            Dim node As TreeNode = parent.Nodes.Add(title)
            node.Tag = doc
            node.Nodes.Add("__items")
        Next
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
        Using dbDialog As New OpenDb
            dbDialog.Session = Me.session
            dbDialog.ShowDialog(Me)
        End Using
    End Sub
End Class
