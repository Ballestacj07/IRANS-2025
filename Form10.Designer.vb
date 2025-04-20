<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form10
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form10))
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.ButtonsSent = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ButtonLogout = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnloadpdf = New System.Windows.Forms.Button()
        Me.AxAcroPDF1 = New AxAcroPDFLib.AxAcroPDF()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Panel5.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.AxAcroPDF1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.Panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel5.Controls.Add(Me.PictureBox2)
        Me.Panel5.Controls.Add(Me.Button4)
        Me.Panel5.Controls.Add(Me.ButtonsSent)
        Me.Panel5.Controls.Add(Me.Button3)
        Me.Panel5.Controls.Add(Me.Button2)
        Me.Panel5.Controls.Add(Me.Button1)
        Me.Panel5.Controls.Add(Me.ButtonLogout)
        Me.Panel5.Controls.Add(Me.Button5)
        Me.Panel5.Controls.Add(Me.Label13)
        Me.Panel5.Controls.Add(Me.Label14)
        Me.Panel5.Controls.Add(Me.Label15)
        Me.Panel5.Controls.Add(Me.Label16)
        Me.Panel5.Location = New System.Drawing.Point(1, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(244, 754)
        Me.Panel5.TabIndex = 84
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.BackgroundImage = Global.IRANS_ADMIN_2K24.My.Resources.Resources.ORIG
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.Location = New System.Drawing.Point(2, 92)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(240, 184)
        Me.PictureBox2.TabIndex = 74
        Me.PictureBox2.TabStop = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.Transparent
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Constantia", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.Black
        Me.Button4.Location = New System.Drawing.Point(24, 612)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(196, 53)
        Me.Button4.TabIndex = 73
        Me.Button4.Text = "STUDENT HANDBOOK"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'ButtonsSent
        '
        Me.ButtonsSent.BackColor = System.Drawing.Color.Transparent
        Me.ButtonsSent.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonsSent.Font = New System.Drawing.Font("Constantia", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonsSent.ForeColor = System.Drawing.Color.Black
        Me.ButtonsSent.Location = New System.Drawing.Point(24, 552)
        Me.ButtonsSent.Name = "ButtonsSent"
        Me.ButtonsSent.Size = New System.Drawing.Size(196, 53)
        Me.ButtonsSent.TabIndex = 72
        Me.ButtonsSent.Text = "SENT NOTIFICATIONS"
        Me.ButtonsSent.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Transparent
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Constantia", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.Black
        Me.Button3.Location = New System.Drawing.Point(24, 488)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(196, 53)
        Me.Button3.TabIndex = 71
        Me.Button3.Text = "CLIENT MESSAGES"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Constantia", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Black
        Me.Button2.Location = New System.Drawing.Point(24, 424)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(196, 53)
        Me.Button2.TabIndex = 70
        Me.Button2.Text = "INCIDENT REPORTS"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Constantia", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Location = New System.Drawing.Point(24, 361)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(196, 53)
        Me.Button1.TabIndex = 69
        Me.Button1.Text = "CLIENT PROFILES"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'ButtonLogout
        '
        Me.ButtonLogout.BackColor = System.Drawing.Color.LightGray
        Me.ButtonLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonLogout.Font = New System.Drawing.Font("Constantia", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonLogout.ForeColor = System.Drawing.Color.Black
        Me.ButtonLogout.Location = New System.Drawing.Point(36, 692)
        Me.ButtonLogout.Name = "ButtonLogout"
        Me.ButtonLogout.Size = New System.Drawing.Size(175, 37)
        Me.ButtonLogout.TabIndex = 68
        Me.ButtonLogout.Text = "LOGOUT"
        Me.ButtonLogout.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.Transparent
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Font = New System.Drawing.Font("Constantia", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.Color.Black
        Me.Button5.Location = New System.Drawing.Point(24, 299)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(196, 53)
        Me.Button5.TabIndex = 67
        Me.Button5.Text = "DASHBOARD"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Constantia", 33.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(43, 12)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(162, 55)
        Me.Label13.TabIndex = 66
        Me.Label13.Text = "IRANS"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(30, 64)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(180, 16)
        Me.Label14.TabIndex = 65
        Me.Label14.Text = "A D M I N I S T R A T O R"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, CType(((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic) _
                Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(35, 211)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(0, 18)
        Me.Label15.TabIndex = 64
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, CType(((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic) _
                Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(5, 211)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(0, 18)
        Me.Label16.TabIndex = 22
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.Panel1.Controls.Add(Me.btnloadpdf)
        Me.Panel1.Controls.Add(Me.AxAcroPDF1)
        Me.Panel1.Location = New System.Drawing.Point(285, 92)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(889, 617)
        Me.Panel1.TabIndex = 85
        '
        'btnloadpdf
        '
        Me.btnloadpdf.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnloadpdf.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnloadpdf.ForeColor = System.Drawing.Color.White
        Me.btnloadpdf.Location = New System.Drawing.Point(754, 6)
        Me.btnloadpdf.Name = "btnloadpdf"
        Me.btnloadpdf.Size = New System.Drawing.Size(108, 43)
        Me.btnloadpdf.TabIndex = 59
        Me.btnloadpdf.Text = "LOAD PDF"
        Me.btnloadpdf.UseVisualStyleBackColor = False
        '
        'AxAcroPDF1
        '
        Me.AxAcroPDF1.Enabled = True
        Me.AxAcroPDF1.Location = New System.Drawing.Point(20, 52)
        Me.AxAcroPDF1.Name = "AxAcroPDF1"
        Me.AxAcroPDF1.OcxState = CType(resources.GetObject("AxAcroPDF1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxAcroPDF1.Size = New System.Drawing.Size(848, 551)
        Me.AxAcroPDF1.TabIndex = 0
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Constantia", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(299, 27)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(854, 42)
        Me.Label12.TabIndex = 86
        Me.Label12.Text = "INCIDENT REPORTS AND NOTIFICATION SYSTEM"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Constantia", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(680, 722)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(105, 19)
        Me.Label11.TabIndex = 87
        Me.Label11.Text = "IRANS@2024"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Form10
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
        Me.ClientSize = New System.Drawing.Size(1200, 752)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form10"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "STUDENT HANDBOOK"
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.AxAcroPDF1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel5 As Panel
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Button4 As Button
    Friend WithEvents ButtonsSent As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents ButtonLogout As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents AxAcroPDF1 As AxAcroPDFLib.AxAcroPDF
    Friend WithEvents btnloadpdf As Button
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
End Class
