Public Class IconCombBox
    Inherits System.Windows.Forms.ComboBox
    Private mIcon As Image = Nothing
    Public Property Icon() As Image
        Get
            Return mIcon
        End Get
        Set(ByVal Value As Image)
            mIcon = Value
        End Set
    End Property

    Private Sub IconCombBox_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles MyBase.DrawItem
        Dim g As Graphics = e.Graphics
        If e.Index = -1 Then
            Return
        End If
        Dim str As String = CStr(Me.Items.Item(e.Index))
        e.DrawBackground()
        e.DrawFocusRectangle()
        g.DrawImage(mIcon, New PointF(e.Bounds.Left, e.Bounds.Top))
        g.DrawString(str, e.Font, New SolidBrush(e.ForeColor), e.Bounds.Left + 17, e.Bounds.Top + 1)
    End Sub

End Class
