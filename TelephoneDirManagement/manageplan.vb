Imports MySql.Data.MySqlClient
Public Class manageplan
    Dim MySqlConn As MySqlConnection
    Dim mycom As MySqlCommand
    Dim dbDataSet As New DataTable
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        MySqlConn = New MySqlConnection
        MySqlConn.ConnectionString = "server=localhost;userid=root;password=root;database=user_data"
        Dim READER As MySqlDataReader
        If TextBox1.Text = "" And TextBox2.Text = "" And TextBox3.Text = "" And TextBox4.Text = "" And TextBox5.Text = "" And TextBox6.Text = "" And TextBox7.Text = "" Then
            MessageBox.Show("Please enter all the fields!")
        Else

            Try
                MySqlConn.Open()
                Dim Query As String
                Query = "update user_data.plans set ID='" & TextBox1.Text & "', ServiceProvider='" & TextBox2.Text & "', Type='" & TextBox3.Text & "', Nature='" & TextBox4.Text & "', Price='" & TextBox5.Text & "', Details='" & TextBox6.Text & "', Validity='" & TextBox7.Text & "' where ID='" & TextBox1.Text & "'"
                mycom = New MySqlCommand(Query, MySqlConn)
                READER = mycom.ExecuteReader
                MessageBox.Show("Data Updated")
                MySqlConn.Close()
            Catch ex As MySqlException
                MessageBox.Show(ex.Message)
            Finally
                MySqlConn.Dispose()
            End Try
        End If

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Application.Restart()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        adminhome.Show()
        Me.Hide()
    End Sub
    Private Sub load_table()
        MySqlConn = New MySqlConnection
        MySqlConn.ConnectionString = "server=localhost;userid=root;password=root;database=user_data"
        Dim SDA As New MySqlDataAdapter
        Dim bSource As New BindingSource
        Try
            MySqlConn.Open()
            Dim Query As String
            Query = "select * from user_data.plans"
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

    Private Sub manageplan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_table()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        MySqlConn = New MySqlConnection
        MySqlConn.ConnectionString = "server=localhost;userid=root;password=root;database=user_data"
        Dim SDA As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim bSource As New BindingSource
        Try
            MySqlConn.Open()
            Dim Query As String
            Query = "select * from user_data.plans"
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

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow
            row = Me.DataGridView1.Rows(e.RowIndex)

            TextBox1.Text = row.Cells("ID").Value.ToString
            TextBox2.Text = row.Cells("ServiceProvider").Value.ToString
            TextBox3.Text = row.Cells("Type").Value.ToString
            TextBox4.Text = row.Cells("Nature").Value.ToString
            TextBox5.Text = row.Cells("Price").Value.ToString
            TextBox6.Text = row.Cells("Details").Value.ToString
            TextBox7.Text = row.Cells("Validity").Value.ToString
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MySqlConn = New MySqlConnection
        MySqlConn.ConnectionString = "server=localhost;userid=root;password=root;database=user_data"
        Dim READER As MySqlDataReader
        If TextBox1.Text = "" And TextBox2.Text = "" And TextBox3.Text = "" And TextBox4.Text = "" And TextBox5.Text = "" And TextBox6.Text = "" And TextBox7.Text = "" Then
            MessageBox.Show("Please enter all the fields!")
        Else

            Try
                MySqlConn.Open()
                Dim Query As String
                Query = "insert into user_data.plans (ID,ServiceProvider,Type,Nature,Price,Details,Validity) values ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & TextBox7.Text & "')"
                mycom = New MySqlCommand(Query, MySqlConn)
                READER = mycom.ExecuteReader
                MessageBox.Show("Data Saved")
                MySqlConn.Close()
            Catch ex As MySqlException
                MessageBox.Show(ex.Message)
            Finally
                MySqlConn.Dispose()
            End Try
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MySqlConn = New MySqlConnection
        MySqlConn.ConnectionString = "server=localhost;userid=root;password=root;database=user_data"
        Dim READER As MySqlDataReader
        If TextBox1.Text = "" And TextBox2.Text = "" And TextBox3.Text = "" And TextBox4.Text = "" And TextBox5.Text = "" And TextBox6.Text = "" And TextBox7.Text = "" Then
            MessageBox.Show("Please enter all the fields!")
        Else

            Try
                MySqlConn.Open()
                Dim Query As String
                Query = "Delete from user_data.plans where ID='" & TextBox1.Text & "'"
                mycom = New MySqlCommand(Query, MySqlConn)
                READER = mycom.ExecuteReader
                MessageBox.Show("Data Deleted")
                MySqlConn.Close()
            Catch ex As MySqlException
                MessageBox.Show(ex.Message)
            Finally
                MySqlConn.Dispose()
            End Try
        End If

    End Sub
End Class