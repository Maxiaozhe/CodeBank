Namespace OperatingSystem.Shares
    Public Class Win32Share
        Public AccessMask As Integer
        Public AllowMaximum As Boolean
        Public Caption As String
        Public Description As String
        Public InstallDate As DateTime
        Public MaximumAllowed As Integer
        Public Name As String
        Public Path As String
        Public Status As String
        Public Type As ShareTypes
        Private mObject As Management.ManagementObject

        Friend Sub New(ByVal m As Management.ManagementObject)
            AccessMask = CInt(m.Item("AccessMask"))
            AllowMaximum = CBool(m.Item("AllowMaximum"))
            Caption = CStr(m.Item("Caption"))
            Description = CStr(m.Item("Description"))
            InstallDate = CDate(m.Item("InstallDate"))
            MaximumAllowed = CInt(m.Item("MaximumAllowed"))
            Name = CStr(m.Item("Name"))
            Path = CStr(m.Item("Path"))
            Status = CStr(m.Item("Status"))
            Type = CType(Convert.ToInt64(m.Item("Type")), ShareTypes)
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
            row.Item("AccessMask") = Convert.ToUInt32(Me.AccessMask)
            row.Item("AllowMaximum") = Me.AllowMaximum
            row.Item("Caption") = Me.Caption
            row.Item("Description") = Me.Description
            row.Item("InstallDate") = Me.InstallDate
            row.Item("MaximumAllowed") = Me.MaximumAllowed
            row.Item("Name") = Me.Name
            row.Item("Path") = Me.Path
            row.Item("Status") = Me.Status
            row.Item("Type") = Convert.ToUInt32(CLng(Me.Type))
        End Sub


        Public Enum ShareTypes As Long
            DiskDrive = 0
            PrintQueue = 1
            Device = 2
            IPC = 3
            DiskDriveAdmin = 2147483648
            PrintQueueAdmin = 2147483649
            DeviceAdmin = 2147483650
            IPCAdmin = 2147483651
        End Enum

    End Class
    Public Class Win32ShareCollection
        Inherits ArrayList
        Implements IDataSetConvert
        Friend Shadows Function Add(ByVal value As Win32Share) As Integer
            Return MyBase.Add(value)
        End Function

        Friend Shadows Sub Insert(ByVal index As Integer, ByVal value As Win32Share)
            MyBase.Insert(index, value)
        End Sub

        Default Shadows Property Item(ByVal index As Integer) As Win32Share
            Get
                Return DirectCast(MyBase.Item(index), Win32Share)
            End Get
            Set(ByVal Value As Win32Share)
                MyBase.Item(index) = Value
            End Set
        End Property

        Public Function ToDataset() As System.Data.DataSet Implements IDataSetConvert.ToDataset
            Dim Dts As New DataSet("Win32_Share_DataSet")
            Dim Dtt As New DataTable("Win32_Share")
            Dtt.Columns.AddRange(Win32Share.GetDataColums())
            For Each m As Win32Share In Me
                Dim row As DataRow = Dtt.NewRow
                m.SetDataRow(row)
                Dtt.Rows.Add(row)
            Next
            Dts.Tables.Add(Dtt)
            Return Dts
        End Function
    End Class
End Namespace

