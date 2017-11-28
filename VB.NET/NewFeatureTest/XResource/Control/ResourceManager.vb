Option Compare Binary
Option Explicit On
Option Strict On

Imports System

Imports System.Globalization

''' <summary>
''' ���\�[�X���烁�b�Z�[�W���擾����@�\��񋟂��܂��B
''' </summary>
''' <remarks></remarks>
Public Class ResourceManager


#Region " Constructor "
    ''' <summary>
    ''' ResourceManager �N���X�̐V�����C���X�^���X�����������܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
    End Sub
#End Region

#Region " Public Method "

#Region " GetCulture "

    ''' <summary>
    ''' ���O�C�����Ă���g�p���錾��̎�ʂ�\���񋓒l���擾���܂��B
    ''' </summary>
    ''' <returns>���O�C�����[�U�[���g�p���錾���Ԃ��܂��B</returns>
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

#Region " GetMessage "

    ''' <summary>
    ''' �G���[�ԍ��ƃ��\�[�X�ɊY�����郁�b�Z�[�W�B
    ''' </summary>
    ''' <param name="MessageType">���b�Z�[�W�ԍ�</param>
    ''' <returns>���\�[�X�Ɋi�[����Ă��郁�b�Z�[�W��Ԃ��܂��B</returns>
    ''' <remarks></remarks>
    Public Shared Function GetMessage(ByVal MessageType As Object) As String

        Try
            Return GetMessage(MessageType, "")
        Catch ex As System.Exception
            Throw ex
        End Try

    End Function

   

    ''' <summary>
    ''' �G���[�ԍ��ƃ��\�[�X�ɊY�����郁�b�Z�[�W�B
    ''' </summary>
    ''' <param name="MessageType">���b�Z�[�W�ԍ�</param>
    ''' <param name="args">�����w�肷�镶����^�̔z��</param>
    ''' <returns>���\�[�X�Ɋi�[����Ă��郁�b�Z�[�W��Ԃ��܂��B</returns>
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
