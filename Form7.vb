Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Imports System.Drawing
Imports System.IO

Public Class Form7
    Private connectionString As String = "server=mysql-irans.alwaysdata.net;port=3306;user id=irans;password=iransdatabase@2024;database=irans_database;"

    ' Display report details in the form
    Public Sub SetReportDetails(subject As String, fullname As String, student_no As String, report_date As DateTime, incident_report As String, file_name As String)
        txtSubject.Text = subject
        txtName.Text = fullname ' Correct field usage
        txtStudentNo.Text = student_no
        txtReportDate.Text = report_date.ToString("yyyy-MM-dd") ' Format the date
        txtReportTime.Text = report_date.ToString("HH:mm") ' Format the time
        txtIncidentReport.Text = incident_report

        ' Configure PictureBox
        PictureBoxImage.SizeMode = PictureBoxSizeMode.StretchImage

        ' Construct image URL
        Dim file_path_url As String = $"https://irans.alwaysdata.net/uploads/{Path.GetFileName(file_name)}"

        Try
            ' Clear any existing image to free memory
            If PictureBoxImage.Image IsNot Nothing Then
                PictureBoxImage.Image.Dispose()
                PictureBoxImage.Image = Nothing
            End If

            ' Load image asynchronously from URL
            PictureBoxImage.LoadAsync(file_path_url)
        Catch ex As Exception
            MessageBox.Show("Error loading image: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Accept the report and handle signature
    Private Sub btnAccept_Click(sender As Object, e As EventArgs) Handles btnaccept.Click
        Try
            ' Open the signature pad for admin to sign
            OpenSignaturePad()

            ' After capturing the signature, send notification to the client
            SendNotification()
        Catch ex As Exception
            MessageBox.Show("Error accepting report: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Open the signature pad
    Public Sub OpenSignaturePad()
        Dim signatureForm As New SignatureForm()
        If signatureForm.ShowDialog() = DialogResult.OK Then
            Dim signatureImage As Image = signatureForm.GetSignature()

            ' Save the signature with a unique file name
            Dim signaturePath As String = Path.Combine(Application.StartupPath, $"signature_{Guid.NewGuid()}.png")
            signatureImage.Save(signaturePath, Imaging.ImageFormat.Png)

            ' Save the signature path in the database
            SaveSignatureInDatabase(signaturePath)

            ' Display signature in the PictureBox
            PictureBoxSignature.Image = signatureImage

            MessageBox.Show("Signature saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    ' Save the signature image path in the database
    Private Sub SaveSignatureInDatabase(signaturePath As String)
        Dim studentNo As String = txtStudentNo.Text
        Dim reportId As Integer = GetReportIdByStudentNo(studentNo)

        If reportId > 0 Then
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                ' Update the report with the signature path in the 'signature' column
                Dim query As String = "UPDATE inci_reports SET signature = @signaturePath WHERE id = @reportId"
                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@signaturePath", signaturePath)
                    cmd.Parameters.AddWithValue("@reportId", reportId)

                    Try
                        cmd.ExecuteNonQuery()
                        MessageBox.Show("Signature path saved to the database.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Catch ex As Exception
                        MessageBox.Show("Error saving signature in database: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End Using
            End Using
        Else
            MessageBox.Show("Unable to find the report ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    ' Send a notification to the user
    Private Sub SendNotification()
        Dim studentNo As String = txtStudentNo.Text
        Dim reportId As Integer = GetReportIdByStudentNo(studentNo)

        If reportId > 0 Then
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

    ' Retrieve the report ID based on the student number
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

    ' Load the saved signature into PictureBoxSignature
    Private Sub LoadSavedSignature()
        Dim studentNo As String = txtStudentNo.Text
        Dim reportId As Integer = GetReportIdByStudentNo(studentNo)

        If reportId > 0 Then
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                ' Query to fetch the saved signature path
                Dim query As String = "SELECT signature FROM inci_reports WHERE id = @reportId"
                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@reportId", reportId)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Dim signaturePath As String = reader("signature").ToString()
                            If Not String.IsNullOrEmpty(signaturePath) AndAlso File.Exists(signaturePath) Then
                                ' Load the saved signature into the PictureBox
                                PictureBoxSignature.Image = Image.FromFile(signaturePath)
                            End If
                        End If
                    End Using
                End Using
            End Using
        Else
            MessageBox.Show("Unable to find the report ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    ' Navigate back to the main form
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Hide()
        Dim form5 As New Form5()
        form5.Show()
    End Sub

    ' Form load event to load saved signature
    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load the saved signature when the form is loaded
        LoadSavedSignature()
    End Sub
End Class

' Signature pad form for capturing admin's signature
Public Class SignatureForm
    Inherits Form

    Private isDrawing As Boolean = False
    Private lastPoint As Point
    Private signatureBitmap As Bitmap
    Private pictureBox As PictureBox
    Private btnSave As Button

    Public Sub New()
        Me.Text = "Sign Here"
        Me.Size = New Size(400, 300)

        ' Create PictureBox
        pictureBox = New PictureBox() With {
            .Dock = DockStyle.Fill,
            .BackColor = Color.White,
            .BorderStyle = BorderStyle.Fixed3D
        }
        AddHandler pictureBox.MouseDown, AddressOf PictureBox_MouseDown
        AddHandler pictureBox.MouseMove, AddressOf PictureBox_MouseMove
        AddHandler pictureBox.MouseUp, AddressOf PictureBox_MouseUp
        Me.Controls.Add(pictureBox)

        ' Initialize Bitmap
        signatureBitmap = New Bitmap(400, 300)
        pictureBox.Image = signatureBitmap

        ' Create Save Button
        btnSave = New Button() With {
            .Text = "Save Signature",
            .Dock = DockStyle.Bottom
        }
        AddHandler btnSave.Click, AddressOf BtnSave_Click
        Me.Controls.Add(btnSave)
    End Sub

    Private Sub PictureBox_MouseDown(sender As Object, e As MouseEventArgs)
        isDrawing = True
        lastPoint = e.Location
    End Sub

    Private Sub PictureBox_MouseMove(sender As Object, e As MouseEventArgs)
        If isDrawing Then
            Using g As Graphics = Graphics.FromImage(signatureBitmap)
                g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                g.DrawLine(Pens.Black, lastPoint, e.Location)
            End Using
            pictureBox.Invalidate()
            lastPoint = e.Location
        End If
    End Sub

    Private Sub PictureBox_MouseUp(sender As Object, e As MouseEventArgs)
        isDrawing = False
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs)
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Public Function GetSignature() As Image
        Return signatureBitmap
    End Function
End Class
