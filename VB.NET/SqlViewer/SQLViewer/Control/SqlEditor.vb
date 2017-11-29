Imports ICSharpCode
Imports ICSharpCode.Core
Imports ICSharpCode.TextEditor
Imports ICSharpCode.TextEditor.Document
<CLSCompliant(False)> _
Public Class SqlEditor

    Inherits ICSharpCode.TextEditor.TextAreaControl
    Private WithEvents painter As ICSharpCode.TextEditor.TextAreaPainter

    Private Sub SqlEditor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AutoClearSelection = True
        Me.EnableFolding = False
    End Sub

    Public Function GetVisualPos(ByVal pt As Point) As Point
        Dim vpt As New Point(0, 0)
        vpt.Y = Me.Document.GetVisibleLine(Math.Min((Me.Document.TotalNumberOfLines - 1), Math.Max(0, CInt((CSng((pt.Y + Me.TextAreaPainter.ScreenVirtualTop)) / Me.TextAreaPainter.FontHeight)))))
        Dim segment As LineSegment = Me.Document.GetLineSegment(vpt.Y)
        vpt.X = Me.TextAreaPainter.GetVirtualPos(segment, (pt.X + Me.TextAreaPainter.ScreenVirtualLeft))
        Return vpt
    End Function


End Class
