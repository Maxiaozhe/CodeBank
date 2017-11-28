Imports System.Resources
Imports System.Reflection
Imports System.ComponentModel
Imports System.Web.UI
Imports System.Windows.Forms
Imports System.Globalization
''' <summary>
''' アプリケーションのリソースマネジャーの管理クラス
''' </summary>
''' <remarks></remarks>
Public Class ResManager
    Private Shared mUIResourceSet As New Dictionary(Of Type, ComponentResourceManager)
    Private Shared mMessageResSet As New Dictionary(Of Type, System.Resources.ResourceManager)
    ''' <summary>
    ''' リソースファイルが存在するか？
    ''' </summary>
    ''' <param name="Type">リソースの対象オブジェクトのタイプ</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function HasResources(ByVal Type As Type) As Boolean
        Dim ResourceFilename As String = Type.FullName & ".resources"
        Dim resFiles() As String = Type.Assembly.GetManifestResourceNames()
        Dim Ret As Integer = Aggregate f In resFiles Into Count(f.ToLower = ResourceFilename.ToLower)
        If Ret > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    ''' <summary>
    ''' Web系UIリソースマネジャーを取得する
    ''' </summary>
    ''' <param name="Control">Web系ページ及びコントロールのインスタンス</param>
    ''' <param name="baseType">Web系ページ及びコントロールの基本データタイプ</param>
    ''' <returns>WebUIResourceManagerを取得する。リソースファイル存在しない場合、Nothingで返す。</returns>
    ''' <remarks>Page及びUserControlのリソースファイルがない場合、UIリソースマネジャーを取得できません。
    ''' <list>リソースファイルの追加例：WebPage.Aspxのリソースファイル名→WebPage.Aspx.resx</list>
    ''' <list>Page及びUserControlの基本タイプの取得方法: <code>Me.GetType().BaseType</code></list>
    ''' </remarks>
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
    ''' <param name="Control">Windows系Form及びコントロールのインスタンス</param>
    ''' <param name="baseType">Windows系Form及びコントロールのデータタイプ</param>
    ''' <returns>WindowsUIResourceManagerを取得する。リソースファイル存在しない場合、Nothingで返す。</returns>
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
    ''' <summary>
    ''' メッセージリソースマネジャー
    ''' </summary>
    ''' <param name="MessageType">メッセージ及び文字列のリソース種別</param>
    ''' <returns>MessageResourcesManagerを取得する</returns>
    ''' <remarks></remarks>
    Public Shared Function GetMessageResourceManager(ByVal MessageType As Object) As MessageResourcesManager
        Dim MsgManager As MessageResourcesManager = Nothing
        Dim resManager As System.Resources.ResourceManager = Nothing
        Dim baseType As Type = MessageType.GetType()
        If mMessageResSet.ContainsKey(MessageType.GetType()) Then
            resManager = mMessageResSet.Item(baseType)
            resManager.IgnoreCase = True
        Else
            If HasResources(baseType) Then
                resManager = New System.Resources.ResourceManager(baseType)
                resManager.IgnoreCase = True
                mMessageResSet.Add(baseType, resManager)
            Else
                Return Nothing
            End If
        End If

        MsgManager = New MessageResourcesManager(resManager)
        Return MsgManager
    End Function
    ''' <summary>
    ''' リソースを解放する
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub ReleaseResources()
        For Each key As Type In mUIResourceSet.Keys
            Dim crm As ComponentResourceManager = mUIResourceSet.Item(key)
            If crm IsNot Nothing Then
                crm.ReleaseAllResources()
            End If
        Next
        mUIResourceSet.Clear()
        For Each key As Type In mMessageResSet.Keys
            Dim mrm As System.Resources.ResourceManager = mMessageResSet.Item(key)
            If mrm IsNot Nothing Then
                mrm.ReleaseAllResources()
            End If
        Next
        mMessageResSet.Clear()
    End Sub
End Class
