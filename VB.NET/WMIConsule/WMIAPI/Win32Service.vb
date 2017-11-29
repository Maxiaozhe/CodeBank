Namespace OperatingSystem.Services
    Public Class Win32Service
        Public AcceptPause As Boolean
        Public AcceptStop As Boolean
        Public Caption As String
        Public CheckPoint As System.UInt32
        Public CreationClassName As String
        Public Description As String
        Public DesktopInteract As Boolean
        Public DisplayName As String
        Public ErrorControl As String
        Public ExitCode As System.UInt32
        Public InstallDate As DateTime
        Public Name As String
        Public PathName As String
        Public ProcessId As System.UInt32
        Public ServiceSpecificExitCode As UInt32
        Public ServiceType As String
        Public Started As Boolean
        Public StartMode As String
        Public StartName As String
        Public State As String
        Public Status As String
        Public SystemCreationClassName As String
        Public SystemName As String
        Public TagId As System.UInt32
        Public WaitHint As System.UInt32
        Private mObject As Management.ManagementObject
        Friend Sub New(ByVal m As Management.ManagementObject)
            AcceptPause = CBool(m.Item("AcceptPause"))
            AcceptStop = CBool(m.Item("AcceptStop"))
            Caption = CStr(m.Item("Caption"))
            CheckPoint = CType(m.Item("CheckPoint"), UInt32)
            CreationClassName = CStr(m.Item("CreationClassName"))
            Description = CStr(m.Item("Description"))
            DesktopInteract = CBool(m.Item("DesktopInteract"))
            DisplayName = CStr(m.Item("DisplayName"))
            ErrorControl = CStr(m.Item("ErrorControl"))
            ExitCode = CType(m.Item("ExitCode"), System.UInt32)

            InstallDate = CDate(m.Item("InstallDate"))
            Name = CStr(m.Item("Name"))
            PathName = CStr(m.Item("PathName"))
            ProcessId = CType(m.Item("ProcessId"), UInt32)
            ServiceSpecificExitCode = CType(m.Item("ServiceSpecificExitCode"), UInt32)
            ServiceType = CStr(m.Item("ServiceType"))
            Started = CBool(m.Item("Started"))
            StartMode = CStr(m.Item("StartMode"))
            StartName = CStr(m.Item("StartName"))

            State = CStr(m.Item("State"))
            Status = CStr(m.Item("Status"))
            SystemCreationClassName = CStr(m.Item("SystemCreationClassName"))
            SystemName = CStr(m.Item("SystemName"))
            TagId = CType(m.Item("TagId"), UInt32)
            WaitHint = CType(m.Item("WaitHint"), UInt32)

            mObject = m
        End Sub

        Public Shared Function GetDataColums() As DataColumn()
            Dim ColArray As New ArrayList
            Dim Col As DataColumn
            Col = New DataColumn("AccessMask", GetType(System.UInt32))
            ColArray.Add(Col)
            Col = New DataColumn("AllowMaximum", GetType(System.Boolean))
            ColArray.Add(Col)
            Col = New DataColumn("Caption", GetType(System.String))
            ColArray.Add(Col)
            Col = New DataColumn("Description", GetType(System.String))
            ColArray.Add(Col)
            Col = New DataColumn("InstallDate", GetType(System.DateTime))
            ColArray.Add(Col)
            Col = New DataColumn("MaximumAllowed", GetType(System.UInt32))
            ColArray.Add(Col)
            Col = New DataColumn("Name", GetType(System.String))
            ColArray.Add(Col)
            Col = New DataColumn("Path", GetType(System.String))
            ColArray.Add(Col)
            Col = New DataColumn("Status", GetType(System.String))
            ColArray.Add(Col)
            Col = New DataColumn("Type", GetType(System.UInt32))
            ColArray.Add(Col)
            Return CType(ColArray.ToArray(GetType(DataColumn)), DataColumn())
        End Function
        Public Sub SetDataRow(ByVal row As DataRow)
            'row.Item("AccessMask") = Convert.ToUInt32(Me.AccessMask)
            'row.Item("AllowMaximum") = Me.AllowMaximum
            'row.Item("Caption") = Me.Caption
            'row.Item("Description") = Me.Description
            'row.Item("InstallDate") = Me.InstallDate
            'row.Item("MaximumAllowed") = Me.MaximumAllowed
            'row.Item("Name") = Me.Name
            'row.Item("Path") = Me.Path
            'row.Item("Status") = Me.Status
            'row.Item("Type") = Convert.ToUInt32(CLng(Me.Type))
        End Sub
    End Class

End Namespace
