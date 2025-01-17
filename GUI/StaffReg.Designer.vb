<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StaffReg
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel22 = New System.Windows.Forms.Panel()
        Me.Panel23 = New System.Windows.Forms.Panel()
        Me.DGV = New System.Windows.Forms.DataGridView()
        Me.Panel21 = New System.Windows.Forms.Panel()
        Me.Label92 = New System.Windows.Forms.Label()
        Me.Add = New System.Windows.Forms.Button()
        Me.Button13 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Dtp = New System.Windows.Forms.DateTimePicker()
        Me.Btnpic = New System.Windows.Forms.Button()
        Me.GSM = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Nmtxt = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Age = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Sex = New System.Windows.Forms.ComboBox()
        Me.Picloc = New System.Windows.Forms.TextBox()
        Me.Pic = New System.Windows.Forms.PictureBox()
        Me.staffid = New System.Windows.Forms.TextBox()
        Me.Panel22.SuspendLayout()
        Me.Panel23.SuspendLayout()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel21.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.Pic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel22
        '
        Me.Panel22.BackColor = System.Drawing.Color.DarkGray
        Me.Panel22.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel22.Controls.Add(Me.Panel23)
        Me.Panel22.Location = New System.Drawing.Point(33, 287)
        Me.Panel22.Name = "Panel22"
        Me.Panel22.Size = New System.Drawing.Size(726, 214)
        Me.Panel22.TabIndex = 76
        '
        'Panel23
        '
        Me.Panel23.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel23.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel23.Controls.Add(Me.DGV)
        Me.Panel23.Location = New System.Drawing.Point(2, 3)
        Me.Panel23.Name = "Panel23"
        Me.Panel23.Size = New System.Drawing.Size(717, 203)
        Me.Panel23.TabIndex = 28
        '
        'DGV
        '
        Me.DGV.AllowUserToAddRows = False
        Me.DGV.AllowUserToDeleteRows = False
        Me.DGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV.Location = New System.Drawing.Point(4, 3)
        Me.DGV.Name = "DGV"
        Me.DGV.ReadOnly = True
        Me.DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGV.Size = New System.Drawing.Size(707, 194)
        Me.DGV.TabIndex = 0
        '
        'Panel21
        '
        Me.Panel21.BackColor = System.Drawing.Color.DarkGray
        Me.Panel21.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel21.Controls.Add(Me.Label92)
        Me.Panel21.Location = New System.Drawing.Point(33, 251)
        Me.Panel21.Name = "Panel21"
        Me.Panel21.Size = New System.Drawing.Size(212, 30)
        Me.Panel21.TabIndex = 75
        '
        'Label92
        '
        Me.Label92.BackColor = System.Drawing.Color.Gainsboro
        Me.Label92.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label92.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label92.Location = New System.Drawing.Point(2, 3)
        Me.Label92.Name = "Label92"
        Me.Label92.Size = New System.Drawing.Size(202, 20)
        Me.Label92.TabIndex = 29
        Me.Label92.Text = "Available Registered Staffs"
        Me.Label92.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Add
        '
        Me.Add.Location = New System.Drawing.Point(377, 45)
        Me.Add.Name = "Add"
        Me.Add.Size = New System.Drawing.Size(97, 24)
        Me.Add.TabIndex = 47
        Me.Add.Text = "Save"
        Me.Add.UseVisualStyleBackColor = True
        '
        'Button13
        '
        Me.Button13.Location = New System.Drawing.Point(480, 46)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(97, 24)
        Me.Button13.TabIndex = 50
        Me.Button13.Text = "Close"
        Me.Button13.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(251, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(274, 37)
        Me.Label1.TabIndex = 73
        Me.Label1.Text = "STAFF REGISTRATION"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DarkGray
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Location = New System.Drawing.Point(35, 68)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(724, 169)
        Me.Panel2.TabIndex = 72
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.staffid)
        Me.Panel1.Controls.Add(Me.Dtp)
        Me.Panel1.Controls.Add(Me.Add)
        Me.Panel1.Controls.Add(Me.Btnpic)
        Me.Panel1.Controls.Add(Me.Button13)
        Me.Panel1.Controls.Add(Me.GSM)
        Me.Panel1.Controls.Add(Me.Sex)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label27)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Nmtxt)
        Me.Panel1.Controls.Add(Me.Pic)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Age)
        Me.Panel1.Controls.Add(Me.Picloc)
        Me.Panel1.Location = New System.Drawing.Point(4, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(712, 158)
        Me.Panel1.TabIndex = 23
        '
        'Dtp
        '
        Me.Dtp.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp.Location = New System.Drawing.Point(480, 25)
        Me.Dtp.Name = "Dtp"
        Me.Dtp.Size = New System.Drawing.Size(113, 20)
        Me.Dtp.TabIndex = 60
        '
        'Btnpic
        '
        Me.Btnpic.Location = New System.Drawing.Point(597, 126)
        Me.Btnpic.Name = "Btnpic"
        Me.Btnpic.Size = New System.Drawing.Size(109, 23)
        Me.Btnpic.TabIndex = 59
        Me.Btnpic.Text = "Upload Photo"
        Me.Btnpic.UseVisualStyleBackColor = True
        '
        'GSM
        '
        Me.GSM.Location = New System.Drawing.Point(102, 46)
        Me.GSM.Name = "GSM"
        Me.GSM.Size = New System.Drawing.Size(260, 20)
        Me.GSM.TabIndex = 51
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(6, 46)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(96, 20)
        Me.Label27.TabIndex = 52
        Me.Label27.Text = "Mobile No."
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(480, 4)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(113, 20)
        Me.Label16.TabIndex = 30
        Me.Label16.Text = "Hire Date"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(363, 4)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(116, 20)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "Age"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Nmtxt
        '
        Me.Nmtxt.Location = New System.Drawing.Point(6, 25)
        Me.Nmtxt.Name = "Nmtxt"
        Me.Nmtxt.Size = New System.Drawing.Size(229, 20)
        Me.Nmtxt.TabIndex = 19
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 4)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(229, 20)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Staff Full Name"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Age
        '
        Me.Age.Location = New System.Drawing.Point(363, 24)
        Me.Age.Name = "Age"
        Me.Age.Size = New System.Drawing.Size(116, 20)
        Me.Age.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(236, 4)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(126, 20)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "Gender"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Sex
        '
        Me.Sex.FormattingEnabled = True
        Me.Sex.Items.AddRange(New Object() {"Male", "Female"})
        Me.Sex.Location = New System.Drawing.Point(235, 24)
        Me.Sex.Name = "Sex"
        Me.Sex.Size = New System.Drawing.Size(127, 21)
        Me.Sex.TabIndex = 7
        '
        'Picloc
        '
        Me.Picloc.Location = New System.Drawing.Point(609, 88)
        Me.Picloc.Name = "Picloc"
        Me.Picloc.Size = New System.Drawing.Size(97, 20)
        Me.Picloc.TabIndex = 62
        '
        'Pic
        '
        Me.Pic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pic.Location = New System.Drawing.Point(597, 2)
        Me.Pic.Name = "Pic"
        Me.Pic.Size = New System.Drawing.Size(109, 120)
        Me.Pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pic.TabIndex = 4
        Me.Pic.TabStop = False
        '
        'staffid
        '
        Me.staffid.Location = New System.Drawing.Point(311, 67)
        Me.staffid.Name = "staffid"
        Me.staffid.Size = New System.Drawing.Size(87, 20)
        Me.staffid.TabIndex = 68
        Me.staffid.Visible = False
        '
        'StaffReg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 528)
        Me.Controls.Add(Me.Panel22)
        Me.Controls.Add(Me.Panel21)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "StaffReg"
        Me.Text = "StaffReg"
        Me.Panel22.ResumeLayout(False)
        Me.Panel23.ResumeLayout(False)
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel21.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.Pic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel22 As System.Windows.Forms.Panel
    Friend WithEvents Panel23 As System.Windows.Forms.Panel
    Friend WithEvents DGV As System.Windows.Forms.DataGridView
    Friend WithEvents Panel21 As System.Windows.Forms.Panel
    Friend WithEvents Label92 As System.Windows.Forms.Label
    Friend WithEvents Add As System.Windows.Forms.Button
    Friend WithEvents Button13 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Dtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents Btnpic As System.Windows.Forms.Button
    Friend WithEvents GSM As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Nmtxt As System.Windows.Forms.TextBox
    Friend WithEvents Pic As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Age As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Sex As System.Windows.Forms.ComboBox
    Friend WithEvents Picloc As System.Windows.Forms.TextBox
    Friend WithEvents staffid As System.Windows.Forms.TextBox
End Class
