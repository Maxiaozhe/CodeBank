Imports SQLViewer.DBAccess
Imports SQLViewer.DBAccess.DBSchema
Public Class MyTabControl
    Inherits TabControl
    Private WithEvents tab As TabPage
    Public Sub AddTabPage(ByVal newpage As TabPage)
        Dim page As TabPage = Nothing
        If (newpage.Tag Is Nothing) Then
            Me.TabPages.Add(newpage)
            Me.SelectedTab = newpage
            Return
        End If

        For Each page In Me.TabPages
            Dim tag As Object = page.Tag
            If (Not tag Is Nothing) AndAlso (TypeOf tag Is iSqlObject) Then
                If (CType(tag, iSqlObject).GetFullName = CType(newpage.Tag, iSqlObject).GetFullName) _
                  AndAlso (CType(tag, iSqlObject).ObjType = CType(newpage.Tag, iSqlObject).ObjType) Then
                    Me.SelectedTab = page
                    Return
                End If
            ElseIf TypeOf tag Is String AndAlso TypeOf newpage.Tag Is String Then
                If CStr(tag) = CStr(newpage.Tag) Then
                    Me.SelectedTab = page
                    Return
                End If
            End If
        Next
        Me.TabPages.Add(newpage)
        Me.SelectedTab = newpage
    End Sub
    Public Function GetNewQueryIndex() As Integer
        Dim page As TabPage = Nothing
        Dim index As Integer = 1
        For Each page In Me.TabPages
            Dim tag As Object = page.Tag
            If (Not tag Is Nothing) AndAlso (TypeOf tag Is SqlQuery) Then
                index += 1
            End If
        Next
        Return index
    End Function
End Class
