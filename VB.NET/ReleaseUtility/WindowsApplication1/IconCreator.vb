
Imports System.Runtime.InteropServices

Public Class Win32

    Public Const SHGFI_ICON As Integer = &H100
    Public Const SHGFI_LARGEICON As Integer = &H0  'Large icon
    Public Const SHGFI_SMALLICON As Integer = &H1  'Small icon

    <DllImport("shell32.dll")>
    Private Shared Function SHGetFileInfo(ByVal pszPath As String, ByVal dwFileAttributes As Integer, ByRef psfi As SHFILEINFO, ByVal cbSizeFileInfo As Integer, ByVal uFlags As Integer) As IntPtr

    End Function

    Public Shared Function GetSmallIcon(ByVal filePath As String) As Icon
        If System.IO.File.Exists(filePath) = False Then
            Return Nothing
        End If
        Dim shinfo As New SHFILEINFO()
        Dim hImgSmall As IntPtr = Win32.SHGetFileInfo(filePath, 0, shinfo, Marshal.SizeOf(shinfo), Win32.SHGFI_ICON Or Win32.SHGFI_SMALLICON)
        Dim SmallIcon As Icon = System.Drawing.Icon.FromHandle(shinfo.hIcon)
        Return SmallIcon
    End Function

    Public Shared Function GetLargeIcon(ByVal filePath As String) As Icon
        If System.IO.File.Exists(filePath) = False Then
            Return Nothing
        End If
        Dim shinfo As New SHFILEINFO()
        Dim hImgSmall As IntPtr = Win32.SHGetFileInfo(filePath, 0, shinfo, Marshal.SizeOf(shinfo), Win32.SHGFI_ICON Or Win32.SHGFI_LARGEICON)
        Dim SmallIcon As Icon = System.Drawing.Icon.FromHandle(shinfo.hIcon)
        Return SmallIcon
    End Function
End Class
<StructLayout(LayoutKind.Sequential)>
Public Structure SHFILEINFO
    Public hIcon As IntPtr
    Public iIcon As IntPtr
    Public dwAttributes As Integer
    <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=260)>
    Public szDisplayName As String
    <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=80)>
    Public szTypeName As String
End Structure


