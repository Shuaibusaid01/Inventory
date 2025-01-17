Imports System.Data.OleDb
Public Class Search
    Dim cnn As New OleDb.OleDbConnection
    Dim cmd As OleDbCommand = Nothing

    Private Sub Search_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cnn = New OleDb.OleDbConnection
        cnn.ConnectionString = "Provider=Microsoft.ACE.Oledb.12.0; Data Source=" & Application.StartupPath & "\db.accdb"
        RefreshData1()
        txtsrch.Focus()
    End Sub
    Private Sub RefreshData1()
        If Not cnn.State = ConnectionState.Open Then
            'open connection
            cnn.Open()
        End If
        Dim da As New OleDb.OleDbDataAdapter("SELECT Barcode, ItemName as [Name], SellPrice as [Price] " & _
                                             " FROM Items Order by Barcode", cnn)
        Dim dt As New DataTable
        'fill data to datatable
        da.Fill(dt)
        'offer data in datatable into datagridview
        Me.dgv.DataSource = dt
        'close connection
        cnn.Close()
    End Sub
    Private Sub RefreshData()
        If Not cnn.State = ConnectionState.Open Then
            'open connection
            cnn.Open()
        End If
        Dim da As New OleDb.OleDbDataAdapter("SELECT Barcode, ItemName as [Name], SellPrice as [Price] " & _
                                             " FROM Items Where ItemName like  '%" & txtsrch.Text & "%'", cnn)
        Dim dt As New DataTable
        'fill data to datatable
        da.Fill(dt)
        'offer data in datatable into datagridview
        Me.DGV.DataSource = dt
        'close connection
        cnn.Close()
    End Sub

    Private Sub txtsrch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsrch.TextChanged
        RefreshData()
    End Sub

    
    Private Sub dgv_RowHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv.RowHeaderMouseClick
        Try
            Dim dr As DataGridViewRow = dgv.SelectedRows(0)
            MainWindow.TextBox1.Text = dr.Cells(0).Value.ToString()
            MainWindow.txtqty3.Text = "1"
            MainWindow.txtqty3.Focus()
                   Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
         If Me.dgv.SelectedRows.Count > 0 Then
            Dim intItemNo As String = Me.dgv.SelectedRows(0).Cells(0).Value
            MainWindow.TextBox1.Text = intItemNo
            MainWindow.txtqty3.Text = "1"
            MainWindow.txtqty3.Focus()

        End If
        Me.Close()
    End Sub
End Class