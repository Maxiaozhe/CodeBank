Imports ICSharpCode
Imports ICSharpCode.Core
Imports ICSharpCode.TextEditor
Imports ICSharpCode.TextEditor.Document
<CLSCompliant(False)> _
Public Class SqlEditor
    Inherits ICSharpCode.TextEditor.TextAreaControl
    'Private WithEvents painter As ICSharpCode.TextEditor.TextAreaPainter
    Private searchOffset As Integer = 0
   Private Sub SqlEditor_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp

    End Sub


    Private Sub SqlEditor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AutoClearSelection = True
        Me.EnableFolding = False
        MyBase.TextAreaPainter.ImeMode = Windows.Forms.ImeMode.Alpha
        MyBase.ImeMode = Windows.Forms.ImeMode.Alpha

    End Sub

    Public Function GetVisualPos(ByVal pt As Point) As Point
        Dim vpt As New Point(0, 0)
        vpt.Y = Me.Document.GetVisibleLine(Math.Min((Me.Document.TotalNumberOfLines - 1), Math.Max(0, CInt((CSng((pt.Y + Me.TextAreaPainter.ScreenVirtualTop)) / Me.TextAreaPainter.FontHeight)))))
        Dim segment As LineSegment = Me.Document.GetLineSegment(vpt.Y)
        vpt.X = Me.TextAreaPainter.GetVirtualPos(segment, (pt.X + Me.TextAreaPainter.ScreenVirtualLeft))
        Return vpt
    End Function

    Protected Overrides Function HandleKeyPress(ch As Char) As Boolean

        Return MyBase.HandleKeyPress(ch)
    End Function

    Protected Overrides Sub OnKeyUp(e As System.Windows.Forms.KeyEventArgs)
        MyBase.OnKeyUp(e)
    End Sub

    Public Sub FindNextWord(ByVal word As String)
        Dim buf As String = Document.GetText(0, Document.TextLength)
        searchOffset = buf.IndexOf(word, searchOffset, StringComparison.CurrentCultureIgnoreCase)
        If searchOffset = -1 Then
            searchOffset = 0
            searchOffset = buf.IndexOf(word, searchOffset, StringComparison.CurrentCultureIgnoreCase)
            If searchOffset = -1 Then
                searchOffset = 0
                Return
            End If
        End If
        Dim selection As New DefaultSelection(Document, searchOffset, word.Length)
        Me.Document.SetSelection(selection)
        Me.ScrollTo(selection.StartLine)
        searchOffset = searchOffset + word.Length
    End Sub

    Public Sub FindPrevWord(ByVal word As String)
        Dim buf As String = Document.GetText(0, Document.TextLength)
        If searchOffset = 0 Then
            searchOffset = Document.TextLength
        End If
        searchOffset = buf.LastIndexOf(word, searchOffset, StringComparison.CurrentCultureIgnoreCase)
        If searchOffset = -1 Then
            searchOffset = 0
            searchOffset = buf.LastIndexOf(word, searchOffset, StringComparison.CurrentCultureIgnoreCase)
            If searchOffset = -1 Then
                searchOffset = 0
                Return
            End If
        End If
        Dim selection As New DefaultSelection(Document, searchOffset, word.Length)
        Me.Document.SetSelection(selection)
        Me.ScrollTo(selection.StartLine)
    End Sub
End Class
