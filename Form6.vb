Imports MySql.Data.MySqlClient
Imports System.Text

Public Class Form6
    Private connectionString As String = "server=mysql-irans.alwaysdata.net;user id=irans;password=iransdatabase@2024;database=irans_database;"
    Private selectedStudentNo As String = ""
    Private adminName As String = "Admin"

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadUsers()
    End Sub

    ' Load users who have messaged the admin
    Private Sub LoadUsers()
        Using conn As New MySqlConnection(connectionString)
            conn.Open()
            Dim query As String = "SELECT DISTINCT student_no, fullname FROM messages WHERE receiver = 'admin' OR receiver IS NULL"
            Dim cmd As New MySqlCommand(query, conn)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            ComboBox.Items.Clear()
            While reader.Read()
                Dim studentNo As String = reader("student_no").ToString()
                Dim fullName As String = reader("fullname").ToString()
                ComboBox.Items.Add(fullName & " (" & studentNo & ")")
            End While
        End Using
    End Sub

    ' When a user is selected, load their messages
    Private Sub ComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox.SelectedIndexChanged
        Dim selectedText As String = ComboBox.SelectedItem.ToString()
        selectedStudentNo = selectedText.Substring(selectedText.LastIndexOf("(") + 1).TrimEnd(")"c) ' Extract student number
        LoadMessages(selectedStudentNo)
    End Sub

    ' Load the messages for the selected student
    Private Sub LoadMessages(studentNo As String)
        Using conn As New MySqlConnection(connectionString)
            conn.Open()
            Dim query As String = "SELECT student_no, fullname, amessages, receiver, created_at FROM messages WHERE student_no = @student_no OR receiver = @student_no ORDER BY id ASC"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@student_no", studentNo)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            stMessages.Clear()
            While reader.Read()
                Dim messageText As String = reader("amessages").ToString()
                Dim fullName As String = reader("fullname").ToString()
                Dim receiver As String = reader("receiver").ToString()
                Dim messageDate As String = reader("created_at").ToString()

                ' Format and display messages
                Dim messageDisplay As New StringBuilder()
                messageDisplay.Append(fullName & " (" & messageDate & "): " & Environment.NewLine)
                messageDisplay.Append(messageText & Environment.NewLine & Environment.NewLine)

                stMessages.AppendText(messageDisplay.ToString())
            End While
        End Using
    End Sub

    ' Send a reply to the selected user
    Private Sub btnSendReply_Click(sender As Object, e As EventArgs) Handles btnSendReply.Click
        If String.IsNullOrWhiteSpace(txtReply.Text) Or String.IsNullOrWhiteSpace(selectedStudentNo) Then
            MessageBox.Show("Please select a user and enter a message.")
            Return
        End If

        Dim replyMessage As String = txtReply.Text.Trim()

        Using conn As New MySqlConnection(connectionString)
            conn.Open()
            Dim query As String = "INSERT INTO messages (student_no, fullname, amessages, receiver) VALUES (@student_no, @fullname, @amessages, @receiver)"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@student_no", selectedStudentNo)
            cmd.Parameters.AddWithValue("@fullname", adminName)
            cmd.Parameters.AddWithValue("@amessages", replyMessage)
            cmd.Parameters.AddWithValue("@receiver", selectedStudentNo)

            If cmd.ExecuteNonQuery() > 0 Then
                MessageBox.Show("Reply sent successfully!")
                txtReply.Clear()
                LoadMessages(selectedStudentNo) ' Refresh the conversation after sending reply
            Else
                MessageBox.Show("Error sending reply.")
            End If
        End Using
    End Sub





    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Hide()
        Dim form3 As New Form3()
        form3.Show()
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

    Private Sub ButtonLogout_Click(sender As Object, e As EventArgs) Handles ButtonLogout.Click

        Dim result As DialogResult = MessageBox.Show("Are you sure you want to log out?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Me.Hide()
            Dim Form2 As New Form2()
            Form2.Show()
        End If

    End Sub
End Class
