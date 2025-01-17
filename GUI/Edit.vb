Imports System.Data.OleDb
Public Class Edit
    Dim cnn As New OleDb.OleDbConnection
    Dim cmd As OleDbCommand = Nothing
    Private Sub Edit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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


    Private Sub dgv_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv.RowHeaderMouseClick
        Try
            Dim dr As DataGridViewRow = dgv.SelectedRows(0)
            If dgv.SelectedRows.Count = 0 Then
                Exit Sub
            End If

            ' get the barcode of the item
            Dim Barcode = dgv.SelectedRows(0).Cells(0).Value

            ' create the edit window

            Dim EditItemWindow As New EditItem

            ' fill the window with information
            EditItemWindow.FillItemInfo(Barcode)

            If EditItemWindow.ShowDialog = Windows.Forms.DialogResult.OK Then
                ' load the information of items from db
                ItemsTA.Fill(MyDataset.Items)
            End If
            MainWindow.FillButtons()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim dr As DataGridViewRow = dgv.SelectedRows(0)
            If dgv.SelectedRows.Count = 0 Then
                Exit Sub
            End If

            ' get the barcode of the item
            Dim Barcode = dgv.SelectedRows(0).Cells(0).Value

            ' create the edit window

            Dim EditItemWindow As New EditItem

            ' fill the window with information
            EditItemWindow.FillItemInfo(Barcode)

            If EditItemWindow.ShowDialog = Windows.Forms.DialogResult.OK Then
                ' load the information of items from db
                ItemsTA.Fill(MyDataset.Items)
            End If
            MainWindow.FillButtons()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Me.Close()
    End Sub
End Class