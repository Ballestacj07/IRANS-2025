Imports System.Data.SqlClient
Imports System.IO
Imports MySql.Data.MySqlClient
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.Drawing.Printing
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar

Public Class Form5

    Private connectionString As String = "server=mysql-irans.alwaysdata.net;user id=irans;password=iransdatabase@2024;database=irans_database;"
    Private dt As New DataTable()

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub LoadData()
        dt.Clear()

        Using connection As New MySqlConnection(connectionString)
            connection.Open()
            Dim query As String = "SELECT id, fullname, subject, student_no, report_time, report_date, incident_report, file_path FROM inci_reports"
            Using command As New MySqlCommand(query, connection)
                Using adapter As New MySqlDataAdapter(command)
                    adapter.Fill(dt)
                End Using
            End Using
        End Using

        DataGridView1.DataSource = dt
    End Sub

    Private WithEvents ButtonGeneratePDF As Button
    Private Sub ButtonGeneratePDF_Click(sender As Object, e As EventArgs) Handles ButtonGeneratePDF.Click
        ' Create a new document
        Dim doc As New Document(PageSize.A4, 50, 50, 25, 25)
        ' Save the document to a file path
        Dim filePath As String = "C:\Reports\IncidentReport_" & DateTime.Now.ToString("yyyyMMddHHmmss") & ".pdf"

        Try
            ' Create a PdfWriter that writes the document to a file
            Dim writer As PdfWriter = PdfWriter.GetInstance(doc, New FileStream(filePath, FileMode.Create))

            ' Open the document for writing
            doc.Open()

            ' Add title
            doc.Add(New Paragraph("Incident Report"))
            doc.Add(New Paragraph("Generated on: " & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")))
            doc.Add(New iTextSharp.text.Chunk(Environment.NewLine)) ' Use fully qualified Chunk class

            ' Add table for report data
            Dim table As New PdfPTable(8) ' Assuming there are 8 columns in your data
            table.AddCell("ID")
            table.AddCell("Full Name")
            table.AddCell("Subject")
            table.AddCell("Student No")
            table.AddCell("Report Time")
            table.AddCell("Report Date")
            table.AddCell("Incident Report")
            table.AddCell("File Path")

            ' Loop through the data and add rows to the table
            For Each row As DataRow In dt.Rows
                table.AddCell(row("id").ToString())
                table.AddCell(row("fullname").ToString())
                table.AddCell(row("subject").ToString())
                table.AddCell(row("student_no").ToString())
                table.AddCell(row("report_time").ToString())
                table.AddCell(Convert.ToDateTime(row("report_date")).ToString("yyyy-MM-dd"))
                table.AddCell(row("incident_report").ToString())
                table.AddCell(row("file_path").ToString())
            Next

            ' Add the table to the document
            doc.Add(table)

            ' Close the document
            doc.Close()

            ' Notify the user that the PDF was generated successfully
            MessageBox.Show("PDF report generated successfully at: " & filePath, "PDF Generated", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            ' Handle errors
            MessageBox.Show("An error occurred while generating the PDF: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
                Dim query As String = "SELECT fullname FROM inci_reports WHERE fullname = @searchQuery"
                Using command As New MySqlCommand(query, connection)
                    command.Parameters.AddWithValue("@searchQuery", searchQuery)

                    Using reader As MySqlDataReader = command.ExecuteReader()
                        If reader.Read() Then
                            ' Display the searched result
                            TextBox5.Text = reader("fullname").ToString()
                        Else
                            MessageBox.Show("No matching records found.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("An error occurred while searching the database: " & ex.Message, "Search", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ButtonDelete_Click(sender As Object, e As EventArgs) Handles ButtonDelete.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = DataGridView1.SelectedRows(0)

            If selectedRow IsNot Nothing Then
                Dim reportId As Integer = Convert.ToInt32(selectedRow.Cells("id").Value)

                Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this report?", "Delete Report", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = DialogResult.Yes Then
                    If DeleteEvaluation(reportId) Then
                        MessageBox.Show("Report deleted successfully.", "Delete Report", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Failed to delete the report.", "Delete Report", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                    LoadData() ' Refresh the data after deletion
                End If
            End If
        Else
            MessageBox.Show("Please select a row to delete.", "Delete Reports", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Function DeleteEvaluation(reportId As Integer) As Boolean
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                Dim query As String = "DELETE FROM inci_reports WHERE id = @id"
                Using command As New MySqlCommand(query, connection)
                    command.Parameters.AddWithValue("@id", reportId)
                    command.ExecuteNonQuery()
                End Using
            End Using
            Return True ' Return true if deletion was successful
        Catch ex As Exception
            MessageBox.Show("An error occurred while deleting the report: " & ex.Message, "Delete Report", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False ' Return false if an error occurred
        End Try
    End Function

    Private Sub ButtonRead_Click(sender As Object, e As EventArgs) Handles ButtonRead.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = DataGridView1.SelectedRows(0)

            If selectedRow IsNot Nothing Then
                Dim subject As String = selectedRow.Cells("subject").Value.ToString()
                Dim fullname As String = selectedRow.Cells("fullname").Value.ToString()
                Dim student_no As String = selectedRow.Cells("student_no").Value.ToString()

                ' Handle report_date and report_time separately
                Dim report_date As Date = Convert.ToDateTime(selectedRow.Cells("report_date").Value)
                Dim report_time As TimeSpan = TimeSpan.Parse(selectedRow.Cells("report_time").Value.ToString())

                ' Combine report_date and report_time into a full DateTime if needed
                Dim report_datetime As DateTime = report_date.Add(report_time)

                Dim incident_report As String = selectedRow.Cells("incident_report").Value.ToString()
                Dim file_name As String = If(selectedRow.Cells("file_path").Value IsNot Nothing, Path.GetFileName(selectedRow.Cells("file_path").Value.ToString()), String.Empty)

                ' Create an instance of Form7 and pass the required details
                Dim form7 As New Form7()
                form7.SetReportDetails(subject, fullname, student_no, report_datetime, incident_report, file_name)
                form7.Show()
                Me.Hide()
            End If
        Else
            MessageBox.Show("Please select a row to view details.", "Select Row", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub


    Private Sub ButtonLogout_Click(sender As Object, e As EventArgs)
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to log out?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Me.Hide()
            Dim Form2 As New Form2()
            Form2.Show()
        End If
    End Sub

    Private Sub ButtonsSent_Click(sender As Object, e As EventArgs)
        Me.Hide()
        Dim Form9 As New Form9()
        Form9.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Hide()
        Dim Form3 As New Form3()
        Form3.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Dim Form4 As New Form4()
        Form4.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Dim Form6 As New Form6()
        Form6.Show()
    End Sub

    Private Sub ButtonsSent_Click_1(sender As Object, e As EventArgs) Handles ButtonsSent.Click
        Me.Hide()
        Dim Form9 As New Form9()
        Form9.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        Dim Form10 As New Form10()
        Form10.Show()
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
