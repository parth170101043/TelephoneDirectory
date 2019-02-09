Imports MySql.Data.MySqlClient
Public Class confirm

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If browseplan.Label1.Text = "d" Then
            Dim MysqlConn As MySqlConnection
            MysqlConn = New MySqlConnection
            Dim MyCom As MySqlCommand
            Dim bal As Integer
            Dim price As Integer
            Dim reader As MySqlDataReader
            Dim transaction As Integer = 0
            Try
                MysqlConn.ConnectionString = "server='" & Form1.TextBox4.Text & "';userid=root;password=root;database=user_data"
                MysqlConn.Open()
                Dim query As String


                query = "Select * from user_data.user_table where userName='" & Form1.TextBox1.Text & "'"
                MyCom = New MySqlCommand(query, MysqlConn)
                reader = MyCom.ExecuteReader()
                reader.Read()
                bal = reader("balance")
                price = browseplan.TextBox6.Text

                If price > bal Then
                    MessageBox.Show("INSUFFICIENT BALANCE")
                    Me.Hide()
                    UserForm1.Show()
                Else
                    bal = bal - price
                    transaction = 1
                End If
                MysqlConn.Close()
                MysqlConn.Open()

                'updating the balance and dataplan
                query = "UPDATE user_data.user_table SET balance = '" & bal & "', DataPlan='" & price & "' where userName ='" & Form1.TextBox1.Text & "';"
                MyCom = New MySqlCommand(query, MysqlConn)
                reader = MyCom.ExecuteReader()
                If (transaction = 1) Then
                    MessageBox.Show("transaction complete! Please Login Again")
                    Application.Restart()

                End If
                MysqlConn.Close()
            Catch ex As Exception
            End Try
        ElseIf browseplan.Label1.Text = "c" Then
            Dim MysqlConn As MySqlConnection
            MysqlConn = New MySqlConnection
            Dim MyCom As MySqlCommand
            Dim bal As Integer
            Dim price As Integer
            Dim reader As MySqlDataReader
            Dim transaction As Integer = 0
            Try
                MysqlConn.ConnectionString = "server='" & Form1.TextBox4.Text & "';userid=root;password=root;database=user_data"
                MysqlConn.Open()
                Dim query As String


                query = "Select * from user_data.user_table where userName='" & Form1.TextBox1.Text & "'"
                MyCom = New MySqlCommand(query, MysqlConn)
                reader = MyCom.ExecuteReader()
                reader.Read()
                bal = reader("balance")
                price = browseplan.TextBox11.Text

                If price > bal Then
                    MessageBox.Show("INSUFFICIENT BALANCE")
                    Me.Hide()
                    UserForm1.Show()
                Else
                    bal = bal - price
                    transaction = 1
                End If
                MysqlConn.Close()
                MysqlConn.Open()

                'updating the balance and dataplan
                query = "UPDATE user_data.user_table SET balance = '" & bal & "', Price='" & price & "' where userName ='" & Form1.TextBox1.Text & "';"
                MyCom = New MySqlCommand(query, MysqlConn)
                reader = MyCom.ExecuteReader()
                If (transaction = 1) Then
                    MessageBox.Show("transaction complete! Please Login Again")
                    Application.Restart()

                End If
                MysqlConn.Close()
            Catch ex As Exception
            End Try
        Else

        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        UserForm1.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        myplans.Show()
    End Sub
End Class