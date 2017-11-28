Public Class frmEditor
    Private mTempList As TemplateCollection
    Private mCurrentTemp As TemplateItem = Nothing
    Private Sub frmEditor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strSeriTemp As String = My.Settings.Templates
        If My.Settings.Templates = "" Then
            mTempList = New TemplateCollection
        Else
            mTempList = CType(Utility.StringToObject(strSeriTemp), TemplateCollection)
        End If
        InitTempList()
    End Sub
    Private Sub InitTempList()
        Me.cmbTempList.Items.Clear()
        Me.cmbTempList.DisplayMember = "Name"
        For Each Temp As TemplateItem In mTempList
            Me.cmbTempList.Items.Add(Temp)
        Next
    End Sub

    Private Sub cmbTempList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTempList.SelectedIndexChanged
        If Me.cmbTempList.SelectedItem Is Nothing Then
            Return
        End If
        If Me.mCurrentTemp IsNot Nothing Then
            Me.mCurrentTemp.TreeRoot.Nodes.Clear()
            Dim newRoot As TreeNode = Me.FileView1.GetTemplate().TreeRoot
            For Each node As TreeNode In newRoot.Nodes
                Me.mCurrentTemp.TreeRoot.Nodes.Add(node)
            Next
        End If
        Dim item As TemplateItem = CType(Me.cmbTempList.SelectedItem, TemplateItem)
        Me.txtTempName.Text = item.Name
        Me.FileView1.Nodes.Clear()
        Me.FileView1.SetTempLate(item)
        mCurrentTemp = item
    End Sub


    Private Sub btnAddFold_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddFold.Click
        Dim ParentNode As TreeNode = Nothing
        If Me.FileView1.SelectedNode IsNot Nothing Then
            ParentNode = Me.FileView1.SelectedNode
            If CStr(ParentNode.Tag) <> "" Then
                If Me.FileView1.SelectedNode.Parent Is Nothing Then
                    ParentNode = Nothing
                Else
                    ParentNode = Me.FileView1.SelectedNode.Parent
                End If
            End If
        End If
        FileView1.newFolder(ParentNode, "新規フォルダ")
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If Me.FileView1.SelectedNode IsNot Nothing Then
            Me.FileView1.SelectedNode.Remove()
        End If
    End Sub

    Private Sub btnDeleteTemp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteTemp.Click
        If Me.cmbTempList.SelectedItem Is Nothing Then
            Return
        End If
        Dim item As TemplateItem = CType(Me.cmbTempList.SelectedItem, TemplateItem)
        Me.mTempList.Remove(item)
        InitTempList()
        Me.FileView1.Nodes.Clear()
        Me.txtTempName.Text = ""
        mCurrentTemp = Nothing
    End Sub
    Private Sub btnOption_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOption.Click
        If Me.cmbTempList.SelectedItem Is Nothing Then
            Return
        End If
        Dim item As TemplateItem = CType(Me.cmbTempList.SelectedItem, TemplateItem)
        Dim frmOpt As New frmOptions
        frmOpt.Options = item.TempOption.Clone
        If frmOpt.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            item.TempOption = frmOpt.Options
        End If
    End Sub
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If Me.mCurrentTemp IsNot Nothing Then
            Me.mCurrentTemp.TreeRoot.Nodes.Clear()
            Dim newRoot As TreeNode = Me.FileView1.GetTemplate().TreeRoot
            For Each node As TreeNode In newRoot.Nodes
                Me.mCurrentTemp.TreeRoot.Nodes.Add(node)
            Next
        End If
        My.Settings.Templates = Utility.ObjectToString(Me.mTempList)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub txtTempName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTempName.TextChanged
        If Me.cmbTempList.SelectedItem Is Nothing Then
            Return
        End If
        Dim item As TemplateItem = CType(Me.cmbTempList.SelectedItem, TemplateItem)
        If item.Name <> Me.txtTempName.Text Then
            item.Name = Me.txtTempName.Text
            InitTempList()
            Me.cmbTempList.SelectedItem = item
        End If

    End Sub

  
End Class