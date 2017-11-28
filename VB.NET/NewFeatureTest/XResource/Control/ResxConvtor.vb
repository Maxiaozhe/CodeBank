Imports System.Reflection
Imports System.Globalization
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Text
Imports System.Collections.ObjectModel
Imports System.Runtime.CompilerServices
Imports System.ComponentModel

''' <summary>
''' リソースファイルコンバーター
''' </summary>
''' <remarks></remarks>
Public Class ResxConvtor
#Region "内部クラス"
    Public Class DisplayNameForRsAttribute
        Inherits DisplayNameAttribute
        Public Overrides ReadOnly Property DisplayName() As String
            Get
                Return ResManager.GetString(GetType(ResxConvtor), MyBase.DisplayName)
            End Get
        End Property
        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal displayname As String)
            MyBase.New(displayname)
        End Sub
    End Class
    ''' <summary>
    ''' インポートタイプ
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum ImportTypes As Integer
        ''' <summary>
        ''' 既存のリソースを全部置き換える
        ''' </summary>
        ''' <remarks></remarks>
        ReplaceAll = 0
        ''' <summary>
        ''' 既存のリソースを基でマッジする
        ''' </summary>
        ''' <remarks></remarks>
        MargePreserve = 1
        ''' <summary>
        ''' インポートするリソースを基でマッジする
        ''' </summary>
        ''' <remarks></remarks>
        MargeNotPreserve = 2
    End Enum

    Public Interface IResourceObject
        Property Name() As String
        Property FileName() As String
        ReadOnly Property objectValue() As Object
        ReadOnly Property ValueString() As String
    End Interface

    Public Class ResourceObject(Of RsType)
        Implements IResourceObject
        Private mName As String
        Private mFileName As String
        Private mValue As RsType
        Private mObjectValue As Object
        Private mConverter As TypeConverter
        Sub New(ByVal value As Object)
            mObjectValue = value
            mConverter = TypeDescriptor.GetConverter(value)
            If TypeOf mObjectValue Is RsType Then
                mValue = DirectCast(mObjectValue, RsType)
            Else
                mValue = CType(mConverter.ConvertTo(mObjectValue, GetType(RsType)), RsType)
            End If

        End Sub

        ''' <summary>
        ''' 名前
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Browsable(True), DisplayNameForRs("name")> _
        Public Property Name() As String Implements IResourceObject.Name
            Get
                Return mName
            End Get
            Set(ByVal value As String)
                mName = value
            End Set
        End Property
        <Browsable(False)> _
        Public ReadOnly Property ObjectValue() As Object Implements IResourceObject.objectValue
            Get
                Return mObjectValue
            End Get
        End Property
        ''' <summary>
        ''' 値
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Browsable(True), DisplayNameForRs("value"), EditorBrowsable(EditorBrowsableState.Always), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)> _
        Public Property TypeValue() As RsType
            Get

                Return mValue
            End Get
            Set(ByVal value As RsType)
                mValue = value
                If value.GetType() Is GetType(RsType) Then
                    mObjectValue = mValue
                Else
                    mObjectValue = mConverter.ConvertFrom(mValue)
                End If
            End Set
        End Property
        ''' <summary>
        ''' リソースファイル名
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Browsable(True), DisplayNameForRs("file")> _
        Public Property FileName() As String Implements IResourceObject.FileName
            Get
                Return mFileName
            End Get
            Set(ByVal value As String)
                mFileName = value
            End Set
        End Property
        <Browsable(False)> _
        Public ReadOnly Property ValueString() As String Implements IResourceObject.ValueString
            Get
                Return mObjectValue.ToString
            End Get
        End Property
    End Class
#End Region
#Region "内部変数"
    Private mAssemblyPath As String = Nothing
    Private mAssembly As Assembly = Nothing
    Private mCultureInfo As CultureInfo = Nothing
    Private mResourceSet As DataTable = Nothing
    Private mOtherResource As New List(Of IResourceObject)
    Private mIsSign As Boolean = False
    Private mkeyFileName As String = ""
    Private mBuildpath As String = ""
    Private Const mWinresItemHeader As String = ">>"
    Private mcolName As String = "name"
    Private mcolValue As String = "value"
    Private mcolFile As String = "file"
#End Region
#Region "プロパティ"
    Public ReadOnly Property ResAssembly() As Assembly
        Get
            Return mAssembly
        End Get
    End Property

    ''' <summary>
    ''' リソースセットを取得する
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ResourceSet() As DataTable
        Get
            Return mResourceSet
        End Get
    End Property
    ''' <summary>
    ''' その他リソースを取得する
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property OtherResources() As List(Of IResourceObject)
        Get
            Return Me.mOtherResource
        End Get
    End Property
    ''' <summary>
    ''' アセンブリのカルチャ情報
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property CurrentCultureInfo() As CultureInfo
        Get
            Return Me.mCultureInfo
        End Get
    End Property
    ''' <summary>
    ''' 署名するか？
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property IsSign() As Boolean
        Get
            Return mIsSign
        End Get
        Set(ByVal value As Boolean)
            mIsSign = value
        End Set
    End Property
    ''' <summary>
    ''' 厳密な名前のキーファイルの名前
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property KeyFileName() As String
        Get
            Return mkeyFileName
        End Get
        Set(ByVal value As String)
            mkeyFileName = value
        End Set
    End Property
    Public Property BuildPath() As String
        Get
            Return Me.mBuildpath
        End Get
        Set(ByVal value As String)
            Me.mBuildpath = value
        End Set
    End Property
    Public ReadOnly Property NameColumn() As String
        Get
            Return Me.mcolName
        End Get
    End Property
    Public ReadOnly Property ValueColumn() As String
        Get
            Return Me.mcolValue
        End Get
    End Property
    Public ReadOnly Property FileColumn() As String
        Get
            Return Me.mcolFile
        End Get
    End Property
#End Region
#Region "公開メソッド"
    ''' <summary>
    ''' アセンブリでインスタンスを初期化する
    ''' </summary>
    ''' <param name="Assembly"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal Assembly As Assembly)
        GetinnerResources()
        Me.mAssembly = Assembly
        Me.mAssemblyPath = Assembly.Location
        mCultureInfo = mAssembly.GetName().CultureInfo
        mResourceSet = Me.GetResourceSet
    End Sub
    ''' <summary>
    ''' アセンブリのパスでインスタンスを初期化する
    ''' </summary>
    ''' <param name="AssemblyPath"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal AssemblyPath As String)
        GetinnerResources()
        mAssemblyPath = AssemblyPath
        mAssembly = Assembly.LoadFrom(AssemblyPath)
        mCultureInfo = mAssembly.GetName().CultureInfo
        mResourceSet = Me.GetResourceSet
    End Sub
    ''' <summary>
    ''' リソースファイルをCSVファイルに変換する
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ConvertToCsv(ByVal FileName As String, ByVal Encoding As System.Text.Encoding)
        If Me.mResourceSet Is Nothing Then
            Return
        End If
        Dim sb As New System.Text.StringBuilder
        Dim Index As Integer = 0
        Dim value As String = ""
        Dim Columns As DataColumnCollection = Me.mResourceSet.Columns
        For Each col As DataColumn In Columns
            If Index > 0 Then
                sb.Append(",")
            End If
            sb.Append(ToCsv(col.ColumnName))
            Index += 1
        Next
        For Each row As DataRow In Me.mResourceSet.Rows
            Index = 0
            sb.Append(vbCrLf)
            For Each col As DataColumn In Columns

                If Index > 0 Then
                    sb.Append(",")
                End If
                If col.ColumnName = mcolFile Then
                    value = Me.ChangeResourceFileName(DBToString(row.Item(col).ToString), Me.mCultureInfo.IetfLanguageTag, "")
                Else
                    value = DBToString(row.Item(col).ToString)
                End If
                sb.Append(ToCsv(value))
                Index += 1
            Next
        Next
        My.Computer.FileSystem.WriteAllText(FileName, sb.ToString, False, Encoding)
    End Sub

    ''' <summary>
    ''' リソースファイルをXMLファイルに変換する
    ''' </summary>
    ''' <param name="FileName"></param>
    ''' <remarks></remarks>
    Public Sub ConvertToXml(ByVal FileName As String)
        If Me.mResourceSet Is Nothing Then
            Return
        End If
        Dim dtt As DataTable = Me.mResourceSet.Copy
        For Each row As DataRow In dtt.Rows
            Dim file As String = CStr(row.Item(mcolFile))
            row.Item(mcolFile) = Me.ChangeResourceFileName(file, Me.mCultureInfo.IetfLanguageTag, "")
        Next
        dtt.WriteXml(FileName)
    End Sub
    ''' <summary>
    ''' Resxファイルへ変換する
    ''' </summary>
    ''' <param name="FolderName"></param>
    ''' <remarks></remarks>
    Public Sub ConvertToResx(ByVal FolderName As String, ByVal culture As CultureInfo)
        If Me.mResourceSet Is Nothing Then
            Return
        End If
        Dim ResxWriter As System.Resources.ResXResourceWriter = Nothing
        Dim Files As List(Of String) = Me.GetOutputResourceFiles(False)
        For Each file In Files
            Dim RescouceFile As String = file
            Dim FileName As String = ChangeResourceFileName(RescouceFile, Me.mCultureInfo.IetfLanguageTag, culture.IetfLanguageTag)
            Dim ResxName As String = System.IO.Path.GetFileNameWithoutExtension(FileName)
            Dim ResxPath As String = Path.Combine(FolderName, ResxName & ".Resx")
            ResxWriter = New System.Resources.ResXResourceWriter(ResxPath)
            Dim ResDatas = From row In Me.mResourceSet Where CStr(row.Item(mcolFile)) = RescouceFile _
                           Select New With {.Key = CStr(row.Item(mcolName)), .value = CStr(row.Item(mcolValue))}
            For Each res In ResDatas
                ResxWriter.AddResource(res.Key, res.value)
            Next
            Dim otherReses As List(Of IResourceObject) = Me.GetOtherResources(file)
            For Each oRes In otherReses
                ResxWriter.AddResource(oRes.Name, oRes.objectValue)
            Next
            ResxWriter.Close()
        Next
    End Sub
    ''' <summary>
    ''' Resourceファイルへ変換する
    ''' </summary>
    ''' <param name="FolderName"></param>
    ''' <remarks></remarks>
    Public Sub ConvertToResources(ByVal FolderName As String, ByVal culture As CultureInfo)
        If Me.mResourceSet Is Nothing Then
            Return
        End If
        Dim ResourceWriter As System.Resources.ResourceWriter = Nothing
        Dim Files As List(Of String) = Me.GetOutputResourceFiles(False)
        For Each file In Files
            Dim RescouceFile As String = file
            Dim FileName As String = ChangeResourceFileName(RescouceFile, Me.mCultureInfo.IetfLanguageTag, culture.IetfLanguageTag)
            Dim ResourceName As String = System.IO.Path.GetFileNameWithoutExtension(FileName)
            Dim ResourcePath As String = Path.Combine(FolderName, ResourceName & ".resources")
            ResourceWriter = New System.Resources.ResourceWriter(ResourcePath)
            Dim ResDatas = From row In Me.mResourceSet Where CStr(row.Item(mcolFile)) = RescouceFile _
                           Select New With {.Key = CStr(row.Item(mcolName)), .value = CStr(row.Item(mcolValue))}
            For Each res In ResDatas
                ResourceWriter.AddResource(res.Key, res.value)
            Next
            Dim otherReses As List(Of IResourceObject) = Me.GetOtherResources(file)
            For Each oRes In otherReses
                ResourceWriter.AddResource(oRes.Name, oRes.objectValue)
            Next
            ResourceWriter.Close()
        Next
    End Sub
    ''' <summary>
    ''' ResxからeResourcesに出力する
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CreateResourcesFile(ByVal Culture As CultureInfo, ByVal StringOnly As Boolean)
        Dim DataSet As DataTable = Me.mResourceSet
        Dim BatCmd As New StringBuilder
        Dim Files As List(Of String) = GetOutputResourceFiles(StringOnly)
        Dim BasePath As String = GetBasePath(Culture)
        If System.IO.Directory.Exists(BasePath) = False Then
            My.Computer.FileSystem.CreateDirectory(BasePath)
        End If
        For Each file In Files
            Dim DefFile As String = file
            Dim FileName As String = ChangeResourceFileName(DefFile, Me.mCultureInfo.IetfLanguageTag, Culture.IetfLanguageTag)
            Dim FilePath As String = Path.Combine(BasePath, FileName)
            Dim resWriter As New System.Resources.ResourceWriter(FilePath)
            Dim ResDatas = From row In DataSet Where CStr(row.Item(mcolFile)) = DefFile _
                           Select New With {.Key = CStr(row.Item(mcolName)), .value = CStr(row.Item(mcolValue))}
            For Each res In ResDatas
                resWriter.AddResource(res.Key, res.value)
            Next
            If StringOnly = False Then
                Dim otherReses As List(Of IResourceObject) = Me.GetOtherResources(file)
                For Each oRes In otherReses
                    resWriter.AddResource(oRes.Name, oRes.objectValue)
                Next
            End If
            resWriter.Close()
            BatCmd.AppendLine(" /embed:" & FileName)
        Next
        'コンパイルオプションファイルを作成する
        Dim bitOptPath As String = System.IO.Path.Combine(BasePath, "Al.option")
        My.Computer.FileSystem.WriteAllText(bitOptPath, BatCmd.ToString, False)
    End Sub
    ''' <summary>
    ''' ResxからDllに変換する
    ''' </summary>
    ''' <param name="Culture"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ComplierResources(ByVal Culture As CultureInfo, ByVal StringOnly As Boolean) As Boolean
        Try
            'コンパイル前の準備（Resourcesファイルとコンパイルオプションファイル作成する）
            CreateResourcesFile(Culture, StringOnly)
            'コンパイル
            'Assembly属性設定
            Dim BasePath As String = GetBasePath(Culture)
            Dim Param As New StringBuilder
            Param.Append("@Al.option")
            Param.Append(" /t:lib")
            Dim attr() As Object = Me.mAssembly.GetCustomAttributes(GetType(AssemblyTitleAttribute), True)
            If attr IsNot Nothing AndAlso attr.Length > 0 Then
                Param.AppendFormat(" /title:""{0}""", CType(attr(0), AssemblyTitleAttribute).Title)
            End If
            Param.AppendFormat(" /v:""{0}""", Me.mAssembly.GetName().Version.ToString())
            attr = Me.mAssembly.GetCustomAttributes(GetType(AssemblyCompanyAttribute), True)
            If attr IsNot Nothing AndAlso attr.Length > 0 Then
                Param.AppendFormat(" /comp:""{0}""", CType(attr(0), AssemblyCompanyAttribute).Company)
            End If
            attr = Me.mAssembly.GetCustomAttributes(GetType(AssemblyDescriptionAttribute), True)
            If attr IsNot Nothing AndAlso attr.Length > 0 Then
                Param.AppendFormat(" /descr:""{0}""", CType(attr(0), AssemblyDescriptionAttribute).Description)
            End If
            If Culture.IetfLanguageTag <> "" Then
                Param.AppendFormat(" /c:""{0}""", Culture.IetfLanguageTag)
            End If
            'KeyFile出力
            If Me.mIsSign Then
                Dim keyFile As String = CreatekeyFile(BasePath)
                Param.AppendFormat(" /keyf:{0}", keyFile)
            End If
            Dim outName As String = ""
            If Me.mAssemblyPath.ToLower.EndsWith(".resources.dll") = False Then
                outName = System.IO.Path.GetFileNameWithoutExtension(mAssemblyPath) & ".Resources.dll"
            Else
                outName = System.IO.Path.GetFileName(mAssemblyPath)
            End If
            Param.AppendFormat(" /out:""{0}""", outName)
            Dim SysFolder As System.IO.DirectoryInfo = New System.IO.DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.System))
            Dim exePath As String = Path.Combine(SysFolder.Parent.FullName, "Microsoft.NET\Framework\v2.0.50727\AL.exe")
            Dim proInfo = New ProcessStartInfo
            proInfo.FileName = exePath
            proInfo.Arguments = Param.ToString
            proInfo.WorkingDirectory = BasePath
            proInfo.UseShellExecute = True
            proInfo.WindowStyle = ProcessWindowStyle.Hidden
            Dim Proc As Process = Process.Start(proInfo)
            Proc.WaitForExit()
            Dim ResFiles As ReadOnlyCollection(Of String) = My.Computer.FileSystem.GetFiles(BasePath, FileIO.SearchOption.SearchTopLevelOnly, "*.resources", "*.option")
            For Each File As String In ResFiles
                My.Computer.FileSystem.DeleteFile(File)
            Next
            If Proc.ExitCode = 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ''' <summary>
    ''' 出力のベースパース
    ''' </summary>
    ''' <param name="Culture"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetBasePath(ByVal Culture As CultureInfo) As String
        Dim BasePath As String = ""
        If Me.mBuildpath = "" OrElse System.IO.Directory.Exists(Me.mBuildpath) = False Then
            BasePath = Path.Combine(System.IO.Path.GetDirectoryName(Me.mAssemblyPath), "Resources")
        Else
            BasePath = Path.Combine(Me.mBuildpath, "Resources")
        End If
        Dim OutputPath As String = ""
        Dim code As String = Culture.IetfLanguageTag
        If code <> "" Then
            BasePath = Path.Combine(BasePath, code)
        End If
        Return BasePath
    End Function
    ''' <summary>
    ''' XMLファイルをインポートする
    ''' </summary>
    ''' <param name="XmlFile"></param>
    ''' <remarks></remarks>
    Public Sub ImportXml(ByVal XmlFile As String, ByVal importType As ImportTypes)
        Try
            Dim tblOrg As DataTable = Me.mResourceSet.Copy
            Dim tblImported As DataTable = Me.mResourceSet.Clone
            tblImported.ReadXml(XmlFile)
            For Each row As DataRow In tblImported.Rows
                Dim file As String = CStr(row.Item(mcolFile))
                row.Item(mcolFile) = Me.ChangeResourceFileName(file, "", Me.mCultureInfo.IetfLanguageTag)
            Next

            Select Case importType
                Case ImportTypes.ReplaceAll
                    Me.mResourceSet = tblImported
                Case ImportTypes.MargePreserve
                    tblOrg.Merge(tblImported, True)
                    Me.mResourceSet = tblOrg
                Case ImportTypes.MargeNotPreserve
                    tblOrg.Merge(tblImported, False)
                    Me.mResourceSet = tblOrg
            End Select

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    ''' <summary>
    ''' 編集後のResourceファイルを出力
    ''' </summary>
    ''' <param name="StringOnly"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetOutputResourceFiles(ByVal StringOnly As Boolean) As List(Of String)
        Dim StrSet As DataTable = Me.mResourceSet
        Dim StrFiles As IEnumerable(Of String) = From row In StrSet Select CStr(row.Item(mcolFile)) Distinct
        Dim FileAll As New List(Of String)(StrFiles)
        If StringOnly = False Then
            Dim OtherFiles As IEnumerable(Of String) = From ors In Me.mOtherResource Select ors.FileName Distinct
            For Each orf As String In OtherFiles
                If FileAll.Contains(orf) = False Then
                    FileAll.Add(orf)
                End If
            Next
        End If
        Return FileAll
    End Function
    ''' <summary>
    ''' リソース項目が存在するかをチェックする
    ''' </summary>
    ''' <param name="keyName"></param>
    ''' <param name="Filename"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsExist(ByVal keyName As String, ByVal Filename As String) As Boolean
        Dim Num1 As Integer = Aggregate row In Me.mResourceSet Into Count(CStr(row.Item(mcolName)) = keyName And CStr(row.Item(mcolFile)) = Filename)
        If Num1 > 0 Then
            Return True
        End If
        Dim Num2 As Integer = Aggregate robj In Me.mOtherResource Into Count(robj.Name = keyName AndAlso robj.FileName = Filename)
        If Num2 > 0 Then
            Return True
        End If
        Return False
    End Function
#End Region
#Region "私用メソッド"
    Private Sub GetinnerResources()
        mcolName = ResManager.GetString(Me.GetType, "name")
        mcolValue = ResManager.GetString(Me.GetType, "value")
        mcolFile = ResManager.GetString(Me.GetType, "file")
    End Sub
    ''' <summary>
    ''' リソースデータテーブルを作成する
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetResourceSet() As DataTable
        Dim Datatable As New DataTable("Resources")
        Datatable.Columns.Add(mcolName)
        Datatable.Columns.Add(mcolValue)
        Datatable.Columns.Add(mcolFile)
        Datatable.PrimaryKey = New DataColumn() {Datatable.Columns.Item(0), Datatable.Columns.Item(2)}
        If mAssembly IsNot Nothing Then
            Try
                Dim resources() As String = mAssembly.GetManifestResourceNames
                For Each resfile As String In resources
                    If resfile.ToLower().EndsWith(".resources") = False Then
                        Continue For
                    End If
                    Dim index As Integer = resfile.IndexOf(".")
                    Dim basename As String = resfile.Substring(0, index)
                    Dim stream As IO.Stream = mAssembly.GetManifestResourceStream(resfile)
                    Dim resReader As New System.Resources.ResourceReader(stream)
                    Dim enumor As IEnumerable(Of DictionaryEntry) = resReader.Cast(Of DictionaryEntry)()
                    Dim source = From res In enumor
                    For Each item In source
                        'Winres用のリソースをSKIPする（先頭>>を付けている項目）
                        If CStr(item.Key).StartsWith(mWinresItemHeader) Then
                            Continue For
                        End If
                        If TypeOf item.Value Is System.String Then
                            Dim row As DataRow = Datatable.NewRow
                            row.Item(mcolName) = item.Key
                            row.Item(mcolValue) = item.Value
                            row.Item(mcolFile) = resfile
                            Datatable.Rows.Add(row)
                        Else
                            Dim resObj As IResourceObject = Nothing
                            If item.Value IsNot Nothing Then
                                Select Case item.Value.GetType.FullName
                                    Case GetType(Int32).FullName
                                        resObj = New ResourceObject(Of Int32)(item.Value) With {.Name = CStr(item.Key), .FileName = resfile}
                                    Case GetType(Int16).FullName
                                        resObj = New ResourceObject(Of Int16)(item.Value) With {.Name = CStr(item.Key), .FileName = resfile}
                                    Case GetType(Boolean).FullName
                                        resObj = New ResourceObject(Of Boolean)(item.Value) With {.Name = CStr(item.Key), .FileName = resfile}
                                    Case GetType(System.Drawing.Icon).FullName
                                        resObj = New ResourceObject(Of Icon)(item.Value) With {.Name = CStr(item.Key), .FileName = resfile}
                                    Case GetType(Bitmap).FullName
                                        resObj = New ResourceObject(Of Bitmap)(item.Value) With {.Name = CStr(item.Key), .FileName = resfile}
                                    Case GetType(Font).FullName
                                        resObj = New ResourceObject(Of Font)(item.Value) With {.Name = CStr(item.Key), .FileName = resfile}
                                    Case GetType(Size).FullName
                                        resObj = New ResourceObject(Of Size)(item.Value) With {.Name = CStr(item.Key), .FileName = resfile}
                                    Case GetType(Color).FullName
                                        resObj = New ResourceObject(Of Color)(item.Value) With {.Name = CStr(item.Key), .FileName = resfile}
                                    Case GetType(Point).FullName
                                        resObj = New ResourceObject(Of Point)(item.Value) With {.Name = CStr(item.Key), .FileName = resfile}
                                    Case GetType(SizeF).FullName
                                        resObj = New ResourceObject(Of SizeF)(item.Value) With {.Name = CStr(item.Key), .FileName = resfile}
                                    Case GetType(ImeMode).FullName
                                        resObj = New ResourceObject(Of ImeMode)(item.Value) With {.Name = CStr(item.Key), .FileName = resfile}
                                    Case GetType(FormStartPosition).FullName
                                        resObj = New ResourceObject(Of FormStartPosition)(item.Value) With {.Name = CStr(item.Key), .FileName = resfile}
                                    Case GetType(Byte()).FullName
                                        resObj = New ResourceObject(Of Byte())(item.Value) With {.Name = CStr(item.Key), .FileName = resfile}
                                    Case Else
                                        Dim Convter As TypeConverter = TypeDescriptor.GetConverter(item.Value)
                                        If Convter.CanConvertFrom(GetType(String)) AndAlso Convter.CanConvertTo(GetType(String)) Then
                                            resObj = New ResourceObject(Of String)(item.Value) With {.Name = CStr(item.Key), .FileName = resfile}
                                        Else
                                            resObj = New ResourceObject(Of Object)(item.Value) With {.Name = CStr(item.Key), .FileName = resfile}
                                        End If
                                End Select
                                Me.mOtherResource.Add(resObj)
                            End If
                        End If
                    Next
                Next
            Catch ex As Exception
                Throw ex
            End Try
        End If
        Return Datatable
    End Function
    ''' <summary>
    ''' 他のリソースファイルを取得
    ''' </summary>
    ''' <param name="fileName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetOtherResources(ByVal fileName As String) As List(Of IResourceObject)
        Dim List = From ro In Me.mOtherResource Where ro.FileName = fileName
        Return New List(Of IResourceObject)(List)
    End Function

    ''' <summary>
    ''' 指定の言語でResourceファイル名を変換する
    ''' </summary>
    ''' <param name="FileName"></param>
    ''' <param name="targetCulture"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ChangeResourceFileName(ByVal FileName As String, ByVal OrgCulture As String, ByVal targetCulture As String) As String
        If OrgCulture = targetCulture Then
            Return FileName
        End If
        Dim pattrn As String = ""
        If OrgCulture <> "" Then
            pattrn = "(?<=[\w\.]+\.){0}\.resources$"
        Else
            pattrn = "(?<=[\w\.]+\.)resources$"
        End If
        Dim rex As Regex = New Regex(String.Format(pattrn, OrgCulture), RegexOptions.IgnoreCase)
        Dim replace As String = ""
        If targetCulture = "" Then
            replace = "resources"
        Else
            replace = targetCulture & ".resources"
        End If
        Dim NewFileName As String = rex.Replace(FileName, replace)
        Return NewFileName
    End Function
    ''' <summary>
    ''' キーファイル作成する
    ''' </summary>
    ''' <param name="basePath"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CreatekeyFile(ByVal basePath As String) As String
        Dim bytes() As Byte
        Dim KeyFileName As String = ""
        '外部のキーファイルが存在しない場合、内部のキーファイルを使用する
        If Me.mkeyFileName = "" OrElse File.Exists(mkeyFileName) = False Then
            bytes = My.Resources.RabitFlow
            KeyFileName = "RabitFlow.snk"
        Else
            bytes = My.Computer.FileSystem.ReadAllBytes(mkeyFileName)
            KeyFileName = Path.GetFileName(mkeyFileName)
        End If
        If bytes IsNot Nothing AndAlso bytes.Length > 0 Then
            Dim KeyfilePath As String = Path.Combine(basePath, KeyFileName)
            My.Computer.FileSystem.WriteAllBytes(KeyfilePath, bytes, False)
        End If
        Return KeyFileName
    End Function
    Private Function ToCsv(ByVal value As String) As String
        If value Is Nothing Then Return ""
        Dim strbuf As String = value
        strbuf = strbuf.Replace("""", """""")
        If strbuf.IndexOf(",") > -1 OrElse strbuf.IndexOf(vbCrLf) > -1 Then
            strbuf = """" & strbuf & """"
        End If
        Return strbuf
    End Function
    Private Function DBToString(ByVal value As Object) As String
        If value Is Nothing OrElse TypeOf value Is DBNull Then
            Return ""
        Else
            Return CType(value, String)
        End If
    End Function
    ''' <summary>
    ''' オブジェクトをバイナリに変換する
    ''' </summary>
    ''' <param name="ObjectData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ObjectToByte(ByVal ObjectData As Object) As Byte()
        Try
            Dim StrSerializ As String = ""
            Dim Formater As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter()
            Dim Stream As New System.IO.MemoryStream()
            Formater.Serialize(Stream, ObjectData)
            Dim bts() As Byte
            bts = Stream.ToArray()
            Stream.Close()
            Return bts
        Catch ex As Exception
            Throw ex
        End Try
    End Function
  
#End Region
End Class
