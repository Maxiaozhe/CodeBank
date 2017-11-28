Imports System.ComponentModel
<Assembly: WebResource("WebApplication1.flag.gif", "Image/gif")> 
Partial Public Class _Default
    Inherits BasePage
    Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

    End Sub
    Public Function GetString(ByVal key As String) As String
        Return CStr(MyBase.GetGlobalResourceObject(Me.GetType.BaseType.Name, key))
    End Function
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack = False Then
            initControls()
            Me.Label1.Text = HttpUtility.HtmlEncode("<a href=""http://www.yahoo.co.jp"">www.yahoo.co.jp</a>")
        End If
    End Sub
    Private Sub initControls()
        Dim strlang As String = MyBase.mResManager.GetString("language")
        Dim langs() As String = strlang.Split(";".ToCharArray, StringSplitOptions.RemoveEmptyEntries)
        Me.RadioButtonList1.Items.Clear()
        Dim CultureInfo As Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentUICulture
        For Each lang In langs
            Dim secs() As String = lang.Split(","c)
            Dim item As New ListItem With {.Text = secs(0), .Value = secs(1)}
            If CultureInfo.IetfLanguageTag = secs(1) Then
                item.Selected = True
            End If
            Me.RadioButtonList1.Items.Add(item)

        Next

        Dim dtt As DataTable = New DataTable()
        dtt.Columns.Add("col1", GetType(String))
        dtt.Columns.Add("col2", GetType(String))
        dtt.Columns.Add("col3", GetType(String))
        Dim row = dtt.NewRow()
        dtt.Rows.Add(row)
        Me.GridView1.DataSource = dtt
        Me.GridView1.DataBind()
    End Sub
   
    Private Sub ApplyResources(ByVal resManger As ComponentResourceManager, ByVal Parent As Control, ByVal name As String)
        Try
            If name IsNot Nothing AndAlso name <> "" Then
                resManger.ApplyResources(Parent, name)
            End If
            If Parent.HasControls Then
                For Each ctrl As Control In Parent.Controls
                    ApplyResources(resManger, ctrl, ctrl.ID)
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        If Me.RadioButtonList1.SelectedItem IsNot Nothing Then
            Dim code As String = Me.RadioButtonList1.SelectedItem.Value
            Dim CultureInfo As Globalization.CultureInfo = New Globalization.CultureInfo(code)
            Me.Session.Item("Culture") = CultureInfo.IetfLanguageTag
            MyBase.mResManager.ChangeLanguage(CultureInfo)
            initControls()
        End If
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        Me.Server.Transfer("WebForm1.aspx")
    End Sub
End Class