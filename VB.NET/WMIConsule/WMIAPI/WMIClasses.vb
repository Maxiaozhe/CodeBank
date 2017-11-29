Imports System.Management
Public Class WMIClasses
    Public Function GetCIMV2Classes() As ManagementObjectCollection
        Dim scope As New System.Management.ManagementScope("root\CIMV2")
        scope.Connect()
        Dim newClass As New ManagementClass(scope, _
            New ManagementPath, _
            Nothing)

        Dim options As New EnumerationOptions
        options.Rewindable = True
        Dim Mobjs As Management.ManagementObjectCollection = newClass.GetSubclasses(options)
        'For Each Mobj As ManagementObject In Mobjs
        '    Dim Text As String = Mobj.GetText(TextFormat.WmiDtd20)
        '    Dim classname As String = Mobj.ClassPath.ClassName
        '    Dim Classpath As String = Mobj.ClassPath.Path
        'Next
        Return Mobjs
    End Function
    Public Function GetLDAPClasses() As ManagementObjectCollection
        Dim options As New Management.ConnectionOptions
        Dim scope As New System.Management.ManagementScope("root\directory\LDAP", options)
        scope.Connect()
        Dim newClass As New ManagementClass(scope, _
            New ManagementPath, _
            Nothing)
        Dim opt As New EnumerationOptions
        opt.Rewindable = True
        Dim Mobjs As Management.ManagementObjectCollection = newClass.GetSubclasses(opt)
        'For Each Mobj As ManagementObject In Mobjs
        '    Dim Text As String = Mobj.GetText(TextFormat.WmiDtd20)
        '    Dim classname As String = Mobj.ClassPath.ClassName
        '    Dim Classpath As String = Mobj.ClassPath.Path
        'Next
        Return Mobjs
    End Function
    Public Function GetCLIClasses() As ManagementObjectCollection
        Dim options As New Management.ConnectionOptions
        Dim scope As New System.Management.ManagementScope("root\cli", options)
        scope.Connect()
        Dim newClass As New ManagementClass(scope, _
            New ManagementPath, _
            Nothing)
        Dim opt As New EnumerationOptions
        opt.Rewindable = True
        Dim Mobjs As Management.ManagementObjectCollection = newClass.GetSubclasses(opt)
        'For Each Mobj As ManagementObject In Mobjs
        '    Dim Text As String = Mobj.GetText(TextFormat.WmiDtd20)
        '    Dim classname As String = Mobj.ClassPath.ClassName
        '    Dim Classpath As String = Mobj.ClassPath.Path
        'Next
        Return Mobjs
    End Function
End Class
