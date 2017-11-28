Imports System.Runtime.Serialization
<Serializable()> _
Public Class OptionData
    Implements ISerializable

    Private mFileFilter As String = ""
    Private mOutputFold As String = ""
    Private mZipFileNameSetting As String = ""
    Private mPassword As String = ""
    Private mFolderFilter As String = ""
    Private mReleaseFolder As String = ""
    Private mReleaseNameSeting As String = ""
    Private mWinrarPath As String = ""
    Public Property FileFilter() As String
        Get
            Return mFileFilter
        End Get
        Set(ByVal value As String)
            mFileFilter = value
        End Set
    End Property

    Public Property OutputFold() As String
        Get
            Return mOutputFold
        End Get
        Set(ByVal value As String)
            mOutputFold = value
        End Set
    End Property

    Public Property ZipFileNameSetting() As NamingSetting
        Get
            Return NamingSetting.StringToObject(mZipFileNameSetting)
        End Get
        Set(ByVal value As NamingSetting)
            mZipFileNameSetting = value.ObjectToString()
        End Set
    End Property

    Public Property Password() As String
        Get
            Return mPassword
        End Get
        Set(ByVal value As String)
            mPassword = value
        End Set
    End Property

    Public Property FolderFilter() As String
        Get
            Return mFolderFilter
        End Get
        Set(ByVal value As String)
            mFolderFilter = value
        End Set
    End Property

    Public Property ReleaseFolder() As String
        Get
            Return mReleaseFolder
        End Get
        Set(ByVal value As String)
            mReleaseFolder = value
        End Set
    End Property

    Public Property ReleaseNameSeting() As NamingSetting
        Get
            Return NamingSetting.StringToObject(mReleaseNameSeting)
        End Get
        Set(ByVal value As NamingSetting)
            mReleaseNameSeting = value.ObjectToString()
        End Set
    End Property

    Public Property WinrarPath() As String
        Get
            Return Me.mWinrarPath
        End Get
        Set(ByVal value As String)
            Me.mWinrarPath = value
        End Set
    End Property

    Public Sub GetObjectData(ByVal info As SerializationInfo, ByVal context As System.Runtime.Serialization.StreamingContext) Implements System.Runtime.Serialization.ISerializable.GetObjectData
        info.AddValue("FileFilter", mFileFilter, GetType(String))
        info.AddValue("OutputFold", mOutputFold, GetType(String))
        info.AddValue("ZipFileNameSetting", mZipFileNameSetting, GetType(String))
        info.AddValue("Password", mPassword, GetType(String))
        info.AddValue("FolderFilter", mFolderFilter, GetType(String))
        info.AddValue("ReleaseFolder", mReleaseFolder, GetType(String))
        info.AddValue("ReleaseNameSeting", mReleaseNameSeting, GetType(String))
        info.AddValue("WinrarPath", mWinrarPath, GetType(String))
    End Sub

    Protected Sub New(ByVal serializationInfo As SerializationInfo, ByVal context As StreamingContext)
        mFileFilter = serializationInfo.GetString("FileFilter")
        mOutputFold = serializationInfo.GetString("OutputFold")
        mZipFileNameSetting = serializationInfo.GetString("ZipFileNameSetting")
        mPassword = serializationInfo.GetString("Password")
        mFolderFilter = serializationInfo.GetString("FolderFilter")
        mReleaseFolder = serializationInfo.GetString("ReleaseFolder")
        mReleaseNameSeting = serializationInfo.GetString("ReleaseNameSeting")
        mWinrarPath = serializationInfo.GetString("WinrarPath")
    End Sub

    Public Sub New()
        mFileFilter = My.Settings.FileFilter
        mOutputFold = My.Settings.OutputFold
        mZipFileNameSetting = My.Settings.NamingSetting
        mPassword = My.Settings.Password
        mFolderFilter = My.Settings.FolderFilter
        mReleaseFolder = My.Settings.ReleaseFolder
        mReleaseNameSeting = My.Settings.ReleaseNameSeting
        mWinrarPath = My.Settings.WinrarPath
    End Sub

    Public Sub Apply()
        My.Settings.FileFilter = mFileFilter
        My.Settings.OutputFold = mOutputFold
        My.Settings.NamingSetting = mZipFileNameSetting
        My.Settings.Password = mPassword
        My.Settings.FolderFilter = mFolderFilter
        My.Settings.ReleaseFolder = mReleaseFolder
        My.Settings.ReleaseNameSeting = mReleaseNameSeting
        My.Settings.WinrarPath = mWinrarPath
    End Sub
    Public Sub SaveToMySetting()
        My.Settings.FileFilter = mFileFilter
        My.Settings.OutputFold = mOutputFold
        My.Settings.NamingSetting = mZipFileNameSetting
        My.Settings.Password = mPassword
        My.Settings.FolderFilter = mFolderFilter
        My.Settings.ReleaseFolder = mReleaseFolder
        My.Settings.ReleaseNameSeting = mReleaseNameSeting
        My.Settings.WinrarPath = mWinrarPath
        My.Settings.Save()
    End Sub

    Public Function Clone() As OptionData
        Dim copyItem As New OptionData
        copyItem.mFileFilter = Me.mFileFilter
        copyItem.mOutputFold = Me.mOutputFold
        copyItem.mZipFileNameSetting = Me.mZipFileNameSetting
        copyItem.Password = Me.mPassword
        copyItem.FolderFilter = Me.mFolderFilter
        copyItem.ReleaseFolder = Me.mReleaseFolder
        copyItem.mReleaseNameSeting = Me.mReleaseNameSeting
        copyItem.mWinrarPath = Me.mWinrarPath
        Return copyItem
    End Function
End Class
