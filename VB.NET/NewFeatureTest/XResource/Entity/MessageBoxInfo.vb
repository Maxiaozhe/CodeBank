Option Compare Binary
Option Explicit On
Option Strict On

Imports System
Imports System.Windows.Forms

''' <summary>
''' ���b�Z�[�W�{�b�N�X��\��������e��񋟂��܂��B
''' </summary>
''' <remarks></remarks>
Public Class MessageBoxInfo

#Region " Member Field "

    ''' <summary>
    ''' ���b�Z�[�W
    ''' </summary>
    ''' <remarks></remarks>
    Private _message As String

    ''' <summary>
    ''' �A�C�R��
    ''' </summary>
    ''' <remarks></remarks>
    Private _icon As MessageBoxIcon

    ''' <summary>
    ''' �{�^��
    ''' </summary>
    ''' <remarks></remarks>
    Private _button As MessageBoxButtons

    ''' <summary>
    ''' �f�t�H���g�{�^��
    ''' </summary>
    ''' <remarks></remarks>
    Private _defaultButton As MessageBoxDefaultButton

#End Region

#Region " Constructor "

    ''' <summary>
    ''' MessageBoxType �N���X�̐V�����C���X�^���X�����������܂��B
    ''' </summary>
    ''' <param name="message">���b�Z�[�W</param>
    ''' <param name="icon">���b�Z�[�W�{�b�N�X�̃A�C�R��</param>
    ''' <param name="button">���b�Z�[�W�{�b�N�X�̃{�^��</param>
    ''' <remarks></remarks>
    Friend Sub New(ByVal message As String, ByVal icon As MessageBoxIcon, ByVal button As MessageBoxButtons)
        _message = message
        _icon = icon
        _button = button
    End Sub

    ''' <summary>
    ''' MessageBoxType �N���X�̐V�����C���X�^���X�����������܂��B
    ''' </summary>
    ''' <param name="message">���b�Z�[�W</param>
    ''' <param name="icon">���b�Z�[�W�{�b�N�X�̃A�C�R��</param>
    ''' <param name="button">���b�Z�[�W�{�b�N�X�̃{�^��</param>
    ''' <param name="defaultButton">���b�Z�[�W�{�b�N�X�̃f�t�H���g�{�^��</param>
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
    ''' ���b�Z�[�W�{�b�N�X�̃��b�Z�[�W���擾���܂��B
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
    ''' ���b�Z�[�W�{�b�N�X�̃A�C�R�����擾���܂��B
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
    ''' ���b�Z�[�W�{�b�N�X�̃{�^�����擾���܂��B
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
    ''' ���b�Z�[�W�{�b�N�X�̃f�t�H���g�{�^�����擾���܂��B
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
