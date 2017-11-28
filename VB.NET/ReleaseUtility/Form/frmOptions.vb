Public Class frmOptions
    Private mOptions As OptionData = Nothing
    Public Property Options() As OptionData
        Get
            Return mOptions
        End Get
        Set(ByVal value As OptionData)
            mOptions = value
        End Set
    End Property

    Private Sub frmOptions_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.txtFileFilter.Text = mOptions.FileFilter
        Me.txtFoldFilter.Text = mOptions.FolderFilter
        If System.IO.Directory.Exists(mOptions.OutputFold) Then
            Me.txtOutput.Text = mOptions.OutputFold
        End If
        If System.IO.File.Exists(mOptions.WinrarPath) Then
            Me.txtWinrar.Text = mOptions.WinrarPath
        End If
        Me.txtPerfix.Text = mOptions.ZipFileNameSetting.Perfix
        Me.txtSuffix.Text = mOptions.ZipFileNameSetting.suffix
        If mOptions.ZipFileNameSetting.Format = "" Then
            Me.cmbFormat.Text = "‚È‚µ"
        Else
            Me.cmbFormat.Text = mOptions.ZipFileNameSetting.Format
        End If
        Me.cmbExt.Text = mOptions.ZipFileNameSetting.Ext
        Me.txtPassword.Text = My.Settings.Password
        If System.IO.Directory.Exists(mOptions.ReleaseFolder) Then
            Me.txtReleaseFolder.Text = mOptions.ReleaseFolder
        End If
        Me.txtReleasePerfix.Text = mOptions.ReleaseNameSeting.Perfix
        Me.txtReleaseSuffix.Text = mOptions.ReleaseNameSeting.suffix
        If mOptions.ReleaseNameSeting.Format = "" Then
            Me.cmbReleaseFormat.Text = "‚È‚µ"
        Else
            Me.cmbReleaseFormat.Text = mOptions.ReleaseNameSeting.Format
        End If

    End Sub


    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        mOptions.FileFilter = Me.txtFileFilter.Text
        mOptions.FolderFilter = Me.txtFoldFilter.Text
        mOptions.OutputFold = Me.txtOutput.Text
        mOptions.WinrarPath = Me.txtWinrar.Text
        Dim nameSet As New NamingSetting
        nameSet.Perfix = Me.txtPerfix.Text
        nameSet.suffix = Me.txtSuffix.Text
        If Me.cmbFormat.Text = "‚È‚µ" Then
            nameSet.Format = ""
        Else
            nameSet.Format = Me.cmbFormat.Text
        End If
        nameSet.Ext = Me.cmbExt.Text
        mOptions.ZipFileNameSetting = nameSet
        mOptions.Password = Me.txtPassword.Text
        mOptions.ReleaseFolder = Me.txtReleaseFolder.Text

        Dim releasenameSet As New NamingSetting
        releasenameSet.Perfix = Me.txtReleasePerfix.Text
        releasenameSet.suffix = Me.txtReleaseSuffix.Text
        If Me.cmbReleaseFormat.Text = "‚È‚µ" Then
            releasenameSet.Format = ""
        Else
            releasenameSet.Format = Me.cmbReleaseFormat.Text
        End If
        nameSet.Ext = ""
        mOptions.ReleaseNameSeting = releasenameSet
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        If Me.txtOutput.Text <> "" Then
            Me.FolderBrowserDialog1.SelectedPath = Me.txtOutput.Text
        End If
        If Me.FolderBrowserDialog1.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Me.txtOutput.Text = Me.FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.OpenFileDialog1.FileName = My.Settings.WinrarPath
        If Me.OpenFileDialog1.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Me.txtWinrar.Text = Me.OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub btnReleaseSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReleaseSelect.Click
        If Me.txtReleaseFolder.Text <> "" Then
            Me.FolderBrowserDialog1.SelectedPath = Me.txtReleaseFolder.Text
        End If
        If Me.FolderBrowserDialog1.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Me.txtReleaseFolder.Text = Me.FolderBrowserDialog1.SelectedPath
        End If
    End Sub
End Class