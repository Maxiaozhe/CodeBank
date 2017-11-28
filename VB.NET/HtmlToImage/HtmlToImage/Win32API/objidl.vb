Imports System
Imports System.Runtime.InteropServices
Imports HtmlToImage.Win32
Namespace OBJIDL

    ' STGM
    <Flags()> _
    Public Enum STGM As Integer
        STGM_DIRECT = &H0
        STGM_TRANSACTED = &H10000
        STGM_SIMPLE = &H8000000
        STGM_READ = &H0
        STGM_WRITE = &H1
        STGM_READWRITE = &H2
        STGM_SHARE_DENY_NONE = &H40
        STGM_SHARE_DENY_READ = &H30
        STGM_SHARE_DENY_WRITE = &H20
        STGM_SHARE_EXCLUSIVE = &H10
        STGM_PRIORITY = &H40000
        STGM_DELETEONRELEASE = &H4000000
        STGM_NOSCRATCH = &H100000
        STGM_CREATE = &H1000
        STGM_CONVERT = &H20000
        STGM_FAILIFTHERE = &H0
        STGM_NOSNAPSHOT = &H200000
    End Enum

    ' DVASPECT
    <Flags()> _
    Public Enum DVASPECT As Integer
        DVASPECT_CONTENT = 1
        DVASPECT_THUMBNAIL = 2
        DVASPECT_ICON = 4
        DVASPECT_DOCPRINT = 8
        DVASPECT_OPAQUE = 16
        DVASPECT_TRANSPARENT = 32
    End Enum

    ' TYMED
    <Flags()> _
    Public Enum TYMED As Integer
        TYMED_NULL = 0
        TYMED_HGLOBAL = 1
        TYMED_FILE = 2
        TYMED_ISTREAM = 4
        TYMED_ISTORAGE = 8
        TYMED_GDI = 16
        TYMED_MFPICT = 32
        TYMED_ENHMF = 64
    End Enum

    ' DATADIR
    Public Enum DATADIR As Integer
        DATADIR_GET = 1
        DATADIR_SET = 2
    End Enum

    ' ADVF
    <Flags()> _
    Public Enum ADVF As Integer
        ADVF_NODATA = 1
        ADVF_ONLYONCE = 2
        ADVF_PRIMEFIRST = 4
        ADVF_CACHE_NOHANDLER = 8
        ADVF_CACHE_FORCEBUILTIN = 16
        ADVF_CACHE_ONSAVE = 32
        ADVF_DATAONSTOP = 64
    End Enum


    ' FORMATETC
    <StructLayout(LayoutKind.Sequential, Pack:=4)> _
    Public Structure FORMATETC
        Public cfFormat As CLIPFORMAT
        Public ptd As IntPtr
        Public dwAspect As DVASPECT
        Public lindex As Integer
        Public etymed As TYMED
    End Structure

    ' STGMEDIUM
    ' COMの実装と同様に共用体を実装しようかと迷ったが、
    ' 下記に示すように実装した方が扱いが楽なので、これに決定。
    <StructLayout(LayoutKind.Explicit, Pack:=4)> _
    Public Structure STGMEDIUM
        <FieldOffset(0)> _
        Public etymed As TYMED
        '		<FieldOffset(4)> _
        '		Public hBitmap As IntPtr
        '		<FieldOffset(4)> _
        '		Public hMetaFilePict As IntPtr
        '		<FieldOffset(4)> _
        '		Public hEnhMetaFile As IntPtr
        '		<FieldOffset(4)> _
        '		Public hGlobal As IntPtr
        '		<FieldOffset(4), MarshalAs(UnmanagedType.LPWStr)> _
        '		Public lpszFileName As String
        '		<FieldOffset(4)> _
        '		Public pstm As UCOMIStream
        '		<FieldOffset(4)> _
        '		Public pstg As IStorage
        <FieldOffset(4)> _
        Public handle As IntPtr
        <FieldOffset(8)> _
        Public pUnkForRelease As IntPtr
    End Structure

    ' STATDATA
    <StructLayout(LayoutKind.Sequential, Pack:=4)> _
    Public Structure STATDATA
        <MarshalAs(UnmanagedType.Struct)> _
        Public formatetc As FORMATETC
        Public advflag As ADVF
        Public pAdvSink As IAdviseSink
        Public dwConnection As Integer
    End Structure

    ' DVTARGETDEVICE
    <StructLayout(LayoutKind.Sequential, Pack:=4)> _
    Public Structure DVTARGETDEVICE
        Public tdSize As Integer
        Public tdDriverNameOffset As Short
        Public tdDeviceNameOffset As Short
        Public tdPortNameOffset As Short
        Public tdExtDevmodeOffset As Short
        <MarshalAs(UnmanagedType.ByValArray, ArraySubType:=UnmanagedType.U1, SizeConst:=1024)> _
           Public tdData() As Byte
    End Structure


    ' PFNCONTINUE
    Public Delegate Function PFNCONTINUE( _
     ByVal dwContinue As Integer) As Integer

    ' IEnumFORMATETC
    <ComImport(), _
     Guid("00000103-0000-0000-C000-000000000046"), _
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface IEnumFORMATETC

        <PreserveSig()> _
        Function [Next]( _
         ByVal celt As Integer, _
         <Out(), MarshalAs(UnmanagedType.LPArray)> _
         ByVal rgelt() As FORMATETC, _
         <Out()> _
         ByRef pceltFetched As Integer) As HRESULT

        <PreserveSig()> _
        Function Skip( _
         ByVal celt As Integer) As HRESULT

        <PreserveSig()> _
        Function Reset() As HRESULT

        <PreserveSig()> _
        Function Clone( _
         <Out()> _
         ByRef ppenum As IEnumFORMATETC) As HRESULT

    End Interface

    ' IEnumSTATDATA
    <ComImport(), _
     Guid("00000105-0000-0000-C000-000000000046"), _
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface IEnumSTATDATA

        <PreserveSig()> _
        Function [Next]( _
         ByVal celt As Integer, _
         <Out(), MarshalAs(UnmanagedType.LPArray)> _
         ByVal rgelt() As STATDATA, _
         <Out()> _
         ByRef pceltFetched As Integer) As HRESULT

        <PreserveSig()> _
        Function Skip( _
         ByVal celt As Integer) As HRESULT

        <PreserveSig()> _
        Function Reset() As HRESULT

        <PreserveSig()> _
        Function Clone( _
         <Out()> _
         ByRef ppenum As IEnumSTATDATA) As HRESULT

    End Interface

    ' IDataObject
    <ComImport(), _
     Guid("0000010e-0000-0000-C000-000000000046"), _
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface IDataObject

        <PreserveSig()> _
        Function GetData( _
         <[In]()> _
         ByRef pformatetc As FORMATETC, _
         <Out()> _
         ByRef pmedium As STGMEDIUM) As HRESULT

        <PreserveSig()> _
        Function GetDataHere( _
         <[In]()> _
         ByRef pformatetc As FORMATETC, _
         <Out()> _
         ByRef pmedium As STGMEDIUM) As HRESULT

        <PreserveSig()> _
        Function QueryGetData( _
         <[In]()> _
         ByRef pformatetc As FORMATETC) As HRESULT

        <PreserveSig()> _
        Function GetCanonicalFormatEtc( _
         <[In]()> _
         ByRef pformatetcIn As FORMATETC, _
         <Out()> _
         ByRef pformatetcOut As FORMATETC) As HRESULT

        <PreserveSig()> _
        Function SetData( _
         <[In]()> _
         ByRef pformatetc As FORMATETC, _
         <[In]()> _
         ByRef pmedium As STGMEDIUM, _
         <MarshalAs(UnmanagedType.Bool)> _
         ByVal fRelease As Boolean) As HRESULT

        <PreserveSig()> _
        Function EnumFormatEtc( _
         ByVal dwDirection As DATADIR, _
         <Out()> _
         ByRef ppenumFormatEtc As IEnumFORMATETC) As HRESULT

        <PreserveSig()> _
        Function DAdvise( _
         <[In]()> _
         ByRef pformatetc As FORMATETC, _
         ByVal advflag As ADVF, _
         ByVal pAdvSink As IAdviseSink, _
         <Out()> _
         ByRef pdwConnection As Integer) As HRESULT

        <PreserveSig()> _
        Function DUnadvise( _
         ByVal dwConnection As Integer) As HRESULT

        <PreserveSig()> _
        Function EnumDAdvise( _
         <Out()> _
         ByRef ppenumAdvise As IEnumSTATDATA) As HRESULT

    End Interface

    ' IAdviseSink
    <ComImport(), _
     Guid("0000010f-0000-0000-C000-000000000046"), _
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface IAdviseSink

        <PreserveSig()> _
        Sub OnDataChange( _
         <[In]()> _
         ByRef pformatetc As FORMATETC, _
         <[In]()> _
         ByRef pmedium As STGMEDIUM)

        <PreserveSig()> _
        Sub OnViewChange( _
         ByVal dwAspect As DVASPECT, _
         ByVal lindex As Integer)

        <PreserveSig()> _
        Sub OnRename( _
         ByVal pmk As UCOMIMoniker)

        <PreserveSig()> _
        Sub OnSave()

        <PreserveSig()> _
        Sub OnClose()

    End Interface

End Namespace
