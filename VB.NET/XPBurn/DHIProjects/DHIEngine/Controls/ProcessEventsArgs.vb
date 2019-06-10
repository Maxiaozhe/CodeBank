Public Class ProcessEventsArgs
    Inherits EventArgs
    Public Enum ProcessTypes
        XMLCHeck
        Burning
        BurnComplete
        CDReading
        CDReadComplete
    End Enum
    Private mMessage As String
    Private mProcessParcent As Integer
    Private mIsWriteLog As Boolean
    Private mProcessType As ProcessTypes
    Public Property ProcessType() As ProcessTypes
        Get
            Return mProcessType
        End Get
        Set(ByVal value As ProcessTypes)
            mProcessType = value
        End Set
    End Property
    Public Property Message() As String
        Get
            Return mMessage
        End Get
        Set(ByVal value As String)
            mMessage = value
        End Set
    End Property

    Public Property ProcessParcent() As Integer
        Get
            Return mProcessParcent
        End Get
        Set(ByVal value As Integer)
            mProcessParcent = value
        End Set
    End Property
    Public Property IsWriteLog() As Boolean
        Get
            Return mIsWriteLog
        End Get
        Set(ByVal value As Boolean)
            mIsWriteLog = value
        End Set
    End Property

    Public Sub New(ByVal msg As String, ByVal parcent As Integer, ByVal ProcType As ProcessTypes, ByVal WriteLog As Boolean)
        mProcessParcent = parcent
        mMessage = msg
        mProcessType = ProcType
        mIsWriteLog = WriteLog
    End Sub

End Class