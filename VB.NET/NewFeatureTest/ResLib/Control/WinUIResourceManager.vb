Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Globalization

Public Class WindowsUIResourceManager

    Private mResManger As ComponentResourceManager
    Private mControl As Control

    Friend Sub New(ByVal Ctrl As Control, ByVal manager As ComponentResourceManager)
        mControl = Ctrl
        mResManger = manager
    End Sub


    Private Sub ApplyChildResources(ByVal Parent As Control, ByVal name As String)
        If name IsNot Nothing AndAlso name <> "" Then
            mResManger.ApplyResources(Parent, name)
        End If
        If Parent.HasChildren Then
            For Each ctrl As Control In Parent.Controls
                ApplyChildResources(ctrl, ctrl.Name)
            Next
        End If
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
