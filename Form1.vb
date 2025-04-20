Imports System.Windows

Public Class Form1
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Dim form2 As New Form2()
        form2.Show()
    End Sub

End Class