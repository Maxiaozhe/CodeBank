Imports XResource.ResxConvtor

Public Class frmAddRes
    Private mResConvtor As ResxConvtor
    Private mReturnValue As ResxConvtor.IResourceObject
    Public Property ResourceConvertor() As ResxConvtor
        Get
            Return mResConvtor
        End Get
        Set(ByVal value As ResxConvtor)
            mResConvtor = value
        End Set
    End Property
    ''' <summary>
    ''' 追加された値
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ResourceData() As ResxConvtor.IResourceObject
        Get
            Return mReturnValue
        End Get
    End Property

    Private Sub InitControls()
        Me.cmbFiles.Items.Clear()
        Dim Files = mResConvtor.GetOutputResourceFiles(False)
        For Each file As String In Files
            Me.cmbFiles.Items.Add(file)
        Next
        Me.cmbFiles.SelectedIndex = 0
        Dim ObjTypes As List(Of KeyValuePair(Of Type, String)) = Me.GetObjectTypes()
        Me.cmbDataType.Items.Clear()
        Me.cmbDataType.DisplayMember = "Value"
        Me.cmbDataType.ValueMember = "Key"
        For Each objtype As KeyValuePair(Of Type, String) In ObjTypes
            Me.cmbDataType.Items.Add(objtype)
        Next
    End Sub

    Private Function GetObjectTypes() As List(Of KeyValuePair(Of Type, String))
        Dim ObjList As New List(Of KeyValuePair(Of Type, String))
        Dim Pair As KeyValuePair(Of Type, String) = Nothing
        Pair = New KeyValuePair(Of Type, String)(GetType(Int16), "整数値(16ビット)")
        ObjList.Add(Pair)
        Pair = New KeyValuePair(Of Type, String)(GetType(Int32), "整数値(32ビット)")
        ObjList.Add(Pair)
        Pair = New KeyValuePair(Of Type, String)(GetType(Boolean), "ブール値")
        ObjList.Add(Pair)
        Pair = New KeyValuePair(Of Type, String)(GetType(Font), "フォント")
        ObjList.Add(Pair)
        Pair = New KeyValuePair(Of Type, String)(GetType(Size), "サイズ(Size)")
        ObjList.Add(Pair)
        Pair = New KeyValuePair(Of Type, String)(GetType(SizeF), "サイズ(SizeF)")
        ObjList.Add(Pair)
        Pair = New KeyValuePair(Of Type, String)(GetType(Color), "色")
        ObjList.Add(Pair)
        Pair = New KeyValuePair(Of Type, String)(GetType(Point), "位置(Point)")
        ObjList.Add(Pair)
        Pair = New KeyValuePair(Of Type, String)(GetType(ImeMode), "IMEモード")
        ObjList.Add(Pair)
        Pair = New KeyValuePair(Of Type, String)(GetType(FormStartPosition), "フォーム初期位置")
        ObjList.Add(Pair)
        Pair = New KeyValuePair(Of Type, String)(GetType(Icon), "アイコン...")
        ObjList.Add(Pair)
        Pair = New KeyValuePair(Of Type, String)(GetType(Bitmap), "イメージ...")
        ObjList.Add(Pair)
        Pair = New KeyValuePair(Of Type, String)(GetType(Byte()), "ファイル...")
        ObjList.Add(Pair)
        Return ObjList
    End Function

    Private Sub frmAddRes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        InitControls()
    End Sub

    Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If Me.txtKey.Text = "" Then
            MessageBox.Show(Resources.Exclamation.NotKey)
            Return
        End If
        If Me.cmbDataType.SelectedIndex = -1 Then
            MessageBox.Show(Resources.Exclamation.NotType)
            Return
        End If
        If Me.cmbDataType.SelectedIndex = -1 Then
            MessageBox.Show(Resources.Exclamation.NotResourceFile)
            Return
        End If
        Dim name As String = Me.txtKey.Text
        Dim fileName As String = CStr(Me.cmbFiles.SelectedItem)
        If Me.mResConvtor.IsExist(name, fileName) Then
            MessageBox.Show(Resources.Exclamation.ExitsResource)
            Return
        End If
        Dim ResType As KeyValuePair(Of Type, String) = CType(Me.cmbDataType.SelectedItem, Global.System.Collections.Generic.KeyValuePair(Of Global.System.Type, String))
        Select Case ResType.Key.FullName
            Case GetType(Int32).FullName
                mReturnValue = New ResxConvtor.ResourceObject(Of Int32)(0)
            Case GetType(Int16).FullName
                mReturnValue = New ResxConvtor.ResourceObject(Of Int16)(0)
            Case GetType(Boolean).FullName
                mReturnValue = New ResxConvtor.ResourceObject(Of Boolean)(True)
            Case GetType(Font).FullName
                mReturnValue = New ResxConvtor.ResourceObject(Of Font)(New System.Drawing.Font("MS UI Gothic", 9.0!))
            Case GetType(Size).FullName
                mReturnValue = New ResxConvtor.ResourceObject(Of Size)(New System.Drawing.Size(20, 20))
            Case GetType(Color).FullName
                mReturnValue = New ResxConvtor.ResourceObject(Of Color)(Color.Transparent)
            Case GetType(Point).FullName
                mReturnValue = New ResxConvtor.ResourceObject(Of Point)(New Point(0, 0))
            Case GetType(SizeF).FullName
                mReturnValue = New ResxConvtor.ResourceObject(Of SizeF)(New SizeF(20.0!, 20.0!))
            Case GetType(ImeMode).FullName
                mReturnValue = New ResxConvtor.ResourceObject(Of ImeMode)(ImeMode.NoControl)
            Case GetType(FormStartPosition).FullName
                mReturnValue = New ResxConvtor.ResourceObject(Of FormStartPosition)(FormStartPosition.WindowsDefaultLocation)
            Case Else
                mReturnValue = GetObjectFromFile(ResType)
        End Select
        If mReturnValue Is Nothing Then
            Return
        End If
        mReturnValue.Name = name
        mReturnValue.FileName = fileName
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Function GetObjectFromFile(ByVal type As KeyValuePair(Of Type, String)) As ResxConvtor.IResourceObject
        Dim ResValue As ResxConvtor.IResourceObject = Nothing
        Select Case type.Key.FullName
            Case GetType(System.Drawing.Icon).FullName
                Me.OpenFileDialog1.Filter = "アイコンファイル(*.ico)|*.ico"
            Case GetType(Bitmap).FullName
                Me.OpenFileDialog1.Filter = "イメージファイル(*.bmp;*.jpg;*.png;*.gif)|*.bmp;*.jpg;*.png;*.gif"

            Case GetType(Byte()).FullName
                Me.OpenFileDialog1.Filter = "ファイル(*.*)|*.*"
            Case Else
                Return Nothing
        End Select
        If Me.OpenFileDialog1.ShowDialog(Me) <> Windows.Forms.DialogResult.OK Then
            Return Nothing
        End If
        Dim Filename As String = OpenFileDialog1.FileName
        If System.IO.File.Exists(Filename) = False Then
            Return Nothing
        End If
        Select Case type.Key.FullName
            Case GetType(System.Drawing.Icon).FullName
                Dim objIcon As New Icon(Filename)
                ResValue = New ResxConvtor.ResourceObject(Of Icon)(objIcon)
            Case GetType(Bitmap).FullName
                Dim objBmp As New Bitmap(Filename)
                ResValue = New ResxConvtor.ResourceObject(Of Bitmap)(objBmp)
            Case GetType(Byte()).FullName
                Dim bytes() As Byte = My.Computer.FileSystem.ReadAllBytes(Filename)
                ResValue = New ResxConvtor.ResourceObject(Of Byte())(bytes)
            Case Else
                Return Nothing
        End Select
        Return ResValue
    End Function
End Class