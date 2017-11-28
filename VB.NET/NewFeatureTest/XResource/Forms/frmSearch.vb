Public Class frmSearch
    Private mResourceSetView As DataView
    Private mcolName As String = "name"
    Private mcolValue As String = "value"
    Private mcolFile As String = "file"
    Public Property NameColumnName() As String
        Get
            Return mcolName
        End Get
        Set(ByVal value As String)
            mcolName = value
        End Set
    End Property

    Public Property ValueColumnName() As String
        Get
            Return mcolValue
        End Get
        Set(ByVal value As String)
            mcolValue = value
        End Set
    End Property

    Public Property FileColumnName() As String
        Get
            Return mcolFile
        End Get
        Set(ByVal value As String)
            mcolFile = value
        End Set
    End Property

    Public Property ResourceSetView() As DataView
        Get
            Return Me.mResourceSetView
        End Get
        Set(ByVal value As DataView)
            mResourceSetView = value
        End Set
    End Property
    Public Sub clearSearch()
        Me.txtKey.Text = ""
        Me.txtValue.Text = ""

    End Sub
    Private Sub InitControls()
        Me.cmbFiles.Items.Clear()
        Dim Files As IEnumerable(Of String) = From row In mResourceSetView.Table Order By CStr(row.Item(mcolFile)) Select CStr(row.Item(mcolFile)) Distinct
        Me.cmbFiles.Items.Add(My.Resources.AllFile)
        For Each file As String In Files
            Me.cmbFiles.Items.Add(file)
        Next
        Me.cmbFiles.SelectedIndex = 0
    End Sub
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Dim key As String = Me.txtKey.Text
        Dim Value As String = Me.txtValue.Text
        Dim file As String = ""
        Dim Filter As String = ""
        If key <> "" Then
            Filter = "[" & Me.mcolName & "] like '" & Replace(key, "'", "''") & "%'"
        End If
        If Value <> "" Then
            If Filter <> "" Then
                Filter &= " AND "
            End If
            Filter &= "[" & mcolValue & "] like '%" & Replace(Value, "'", "''") & "%'"
        End If
        If Me.cmbFiles.SelectedIndex > 0 Then
            file = CStr(Me.cmbFiles.SelectedItem)
            If Filter <> "" Then
                Filter &= " AND "
            End If
            Filter &= "[" & mcolFile & "] = '" & Replace(file, "'", "''") & "'"
        End If
        Me.mResourceSetView.RowFilter = Filter
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub frmSearch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        InitControls()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class