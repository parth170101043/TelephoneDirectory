Imports MySql.Data.MySqlClient
Public Class browseplan

    Private Sub browseplan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim MysqlConn As MySqlConnection
            MysqlConn = New MySqlConnection
            Dim MyCom As MySqlCommand
            MysqlConn.ConnectionString = "server='" & Form1.TextBox4.Text & "';userid=root;password=root;database=user_data"
            Dim query As String
            MysqlConn.Open()
            Dim SDA As New MySqlDataAdapter
            Dim dbdataset As New DataTable
            Dim bsource As New BindingSource
            query = "select * from user_data.plans where ServiceProvider = '" & UserForm1.Label4.Text & "'"
            MyCom = New MySqlCommand(query, MysqlConn)
            SDA.SelectCommand = MyCom
            SDA.Fill(dbdataset)
            bsource.DataSource = dbdataset
            DataGridView1.DataSource = bsource
            SDA.Update(dbdataset)
            MysqlConn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
      
    End Sub
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Try
            Dim index As Integer
            index = e.RowIndex
            Dim selectedRow As DataGridViewRow
            Dim str As String
            selectedRow = DataGridView1.Rows(index)
            str = selectedRow.Cells(2).Value.ToString()
            If str = "data" Then
                TextBox3.Text = selectedRow.Cells(1).Value.ToString()
                TextBox6.Text = selectedRow.Cells(4).Value.ToString()
            Else
                TextBox10.Text = selectedRow.Cells(1).Value.ToString()
                TextBox11.Text = selectedRow.Cells(4).Value.ToString()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        UserForm1.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox3.Text = ""
        TextBox6.Text = ""
        TextBox10.Text = ""
        TextBox11.Text = ""
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
      
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
       
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Label1.Text = "d"
        Me.Hide()
        confirm.Show()
    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        Label1.Text = "c"
        Me.Hide()
        confirm.Show()
    End Sub
End Class