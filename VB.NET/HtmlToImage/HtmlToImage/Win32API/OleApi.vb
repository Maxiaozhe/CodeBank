Imports System
Imports System.Runtime.InteropServices
Imports System.Runtime.InteropServices.ComTypes

Namespace Win32
    ' HRESULT
    Public Enum HRESULT As Integer
        S_OK = &H0
        S_FALSE = &H1
        ERROR_AUDITING_DISABLED = &HC0090001
        ERROR_ALL_SIDS_FILTERED = &HC0090002
    End Enum
    ' CLIPFORMAT
    Public Enum CLIPFORMAT As Short
        CF_TEXT = 1
        CF_BITMAP = 2
        CF_METAFILEPICT = 3
        CF_SYLK = 4
        CF_DIF = 5
        CF_TIFF = 6
        CF_OEMTEXT = 7
        CF_DIB = 8
        CF_PALETTE = 9
        CF_PENDATA = 10
        CF_RIFF = 11
        CF_WAVE = 12
        CF_UNICODETEXT = 13
        CF_ENHMETAFILE = 14
        CF_HDROP = 15
        CF_LOCALE = 16
        CF_MAX = 17
        CF_OWNERDISPLAY = &H80
        CF_DSPTEXT = &H81
        CF_DSPBITMAP = &H82
        CF_DSPMETAFILEPICT = &H83
        CF_DSPENHMETAFILE = &H8E
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
    ' DVASPECTINFOFLAG
    <Flags()> _
    Public Enum DVASPECTINFOFLAG As Integer
        DVASPECTINFOFLAG_CANOPTIMIZE = 1
    End Enum
    ' RECT
    <StructLayout(LayoutKind.Sequential, Pack:=4)> _
    Public Structure RECT
        Public left As Integer
        Public top As Integer
        Public right As Integer
        Public bottom As Integer
    End Structure
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
    ' STGMEDIUM
    ' COMの実装と同様に共用体を実装しようかと迷ったが、
    ' 下記に示すように実装した方が扱いが楽なので、これに決定。
    <StructLayout(LayoutKind.Explicit, Pack:=4)> _
    Public Structure STGMEDIUM
        <FieldOffset(0)> _
        Public etymed As TYMED
        <FieldOffset(4)> _
        Public handle As IntPtr
        <FieldOffset(8)> _
        Public pUnkForRelease As IntPtr
    End Structure
    ' DVASPECTINFO
    <StructLayout(LayoutKind.Sequential, Pack:=4)> _
    Public Structure DVASPECTINFO
        <MarshalAs(UnmanagedType.U4)> _
        Public cb As Integer
        Public dwFlags As DVASPECTINFOFLAG
    End Structure
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

    ' PFNCONTINUE
    Public Delegate Function PFNCONTINUE( _
     ByVal dwContinue As Integer) As Integer

    ' IViewObject
    <ComImport(), _
     Guid("0000010d-0000-0000-C000-000000000046"), _
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface IViewObject

        <PreserveSig()> _
        Function Draw( _
         ByVal dwDrawAspect As DVASPECT, _
         ByVal lindex As Integer, _
         <[In]()> _
         ByRef pvAspect As DVASPECTINFO, _
         ByVal ptd As IntPtr, _
         ByVal hdcTargetDev As IntPtr, _
         ByVal hdcDraw As IntPtr, _
         <[In]()> _
         ByRef lprcBounds As RECT, _
         <[In]()> _
         ByRef lprcWBounds As RECT, _
         <MarshalAs(UnmanagedType.FunctionPtr)> _
         ByVal pfnContinueProc As PFNCONTINUE, _
         ByVal dwContinue As Integer) As HRESULT

        <PreserveSig()> _
        Function GetColorSet( _
         ByVal dwDrawAspect As DVASPECT, _
         ByVal lindex As Integer, _
         <[In]()> _
         ByRef pvAspect As DVASPECTINFO, _
         ByVal ptd As IntPtr, _
         ByVal hicTargetDev As IntPtr, _
         <Out()> _
         ByRef ppColorSet As IntPtr) As HRESULT

        <PreserveSig()> _
        Function Freeze( _
         ByVal dwDrawAspect As DVASPECT, _
         ByVal lindex As Integer, _
         <[In]()> _
         ByRef pvAspect As DVASPECTINFO, _
         <Out()> _
         ByRef pdwFreeze As Integer) As HRESULT

        <PreserveSig()> _
        Function Unfreeze( _
         ByVal dwFreeze As Integer) As HRESULT

        <PreserveSig()> _
        Function SetAdvise( _
         ByVal dwDrawAspect As DVASPECT, _
         ByVal advflag As ADVF, _
         ByVal pAdvSink As IAdviseSink) As HRESULT

        <PreserveSig()> _
        Function GetAdvise( _
         <Out()> _
         ByRef pAspects As DVASPECT, _
         <Out()> _
         ByRef pAdvf As ADVF, _
         <Out()> _
         ByRef ppAdvSink As IAdviseSink) As HRESULT

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
         ByVal pmk As IMoniker)

        <PreserveSig()> _
        Sub OnSave()

        <PreserveSig()> _
        Sub OnClose()
    End Interface
End Namespace