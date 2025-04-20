Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient
Public Class Form4

    Private connectionString As String = "server=mysql-irans.alwaysdata.net;user id=irans;password=iransdatabase@2024;database=irans_database;"
    Private dt As New DataTable()

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub LoadData()
        dt.Clear()

        Using connection As New MySqlConnection(connectionString)
            connection.Open()

            Dim query As String = "SELECT * FROM client_ds"
            Using command As New MySqlCommand(query, connection)
                Using adapter As New MySqlDataAdapter(command)
                    adapter.Fill(dt)
                End Using
            End Using
        End Using

        DataGridView1.DataSource = dt
    End Sub

    Private Sub ButtonSearch_Click(sender As Object, e As EventArgs) Handles ButtonSearch.Click
        Dim searchQuery As String = TextBox5.Text.Trim()

        If String.IsNullOrEmpty(searchQuery) Then
            MessageBox.Show("Please enter a search query.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                Dim query As String = "SELECT fullname, student_no, email, password FROM client_ds WHERE fullname = @searchQuery"
                Using command As New MySqlCommand(query, connection)
                    command.Parameters.AddWithValue("@searchQuery", searchQuery)

                    Using reader As MySqlDataReader = command.ExecuteReader()
                        If reader.Read() Then
                            TextBox4.Text = reader("fullname").ToString()
                            TextBox1.Text = reader("student_no").ToString()
                            TextBox2.Text = reader("email").ToString()
                            TextBox3.Text = reader("password").ToString()
                            TextBox6.Text = reader("phnumber").ToString()

                        Else
                            MessageBox.Show("No matching records found.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("An error occurred while searching the database.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub ButtonCreate_Click(sender As Object, e As EventArgs) Handles ButtonCreate.Click
        Dim connectionString As String = "server=mysql-irans.alwaysdata.net;user id=irans;password=iransdatabase@2024;database=irans_database;"

        Dim fullname As String = TextBox4.Text
        Dim student_no As String = TextBox1.Text
        Dim email As String = TextBox2.Text
        Dim password As String = TextBox3.Text
        Dim phnumber As String = TextBox6.Text

        Dim query As String = "INSERT INTO client_ds (fullname, student_no, email, password, phnumber) VALUES (@fullname, @student_no, @email, @password, @phnumber)"

        Using conn As New MySqlConnection(connectionString)
            Try
                conn.Open()

                Using cmd As New MySqlCommand(query, conn)
                    ' Add parameters to avoid SQL injection
                    cmd.Parameters.AddWithValue("@fullname", fullname)
                    cmd.Parameters.AddWithValue("@student_no", student_no)
                    cmd.Parameters.AddWithValue("@email", email)
                    cmd.Parameters.AddWithValue("@password", password)
                    cmd.Parameters.AddWithValue("@phnumber", phnumber)

                    ' Execute the command
                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                    ' Check if the insert was successful
                    If rowsAffected > 0 Then
                        MessageBox.Show("Data created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Error creating data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End Using
            Catch ex As MySqlException
                MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                conn.Close()
            End Try
        End Using
    End Sub

    Private Sub ButtonDelete_Click(sender As Object, e As EventArgs) Handles ButtonDelete.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = DataGridView1.SelectedRows(0)

            ' Use the correct variable "fullname" instead of "Name" for displaying the message
            Dim fullname As String = selectedRow.Cells("fullname").Value.ToString()

            Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete the client profile by '" & fullname & "'?", "Delete Evaluation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                DeleteEvaluation(fullname)
                LoadData()
            End If
        Else
            MessageBox.Show("Please select a row to delete.", "Delete Client Profile", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub DeleteEvaluation(fullname As String)
        Using connection As New MySqlConnection(connectionString)
            Try
                connection.Open()

                Dim query As String = "DELETE FROM client_ds WHERE fullname = @fullname"
                Using command As New MySqlCommand(query, connection)
                    command.Parameters.AddWithValue("@fullname", fullname)

                    command.ExecuteNonQuery()
                    MessageBox.Show("Record deleted successfully.", "Delete Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using
            Catch ex As MySqlException
                MessageBox.Show("An error occurred: " & ex.Message, "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub ButtonRead_Click(sender As Object, e As EventArgs) Handles ButtonRead.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = DataGridView1.SelectedRows(0)

            If selectedRow IsNot Nothing Then
                Dim email As String = selectedRow.Cells("email").Value.ToString()
                Dim fullname As String = selectedRow.Cells("fullname").Value.ToString()
                Dim student_no As String = selectedRow.Cells("student_no").Value.ToString()
                Dim password As String = selectedRow.Cells("password").Value.ToString()
                Dim phnumber As String = selectedRow.Cells("phnumber").Value.ToString()
                Dim profile_photo As String = If(selectedRow.Cells("profile_photo").Value IsNot Nothing, selectedRow.Cells("profile_photo").Value.ToString(), String.Empty)

                Dim form8 As New Form8()
                form8.SetReportDetails(email, fullname, student_no, password, profile_photo, phnumber)
                form8.Show()
                Me.Hide()
            End If
        Else
            MessageBox.Show("Please select a row to view details.", "Select Row", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ButtonUpdate_Click(sender As Object, e As EventArgs) Handles ButtonUpdate.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = DataGridView1.SelectedRows(0)

            ' Collect new values from textboxes or controls where the user has edited data
            Dim fullname As String = TextBox4.Text
            Dim student_no As String = TextBox1.Text
            Dim email As String = TextBox2.Text
            Dim password As String = TextBox3.Text
            Dim phnumber As String = TextBox6.Text

            ' Confirm if changes were made and the user wants to proceed
            Dim confirmUpdate As DialogResult = MessageBox.Show("Are you sure you want to update this record?", "Update Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If confirmUpdate = DialogResult.Yes Then
                ' Define a new MySQL connection
                Using conn As New MySqlConnection(connectionString)
                    Try
                        ' Define the update query
                        Dim query As String = "UPDATE client_ds SET fullname = @fullname, student_no = @student_no, email = @email, password = @password, phnumber = @phnumber WHERE student_no = @original_student_no"

                        ' Create a new MySQL command and add parameters
                        Using cmd As New MySqlCommand(query, conn)
                            cmd.Parameters.AddWithValue("@fullname", fullname)
                            cmd.Parameters.AddWithValue("@student_no", student_no)
                            cmd.Parameters.AddWithValue("@email", email)
                            cmd.Parameters.AddWithValue("@password", password)
                            cmd.Parameters.AddWithValue("@phnumber", phnumber)
                            cmd.Parameters.AddWithValue("@original_student_no", selectedRow.Cells("student_no").Value.ToString())

                            ' Open the connection, execute the command, and close the connection
                            conn.Open()
                            cmd.ExecuteNonQuery()
                            MessageBox.Show("Record updated successfully.", "Update Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End Using
                    Catch ex As MySqlException
                        MessageBox.Show("An error occurred: " & ex.Message, "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End Using

                ' Reload data to refresh DataGridView
                LoadData()
            End If
        Else
            MessageBox.Show("Please select a row to update.", "Update Evaluation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ButtonShow_Click(sender As Object, e As EventArgs) Handles ButtonShow.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = DataGridView1.SelectedRows(0)

            ' Populate the textboxes with the selected row's data
            TextBox4.Text = selectedRow.Cells("fullname").Value.ToString()
            TextBox1.Text = selectedRow.Cells("student_no").Value.ToString()
            TextBox2.Text = selectedRow.Cells("email").Value.ToString()
            TextBox3.Text = selectedRow.Cells("password").Value.ToString()
            TextBox6.Text = selectedRow.Cells("phnumber").Value.ToString()
        Else
            MessageBox.Show("Please select a row to show details.", "Show Details", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ButtonsSent_Click(sender As Object, e As EventArgs)
        Me.Hide()
        Dim form9 As New Form9()
        form9.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Hide()
        Dim form3 As New Form3()
        form3.Show()
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

    Private Sub ButtonsSent_Click_1(sender As Object, e As EventArgs) Handles ButtonsSent.Click
        Me.Hide()
        Dim form9 As New Form9()
        form9.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        Dim form10 As New Form10()
        form10.Show()
    End Sub

    Private Sub ButtonLogout_Click(sender As Object, e As EventArgs) Handles ButtonLogout.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to log out?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Me.Hide()
            Dim Form2 As New Form2()
            Form2.Show()
        End If
    End Sub
End Class