Option Compare Binary
Option Explicit On
Option Strict On

Imports System
Imports System.Windows.Forms

''' <summary>
''' メッセージボックスを表示する内容を提供します。
''' </summary>
''' <remarks></remarks>
Public Class MessageBoxInfo

#Region " Member Field "

    ''' <summary>
    ''' メッセージ
    ''' </summary>
    ''' <remarks></remarks>
    Private _message As String

    ''' <summary>
    ''' アイコン
    ''' </summary>
    ''' <remarks></remarks>
    Private _icon As MessageBoxIcon

    ''' <summary>
    ''' ボタン
    ''' </summary>
    ''' <remarks></remarks>
    Private _button As MessageBoxButtons

    ''' <summary>
    ''' デフォルトボタン
    ''' </summary>
    ''' <remarks></remarks>
    Private _defaultButton As MessageBoxDefaultButton

#End Region

#Region " Constructor "

    ''' <summary>
    ''' MessageBoxType クラスの新しいインスタンスを初期化します。
    ''' </summary>
    ''' <param name="message">メッセージ</param>
    ''' <param name="icon">メッセージボックスのアイコン</param>
    ''' <param name="button">メッセージボックスのボタン</param>
    ''' <remarks></remarks>
    Friend Sub New(ByVal message As String, ByVal icon As MessageBoxIcon, ByVal button As MessageBoxButtons)
        _message = message
        _icon = icon
        _button = button
    End Sub

    ''' <summary>
    ''' MessageBoxType クラスの新しいインスタンスを初期化します。
    ''' </summary>
    ''' <param name="message">メッセージ</param>
    ''' <param name="icon">メッセージボックスのアイコン</param>
    ''' <param name="button">メッセージボックスのボタン</param>
    ''' <param name="defaultButton">メッセージボックスのデフォルトボタン</param>
    ''' <remarks></remarks>
    Friend Sub New(ByVal message As String, ByVal icon As MessageBoxIcon, ByVal button As MessageBoxButtons, ByVal defaultButton As MessageBoxDefaultButton)
        _message = message
        _icon = icon
        _button = button
        _defaultButton = defaultButton
    End Sub

#End Region

#Region " Public Property "

#Region " Message "

    ''' <summary>
    ''' メッセージボックスのメッセージを取得します。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Message() As String
        Get
            Return _message
        End Get
    End Property

#End Region

#Region " Icon "

    ''' <summary>
    ''' メッセージボックスのアイコンを取得します。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Icon() As MessageBoxIcon
        Get
            Return _icon
        End Get
    End Property

#End Region

#Region " Button "

    ''' <summary>
    ''' メッセージボックスのボタンを取得します。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Button() As MessageBoxButtons
        Get
            Return _button
        End Get
    End Property

#End Region

#Region " DefaultButton "

    ''' <summary>
    ''' メッセージボックスのデフォルトボタンを取得します。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property DefaultButton() As MessageBoxDefaultButton
        Get
            Return _defaultButton
        End Get
    End Property

#End Region

#End Region

End Class
