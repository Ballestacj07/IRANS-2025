Imports System.IO.Ports
Imports MySql.Data.MySqlClient

Public Class Form9
    Dim WithEvents serialPort As New SerialPort()

    ' MySQL connection details
    Private connectionString As String = "server=mysql-irans.alwaysdata.net;user id=irans;password=iransdatabase@2024;database=irans_database;"
    Dim connection As New MySqlConnection(connectionString)

    ' Initialize the serial port
    Private Sub ButtonInitialize_Click(sender As Object, e As EventArgs) Handles ButtonInitialize.Click
        Try
            serialPort.PortName = "COM3" ' Replace with your Arduino's COM port
            serialPort.BaudRate = 9600
            serialPort.Open()

            MessageBox.Show("Connection Established with Arduino!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadPhoneNumbers()
        Catch ex As Exception
            MessageBox.Show("Error initializing serial port: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Load phone numbers from the database
    Private Sub LoadPhoneNumbers()
        Try
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If

            connection.Open()
            Dim query As String = "SELECT phnumber FROM client_ds"
            Dim cmd As New MySqlCommand(query, connection)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            lstPhoneNumbers.Items.Clear()
            While reader.Read()
                lstPhoneNumbers.Items.Add(reader("phnumber").ToString())
            End While
            reader.Close()
            MessageBox.Show("Phone numbers loaded successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error loading phone numbers: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            connection.Close()
        End Try
    End Sub

    ' Send SMS through Arduino
    Private Sub btnSendSMS_Click(sender As Object, e As EventArgs) Handles btnSendSMS.Click
        If Not serialPort.IsOpen Then
            MessageBox.Show("Serial port is not open. Please initialize the connection first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If lstPhoneNumbers.SelectedItem Is Nothing Then
            MessageBox.Show("Please select a phone number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim phoneNumber As String = lstPhoneNumbers.SelectedItem.ToString()
        Dim message As String = txtMessage.Text

        If String.IsNullOrWhiteSpace(message) Then
            MessageBox.Show("Please enter a message.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Send SMS to Arduino
        Dim smsCommand As String = $"SMS:{phoneNumber},{message}{vbCrLf}"
        Try
            serialPort.Write(smsCommand)
            SaveSmsToDatabase(phoneNumber, message)
            MessageBox.Show("Message sent and saved to database!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error sending SMS: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnSendToAll_Click(sender As Object, e As EventArgs) Handles btnSendToAll.Click
        If Not serialPort.IsOpen Then
            MessageBox.Show("Serial port is not open. Please initialize the connection first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If lstPhoneNumbers.Items.Count = 0 Then
            MessageBox.Show("No phone numbers in the list to send to.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim message As String = txtMessage.Text

        If String.IsNullOrWhiteSpace(message) Then
            MessageBox.Show("Please enter a message.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Loop through all phone numbers in the list and send SMS to each one
        For Each phoneNumber As String In lstPhoneNumbers.Items
            Try
                ' Format the SMS command for each phone number
                Dim smsCommand As String = $"SMS:{phoneNumber},{message}{vbCrLf}"
                serialPort.Write(smsCommand)
                MessageBox.Show($"Message sent to {phoneNumber}", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Error sending SMS to " & phoneNumber & ": " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Next
    End Sub
    ' Save SMS to database
    Public Sub SaveSmsToDatabase(phoneNumber As String, message As String)
        Try
            If String.IsNullOrWhiteSpace(phoneNumber) OrElse String.IsNullOrWhiteSpace(message) Then
                MessageBox.Show("Phone number or message cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If

            connection.Open()
            Dim query As String = "INSERT INTO sms (phnumber, sms, timestamp) VALUES (@phnumber, @sms, NOW())"
            Dim cmd As New MySqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@phnumber", phoneNumber)
            cmd.Parameters.AddWithValue("@sms", message)
            cmd.ExecuteNonQuery()

            MessageBox.Show("SMS saved to database successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show($"Error saving SMS to database: {ex.Message}{vbCrLf}{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            connection.Close()
        End Try
    End Sub

    ' Handle Arduino responses
    Private Sub serialPort_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles serialPort.DataReceived
        Dim response As String = serialPort.ReadExisting()
        Me.Invoke(Sub()
                      MessageBox.Show("Response from Arduino: " & response, "Arduino Response", MessageBoxButtons.OK, MessageBoxIcon.Information)
                  End Sub)
    End Sub

    ' Close the serial port when the form is closing
    Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
        If serialPort.IsOpen Then serialPort.Close()
        MyBase.OnFormClosing(e)
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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Dim form6 As New Form6()
        Form5.Show()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
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
