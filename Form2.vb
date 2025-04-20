Imports System.Data.SqlClient
Imports System.Windows
Imports MySql.Data.MySqlClient
Public Class Form2
    Private connectionString As String = "server=mysql-irans.alwaysdata.net;user id=irans;password=iransdatabase@2024;database=irans_database;"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim username As String = UsernameTextBox.Text
        Dim password As String = PasswordTextBox.Text

        ' Check if the "Remember Me" checkbox is checked
        If Not RememberMeCheckBox.Checked Then
            MessageBox.Show("You must agree to the Terms and Conditions and acknowledge the Data Privacy Act by checking 'Terms and Conditions' before logging in.", "Reminder", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return ' Stop the login process if the checkbox is not checked
        End If

        If Authenticate(username, password) Then
            ' Display the Data Privacy message when the checkbox is checked
            MessageBox.Show("By checking 'Terms and Agreement', you agree to our Terms and Conditions and acknowledge our Data Privacy Act.", "Data Privacy Notice", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Proceed to the next form after successful authentication
            Dim form3 As New Form3()
            form3.Show()
            Hide()
        Else
            ' Display an error message if login fails
            MessageBox.Show("Invalid username or password. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Function Authenticate(username As String, password As String) As Boolean
        Dim query As String = "SELECT * FROM admin_ds WHERE username = @username AND password = @password"
        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@username", username)
                command.Parameters.AddWithValue("@password", password)
                connection.Open()
                Dim reader As MySqlDataReader = command.ExecuteReader()
                Dim userExists As Boolean = reader.HasRows
                reader.Close()

                Return userExists
            End Using
        End Using
    End Function

    Private Sub SaveUsername(username As String)
        Dim query As String = "INSERT INTO admin_ds (username) VALUES (@username)"
        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@username", username)

                connection.Open()
                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class