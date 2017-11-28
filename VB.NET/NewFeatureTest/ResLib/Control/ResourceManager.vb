Option Compare Binary
Option Explicit On
Option Strict On

Imports System

Imports RTS.RabitFlow
Imports RTS.RabitFlow.Resources
Imports System.Globalization

''' <summary>
''' リソースからメッセージを取得する機能を提供します。
''' </summary>
''' <remarks></remarks>
Public Class ResourceManager


#Region " Constructor "
    ''' <summary>
    ''' ResourceManager クラスの新しいインスタンスを初期化します。
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
    End Sub
#End Region

#Region " Public Method "

#Region " GetCulture "

    ''' <summary>
    ''' ログインしている使用する言語の種別を表す列挙値を取得します。
    ''' </summary>
    ''' <returns>ログインユーザーが使用する言語を返します。</returns>
    ''' <remarks></remarks>
    Public Shared Property Culture() As CultureInfo
        Get
            Dim CultInfo As CultureInfo = System.Threading.Thread.CurrentThread.CurrentUICulture
            Return CultInfo
        End Get
        Set(ByVal value As CultureInfo)
            System.Threading.Thread.CurrentThread.CurrentUICulture = value
        End Set
    End Property

#End Region

#Region " GetException "

    ''' <summary>
    ''' エラー番号とリソースに該当するアプリケーション例外クラスのインスタンスを取得します。
    ''' </summary>
    ''' <param name="ExceptType">エラー番号</param>
    ''' <returns>拡張アプリケーションエラーの例外クラスを返します。</returns>
    ''' <remarks></remarks>
    Public Shared Function GetException(ByVal ExceptType As Object) As RabitFlowException

        Try
            Return GetException(ExceptType, "")
        Catch ex As System.Exception
            Throw ex
        End Try

    End Function



    ''' <summary>
    ''' エラー番号とリソースに該当するアプリケーション例外クラスのインスタンスを取得します。
    ''' </summary>
    ''' <param name="ExceptType">エラー対象</param>
    ''' <param name="args">書式指定する文字列型の配列</param>
    ''' <returns>拡張アプリケーションエラーの例外クラスを返します。</returns>
    ''' <remarks></remarks>
    Public Shared Function GetException(ByVal ExceptType As Object, ByVal ParamArray args() As String) As RabitFlowException

        Dim rm As MessageResourcesManager
        Dim exp As RabitFlowException

        Try
            rm = ResManager.GetMessageResourceManager(ExceptType)
            exp = rm.GetException(ExceptType, args)
        Catch ex As System.Exception
            Throw ex
        Finally
            rm = Nothing
        End Try

        Return exp

    End Function

#End Region

#Region " GetMessage "

    ''' <summary>
    ''' エラー番号とリソースに該当するメッセージ。
    ''' </summary>
    ''' <param name="MessageType">メッセージ番号</param>
    ''' <returns>リソースに格納されているメッセージを返します。</returns>
    ''' <remarks></remarks>
    Public Shared Function GetMessage(ByVal MessageType As Object) As String

        Try
            Return GetMessage(MessageType, "")
        Catch ex As System.Exception
            Throw ex
        End Try

    End Function

   

    ''' <summary>
    ''' エラー番号とリソースに該当するメッセージ。
    ''' </summary>
    ''' <param name="MessageType">メッセージ番号</param>
    ''' <param name="args">書式指定する文字列型の配列</param>
    ''' <returns>リソースに格納されているメッセージを返します。</returns>
    ''' <remarks></remarks>
    Public Shared Function GetMessage(ByVal MessageType As Object, ByVal ParamArray args() As String) As String

        Dim rm As MessageResourcesManager
        Dim msg As String

        Try
            rm = ResManager.GetMessageResourceManager(MessageType)
            msg = rm.GetMessage(MessageType, args)
        Catch ex As System.Exception
            Throw ex
        Finally
            rm = Nothing
        End Try

        Return msg

    End Function

#End Region

#End Region

End Class
