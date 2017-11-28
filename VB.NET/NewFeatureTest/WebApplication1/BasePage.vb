Imports ResourceManager
Imports System.Globalization

Public Class BasePage
    Inherits Page
    Protected mResManager As WebUIResourceManager
    Public ReadOnly Property Resources() As WebUIResourceManager
        Get
            If mResManager Is Nothing Then
                mResManager = ResManager.GetUIResourceManager(Me, Me.GetType.BaseType)
            End If
            Return mResManager
        End Get
    End Property
    Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        If Me.Session.Item("Culture") IsNot Nothing Then
            System.Threading.Thread.CurrentThread.CurrentUICulture = New CultureInfo(CStr(Me.Session.Item("Culture")))
        End If
        mResManager = ResManager.GetUIResourceManager(Me, Me.GetType.BaseType)
        If Me.IsPostBack = False Then
            If mResManager IsNot Nothing Then
                mResManager.ApplyResources()
            End If
        End If
    End Sub
End Class
