Imports System.Globalization

Partial Public Class WebForm1
    Inherits BasePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack = False Then
            InitControls()
        End If
    End Sub

    Private Sub InitControls()
        Me.DropDownList1.Font.Name = ""
        'Me.DropDownList1.Items.Clear()
        'Me.DropDownList1.Items.Add(New ListItem(Me.Resources.GetString("DropDownList1.Item0.Text"), Me.Resources.GetString("DropDownList1.Item0.Value")))
        'Me.DropDownList1.Items.Add(New ListItem(Me.Resources.GetString("DropDownList1.Item1.Text"), Me.Resources.GetString("DropDownList1.Item1.Value")))
        'Me.DropDownList1.Items.Add(New ListItem(Me.Resources.GetString("DropDownList1.Item2.Text"), Me.Resources.GetString("DropDownList1.Item2.Value")))
        'Me.DropDownList1.Items.Add(New ListItem(Me.Resources.GetString("DropDownList1.Item3.Text"), Me.Resources.GetString("DropDownList1.Item3.Value")))
    End Sub
    Private Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged
        If Me.DropDownList1.SelectedItem Is Nothing Then
            Return
        End If
        Dim selectIndex As Integer = Me.DropDownList1.SelectedIndex
        Dim Code As String = Me.DropDownList1.SelectedItem.Value
        Me.Resources.ChangeLanguage(New CultureInfo(Code))
        InitControls()
        Me.DropDownList1.SelectedIndex = selectIndex
    End Sub
End Class