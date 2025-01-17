Imports System.Data.OleDb
Imports System.IO
Imports System.Windows.Forms
Imports System.Drawing.Imaging
Imports System.Text
Public Class Sales
    Dim cnn As New OleDb.OleDbConnection
    Dim rdr As OleDbDataReader = Nothing
    Public myDA As New OleDbDataAdapter()
    Dim cmd As OleDbCommand = Nothing
    Private Sub RefreshData1()
        If Not cnn.State = ConnectionState.Open Then
            'open connection
            cnn.Open()
        End If
        Dim da As New OleDb.OleDbDataAdapter("SELECT ReceiptID, ReceiptDate, ReceiptTotal  " & _
                                             " FROM Receipts WHERE ReceiptDate Between '" & dtp.Text & "' And '" & dtp1.Text & "'", cnn)

        Dim dt As New DataTable
        'fill data to datatable
        da.Fill(dt)
        'offer data in datatable into datagridview
        Me.DGV.DataSource = dt
        'close connection
        cnn.Close()
    End Sub
    Private Sub RefreshData()
        If Not cnn.State = ConnectionState.Open Then
            'open connection
            cnn.Open()
        End If
        Dim da As New OleDb.OleDbDataAdapter("SELECT ReceiptID, ReceiptDate, ReceiptTotal  " & _
                                             " FROM Receipts ORDER BY ReceiptID", cnn)
        Dim dt As New DataTable
        'fill data to datatable
        da.Fill(dt)
        'offer data in datatable into datagridview
        Me.DGV.DataSource = dt
        'close connection
        cnn.Close()
    End Sub
    Private Sub SalesRep_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim I As Integer
        cnn = New OleDb.OleDbConnection
        cnn.ConnectionString = "Provider=Microsoft.ACE.Oledb.12.0; Data Source=" & Application.StartupPath & "\db.accdb"
        RefreshData()
        GetData()
        Dim Sum As Decimal = 0
        For I = 0 To DGV.Rows.Count - 1
            Sum += DGV.Rows(I).Cells(2).Value
        Next

        txttot.Text = Sum
    End Sub
    Private Sub GetData()
        Dim dt As New DataTable

        With dt
            .Columns.Add("ReceiptID")
            .Columns.Add("ReceiptDate")
            .Columns.Add("ReceiptTotal")


        End With
        For Each dr As DataGridViewRow In Me.DGV.Rows
            dt.Rows.Add(dr.Cells("ReceiptID").Value, dr.Cells("ReceiptDate").Value, dr.Cells("ReceiptTotal").Value)
        Next
        '
        Dim rptDoc As New RepSales
        rptDoc.SetDataSource(dt)
        crv.ReportSource = rptDoc
        crv.Refresh()
    End Sub

    Private Sub Sales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim I As Integer
        RefreshData1()
        GetData()
        Dim Sum As Decimal = 0
        For I = 0 To DGV.Rows.Count - 1
            Sum += DGV.Rows(I).Cells(2).Value
        Next

        txttot.Text = Sum
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim I As Integer
        RefreshData()
        GetData()
        Dim Sum As Decimal = 0
        For I = 0 To DGV.Rows.Count - 1
            Sum += DGV.Rows(I).Cells(2).Value
        Next

        txttot.Text = Sum
    End Sub

    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub
End Class