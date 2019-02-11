Imports MySql.Data.MySqlClient
Public Class manageuser
    Dim MySqlConn As MySqlConnection
    Dim COMMAND As MySqlCommand
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        adminhome.Show()
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Application.Restart()
    End Sub

    Private Sub manageuser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MySqlConn = New MySqlConnection
        MySqlConn.ConnectionString = "server='" & Form1.TextBox4.Text & "';userid=root;password=root;database=user_data"
        Dim READER As MySqlDataReader
        Try
            MySqlConn.Open()
            Dim Query As String
            Query = "select * from user_data.user_table where Approved = '1'"
            COMMAND = New MySqlCommand(Query, MySqlConn)
            READER = COMMAND.ExecuteReader
            While READER.Read
                Dim sName = READER.GetString("Name")
                ComboBox1.Items.Add(sName)
            End While
            MySqlConn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            MySqlConn.Dispose()
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        MySqlConn = New MySqlConnection
        MySqlConn.ConnectionString = "server='" & Form1.TextBox4.Text & "';userid=root;password=root;database=user_data"
        Dim READER As MySqlDataReader
        Try
            MySqlConn.Open()
            Dim Query As String
            Query = "select * from user_data.user_table where name='" & ComboBox1.Text & "' And Approved = '1'"
            COMMAND = New MySqlCommand(Query, MySqlConn)
            READER = COMMAND.ExecuteReader
            While READER.Read
                TextBox_UID.Text = READER.GetInt32("UID")
                TextBox_Name.Text = READER.GetString("Name")
                TextBox_Phone.Text = READER("Phone")
                TextBox_Email.Text = READER.GetString("Email")
                TextBox_city.Text = READER.GetString("City")
                TextBox_Gender.Text = READER.GetString("Gender")
                TextBox_Occupation.Text = READER.GetString("Occupation")
            End While
            MySqlConn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            MySqlConn.Dispose()
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MySqlConn = New MySqlConnection
        MySqlConn.ConnectionString = "server='" & Form1.TextBox4.Text & "';userid=root;password=root;database=user_data"
        Dim READER As MySqlDataReader
        If TextBox_UID.Text = "" And TextBox_Name.Text = "" And TextBox_Phone.Text = "" And TextBox_Email.Text = "" And TextBox_city.Text = "" And TextBox_Gender.Text = "" And TextBox_Occupation.Text = "" Then
            MessageBox.Show("Please enter all the fields!")

        Else
            Try
                MySqlConn.Open()
                Dim Query As String
                Query = "update user_data.user_table set UID='" & TextBox_UID.Text & "', Name='" & TextBox_Name.Text & "', Phone='" & TextBox_Phone.Text & "', Email='" & TextBox_Email.Text & "', City='" & TextBox_city.Text & "', Gender='" & TextBox_Gender.Text & "', Occupation='" & TextBox_Occupation.Text & "' where UID='" & TextBox_UID.Text & "'"
                COMMAND = New MySqlCommand(Query, MySqlConn)
                READER = COMMAND.ExecuteReader
                MessageBox.Show("Data Updated")
                MySqlConn.Close()
            Catch ex As MySqlException
                MessageBox.Show(ex.Message)
            Finally
                MySqlConn.Dispose()
            End Try
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MySqlConn = New MySqlConnection
        MySqlConn.ConnectionString = "server='" & Form1.TextBox4.Text & "';userid=root;password=root;database=user_data"
        Dim READER As MySqlDataReader
        If TextBox_UID.Text = "" And TextBox_Name.Text = "" And TextBox_Phone.Text = "" And TextBox_Email.Text = "" And TextBox_city.Text = "" And TextBox_Gender.Text = "" And TextBox_Occupation.Text = "" Then
            MessageBox.Show("Please enter all the fields!")

        Else
            Try
                MySqlConn.Open()
                Dim Query As String
                Query = "Delete from user_data.user_table where UID='" & TextBox_UID.Text & "'"
                COMMAND = New MySqlCommand(Query, MySqlConn)
                READER = COMMAND.ExecuteReader
                MessageBox.Show("Data Deleted")
                MySqlConn.Close()
            Catch ex As MySqlException
                MessageBox.Show(ex.Message)
            Finally
                MySqlConn.Dispose()
            End Try
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        TextBox_UID.Clear()
        TextBox_Name.Clear()
        TextBox_Phone.Clear()
        TextBox_Email.Clear()
        TextBox_city.Clear()
        TextBox_Gender.Clear()
        TextBox_Occupation.Clear()
    End Sub
End Class