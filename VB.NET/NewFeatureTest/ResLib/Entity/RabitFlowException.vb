Option Compare Binary
Option Explicit On
Option Strict On

Imports System

''' <summary>
''' ApplicationException �̊g����O�N���X�ł��B
''' </summary>
''' <remarks></remarks>
Public Class RabitFlowException
    Inherits ApplicationException

#Region " Member Field "

    ''' <summary>
    ''' �G���[�ԍ�
    ''' </summary>
    ''' <remarks></remarks>
    Private _ExceptType As Object


#End Region

#Region " Constructor "

    ''' <summary>
    ''' �w�肵���G���[�ԍ��ƃ��b�Z�[�W�� RabitFlowException �̐V�����C���X�^���X�����������܂��B
    ''' </summary>
    ''' <param name="ExceptType">�G���[�ԍ�</param>
    ''' <param name="msg">�G���[���b�Z�[�W</param>
    ''' <remarks></remarks>
    Protected Friend Sub New(ByVal ExceptType As Object, ByVal msg As String)
        MyBase.New(msg)

        _ExceptType = ExceptType
    End Sub

  
#End Region

#Region " Public Property "

    ''' <summary>
    ''' �G���[�ԍ����擾���܂��B
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
