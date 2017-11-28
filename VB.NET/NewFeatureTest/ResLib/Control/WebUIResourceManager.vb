Imports System.Resources
Imports System.Reflection
Imports System.ComponentModel
Imports System.Web.UI
Imports System.Globalization

Public Class WebUIResourceManager
    Private mResManger As ComponentResourceManager
    Private mControl As System.Web.UI.Control

    Friend Sub New(ByVal ctrl As Control, ByVal manager As ComponentResourceManager)
        mControl = ctrl
        mResManger = manager
    End Sub

    Private Sub ApplyChildResources(ByVal Parent As Control, ByVal name As String)
        If name IsNot Nothing AndAlso name <> "" Then
            mResManger.ApplyResources(Parent, name)
        End If
        If Parent.HasControls Then
            For Each ctrl As Control In Parent.Controls
                ApplyChildResources(ctrl, ctrl.ID)
            Next
        End If
    End Sub

    Private Sub OnPageInit(ByVal sender As Object, ByVal e As System.EventArgs)
        ApplyResources()
    End Sub

    Public Sub ApplyResources()
        ApplyChildResources(mControl, "$this")
    End Sub

    Public Sub ChangeLanguage(ByVal Culture As System.Globalization.CultureInfo)
        System.Threading.Thread.CurrentThread.CurrentUICulture = Culture
        ApplyChildResources(mControl, "$this")
    End Sub

    Public Function GetString(ByVal Key As String) As String
        Return mResManger.GetString(Key)
    End Function
End Class
