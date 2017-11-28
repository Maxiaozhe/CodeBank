Imports System
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports HtmlToImage
Imports HtmlToImage.Win32
Imports HtmlToImage.OBJIDL

Namespace OLEIDL

	' OLEGETMONIKER
	Public Enum OLEGETMONIKER As Integer
		OLEGETMONIKER_ONLYIFTHERE = 1
		OLEGETMONIKER_FORCEASSIGN = 2
		OLEGETMONIKER_UNASSIGN    = 3
		OLEGETMONIKER_TEMPFORUSER = 4
	End Enum

	' OLEWHICHMK
	Public Enum OLEWHICHMK As Integer
		OLEWHICHMK_CONTAINER = 1
		OLEWHICHMK_OBJREL    = 2
		OLEWHICHMK_OBJFULL   = 3
	End Enum

	' USERCLASSTYPE
	Public Enum USERCLASSTYPE As Integer
		USERCLASSTYPE_FULL    = 1
		USERCLASSTYPE_SHORT   = 2
		USERCLASSTYPE_APPNAME = 3
	End Enum

	' OLEMISC
	<Flags()> _
	Public Enum OLEMISC As Integer
		OLEMISC_RECOMPOSEONRESIZE           = &H00000001
		OLEMISC_ONLYICONIC                  = &H00000002
		OLEMISC_INSERTNOTREPLACE            = &H00000004
		OLEMISC_STATIC                      = &H00000008
		OLEMISC_CANTLINKINSIDE              = &H00000010
		OLEMISC_CANLINKBYOLE1               = &H00000020
		OLEMISC_ISLINKOBJECT                = &H00000040
		OLEMISC_INSIDEOUT                   = &H00000080
		OLEMISC_ACTIVATEWHENVISIBLE         = &H00000100
		OLEMISC_RENDERINGISDEVICEINDEPENDENT= &H00000200
		OLEMISC_INVISIBLEATRUNTIME          = &H00000400
		OLEMISC_ALWAYSRUN                   = &H00000800
		OLEMISC_ACTSLIKEBUTTON              = &H00001000
		OLEMISC_ACTSLIKELABEL               = &H00002000
		OLEMISC_NOUIACTIVATE                = &H00004000
		OLEMISC_ALIGNABLE                   = &H00008000
		OLEMISC_SIMPLEFRAME                 = &H00010000
		OLEMISC_SETCLIENTSITEFIRST          = &H00020000
		OLEMISC_IMEMODE                     = &H00040000
		OLEMISC_IGNOREACTIVATEWHENVISIBLE   = &H00080000
		OLEMISC_WANTSTOMENUMERGE            = &H00100000
		OLEMISC_SUPPORTSMULTILEVELUNDO      = &H00200000
	End Enum

	' OLECLOSE
	Public Enum OLECLOSE As Integer
		OLECLOSE_SAVEIFDIRTY = 0
		OLECLOSE_NOSAVE      = 1
		OLECLOSE_PROMPTSAVE  = 2
	End Enum

	' OLEIVERB
	Public Enum OLEIVERB As Integer
		OLEIVERB_PRIMARY            = 0
		OLEIVERB_SHOW               = -1
		OLEIVERB_OPEN               = -2
		OLEIVERB_HIDE               = -3
		OLEIVERB_UIACTIVATE         = -4
		OLEIVERB_INPLACEACTIVATE    = -5
		OLEIVERB_DISCARDUNDOSTATE   = -6
		OLEIVERB_PROPERTIES         = -7
	End Enum

	' OLEVERBATTRIB
	<Flags()> _
	Public Enum OLEVERBATTRIB As Integer
		OLEVERBATTRIB_NEVERDIRTIES      = 1
		OLEVERBATTRIB_ONCONTAINERMENU   = 2
	End Enum

	' DVASPECTINFOFLAG
	<Flags()> _
	Public Enum DVASPECTINFOFLAG As Integer
		DVASPECTINFOFLAG_CANOPTIMIZE    = 1
	End Enum


	' PFNCONTINUE
	Public Delegate Function PFNCONTINUE( _
		ByVal dwContinue As Integer) As Integer


	' OLEVERB
	<StructLayout(LayoutKind.Sequential, Pack:=4)> _
	Public Structure OLEVERB
		Public iVerb As OLEIVERB
		<MarshalAs(UnmanagedType.LPWStr)> _
		Public lpszVerbName As String
		Public fuFlags As Integer
		Public grfAttribs As OLEVERBATTRIB
	End Structure

	' DVASPECTINFO
	<StructLayout(LayoutKind.Sequential, Pack:=4)> _
	Public Structure DVASPECTINFO
		<MarshalAs(UnmanagedType.U4)> _
		Public cb As Integer
		Public dwFlags As DVASPECTINFOFLAG
	End Structure


	' IEnumOLEVERB
	<ComImport, _
	 Guid("00000104-0000-0000-C000-000000000046"), _
	 InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
	Public Interface IEnumOLEVERB

		<PreserveSig> _
		Function [Next]( _
			ByVal celt As Integer, _
			<Out(), MarshalAs(UnmanagedType.LPArray, SizeParamIndex:=0)> _
			ByVal rgelt() As OLEVERB, _
			<Out()> _
			ByRef pceltFetched As Integer) As HRESULT

		<PreserveSig> _
		Function Skip( _
			ByVal celt As Integer) As HRESULT

		<PreserveSig> _
		Function Reset() As HRESULT

		<PreserveSig> _
		Function Clone( _
			<Out()> _
			ByRef ppenum As IEnumOLEVERB) As HRESULT

	End Interface

	' IViewObject
	<ComImport, _
	 Guid("0000010d-0000-0000-C000-000000000046"), _
	 InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
	Public Interface IViewObject

		<PreserveSig> _
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

		<PreserveSig> _
		Function GetColorSet( _
			ByVal dwDrawAspect As DVASPECT, _
			ByVal lindex As Integer, _
			<[In]()> _
			ByRef pvAspect As DVASPECTINFO, _
			ByVal ptd As IntPtr, _
			ByVal hicTargetDev As IntPtr, _
			<Out()> _
			ByRef ppColorSet As IntPtr) As HRESULT

		<PreserveSig> _
		Function Freeze( _
			ByVal dwDrawAspect As DVASPECT, _
			ByVal lindex As Integer, _
			<[In]()> _
			ByRef pvAspect As DVASPECTINFO, _
			<Out()> _
			ByRef pdwFreeze As Integer) As HRESULT

		<PreserveSig> _
		Function Unfreeze( _
			ByVal dwFreeze As Integer) As HRESULT

		<PreserveSig> _
		Function SetAdvise( _
			ByVal dwDrawAspect As DVASPECT, _
			ByVal advflag As ADVF, _
			ByVal pAdvSink As IAdviseSink) As HRESULT

		<PreserveSig> _
		Function GetAdvise( _
			<Out()> _
			ByRef pAspects As DVASPECT, _
			<Out()> _
			ByRef pAdvf As ADVF, _
			<Out()> _
			ByRef ppAdvSink As IAdviseSink) As HRESULT

	End Interface

	' IOleObject
	<ComImport, _
	 Guid("00000112-0000-0000-C000-000000000046"), _
	 InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
	Public Interface IOleObject

		<PreserveSig> _
		Function SetClientSite( _
			ByVal pClientSite As IOleClientSite) As HRESULT

		<PreserveSig> _
		Function GetClientSite( _
			<Out()> _
			ByRef ppClientSite As IOleClientSite) As HRESULT

		<PreserveSig> _
		Function SetHostNames( _
			<MarshalAs(UnmanagedType.LPWStr)> _
			ByVal szContainerApp As String, _
			<MarshalAs(UnmanagedType.LPWStr)> _
			ByVal szContainerObj As String) As HRESULT

		<PreserveSig> _
		Function Close( _
			ByVal dwSaveOption As OLECLOSE) As HRESULT

		<PreserveSig> _
		Function SetMoniker( _
			ByVal dwWhichMoniker As OLEWHICHMK, _
			ByVal pmk As UCOMIMoniker) As HRESULT

		<PreserveSig> _
		Function GetMoniker( _
			ByVal dwAssign As OLEGETMONIKER, _
			ByVal dwWhichMoniker As OLEWHICHMK, _
			<Out()> _
			ByRef pmk As UCOMIMoniker) As HRESULT

		<PreserveSig> _
		Function InitFromData( _
			ByVal pDataObject As IDataObject, _
			<MarshalAs(UnmanagedType.Bool)> _
			ByVal fCreation As Boolean, _
			ByVal dwReserved As Integer) As HRESULT

		<PreserveSig> _
		Function GetClipboardData( _
			ByVal dwReserved As Integer, _
			<Out()> _
			ByRef ppDataObject As IDataObject) As HRESULT

		<PreserveSig> _
		Function DoVerb( _
			ByVal iVerb As OLEIVERB, _
			<[In]()> _
			ByRef lpmsg As MSG, _
			ByVal pActiveSite As IOleClientSite, _
			ByVal lindex As Integer, _
			ByVal hwndParent As IntPtr, _
			<[In]()> _
			ByRef lprcPosRect As RECT) As HRESULT

		<PreserveSig> _
		Function EnumVerbs( _
			<Out()> _
			ByRef ppEnumOleVerb As IEnumOLEVERB) As HRESULT

		<PreserveSig> _
		Function Update() As HRESULT

		<PreserveSig> _
		Function IsUpToDate() As HRESULT

		<PreserveSig> _
		Function GetUserClassID ( _
			<Out()> _
			ByRef pClsid As Guid) As HRESULT

		<PreserveSig> _
		Function GetUserType( _
			ByVal dwFormOfType As USERCLASSTYPE, _
			<Out(), MarshalAs(UnmanagedType.LPWStr)> _
			ByRef pszUserType As String) As HRESULT

		<PreserveSig> _
		Function SetExtent( _
			ByVal dwDrawAspect As DVASPECT, _
			<[In]()> _
			ByRef psizel As Win32.SIZE) As HRESULT

		<PreserveSig> _
		Function GetExtent( _
			ByVal dwDrawAspect As DVASPECT, _
			<Out()> _
			ByRef psizel As Win32.SIZE) As HRESULT

		<PreserveSig> _
		Function Advise( _
			ByVal pAdvSink As IAdviseSink, _
			<Out()> _
			ByRef pdwConnection As Integer) As HRESULT

		<PreserveSig> _
		Function Unadvise( _
			ByVal dwConnection As Integer) As HRESULT

		<PreserveSig> _
		Function EnumAdvise( _
			<Out()> _
			ByRef ppenumAdvise As IEnumSTATDATA) As HRESULT

		<PreserveSig> _
		Function GetMiscStatus( _
			ByVal dwDrawAspect As DVASPECT, _
			<Out()> _
			ByRef pdwStatus As OLEMISC) As HRESULT

		<PreserveSig> _
		Function SetColorScheme( _
			<[In]()> _
			ByRef pLogpal As LOGPALETTE) As HRESULT

	End Interface

	' IOleClientSite
	<ComImport, _
	 Guid("00000118-0000-0000-C000-000000000046"), _
	 InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
	Public interface IOleClientSite

		<PreserveSig> _
		Function SaveObject() As HRESULT

		<PreserveSig> _
		Function GetMoniker( _
			ByVal dwAssign As OLEGETMONIKER, _
			ByVal dwWhichMoniker As OLEWHICHMK, _
			ByRef ppmk As UCOMIMoniker) As HRESULT

		<PreserveSig> _
		Function GetContainer( _
			<Out(), MarshalAs(UnmanagedType.IUnknown)> _
			ByRef ppContainer As Object) As HRESULT

		<PreserveSig> _
		Function ShowObject() As HRESULT

		<PreserveSig> _
		Function OnShowWindow( _
			<MarshalAs(UnmanagedType.Bool)> _
			ByVal fShow As Boolean) As HRESULT

		<PreserveSig> _
		Function RequestNewObjectLayout() As HRESULT

	End Interface


	' OLE32.DLLのシンボルを定義する。
	Public Class OLE32

		' CoCreateInstance
		Public Declare Function CoCreateInstance Lib "OLE32.DLL" ( _
			<[In]()> _
			ByRef rclsid As Guid, _
			<MarshalAs(UnmanagedType.IUnknown)> _
			ByVal pUnkOuter As Object, _
			ByVal dwClsContext As CLSCTX, _
			<[In]()> _
			ByRef riid As Guid, _
			<Out(), MarshalAs(UnmanagedType.IUnknown)> _
			ByRef ppv As Object) As HRESULT

		' CLSIDFromProgID
		Public Declare Function CLSIDFromProgID Lib "OLE32.DLL" ( _
			<MarshalAs(UnmanagedType.LPWStr)> _
			ByVal lpszProgID As String, _
			<Out()> _
			ByRef pclsid As Guid) As HRESULT

		' ReleaseStgMedium
		Public Declare Function ReleaseStgMedium Lib "OLE32.DLL" ( _
			<[In](), Out()> _
			ByRef pstgm As STGMEDIUM) As HRESULT

		' CreateBindCtx
		Public Declare Function CreateBindCtx Lib "OLE32.DLL" ( _
			ByVal reserved As Integer, _
			<Out()> _
			ByRef ppbc As UCOMIBindCtx) As HRESULT

		' MkParseDisplayName
		Public Declare Function MkParseDisplayName Lib "OLE32.DLL" ( _
			ByVal pbc As UCOMIBindCtx, _
			<MarshalAs(UnmanagedType.LPWStr)> _
			ByVal szUserName As String, _
			<MarshalAs(UnmanagedType.U4)> _
			ByRef pchEaten As Integer, _
			<Out()> _
			ByRef ppmk As UCOMIMoniker) As HRESULT

		' BindMoniker
		Public Declare Function BindMoniker Lib "OLE32.DLL" ( _
			ByVal pmk As UCOMIMoniker, _
			ByVal grfOpt As Integer, _
			<[In]()> _
			ByRef iidResult As Guid, _
			<Out(), MarshalAs(UnmanagedType.IUnknown)> _
			ByRef ppvResult As Object) As HRESULT

		' CreateFileMoniker
		Public Declare Function CreateFileMoniker Lib "OLE32.DLL" ( _
			<MarshalAs(UnmanagedType.LPWStr)> _
			ByVal lpszPathName As String, _
			<Out()> _
			ByRef ppmk As UCOMIMoniker) As HRESULT

		' CreateURLMoniker
		Public Declare Function CreateURLMoniker Lib "URLMON.DLL" ( _
			ByVal pmkContext As UCOMIMoniker, _
			<MarshalAs(UnmanagedType.LPWStr)> _
			ByVal szURL As String, _
			<Out()> _
			ByRef ppmk As UCOMIMoniker) As HRESULT

		' OleRegEnumFormatEtc
		Public Declare Function OleRegEnumFormatEtc Lib "OLE32.DLL" ( _
			<[In]()> _
			ByRef clsid As Guid, _
			ByVal dwDirection As DATADIR, _
			ByRef ppenumFormatetc As IEnumFORMATETC) As HRESULT

		' OleRegEnumVerbs
		Public Declare Function OleRegEnumVerbs Lib "OLE32.DLL" ( _
			<[In]()> _
			ByRef clsid As Guid, _
			ByRef ppenumOleVerb As IEnumOLEVERB) As HRESULT

		' OleRegGetMiscStatus
		Public Declare Function OleRegGetMiscStatus Lib "OLE32.DLL" ( _
			<[In]()> _
			ByRef clsid As Guid, _
			ByVal dwAspect As DVASPECT, _
			ByRef pdwStatus As OLEMISC) As HRESULT

		' OleRegGetUserType
		Public Declare Function OleRegGetUserType Lib "OLE32.DLL" ( _
			<[In]()> _
			ByRef clsid As Guid, _
			ByVal dwFormOfType As USERCLASSTYPE, _
			<Out(), MarshalAs(UnmanagedType.LPWStr)> _
			ByRef pszUserType As String) As HRESULT

		' OleDraw
		Public Declare Function OleDraw Lib "OLE32.DLL" ( _
			<MarshalAs(UnmanagedType.IUnknown)> _
			ByVal pUnknown As Object, _
			ByVal dwAspect As DVASPECT, _
			ByVal hdcDraw As IntPtr, _
			<[In]()> _
			ByRef lprcBounds As RECT) As HRESULT

	End Class


	' OLE2UIクラス
	' コンテナ機能をヘルプするために拡張していく予定。
	Public Class OLE2UI

		Public Const HIMETRIC_PER_INCH As Integer = 2540


		' HIMETRIC単位の座標系をピクセル単位に変換するヘルパ関数です。

		Public Shared Sub HIMETRICtoPIXEL(ByRef hm As System.Drawing.Point)
			HIMETRICtoPIXEL(hm.X, hm.Y)
		End Sub

		Public Shared Sub HIMETRICtoPIXEL(ByRef hm As System.Drawing.Size)
			HIMETRICtoPIXEL(hm.Width, hm.Height)
		End Sub

		Public Shared Sub HIMETRICtoPIXEL(ByRef hm As Win32.POINT)
			HIMETRICtoPIXEL(hm.x, hm.y)
		End Sub

		Public Shared Sub HIMETRICtoPIXEL(ByRef hm As Win32.SIZE)
			HIMETRICtoPIXEL(hm.cx, hm.cy)
		End Sub

		Public Shared Sub HIMETRICtoPIXEL(ByRef x As Integer, ByRef y As Integer)
			Dim hdc As IntPtr

			hdc = USER32.GetDC(IntPtr.Zero)

			x = CInt(CSng(x) * CSng(GDI32.GetDeviceCaps(hdc, DEVICECAPS.LOGPIXELSX)) / HIMETRIC_PER_INCH)
			y = CInt(CSng(y) * CSng(GDI32.GetDeviceCaps(hdc, DEVICECAPS.LOGPIXELSY)) / HIMETRIC_PER_INCH)

			USER32.ReleaseDC(IntPtr.Zero, hdc)

		End Sub


		' ピクセル単位の座標系をHIMETRIC単位に変換するヘルパ関数です。

		Public Shared Sub PIXELtoHIMETRIC(ByRef hm As System.Drawing.Point)
			PIXELtoHIMETRIC(hm.X, hm.Y)
		End Sub

		Public Shared Sub PIXELtoHIMETRIC(ByRef hm As System.Drawing.Size)
			PIXELtoHIMETRIC(hm.Width, hm.Height)
		End Sub

		Public Shared Sub PIXELtoHIMETRIC(ByRef hm As Win32.POINT)
			PIXELtoHIMETRIC(hm.x, hm.y)
		End Sub

		Public Shared Sub PIXELtoHIMETRIC(ByRef hm As Win32.SIZE)
			PIXELtoHIMETRIC(hm.cx, hm.cy)
		End Sub

		Public Shared Sub PIXELtoHIMETRIC(ByRef x As Integer, ByRef y As Integer)
			Dim hdc As IntPtr

			hdc = USER32.GetDC(IntPtr.Zero)

			x = CInt(CSng(x) * HIMETRIC_PER_INCH / CSng(GDI32.GetDeviceCaps(hdc, DEVICECAPS.LOGPIXELSX)))
			y = CInt(CSng(y) * HIMETRIC_PER_INCH / CSng(GDI32.GetDeviceCaps(hdc, DEVICECAPS.LOGPIXELSY)))

			USER32.ReleaseDC(IntPtr.Zero, hdc)

		End Sub

	End Class

End Namespace
