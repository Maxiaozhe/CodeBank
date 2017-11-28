Imports System.Runtime.InteropServices
Imports System.Security.Principal
Public Class UserLogin
    Private Const LOGON32_PROVIDER_DEFAULT As Integer = 0
    'This parameter causes LogonUser to create a primary token.
    Private Const LOGON32_LOGON_INTERACTIVE As Integer = 2

    Private _impersonatedUser As WindowsImpersonationContext
    Private _TokenHandle As IntPtr

    Private Declare Auto Function LogonUser Lib "advapi32.dll" (ByVal lpszUsername As [String], _
          ByVal lpszDomain As [String], ByVal lpszPassword As [String], _
          ByVal dwLogonType As Integer, ByVal dwLogonProvider As Integer, _
          ByRef phToken As IntPtr) As Boolean

    <DllImport("kernel32.dll")> _
    Private Shared Function FormatMessage(ByVal dwFlags As Integer, ByRef lpSource As IntPtr, _
        ByVal dwMessageId As Integer, ByVal dwLanguageId As Integer, ByRef lpBuffer As [String], _
        ByVal nSize As Integer, ByRef Arguments As IntPtr) As Integer

    End Function

    Private Declare Auto Function CloseHandle Lib "kernel32.dll" (ByVal handle As IntPtr) As Boolean


    Private Declare Auto Function DuplicateToken Lib "advapi32.dll" (ByVal ExistingTokenHandle As IntPtr, _
            ByVal SECURITY_IMPERSONATION_LEVEL As Integer, _
            ByRef DuplicateTokenHandle As IntPtr) As Boolean



    Public Function Login(ByVal UserName As String, ByVal Password As String, ByVal Domain As String) As Boolean
        Dim dupeTokenHandle As New IntPtr(0)
        _TokenHandle = IntPtr.Zero
        Dim returnValue As Boolean = LogonUser(UserName, Domain, Password, LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT, _TokenHandle)
        If returnValue = False Then
            Dim ret As Integer = Marshal.GetLastWin32Error()
            Throw New System.ComponentModel.Win32Exception(ret)
        End If
        Dim newId As New WindowsIdentity(_TokenHandle)
        _impersonatedUser = newId.Impersonate()
        Return True
    End Function

    Public Function LogOff() As Boolean
        If Me._impersonatedUser IsNot Nothing Then
            _impersonatedUser.Undo()
        End If
        If _TokenHandle <> IntPtr.Zero Then
            CloseHandle(_TokenHandle)
        End If
    End Function

End Class
