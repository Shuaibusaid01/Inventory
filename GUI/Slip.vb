Imports System.Data.OleDb
Public Class Slip
    Dim cnn As New OleDb.OleDbConnection
    Dim cmd As OleDbCommand = Nothing

    Private Sub Slip_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cnn = New OleDb.OleDbConnection
        cnn.ConnectionString = "Provider=Microsoft.ACE.Oledb.12.0; Data Source=" & Application.StartupPath & "\db.accdb"
        fillANo()
    End Sub
    Private Sub RefreshData2()
        If Not cnn.State = ConnectionState.Open Then
            'open connection
            cnn.Open()
        End If
        Dim da As New OleDb.OleDbDataAdapter("SELECT ReceiptDetails.ReceiptID, ReceiptDetails.ItemName, ReceiptDetails.Price, ReceiptDetails.Counts,  " & _
                                             " ReceiptDetails.TPrice,Receipts.ReceiptDate, Receipts.ReceiptTotal, Receipts.Change, Receipts.Username" & _
                                             " FROM Receipts INNER JOIN ReceiptDetails ON Receipts.[ReceiptID] = ReceiptDetails.[ReceiptID] WHERE Receipts.[ReceiptID] And ReceiptDetails.[ReceiptID]=" & cmbno.Text & "", cnn)
        Dim dt As New DataTable
        'fill data to datatable
        da.Fill(dt)
        'offer data in datatable into datagridview
        Me.dgv4.DataSource = dt
        'close connection
        cnn.Close()
    End Sub
    Private Sub GetData()
        Dim dt As New DataTable

        With dt
            .Columns.Add("ReceiptID")
            .Columns.Add("ItemName")
            .Columns.Add("Price")
            .Columns.Add("Counts")
            .Columns.Add("TPrice")
            .Columns.Add("ReceiptDate")
            .Columns.Add("ReceiptTotal")
            .Columns.Add("Change")
            .Columns.Add("Username")

        End With
        For Each dr As DataGridViewRow In Me.dgv4.Rows
            dt.Rows.Add(dr.Cells("ReceiptID").Value, dr.Cells("ItemName").Value, dr.Cells("Price").Value, dr.Cells("Counts").Value, dr.Cells("TPrice").Value, dr.Cells("ReceiptDate").Value, dr.Cells("ReceiptTotal").Value, dr.Cells("Change").Value, dr.Cells("Username").Value)
        Next
        '
        Dim rptDoc As New Reciept
        rptDoc.SetDataSource(dt)
        crv.ReportSource = rptDoc
        crv.Refresh()
    End Sub
    Sub fillANo()
        Try
            Dim ds As New DataSet
            Dim dr As DataRow
            Dim dt As New DataTable
            Dim adptr As New OleDbDataAdapter("SELECT  distinct ReceiptID FROM Receipts Ascend", cnn)
            adptr.Fill(ds, "Receipts")
            dt = ds.Tables(0)
            cmbno.Items.Clear()
            cmbno.SelectedIndex = -1
            For Each dr In dt.Rows
                cmbno.Items.Add(dr.Item("ReceiptID"))


            Next
        Catch ex As Exception
            MsgBox("The database could not be found. Try again")
            End
        End Try

    End Sub

    Private Sub btnget_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnget.Click
        RefreshData2()
        GetData()
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub
End Class