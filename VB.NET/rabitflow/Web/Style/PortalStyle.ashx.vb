Imports System
Imports System.Web
Imports RJ.RabitFlow
Imports RJ.RabitFlow.Engine.Portal


Public Class PortalStyle : Implements IHttpHandler

    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        Dim strID As String = context.Request.QueryString("IDCSS")
        Dim IdCss As Integer = 0
        If IsNumeric(strID) Then
            IdCss = CInt(strID)
        End If
        context.Response.ContentType = "text/css"
        Dim cssfile As String = RJ.RabitFlow.Engine.Portal.CssCreator.GetCssFile(IdCss)
        context.Response.Write(cssfile)
    End Sub

    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class