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

    Private Function AnalyzeResource() As SortedList(Of String, String)
        Dim culture As CultureInfo = System.Threading.Thread.CurrentThread.CurrentUICulture
        Dim rs = Me.mResManger.GetResourceSet(culture, True, True).Cast(Of DictionaryEntry)()
        Dim RsLinq = From r In rs Order By CStr(r.Key).ToLower
        Dim ResList As New SortedList(Of String, String)
        For Each entry In RsLinq
            Dim FullPath As String = CStr(entry.Key)
            Dim sect() As String = FullPath.Split("."c)
            If sect.Length < 2 Then
                Continue For
            End If
            Dim path As String = ""
            For i = 0 To sect.Length - 2
                If i > 0 Then
                    path &= "."
                End If
                path &= sect(i).ToLower
                If ResList.ContainsKey(path) = False Then
                    ResList.Add(path, sect(i))
                End If
            Next
        Next
        Return ResList
    End Function

    Public Function FindResources(ByVal name As String) As SortedList(Of String, Object)
        Dim culture As CultureInfo = System.Threading.Thread.CurrentThread.CurrentUICulture
        Dim rs = Me.mResManger.GetResourceSet(culture, True, True).Cast(Of DictionaryEntry)()
        Dim RsLinq = From r In rs Where CStr(r.Key).ToLower Like name.ToLower & ".%"
        Dim List As New SortedList(Of String, Object)
        For Each entry As DictionaryEntry In RsLinq
            List.Add(CStr(entry.Key), entry.Value)
        Next
        Return List
    End Function

    Public Function HasResources(ByVal name As String) As Boolean
        Dim culture As CultureInfo = System.Threading.Thread.CurrentThread.CurrentUICulture
        Dim rs = Me.mResManger.GetResourceSet(culture, True, True).Cast(Of DictionaryEntry)()
        Dim num = Aggregate r In rs Into Count(CStr(r.Key).ToLower Like name.ToLower & ".*")
        Return num > 0
    End Function

    Private Sub ApplyChildResources(ByVal Parent As Control)
        Dim ResList As SortedList(Of String, String) = AnalyzeResource()
        Dim CurrentObj As Object = Nothing
        For Each key As String In ResList.Keys
            If key.IndexOf(".") < 0 Then
                If key.ToLower = "$this" Then
                    CurrentObj = Parent
                    mResManger.ApplyResources(Parent, key)
                Else
                    CurrentObj = Parent.FindControl(key)
                    mResManger.ApplyResources(CurrentObj, key)
                End If
            Else
                If CurrentObj IsNot Nothing Then
                    CurrentObj = ApplyProperties(CurrentObj, key)
                End If
            End If
        Next
    End Sub


    Private Function ApplyProperties(ByVal Obj As Object, ByVal Name As String) As Object
        Dim flag As BindingFlags = BindingFlags.IgnoreCase Or BindingFlags.GetProperty Or BindingFlags.Instance Or BindingFlags.Public
        Dim Num As Integer = Name.IndexOf(".")
        If Num < 0 Then
            Return Nothing
        End If
        Dim propName As String = Name.Substring(Num + 1)
        Dim Prop As PropertyInfo = Obj.GetType().GetProperty(propName, flag)
        If Prop IsNot Nothing AndAlso Prop.CanRead Then
            Dim PropVal As Object = Prop.GetValue(Obj, Nothing)
            If PropVal IsNot Nothing AndAlso TypeOf PropVal Is IList Then
                Dim index As Integer = 0
                For Each item In DirectCast(PropVal, IList)
                    mResManger.ApplyResources(item, Name & ".Item" & index)
                    index += 1
                Next
                Return Nothing
            Else
                mResManger.ApplyResources(PropVal, Name)
                Return PropVal
            End If
        End If
        Return Nothing
    End Function

    Private Sub ApplyChildResources(ByVal Parent As Control, ByVal name As String)
        If name IsNot Nothing AndAlso name <> "" Then
            mResManger.ApplyResources(Parent, name)
            If Me.HasResources(name) = True Then
                ApplyProperties(Parent, name & ".Items")
                ApplyProperties(Parent, name & ".Columns")
            End If
        End If
        If Parent.HasControls Then
            For Each ctrl As Control In Parent.Controls
                ApplyChildResources(ctrl, ctrl.ID)
            Next
        End If
    End Sub

    Public Sub ApplyResources()
        ApplyChildResources(mControl)
    End Sub

    Public Sub ChangeLanguage(ByVal Culture As System.Globalization.CultureInfo)
        System.Threading.Thread.CurrentThread.CurrentUICulture = Culture
        ApplyChildResources(mControl)
    End Sub

    Public Function GetString(ByVal Key As String) As String
        Return mResManger.GetString(Key)
    End Function
End Class
