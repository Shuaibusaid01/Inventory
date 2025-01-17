Imports System.Data.OleDb
Public Class Sold
    Dim cnn As New OleDb.OleDbConnection
    Dim cmd As OleDbCommand = Nothing

    Private Sub Sold_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cnn = New OleDb.OleDbConnection
        cnn.ConnectionString = "Provider=Microsoft.ACE.Oledb.12.0; Data Source=" & Application.StartupPath & "\db.accdb"
        fillANo()
    End Sub
    Sub fillANo()
        Try
            Dim ds As New DataSet
            Dim dr As DataRow
            Dim dt As New DataTable
            Dim adptr As New OleDbDataAdapter("SELECT  distinct ItemName FROM Items Ascend", cnn)
            adptr.Fill(ds, "Items")
            dt = ds.Tables(0)
            cmbitem.Items.Clear()
            cmbitem.SelectedIndex = -1
            For Each dr In dt.Rows
                cmbitem.Items.Add(dr.Item("ItemName"))


            Next
        Catch ex As Exception
            MsgBox("The database could not be found. Try again")
            End
        End Try

    End Sub
    Private Sub btnget_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnget.Click
        If Not cnn.State = ConnectionState.Open Then
            'open connection
            cnn.Open()
        End If
       
        Dim da As New OleDb.OleDbDataAdapter("SELECT ReceiptID, ItemName, Counts, TPrice as [Price]  " & _
                                             " FROM ReceiptDetails Where ItemName= '" & cmbitem.Text & "' And Dat like '%" & dtp3.Text.ToString() & "%'", cnn)
        Dim dt As New DataTable
        'fill data to datatable
        da.Fill(dt)
        'offer data in datatable into datagridview
        Me.dg2.DataSource = dt
        'close connection
        cnn.Close()
        Dim Sum As Decimal = 0
        Dim Sum1 As Decimal = 0

        For I = 0 To dg2.Rows.Count - 1
            Sum += dg2.Rows(I).Cells(2).Value
            Sum1 += dg2.Rows(I).Cells(3).Value

        Next

        txtqtysold.Text = Sum
        txtqtytot.Text = Sum1
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub
End Class