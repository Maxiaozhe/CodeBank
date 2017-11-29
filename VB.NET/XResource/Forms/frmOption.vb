Imports XResource.Resources
Imports XResource.ResxConvtor

Public Class frmOption
    Dim mOptions As ApplicationOptions

    Private Sub frmOption_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        InitControls()
    End Sub

    Private Sub InitControls()
        mOptions = New ApplicationOptions
        '署名
        Me.chkSign.Checked = mOptions.IsSign
        Me.chkOpenDllFolder.Checked = mOptions.IsOpenDllFolder
        Select Case mOptions.SignType
            Case ApplicationOptions.SignTypes.Auto
                Me.rdbAutoSign.Checked = True
            Case ApplicationOptions.SignTypes.SelectFile
                Me.rdbKeyFile.Checked = True
        End Select
        If Me.rdbAutoSign.Checked = False Then
            Me.txtKeyFile.Text = mOptions.KeyFilePath
        End If
        'ビルド
        If mOptions.IsBuildPathAuto Then
            Me.rdbAutoBuild.Checked = True
        Else
            Me.rdbBuildPath.Checked = True
        End If
        If mOptions.IsBuildPathAuto = False Then
            Me.txtBuildPath.Text = mOptions.BuildPath
        End If
        'Encode
        Dim index As Integer = Me.cmbEndcode.Items.IndexOf(mOptions.CsvEncode)
        Me.cmbEndcode.SelectedIndex = index
        Me.chkOpenFile.Checked = mOptions.IsOpenExportFile
        'Import
        Select Case mOptions.ImportType
            Case ImportTypes.ReplaceAll
                Me.rdbReplaceAll.Checked = True
            Case ImportTypes.MargePreserve
                Me.rdbMargePreserve.Checked = True
            Case ImportTypes.MargeNotPreserve
                Me.rdbMergeNotPreserve.Checked = True
        End Select
        SetStatus()
    End Sub

    Private Function CheckInput() As Boolean
        If Me.chkSign.Checked = True AndAlso rdbKeyFile.Checked = True Then
            If Me.txtKeyFile.Text = "" Then
                MessageBox.Show(Exclamation.NotKeyFile)
                Return False
            End If
            If System.IO.File.Exists(Me.txtKeyFile.Text) = False Then
                MessageBox.Show(Exclamation.NotExistsKeyFile)
                Return False
            End If
        End If
        If rdbBuildPath.Checked = True Then
            If Me.txtBuildPath.Text = "" Then
                MessageBox.Show(Exclamation.NotBuildPath)
                Return False
            End If
            If System.IO.Directory.Exists(Me.txtBuildPath.Text) = False Then
                MessageBox.Show(Exclamation.NotExistsBuildPath)
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub SaveOptions()
        mOptions.IsSign = Me.chkSign.Checked
        mOptions.IsOpenDllFolder = Me.chkOpenDllFolder.Checked
        If Me.rdbAutoSign.Checked Then
            mOptions.SignType = ApplicationOptions.SignTypes.Auto
        Else
            mOptions.SignType = ApplicationOptions.SignTypes.SelectFile
        End If
        If Me.rdbAutoSign.Checked = False Then
            mOptions.KeyFilePath = Me.txtKeyFile.Text
        Else
            mOptions.KeyFilePath = ""
        End If
        'ビルド
        mOptions.IsBuildPathAuto = Me.rdbAutoBuild.Checked
        If Me.rdbAutoBuild.Checked = False Then
            mOptions.BuildPath = Me.txtBuildPath.Text
        Else
            mOptions.BuildPath = ""
        End If
        'Encode
        mOptions.CsvEncode = CStr(Me.cmbEndcode.SelectedItem)
        mOptions.IsOpenExportFile = Me.chkOpenFile.Checked
        'Import
        If Me.rdbReplaceAll.Checked = True Then
            mOptions.ImportType = ImportTypes.ReplaceAll
        ElseIf Me.rdbMargePreserve.Checked = True Then
            mOptions.ImportType = ImportTypes.MargePreserve
        ElseIf Me.rdbMergeNotPreserve.Checked = True Then
            mOptions.ImportType = ImportTypes.MargeNotPreserve
        End If
        mOptions.Save()
    End Sub

    Private Sub SetStatus()
        If Me.chkSign.Checked Then
            Me.pnlSign.Enabled = True
            If Me.rdbAutoSign.Checked Then
                Me.txtKeyFile.Enabled = False
                Me.btnKeyFile.Enabled = False
            Else
                Me.txtKeyFile.Enabled = True
                Me.btnKeyFile.Enabled = True
            End If
        Else
            Me.pnlSign.Enabled = False
        End If
        Me.txtBuildPath.Enabled = Not rdbAutoBuild.Checked
        Me.btnBuildPath.Enabled = Not rdbAutoBuild.Checked
    End Sub

    Private Sub chkSign_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkSign.CheckedChanged
        SetStatus()
    End Sub

    Private Sub SignTypeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbAutoSign.CheckedChanged, rdbKeyFile.CheckedChanged
        SetStatus()
    End Sub

    Private Sub rdbAutoBuild_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbAutoBuild.CheckedChanged, rdbBuildPath.CheckedChanged
        SetStatus()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If CheckInput() = False Then
            Return
        End If
        SaveOptions()
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnKeyFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKeyFile.Click
        Me.dlgSnkFile.FileName = Me.txtKeyFile.Text
        If Me.dlgSnkFile.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Me.txtKeyFile.Text = Me.dlgSnkFile.FileName
        End If
    End Sub

    Private Sub btnBuildPath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuildPath.Click
        Me.dlgFolder.SelectedPath = Me.txtBuildPath.Text
        If Me.dlgFolder.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Me.txtBuildPath.Text = Me.dlgFolder.SelectedPath
        End If
    End Sub
End Class