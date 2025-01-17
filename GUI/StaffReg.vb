Imports System.Data.OleDb
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Public Class StaffReg
    Dim cnn As New OleDb.OleDbConnection
    Private Sub StaffReg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cnn = New OleDb.OleDbConnection
        cnn.ConnectionString = "Provider=Microsoft.ACE.Oledb.12.0; Data Source=" & Application.StartupPath & "\db.accdb"
        Me.RefreshData()
    End Sub
    Private Sub RefreshData()
        If Not cnn.State = ConnectionState.Open Then
            'open connection
            cnn.Open()
        End If
        Dim da As New OleDb.OleDbDataAdapter("SELECT StaffID as [Staff ID],  " & _
                                             " StaffName as [Name], Gender, Age, DateHireD as [Hire Date], GSM " & _
   " FROM Staffs ORDER BY StaffID", cnn)
        Dim dt As New DataTable
        'fill data to datatable
        da.Fill(dt)
        'offer data in datatable into datagridview
        Me.DGV.DataSource = dt
        'close connection
        cnn.Close()
    End Sub
    Public Shared Function GetUniqueKey(ByVal maxSize As Integer) As String
        Dim chars As Char() = New Char(61) {}
        chars = "123456789".ToCharArray()
        Dim data As Byte() = New Byte(0) {}
        Dim crypto As New RNGCryptoServiceProvider()
        crypto.GetNonZeroBytes(data)
        data = New Byte(maxSize - 1) {}
        crypto.GetNonZeroBytes(data)
        Dim result As New StringBuilder(maxSize)
        For Each b As Byte In data
            result.Append(chars(b Mod (chars.Length)))
        Next
        Return result.ToString()
    End Function

    Private Sub Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Add.Click
        staffid.Text = "S-" & GetUniqueKey(6)

        Dim cmd As New OleDb.OleDbCommand
        If Not cnn.State = ConnectionState.Open Then
            cnn.Open()

            cmd.Connection = cnn
            Dim ms As New MemoryStream()
            Dim bmpImage As New Bitmap(Pic.Image)
            bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
            Dim data As Byte() = ms.GetBuffer()
            Dim p As New OleDbParameter("@image", OleDbType.VarBinary)
            p.Value = data
            cmd.Parameters.Add(p)

            cmd.CommandText = "INSERT INTO Staffs(StaffID, StaffName, Gender, Age, DateHired, GSM, Photo, Picloc) " & _
                          " VALUES ('" & Me.staffid.Text & "', '" & Me.Nmtxt.Text & "', '" & Me.Sex.Text & "', '" & Me.Age.Text & "','" & Me.Dtp.Text & "', '" & Me.GSM.Text & "', '" & "@image" & "', '" & Me.Picloc.Text & "')"
            cmd.ExecuteNonQuery()
        Else
            'update in table
            cmd.CommandText = "UPDATE Staffs " & _
                                " SET StaffID = " & Me.staffid.Text & _
                                " WHERE StaffID =" & Me.staffid.Tag

            cmd.ExecuteNonQuery()
        End If


        MsgBox("Record updated successefully", MsgBoxStyle.OkOnly)
        cnn.Close()
        RefreshData()
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Btnpic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnpic.Click
        Dim OFD As New OpenFileDialog
        OFD.Filter = "Images |*.png; *.bmp; *.jpg;*.jpeg; *.gif;"
        OFD.FilterIndex = 4
        If OFD.ShowDialog = DialogResult.OK Then
            Pic.Image = Image.FromFile(OFD.FileName)
            Picloc.Text = "(" & OFD.FileName & ")"
        End If
    End Sub
End Class