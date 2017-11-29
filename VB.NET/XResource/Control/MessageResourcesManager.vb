Imports System.Windows.Forms

Public Class MessageResourcesManager
#Region "内部変数"
    Private mResManager As System.Resources.ResourceManager
#End Region
#Region "メッセージタイプ"
    Public Enum MessageKind
        ''' <summary>
        ''' エラー
        ''' </summary>
        ''' <remarks></remarks>
        [Error] = 1
        ''' <summary>
        ''' 例外
        ''' </summary>
        ''' <remarks></remarks>
        Exception = 2
        ''' <summary>
        ''' 警告
        ''' </summary>
        ''' <remarks></remarks>
        Exclamation = 3
        ''' <summary>
        ''' 情報
        ''' </summary>
        ''' <remarks></remarks>
        Information = 4
        ''' <summary>
        ''' 確認
        ''' </summary>
        ''' <remarks></remarks>
        Question = 5
        ''' <summary>
        ''' そのたリソース
        ''' </summary>
        ''' <remarks></remarks>
        Other = 6
    End Enum
#End Region
#Region "メッソド"
#Region " New "
    ''' <summary>
    ''' メッセージのリソースマネジャーのインスタンスを生成する
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub New(ByVal msgManger As System.Resources.ResourceManager)
        mResManager = msgManger
    End Sub
#End Region
#Region " GetMessage "
    Public Function GetMessage(ByVal messageType As Object) As String
        Return mResManager.GetString(messageType.ToString)
    End Function

    Public Function GetMessage(ByVal messageType As Object, ByVal ParamArray Args() As String) As String
        Dim Msg As String = mResManager.GetString(messageType.ToString)
        Return String.Format(Msg, Args)
    End Function
#End Region
#Region " GetMessageBoxInfo "

    Private Function GetMessageKind(ByVal messageType As Object) As MessageKind
        Dim TypeName As String = messageType.GetType().FullName.ToLower
        If TypeName.IndexOf(".error.") > -1 Then
            Return MessageKind.Error
        End If
        If TypeName.IndexOf(".exception.") > -1 Then
            Return MessageKind.Exception
        End If
        If TypeName.IndexOf(".exclamation.") > -1 Then
            Return MessageKind.Exclamation
        End If
        If TypeName.IndexOf(".Information.") > -1 Then
            Return MessageKind.Information
        End If
        If TypeName.IndexOf(".Question.") > -1 Then
            Return MessageKind.Question
        End If
        Return MessageKind.Other
    End Function

    ''' <summary>
    ''' メッセージボックスに表示するメッセージの内容を格納した MessageBoxInfo クラスのオブジェクトインスタンスを取得します。
    ''' </summary>
    ''' <param name="messageType">リソースの名前を表す列挙値</param>
    ''' <returns>メッセージボックスの情報を返します。</returns>
    ''' <remarks></remarks>
    Public Function GetMessageBoxInfo(ByVal messageType As Object) As MessageBoxInfo

        Try
            Return GetMessageBoxInfo(messageType, "")
        Catch ex As System.Exception
            Throw ex
        End Try

    End Function
    ''' <summary>
    ''' メッセージボックスに表示するメッセージの内容を格納した MessageBoxInfo クラスのオブジェクトインスタンスを取得します。
    ''' </summary>
    ''' <param name="resourceName">リソースの名前を表す列挙値</param>
    ''' <param name="args">書式指定する文字列型の配列</param>
    ''' <returns>メッセージボックスの情報を返します。</returns>
    ''' <remarks></remarks>
    Public Function GetMessageBoxInfo(ByVal resourceName As Object, ByVal ParamArray args As String()) As MessageBoxInfo

        Try
            Return GetMessageBoxInfo(resourceName, False, MessageBoxDefaultButton.Button1, args)
        Catch ex As System.Exception
            Throw ex
        End Try

    End Function


    ''' <summary>
    ''' メッセージボックスに表示するメッセージの内容を格納した MessageBoxInfo クラスのオブジェクトインスタンスを取得します。
    ''' </summary>
    ''' <param name="messageType">リソースの名前を表す列挙値</param>
    ''' <param name="cancel">キャンセルボタンを使用するかどうか</param>
    ''' <param name="defaultButton">デフォルトボタン</param>
    ''' <returns>メッセージボックスの情報を返します。</returns>
    ''' <remarks></remarks>
    Public Function GetMessageBoxInfo(ByVal messageType As Object, ByVal cancel As Boolean, ByVal defaultButton As MessageBoxDefaultButton) As MessageBoxInfo

        Try
            Return GetMessageBoxInfo(messageType, cancel, defaultButton)
        Catch ex As System.Exception
            Throw ex
        End Try

    End Function

    ''' <summary>
    ''' メッセージボックスに表示するメッセージの内容を格納した MessageBoxInfo クラスのオブジェクトインスタンスを取得します。
    ''' </summary>
    ''' <param name="messageType">リソースの名前を表す列挙値</param>
    ''' <param name="args">書式指定する文字列型の配列</param>
    ''' <param name="cancel">キャンセルボタンを使用するかどうか</param>
    ''' <param name="defaultButton">デフォルトボタン</param>
    ''' <returns>メッセージボックスの情報を返します。</returns>
    ''' <remarks></remarks>
    Public Function GetMessageBoxInfo(ByVal messageType As Object, ByVal cancel As Boolean, ByVal defaultButton As MessageBoxDefaultButton, ByVal ParamArray args() As String) As MessageBoxInfo

        Dim msg As String
        Dim icon As MessageBoxIcon
        Dim button As MessageBoxButtons
        Dim info As MessageBoxInfo

        Try
            msg = GetMessage(messageType, args)

            Select Case Me.GetMessageKind(messageType)
                Case MessageKind.Error
                    icon = MessageBoxIcon.Error
                    button = MessageBoxButtons.OK
                Case MessageKind.Exclamation
                    icon = MessageBoxIcon.Exclamation
                    button = MessageBoxButtons.OK
                Case MessageKind.Information
                    icon = MessageBoxIcon.Information
                    button = MessageBoxButtons.OK
                Case MessageKind.Question
                    icon = MessageBoxIcon.Question
                    If cancel = True Then
                        button = MessageBoxButtons.YesNoCancel
                    Else
                        button = MessageBoxButtons.YesNo
                    End If
            End Select

            info = New MessageBoxInfo(msg, icon, button, defaultButton)
        Catch ex As System.Exception
            Throw ex
        End Try

        Return info

    End Function

#End Region

#End Region
End Class