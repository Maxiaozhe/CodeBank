<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOption
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使用して変更できます。  
    'コード エディタを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOption))
        Me.chkSign = New System.Windows.Forms.CheckBox
        Me.grpBuild = New System.Windows.Forms.GroupBox
        Me.pnlSign = New System.Windows.Forms.Panel
        Me.btnKeyFile = New System.Windows.Forms.Button
        Me.txtKeyFile = New System.Windows.Forms.TextBox
        Me.rdbKeyFile = New System.Windows.Forms.RadioButton
        Me.rdbAutoSign = New System.Windows.Forms.RadioButton
        Me.btnBuildPath = New System.Windows.Forms.Button
        Me.chkOpenDllFolder = New System.Windows.Forms.CheckBox
        Me.txtBuildPath = New System.Windows.Forms.TextBox
        Me.rdbBuildPath = New System.Windows.Forms.RadioButton
        Me.rdbAutoBuild = New System.Windows.Forms.RadioButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.dlgSnkFile = New System.Windows.Forms.OpenFileDialog
        Me.grpExport = New System.Windows.Forms.GroupBox
        Me.cmbEndcode = New System.Windows.Forms.ComboBox
        Me.lblCsvEncode = New System.Windows.Forms.Label
        Me.chkOpenFile = New System.Windows.Forms.CheckBox
        Me.grpImport = New System.Windows.Forms.GroupBox
        Me.rdbMergeNotPreserve = New System.Windows.Forms.RadioButton
        Me.rdbMargePreserve = New System.Windows.Forms.RadioButton
        Me.rdbReplaceAll = New System.Windows.Forms.RadioButton
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.dlgFolder = New System.Windows.Forms.FolderBrowserDialog
        Me.grpBuild.SuspendLayout()
        Me.pnlSign.SuspendLayout()
        Me.grpExport.SuspendLayout()
        Me.grpImport.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkSign
        '
        resources.ApplyResources(Me.chkSign, "chkSign")
        Me.chkSign.Name = "chkSign"
        Me.chkSign.UseVisualStyleBackColor = True
        '
        'grpBuild
        '
        Me.grpBuild.Controls.Add(Me.pnlSign)
        Me.grpBuild.Controls.Add(Me.btnBuildPath)
        Me.grpBuild.Controls.Add(Me.chkOpenDllFolder)
        Me.grpBuild.Controls.Add(Me.txtBuildPath)
        Me.grpBuild.Controls.Add(Me.rdbBuildPath)
        Me.grpBuild.Controls.Add(Me.rdbAutoBuild)
        Me.grpBuild.Controls.Add(Me.Label1)
        Me.grpBuild.Controls.Add(Me.chkSign)
        Me.grpBuild.FlatStyle = System.Windows.Forms.FlatStyle.System
        resources.ApplyResources(Me.grpBuild, "grpBuild")
        Me.grpBuild.Name = "grpBuild"
        Me.grpBuild.TabStop = False
        '
        'pnlSign
        '
        Me.pnlSign.Controls.Add(Me.btnKeyFile)
        Me.pnlSign.Controls.Add(Me.txtKeyFile)
        Me.pnlSign.Controls.Add(Me.rdbKeyFile)
        Me.pnlSign.Controls.Add(Me.rdbAutoSign)
        resources.ApplyResources(Me.pnlSign, "pnlSign")
        Me.pnlSign.Name = "pnlSign"
        '
        'btnKeyFile
        '
        resources.ApplyResources(Me.btnKeyFile, "btnKeyFile")
        Me.btnKeyFile.Name = "btnKeyFile"
        Me.btnKeyFile.UseVisualStyleBackColor = True
        '
        'txtKeyFile
        '
        resources.ApplyResources(Me.txtKeyFile, "txtKeyFile")
        Me.txtKeyFile.Name = "txtKeyFile"
        '
        'rdbKeyFile
        '
        resources.ApplyResources(Me.rdbKeyFile, "rdbKeyFile")
        Me.rdbKeyFile.Name = "rdbKeyFile"
        Me.rdbKeyFile.TabStop = True
        Me.rdbKeyFile.UseVisualStyleBackColor = True
        '
        'rdbAutoSign
        '
        resources.ApplyResources(Me.rdbAutoSign, "rdbAutoSign")
        Me.rdbAutoSign.Name = "rdbAutoSign"
        Me.rdbAutoSign.TabStop = True
        Me.rdbAutoSign.UseVisualStyleBackColor = True
        '
        'btnBuildPath
        '
        Me.btnBuildPath.ForeColor = System.Drawing.SystemColors.WindowText
        resources.ApplyResources(Me.btnBuildPath, "btnBuildPath")
        Me.btnBuildPath.Name = "btnBuildPath"
        Me.btnBuildPath.UseVisualStyleBackColor = True
        '
        'chkOpenDllFolder
        '
        resources.ApplyResources(Me.chkOpenDllFolder, "chkOpenDllFolder")
        Me.chkOpenDllFolder.ForeColor = System.Drawing.SystemColors.WindowText
        Me.chkOpenDllFolder.Name = "chkOpenDllFolder"
        Me.chkOpenDllFolder.UseVisualStyleBackColor = True
        '
        'txtBuildPath
        '
        resources.ApplyResources(Me.txtBuildPath, "txtBuildPath")
        Me.txtBuildPath.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtBuildPath.Name = "txtBuildPath"
        '
        'rdbBuildPath
        '
        resources.ApplyResources(Me.rdbBuildPath, "rdbBuildPath")
        Me.rdbBuildPath.ForeColor = System.Drawing.SystemColors.WindowText
        Me.rdbBuildPath.Name = "rdbBuildPath"
        Me.rdbBuildPath.TabStop = True
        Me.rdbBuildPath.UseVisualStyleBackColor = True
        '
        'rdbAutoBuild
        '
        resources.ApplyResources(Me.rdbAutoBuild, "rdbAutoBuild")
        Me.rdbAutoBuild.ForeColor = System.Drawing.SystemColors.WindowText
        Me.rdbAutoBuild.Name = "rdbAutoBuild"
        Me.rdbAutoBuild.TabStop = True
        Me.rdbAutoBuild.UseVisualStyleBackColor = True
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'dlgSnkFile
        '
        resources.ApplyResources(Me.dlgSnkFile, "dlgSnkFile")
        '
        'grpExport
        '
        Me.grpExport.Controls.Add(Me.cmbEndcode)
        Me.grpExport.Controls.Add(Me.lblCsvEncode)
        Me.grpExport.Controls.Add(Me.chkOpenFile)
        Me.grpExport.FlatStyle = System.Windows.Forms.FlatStyle.System
        resources.ApplyResources(Me.grpExport, "grpExport")
        Me.grpExport.Name = "grpExport"
        Me.grpExport.TabStop = False
        '
        'cmbEndcode
        '
        Me.cmbEndcode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cmbEndcode, "cmbEndcode")
        Me.cmbEndcode.FormattingEnabled = True
        Me.cmbEndcode.Items.AddRange(New Object() {resources.GetString("cmbEndcode.Items"), resources.GetString("cmbEndcode.Items1")})
        Me.cmbEndcode.Name = "cmbEndcode"
        '
        'lblCsvEncode
        '
        resources.ApplyResources(Me.lblCsvEncode, "lblCsvEncode")
        Me.lblCsvEncode.Name = "lblCsvEncode"
        '
        'chkOpenFile
        '
        resources.ApplyResources(Me.chkOpenFile, "chkOpenFile")
        Me.chkOpenFile.ForeColor = System.Drawing.SystemColors.WindowText
        Me.chkOpenFile.Name = "chkOpenFile"
        Me.chkOpenFile.UseVisualStyleBackColor = True
        '
        'grpImport
        '
        Me.grpImport.Controls.Add(Me.rdbMergeNotPreserve)
        Me.grpImport.Controls.Add(Me.rdbMargePreserve)
        Me.grpImport.Controls.Add(Me.rdbReplaceAll)
        Me.grpImport.FlatStyle = System.Windows.Forms.FlatStyle.System
        resources.ApplyResources(Me.grpImport, "grpImport")
        Me.grpImport.Name = "grpImport"
        Me.grpImport.TabStop = False
        '
        'rdbMergeNotPreserve
        '
        resources.ApplyResources(Me.rdbMergeNotPreserve, "rdbMergeNotPreserve")
        Me.rdbMergeNotPreserve.Name = "rdbMergeNotPreserve"
        Me.rdbMergeNotPreserve.TabStop = True
        Me.rdbMergeNotPreserve.UseVisualStyleBackColor = True
        '
        'rdbMargePreserve
        '
        resources.ApplyResources(Me.rdbMargePreserve, "rdbMargePreserve")
        Me.rdbMargePreserve.Name = "rdbMargePreserve"
        Me.rdbMargePreserve.TabStop = True
        Me.rdbMargePreserve.UseVisualStyleBackColor = True
        '
        'rdbReplaceAll
        '
        resources.ApplyResources(Me.rdbReplaceAll, "rdbReplaceAll")
        Me.rdbReplaceAll.Name = "rdbReplaceAll"
        Me.rdbReplaceAll.TabStop = True
        Me.rdbReplaceAll.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        resources.ApplyResources(Me.btnOK, "btnOK")
        Me.btnOK.Name = "btnOK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        resources.ApplyResources(Me.btnCancel, "btnCancel")
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'dlgFolder
        '
        resources.ApplyResources(Me.dlgFolder, "dlgFolder")
        '
        'frmOption
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.grpImport)
        Me.Controls.Add(Me.grpExport)
        Me.Controls.Add(Me.grpBuild)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOption"
        Me.grpBuild.ResumeLayout(False)
        Me.grpBuild.PerformLayout()
        Me.pnlSign.ResumeLayout(False)
        Me.pnlSign.PerformLayout()
        Me.grpExport.ResumeLayout(False)
        Me.grpExport.PerformLayout()
        Me.grpImport.ResumeLayout(False)
        Me.grpImport.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents chkSign As System.Windows.Forms.CheckBox
    Friend WithEvents grpBuild As System.Windows.Forms.GroupBox
    Friend WithEvents rdbAutoSign As System.Windows.Forms.RadioButton
    Friend WithEvents rdbKeyFile As System.Windows.Forms.RadioButton
    Friend WithEvents btnKeyFile As System.Windows.Forms.Button
    Friend WithEvents txtKeyFile As System.Windows.Forms.TextBox
    Friend WithEvents dlgSnkFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents grpExport As System.Windows.Forms.GroupBox
    Friend WithEvents rdbAutoBuild As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkOpenDllFolder As System.Windows.Forms.CheckBox
    Friend WithEvents btnBuildPath As System.Windows.Forms.Button
    Friend WithEvents txtBuildPath As System.Windows.Forms.TextBox
    Friend WithEvents rdbBuildPath As System.Windows.Forms.RadioButton
    Friend WithEvents chkOpenFile As System.Windows.Forms.CheckBox
    Friend WithEvents cmbEndcode As System.Windows.Forms.ComboBox
    Friend WithEvents lblCsvEncode As System.Windows.Forms.Label
    Friend WithEvents grpImport As System.Windows.Forms.GroupBox
    Friend WithEvents rdbReplaceAll As System.Windows.Forms.RadioButton
    Friend WithEvents rdbMergeNotPreserve As System.Windows.Forms.RadioButton
    Friend WithEvents rdbMargePreserve As System.Windows.Forms.RadioButton
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents pnlSign As System.Windows.Forms.Panel
    Friend WithEvents dlgFolder As System.Windows.Forms.FolderBrowserDialog
End Class
