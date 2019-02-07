Imports MySql.Data.MySqlClient
Public Class updatePassword
    Private Sub updatePassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox2.Hide()
        TextBox3.Hide()
        Label2.Hide()
        Label3.Hide()
        Button1.Hide()
    End Sub
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

        If TextBox1.Text = Form1.TextBox2.Text Then
            TextBox2.Show()
            TextBox3.Show()
            Label2.Show()
            Label3.Show()
        Else
            TextBox2.Hide()
            TextBox3.Hide()
            Label2.Hide()
            Label3.Hide()
        End If
        If TextBox1.TextLength <> 0 And TextBox2.TextLength <> 0 And TextBox3.TextLength <> 0 Then
            If TextBox2.Text = TextBox3.Text Then
                Button1.Show()
            Else
                Button1.Hide()
            End If
        Else
            Button1.Hide()
        End If
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim MysqlConn As MySqlConnection
        MysqlConn = New MySqlConnection
        Dim MyCom As MySqlCommand
        Dim reader As MySqlDataReader
        Try
            MysqlConn.ConnectionString = "server='" & Form1.TextBox4.Text & "';userid=root;password=root;database=user_data"
            MysqlConn.Open()
            Dim query As String

            'counting the number of entries in the table
            query = "UPDATE user_data.user_table SET Password= '" & TextBox2.Text & "' where userName ='" & Form1.TextBox1.Text & "';"
            MyCom = New MySqlCommand(query, MysqlConn)
            reader = MyCom.ExecuteReader()

            MysqlConn.Close()
            MessageBox.Show("PASSWORD UPDATED SUCCESSFULLY ! LOGIN AGAIN")
            Me.Hide()
            Application.Restart()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        If TextBox1.TextLength <> 0 And TextBox2.TextLength <> 0 And TextBox3.TextLength <> 0 Then
            If TextBox2.Text = TextBox3.Text Then
                Button1.Show()
            Else
                Button1.Hide()
            End If
        Else
            Button1.Hide()
        End If
    End Sub



    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = False Then
            TextBox1.PasswordChar = "*"
            TextBox2.PasswordChar = "*"
            TextBox3.PasswordChar = "*"
        Else
            TextBox1.PasswordChar = ""
            TextBox2.PasswordChar = ""
            TextBox3.PasswordChar = ""
        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        Form1.Show()
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        If TextBox1.TextLength <> 0 And TextBox2.TextLength <> 0 And TextBox3.TextLength <> 0 Then
            If TextBox2.Text = TextBox3.Text Then
                Button1.Show()
            Else
                Button1.Hide()
            End If
        Else
            Button1.Hide()
        End If
    End Sub
End Class