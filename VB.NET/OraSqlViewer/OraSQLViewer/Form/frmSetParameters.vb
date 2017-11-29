Imports System.Collections.Generic
Imports SQLViewer.DBAccess

Public Class frmSetParameters
    Private _DBParameters As List(Of DBParameter)


    Public Property DBParameters As List(Of DBParameter)
        Get
            Return Me._DBParameters
        End Get
        Set(value As List(Of DBParameter))
            Me._DBParameters = value
        End Set
    End Property
    Private Sub frmSetParameters_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Me.colType.DataSource = New String() {"文字", "数字", "日付"}
        Me.DataGridView1.DataSource = Me._DBParameters
    End Sub



    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancle_Click(sender As System.Object, e As System.EventArgs) Handles btnCancle.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel

        Me.Close()
    End Sub


    Private Sub DataGridView1_DataError(sender As Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError

    End Sub
End Class