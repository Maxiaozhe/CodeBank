Imports System.Windows.Forms

Public Class frmSaveTemplate
    Private mTempItem As TemplateItem = Nothing
    Public Property TemplateData() As TemplateItem
        Get
            Return mTempItem
        End Get
        Set(ByVal value As TemplateItem)
            mTempItem = value
        End Set
    End Property

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If Me.txtTempName.Text = "" Then
            MessageBox.Show("テンプレートの名前を入力してください。")
            Return
        End If
        mTempItem.Name = Me.txtTempName.Text
        Dim Temps As TemplateCollection = Nothing
        Dim strSeriTemp As String = My.Settings.Templates
        If My.Settings.Templates = "" Then
            Temps = New TemplateCollection
        Else
            Temps = CType(Utility.StringToObject(strSeriTemp), TemplateCollection)
        End If
        Temps.Add(mTempItem)
        My.Settings.Templates = Utility.ObjectToString(Temps)
        My.Settings.Save()
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class
