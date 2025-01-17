Imports System.Drawing.Imaging
Imports System.Text
Imports System.Security.Cryptography
Imports System.IO
Imports System.Data.OleDb
Imports System.Net.WebRequestMethods

Public Class AddItem
    Dim image As String
    Dim Loc As String
    Dim cnn As New OleDb.OleDbConnection
    Dim adp As OleDb.OleDbDataAdapter
    Public ds As New DataSet()
    Dim cmd As OleDbCommand = Nothing
    Dim rdr As OleDbDataReader = Nothing
    Dim cs As String = "Provider=Microsoft.ACE.Oledb.12.0; Data Source=" & Application.StartupPath & "\db.accdb"

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
    ' used to tell the main window that the operation is cancelled
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    ' used to insert the item
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
        Dim SellPrice As Decimal = Decimal.Parse(TextBox4.Text)

        If Not IsNumeric(TextBox4.Text) Then
            MsgBox("You should enter the sell price as a number", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            TextBox4.Focus()
            Exit Sub
        End If



        ' insert the item
        Try
            ' create the adapter
            Dim TA As New POSDSTableAdapters.ItemsTableAdapter
            cnn = New OleDbConnection(cs)
            cnn.Open()

            Dim cb As String = "insert into Items(Barcode,ItemName,SellPrice,FileName,Quantity) VALUES ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox3.Text & "')"
            cmd = New OleDbCommand(cb)
            cmd.Connection = cnn
            cmd.ExecuteReader()
            cnn.Close()

            ' insert the item
            MainWindow.RefreshDataItems()
            Me.Close
        Catch ex As Exception

            ' display error message
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub


    ' select a file
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim OFD As New OpenFileDialog
        OFD.Filter = "Images |*.png; *.bmp; *.jpg;*.jpeg; *.gif;"
        If OFD.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            TextBox5.Text = ""
        Else
            TextBox5.Text = OFD.FileName
        End If
     
    End Sub

    Private Sub AddItem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub


End Class