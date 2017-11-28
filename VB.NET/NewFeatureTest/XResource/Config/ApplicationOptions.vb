Imports System.Text
Imports XResource.ResxConvtor
Imports System.Globalization

Public Class ApplicationOptions
#Region "Enum"
    ''' <summary>
    ''' 署名タイプ
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum SignTypes As Integer
        ''' <summary>
        ''' 自動署名
        ''' </summary>
        ''' <remarks></remarks>
        Auto = 0
        ''' <summary>
        ''' 外部キーファイル指定
        ''' </summary>
        ''' <remarks></remarks>
        SelectFile = 1
    End Enum

#End Region
#Region "内部変数"
    Private mIsSign As Boolean
    Private mSignType As SignTypes
    Private mKeyFilePath As String
    Private mIsBuildPathAuto As Boolean
    Private mBuildPath As String
    Private mIsOpenDllFolder As Boolean
    Private mCsvEncode As String
    Private mIsOpenExportFile As Boolean
    Private mImportType As ImportTypes
    Private mCurrentUICultureCode As String
#End Region
#Region "プロパティ"
    ''' <summary>
    ''' 署名するか
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property IsSign() As Boolean
        Get
            Return Me.mIsSign
        End Get
        Set(ByVal value As Boolean)
            Me.mIsSign = value
        End Set
    End Property
    ''' <summary>
    ''' 署名種別
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SignType() As SignTypes
        Get
            Return Me.mSignType
        End Get
        Set(ByVal value As SignTypes)
            Me.mSignType = value
        End Set
    End Property

    ''' <summary>
    ''' 厳密な名前キーファイルのパス
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property KeyFilePath() As String
        Get
            Return Me.mKeyFilePath
        End Get
        Set(ByVal value As String)
            Me.mKeyFilePath = value
        End Set
    End Property
    ''' <summary>
    ''' ビルドパスを自動決めるか
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property IsBuildPathAuto() As Boolean
        Get
            Return Me.mIsBuildPathAuto
        End Get
        Set(ByVal value As Boolean)
            Me.mIsBuildPathAuto = value
        End Set
    End Property
    ''' <summary>
    ''' 指定したビルドパス
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property BuildPath() As String
        Get
            Return Me.mBuildPath
        End Get
        Set(ByVal value As String)
            Me.mBuildPath = value
        End Set
    End Property
    ''' <summary>
    ''' ビルド後、フォルダを開くか
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property IsOpenDllFolder() As Boolean
        Get
            Return Me.mIsOpenDllFolder
        End Get
        Set(ByVal value As Boolean)
            Me.mIsOpenDllFolder = value
        End Set
    End Property
    ''' <summary>
    ''' CSVファイルのエンコード種類
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CsvEncode() As String
        Get
            Return Me.mCsvEncode
        End Get
        Set(ByVal value As String)
            Me.mCsvEncode = value
        End Set
    End Property

    ''' <summary>
    ''' エクスポート後、ファイルを自動開く
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property IsOpenExportFile() As Boolean
        Get
            Return Me.mIsOpenExportFile
        End Get
        Set(ByVal value As Boolean)
            Me.mIsOpenExportFile = value
        End Set
    End Property
    ''' <summary>
    ''' インポート方法
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ImportType() As ImportTypes
        Get
            Return Me.mImportType
        End Get
        Set(ByVal value As ImportTypes)
            Me.mImportType = value
        End Set
    End Property
    ''' <summary>
    ''' プログラムのロカラーズコード
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CurrentUICultureCode() As String
        Get
            Return Me.mCurrentUICultureCode
        End Get
        Set(ByVal value As String)
            Me.mCurrentUICultureCode = value
        End Set
    End Property
#End Region
#Region "メソッド"
    Public Sub New()
        InitInstance()
    End Sub
    Private Sub InitInstance()
        Me.mIsSign = My.Settings.IsSign
        Me.mSignType = CType(My.Settings.SignType, SignTypes)
        Me.mKeyFilePath = My.Settings.KeyFileName
        Me.mIsBuildPathAuto = My.Settings.IsBuildPathAuto
        If Me.mIsBuildPathAuto = True Then
            Me.mBuildPath = ""
        Else
            Me.mBuildPath = My.Settings.BuildPath
        End If
        Me.mIsOpenDllFolder = My.Settings.IsOpenDllFolder
        Me.mCsvEncode = My.Settings.CSVEncode
        Me.mIsOpenExportFile = My.Settings.IsOpenFile
        Me.mImportType = CType(My.Settings.ImportType, ImportTypes)
        Me.mCurrentUICultureCode = My.Settings.CurrentLanguage
    End Sub
    ''' <summary>
    ''' 設定を登録する
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Save()
        My.Settings.IsSign = Me.mIsSign
        My.Settings.SignType = CInt(Me.mSignType)
        My.Settings.KeyFileName = Me.mKeyFilePath
        My.Settings.IsBuildPathAuto = Me.mIsBuildPathAuto
        If Me.mIsBuildPathAuto = True Then
            My.Settings.BuildPath = ""
        Else
            My.Settings.BuildPath = Me.mBuildPath
        End If
        My.Settings.IsOpenDllFolder = Me.mIsOpenDllFolder
        My.Settings.CSVEncode = Me.mCsvEncode
        My.Settings.IsOpenFile = Me.mIsOpenExportFile
        My.Settings.ImportType = CInt(Me.mImportType)
        My.Settings.CurrentLanguage = Me.mCurrentUICultureCode
        My.Settings.Save()
    End Sub
    Public Function GetCsvEncoding() As Encoding
        Return System.Text.Encoding.GetEncoding(Me.mCsvEncode)
    End Function
#End Region
End Class
