Option Compare Binary
Option Explicit On
Option Strict On

Imports System
Imports System.Windows.Forms
Imports System.Diagnostics

Imports RTS.RabitFlow
Imports RTS.RabitFlow.Resources

''' <summary>
''' メッセージボックスを表示します。
''' </summary>
''' <remarks></remarks>
Partial Public Class MessageBox

#Region " Constant "

    ''' <summary>
    ''' アプリケーション名
    ''' </summary>
    ''' <remarks></remarks>
    Private Const _appName As String = "R@bitFlow"

#End Region

#Region " Constructor "

    ''' <summary>
    ''' MessageBox クラスの新しいインスタンスを初期化します。
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub New()

    End Sub

#End Region

#Region " Public Method "

#Region " Show "

    ''' <summary>
    ''' 指定した例外の内容を表示します。
    ''' </summary>
    ''' <param name="e">例外</param>
    ''' <returns>メッセージボックスダイアログの戻り値を返します。</returns>
    ''' <remarks></remarks>
    Public Shared Function Show(ByVal e As System.Exception) As DialogResult
        Return System.Windows.Forms.MessageBox.Show(e.Message, _appName, MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Function

    ''' <summary>
    ''' 指定した番号に該当するメッセージをダイアログ表示します。
    ''' </summary>
    ''' <param name="MessageType">メッセージ番号</param>
    ''' <returns>メッセージボックスダイアログの戻り値を返します。</returns>
    ''' <remarks></remarks>
    Public Shared Function Show(ByVal MessageType As Object) As DialogResult
        Return Show(MessageType, "")
    End Function

    ''' <summary>
    ''' 指定した番号に該当するメッセージをダイアログ表示します。
    ''' デフォルトボタンの既定値は Button1 のため、それ以外のボタンをデフォルトで選択したい場合はこのメソッドを使用します。
    ''' </summary>
    ''' <param name="MessageType">メッセージ番号</param>
    ''' <param name="defaultButton">デフォルトボタン</param>
    ''' <returns>メッセージボックスダイアログの戻り値を返します。</returns>
    ''' <remarks></remarks>
    Public Shared Function Show(ByVal MessageType As Object, ByVal defaultButton As MessageBoxDefaultButton) As DialogResult
        Return Show(MessageType, defaultButton, "")
    End Function

    ''' <summary>
    ''' 指定した番号に該当するメッセージをダイアログ表示します。
    ''' 確認メッセージのボタンの既定値は YesNo のため、キャンセルボタンを含めたい場合はこのメソッドを使用します。
    ''' </summary>
    ''' <param name="MessageType">メッセージ番号</param>
    ''' <param name="cancel">キャンセルボタンを使用するかどうか</param>
    ''' <param name="defaultButton">デフォルトボタン</param>
    ''' <returns>メッセージボックスダイアログの戻り値を返します。</returns>
    ''' <remarks></remarks>
    Public Shared Function Show(ByVal MessageType As Object, ByVal cancel As Boolean, ByVal defaultButton As MessageBoxDefaultButton) As DialogResult
        Return Show(MessageType, cancel, defaultButton, "")
    End Function


    ''' <summary>
    ''' 指定した番号に該当するメッセージをダイアログ表示します。
    ''' </summary>
    ''' <param name="MessageType">メッセージ番号</param>
    ''' <param name="args">書式指定する文字列型の配列</param>
    ''' <returns>メッセージボックスダイアログの戻り値を返します。</returns>
    ''' <remarks></remarks>
    Public Shared Function Show(ByVal MessageType As Object, ByVal ParamArray args() As String) As DialogResult

        Try
            Return Show(GetMessageBoxInfo(MessageType, False, MessageBoxDefaultButton.Button1, args))
        Catch ex As System.Exception
            Throw ex
        End Try

    End Function

    ''' <summary>
    ''' 指定した番号に該当するメッセージをダイアログ表示します。
    ''' デフォルトボタンの既定値は Button1 のため、それ以外のボタンをデフォルトで選択したい場合はこのメソッドを使用します。
    ''' </summary>
    ''' <param name="MessageType">メッセージ番号</param>
    ''' <param name="args">書式指定する文字列型の配列</param>
    ''' <param name="defaultButton">デフォルトボタン</param>
    ''' <returns>メッセージボックスダイアログの戻り値を返します。</returns>
    ''' <remarks></remarks>
    Public Shared Function Show(ByVal MessageType As Object, ByVal defaultButton As MessageBoxDefaultButton, ByVal ParamArray args() As String) As DialogResult

        Try
            Return Show(GetMessageBoxInfo(MessageType, False, defaultButton, args))
        Catch ex As System.Exception
            Throw ex
        End Try

    End Function

    ''' <summary>
    ''' 指定した番号に該当するメッセージをダイアログ表示します。
    ''' 確認メッセージのボタンの既定値は YesNo のため、キャンセルボタンを含めたい場合はこのメソッドを使用します。
    ''' </summary>
    ''' <param name="MessageType">メッセージ番号</param>
    ''' <param name="args">書式指定する文字列型の配列</param>
    ''' <param name="cancel">キャンセルボタンを使用するかどうか</param>
    ''' <param name="defaultButton">デフォルトボタン</param>
    ''' <returns>メッセージボックスダイアログの戻り値を返します。</returns>
    ''' <remarks></remarks>
    Public Shared Function Show(ByVal MessageType As Object, ByVal cancel As Boolean, ByVal defaultButton As MessageBoxDefaultButton, ByVal ParamArray args() As String) As DialogResult

        Try
            Return Show(GetMessageBoxInfo(MessageType, cancel, defaultButton, args))
        Catch ex As System.Exception
            Throw ex
        End Try

    End Function

    ''' <summary>
    ''' Show メソッドでどうにもならないときに、警告メッセージダイアログを表示します。
    ''' よほどのことがない限り、このメソッドの使用は禁止します。
    ''' </summary>
    ''' <param name="msg">メッセージ</param>
    ''' <returns>メッセージボックスダイアログの戻り値を返します。</returns>
    ''' <remarks></remarks>
    Public Shared Function ShowExclamationDialog(ByVal msg As String) As DialogResult
        Return System.Windows.Forms.MessageBox.Show(msg, _appName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Function

#End Region

#Region " Private Method "

#Region " GetMessageBoxInfo "

    ''' <summary>
    ''' メッセージボックスの内容を表す MessageBoxInfo クラスのインスタンスを取得します。
    ''' </summary>
    ''' <param name="MessageType">メッセージ番号</param>
    ''' <param name="args">書式指定する文字列型の配列</param>
    ''' <returns>メッセージボックスの内容を返します。</returns>
    ''' <remarks></remarks>
    Private Shared Function GetMessageBoxInfo(ByVal MessageType As Object, ByVal cancel As Boolean, ByVal defautlButton As MessageBoxDefaultButton, ByVal ParamArray args() As String) As MessageBoxInfo

        Try
            Dim resMnger As MessageResourcesManager = ResManager.GetMessageResourceManager(MessageType)
            Return resMnger.GetMessageBoxInfo(MessageType, cancel, defautlButton, args)
        Catch ex As System.Exception
            Throw ex
        End Try

    End Function

#End Region

#Region " Show "

    ''' <summary>
    ''' メッセージボックスダイアログを表示します。
    ''' </summary>
    ''' <param name="msgInfo">メッセージボックスの内容</param>
    ''' <returns>メッセージボックスダイアログの戻り値を返します。</returns>
    ''' <remarks></remarks>
    Private Shared Function Show(ByVal msgInfo As MessageBoxInfo) As DialogResult
        Return System.Windows.Forms.MessageBox.Show(msgInfo.Message, _appName, msgInfo.Button, msgInfo.Icon, msgInfo.DefaultButton)
    End Function

#End Region

#End Region

#End Region

End Class
