Imports System.Data.OleDb
Public Class MainWindow
    Dim cnn As New OleDb.OleDbConnection
     Dim cmd As OleDbCommand = Nothing
    Dim MyConnection As OleDb.OleDbConnection = Nothing

    Dim ReceiptImage As Bitmap
    Dim LastSetOfButtons As Integer = 0
    Dim LastSetOfPic As Integer = 0
    ' the form loads and initialization should happen
    Private Sub MainWindow_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Button2.Visible = False
        Timer1.Enabled = True
        Try

            cnn = New OleDb.OleDbConnection
            cnn.ConnectionString = "Provider=Microsoft.ACE.Oledb.12.0; Data Source=" & Application.StartupPath & "\db.accdb"
            RefreshData5()
            RefreshDataItems()

            If txtunm.Text = "admin" Then
                MenuStrip1.Enabled = True
            ElseIf txtunm.Text = "Admin" Then
                MenuStrip1.Enabled = True
            Else
                MenuStrip1.Enabled = False
            End If

            ' get the password from the user
            'Dim PSWWin As New PasswordPicker

            ' if the user hits the exit button then stop execution
            ' If PSWWin.ShowDialog <> Windows.Forms.DialogResult.OK Then
            'End
            ' End If

            ' get the password
            ' Dim PSW As String = PSWWin.TextBox1.Text

            ' get the password from the database
            Dim TA As New POSDSTableAdapters.ValuesTableAdapter
            Dim TB = TA.GetDataByKey("password")
            Dim DBPSW As String = TB.Rows(0).Item(1)

            ' check that passwords match
            ' If PSW <> DBPSW Then
            'MsgBox("invalid password", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            'End
            ' End If

            ' load the items information from db into the dataset
            ItemsTA.Fill(MyDataset.Items)


            ' the printer name should appear
            Dim VTA As New POSDSTableAdapters.ValuesTableAdapter
            Dim Result = VTA.GetDataByKey("printer")


        Catch ex As Exception

            ' handle the error
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            End
        End Try

        FillButtons()
        FillPic()
    End Sub

    ' this method is used to fill the buttons
    Public Sub FillButtons()
        Dim I As Integer
        Dim J As Integer = 0
        Dim B As Button = Nothing
        For I = LastSetOfButtons To LastSetOfButtons + 5 - 1
            If J = 0 Then B = B1
            If J = 1 Then B = B2
            If J = 2 Then B = b3
            If J = 3 Then B = b4
            If J = 4 Then B = b5
            J = J + 1
            If MyDataset.Items.Rows.Count > I Then
                B.Tag = MyDataset.Items.Rows(I).Item("barcode")
                B.Image = Nothing

                If MyDataset.Items.Rows(I).Item("FileName") & "" <> "" Then
                    Try
                        B.Text = MyDataset.Items.Rows(I).Item("ItemName")
                    Catch ex As Exception
                        B.Text = MyDataset.Items.Rows(I).Item("ItemName")
                        B.Image = Nothing
                    End Try
                Else
                    B.Text = MyDataset.Items.Rows(I).Item("ItemName")
                End If


                B.Visible = True
            Else
                B.Visible = False
            End If
        Next
    End Sub
    Public Sub FillPic()
        Dim I As Integer
        Dim J As Integer = 0
        Dim P As PictureBox = Nothing
        For I = LastSetOfPic To LastSetOfPic + 5 - 1
            If J = 0 Then P = P1
            If J = 1 Then P = P2
            If J = 2 Then P = P3
            If J = 3 Then P = P4
            If J = 4 Then P = P5
            J = J + 1
            If MyDataset.Items.Rows.Count > I Then
                P.Tag = MyDataset.Items.Rows(I).Item("barcode")
                P.Image = Nothing

                If MyDataset.Items.Rows(I).Item("FileName") & "" <> "" Then
                    Try
                        Dim ImgB() As Byte = System.IO.File.ReadAllBytes(MyDataset.Items.Rows(I).Item("FileName"))
                        Dim MemS As New System.IO.MemoryStream(ImgB)
                        Dim IMG As Image = Image.FromStream(MemS)
                        P.Image = IMG
                        P.Text = ""
                    Catch ex As Exception
                        P.Text = MyDataset.Items.Rows(I).Item("ItemName")
                        P.Image = Nothing
                    End Try
                Else
                    P.Text = MyDataset.Items.Rows(I).Item("ItemName")
                End If


                P.Visible = True
            Else
                P.Visible = False
            End If
        Next
    End Sub
    Private Sub RefreshData1()
        If Not cnn.State = ConnectionState.Open Then
            'open connection
            cnn.Open()
        End If
        Dim da As New OleDb.OleDbDataAdapter("SELECT ReceiptDetails.ReceiptID, ReceiptDetails.ItemName, ReceiptDetails.Price, ReceiptDetails.Counts,  " & _
                                             " ReceiptDetails.TPrice,Receipts.Receiptdate, Receipts.Receipttotal, Receipts.Change" & _
                                             " FROM Receipts INNER JOIN ReceiptDetails ON Receipts.[ReceiptID] = ReceiptDetails.[ReceiptID] ORDER BY ReceiptDetails.ReceiptID DESC", cnn)
        Dim dt As New DataTable
        'fill data to datatable
        da.Fill(dt)
        'offer data in datatable into datagridview
        Me.dgv3.DataSource = dt
        'close connection
        cnn.Close()
    End Sub
    Private Sub RefreshData2()
        If Not cnn.State = ConnectionState.Open Then
            'open connection
            cnn.Open()
        End If
        Dim da As New OleDb.OleDbDataAdapter("SELECT ReceiptDetails.ReceiptID, ReceiptDetails.ItemName, ReceiptDetails.Price, ReceiptDetails.Counts,  " & _
                                             " ReceiptDetails.TPrice,Receipts.ReceiptDate, Receipts.ReceiptTotal, Receipts.Change, Receipts.Username, Receipts.Amounts, Receipts.Tym" & _
                                             " FROM Receipts INNER JOIN ReceiptDetails ON Receipts.[ReceiptID] = ReceiptDetails.[ReceiptID] WHERE Receipts.[ReceiptID] And ReceiptDetails.[ReceiptID]=" & txtid.Text & "", cnn)
        Dim dt As New DataTable
        'fill data to datatable
        da.Fill(dt)
        'offer data in datatable into datagridview
        Me.dgv4.DataSource = dt
        'close connection
        cnn.Close()
    End Sub

    Private Sub RefreshData5()
        If Not cnn.State = ConnectionState.Open Then
            'open connection
            cnn.Open()
        End If
        Dim da As New OleDb.OleDbDataAdapter("SELECT ReceiptTotal " & _
                                             " FROM Receipts Where ReceiptDate = '" & dtp.Text.ToString() & "'", cnn)
        Dim dt As New DataTable
        'fill data to datatable
        da.Fill(dt)
        'offer data in datatable into datagridview
        Me.dg.DataSource = dt
        'close connection
        cnn.Close()
        Dim Sum As String = 0
        For I = 0 To dg.Rows.Count - 1
            Sum += dg.Rows(I).Cells(0).Value
        Next

        txttotal.Text = Sum
    End Sub
    Sub RefreshDataItems()
        If Not cnn.State = ConnectionState.Open Then
            'open connection
            cnn.Open()
        End If
        Dim da As New OleDb.OleDbDataAdapter("SELECT Barcode as [Item No],ItemName as [Item Name],SellPrice as [Price], Quantity, FileName as [Image Loc] FROM Items ORDER BY ItemName", cnn)
        Dim dt As New DataTable
        'fill data to datatable
        da.Fill(dt)
        'offer data in datatable into datagridview
        Me.DGV.DataSource = dt
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
            .Columns.Add("Amounts")
            .Columns.Add("Tym")


        End With
        For Each dr As DataGridViewRow In Me.dgv4.Rows
            dt.Rows.Add(dr.Cells("ReceiptID").Value, dr.Cells("ItemName").Value, dr.Cells("Price").Value, dr.Cells("Counts").Value, dr.Cells("TPrice").Value, dr.Cells("ReceiptDate").Value, dr.Cells("ReceiptTotal").Value, dr.Cells("Change").Value, dr.Cells("Username").Value, dr.Cells("Amounts").Value, dr.Cells("Tym").Value)
        Next
        '
        Dim rptDoc As New Reciept
        rptDoc.SetDataSource(dt)
        crv.ReportSource = rptDoc
        crv.Refresh()
           End Sub
    ' change the password
    Private Sub ChangePasswordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangePasswordToolStripMenuItem.Click
        Users.Show()
    End Sub

    ' add item to the db
    Private Sub AddItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddItemToolStripMenuItem.Click
        Dim AddItemWindow As New AddItem
        If AddItemWindow.ShowDialog = Windows.Forms.DialogResult.OK Then
            ' load the information of items from db
            ItemsTA.Fill(MyDataset.Items)
        End If

        FillButtons()
        FillPic()
    End Sub

    ' used to select an item
    Private Sub EditItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditItemToolStripMenuItem.Click
        Dim I As Integer

        ' make sure an item is selected
        If DGV.SelectedRows.Count = 0 Then
            Exit Sub
        End If


        ' get the barcode of the item
        Dim Barcode = DGV.SelectedRows(0).Cells(0).Value

        ' create the edit window
        Dim EditItemWindow As New EditItem

        ' fill the window with information
        EditItemWindow.FillItemInfo(Barcode)

        If EditItemWindow.ShowDialog = Windows.Forms.DialogResult.OK Then
            ' load the information of items from db
            ItemsTA.Fill(MyDataset.Items)
        End If

        EditItem.TextBox5.Text = DGV.Rows(I).Cells(3).Value
        FillButtons()
        FillPic()
    End Sub

    ' this one is used to remove an item
    Private Sub RemoveItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveItemToolStripMenuItem.Click

        ' make sure a single item is being selected
        If DGV.SelectedRows.Count = 0 Then
            Exit Sub
        End If

        ' get the barcode of the item
        Dim Barcode As String = DGV.SelectedRows(0).Cells(0).Value

        ' remove the item
        Try
            ItemsTA.DeleteByBarcode(Barcode)
            ItemsTA.Fill(MyDataset.Items)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
        End Try

        FillButtons()
        FillPic()
    End Sub



    ' checks if the return key is pressed
    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If Button1.Enabled Then
            If e.KeyChar = Chr(13) Then
                Button1_Click(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub RefreshData3()
        If Not cnn.State = ConnectionState.Open Then
            'open connection
            cnn.Open()
        End If
        Dim da As New OleDb.OleDbDataAdapter("SELECT Barcode, Quantity FROM Items Where Barcode= " & TextBox1.Text.ToString() & "", cnn)
        Dim dt As New DataTable
        'fill data to datatable
        da.Fill(dt)
        'offer data in datatable into datagridview
        Me.dgv5.DataSource = dt
        'close connection
        cnn.Close()
    End Sub
    ' this one is used to detect the barcode item when the text change and display its information
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Try

            ' step 01: create the table adapter
            Dim TA As New POSDSTableAdapters.ItemsTableAdapter
            Dim TB = TA.GetDataByBarcode(TextBox1.Text)

            ' step 02: check if no item is found
            If TB.Rows.Count = 0 Then
                TextBox2.Text = ""
                TextBox3.Text = ""
                'txtqty2.Text = ""
                Button1.Enabled = False
                Exit Sub
            End If

            ' step 03: display the information in the textboxes
            Button1.Enabled = True
            Dim R As POS.POSDS.ItemsRow = TB.Rows(0)
            TextBox2.Text = R.ItemName
            TextBox3.Text = R.SellPrice
            ' txtqty2.Text = R.Qty
            Button1.Tag = R
        Catch ex As Exception
            ' display error message
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub


    ' this will be used to add an item to the recipt details
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ' get the details of the item
        Dim R As POS.POSDS.ItemsRow = Button1.Tag

        ' next search for the barcode in the datagridview
        Dim I As Integer
        Dim ItemLoc As Integer = -1
        For I = 0 To DGV2.Rows.Count - 1
            If R.Barcode = DGV2.Rows(I).Cells(0).Value Then

                ' item found
                ItemLoc = I
                Exit For

            End If
        Next

        If txtqty3.Text = "" Then
            MsgBox("pls enter the qty")
            txtqty2.Focus()
            Exit Sub
        End If
        ' if item is not found, add it
        If ItemLoc = -1 Then
            DGV2.Rows.Add(R.Barcode, R.ItemName, R.SellPrice, "" & txtqty3.Text & "", R.SellPrice)
        Else
            ' if item is already there increase its count
            Dim ItemCount As Long = DGV2.Rows(ItemLoc).Cells(3).Value
            ItemCount += "" & txtqty3.Text & ""

            ' txtqty3.Text = ItemCount
            Dim NewPrice As Decimal = R.SellPrice * ItemCount
            DGV2.Rows(ItemLoc).Cells(3).Value = ItemCount
            DGV2.Rows(ItemLoc).Cells(4).Value = NewPrice
        End If

       

       
        ' next clear textbox1 and set focus to it
        TextBox1.Text = ""
        txtqty3.Text = ""
        Button4.Focus()

        ' compute the total for the recipt
        Dim Sum As Decimal = 0
        For I = 0 To DGV2.Rows.Count - 1
            Sum += DGV2.Rows(I).Cells(4).Value
        Next

        TextBox4.Text = Sum


    End Sub


    ' remove item from the recipt
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If DGV2.SelectedRows.Count = 0 Then
            Exit Sub
        End If

        DGV2.Rows.Remove(DGV2.SelectedRows(0))

        Dim Sum As Decimal = 0
        For I = 0 To DGV2.Rows.Count - 1
            Sum += DGV2.Rows(I).Cells(5).Value
        Next

        TextBox4.Text = Sum
        txtchange.Text = txtamount.Text - TextBox4.Text
        txtchange.ToString()

    End Sub


    ' save the recipt
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If txtamount.Text.Trim = "" Then
            MsgBox("Please enter the amount")
            Exit Sub
            txtamount.Focus()
        End If
        Dim MyConnection As OleDb.OleDbConnection = Nothing
        Dim MyTransaction As OleDb.OleDbTransaction = Nothing

        Try

            ' create the connection and  transaction object
            MyConnection = New OleDb.OleDbConnection(My.Settings.dbConnectionString)
            MyConnection.Open()
            MyTransaction = MyConnection.BeginTransaction

            ' insert the new recipt
            Dim SQL As String = "insert into Receipts (ReceiptDate,ReceiptTotal,Change, Username, Amounts, Tym) values (:0,:1,:2,:3,:4,:5)"
            Dim CMD1 As New OleDb.OleDbCommand
            CMD1.Connection = MyConnection
            CMD1.Transaction = MyTransaction
            CMD1.CommandText = SQL
            CMD1.Parameters.AddWithValue(":0", dtp.Text)
            CMD1.Parameters.AddWithValue(":1", TextBox4.Text)
            CMD1.Parameters.AddWithValue(":2", txtchange.Text)
            CMD1.Parameters.AddWithValue(":3", txtunm.Text)
            CMD1.Parameters.AddWithValue(":4", txtamount.Text)
            CMD1.Parameters.AddWithValue(":5", txttym.Text)


            CMD1.ExecuteNonQuery()
            CMD1.Dispose()


            ' get the id for the recipt
            SQL = "Select max(ReceiptID) as MAXID from Receipts"
            Dim CMD2 As New OleDb.OleDbCommand
            CMD2.Connection = MyConnection
            CMD2.Transaction = MyTransaction
            CMD2.CommandText = SQL
            Dim ReceiptID As Long = CMD2.ExecuteScalar()
            CMD2.Dispose()

            ' insert the details of the recipt
            Dim I As Integer
            For I = 0 To DGV2.Rows.Count - 1

                ' get the values
                Dim ItemName As String = DGV2.Rows(I).Cells(1).Value
                Dim Price As Decimal = DGV2.Rows(I).Cells(2).Value
                Dim Count As Integer = DGV2.Rows(I).Cells(3).Value
                Dim TPrice As String = DGV2.Rows(I).Cells(4).Value

                ' next create a command
                Dim CMD3 As New OleDb.OleDbCommand
                SQL = "insert into ReceiptDetails " & _
                      "(ReceiptID, ItemName, Price, Counts,Tprice, Dat) " & _
                      "values " & _
                      "(:0      ,:1     ,:2       ,:3       ,:4      ,'" & dtp.Text & "')"
                CMD3.Connection = MyConnection
                CMD3.Transaction = MyTransaction
                CMD3.CommandText = SQL
                CMD3.Parameters.AddWithValue(":0", ReceiptID)
                CMD3.Parameters.AddWithValue(":1", ItemName)
                CMD3.Parameters.AddWithValue(":2", Price)
                CMD3.Parameters.AddWithValue(":3", Count)
                CMD3.Parameters.AddWithValue(":4", TPrice)


                CMD3.ExecuteNonQuery()
                CMD3.Dispose()

            Next


            ' all well save the changes
            MyTransaction.Commit()

            ' close connection
            MyTransaction.Dispose()
            MyConnection.Close()
            MyConnection.Dispose()



            ' use the printer
            Subtrct()


            DGV2.Rows.Clear()
            TextBox4.Text = ""
            txtamount.Text = ""
            txtchange.Text = ""

            RefreshData1()
            RefreshData2()
            RefreshData5()
        Catch ex As Exception
            If MyTransaction IsNot Nothing Then
                ' MyTransaction.Rollback()
            End If
            If MyConnection IsNot Nothing Then
                If MyConnection.State = ConnectionState.Open Then
                    MyConnection.Close()
                End If
            End If

            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
        End Try
        '  GetData()
        crv.PrintReport()

    End Sub
   

    ' show the correct report

    ' function Draw Receipt






    ' this one is used to print a document
    Private Sub PrintDoc_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDoc.PrintPage
        e.Graphics.DrawImage(ReceiptImage, 0, 0, ReceiptImage.Width, ReceiptImage.Height)
        e.HasMorePages = False
      

    End Sub

    ' used to select a printer
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If PrintDLG.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If


        ' save the printer name in the database
        Try
            Dim VTA As New POSDSTableAdapters.ValuesTableAdapter
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub








    ' save backup
    Private Sub BackupDBToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackupDBToolStripMenuItem.Click
        Dim SFD As New SaveFileDialog
        SFD.Filter = "*.backup|*.backup"
        If SFD.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
        If BackupRestoreModule.SaveDB(SFD.FileName) Then
            MsgBox("Backup completed successfully", MsgBoxStyle.OkOnly Or MsgBoxStyle.Information, "OK")
        Else
            MsgBox("Unable to make backup", MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    Private Sub RestoreDBToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestoreDBToolStripMenuItem.Click
        Dim OFD As New OpenFileDialog
        OFD.Filter = "*.backup|*.backup"
        If OFD.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
        If Not LoadDB(OFD.FileName) Then
            MsgBox("Error restoring the Database", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
        Else
            MsgBox("Restore successful", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "OK")
            End
        End If
    End Sub


    Private Sub RR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RR.Click
        Me.LastSetOfButtons = Me.LastSetOfButtons + 5
        If Me.LastSetOfButtons >= MyDataset.Items.Rows.Count Then
            Me.LastSetOfButtons = MyDataset.Items.Rows.Count - 5
            If Me.LastSetOfButtons < 0 Then
                Me.LastSetOfButtons = 0
            End If
        End If
        Me.LastSetOfPic = Me.LastSetOfPic + 5
        If Me.LastSetOfPic >= MyDataset.Items.Rows.Count Then
            Me.LastSetOfPic = MyDataset.Items.Rows.Count - 5
            If Me.LastSetOfPic < 0 Then
                Me.LastSetOfPic = 0
            End If
        End If
        FillButtons()
        FillPic()
    End Sub

    Private Sub LL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LL.Click
        Me.LastSetOfButtons = Me.LastSetOfButtons - 5
        If Me.LastSetOfButtons < 0 Then
            Me.LastSetOfButtons = 0
        End If
        Me.LastSetOfPic = Me.LastSetOfPic - 5
        If Me.LastSetOfPic < 0 Then
            Me.LastSetOfPic = 0
        End If

        FillButtons()
        FillPic()

    End Sub

    ' used to add item to receipt
    Private Sub B1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B1.Click, B2.Click, b3.Click, b4.Click, b5.Click
        TextBox1.Text = sender.Tag
        txtqty3.Text = "1"

        Button1_Click(Nothing, Nothing)
    End Sub

    Private Sub DGV2_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs)
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If DGV.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            DGV.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

    End Sub

    Private Sub SalesReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesReportToolStripMenuItem.Click
        Sales.Show()
    End Sub

    Private Sub txtamount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtamount.KeyPress
        If e.KeyChar = Chr(13) Then
            Button3_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtamount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtamount.TextChanged
          txtchange.Text = (Val(txtamount.Text)) - (Val(TextBox4.Text))
       
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Me.Close()
        Login.Show()
    End Sub


    Private Sub dgv3_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv3.SelectionChanged
        On Error Resume Next
        txtid.Text = dgv3.SelectedCells(0).Value.ToString()

    End Sub


    Private Sub DGV2_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        On Error Resume Next
        TextBox1.Text = DGV2.SelectedCells(0).Value.ToString()
       
    End Sub

   

    Private Sub AddStaffToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddStaffToolStripMenuItem.Click
        StaffReg.Show()
    End Sub

    
    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub


   

  
    Private Sub SoldItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SoldItemToolStripMenuItem.Click
        Sold.Show()
    End Sub

    Private Sub ReprintReceiptToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReprintReceiptToolStripMenuItem.Click
        Slip.Show()
    End Sub

    Private Sub SalepersonToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalepersonToolStripMenuItem.Click
        Salesby.Show()
    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        Edit.Show()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Search.Show()
    End Sub
    Private Sub Subtrct()
        If Not cnn.State = ConnectionState.Open Then
            'open connection
            cnn.Open()
        End If


        Dim I As Integer
        For I = 0 To DGV2.Rows.Count - 1


            Dim cmdStr As String = "Select Count(*) from Items where Barcode='" & DGV2.Rows(I).Cells(0).Value & "' "

            Dim CheckUser As OleDbCommand = New OleDbCommand(cmdStr, cnn)
            Dim temp As Integer = Convert.ToInt32(CheckUser.ExecuteScalar())



            'get the values

            If temp = 1 Then

                Dim cmd As OleDbCommand = New OleDbCommand("update Items set Quantity= Items.[Quantity] - " & Val(DGV2.Rows(I).Cells(3).Value) & " ,Qty= Items.[Qty] - " & Val(DGV2.Rows(I).Cells(4).Value) & " where Barcode= '" & DGV2.Rows(I).Cells(0).Value & "'", cnn)
                cmd.ExecuteNonQuery()

            End If

        Next
        cnn.Close()

    End Sub

    Private Sub DGV2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV2.CellContentClick
        If DGV2.Columns(e.ColumnIndex).Name = "Delete" Then
            DGV2.Rows.Remove(DGV2.SelectedRows(0))
        End If
        Dim Sum As Decimal = 0
        For I = 0 To DGV2.Rows.Count - 1
            Sum += DGV2.Rows(I).Cells(4).Value
        Next

        TextBox4.Text = Sum

    End Sub

    Private Sub DGV2_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGV2.RowHeaderMouseClick
        On Error Resume Next
        TextBox1.Text = DGV2.SelectedCells(0).Value.ToString()
        txtqty3.Text = DGV2.SelectedCells(3).Value.ToString()
        txtqty3.Focus()
        DGV2.Rows.Remove(DGV2.SelectedRows(0))

    End Sub

    Private Sub DGV2_SelectionChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGV2.SelectionChanged
        On Error Resume Next
        ' txtqty2.Text = DGV2.SelectedCells(0).Value.ToString()

    End Sub

    Private Sub txtqty3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtqty3.KeyPress
        If Button1.Enabled Then
            If e.KeyChar = Chr(13) Then
                ' TextBox1.Text = sender.Tag
                Button1_Click(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub txtqty3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtqty3.TextChanged

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        txttym.Text = TimeOfDay
    End Sub
End Class
