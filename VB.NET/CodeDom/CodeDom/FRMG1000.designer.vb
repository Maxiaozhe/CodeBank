﻿'------------------------------------------------------------------------------
' <auto-generated>
'     このコードはツールによって生成されました。
'     ランタイム バージョン:4.0.30319.42000
'
'     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
'     コードが再生成されるときに損失したりします。
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.Linq
Imports System.Data.Linq.Mapping
Imports System.Linq
Imports System.Linq.Expressions
Imports System.Reflection


<Global.System.Data.Linq.Mapping.DatabaseAttribute(Name:="RabitFlow_410")>  _
Partial Public Class RabitFlowDB
	Inherits System.Data.Linq.DataContext
	
	Private Shared mappingSource As System.Data.Linq.Mapping.MappingSource = New AttributeMappingSource()
	
  #Region "拡張メソッドの定義"
  Partial Private Sub OnCreated()
  End Sub
  Partial Private Sub InsertEGGA0001(instance As EGGA0001)
    End Sub
  Partial Private Sub UpdateEGGA0001(instance As EGGA0001)
    End Sub
  Partial Private Sub DeleteEGGA0001(instance As EGGA0001)
    End Sub
  #End Region
	
	Public Sub New()
		MyBase.New("Data Source=db12;Initial Catalog=RabitFlow_410;Persist Security Info=True;User ID"& _ 
				"=sa", mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As String)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As System.Data.IDbConnection)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As String, ByVal mappingSource As System.Data.Linq.Mapping.MappingSource)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As System.Data.IDbConnection, ByVal mappingSource As System.Data.Linq.Mapping.MappingSource)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public ReadOnly Property EGGA0001() As System.Data.Linq.Table(Of EGGA0001)
		Get
			Return Me.GetTable(Of EGGA0001)
		End Get
	End Property
End Class

<Global.System.Data.Linq.Mapping.TableAttribute(Name:="dbo.EGGA0001")>  _
Partial Public Class EGGA0001
	Implements System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	
	Private Shared emptyChangingEventArgs As PropertyChangingEventArgs = New PropertyChangingEventArgs(String.Empty)
	
	Private _IDDOC As Integer
	
	Private _IDFRM As System.Nullable(Of Integer)
	
	Private _STDOC As String
	
	Private _DTMAKE As String
	
	Private _NMMAKE As String
	
	Private _STMAKE As String
	
	Private _TPACPT As String
	
	Private _DTLASTACPT As String
	
	Private _NMLASTACPT As String
	
	Private _TPPRIORITY As String
	
	Private _STSUBJECT As String
	
	Private _FGDEL As System.Nullable(Of Char)
	
	Private _IDNEXTRECOG As System.Nullable(Of Integer)
	
	Private _IDUNNEXTRECOG As System.Nullable(Of Integer)
	
	Private _NMNEXTRECOG As String
	
	Private _VLSTATUS As String
	
	Private _FGADMIN As System.Nullable(Of Char)
	
	Private _FGREVISION As System.Nullable(Of Char)
	
	Private _DTREVISION As String
	
	Private _TMREVISION As String
	
	Private _STCONTROLNO As String
	
	Private _DTRESPONSE As String
	
	Private _STVERSION As String
	
	Private _IDACTINGUSER As System.Nullable(Of Integer)
	
	Private _IDDOCBEFORE As System.Nullable(Of Integer)
	
	Private _FGCUTINTO As System.Nullable(Of Integer)
	
	Private _IDCUTSYSBLG As System.Nullable(Of Integer)
	
	Private _FGBEFORECHK As System.Nullable(Of Integer)
	
	Private _IDCREUSER As System.Nullable(Of Integer)
	
	Private _DTCREATE As String
	
	Private _TMCREATE As String
	
	Private _IDUPDUSER As System.Nullable(Of Integer)
	
	Private _DTUPDATE As String
	
	Private _TMUPDATE As String
	
	Private _DTDIRECTORDAY As System.Nullable(Of Date)
	
	Private _IDCRESYSBLG As System.Nullable(Of Integer)
	
	Private _VLSTATUSBK As String
	
	Private _VLDOCTYPE As System.Nullable(Of Char)
	
	Private _VLBBSRELEASE As String
	
	Private _STATUS As String
	
	Private _STATUSUPD As String
	
	Private _STATUSDNP As String
	
    #Region "拡張メソッドの定義"
    Partial Private Sub OnLoaded()
    End Sub
    Partial Private Sub OnValidate(action As System.Data.Linq.ChangeAction)
    End Sub
    Partial Private Sub OnCreated()
    End Sub
    Partial Private Sub OnIDDOCChanging(value As Integer)
    End Sub
    Partial Private Sub OnIDDOCChanged()
    End Sub
    Partial Private Sub OnIDFRMChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnIDFRMChanged()
    End Sub
    Partial Private Sub OnSTDOCChanging(value As String)
    End Sub
    Partial Private Sub OnSTDOCChanged()
    End Sub
    Partial Private Sub OnDTMAKEChanging(value As String)
    End Sub
    Partial Private Sub OnDTMAKEChanged()
    End Sub
    Partial Private Sub OnNMMAKEChanging(value As String)
    End Sub
    Partial Private Sub OnNMMAKEChanged()
    End Sub
    Partial Private Sub OnSTMAKEChanging(value As String)
    End Sub
    Partial Private Sub OnSTMAKEChanged()
    End Sub
    Partial Private Sub OnTPACPTChanging(value As String)
    End Sub
    Partial Private Sub OnTPACPTChanged()
    End Sub
    Partial Private Sub OnDTLASTACPTChanging(value As String)
    End Sub
    Partial Private Sub OnDTLASTACPTChanged()
    End Sub
    Partial Private Sub OnNMLASTACPTChanging(value As String)
    End Sub
    Partial Private Sub OnNMLASTACPTChanged()
    End Sub
    Partial Private Sub OnTPPRIORITYChanging(value As String)
    End Sub
    Partial Private Sub OnTPPRIORITYChanged()
    End Sub
    Partial Private Sub OnSTSUBJECTChanging(value As String)
    End Sub
    Partial Private Sub OnSTSUBJECTChanged()
    End Sub
    Partial Private Sub OnFGDELChanging(value As System.Nullable(Of Char))
    End Sub
    Partial Private Sub OnFGDELChanged()
    End Sub
    Partial Private Sub OnIDNEXTRECOGChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnIDNEXTRECOGChanged()
    End Sub
    Partial Private Sub OnIDUNNEXTRECOGChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnIDUNNEXTRECOGChanged()
    End Sub
    Partial Private Sub OnNMNEXTRECOGChanging(value As String)
    End Sub
    Partial Private Sub OnNMNEXTRECOGChanged()
    End Sub
    Partial Private Sub OnVLSTATUSChanging(value As String)
    End Sub
    Partial Private Sub OnVLSTATUSChanged()
    End Sub
    Partial Private Sub OnFGADMINChanging(value As System.Nullable(Of Char))
    End Sub
    Partial Private Sub OnFGADMINChanged()
    End Sub
    Partial Private Sub OnFGREVISIONChanging(value As System.Nullable(Of Char))
    End Sub
    Partial Private Sub OnFGREVISIONChanged()
    End Sub
    Partial Private Sub OnDTREVISIONChanging(value As String)
    End Sub
    Partial Private Sub OnDTREVISIONChanged()
    End Sub
    Partial Private Sub OnTMREVISIONChanging(value As String)
    End Sub
    Partial Private Sub OnTMREVISIONChanged()
    End Sub
    Partial Private Sub OnSTCONTROLNOChanging(value As String)
    End Sub
    Partial Private Sub OnSTCONTROLNOChanged()
    End Sub
    Partial Private Sub OnDTRESPONSEChanging(value As String)
    End Sub
    Partial Private Sub OnDTRESPONSEChanged()
    End Sub
    Partial Private Sub OnSTVERSIONChanging(value As String)
    End Sub
    Partial Private Sub OnSTVERSIONChanged()
    End Sub
    Partial Private Sub OnIDACTINGUSERChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnIDACTINGUSERChanged()
    End Sub
    Partial Private Sub OnIDDOCBEFOREChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnIDDOCBEFOREChanged()
    End Sub
    Partial Private Sub OnFGCUTINTOChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnFGCUTINTOChanged()
    End Sub
    Partial Private Sub OnIDCUTSYSBLGChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnIDCUTSYSBLGChanged()
    End Sub
    Partial Private Sub OnFGBEFORECHKChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnFGBEFORECHKChanged()
    End Sub
    Partial Private Sub OnIDCREUSERChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnIDCREUSERChanged()
    End Sub
    Partial Private Sub OnDTCREATEChanging(value As String)
    End Sub
    Partial Private Sub OnDTCREATEChanged()
    End Sub
    Partial Private Sub OnTMCREATEChanging(value As String)
    End Sub
    Partial Private Sub OnTMCREATEChanged()
    End Sub
    Partial Private Sub OnIDUPDUSERChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnIDUPDUSERChanged()
    End Sub
    Partial Private Sub OnDTUPDATEChanging(value As String)
    End Sub
    Partial Private Sub OnDTUPDATEChanged()
    End Sub
    Partial Private Sub OnTMUPDATEChanging(value As String)
    End Sub
    Partial Private Sub OnTMUPDATEChanged()
    End Sub
    Partial Private Sub OnDTDIRECTORDAYChanging(value As System.Nullable(Of Date))
    End Sub
    Partial Private Sub OnDTDIRECTORDAYChanged()
    End Sub
    Partial Private Sub OnIDCRESYSBLGChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnIDCRESYSBLGChanged()
    End Sub
    Partial Private Sub OnVLSTATUSBKChanging(value As String)
    End Sub
    Partial Private Sub OnVLSTATUSBKChanged()
    End Sub
    Partial Private Sub OnVLDOCTYPEChanging(value As System.Nullable(Of Char))
    End Sub
    Partial Private Sub OnVLDOCTYPEChanged()
    End Sub
    Partial Private Sub OnVLBBSRELEASEChanging(value As String)
    End Sub
    Partial Private Sub OnVLBBSRELEASEChanged()
    End Sub
    Partial Private Sub OnSTATUSChanging(value As String)
    End Sub
    Partial Private Sub OnSTATUSChanged()
    End Sub
    Partial Private Sub OnSTATUSUPDChanging(value As String)
    End Sub
    Partial Private Sub OnSTATUSUPDChanged()
    End Sub
    Partial Private Sub OnSTATUSDNPChanging(value As String)
    End Sub
    Partial Private Sub OnSTATUSDNPChanged()
    End Sub
    #End Region
	
	Public Sub New()
		MyBase.New
		OnCreated
	End Sub
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_IDDOC", DbType:="Int NOT NULL", IsPrimaryKey:=true)>  _
	Public Property IDDOC() As Integer
		Get
			Return Me._IDDOC
		End Get
		Set
			If ((Me._IDDOC = value)  _
						= false) Then
				Me.OnIDDOCChanging(value)
				Me.SendPropertyChanging
				Me._IDDOC = value
				Me.SendPropertyChanged("IDDOC")
				Me.OnIDDOCChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_IDFRM", DbType:="Int")>  _
	Public Property IDFRM() As System.Nullable(Of Integer)
		Get
			Return Me._IDFRM
		End Get
		Set
			If (Me._IDFRM.Equals(value) = false) Then
				Me.OnIDFRMChanging(value)
				Me.SendPropertyChanging
				Me._IDFRM = value
				Me.SendPropertyChanged("IDFRM")
				Me.OnIDFRMChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_STDOC", DbType:="NVarChar(800)")>  _
	Public Property STDOC() As String
		Get
			Return Me._STDOC
		End Get
		Set
			If (String.Equals(Me._STDOC, value) = false) Then
				Me.OnSTDOCChanging(value)
				Me.SendPropertyChanging
				Me._STDOC = value
				Me.SendPropertyChanged("STDOC")
				Me.OnSTDOCChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_DTMAKE", DbType:="NVarChar(10)")>  _
	Public Property DTMAKE() As String
		Get
			Return Me._DTMAKE
		End Get
		Set
			If (String.Equals(Me._DTMAKE, value) = false) Then
				Me.OnDTMAKEChanging(value)
				Me.SendPropertyChanging
				Me._DTMAKE = value
				Me.SendPropertyChanged("DTMAKE")
				Me.OnDTMAKEChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_NMMAKE", DbType:="NVarChar(40)")>  _
	Public Property NMMAKE() As String
		Get
			Return Me._NMMAKE
		End Get
		Set
			If (String.Equals(Me._NMMAKE, value) = false) Then
				Me.OnNMMAKEChanging(value)
				Me.SendPropertyChanging
				Me._NMMAKE = value
				Me.SendPropertyChanged("NMMAKE")
				Me.OnNMMAKEChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_STMAKE", DbType:="NVarChar(40)")>  _
	Public Property STMAKE() As String
		Get
			Return Me._STMAKE
		End Get
		Set
			If (String.Equals(Me._STMAKE, value) = false) Then
				Me.OnSTMAKEChanging(value)
				Me.SendPropertyChanging
				Me._STMAKE = value
				Me.SendPropertyChanged("STMAKE")
				Me.OnSTMAKEChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_TPACPT", DbType:="NVarChar(32)")>  _
	Public Property TPACPT() As String
		Get
			Return Me._TPACPT
		End Get
		Set
			If (String.Equals(Me._TPACPT, value) = false) Then
				Me.OnTPACPTChanging(value)
				Me.SendPropertyChanging
				Me._TPACPT = value
				Me.SendPropertyChanged("TPACPT")
				Me.OnTPACPTChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_DTLASTACPT", DbType:="NVarChar(10)")>  _
	Public Property DTLASTACPT() As String
		Get
			Return Me._DTLASTACPT
		End Get
		Set
			If (String.Equals(Me._DTLASTACPT, value) = false) Then
				Me.OnDTLASTACPTChanging(value)
				Me.SendPropertyChanging
				Me._DTLASTACPT = value
				Me.SendPropertyChanged("DTLASTACPT")
				Me.OnDTLASTACPTChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_NMLASTACPT", DbType:="NVarChar(128) NOT NULL", CanBeNull:=false)>  _
	Public Property NMLASTACPT() As String
		Get
			Return Me._NMLASTACPT
		End Get
		Set
			If (String.Equals(Me._NMLASTACPT, value) = false) Then
				Me.OnNMLASTACPTChanging(value)
				Me.SendPropertyChanging
				Me._NMLASTACPT = value
				Me.SendPropertyChanged("NMLASTACPT")
				Me.OnNMLASTACPTChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_TPPRIORITY", DbType:="NVarChar(20)")>  _
	Public Property TPPRIORITY() As String
		Get
			Return Me._TPPRIORITY
		End Get
		Set
			If (String.Equals(Me._TPPRIORITY, value) = false) Then
				Me.OnTPPRIORITYChanging(value)
				Me.SendPropertyChanging
				Me._TPPRIORITY = value
				Me.SendPropertyChanged("TPPRIORITY")
				Me.OnTPPRIORITYChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_STSUBJECT", DbType:="NVarChar(255)")>  _
	Public Property STSUBJECT() As String
		Get
			Return Me._STSUBJECT
		End Get
		Set
			If (String.Equals(Me._STSUBJECT, value) = false) Then
				Me.OnSTSUBJECTChanging(value)
				Me.SendPropertyChanging
				Me._STSUBJECT = value
				Me.SendPropertyChanged("STSUBJECT")
				Me.OnSTSUBJECTChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_FGDEL", DbType:="NVarChar(1)")>  _
	Public Property FGDEL() As System.Nullable(Of Char)
		Get
			Return Me._FGDEL
		End Get
		Set
			If (Me._FGDEL.Equals(value) = false) Then
				Me.OnFGDELChanging(value)
				Me.SendPropertyChanging
				Me._FGDEL = value
				Me.SendPropertyChanged("FGDEL")
				Me.OnFGDELChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_IDNEXTRECOG", DbType:="Int")>  _
	Public Property IDNEXTRECOG() As System.Nullable(Of Integer)
		Get
			Return Me._IDNEXTRECOG
		End Get
		Set
			If (Me._IDNEXTRECOG.Equals(value) = false) Then
				Me.OnIDNEXTRECOGChanging(value)
				Me.SendPropertyChanging
				Me._IDNEXTRECOG = value
				Me.SendPropertyChanged("IDNEXTRECOG")
				Me.OnIDNEXTRECOGChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_IDUNNEXTRECOG", DbType:="Int")>  _
	Public Property IDUNNEXTRECOG() As System.Nullable(Of Integer)
		Get
			Return Me._IDUNNEXTRECOG
		End Get
		Set
			If (Me._IDUNNEXTRECOG.Equals(value) = false) Then
				Me.OnIDUNNEXTRECOGChanging(value)
				Me.SendPropertyChanging
				Me._IDUNNEXTRECOG = value
				Me.SendPropertyChanged("IDUNNEXTRECOG")
				Me.OnIDUNNEXTRECOGChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_NMNEXTRECOG", DbType:="NVarChar(255)")>  _
	Public Property NMNEXTRECOG() As String
		Get
			Return Me._NMNEXTRECOG
		End Get
		Set
			If (String.Equals(Me._NMNEXTRECOG, value) = false) Then
				Me.OnNMNEXTRECOGChanging(value)
				Me.SendPropertyChanging
				Me._NMNEXTRECOG = value
				Me.SendPropertyChanged("NMNEXTRECOG")
				Me.OnNMNEXTRECOGChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_VLSTATUS", DbType:="NVarChar(2)")>  _
	Public Property VLSTATUS() As String
		Get
			Return Me._VLSTATUS
		End Get
		Set
			If (String.Equals(Me._VLSTATUS, value) = false) Then
				Me.OnVLSTATUSChanging(value)
				Me.SendPropertyChanging
				Me._VLSTATUS = value
				Me.SendPropertyChanged("VLSTATUS")
				Me.OnVLSTATUSChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_FGADMIN", DbType:="NVarChar(1)")>  _
	Public Property FGADMIN() As System.Nullable(Of Char)
		Get
			Return Me._FGADMIN
		End Get
		Set
			If (Me._FGADMIN.Equals(value) = false) Then
				Me.OnFGADMINChanging(value)
				Me.SendPropertyChanging
				Me._FGADMIN = value
				Me.SendPropertyChanged("FGADMIN")
				Me.OnFGADMINChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_FGREVISION", DbType:="NVarChar(1)")>  _
	Public Property FGREVISION() As System.Nullable(Of Char)
		Get
			Return Me._FGREVISION
		End Get
		Set
			If (Me._FGREVISION.Equals(value) = false) Then
				Me.OnFGREVISIONChanging(value)
				Me.SendPropertyChanging
				Me._FGREVISION = value
				Me.SendPropertyChanged("FGREVISION")
				Me.OnFGREVISIONChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_DTREVISION", DbType:="NVarChar(10)")>  _
	Public Property DTREVISION() As String
		Get
			Return Me._DTREVISION
		End Get
		Set
			If (String.Equals(Me._DTREVISION, value) = false) Then
				Me.OnDTREVISIONChanging(value)
				Me.SendPropertyChanging
				Me._DTREVISION = value
				Me.SendPropertyChanged("DTREVISION")
				Me.OnDTREVISIONChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_TMREVISION", DbType:="NVarChar(8)")>  _
	Public Property TMREVISION() As String
		Get
			Return Me._TMREVISION
		End Get
		Set
			If (String.Equals(Me._TMREVISION, value) = false) Then
				Me.OnTMREVISIONChanging(value)
				Me.SendPropertyChanging
				Me._TMREVISION = value
				Me.SendPropertyChanged("TMREVISION")
				Me.OnTMREVISIONChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_STCONTROLNO", DbType:="NVarChar(400)")>  _
	Public Property STCONTROLNO() As String
		Get
			Return Me._STCONTROLNO
		End Get
		Set
			If (String.Equals(Me._STCONTROLNO, value) = false) Then
				Me.OnSTCONTROLNOChanging(value)
				Me.SendPropertyChanging
				Me._STCONTROLNO = value
				Me.SendPropertyChanged("STCONTROLNO")
				Me.OnSTCONTROLNOChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_DTRESPONSE", DbType:="NVarChar(10)")>  _
	Public Property DTRESPONSE() As String
		Get
			Return Me._DTRESPONSE
		End Get
		Set
			If (String.Equals(Me._DTRESPONSE, value) = false) Then
				Me.OnDTRESPONSEChanging(value)
				Me.SendPropertyChanging
				Me._DTRESPONSE = value
				Me.SendPropertyChanged("DTRESPONSE")
				Me.OnDTRESPONSEChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_STVERSION", DbType:="NVarChar(7)")>  _
	Public Property STVERSION() As String
		Get
			Return Me._STVERSION
		End Get
		Set
			If (String.Equals(Me._STVERSION, value) = false) Then
				Me.OnSTVERSIONChanging(value)
				Me.SendPropertyChanging
				Me._STVERSION = value
				Me.SendPropertyChanged("STVERSION")
				Me.OnSTVERSIONChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_IDACTINGUSER", DbType:="Int")>  _
	Public Property IDACTINGUSER() As System.Nullable(Of Integer)
		Get
			Return Me._IDACTINGUSER
		End Get
		Set
			If (Me._IDACTINGUSER.Equals(value) = false) Then
				Me.OnIDACTINGUSERChanging(value)
				Me.SendPropertyChanging
				Me._IDACTINGUSER = value
				Me.SendPropertyChanged("IDACTINGUSER")
				Me.OnIDACTINGUSERChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_IDDOCBEFORE", DbType:="Int")>  _
	Public Property IDDOCBEFORE() As System.Nullable(Of Integer)
		Get
			Return Me._IDDOCBEFORE
		End Get
		Set
			If (Me._IDDOCBEFORE.Equals(value) = false) Then
				Me.OnIDDOCBEFOREChanging(value)
				Me.SendPropertyChanging
				Me._IDDOCBEFORE = value
				Me.SendPropertyChanged("IDDOCBEFORE")
				Me.OnIDDOCBEFOREChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_FGCUTINTO", DbType:="Int")>  _
	Public Property FGCUTINTO() As System.Nullable(Of Integer)
		Get
			Return Me._FGCUTINTO
		End Get
		Set
			If (Me._FGCUTINTO.Equals(value) = false) Then
				Me.OnFGCUTINTOChanging(value)
				Me.SendPropertyChanging
				Me._FGCUTINTO = value
				Me.SendPropertyChanged("FGCUTINTO")
				Me.OnFGCUTINTOChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_IDCUTSYSBLG", DbType:="Int")>  _
	Public Property IDCUTSYSBLG() As System.Nullable(Of Integer)
		Get
			Return Me._IDCUTSYSBLG
		End Get
		Set
			If (Me._IDCUTSYSBLG.Equals(value) = false) Then
				Me.OnIDCUTSYSBLGChanging(value)
				Me.SendPropertyChanging
				Me._IDCUTSYSBLG = value
				Me.SendPropertyChanged("IDCUTSYSBLG")
				Me.OnIDCUTSYSBLGChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_FGBEFORECHK", DbType:="Int")>  _
	Public Property FGBEFORECHK() As System.Nullable(Of Integer)
		Get
			Return Me._FGBEFORECHK
		End Get
		Set
			If (Me._FGBEFORECHK.Equals(value) = false) Then
				Me.OnFGBEFORECHKChanging(value)
				Me.SendPropertyChanging
				Me._FGBEFORECHK = value
				Me.SendPropertyChanged("FGBEFORECHK")
				Me.OnFGBEFORECHKChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_IDCREUSER", DbType:="Int")>  _
	Public Property IDCREUSER() As System.Nullable(Of Integer)
		Get
			Return Me._IDCREUSER
		End Get
		Set
			If (Me._IDCREUSER.Equals(value) = false) Then
				Me.OnIDCREUSERChanging(value)
				Me.SendPropertyChanging
				Me._IDCREUSER = value
				Me.SendPropertyChanged("IDCREUSER")
				Me.OnIDCREUSERChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_DTCREATE", DbType:="NVarChar(10)")>  _
	Public Property DTCREATE() As String
		Get
			Return Me._DTCREATE
		End Get
		Set
			If (String.Equals(Me._DTCREATE, value) = false) Then
				Me.OnDTCREATEChanging(value)
				Me.SendPropertyChanging
				Me._DTCREATE = value
				Me.SendPropertyChanged("DTCREATE")
				Me.OnDTCREATEChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_TMCREATE", DbType:="NVarChar(8)")>  _
	Public Property TMCREATE() As String
		Get
			Return Me._TMCREATE
		End Get
		Set
			If (String.Equals(Me._TMCREATE, value) = false) Then
				Me.OnTMCREATEChanging(value)
				Me.SendPropertyChanging
				Me._TMCREATE = value
				Me.SendPropertyChanged("TMCREATE")
				Me.OnTMCREATEChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_IDUPDUSER", DbType:="Int")>  _
	Public Property IDUPDUSER() As System.Nullable(Of Integer)
		Get
			Return Me._IDUPDUSER
		End Get
		Set
			If (Me._IDUPDUSER.Equals(value) = false) Then
				Me.OnIDUPDUSERChanging(value)
				Me.SendPropertyChanging
				Me._IDUPDUSER = value
				Me.SendPropertyChanged("IDUPDUSER")
				Me.OnIDUPDUSERChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_DTUPDATE", DbType:="NVarChar(10)")>  _
	Public Property DTUPDATE() As String
		Get
			Return Me._DTUPDATE
		End Get
		Set
			If (String.Equals(Me._DTUPDATE, value) = false) Then
				Me.OnDTUPDATEChanging(value)
				Me.SendPropertyChanging
				Me._DTUPDATE = value
				Me.SendPropertyChanged("DTUPDATE")
				Me.OnDTUPDATEChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_TMUPDATE", DbType:="NVarChar(8)")>  _
	Public Property TMUPDATE() As String
		Get
			Return Me._TMUPDATE
		End Get
		Set
			If (String.Equals(Me._TMUPDATE, value) = false) Then
				Me.OnTMUPDATEChanging(value)
				Me.SendPropertyChanging
				Me._TMUPDATE = value
				Me.SendPropertyChanged("TMUPDATE")
				Me.OnTMUPDATEChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_DTDIRECTORDAY", DbType:="DateTime")>  _
	Public Property DTDIRECTORDAY() As System.Nullable(Of Date)
		Get
			Return Me._DTDIRECTORDAY
		End Get
		Set
			If (Me._DTDIRECTORDAY.Equals(value) = false) Then
				Me.OnDTDIRECTORDAYChanging(value)
				Me.SendPropertyChanging
				Me._DTDIRECTORDAY = value
				Me.SendPropertyChanged("DTDIRECTORDAY")
				Me.OnDTDIRECTORDAYChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_IDCRESYSBLG", DbType:="Int")>  _
	Public Property IDCRESYSBLG() As System.Nullable(Of Integer)
		Get
			Return Me._IDCRESYSBLG
		End Get
		Set
			If (Me._IDCRESYSBLG.Equals(value) = false) Then
				Me.OnIDCRESYSBLGChanging(value)
				Me.SendPropertyChanging
				Me._IDCRESYSBLG = value
				Me.SendPropertyChanged("IDCRESYSBLG")
				Me.OnIDCRESYSBLGChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_VLSTATUSBK", DbType:="NVarChar(32)")>  _
	Public Property VLSTATUSBK() As String
		Get
			Return Me._VLSTATUSBK
		End Get
		Set
			If (String.Equals(Me._VLSTATUSBK, value) = false) Then
				Me.OnVLSTATUSBKChanging(value)
				Me.SendPropertyChanging
				Me._VLSTATUSBK = value
				Me.SendPropertyChanged("VLSTATUSBK")
				Me.OnVLSTATUSBKChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_VLDOCTYPE", DbType:="NVarChar(1)")>  _
	Public Property VLDOCTYPE() As System.Nullable(Of Char)
		Get
			Return Me._VLDOCTYPE
		End Get
		Set
			If (Me._VLDOCTYPE.Equals(value) = false) Then
				Me.OnVLDOCTYPEChanging(value)
				Me.SendPropertyChanging
				Me._VLDOCTYPE = value
				Me.SendPropertyChanged("VLDOCTYPE")
				Me.OnVLDOCTYPEChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_VLBBSRELEASE", DbType:="NVarChar(100)")>  _
	Public Property VLBBSRELEASE() As String
		Get
			Return Me._VLBBSRELEASE
		End Get
		Set
			If (String.Equals(Me._VLBBSRELEASE, value) = false) Then
				Me.OnVLBBSRELEASEChanging(value)
				Me.SendPropertyChanging
				Me._VLBBSRELEASE = value
				Me.SendPropertyChanged("VLBBSRELEASE")
				Me.OnVLBBSRELEASEChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_STATUS", DbType:="NVarChar(200)")>  _
	Public Property STATUS() As String
		Get
			Return Me._STATUS
		End Get
		Set
			If (String.Equals(Me._STATUS, value) = false) Then
				Me.OnSTATUSChanging(value)
				Me.SendPropertyChanging
				Me._STATUS = value
				Me.SendPropertyChanged("STATUS")
				Me.OnSTATUSChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_STATUSUPD", DbType:="NVarChar(10)")>  _
	Public Property STATUSUPD() As String
		Get
			Return Me._STATUSUPD
		End Get
		Set
			If (String.Equals(Me._STATUSUPD, value) = false) Then
				Me.OnSTATUSUPDChanging(value)
				Me.SendPropertyChanging
				Me._STATUSUPD = value
				Me.SendPropertyChanged("STATUSUPD")
				Me.OnSTATUSUPDChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_STATUSDNP", DbType:="NVarChar(10)")>  _
	Public Property STATUSDNP() As String
		Get
			Return Me._STATUSDNP
		End Get
		Set
			If (String.Equals(Me._STATUSDNP, value) = false) Then
				Me.OnSTATUSDNPChanging(value)
				Me.SendPropertyChanging
				Me._STATUSDNP = value
				Me.SendPropertyChanged("STATUSDNP")
				Me.OnSTATUSDNPChanged
			End If
		End Set
	End Property
	
	Public Event PropertyChanging As PropertyChangingEventHandler Implements System.ComponentModel.INotifyPropertyChanging.PropertyChanging
	
	Public Event PropertyChanged As PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
	
	Protected Overridable Sub SendPropertyChanging()
		If ((Me.PropertyChangingEvent Is Nothing)  _
					= false) Then
			RaiseEvent PropertyChanging(Me, emptyChangingEventArgs)
		End If
	End Sub
	
	Protected Overridable Sub SendPropertyChanged(ByVal propertyName As [String])
		If ((Me.PropertyChangedEvent Is Nothing)  _
					= false) Then
			RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
		End If
	End Sub
End Class