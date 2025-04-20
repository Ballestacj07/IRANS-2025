Imports AxAcroPDFLib
Imports System.IO
Imports System.Net

Public Class Form10
    Private Sub btnLoadPDF_Click(sender As Object, e As EventArgs) Handles btnloadpdf.Click
        Try
            ' Define the URL of the PDF file (Google Drive link in this case)
            Dim driveLink As String = "https://drive.google.com/uc?export=download&id=1o-dOEg53uIcRzHr-L2BBRVmD1TkzjdS3"
            Dim tempFilePath As String = Path.Combine(Path.GetTempPath(), "tempPDF.pdf")

            ' Download the PDF file from the provided link
            Using client As New WebClient()
                client.DownloadFile(driveLink, tempFilePath)
            End Using

            ' Check if the file was downloaded successfully
            If File.Exists(tempFilePath) Then
                ' Load the PDF into the AxAcroPDF viewer
                AxAcroPDF1.src = tempFilePath
                AxAcroPDF1.setShowToolbar(True)
                AxAcroPDF1.setView("Fit")
                AxAcroPDF1.setZoom(100)
                AxAcroPDF1.Show()
            Else
                MessageBox.Show("Failed to download the PDF file!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            ' Handle exceptions
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ButtonLogout_Click(sender As Object, e As EventArgs) Handles ButtonLogout.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to log out?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Me.Hide()
            Dim Form2 As New Form2()
            Form2.Show()
        End If
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
        form6.Show()
    End Sub

    Private Sub ButtonsSent_Click(sender As Object, e As EventArgs) Handles ButtonsSent.Click
        Me.Hide()
        Dim form9 As New Form9()
        form9.Show()
    End Sub

    Private Sub Form10_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
