Imports System.Linq.Expressions
Public Class LinkExpress
    Public Shared Function TestFunc() As String
        Dim DynFunc As Func(Of Integer, String) = Function(num) _
        num.ToString("#,#")
        Dim number As Integer = 113000
        Dim buf As String = DynFunc(number)
        Return buf
    End Function
    Public Shared Function test2() As List(Of String)
        Dim predicate As Func(Of String, Integer, Boolean) = Function(str, index) str.Length = index

        Dim words() As String = {"orange", "apple", "Article", "elephant", "star", "and"}
        Dim aWords As IEnumerable(Of String) = words.Where(predicate)
        Dim ret As New List(Of String)
        For Each word As String In aWords
            ret.Add(word)
        Next
        Return ret
    End Function
    Public Shared Function test3() As List(Of String)
        Dim words() As String = {"orange", "apple", "Article", "elephant", "star", "and"}
        Dim rets As IEnumerable(Of String) = From str In words Where str Like "or*"
        Return New List(Of String)(rets)
    End Function
End Class
