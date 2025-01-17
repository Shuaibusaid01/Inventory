Imports System.Data.OleDb
Public Class EditItem
    Dim cnn As New OleDb.OleDbConnection
    Dim cmd As OleDbCommand = Nothing

    ' this method is used to fill the information 
    Public Sub FillItemInfo(ByVal Barcode As String)
        ItemsTA.FillByBarcode(MyDS.Items, Barcode)
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ' perform validation for barcode
        If TextBox1.Text.Trim = "" Then
            MsgBox("You should enter a barcode number", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            TextBox1.Focus()
            Exit Sub
        End If
        If Not IsNumeric(TextBox1.Text) Then
            MsgBox("The barcode number should include digits only", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            TextBox1.Focus()
            Exit Sub
        End If
        If TextBox1.Text.Contains(".") Or TextBox1.Text.Contains("-") Then
            MsgBox("The barcode number should include digits only", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            TextBox1.Focus()
            Exit Sub
        End If

        ' perform check for the item name
        If TextBox2.Text.Trim = "" Then
            MsgBox("You should enter name for the item", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            TextBox2.Focus()
            Exit Sub
        End If


        ' perform a check for the sell price
        If Not IsNumeric(TextBox4.Text) Then
            MsgBox("You should enter the sell price as a number", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            TextBox4.Focus()
            Exit Sub
        End If
        Dim SellPrice As Decimal = Decimal.Parse(TextBox4.Text)
        If SellPrice < 0 Then
            MsgBox("Sell price can't be negative", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            TextBox4.Focus()
            Exit Sub
        End If

        ' insert the item
        Try
            '  ' create the adapter
            ' Dim TA As New POSDSTableAdapters.ItemsTableAdapter

            ' insert the item
            ' BS.EndEdit()
            'TA.Update(MyDS.Items)
            Dim cmd As New OleDb.OleDbCommand
            If Not cnn.State = ConnectionState.Open Then
                cnn.Open()
            End If
            cmd.Connection = cnn
            cmd.CommandText = "UPDATE Items " &
                                           " SET ItemName='" & TextBox2.Text & "',SellPrice='" & TextBox4.Text & "' ,Quantity='" & TextBox3.Text & "' ,FileName = '" & Me.TextBox5.Text & "'" &
            " WHERE Barcode ='" & Me.TextBox1.Text & "'"

            cmd.ExecuteNonQuery()
            ' close window and return ok
            Me.Close()
        Catch ex As Exception

            ' display error message
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
        End Try
        cnn.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim OFD As New OpenFileDialog
        OFD.Filter = "Images |*.png; *.bmp; *.jpg;*.jpeg; *.gif;"
        If OFD.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            TextBox5.Text = ""
        Else
            TextBox5.Text = OFD.FileName
        End If
    End Sub

    Private Sub EditItem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cnn = New OleDb.OleDbConnection
        cnn.ConnectionString = "Provider=Microsoft.ACE.Oledb.12.0; Data Source=" & Application.StartupPath & "\db.accdb"

        Dim I As Integer
        TextBox5.Text = MainWindow.DGV.Rows(I).Cells(4).Value

    End Sub
End Class