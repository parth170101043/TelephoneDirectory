Imports MySql.Data.MySqlClient
Public Class history

    Private Sub history_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim MysqlConn As MySqlConnection
            MysqlConn = New MySqlConnection
            Dim MyCom As MySqlCommand
            Dim reader As MySqlDataReader
            Dim total As Integer = 0
            MysqlConn.ConnectionString = "server='" & Form1.TextBox4.Text & "';userid=root;password=root;database=user_data"
            Dim query As String
            MysqlConn.Open()
            query = "select count(*) from user_data.history where UID = '" & UserForm1.Label7.Text & "' "
            MyCom = New MySqlCommand(query, MysqlConn)
            reader = MyCom.ExecuteReader()
            reader.Read()
            total = reader("count(*)")
            MysqlConn.Close()
            MysqlConn.Open()
            Dim SDA As New MySqlDataAdapter
            Dim dbdataset As New DataTable
            Dim bsource As New BindingSource
            query = "select Amount,Date from user_data.history where UID = '" & UserForm1.Label7.Text & "'"
            MyCom = New MySqlCommand(query, MysqlConn)
            SDA.SelectCommand = MyCom
            SDA.Fill(dbdataset)
            bsource.DataSource = dbdataset
            DataGridView1.DataSource = bsource
            SDA.Update(dbdataset)
            MysqlConn.Close()
            Label2.Text = "LAST " + CStr(total) + " TRANSACTIONS"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        UserForm1.Show()
    End Sub
End Class