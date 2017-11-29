Imports System.Management

Public Class WMIQuery
    Public Shared Function Search(ByVal Wql As String) As ManagementObjectCollection
        Dim objectQuery As New WqlObjectQuery(Wql)
        Dim searcher As New ManagementObjectSearcher(objectQuery)
        Dim mobj As ManagementObjectCollection = searcher.Get()
        Return mobj

    End Function
End Class
