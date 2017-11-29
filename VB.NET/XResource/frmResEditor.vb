Imports System.Reflection
Imports System.IO
Imports System.Text
Imports System.Globalization

Public Class frmResEditor
#Region "内部変数"
    Private mResConvter As ResxConvtor
    Private mOptions As ApplicationOptions
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
    Private Sub ChangeStatus()
        If Me.mResConvter IsNot Nothing Then
            Me.mnuBuild.Visible = True
            Me.mnuExport.Visible = True
            Me.mnuImport.Visible = True
            Me.toolBuild.Visible = True
            Me.toolExport.Visible = True
            Me.toolImport.Visible = True
            Me.toolSpliter1.Visible = True
            Me.toolSpliter2.Visible = True
            Me.mnuSpliter1.Visible = True
        Else
            Me.mnuBuild.Visible = False
            Me.mnuExport.Visible = False
            Me.mnuImport.Visible = False
            Me.toolBuild.Visible = False
            Me.toolExport.Visible = False
            Me.toolImport.Visible = False
            Me.toolSpliter1.Visible = False
            Me.toolSpliter2.Visible = False
            Me.mnuSpliter1.Visible = False
        End If
    End Sub
#End Region
#Region "エベント"
    Private Sub InitControls()
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
        ChangeStatus()
    End Sub
    ''' <summary>
    ''' アセンブリ読み取り
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuOpen.Click, toolOpen.Click
        Me.OpenFileDialog1.Filter = "アセンブリファイル(*.dll;*.exe)|*.dll;*.exe"
        If Me.OpenFileDialog1.ShowDialog <> Windows.Forms.DialogResult.OK Then
            Return
        End If
        Dim dllfile As String = Me.OpenFileDialog1.FileName
        mResConvter = New ResxConvtor(dllfile)
        Dim CurrCul As CultureInfo = mResConvter.CurrentCultureInfo
        For Each item In Me.cmblaguage.Items
            Dim cul As LanguageInfo = DirectCast(item, LanguageInfo)
            If cul.LanguageCode = CurrCul.IetfLanguageTag Then
                Me.cmblaguage.SelectedItem = cul
                Exit For
            End If
        Next
        Me.DataGridView1.DataSource = mResConvter.ResourceSet
        Me.DataGridView1.AutoResizeColumns()
        Me.ChangeStatus()
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
        Me.mResConvter.ImportXml(Me.OpenFileDialog1.FileName)
        Me.DataGridView1.DataSource = mResConvter.ResourceSet
        Me.DataGridView1.AutoResizeColumns()
    End Sub
    ''' <summary>
    ''' リソースをビルドする
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuBuild_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBuild.Click, toolBuild.Click
        If Me.mResConvter Is Nothing Then
            Return
        End If
        Dim code As String = ""
        If Me.cmblaguage.SelectedItem IsNot Nothing Then
            Dim SelectedCul As LanguageInfo = CType(Me.cmblaguage.SelectedItem, LanguageInfo)
            code = SelectedCul.LanguageCode
        End If
        Try
            Dim Culcure As CultureInfo = New CultureInfo(code)
            Dim isSuccess As Boolean = mResConvter.ComplierResources(Culcure)
            If isSuccess Then
                MessageBox.Show("リソースアセンブリ作成しました！")
            Else
                MessageBox.Show("リソースアセンブリ作成中に異常が発生しました！")
            End If
            Process.Start(mResConvter.GetBasePath(Culcure))
        Catch ex As Exception
            MessageBox.Show(ex.Message)
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
        SaveFileDialog1.FileName = Me.mResConvter.ResAssembly.GetName().Name
        If Me.SaveFileDialog1.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Dim Culcure As CultureInfo = New CultureInfo(code)
            Dim outFile As String = Me.SaveFileDialog1.FileName
            Dim ext As String = Path.GetExtension(outFile)
            Select Case ext.ToLower
                Case ".csv"
                    Me.mResConvter.ConvertToCsv(outFile)
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
        SaveFileDialog1.FileName = Me.mResConvter.ResAssembly.GetName().Name
        If Me.SaveFileDialog1.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Dim Culcure As CultureInfo = New CultureInfo(code)
            Dim outFile As String = Me.SaveFileDialog1.FileName
            Dim ext As String = Path.GetExtension(outFile)
            Select Case ext.ToLower
                Case ".csv"
                    Me.mResConvter.ConvertToCsv(outFile)
                Case ".xml"
                    Me.mResConvter.ConvertToXml(outFile)
            End Select
            Process.Start("excel", """" & outFile & """")
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
    
#End Region

End Class
