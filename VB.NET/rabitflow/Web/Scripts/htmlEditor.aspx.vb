Public Class dialog1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RegistScripts()
        InitControls()
    End Sub

    Private Sub InitControls()
        Dim param As String = ""
        param = "hdnUserSeed=0"
        param = param & "&hdnDocumentSeed=0"
        param = param & "&hdnFormSeed=0"
        Me.hdnImageParam.Value = param

    End Sub

    Private Sub RegistScripts()
        Dim fontNames As New StringBuilder

        For Each Fname In System.Drawing.FontFamily.Families
            If Fname.IsStyleAvailable(Drawing.FontStyle.Bold Or Drawing.FontStyle.Italic Or Drawing.FontStyle.Regular Or Drawing.FontStyle.Underline Or Drawing.FontStyle.Strikeout) Then
                If fontNames.Length > 0 Then
                    fontNames.Append(",")
                End If
                fontNames.Append("'" & Fname.Name & "'")
            End If
        Next Fname
        Dim script As String = "var fontNames=[" & fontNames.ToString() & "];"
        If ClientScript.IsClientScriptBlockRegistered("HTMLEDITOR_FONTS") = False Then
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "HTMLEDITOR_FONTS", script, True)
        End If
    End Sub


End Class