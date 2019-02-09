Imports MySql.Data.MySqlClient
Public Class recharge

    Private Sub recharge_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        UserForm1.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim MysqlConn As MySqlConnection
        MysqlConn = New MySqlConnection
        Dim MyCom As MySqlCommand
        Dim reader As MySqlDataReader
        Dim bal As Integer
        Try
            MysqlConn.ConnectionString = "server='" & Form1.TextBox4.Text & "';userid=root;password=root;database=user_data"
            MysqlConn.Open()
            Dim query As String


            query = "Select * from user_data.user_table where userName='" & Form1.TextBox1.Text & "'"
            MyCom = New MySqlCommand(query, MysqlConn)
            reader = MyCom.ExecuteReader()
            reader.Read()
            bal = CInt(reader("balance")) + CInt(ComboBox1.Text())

            UserForm1.Label2.Text = "Balance = " + CStr(bal)
            Label3.Text = "Current Balance = " + CStr(bal)
            MysqlConn.Close()
            MysqlConn.Open()

            'counting the number of entries in the table
            query = "UPDATE user_data.user_table SET balance = '" & bal & "' where userName ='" & Form1.TextBox1.Text & "';"
            MyCom = New MySqlCommand(query, MysqlConn)
            reader = MyCom.ExecuteReader()

            MysqlConn.Close()
            MessageBox.Show("recharge successful! ")
        Catch ex As Exception
            MessageBox.Show("recharge cannot be completed")
            Me.Hide()
            UserForm1.Show()
        End Try

    End Sub
End Class