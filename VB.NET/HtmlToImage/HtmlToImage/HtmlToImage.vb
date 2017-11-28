Imports mshtml
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Imaging
Imports HtmlToImage.Win32

Public Class HtmlToImage
#Region "内部変数"
    Private WithEvents mWebBrower As WebBrowser
    Private mMinWidth As Integer
    Private mJpegQuality As Integer = 85
#End Region
#Region "プロパティ"
    ''' <summary>
    ''' 最小幅を設定する
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MinWidth() As Integer
        Get
            Return Me.mMinWidth
        End Get
        Set(ByVal value As Integer)
            Me.mMinWidth = value
        End Set
    End Property
    ''' <summary>
    ''' JEPGに変換するとき、画像の品質レベル（10～100）を設定する
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks>JEPG画像のみ有効</remarks>
    Public Property JpegQuality() As Integer
        Get
            Return mJpegQuality
        End Get
        Set(ByVal value As Integer)
            If value > 100 Then
                mJpegQuality = 100
            ElseIf value < 10 Then
                mJpegQuality = 10
            Else
                mJpegQuality = value
            End If
        End Set
    End Property
#End Region
#Region "メッソド"
    Public Sub New()
        mWebBrower = New WebBrowser
        mWebBrower.ScrollBarsEnabled = False
        mWebBrower.ScriptErrorsSuppressed = True

    End Sub
    ''' <summary>
    ''' URLからビットマップに変換する
    ''' </summary>
    ''' <param name="Url"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ConvertToImage(ByVal Url As String) As Bitmap
        Try
            mWebBrower.Navigate(Url)
            Do Until mWebBrower.ReadyState = WebBrowserReadyState.Complete
                Application.DoEvents()
            Loop
            Return DoConvert()
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ''' <summary>
    ''' URLからイメージファイルとして保存する
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ConvertToImage(ByVal Url As String, ByVal FileName As String)
        Try
            Dim Bmp As Bitmap = ConvertToImage(Url)
            SaveImage(Bmp, FileName)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    ''' <summary>
    ''' URLからイメージファイルとして保存する
    ''' </summary>
    ''' <remarks></remarks>
    Public Function GetThumbnailImage(ByVal Url As String, ByVal Zoom As Integer) As Bitmap
        Try
            Dim Bmp As Bitmap = ConvertToImage(Url)
            Dim Scale As Single = CSng(Zoom / 100)
            Dim Thumbnail As Image = Bmp.GetThumbnailImage(CInt(Bmp.Width * Scale), CInt(Bmp.Height * Scale), AddressOf ThumbnailCallback, System.IntPtr.Zero)
            Return CType(Thumbnail, Bitmap)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ''' <summary>
    ''' URLからイメージファイルとして保存する
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SaveThumbnail(ByVal Url As String, ByVal FileName As String, ByVal zoom As Integer)
        Try
            Dim Bmp As Bitmap = GetThumbnailImage(Url, zoom)
            SaveImage(Bmp, FileName)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub SaveImage(ByVal Bmp As Bitmap, ByVal FileName As String)
        Try
            If Bmp IsNot Nothing Then
                Dim Format As Imaging.ImageFormat = Nothing
                Dim ext As String = System.IO.Path.GetExtension(FileName)
                Select Case ext.ToLower
                    Case ".jpg", ".jpeg"
                        Format = Imaging.ImageFormat.Jpeg
                    Case ".gif"
                        Format = Imaging.ImageFormat.Gif
                    Case Else
                        Format = Imaging.ImageFormat.Bmp
                End Select
                If Format Is Imaging.ImageFormat.Jpeg Then
                    Dim encode As ImageCodecInfo = Me.GetEncoderInfo(Format)
                    Dim myEncoderParameters As New System.Drawing.Imaging.EncoderParameters(1)
                    Dim myEncoder As System.Drawing.Imaging.Encoder = System.Drawing.Imaging.Encoder.Quality
                    Dim myEncoderParameter As New System.Drawing.Imaging.EncoderParameter(myEncoder, mJpegQuality)
                    myEncoderParameters.Param(0) = myEncoderParameter
                    Bmp.Save(FileName, encode, myEncoderParameters)
                Else
                    Bmp.Save(FileName, Format)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Private Function ThumbnailCallback() As Boolean
        Return False
    End Function

    ''' <summary>
    ''' イメージ変換
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function DoConvert() As Bitmap
        Dim g As Graphics = Nothing
        Dim img As Bitmap = Nothing
        Try
            Dim Doc As IHTMLDocument2 = CType(mWebBrower.Document.DomDocument, IHTMLDocument2)
            Dim Body As IHTMLElement2 = CType(Doc.body, IHTMLElement2)

            Dim Width As Integer = Body.scrollWidth
            Dim Height As Integer = Body.scrollHeight
            If Width < Me.mMinWidth Then Width = mMinWidth
            mWebBrower.Width = Width
            mWebBrower.Height = Height
            mWebBrower.Visible = True
            Dim rect As Win32.RECT '= New Win32.RECT With {.left = 0, .top = 0, .right = Width, .bottom = Height}
            With rect
                .left = 0
                .top = 0
                .right = Width
                .bottom = Height
            End With
            img = New Bitmap(Width, Height, Imaging.PixelFormat.Format24bppRgb)
            g = Graphics.FromImage(img)
            g.Clear(Color.White)
            Dim hdc As IntPtr = g.GetHdc()
            Dim ViewObj As IViewObject = CType(Doc, IViewObject)
            ViewObj.Draw(DVASPECT.DVASPECT_CONTENT, -1, Nothing, Nothing, hdc, hdc, rect, Nothing, Nothing, 0)
            Return img
        Catch ex As Exception
            Throw ex
        Finally
            If g IsNot Nothing Then
                g.Dispose()
            End If
        End Try
    End Function

    Private Function GetEncoderInfo(ByVal ImageFormat As ImageFormat) As ImageCodecInfo
        Dim encoders As System.Drawing.Imaging.ImageCodecInfo() = ImageCodecInfo.GetImageEncoders()
        Dim info As ImageCodecInfo
        For Each info In encoders
            If ImageFormat.Guid.Equals(info.FormatID) Then
                Return info
            End If
        Next
        Return Nothing
    End Function



#End Region

 End Class
