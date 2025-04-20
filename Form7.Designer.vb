<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form7
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form7))
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.PictureBoxSignature = New System.Windows.Forms.PictureBox()
        Me.btnaccept = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBoxImage = New System.Windows.Forms.PictureBox()
        Me.txtIncidentReport = New System.Windows.Forms.TextBox()
        Me.txtReportTime = New System.Windows.Forms.TextBox()
        Me.txtReportDate = New System.Windows.Forms.TextBox()
        Me.txtStudentNo = New System.Windows.Forms.TextBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.txtSubject = New System.Windows.Forms.TextBox()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel4.SuspendLayout()
        Me.Panel6.SuspendLayout()
        CType(Me.PictureBoxSignature, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("Constantia", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(43, 83)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(263, 36)
        Me.Label6.TabIndex = 56
        Me.Label6.Text = "REPORT DETAILS "
        '
        'ListView1
        '
        Me.ListView1.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.ListView1.BackgroundImageTiled = True
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(33, 76)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(957, 53)
        Me.ListView1.TabIndex = 55
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Tile
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Constantia", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(82, 19)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(854, 42)
        Me.Label12.TabIndex = 54
        Me.Label12.Text = "INCIDENT REPORTS AND NOTIFICATION SYSTEM"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel4.Controls.Add(Me.Panel6)
        Me.Panel4.Controls.Add(Me.btnBack)
        Me.Panel4.Location = New System.Drawing.Point(34, 129)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(956, 569)
        Me.Panel4.TabIndex = 53
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.Panel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel6.Controls.Add(Me.PictureBoxSignature)
        Me.Panel6.Controls.Add(Me.btnaccept)
        Me.Panel6.Controls.Add(Me.Label9)
        Me.Panel6.Controls.Add(Me.Label7)
        Me.Panel6.Controls.Add(Me.Label5)
        Me.Panel6.Controls.Add(Me.Label4)
        Me.Panel6.Controls.Add(Me.Label3)
        Me.Panel6.Controls.Add(Me.Label2)
        Me.Panel6.Controls.Add(Me.Label1)
        Me.Panel6.Controls.Add(Me.PictureBoxImage)
        Me.Panel6.Controls.Add(Me.txtIncidentReport)
        Me.Panel6.Controls.Add(Me.txtReportTime)
        Me.Panel6.Controls.Add(Me.txtReportDate)
        Me.Panel6.Controls.Add(Me.txtStudentNo)
        Me.Panel6.Controls.Add(Me.txtName)
        Me.Panel6.Controls.Add(Me.txtSubject)
        Me.Panel6.Location = New System.Drawing.Point(28, 40)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(906, 507)
        Me.Panel6.TabIndex = 2
        '
        'PictureBoxSignature
        '
        Me.PictureBoxSignature.BackColor = System.Drawing.Color.White
        Me.PictureBoxSignature.Location = New System.Drawing.Point(518, 214)
        Me.PictureBoxSignature.Name = "PictureBoxSignature"
        Me.PictureBoxSignature.Size = New System.Drawing.Size(373, 230)
        Me.PictureBoxSignature.TabIndex = 85
        Me.PictureBoxSignature.TabStop = False
        '
        'btnaccept
        '
        Me.btnaccept.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnaccept.Font = New System.Drawing.Font("Constantia", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnaccept.ForeColor = System.Drawing.Color.White
        Me.btnaccept.Location = New System.Drawing.Point(651, 460)
        Me.btnaccept.Name = "btnaccept"
        Me.btnaccept.Size = New System.Drawing.Size(151, 34)
        Me.btnaccept.TabIndex = 84
        Me.btnaccept.Text = "ACCEPT"
        Me.btnaccept.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Constantia", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(149, 277)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(234, 29)
        Me.Label9.TabIndex = 83
        Me.Label9.Text = "INCIDENT DETAILS"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Constantia", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(64, 214)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(149, 23)
        Me.Label7.TabIndex = 81
        Me.Label7.Text = "REPORT TIME :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Constantia", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(62, 170)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(150, 23)
        Me.Label5.TabIndex = 80
        Me.Label5.Text = "REPORT DATE :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Constantia", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(16, 125)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(198, 23)
        Me.Label4.TabIndex = 79
        Me.Label4.Text = "STUDENT NUMBER :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Constantia", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(132, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 23)
        Me.Label3.TabIndex = 78
        Me.Label3.Text = "NAME :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Constantia", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(111, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 23)
        Me.Label2.TabIndex = 77
        Me.Label2.Text = "SUBJECT :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Constantia", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(554, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(320, 36)
        Me.Label1.TabIndex = 70
        Me.Label1.Text = "PHOTO OF INCIDENT"
        '
        'PictureBoxImage
        '
        Me.PictureBoxImage.BackColor = System.Drawing.Color.White
        Me.PictureBoxImage.Location = New System.Drawing.Point(518, 49)
        Me.PictureBoxImage.Name = "PictureBoxImage"
        Me.PictureBoxImage.Size = New System.Drawing.Size(373, 159)
        Me.PictureBoxImage.TabIndex = 76
        Me.PictureBoxImage.TabStop = False
        '
        'txtIncidentReport
        '
        Me.txtIncidentReport.Font = New System.Drawing.Font("Constantia", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIncidentReport.Location = New System.Drawing.Point(22, 310)
        Me.txtIncidentReport.Multiline = True
        Me.txtIncidentReport.Name = "txtIncidentReport"
        Me.txtIncidentReport.Size = New System.Drawing.Size(490, 157)
        Me.txtIncidentReport.TabIndex = 75
        '
        'txtReportTime
        '
        Me.txtReportTime.Font = New System.Drawing.Font("Constantia", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReportTime.Location = New System.Drawing.Point(227, 208)
        Me.txtReportTime.Multiline = True
        Me.txtReportTime.Name = "txtReportTime"
        Me.txtReportTime.Size = New System.Drawing.Size(269, 39)
        Me.txtReportTime.TabIndex = 73
        '
        'txtReportDate
        '
        Me.txtReportDate.Font = New System.Drawing.Font("Constantia", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReportDate.Location = New System.Drawing.Point(227, 164)
        Me.txtReportDate.Multiline = True
        Me.txtReportDate.Name = "txtReportDate"
        Me.txtReportDate.Size = New System.Drawing.Size(269, 36)
        Me.txtReportDate.TabIndex = 72
        '
        'txtStudentNo
        '
        Me.txtStudentNo.Font = New System.Drawing.Font("Constantia", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStudentNo.Location = New System.Drawing.Point(225, 118)
        Me.txtStudentNo.Multiline = True
        Me.txtStudentNo.Name = "txtStudentNo"
        Me.txtStudentNo.Size = New System.Drawing.Size(269, 36)
        Me.txtStudentNo.TabIndex = 71
        '
        'txtName
        '
        Me.txtName.Font = New System.Drawing.Font("Constantia", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.Location = New System.Drawing.Point(225, 73)
        Me.txtName.Multiline = True
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(269, 36)
        Me.txtName.TabIndex = 70
        '
        'txtSubject
        '
        Me.txtSubject.Font = New System.Drawing.Font("Constantia", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubject.Location = New System.Drawing.Point(225, 30)
        Me.txtSubject.Multiline = True
        Me.txtSubject.Name = "txtSubject"
        Me.txtSubject.Size = New System.Drawing.Size(269, 36)
        Me.txtSubject.TabIndex = 69
        '
        'btnBack
        '
        Me.btnBack.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnBack.Font = New System.Drawing.Font("Constantia", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBack.ForeColor = System.Drawing.Color.White
        Me.btnBack.Location = New System.Drawing.Point(859, 8)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(75, 26)
        Me.btnBack.TabIndex = 57
        Me.btnBack.Text = "BACK"
        Me.btnBack.UseVisualStyleBackColor = False
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CalendarFont = New System.Drawing.Font("Constantia", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Location = New System.Drawing.Point(777, 94)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePicker1.TabIndex = 69
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Constantia", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(457, 712)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(105, 19)
        Me.Label11.TabIndex = 83
        Me.Label11.Text = "IRANS@2024"
        '
        'Form7
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1029, 741)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Panel4)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form7"
        Me.Text = " REPORT DETAILS"
        Me.Panel4.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        CType(Me.PictureBoxSignature, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label6 As Label
    Friend WithEvents ListView1 As ListView
    Friend WithEvents Label12 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents PictureBoxImage As PictureBox
    Friend WithEvents txtIncidentReport As TextBox
    Friend WithEvents txtReportTime As TextBox
    Friend WithEvents txtReportDate As TextBox
    Friend WithEvents txtStudentNo As TextBox
    Friend WithEvents txtName As TextBox
    Friend WithEvents txtSubject As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnBack As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnaccept As Button
    Friend WithEvents Label11 As Label
    Friend WithEvents PictureBoxSignature As PictureBox
End Class
