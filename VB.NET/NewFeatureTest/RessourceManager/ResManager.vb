Imports System.Resources
Imports System.Reflection
Imports System.ComponentModel
Imports System.Web.UI
Imports System.Windows.Forms
Imports System.Globalization
Public Class ResManager
    Private Shared mUIResourceSet As New Dictionary(Of Type, ComponentResourceManager)
    Private Shared mMessageResSet As New Dictionary(Of Type, Resources.ResourceManager)
    Public Shared Function HasResources(ByVal Type As Type) As Boolean
        Dim ResourceFilename As String = Type.FullName & ".resources"
        Dim resFiles() As String = Type.Assembly.GetManifestResourceNames()
        Dim Ret As Integer = Aggregate f In resFiles Into Count(f = ResourceFilename)
        If Ret > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    ''' <summary>
    ''' Web系UIリソースマネジャーを取得する
    ''' </summary>
    ''' <param name="Control"></param>
    ''' <param name="baseType"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetUIResourceManager(ByVal Control As System.Web.UI.Control, ByVal baseType As System.Type) As WebUIResourceManager
        Dim UIManager As WebUIResourceManager = Nothing
        Dim Compmanager As ComponentResourceManager = Nothing
        If mUIResourceSet.ContainsKey(baseType) Then
            Compmanager = mUIResourceSet.Item(baseType)
            Compmanager.IgnoreCase = True
        Else
            If HasResources(baseType) Then
                Compmanager = New ComponentResourceManager(baseType)
                Compmanager.IgnoreCase = True
                mUIResourceSet.Add(baseType, Compmanager)
            Else
                Return Nothing
            End If
        End If
        UIManager = New WebUIResourceManager(Control, Compmanager)
        Return UIManager
    End Function
    ''' <summary>
    ''' Windows系UIリソースマネジャーを取得する
    ''' </summary>
    ''' <param name="Control"></param>
    ''' <param name="baseType"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetUIResourceManager(ByVal Control As System.Windows.Forms.Control, ByVal baseType As System.Type) As WindowsUIResourceManager
        Dim UIManager As WindowsUIResourceManager = Nothing
        Dim Compmanager As ComponentResourceManager = Nothing
        If mUIResourceSet.ContainsKey(baseType) Then
            Compmanager = mUIResourceSet.Item(baseType)
            Compmanager.IgnoreCase = True
        Else
            If HasResources(baseType) Then
                Compmanager = New ComponentResourceManager(baseType)
                Compmanager.IgnoreCase = True
                mUIResourceSet.Add(baseType, Compmanager)
            Else
                Return Nothing
            End If
        End If
        UIManager = New WindowsUIResourceManager(Control, Compmanager)
        Return UIManager
    End Function
    Public Shared Sub ReleaseResources()
        mUIResourceSet.Clear()
        mMessageResSet.Clear()
    End Sub
End Class
