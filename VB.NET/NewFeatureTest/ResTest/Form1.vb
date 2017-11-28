Imports System.Resources
Imports System.Reflection
Imports System.Windows.Forms
Imports System.ComponentModel
Imports ResourceManager

Public Class Form1
    Private mResManager As WindowsUIResourceManager
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        mResManager = ResManager.GetUIResourceManager(Me, Me.GetType())
        mResManager.ApplyResources()
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        Dim CultureInfo As Globalization.CultureInfo = New Globalization.CultureInfo("en")
        System.Threading.Thread.CurrentThread.CurrentUICulture = CultureInfo
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        Dim CultureInfo As Globalization.CultureInfo = New Globalization.CultureInfo("ja-JP")
        System.Threading.Thread.CurrentThread.CurrentUICulture = CultureInfo
    End Sub

    Private Sub RadioButton3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton3.CheckedChanged
        Dim CultureInfo As Globalization.CultureInfo = New Globalization.CultureInfo("ZH-cn")
        System.Threading.Thread.CurrentThread.CurrentUICulture = CultureInfo
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ' Resources.MessageBox.Show(Resources.Question.VRUN.RouteCategoryDelete)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim obj As Object = Me.ComboBox1.Items
        Dim strname As String = "item"
        Dim value As String = "999"
        Dim descriptor As PropertyDescriptor = TypeDescriptor.GetProperties(obj).Find(strname, True)
        If ((descriptor IsNot Nothing AndAlso descriptor.IsReadOnly = False) AndAlso ((value Is Nothing) OrElse descriptor.PropertyType.IsInstanceOfType(value))) Then
            descriptor.SetValue(value, value)
        End If
        Dim prop As PropertyInfo = Nothing
        Dim bindingAttr As BindingFlags = BindingFlags.GetProperty Or BindingFlags.Public Or BindingFlags.Instance Or BindingFlags.IgnoreCase
        Try
            prop = obj.GetType.GetProperty(strname, bindingAttr)
            If (((Not prop Is Nothing) AndAlso prop.CanWrite) AndAlso ((value Is Nothing) OrElse prop.PropertyType.IsInstanceOfType(value))) Then
                prop.SetValue(obj, value, New Object() {0})
            End If
        Catch exception1 As AmbiguousMatchException
            Dim baseType As Type = obj.GetType
            Do

                prop = baseType.GetProperty(strname, (bindingAttr Or BindingFlags.DeclaredOnly))
                baseType = baseType.BaseType
                If ((Not prop Is Nothing) OrElse (baseType Is Nothing)) Then
                    If (((Not prop Is Nothing) AndAlso prop.CanWrite) AndAlso ((value Is Nothing) OrElse prop.PropertyType.IsInstanceOfType(value))) Then
                        prop.SetValue(obj, value, New Object() {0})
                    End If
                End If
            Loop While (Not baseType Is GetType(Object))
        End Try

    End Sub


End Class