Public Class Form3

    Private Sub ButtonLogout_Click(sender As Object, e As EventArgs)
        ' Confirm logout action
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to log out?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            ' Close the current form
            Me.Hide()

            ' Show the login form
            Dim Form2 As New Form2() ' Replace LoginForm with your actual login form name
            Form2.Show()

            ' Optionally, dispose of the current form if you don't need to go back to it
            ' Me.Dispose()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Dim form4 As New Form4()
        form4.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Dim form5 As New Form5()
        form5.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Dim form6 As New Form6()
        form6.Show()
    End Sub

    Private Sub ButtonsSent_Click(sender As Object, e As EventArgs) Handles ButtonsSent.Click
        Me.Hide()
        Dim form9 As New Form9()
        form9.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        Dim form10 As New Form10()
        form10.Show()
    End Sub

    Private Sub ButtonLogout_Click_1(sender As Object, e As EventArgs) Handles ButtonLogout.Click

        Dim result As DialogResult = MessageBox.Show("Are you sure you want to log out?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Me.Hide()
            Dim Form2 As New Form2()
            Form2.Show()
        End If

    End Sub
End Class