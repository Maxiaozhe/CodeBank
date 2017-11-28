Imports System.Xml
Imports System.Xml.XPath

Public Class XPathTest
    Private XpathNavi As XPathNavigator
    Private xmlnManager As XmlNamespaceManager

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If Me.XpathNavi Is Nothing Then Return
        Try
            Me.TreeView1.Nodes.Clear()
            Dim node As XPathNodeIterator = SelectPath(XpathNavi, Me.TextBox1.Text)
            While node.MoveNext
                AddRootNode(node)
            End While
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Function CreateXPathNavi(ByVal path As String) As XPathNavigator
        Dim setting As New XmlReaderSettings
        setting.DtdProcessing = DtdProcessing.Ignore
        Using xreader As XmlReader = XmlReader.Create(path, setting)
            Return New XPathDocument(xreader).CreateNavigator()
        End Using

    End Function

    Private Function SelectPath(ByVal navi As XPathNavigator, ByVal xpath As String) As XPathNodeIterator
        Return navi.Select(xpath, xmlnManager)
    End Function



    Private Sub XLSTTest_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Me.btnSave.Enabled = False
        Me.Button1.Enabled = False
        Me.Button2.Enabled = False
    End Sub

    Private Sub AddRootNode(node As XPathNodeIterator)
        If node.Current Is Nothing Then
            Return
        End If
        Dim subNode As TreeNode
        Select Case node.Current.NodeType
            Case XPathNodeType.Root
                subNode = Me.TreeView1.Nodes.Add("Root")
                subNode.Tag = node.Current.Clone
                AddElement(subNode, node.Current)
            Case XPathNodeType.Element
                subNode = Me.TreeView1.Nodes.Add(node.Current.Name)
                subNode.Tag = node.Current.Clone
                AddElement(subNode, node.Current)
            Case XPathNodeType.Attribute
                subNode = Me.TreeView1.Nodes.Add("@" & node.Current.Name & ":" & node.Current.Value)
                subNode.Tag = node.Current.Clone
            Case Else
                subNode = Me.TreeView1.Nodes.Add(node.Current.NodeType.ToString() & ":" & node.Current.Value)
                subNode.Tag = node.Current.Clone
        End Select
    End Sub

    Private Sub AddSubNode(ByVal parent As TreeNode, node As XPathNodeIterator)
        If node.Current Is Nothing Then
            Return
        End If
        Dim subNode As TreeNode
        Select Case node.Current.NodeType
            Case XPathNodeType.Element
                subNode = parent.Nodes.Add(node.Current.Name)
                subNode.Tag = node.Current.Clone
                AddElement(subNode, node.Current)
            Case XPathNodeType.Attribute
                subNode = parent.Nodes.Add("@" & node.Current.Name & ":" & node.Current.Value)
                subNode.Tag = node.Current.Clone
            Case Else
                subNode = parent.Nodes.Add(node.Current.NodeType.ToString() & ":" & node.Current.Value)
                subNode.Tag = node.Current.Clone
        End Select
    End Sub

    Private Sub AddElement(ByVal parent As TreeNode, node As XPathNavigator)
        If node.HasAttributes Then

            Dim Attrs As XPathNodeIterator = node.Select("attribute::*")
            While Attrs.MoveNext()
                AddSubNode(parent, Attrs)
            End While
        End If
        If node.HasChildren Then
            Dim children As XPathNodeIterator = node.SelectChildren(XPathNodeType.All)
            While children.MoveNext()
                AddSubNode(parent, children)
            End While
        End If
    End Sub


    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        Me.SaveFileDialog1.Filter = "Xmlファイル(*.xml)|*.xml|DXLファイル|*.dxl"
        If Me.SaveFileDialog1.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Using xmlOut As XmlWriter = XmlWriter.Create(Me.SaveFileDialog1.FileName)
                Dim node As XPathNodeIterator = SelectPath(XpathNavi, Me.TextBox1.Text)
                While node.MoveNext
                    node.Current.WriteSubtree(xmlOut)
                End While
            End Using
        End If
    End Sub

  

    Private Sub mnuSaveGif_Click(sender As System.Object, e As System.EventArgs) Handles mnuSaveGif.Click
        Dim gifs As XPathNodeIterator = Me.SelectPath(Me.XpathNavi, "//x:gif/parent::*")
        Dim name As String = ""
        Dim gifSource As String = ""
        Dim dirPath As String = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "..\gif")
        If System.IO.Directory.Exists(dirPath) = False Then
            My.Computer.FileSystem.CreateDirectory(dirPath)
        End If
        Dim gifData() As Byte = New Byte() {}
        While gifs.MoveNext
            Dim nameNode As XPathNodeIterator = gifs.Current.Select("attribute::name")
            If nameNode.MoveNext() Then
                name = nameNode.Current.Value
            Else
                name = Guid.NewGuid().ToString("D") & ".gif"
            End If
            Dim gifNode As XPathNodeIterator = gifs.Current.Select("./x:gif", Me.xmlnManager)
            If gifNode.MoveNext() Then
                gifSource = gifNode.Current.Value
            End If
            gifData = Convert.FromBase64String(gifSource)

            name = System.IO.Path.Combine(dirPath, name)

            If gifData.Length > 0 AndAlso String.IsNullOrEmpty(name) = False Then
                My.Computer.FileSystem.WriteAllBytes(name, gifData, False)
            End If
        End While
    End Sub

    Private Sub mnuLoad_Click(sender As System.Object, e As System.EventArgs) Handles mnuLoad.Click
        Me.OpenFileDialog1.Filter = "DXLファイル|*.dxl"
        If Me.OpenFileDialog1.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            ReadDxl(OpenFileDialog1.FileName)
        End If

    End Sub

    Public Sub ReadDxl(ByVal fileName As String)
        Try
            If Not System.IO.File.Exists(fileName) Then
                Return
            End If
            XpathNavi = CreateXPathNavi(fileName)
            xmlnManager = New XmlNamespaceManager(XpathNavi.NameTable)
            xmlnManager.AddNamespace("x", "http://www.lotus.com/dxl")
            Me.btnSave.Enabled = True
            Me.Button1.Enabled = True
            Me.Button2.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    
    End Sub

    Private Sub mnuDXLExport_Click(sender As System.Object, e As System.EventArgs) Handles mnuDXLExport.Click
        Using newForm As MainForm = New MainForm()
            MainForm.ShowDialog()
        End Using
    End Sub

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        If Me.TreeView1.SelectedNode Is Nothing OrElse Me.TreeView1.SelectedNode.Tag Is Nothing Then
            Return
        End If
        Me.PropertyGrid1.SelectedObject = Me.TreeView1.SelectedNode.Tag
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub
End Class