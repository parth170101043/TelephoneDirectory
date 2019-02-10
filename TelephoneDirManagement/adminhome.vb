Imports MySql.Data.MySqlClient
Public Class adminhome

    Dim MySqlConn As MySqlConnection
    Dim mycom As MySqlCommand
    Dim dbDataSet As New DataTable

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Application.Restart()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        manageuser.Show()
        Me.Hide()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        manageplan.Show()
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        pendingapproval.Show()
        Me.Close()
    End Sub
    Private Sub load_table()
        MySqlConn = New MySqlConnection
        MySqlConn.ConnectionString = "server=localhost;userid=root;password=root;database=user_data"
        Dim SDA As New MySqlDataAdapter

        Dim bSource As New BindingSource
        Try
            MySqlConn.Open()
            Dim Query As String
            Query = "select Name,Phone,Email,City from user_data.user_table where Approved='1'"
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

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        MySqlConn = New MySqlConnection
        MySqlConn.ConnectionString = "server=localhost;userid=root;password=root;database=user_data"
        Dim SDA As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim bSource As New BindingSource
        Try
            MySqlConn.Open()
            Dim Query As String
            Query = "select Name,Phone,Email,City from user_data.user_table where Approved='1'"
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

    Public Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_table()
        MySqlConn = New MySqlConnection
        MySqlConn.ConnectionString = "server=localhost;userid=root;password=root;database=user_data"
        Try
            MySqlConn.Open()
            Dim query As String
            query = "Select * from user_data.user_table where Approved='0'"
            mycom = New MySqlCommand(query, MySqlConn)
            Dim reader As MySqlDataReader
            reader = mycom.ExecuteReader()
            Dim count As Integer = 0
            While reader.Read
                count = count + 1
            End While
            If count >= 1 Then
                Label4.Visible = True
                Button6.Visible = True
                Button7.Visible = True
            Else
                Label4.Visible = False
                Button6.Visible = False
                Button7.Visible = False
            End If
            MySqlConn.Close()

        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim DV As New DataView(dbDataSet)
        DV.RowFilter = String.Format("Name Like '" & TextBox1.Text & "%'")
        DataGridView1.DataSource = DV
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        pendingapproval.Show()
        Me.Hide()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Button6.Visible = False
        Label4.Visible = False
        Button7.Visible = False
    End Sub
End Class