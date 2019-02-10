Imports MySql.Data.MySqlClient
Public Class contact_us

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim MysqlConn As MySqlConnection
        MysqlConn = New MySqlConnection
        Dim MyCom As MySqlCommand
        Dim reader As MySqlDataReader
        Dim str As String = ""
        Try
            MysqlConn.ConnectionString = "server='" & Form1.TextBox4.Text & "';userid=root;password=root;database=user_data"
            MysqlConn.Open()
            Dim query As String

            'counting the number of entries in the table
            query = "insert into user_data.contactadmin(UID,Problem,Reply) values('" & UserForm1.Label7.Text & "','" & TextBox1.Text & "','" & str & "');"
            MyCom = New MySqlCommand(query, MysqlConn)
            reader = MyCom.ExecuteReader()

            MysqlConn.Close()
            MessageBox.Show("query sent")
            TextBox1.Clear()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        UserForm1.Show()
        Me.Hide()
    End Sub
End Class