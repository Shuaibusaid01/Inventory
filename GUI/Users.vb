Imports System.Data.OleDb
Imports System.IO
Imports System.Windows.Forms

Public Class Users
    Dim cnn As New OleDb.OleDbConnection
    Dim adp As OleDb.OleDbDataAdapter
    Public ds As New DataSet()
    Dim cmd As OleDbCommand = Nothing
    Dim rdr As OleDbDataReader = Nothing
    Public myDA As New OleDbDataAdapter()
    Dim Replocation As String
    Dim cryRpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument
    Dim cs As String = "Provider=Microsoft.ACE.Oledb.12.0; Data Source=" & Application.StartupPath & "\db.accdb"
    Public CurrentRow As Integer

    Private Sub Users_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cnn = New OleDb.OleDbConnection
        cnn.ConnectionString = "Provider=Microsoft.ACE.Oledb.12.0; Data Source=" & Application.StartupPath & "\db.accdb"

        RefreshData5()
    End Sub

    Private Sub btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click
        If txtUsername.Text = "" Then
            MessageBox.Show("Please enter username", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            txtUsername.Focus()
            Return
        End If
        If txtPassword.Text = "" Then
            MessageBox.Show("Please enter password", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            txtPassword.Focus()
            Return
        End If
        If txtName.Text = "" Then
            MessageBox.Show("Please enter name", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            txtName.Focus()
            Return
        End If
        If txtContactNo.Text = "" Then
            MessageBox.Show("Please enter contact no.", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            txtContactNo.Focus()
            Return
        End If
        If txtEmailID.Text = "" Then
            MessageBox.Show("Please enter email id", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            txtEmailID.Focus()
            Return
        End If
        Try
            cnn = New OleDbConnection(cs)
            cnn.Open()
            Dim ct As String = "select username from registration where username=@find"

            cmd = New OleDbCommand(ct)
            cmd.Connection = cnn
            cmd.Parameters.Add(New OleDbParameter("@find", System.Data.OleDb.OleDbType.VarChar, 30, "username"))
            cmd.Parameters("@find").Value = txtUsername.Text
            rdr = cmd.ExecuteReader()

            If rdr.Read() Then
                MessageBox.Show("Username Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtUsername.Text = ""
                txtUsername.Focus()
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If

            cnn = New OleDbConnection(cs)
            cnn.Open()

            Dim cb As String = "insert into Registration(UserName, User_Password, NameOfuser, ContactNo, Email,JoiningDate) VALUES ('" & txtUsername.Text & "','" & txtPassword.Text & "','" & txtName.Text & "','" & txtContactNo.Text & "','" & txtEmailID.Text & "','" & dtp.Text & "')"
            cmd = New OleDbCommand(cb)
            cmd.Connection = cnn
            cmd.ExecuteReader()
            cnn.Close()
            cnn = New OleDbConnection(cs)
            cnn.Open()
            MessageBox.Show("Successfully Registered", "User", MessageBoxButtons.OK, MessageBoxIcon.Information)
            RefreshData5()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnupd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupd.Click
        Try
            If txtUsername.Text = "" Then
                MessageBox.Show("Please enter username", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtUsername.Focus()
                Return
            End If
            If txtPassword.Text = "" Then
                MessageBox.Show("Please enter password", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtPassword.Focus()
                Return
            End If
            If txtName.Text = "" Then
                MessageBox.Show("Please enter name", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtName.Focus()
                Return
            End If
            If txtContactNo.Text = "" Then
                MessageBox.Show("Please enter contact no.", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtContactNo.Focus()
                Return
            End If
            If txtEmailID.Text = "" Then
                MessageBox.Show("Please enter email id", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtEmailID.Focus()
                Return
            End If
            cnn = New OleDbConnection(cs)
            cnn.Open()
            Dim cb As String = "update registration set username='" & txtUsername.Text & "', user_password='" & txtPassword.Text & "',contactno='" & txtContactNo.Text & "',email='" & txtEmailID.Text & "',nameofuser='" & txtName.Text & "' where username='" & TextBox1.Text & "'"
            cmd = New OleDbCommand(cb)
            cmd.Connection = cnn
            cmd.ExecuteReader()
            cnn.Close()
            cnn = New OleDbConnection(cs)
            MessageBox.Show("Successfully updated", "User Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            RefreshData5()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Sub RefreshData5()
        If Not cnn.State = ConnectionState.Open Then
            'open connection
            cnn.Open()
        End If
        Dim da As New OleDb.OleDbDataAdapter("SELECT UserName, NameofUser, ContactNo, JoiningDate as [Hire Date] FROM Registration ORDER BY JoiningDate", cnn)
        Dim dt As New DataTable
        'fill data to datatable
        da.Fill(dt)
        'offer data in datatable into datagridview
        Me.DGV.DataSource = dt
        'close connection
        cnn.Close()
    End Sub

    Private Sub DGV_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGV.RowHeaderMouseClick
        Try
            Dim dr As DataGridViewRow = DGV.SelectedRows(0)
            txtUsername.Text = dr.Cells(0).Value.ToString()
            TextBox1.Text = dr.Cells(0).Value.ToString()
            txtPassword.Text = dr.Cells(2).Value.ToString()
            txtName.Text = dr.Cells(3).Value.ToString()
            txtContactNo.Text = dr.Cells(4).Value.ToString()
            txtEmailID.Text = dr.Cells(5).Value.ToString()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btndel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndel.Click
        Try
            If MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                DeleteRecord()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DeleteRecord()

        Try
            If txtUsername.Text = "admin" Or txtUsername.Text = "Admin" Then
                MessageBox.Show("Admin account can not be deleted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            Dim RowsAffected As Integer = 0
            cnn = New OleDbConnection(cs)
            cnn.Open()
            Dim cq As String = "delete from Registration where Username='" & txtUsername.Text & "'"
            cmd = New OleDbCommand(cq)
            cmd.Connection = cnn
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                RefreshData5()
                Reset()
            Else
                MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset()
            End If
            If cnn.State = ConnectionState.Open Then
                cnn.Close()

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub


    Private Sub DGV_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DGV.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If DGV.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            DGV.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

    End Sub

    Private Sub txtUsername_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUsername.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtPassword.Focus()
        End If
    End Sub

   

    Private Sub txtPassword_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtName.Focus()
        End If
    End Sub

   

    Private Sub txtName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtName.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtContactNo.Focus()
        End If
    End Sub


    Private Sub txtContactNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtContactNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtEmailID.Focus()
        End If
    End Sub

    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub
End Class