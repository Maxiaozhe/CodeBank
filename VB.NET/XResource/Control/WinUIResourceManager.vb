Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Globalization
Imports System.Resources
Imports System.Reflection



Public Class WindowsUIResourceManager

    Private mResManger As ComponentResourceManager
    Private mControl As Control

    Friend Sub New(ByVal Ctrl As Control, ByVal manager As ComponentResourceManager)
        mControl = Ctrl
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
                    Dim Controls() As Object = FindComponent(Parent, key)
                    If Controls IsNot Nothing AndAlso Controls.Count > 0 Then
                        CurrentObj = Controls(0)
                        mResManger.ApplyResources(CurrentObj, key)
                    End If
                End If
            Else
                If CurrentObj IsNot Nothing Then
                    CurrentObj = ApplyProperties(CurrentObj, key)
                End If
            End If
        Next
    End Sub

    Private Function FindComponent(ByVal parent As Component, ByVal key As String) As Object()
        Dim ctrls() As Control = DirectCast(parent, Control).Controls.Find(key, True)
        If ctrls IsNot Nothing AndAlso ctrls.Count > 0 Then
            Return ctrls
        Else
            Dim compType As Type = parent.GetType()
            Dim flag As BindingFlags = Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance Or Reflection.BindingFlags.Static Or BindingFlags.IgnoreCase Or BindingFlags.Public
            Dim fld As FieldInfo = compType.GetField("_" & key, flag)
            If fld Is Nothing Then
                Return Nothing
            Else
                Dim fldInstance As Object = fld.GetValue(parent)
                Return New Object() {fldInstance}
            End If
        End If
    End Function

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
                For index = 0 To DirectCast(PropVal, IList).Count - 1
                    If Me.mResManger.GetString(Name & ".Item" & index) IsNot Nothing Then
                        DirectCast(PropVal, IList).Item(index) = Me.mResManger.GetString(Name & ".Item" & index)
                    Else
                        mResManger.ApplyResources(DirectCast(PropVal, IList).Item(index), Name & ".Item" & index)
                    End If
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
        End If
        If Parent.HasChildren Then
            For Each ctrl As Control In Parent.Controls
                ApplyChildResources(ctrl, ctrl.Name)
            Next
        End If
    End Sub

    Public Sub ApplyResources()
        'ApplyChildResources(mControl, "$this")
        ApplyChildResources(mControl)
    End Sub

    Public Sub ChangeLanguage(ByVal Culture As System.Globalization.CultureInfo, ByVal reset As Boolean)
        System.Threading.Thread.CurrentThread.CurrentUICulture = Culture
        If reset = False Then
            ApplyChildResources(mControl)
        Else
            If TypeOf mControl Is Form Then
                My.Application.ChangeUICulture(Culture.IetfLanguageTag)
            End If
        End If
    End Sub

    Public Function GetString(ByVal Key As String) As String
        Return mResManger.GetString(Key)
    End Function

End Class
