Imports MySql.Data.MySqlClient
Public Class pendingapproval
 
    Dim MySqlConn As MySqlConnection
    Dim mycom As MySqlCommand
    Dim dbDataSet As New DataTable
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        adminhome.Show()

        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.Show()
        Me.Hide()
    End Sub
    Private Sub load_table()
        MySqlConn = New MySqlConnection
        MySqlConn.ConnectionString = "server='" & Form1.TextBox4.Text & "';userid=root;password=root;database=user_data"
        Dim SDA As New MySqlDataAdapter
        Dim bSource As New BindingSource
        Try
            MySqlConn.Open()
            Dim Query As String
            Query = "select UID,Name,UserName,Phone,Email, City, Gender, Occupation from user_data.user_table where Approved = '0'"
            mycom = New MySqlCommand(Query, MySqlConn)
            SDA.SelectCommand = mycom
            SDA.Fill(dbDataSet)
            bSource.DataSource = dbDataSet
            DataGridView1.DataSource = bSource
            SDA.Update(dbDataSet)
            MySqlConn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            MySqlConn.Dispose()
        End Try
    End Sub

    Private Sub pendingapproval_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_table()
    End Sub



    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        MySqlConn = New MySqlConnection
        MySqlConn.ConnectionString = "server='" & Form1.TextBox4.Text & "';userid=root;password=root;database=user_data"
        Dim READER As MySqlDataReader
        If TextBox1.Text = "" And TextBox2.Text = "" And TextBox3.Text = "" And TextBox4.Text = "" And TextBox5.Text = "" And TextBox6.Text = "" And TextBox7.Text = "" Then
            MessageBox.Show("Please enter all the fields!")
        Else

            Try
                MySqlConn.Open()
                Dim Query As String
                Query = "Delete from user_data.user_table where UID='" & TextBox1.Text & "'"
                mycom = New MySqlCommand(Query, MySqlConn)
                READER = mycom.ExecuteReader
                MessageBox.Show("Data Deleted")
                TextBox1.Clear()
                TextBox2.Clear()
                TextBox3.Clear()
                TextBox4.Clear()
                TextBox5.Clear()
                TextBox6.Clear()
                TextBox7.Clear()
                MySqlConn.Close()
                MySqlConn = New MySqlConnection
                MySqlConn.ConnectionString = "server='" & Form1.TextBox4.Text & "';userid=root;password=root;database=user_data"
                Dim SDA As New MySqlDataAdapter
                Dim dbDataSet As New DataTable
                Dim bSource As New BindingSource
                Try
                    MySqlConn.Open()
                    'Dim Query As String
                    Query = "select UID,Name,UserName,Phone,Email, City, Gender, Occupation from user_data.user_table where Approved='0'"
                    mycom = New MySqlCommand(Query, MySqlConn)
                    SDA.SelectCommand = mycom
                    SDA.Fill(dbDataSet)
                    bSource.DataSource = dbDataSet
                    DataGridView1.DataSource = bSource
                    SDA.Update(dbDataSet)
                    MySqlConn.Close()
                Catch ex As MySqlException
                    MessageBox.Show(ex.Message)
                Finally
                    MySqlConn.Dispose()
                End Try
            Catch ex As MySqlException
                MessageBox.Show(ex.Message)
            Finally
                MySqlConn.Dispose()
            End Try
        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        MySqlConn = New MySqlConnection
        MySqlConn.ConnectionString = "server='" & Form1.TextBox4.Text & "';userid=root;password=root;database=user_data"
        Dim READER As MySqlDataReader
        If TextBox1.Text = "" And TextBox2.Text = "" And TextBox3.Text = "" And TextBox4.Text = "" And TextBox5.Text = "" And TextBox6.Text = "" And TextBox7.Text = "" Then
            MessageBox.Show("Please enter all the fields!")
        Else

            Try
                MySqlConn.Open()
                Dim Query As String
                Query = "update user_data.user_table set Approved='1' where UID='" & TextBox1.Text & "'"
                mycom = New MySqlCommand(Query, MySqlConn)
                READER = mycom.ExecuteReader
                MessageBox.Show("Data Updated")
                TextBox1.Clear()
                TextBox2.Clear()
                TextBox3.Clear()
                TextBox4.Clear()
                TextBox5.Clear()
                TextBox6.Clear()
                TextBox7.Clear()
                MySqlConn.Close()
                MySqlConn = New MySqlConnection
                MySqlConn.ConnectionString = "server='" & Form1.TextBox4.Text & "';userid=root;password=root;database=user_data"
                Dim SDA As New MySqlDataAdapter
                Dim dbDataSet As New DataTable
                Dim bSource As New BindingSource
                Try
                    MySqlConn.Open()
                    'Dim Query As String
                    Query = "select UID,Name,UserName,Phone,Email, City, Gender, Occupation from user_data.user_table where Approved='0'"
                    mycom = New MySqlCommand(Query, MySqlConn)
                    SDA.SelectCommand = mycom
                    SDA.Fill(dbDataSet)
                    bSource.DataSource = dbDataSet
                    DataGridView1.DataSource = bSource
                    SDA.Update(dbDataSet)
                    MySqlConn.Close()
                Catch ex As MySqlException
                    MessageBox.Show(ex.Message)
                Finally
                    MySqlConn.Dispose()
                End Try
            Catch ex As MySqlException
                MessageBox.Show(ex.Message)
            Finally
                MySqlConn.Dispose()
            End Try
        End If
    End Sub


    Private Sub DataGridView1_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.RowEnter
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow
            row = Me.DataGridView1.Rows(e.RowIndex)
            TextBox1.Text = row.Cells("UID").Value.ToString
            TextBox2.Text = row.Cells("Name").Value.ToString
            TextBox3.Text = row.Cells("Phone").Value.ToString
            TextBox4.Text = row.Cells("Email").Value.ToString
            TextBox5.Text = row.Cells("City").Value.ToString
            TextBox6.Text = row.Cells("Gender").Value.ToString
            TextBox7.Text = row.Cells("Occupation").Value.ToString
        End If
    End Sub

    
End Class