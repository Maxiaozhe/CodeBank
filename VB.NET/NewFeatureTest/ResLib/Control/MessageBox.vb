Option Compare Binary
Option Explicit On
Option Strict On

Imports System
Imports System.Windows.Forms
Imports System.Diagnostics

Imports RTS.RabitFlow
Imports RTS.RabitFlow.Resources

''' <summary>
''' ���b�Z�[�W�{�b�N�X��\�����܂��B
''' </summary>
''' <remarks></remarks>
Partial Public Class MessageBox

#Region " Constant "

    ''' <summary>
    ''' �A�v���P�[�V������
    ''' </summary>
    ''' <remarks></remarks>
    Private Const _appName As String = "R@bitFlow"

#End Region

#Region " Constructor "

    ''' <summary>
    ''' MessageBox �N���X�̐V�����C���X�^���X�����������܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub New()

    End Sub

#End Region

#Region " Public Method "

#Region " Show "

    ''' <summary>
    ''' �w�肵����O�̓��e��\�����܂��B
    ''' </summary>
    ''' <param name="e">��O</param>
    ''' <returns>���b�Z�[�W�{�b�N�X�_�C�A���O�̖߂�l��Ԃ��܂��B</returns>
    ''' <remarks></remarks>
    Public Shared Function Show(ByVal e As System.Exception) As DialogResult
        Return System.Windows.Forms.MessageBox.Show(e.Message, _appName, MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Function

    ''' <summary>
    ''' �w�肵���ԍ��ɊY�����郁�b�Z�[�W���_�C�A���O�\�����܂��B
    ''' </summary>
    ''' <param name="MessageType">���b�Z�[�W�ԍ�</param>
    ''' <returns>���b�Z�[�W�{�b�N�X�_�C�A���O�̖߂�l��Ԃ��܂��B</returns>
    ''' <remarks></remarks>
    Public Shared Function Show(ByVal MessageType As Object) As DialogResult
        Return Show(MessageType, "")
    End Function

    ''' <summary>
    ''' �w�肵���ԍ��ɊY�����郁�b�Z�[�W���_�C�A���O�\�����܂��B
    ''' �f�t�H���g�{�^���̊���l�� Button1 �̂��߁A����ȊO�̃{�^�����f�t�H���g�őI���������ꍇ�͂��̃��\�b�h���g�p���܂��B
    ''' </summary>
    ''' <param name="MessageType">���b�Z�[�W�ԍ�</param>
    ''' <param name="defaultButton">�f�t�H���g�{�^��</param>
    ''' <returns>���b�Z�[�W�{�b�N�X�_�C�A���O�̖߂�l��Ԃ��܂��B</returns>
    ''' <remarks></remarks>
    Public Shared Function Show(ByVal MessageType As Object, ByVal defaultButton As MessageBoxDefaultButton) As DialogResult
        Return Show(MessageType, defaultButton, "")
    End Function

    ''' <summary>
    ''' �w�肵���ԍ��ɊY�����郁�b�Z�[�W���_�C�A���O�\�����܂��B
    ''' �m�F���b�Z�[�W�̃{�^���̊���l�� YesNo �̂��߁A�L�����Z���{�^�����܂߂����ꍇ�͂��̃��\�b�h���g�p���܂��B
    ''' </summary>
    ''' <param name="MessageType">���b�Z�[�W�ԍ�</param>
    ''' <param name="cancel">�L�����Z���{�^�����g�p���邩�ǂ���</param>
    ''' <param name="defaultButton">�f�t�H���g�{�^��</param>
    ''' <returns>���b�Z�[�W�{�b�N�X�_�C�A���O�̖߂�l��Ԃ��܂��B</returns>
    ''' <remarks></remarks>
    Public Shared Function Show(ByVal MessageType As Object, ByVal cancel As Boolean, ByVal defaultButton As MessageBoxDefaultButton) As DialogResult
        Return Show(MessageType, cancel, defaultButton, "")
    End Function


    ''' <summary>
    ''' �w�肵���ԍ��ɊY�����郁�b�Z�[�W���_�C�A���O�\�����܂��B
    ''' </summary>
    ''' <param name="MessageType">���b�Z�[�W�ԍ�</param>
    ''' <param name="args">�����w�肷�镶����^�̔z��</param>
    ''' <returns>���b�Z�[�W�{�b�N�X�_�C�A���O�̖߂�l��Ԃ��܂��B</returns>
    ''' <remarks></remarks>
    Public Shared Function Show(ByVal MessageType As Object, ByVal ParamArray args() As String) As DialogResult

        Try
            Return Show(GetMessageBoxInfo(MessageType, False, MessageBoxDefaultButton.Button1, args))
        Catch ex As System.Exception
            Throw ex
        End Try

    End Function

    ''' <summary>
    ''' �w�肵���ԍ��ɊY�����郁�b�Z�[�W���_�C�A���O�\�����܂��B
    ''' �f�t�H���g�{�^���̊���l�� Button1 �̂��߁A����ȊO�̃{�^�����f�t�H���g�őI���������ꍇ�͂��̃��\�b�h���g�p���܂��B
    ''' </summary>
    ''' <param name="MessageType">���b�Z�[�W�ԍ�</param>
    ''' <param name="args">�����w�肷�镶����^�̔z��</param>
    ''' <param name="defaultButton">�f�t�H���g�{�^��</param>
    ''' <returns>���b�Z�[�W�{�b�N�X�_�C�A���O�̖߂�l��Ԃ��܂��B</returns>
    ''' <remarks></remarks>
    Public Shared Function Show(ByVal MessageType As Object, ByVal defaultButton As MessageBoxDefaultButton, ByVal ParamArray args() As String) As DialogResult

        Try
            Return Show(GetMessageBoxInfo(MessageType, False, defaultButton, args))
        Catch ex As System.Exception
            Throw ex
        End Try

    End Function

    ''' <summary>
    ''' �w�肵���ԍ��ɊY�����郁�b�Z�[�W���_�C�A���O�\�����܂��B
    ''' �m�F���b�Z�[�W�̃{�^���̊���l�� YesNo �̂��߁A�L�����Z���{�^�����܂߂����ꍇ�͂��̃��\�b�h���g�p���܂��B
    ''' </summary>
    ''' <param name="MessageType">���b�Z�[�W�ԍ�</param>
    ''' <param name="args">�����w�肷�镶����^�̔z��</param>
    ''' <param name="cancel">�L�����Z���{�^�����g�p���邩�ǂ���</param>
    ''' <param name="defaultButton">�f�t�H���g�{�^��</param>
    ''' <returns>���b�Z�[�W�{�b�N�X�_�C�A���O�̖߂�l��Ԃ��܂��B</returns>
    ''' <remarks></remarks>
    Public Shared Function Show(ByVal MessageType As Object, ByVal cancel As Boolean, ByVal defaultButton As MessageBoxDefaultButton, ByVal ParamArray args() As String) As DialogResult

        Try
            Return Show(GetMessageBoxInfo(MessageType, cancel, defaultButton, args))
        Catch ex As System.Exception
            Throw ex
        End Try

    End Function

    ''' <summary>
    ''' Show ���\�b�h�łǂ��ɂ��Ȃ�Ȃ��Ƃ��ɁA�x�����b�Z�[�W�_�C�A���O��\�����܂��B
    ''' ��قǂ̂��Ƃ��Ȃ�����A���̃��\�b�h�̎g�p�͋֎~���܂��B
    ''' </summary>
    ''' <param name="msg">���b�Z�[�W</param>
    ''' <returns>���b�Z�[�W�{�b�N�X�_�C�A���O�̖߂�l��Ԃ��܂��B</returns>
    ''' <remarks></remarks>
    Public Shared Function ShowExclamationDialog(ByVal msg As String) As DialogResult
        Return System.Windows.Forms.MessageBox.Show(msg, _appName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Function

#End Region

#Region " Private Method "

#Region " GetMessageBoxInfo "

    ''' <summary>
    ''' ���b�Z�[�W�{�b�N�X�̓��e��\�� MessageBoxInfo �N���X�̃C���X�^���X���擾���܂��B
    ''' </summary>
    ''' <param name="MessageType">���b�Z�[�W�ԍ�</param>
    ''' <param name="args">�����w�肷�镶����^�̔z��</param>
    ''' <returns>���b�Z�[�W�{�b�N�X�̓��e��Ԃ��܂��B</returns>
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
    ''' ���b�Z�[�W�{�b�N�X�_�C�A���O��\�����܂��B
    ''' </summary>
    ''' <param name="msgInfo">���b�Z�[�W�{�b�N�X�̓��e</param>
    ''' <returns>���b�Z�[�W�{�b�N�X�_�C�A���O�̖߂�l��Ԃ��܂��B</returns>
    ''' <remarks></remarks>
    Private Shared Function Show(ByVal msgInfo As MessageBoxInfo) As DialogResult
        Return System.Windows.Forms.MessageBox.Show(msgInfo.Message, _appName, msgInfo.Button, msgInfo.Icon, msgInfo.DefaultButton)
    End Function

#End Region

#End Region

#End Region

End Class
