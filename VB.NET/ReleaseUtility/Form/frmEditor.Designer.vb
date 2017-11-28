<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditor
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
        Me.components = New System.ComponentModel.Container
        Me.cmbTempList = New System.Windows.Forms.ComboBox
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.btnAddFold = New System.Windows.Forms.Button
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnDeleteTemp = New System.Windows.Forms.Button
        Me.lblTemp = New System.Windows.Forms.Label
        Me.txtTempName = New System.Windows.Forms.TextBox
        Me.FileView1 = New ReleaseUtility.FileView
        Me.btnOption = New System.Windows.Forms.Button
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbTempList
        '
        Me.cmbTempList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTempList.FormattingEnabled = True
        Me.cmbTempList.Location = New System.Drawing.Point(13, 12)
        Me.cmbTempList.Name = "cmbTempList"
        Me.cmbTempList.Size = New System.Drawing.Size(231, 20)
        Me.cmbTempList.TabIndex = 1
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(451, 10)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(162, 37)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 6)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(75, 24)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(84, 6)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(75, 24)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "キャンセル"
        '
        'btnAddFold
        '
        Me.btnAddFold.Image = Global.ReleaseUtility.My.Resources.Resources.AddFolder
        Me.btnAddFold.Location = New System.Drawing.Point(13, 69)
        Me.btnAddFold.Name = "btnAddFold"
        Me.btnAddFold.Size = New System.Drawing.Size(97, 23)
        Me.btnAddFold.TabIndex = 3
        Me.btnAddFold.Text = "新規フォルダ"
        Me.btnAddFold.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAddFold.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Image = Global.ReleaseUtility.My.Resources.Resources.Delete
        Me.btnDelete.Location = New System.Drawing.Point(116, 69)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(84, 23)
        Me.btnDelete.TabIndex = 4
        Me.btnDelete.Text = "削除"
        Me.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnDeleteTemp
        '
        Me.btnDeleteTemp.Location = New System.Drawing.Point(250, 10)
        Me.btnDeleteTemp.Name = "btnDeleteTemp"
        Me.btnDeleteTemp.Size = New System.Drawing.Size(88, 23)
        Me.btnDeleteTemp.TabIndex = 5
        Me.btnDeleteTemp.Text = "削除"
        Me.btnDeleteTemp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnDeleteTemp.UseVisualStyleBackColor = True
        '
        'lblTemp
        '
        Me.lblTemp.AutoSize = True
        Me.lblTemp.Location = New System.Drawing.Point(12, 47)
        Me.lblTemp.Name = "lblTemp"
        Me.lblTemp.Size = New System.Drawing.Size(89, 12)
        Me.lblTemp.TabIndex = 7
        Me.lblTemp.Text = "テンプレート名前："
        '
        'txtTempName
        '
        Me.txtTempName.Location = New System.Drawing.Point(107, 44)
        Me.txtTempName.MaxLength = 20
        Me.txtTempName.Name = "txtTempName"
        Me.txtTempName.Size = New System.Drawing.Size(214, 19)
        Me.txtTempName.TabIndex = 6
        '
        'FileView1
        '
        Me.FileView1.AllowDrop = True
        Me.FileView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FileView1.ImageIndex = 0
        Me.FileView1.LabelEdit = True
        Me.FileView1.Location = New System.Drawing.Point(13, 98)
        Me.FileView1.Name = "FileView1"
        Me.FileView1.SelectedImageIndex = 0
        Me.FileView1.ShowNodeToolTips = True
        Me.FileView1.Size = New System.Drawing.Size(600, 394)
        Me.FileView1.TabIndex = 0
        '
        'btnOption
        '
        Me.btnOption.Location = New System.Drawing.Point(206, 69)
        Me.btnOption.Name = "btnOption"
        Me.btnOption.Size = New System.Drawing.Size(84, 23)
        Me.btnOption.TabIndex = 8
        Me.btnOption.Text = "オプション設定..."
        Me.btnOption.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnOption.UseVisualStyleBackColor = True
        '
        'frmEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(625, 504)
        Me.Controls.Add(Me.btnOption)
        Me.Controls.Add(Me.lblTemp)
        Me.Controls.Add(Me.txtTempName)
        Me.Controls.Add(Me.btnDeleteTemp)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnAddFold)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.cmbTempList)
        Me.Controls.Add(Me.FileView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEditor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "テンプレート編集"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FileView1 As ReleaseUtility.FileView
    Friend WithEvents cmbTempList As System.Windows.Forms.ComboBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents btnAddFold As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnDeleteTemp As System.Windows.Forms.Button
    Friend WithEvents lblTemp As System.Windows.Forms.Label
    Friend WithEvents txtTempName As System.Windows.Forms.TextBox
    Friend WithEvents btnOption As System.Windows.Forms.Button
End Class
