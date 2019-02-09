Imports MySql.Data.MySqlClient
Public Class RegForm3
    Dim y As Integer = 0
    Dim uid As Integer = 0
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PictureBox1.Hide()

    End Sub
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

        Dim MysqlConn As MySqlConnection
        MysqlConn = New MySqlConnection
        Dim MyCom As MySqlCommand
        Dim reader As MySqlDataReader
        Try
            MysqlConn.ConnectionString = "server='" & Form1.TextBox4.Text & "';userid=root;password=root;database=user_data"
            MysqlConn.Open()
            Dim query As String

            'counting the number of entries in the table
            query = "Select count(*) from user_data.user_table"
            MyCom = New MySqlCommand(query, MysqlConn)
            reader = MyCom.ExecuteReader()
            reader.Read()
            uid = reader("count(*)")
            MysqlConn.Close()

            'inserting into database
            MysqlConn.Open()
            query = "insert into user_data.user_table(UID,UserName,Password,Phone,email,City,Gender,Occupation,name,approved,ISP,balance) values ('" & uid & "', '" & TextBox1.Text & "','" & TextBox2.Text & "', '" & RegForm1.TextBox3.Text & "', '" & RegForm1.TextBox2.Text & "', '" & RegForm2.TextBox2.Text & "','" & RegForm2.ComboBox1.Text & "', '" & RegForm2.TextBox3.Text & "','" & RegForm1.TextBox1.Text & "','" & 0 & "','" & RegForm1.ComboBox1.Text & "',50) "
            MyCom = New MySqlCommand(query, MysqlConn)
            reader = MyCom.ExecuteReader()
            MessageBox.Show("request Sent to Admin")

            'restart the application again
            Application.Restart()
            MysqlConn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Form1.Show()
    End Sub


    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = False Then
            TextBox2.PasswordChar = "*"
            TextBox3.PasswordChar = "*"
        Else
            TextBox2.PasswordChar = ""
            TextBox3.PasswordChar = ""
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

        Dim MysqlConn As MySqlConnection
        MysqlConn = New MySqlConnection
        Dim MyCom As MySqlCommand
        Dim reader As MySqlDataReader
        Try
            MysqlConn.ConnectionString = "server='" & Form1.TextBox4.Text & "';userid=root;password=root;database=user_data"
            MysqlConn.Open()
            Dim query As String
            Dim count As Integer = 0
            'counting the number of entries in the table
            query = "Select * from user_data.user_table where userName = '" & TextBox1.Text & "'"
            MyCom = New MySqlCommand(query, MysqlConn)
            reader = MyCom.ExecuteReader()
            While reader.Read
                count = count + 1
            End While
            If count = 0 Then
                Label4.Text = ""
            Else
                Label4.Text = "username already taken"
                PictureBox1.Hide()
            End If
            MysqlConn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        If TextBox1.TextLength <> 0 And TextBox2.TextLength <> 0 And TextBox3.TextLength <> 0 Then
            If TextBox2.Text = TextBox3.Text And Label4.Text.Length = 0 Then
                PictureBox1.Show()
            Else
                PictureBox1.Hide()
            End If
        Else
            PictureBox1.Hide()
        End If

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        If TextBox2.TextLength = 0 Then
            TextBox3.Hide()
            PictureBox1.Hide()
        Else
            TextBox3.Show()
        End If


        If TextBox1.TextLength <> 0 And TextBox2.TextLength <> 0 And TextBox3.TextLength <> 0 Then
            If TextBox2.Text = TextBox3.Text And Label4.Text.Length = 0 Then
                PictureBox1.Show()
            Else
                PictureBox1.Hide()
            End If
        Else
            PictureBox1.Hide()
        End If

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

        If TextBox1.TextLength <> 0 And TextBox2.TextLength <> 0 And TextBox3.TextLength <> 0 Then
            If TextBox2.Text = TextBox3.Text And Label4.Text.Length = 0 Then
                PictureBox1.Show()
            Else
                PictureBox1.Hide()
            End If
        Else
            PictureBox1.Hide()
        End If

    End Sub

    'Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
    '   If Label4.Text.Length = 0 Then
    '    PictureBox1.Hide()
    ' End If
    ' End Sub
End Class