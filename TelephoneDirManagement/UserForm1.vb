Imports MySql.Data.MySqlClient
Public Class UserForm1
    Private Sub bus_Click(sender As Object, e As EventArgs)
        UserForm2.Show()
        Me.Hide()
    End Sub

    Private Sub UserForm1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = Label1.Text + Form1.TextBox1.Text
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Application.Restart()

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Hide()
        Form5.Show()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button7_Click_1(sender As Object, e As EventArgs) Handles Button7.Click
        Me.Hide()
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

            If IsDBNull(reader("DataISP")) Then
                myplans.TextBox3.Text = ""
            Else
                myplans.TextBox3.Text = reader("DataISP")
            End If


            If IsDBNull(reader("DataPlan")) Then
                myplans.TextBox6.Text = "(No Current Plans)"
            Else
                myplans.TextBox6.Text = reader("DataPlan")
            End If


            If IsDBNull(reader("CallISP")) Then
                myplans.TextBox10.Text = ""
            Else
                myplans.TextBox10.Text = reader("CallISP")
            End If
            If IsDBNull(reader("Price")) Then
                myplans.TextBox11.Text = ""
            Else
                myplans.TextBox11.Text = reader("Price")
            End If
            MysqlConn.Close()
        Catch ex As Exception

        End Try
        myplans.Show()
    End Sub
End Class