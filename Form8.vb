Imports MySql.Data.MySqlClient

Public Class Form8
    Private connectionString As String = "server=mysql-irans.alwaysdata.net;user id=irans;password=iransdatabase@2024;database=irans_database;"

    ' This method receives and displays the data from the main form
    Public Sub SetReportDetails(email As String, fullname As String, student_no As String, password As String, file_name As String, phnumber As String)
        ' Set form fields
        txtemail.Text = email
        txtName.Text = fullname
        txtStudentNo.Text = student_no
        txtpassword.Text = password
        txtphnumber.Text = phnumber

        ' Set PictureBox properties
        PictureBoxImage.SizeMode = PictureBoxSizeMode.StretchImage

        ' Construct the image URL, assuming the base URL is on alwaysdata.net
        Dim profile_photo_url As String = "https://irans.alwaysdata.net/uploads/" & IO.Path.GetFileName(file_name)

        ' Debugging: Display constructed URL to verify correctness
        MessageBox.Show("Profile Photo: " & profile_photo_url)

        Try
            ' Dispose of previous image to prevent memory issues
            If PictureBoxImage.Image IsNot Nothing Then
                PictureBoxImage.Image.Dispose()
            End If

            ' Load image from URL asynchronously
            PictureBoxImage.LoadAsync(profile_photo_url)
        Catch ex As Exception
            ' Show an error message if there's an issue loading the image
            MessageBox.Show("Error loading image: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub







    ' Method to accept the report and send notification
    Private Sub btnAccept_Click(sender As Object, e As EventArgs)
        ' Get the report details
        Dim studentNo As String = txtStudentNo.Text
        Dim reportId As Integer = GetReportIdByStudentNo(studentNo) ' Get the report ID by student number

        If reportId > 0 Then
            ' Insert notification into the database
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                Dim query As String = "INSERT INTO notifications (report_id, message) VALUES (@reportId, @message)"
                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@reportId", reportId)
                    cmd.Parameters.AddWithValue("@message", "Your report has been accepted by the admin.")

                    Try
                        cmd.ExecuteNonQuery()
                        MessageBox.Show("Report accepted, notification sent to client.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Catch ex As Exception
                        MessageBox.Show("Error sending notification: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End Using
            End Using
        Else
            MessageBox.Show("Unable to find the report ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    ' Method to get the report ID by student number
    Private Function GetReportIdByStudentNo(studentNo As String) As Integer
        Dim reportId As Integer = 0

        Using connection As New MySqlConnection(connectionString)
            connection.Open()

            Dim query As String = "SELECT id FROM inci_reports WHERE student_no = @studentNo"
            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@studentNo", studentNo)

                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        reportId = Convert.ToInt32(reader("id"))
                    End If
                End Using
            End Using
        End Using

        Return reportId
    End Function

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Hide()
        Dim form4 As New Form4()
        form4.Show()
    End Sub


End Class