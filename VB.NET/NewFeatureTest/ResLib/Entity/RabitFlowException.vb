Option Compare Binary
Option Explicit On
Option Strict On

Imports System

''' <summary>
''' ApplicationException の拡張例外クラスです。
''' </summary>
''' <remarks></remarks>
Public Class RabitFlowException
    Inherits ApplicationException

#Region " Member Field "

    ''' <summary>
    ''' エラー番号
    ''' </summary>
    ''' <remarks></remarks>
    Private _ExceptType As Object


#End Region

#Region " Constructor "

    ''' <summary>
    ''' 指定したエラー番号とメッセージで RabitFlowException の新しいインスタンスを初期化します。
    ''' </summary>
    ''' <param name="ExceptType">エラー番号</param>
    ''' <param name="msg">エラーメッセージ</param>
    ''' <remarks></remarks>
    Protected Friend Sub New(ByVal ExceptType As Object, ByVal msg As String)
        MyBase.New(msg)

        _ExceptType = ExceptType
    End Sub

  
#End Region

#Region " Public Property "

    ''' <summary>
    ''' エラー番号を取得します。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ExceptType() As Object
        Get
            Return Me._ExceptType
        End Get
    End Property


#End Region

End Class
