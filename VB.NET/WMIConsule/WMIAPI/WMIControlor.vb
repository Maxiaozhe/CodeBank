Imports System.Management
Imports WMIAPI.OperatingSystem
Public Class WMIControlor
    Public Function GetWin32Shares() As Shares.Win32ShareCollection
        Dim Manager As New System.Management.ManagementClass("Win32_Share")
        Dim Mangers As Management.ManagementObjectCollection = Manager.GetInstances()
        Dim Shares As New Shares.Win32ShareCollection
        For Each m As Management.ManagementObject In Mangers
            Dim share As New Shares.Win32Share(m)
            Shares.Add(share)
        Next
        Return Shares
    End Function
    Public Function GetIIS() As Shares.Win32ShareCollection
        Try
            Dim path As New Management.ManagementPath("Win32_Directory.Drive='c:'")
            path.NamespacePath = "root\cimv2"
            Dim Manager As New System.Management.ManagementClass(path)

            Dim Mangers As Management.ManagementObjectCollection = Manager.GetInstances()
            Dim Shares As New Shares.Win32ShareCollection

            For Each m As Management.ManagementObject In Mangers
                Dim name As String = CStr(m.Item("Name"))
                Debug.WriteLine(name)
            Next
            Return Shares

        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
