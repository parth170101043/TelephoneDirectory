Imports MySql.Data.MySqlClient
Public Class Form5
    Dim noval As String = "!~`#$%^&*()_-+=/*<>.,?;:0123465789"
    Dim noval1 As String = ".+-="
    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            TextBox1.Text = reader("Name")
            TextBox2.Text = reader("UserName")


            If IsDBNull(reader("DataISP")) Then
                TextBox3.Text = ""
            Else
                TextBox3.Text = reader("DataISP")
            End If


            If IsDBNull(reader("City")) Or reader("city") = "" Then
                TextBox4.Text = "(No User Data Available)"
            Else
                TextBox4.Text = reader("City")
            End If


            If IsDBNull(reader("Gender")) Or reader("Gender") = "" Then
                TextBox5.Text = "(No User Data Available)"
            Else
                TextBox5.Text = reader("Gender")
            End If
            If IsDBNull(reader("DataPlan")) Then
                TextBox6.Text = "(No Current Plans)"
            Else
                TextBox6.Text = reader("DataPlan")
            End If


            TextBox7.Text = reader("email")


            If IsDBNull(reader("Occupation")) Or reader("Occupation") = "" Then
                TextBox8.Text = "(No User Data Available)"
            Else
                TextBox8.Text = reader("Occupation")
            End If
            TextBox9.Text = reader("phone")
            ' TextBox10.Text = reader("CallISP")
            '   TextBox11.Text = reader("Price")

            If IsDBNull(reader("CallISP")) Then
                TextBox10.Text = ""
            Else
                TextBox10.Text = reader("CallISP")
            End If
            If IsDBNull(reader("Price")) Then
                TextBox11.Text = ""
            Else
                TextBox11.Text = reader("Price")
            End If
            MysqlConn.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Function IsValidFileNameOrPath(ByVal name As String, ByVal str1 As String) As Boolean '''''for name
        ' Determines if the name is Nothing.
        If name Is Nothing Then
            Return False
        End If

        ' Determines if there are bad characters in the name.
        For Each badChar As Char In str1
            If InStr(name, badChar) > 0 Then
                Return False
            End If
        Next

        ' The name passes basic validation.
        Return True
    End Function
    Private Sub Button2_Click(sender As Object, e As EventArgs)

        Me.Hide()
        updatePassword.Show()

        updatePassword.TextBox1.Text = ""
        updatePassword.TextBox2.Text = ""
        updatePassword.TextBox3.Text = ""
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)


        Dim MysqlConn As MySqlConnection
        MysqlConn = New MySqlConnection
        Dim MyCom As MySqlCommand
        Dim reader As MySqlDataReader
        Try
            MysqlConn.ConnectionString = "server='" & Form1.TextBox4.Text & "';userid=root;password=root;database=user_data"
            MysqlConn.Open()
            Dim query As String

            'counting the number of entries in the table
            query = "UPDATE user_data.user_table SET email= '" & TextBox7.Text & "',Occupation= '" & TextBox8.Text & "', Phone ='" & TextBox9.Text & "' where userName ='" & Form1.TextBox1.Text & "';"
            MyCom = New MySqlCommand(query, MysqlConn)
            reader = MyCom.ExecuteReader()

            MysqlConn.Close()
            MessageBox.Show("Changes Saved")
            Me.Hide()
            Form1.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs)
        If IsValidFileNameOrPath(TextBox8.Text, noval) Then
            Button1.Show()
        Else
            Button1.Hide()
            '    Label6.Text = "Invalid Occupation"
        End If
    End Sub

    Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs)
        If IsValidFileNameOrPath(TextBox9.Text, noval1) Then
            Button1.Show()
        Else
            Button1.Hide()
            '  Label6.Text = "Invalid PhoneNo."
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Dim MysqlConn As MySqlConnection
        MysqlConn = New MySqlConnection
        Dim MyCom As MySqlCommand
        Dim reader As MySqlDataReader
        Try
            MysqlConn.ConnectionString = "server='" & Form1.TextBox4.Text & "';userid=root;password=root;database=user_data"
            MysqlConn.Open()
            Dim query As String

            'counting the number of entries in the table
            query = "UPDATE user_data.user_table SET DataISP = '" & TextBox3.Text & "',DataPlan = '" & TextBox6.Text & "', CallISP ='" & TextBox10.Text & "' , Price = '" & TextBox11.Text & "' where userName ='" & Form1.TextBox1.Text & "' "
            MyCom = New MySqlCommand(query, MysqlConn)
            reader = MyCom.ExecuteReader()

            MysqlConn.Close()
            MessageBox.Show("Changes Saved")
            Me.Hide()
            UserForm1.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        UserForm1.Show()
    End Sub


    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        updatePassword.Show()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub
End Class