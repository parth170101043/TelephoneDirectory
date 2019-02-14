Imports MySql.Data.MySqlClient
Public Class myplans
    
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        UserForm1.Show()

    End Sub


    Private Sub myplans_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim MysqlConn As MySqlConnection
        MysqlConn = New MySqlConnection
        Dim MyCom As MySqlCommand
        Dim reader As MySqlDataReader
        Try
            MysqlConn.ConnectionString = "server='" & Form1.TextBox4.Text & "';userid=root;password=root;database=user_data"
            MysqlConn.Open()
            Dim query As String


            query = "Select * from user_data.user_table where userName='" & Form1.TextBox1.Text & "'"
            MyCom = New MySqlCommand(query, MysqlConn)
            reader = MyCom.ExecuteReader()
            reader.Read()

            If IsDBNull(reader("ISP")) Then
                TextBox3.Text = ""
            Else
                TextBox3.Text = reader("ISP")
            End If


            If IsDBNull(reader("DataPlan")) Then
                TextBox6.Text = "(No Current Plans)"
            Else
                TextBox6.Text = reader("DataPlan")
            End If


            If IsDBNull(reader("ISP")) Then
                TextBox10.Text = ""
            Else
                TextBox10.Text = reader("ISP")
            End If
            If IsDBNull(reader("Price")) Then
                TextBox11.Text = ""
            Else
                TextBox11.Text = reader("Price")
            End If
            MysqlConn.Close()
        Catch ex As Exception

        End Try

    End Sub

End Class