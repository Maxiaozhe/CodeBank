Imports System.Reflection
Imports System.Globalization
Imports System.Resources
Imports System.ComponentModel

Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim RDB As New FormLinqDataContext("Data Source=db12;Initial Catalog=RabitFlow_SBB;Persist Security Info=True;User ID=sa")
            Dim Source As Object = From GuiItem In RDB.FRMG1000
            Me.DataGridView1.DataSource = Source

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Dim RDB As New FormLinqDataContext("Data Source=db12;Initial Catalog=RabitFlow_410;Persist Security Info=True;User ID=sa")
            Dim Source As Object = From GuiItem In RDB.FRMG1005 Where GuiItem.NMCLASS = "FileUpLoad"

            Me.DataGridView1.DataSource = Source

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Me.lblTime.Text = ""
            Dim STime As DateTime = DateTime.Now
            Dim RDB As New RabitFlowDB("Data Source=db12;Initial Catalog=RabitFlow_SBB;Persist Security Info=True;User ID=sa")

            For i As Integer = 0 To 0
                Dim Source As IEnumerable = From Docitem In RDB.EGGA0001 _
                                       Where Docitem.FGDEL = "0"c And Docitem.IDDOC = 66880 Order By Docitem.IDDOC _
                                       Select New With {.IDDOC = Docitem.IDDOC, .IDFRM = Docitem.IDFRM, .NMMAKE = Docitem.NMMAKE, .STATUS = Docitem.STATUS, .STMAKE = Docitem.STMAKE, .STSUBJECT = Docitem.STSUBJECT, .DTMAKE = Docitem.DTMAKE}

                Me.DataGridView1.DataSource = Source
            Next
            Dim ETime As DateTime = DateTime.Now
            Dim Stmp As TimeSpan = ETime.Subtract(STime)
            Me.lblTime.Text = CStr(Stmp.Milliseconds)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim conn As SqlClient.SqlConnection = Nothing
        Dim Cmd As SqlClient.SqlCommand = Nothing
        Try
            Me.lblTime.Text = ""
            Dim STime As DateTime = DateTime.Now
            conn = New SqlClient.SqlConnection("Data Source=db12;Initial Catalog=RabitFlow_SBB;Persist Security Info=True;User ID=sa")
            conn.Open()
            For i As Integer = 0 To 0
                Cmd = conn.CreateCommand
                Cmd.CommandText = "Select IDDOC,IDFRM,NMMAKE,STATUS,STMAKE,STSUBJECT,DTMAKE from EGGA0001 where FGDEL='0' and iddoc=66880"
                Dim SqlAdp As New SqlClient.SqlDataAdapter(Cmd)
                Dim dtt As New DataTable
                SqlAdp.Fill(dtt)
                Me.DataGridView1.DataSource = dtt
            Next
            Dim ETime As DateTime = DateTime.Now
            Dim Stmp As TimeSpan = ETime.Subtract(STime)
            Me.lblTime.Text = CStr(Stmp.Milliseconds)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If conn IsNot Nothing Then
                conn.Close()
                conn = Nothing
            End If
        End Try
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim str As String = LinkExpress.TestFunc()
        MessageBox.Show(str)
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim lst As List(Of String) = LinkExpress.test2()

    End Sub


    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim lst As List(Of String) = LinkExpress.test3()
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Dim express As String = Me.txtExpress.Text
        Dim codedom As New CodeDom() With {.Express = express}
        If codedom.Compile() = False Then
            Me.txtOutput.Text = codedom.CompilerError
        Else
            Me.txtOutput.Text = "ビルド完了しました。"
        End If
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Dim express As String = Me.txtExpress.Text
        Dim codedom As New CodeDom() With {.Express = express}
        If codedom.Compile() = True Then
            Me.txtOutput.AppendText(vbCrLf)
            Me.txtOutput.AppendText("-----------------------------------------")
            Me.txtOutput.AppendText(vbCrLf)
            Me.txtOutput.AppendText("実行結果========>")
            Me.txtOutput.AppendText(vbCrLf)
            Dim result As String = codedom.Eval()
            Me.txtOutput.AppendText(CStr(IIf(result Is Nothing, "", result)))
        End If
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Dim xelemTest As New XmlElementTest

    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Dim assm As Assembly = Assembly.GetExecutingAssembly()
        Dim resources() As String = assm.GetManifestResourceNames
    End Sub



    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim CultureInfo As Globalization.CultureInfo = New Globalization.CultureInfo("zh-CN")
        System.Threading.Thread.CurrentThread.CurrentUICulture = CultureInfo
        Dim resManger As New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        ApplyResources(resManger, Me, "$this")

        'Dim Resset As ResourceSet = resManger.GetResourceSet(CultureInfo, True, True)
        'Dim enumor = Resset.GetEnumerator()
        'Do While enumor.MoveNext()
        '    Dim key As Object = enumor.Key
        '    Dim value As Object = enumor.Value
        '    resManger.ApplyResources(value, CStr(key), My.Resources.Culture)
        'Loop


    End Sub

    Private Sub ApplyResources(ByVal resManger As ComponentResourceManager, ByVal Parent As Control, ByVal name As String)
        resManger.ApplyResources(Parent, name)
        If Parent.HasChildren Then
            For Each ctrl As Control In Parent.Controls
                ApplyResources(resManger, ctrl, ctrl.Name)
            Next
        End If
    End Sub
End Class
