Option Compare Binary
Option Explicit On
Option Strict On

Imports System.Windows.Forms
Imports System.Drawing
Imports System.Reflection
Imports System.IO
Imports System.Text
Imports System.Globalization

Public Class frmResEditor
#Region "内部変数"
    Private mResConvter As ResxConvtor
    Private mOptions As ApplicationOptions
    Private mResourceView As DataView
    Private mSearchForm As frmSearch
    Private mListManager As ListViewSortManager
#End Region
#Region "構造体"
    Public Structure LanguageInfo
        Private mLanguageCode As String
        Private mName As String
        Public Property LanguageCode() As String
            Get
                Return mLanguageCode
            End Get
            Set(ByVal value As String)
                mLanguageCode = value
            End Set
        End Property

        Public Property Name() As String
            Get
                Return mName
            End Get
            Set(ByVal value As String)
                mName = value
            End Set
        End Property

        Public ReadOnly Property DisplayName() As String
            Get
                If mLanguageCode = "" Then
                    Return "(既定値)"
                Else
                    Return mLanguageCode.PadRight(10) & "|" & mName
                End If
            End Get
        End Property

    End Structure
#End Region
#Region "メッソド"
    Private Sub InitLanguageList()
        Me.mnuLanguage.DropDownItems.Clear()
        Dim strlanguageList As String = My.Resources.LanguageList
        Dim Languages() As String = strlanguageList.Split(";"c)
        For Each lang As String In Languages
            Dim sect() As String = lang.Split(":"c)
            If sect Is Nothing OrElse sect.Length <> 2 Then
                Continue For
            End If
            Dim name As String = sect(0)
            Dim code As String = sect(1)
            Dim menuItem As New System.Windows.Forms.ToolStripMenuItem
            menuItem.Text = name
            menuItem.Tag = code
            If My.Settings.CurrentLanguage.ToLower = code.ToLower Then
                menuItem.Checked = True
            End If
            AddHandler menuItem.Click, AddressOf mnuLanguage_Click
            Me.mnuLanguage.DropDownItems.Add(menuItem)
        Next
    End Sub
    Private Sub ChangeStatus()
        Dim rm As WindowsUIResourceManager = ResManager.GetUIResourceManager(Me, Me.GetType())
        Dim title As String = rm.GetString("$this.Text")
        If Me.mResConvter IsNot Nothing Then
            Me.TabControl1.Enabled = True
            Me.mnuBuild.Enabled = True
            Me.mnuExport.Enabled = True
            Me.mnuImport.Enabled = True
            Me.toolBuild.Enabled = True
            Me.toolExport.Enabled = True
            Me.toolImport.Enabled = True
            Me.toolSpliter1.Enabled = True
            Me.toolSpliter2.Enabled = True
            Me.toolSpliter3.Enabled = True
            Me.mnuSearch.Enabled = True
            If Me.mResourceView.RowFilter = "" Then
                Me.mnuSearchCancel.Enabled = False
            Else
                Me.mnuSearchCancel.Enabled = True
            End If
            If Me.TabControl1.SelectedTab Is Me.tabStringRes Then
                Me.mnuAddResource.Enabled = False
                Me.mnuDelete.Enabled = False
                Me.toolAddRes.Enabled = False
                Me.toolDelete.Enabled = False
                Me.toolSpliter3.Enabled = False
            Else
                Me.mnuAddResource.Enabled = True
                Me.mnuDelete.Enabled = True
                Me.toolAddRes.Enabled = True
                Me.toolDelete.Enabled = True
                Me.toolSpliter3.Enabled = True
            End If
            Me.toolLabel.Enabled = True
            Me.cmblaguage.Enabled = True
            Me.Text = System.IO.Path.GetFileName(Me.mResConvter.ResAssembly.Location) & " - " & title
        Else
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Enabled = False
            Me.mnuBuild.Enabled = False
            Me.mnuExport.Enabled = False
            Me.mnuImport.Enabled = False
            Me.toolBuild.Enabled = False
            Me.toolExport.Enabled = False
            Me.toolImport.Enabled = False
            Me.toolSpliter1.Enabled = False
            Me.toolSpliter2.Enabled = False
            Me.toolSpliter3.Enabled = False
            Me.mnuAddResource.Enabled = False
            Me.mnuDelete.Enabled = False
            Me.mnuSearch.Enabled = False
            Me.mnuSearchCancel.Enabled = False
            Me.toolAddRes.Enabled = False
            Me.toolDelete.Enabled = False
            Me.toolLabel.Enabled = False
            Me.cmblaguage.Enabled = False
            Me.Text = title
        End If
    End Sub
    ''' <summary>
    ''' その他リソースリストを表示する
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InitOtherResourceList(ByVal otherResources As List(Of ResxConvtor.IResourceObject))
        Try
            Me.PropertyGrid1.SelectedObject = Nothing
            Me.splProperty.Panel1Collapsed = True
            Me.lstOtherRes.Items.Clear()
            Me.lstOtherRes.BeginUpdate()
            Me.Cursor = Cursors.WaitCursor
            Dim viewitems As New List(Of ListViewItem)
            For Each objres As ResxConvtor.IResourceObject In otherResources
                Dim lstItem As New ListViewItem(objres.Name)
                lstItem.SubItems.Add(objres.ValueString.ToString)
                lstItem.SubItems.Add(objres.FileName)
                lstItem.Tag = objres
                viewitems.Add(lstItem)
            Next
            Me.lstOtherRes.Items.AddRange(viewitems.ToArray())
            viewitems.Clear()
            viewitems = Nothing
        Finally
            Me.Cursor = Cursors.Default
            Me.lstOtherRes.EndUpdate()
        End Try
    End Sub
    ''' <summary>
    ''' プレビュー表示
    ''' </summary>
    ''' <param name="objectValue"></param>
    ''' <remarks></remarks>
    Private Sub InitPreview(ByVal objectValue As Object)
        Dim img As Image = Nothing
        If TypeOf objectValue Is Image Then
            img = DirectCast(objectValue, Image)
        ElseIf TypeOf objectValue Is Icon Then
            img = DirectCast(objectValue, Icon).ToBitmap
        End If
        If img IsNot Nothing Then
            If img.Size.Width > PictureboxPreview.Width OrElse img.Size.Height > PictureboxPreview.Height Then
                PictureboxPreview.SizeMode = PictureBoxSizeMode.Zoom
            Else
                PictureboxPreview.SizeMode = PictureBoxSizeMode.CenterImage
            End If
            PictureboxPreview.Image = img
            Me.splProperty.Panel1Collapsed = False
        Else
            PictureboxPreview.Image = Nothing
            Me.splProperty.Panel1Collapsed = True
        End If
    End Sub
    ''' <summary>
    ''' アセンブリを開く
    ''' </summary>
    ''' <param name="AssemblyFile"></param>
    ''' <remarks></remarks>
    Private Sub OpenAssemblyFile(ByVal AssemblyFile As String)
        Dim dllfile As String = AssemblyFile
        mResConvter = New ResxConvtor(dllfile)
        Dim CurrCul As CultureInfo = mResConvter.CurrentCultureInfo
        For Each item In Me.cmblaguage.Items
            Dim cul As LanguageInfo = DirectCast(item, LanguageInfo)
            If cul.LanguageCode = CurrCul.IetfLanguageTag Then
                Me.cmblaguage.SelectedItem = cul
                Exit For
            End If
        Next
        Me.mResourceView = New DataView(mResConvter.ResourceSet)
        Me.mResourceView.AllowEdit = True
        Me.mResourceView.AllowDelete = True
        Me.mResourceView.AllowNew = True
        Me.DataGridView1.DataSource = mResourceView
        Me.DataGridView1.AutoResizeColumns()
        InitOtherResourceList(mResConvter.OtherResources)
    End Sub
#End Region
#Region "エベント"
    Private Sub InitControls()
        InitLanguageList()
        Me.mListManager = New ListViewSortManager(Me.lstOtherRes)
        mOptions = New ApplicationOptions
        Dim culs() As CultureInfo = CultureInfo.GetCultures(CultureTypes.AllCultures)
        Dim Culinfo = From cul In culs Order By cul.IetfLanguageTag Select New LanguageInfo() With {.name = cul.DisplayName, .LanguageCode = cul.IetfLanguageTag}
        Me.cmblaguage.Items.Clear()
        Me.cmblaguage.ComboBox.DisplayMember = "DisplayName"
        Me.cmblaguage.ComboBox.ValueMember = "LanguageCode"
        Me.cmblaguage.ComboBox.Width = 288
        For Each cul In Culinfo
            Me.cmblaguage.Items.Add(cul)
        Next
        Me.PictureboxPreview.SizeMode = PictureBoxSizeMode.CenterImage Or PictureBoxSizeMode.AutoSize
        If Me.mResConvter IsNot Nothing Then
            Me.OpenAssemblyFile(Me.mResConvter.ResAssembly.Location)
        End If
        ChangeStatus()
    End Sub
    ''' <summary>
    ''' アセンブリ読み取り
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuOpen.Click, toolOpen.Click
        Try
            Me.OpenFileDialog1.Filter = "アセンブリファイル(*.dll;*.exe)|*.dll;*.exe"
            If Me.OpenFileDialog1.ShowDialog <> Windows.Forms.DialogResult.OK Then
                Return
            End If
            Me.mResConvter = Nothing
            Dim dllfile As String = Me.OpenFileDialog1.FileName
            OpenAssemblyFile(dllfile)
            Me.ChangeStatus()
        Catch ex As Exception
            MessageBox.Show(ex)
        End Try
    End Sub
    ''' <summary>
    ''' プログラム言語を変わる
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuLanguage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim menuItem As ToolStripMenuItem = Nothing
        If sender IsNot Nothing AndAlso TypeOf sender Is ToolStripMenuItem Then
            menuItem = DirectCast(sender, ToolStripMenuItem)
            Dim code As String = CStr(menuItem.Tag)
            Me.mOptions.CurrentUICultureCode = code
            Me.mOptions.Save()
            Dim Uimanager As WindowsUIResourceManager = ResManager.GetUIResourceManager(Me, Me.GetType())
            Uimanager.ChangeLanguage(New CultureInfo(code), False)
            InitControls()
        End If

    End Sub
    ''' <summary>
    ''' XMLからインポートする
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuImport.Click, toolImport.Click
        If Me.mResConvter Is Nothing Then
            Return
        End If
        Me.OpenFileDialog1.Filter = "XMLファイル(*.xml)|*.xml"
        If Me.OpenFileDialog1.ShowDialog <> Windows.Forms.DialogResult.OK Then
            Return
        End If
        Me.mResConvter.ImportXml(Me.OpenFileDialog1.FileName, Me.mOptions.ImportType)
        Me.mResourceView = New DataView(mResConvter.ResourceSet)
        Me.mResourceView.AllowEdit = True
        Me.mResourceView.AllowDelete = True
        Me.mResourceView.AllowNew = True
        Me.DataGridView1.DataSource = mResourceView
        Me.DataGridView1.AutoResizeColumns()
    End Sub
    ''' <summary>
    ''' リソースをビルドする
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuBuild_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBuildAll.Click, mnuBuildString.Click, toolBuildAll.Click, toolBuildString.Click
        If Me.mResConvter Is Nothing Then
            Return
        End If
        Dim IsBuildStringOnly As Boolean = False
        If sender Is toolBuildAll OrElse sender Is mnuBuildAll Then
            'すべてビルド
            IsBuildStringOnly = False
        Else
            '文字列のみビルド
            IsBuildStringOnly = True
        End If

        Dim code As String = ""
        If Me.cmblaguage.SelectedItem IsNot Nothing Then
            Dim SelectedCul As LanguageInfo = CType(Me.cmblaguage.SelectedItem, LanguageInfo)
            code = SelectedCul.LanguageCode
        End If
        Try
            Dim Culcure As CultureInfo = New CultureInfo(code)
            '署名設定
            mResConvter.IsSign = Me.mOptions.IsSign
            If Me.mOptions.IsSign = True AndAlso Me.mOptions.SignType = ApplicationOptions.SignTypes.SelectFile Then
                mResConvter.KeyFileName = Me.mOptions.KeyFilePath
            End If
            If Me.mOptions.IsBuildPathAuto = False Then
                mResConvter.BuildPath = Me.mOptions.BuildPath
            Else
                mResConvter.BuildPath = ""
            End If
            'コンバイル
            Dim isSuccess As Boolean = mResConvter.ComplierResources(Culcure, IsBuildStringOnly)
            If isSuccess Then
                MessageBox.Show(XResource.Resources.Information.BuildFinished)
            Else
                MessageBox.Show(XResource.Resources.Error.BuildFailed)
            End If
            Process.Start(mResConvter.GetBasePath(Culcure))
        Catch ex As Exception
            MessageBox.Show(ex)
        End Try
    End Sub
    ''' <summary>
    ''' XMLファイルを出力する
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuExportXml_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExportXml.Click, toolExportXml.Click
        If Me.mResConvter Is Nothing Then
            Return
        End If
        Dim code As String = ""
        If Me.cmblaguage.SelectedItem IsNot Nothing Then
            Dim SelectedCul As LanguageInfo = CType(Me.cmblaguage.SelectedItem, LanguageInfo)
            code = SelectedCul.LanguageCode
        End If
        SaveFileDialog1.DefaultExt = "xml"
        SaveFileDialog1.FilterIndex = 2
        SaveFileDialog1.FileName = Me.mResConvter.ResAssembly.GetName().Name
        If Me.SaveFileDialog1.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Dim Culcure As CultureInfo = New CultureInfo(code)
            Dim outFile As String = Me.SaveFileDialog1.FileName
            Dim ext As String = Path.GetExtension(outFile)
            Select Case ext.ToLower
                Case ".csv"
                    Me.mResConvter.ConvertToCsv(outFile, mOptions.GetCsvEncoding())
                Case ".xml"
                    Me.mResConvter.ConvertToXml(outFile)
            End Select
            Process.Start("excel", """" & outFile & """")
        End If
    End Sub
    ''' <summary>
    ''' CSVファイルで出力
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub toolExportCsv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExportCSV.Click, toolExportCsv.Click
        If Me.mResConvter Is Nothing Then
            Return
        End If
        Dim code As String = ""
        If Me.cmblaguage.SelectedItem IsNot Nothing Then
            Dim SelectedCul As LanguageInfo = CType(Me.cmblaguage.SelectedItem, LanguageInfo)
            code = SelectedCul.LanguageCode
        End If
        SaveFileDialog1.DefaultExt = "csv"
        SaveFileDialog1.FilterIndex = 1
        SaveFileDialog1.FileName = Me.mResConvter.ResAssembly.GetName().Name
        If Me.SaveFileDialog1.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Dim Culcure As CultureInfo = New CultureInfo(code)
            Dim outFile As String = Me.SaveFileDialog1.FileName
            Dim ext As String = Path.GetExtension(outFile)
            Select Case ext.ToLower
                Case ".csv"
                    Me.mResConvter.ConvertToCsv(outFile, mOptions.GetCsvEncoding())
                Case ".xml"
                    Me.mResConvter.ConvertToXml(outFile)
            End Select
            Process.Start("excel", """" & outFile & """")
        End If
    End Sub
    ''' <summary>
    ''' RESXファイルをエクスポートする
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub toolExportResx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolExportResx.Click, mnuExportResx.Click
        If Me.mResConvter Is Nothing Then
            Return
        End If
        Dim code As String = ""
        If Me.cmblaguage.SelectedItem IsNot Nothing Then
            Dim SelectedCul As LanguageInfo = CType(Me.cmblaguage.SelectedItem, LanguageInfo)
            code = SelectedCul.LanguageCode
        End If
        If Me.dlgSaveToFolder.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Dim Culcure As CultureInfo = New CultureInfo(code)
            Dim outputFolder As String = Me.dlgSaveToFolder.SelectedPath
            Me.mResConvter.ConvertToResx(outputFolder, Culcure)
            Process.Start(outputFolder)
        End If
    End Sub
    ''' <summary>
    ''' Resourcesファイルをエクスポートする
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub toolExportResource_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolExportResource.Click, mnuExportResource.Click
        If Me.mResConvter Is Nothing Then
            Return
        End If
        Dim code As String = ""
        If Me.cmblaguage.SelectedItem IsNot Nothing Then
            Dim SelectedCul As LanguageInfo = CType(Me.cmblaguage.SelectedItem, LanguageInfo)
            code = SelectedCul.LanguageCode
        End If
        If Me.dlgSaveToFolder.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Dim Culcure As CultureInfo = New CultureInfo(code)
            Dim outputFolder As String = Me.dlgSaveToFolder.SelectedPath
            Me.mResConvter.ConvertToResources(outputFolder, Culcure)
            Process.Start(outputFolder)
        End If
    End Sub
    ''' <summary>
    ''' バージョン表示
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuVersion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuVersion.Click
        Dim frmVer As New frmAbout
        frmVer.ShowDialog(Me)
    End Sub

    Private Sub frmResEditor_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragDrop
        e.Effect = DragDropEffects.All
        Dim files() As String = CType(e.Data.GetData(DataFormats.FileDrop, True), String())
        If files IsNot Nothing AndAlso files.Count > 0 Then
            Dim file As String = files(0)
            If System.IO.File.Exists(file) Then
                Select Case System.IO.Path.GetExtension(file).ToLower
                    Case ".dll", ".exe"
                        OpenAssemblyFile(file)
                        Me.ChangeStatus()
                    Case Else
                        Return
                End Select
            End If
        End If
    End Sub

    Private Sub frmResEditor_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragEnter
        e.Effect = DragDropEffects.All
    End Sub
    ''' <summary>
    ''' 初期化
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmResEditor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        InitControls()
    End Sub

    ''' <summary>
    ''' オプション設定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuOptions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuOptions.Click
        Dim frmOpt As New frmOption
        If frmOpt.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            mOptions = New ApplicationOptions
        End If
    End Sub

   ''' <summary>
    ''' 閉じる
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuClose.Click
        Me.Close()
    End Sub
    ''' <summary>
    ''' ファイル閉じる
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuCloseFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCloseFile.Click
        Me.mResConvter = Nothing
        Me.TabControl1.SelectedTab = Me.tabStringRes
        Me.DataGridView1.DataSource = Nothing
        Me.lstOtherRes.Items.Clear()
        ChangeStatus()
    End Sub
    ''' <summary>
    ''' 検索
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuSearch.Click
        If Me.mResourceView Is Nothing Then
            Return
        End If
        If mSearchForm Is Nothing Then
            mSearchForm = New frmSearch
        End If
        mSearchForm.ResourceSetView = Me.mResourceView
        mSearchForm.NameColumnName = Me.mResConvter.NameColumn
        mSearchForm.ValueColumnName = Me.mResConvter.ValueColumn
        mSearchForm.FileColumnName = Me.mResConvter.FileColumn
        If mSearchForm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            If Me.mResourceView.RowFilter <> "" Then
                Me.mnuSearchCancel.Enabled = True
            Else
                Me.mnuSearchCancel.Enabled = False
            End If
        End If
    End Sub
    ''' <summary>
    ''' 検索取り消し
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuSearchCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuSearchCancel.Click
        If Me.mResourceView Is Nothing Then
            Return
        End If
        Me.mResourceView.RowFilter = ""
        Me.mnuSearchCancel.Enabled = False
        If Me.mSearchForm IsNot Nothing Then
            Me.mSearchForm.clearSearch()
        End If
    End Sub

    ''' <summary>
    ''' リソース項目を選択する
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub lstOtherRes_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstOtherRes.SelectedIndexChanged
        If Me.lstOtherRes.SelectedItems.Count = 0 Then
            Return
        End If
        Dim selObj As ResxConvtor.IResourceObject = CType(Me.lstOtherRes.SelectedItems.Item(0).Tag, ResxConvtor.IResourceObject)
        Me.PropertyGrid1.SelectedObject = selObj
        InitPreview(selObj.objectValue)
    End Sub

    ''' <summary>
    ''' プロパティ変更
    ''' </summary>
    ''' <param name="s"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PropertyGrid1_PropertyValueChanged(ByVal s As Object, ByVal e As System.Windows.Forms.PropertyValueChangedEventArgs) Handles PropertyGrid1.PropertyValueChanged
        If Me.lstOtherRes.SelectedItems.Count > 0 Then
            Dim tag As ResxConvtor.IResourceObject = CType(Me.lstOtherRes.SelectedItems.Item(0).Tag, ResxConvtor.IResourceObject)
            Me.lstOtherRes.SelectedItems.Item(0).Text = tag.Name
            Me.lstOtherRes.SelectedItems.Item(0).SubItems.Item(1).Text = tag.ValueString
            Me.lstOtherRes.SelectedItems.Item(0).SubItems.Item(2).Text = tag.FileName
            InitPreview(tag.objectValue)
        End If
    End Sub
    ''' <summary>
    ''' 文字列タブ/その他タブの切り替え
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If Me.TabControl1.SelectedTab Is Me.tabStringRes Then
            Me.mnuAddResource.Enabled = False
            Me.mnuDelete.Enabled = False
            Me.toolAddRes.Enabled = False
            Me.toolDelete.Enabled = False
            Me.toolSpliter3.Enabled = False
            Me.mnuSearch.Enabled = True
            If Me.mResourceView.RowFilter = "" Then
                Me.mnuSearchCancel.Enabled = False
            Else
                Me.mnuSearchCancel.Enabled = True
            End If
        Else
            Me.mnuAddResource.Enabled = True
            Me.mnuDelete.Enabled = True
            Me.toolAddRes.Enabled = True
            Me.toolDelete.Enabled = True
            Me.toolSpliter3.Enabled = True
            Me.mnuSearch.Enabled = False
            Me.mnuSearchCancel.Enabled = False
        End If
    End Sub
    ''' <summary>
    ''' その他リソースを追加する
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub toolAddRes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAddRes.Click, mnuAddResource.Click
        Try
            Dim frmAdd As New frmAddRes
            frmAdd.ResourceConvertor = Me.mResConvter
            If frmAdd.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                If frmAdd.ResourceData IsNot Nothing Then
                    Me.mResConvter.OtherResources.Add(frmAdd.ResourceData)
                    Me.InitOtherResourceList(Me.mResConvter.OtherResources)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex)
        End Try
    End Sub
    ''' <summary>
    ''' その他リソースを削除する
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub toolDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolDelete.Click
        Try
            If Me.lstOtherRes.SelectedItems Is Nothing OrElse Me.lstOtherRes.SelectedItems.Count = 0 Then
                Return
            End If
            Dim ResObj As ResxConvtor.IResourceObject = CType(Me.lstOtherRes.SelectedItems.Item(0).Tag, ResxConvtor.IResourceObject)
            Me.mResConvter.OtherResources.Remove(ResObj)
            Me.lstOtherRes.Items.Remove(Me.lstOtherRes.SelectedItems.Item(0))
        Catch ex As Exception
            MessageBox.Show(ex)
        End Try

    End Sub
   
#End Region

  

End Class
