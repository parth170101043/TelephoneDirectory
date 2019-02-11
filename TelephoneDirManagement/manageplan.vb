Imports MySql.Data.MySqlClient
Public Class manageplan
    Dim MySqlConn As MySqlConnection
    Dim mycom As MySqlCommand
    Dim dbDataSet As New DataTable
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        MySqlConn = New MySqlConnection
        MySqlConn.ConnectionString = "server='" & Form1.TextBox4.Text & "';userid=root;password=root;database=user_data"
        Dim READER As MySqlDataReader
        If TextBox1.Text = "" And ComboBox2.Text = "" And ComboBox1.Text = "" And TextBox5.Text = "" And TextBox6.Text = "" And TextBox7.Text = "" Then
            MessageBox.Show("Please enter all the fields!")
        Else

            Try
                Dim count As Integer = 0
                Dim Query As String
                MySqlConn.Open()
                Query = "select count(*) from user_data.user_table where planid_t = '" & TextBox1.Text & "' or planid_d ='" & TextBox1.Text & "' "
                mycom = New MySqlCommand(Query, MySqlConn)
                READER = mycom.ExecuteReader
                READER.Read()
                count = READER("count(*)")
                MySqlConn.Close()
                If count = 0 Then
                    MySqlConn.Open()

                    Query = "update user_data.plans set ID='" & TextBox1.Text & "', ServiceProvider='" & ComboBox2.Text & "', Type='" & ComboBox1.Text & "', Price='" & TextBox5.Text & "', Details='" & TextBox6.Text & "', Validity='" & TextBox7.Text & "' where ID='" & TextBox1.Text & "'"
                    mycom = New MySqlCommand(Query, MySqlConn)
                    READER = mycom.ExecuteReader
                    MessageBox.Show("Data Updated")
                    TextBox1.Clear()
                    ComboBox2.Text = ""
                    ComboBox1.Text = ""
                    'TextBox4.Clear()
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
                Else
                    MessageBox.Show("can't update! plans already in use")
                End If
               
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
        MySqlConn.ConnectionString = "server='" & Form1.TextBox4.Text & "';userid=root;password=root;database=user_data"
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



    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow
            row = Me.DataGridView1.Rows(e.RowIndex)

            TextBox1.Text = row.Cells("ID").Value.ToString
            ComboBox2.Text = row.Cells("ServiceProvider").Value.ToString
            ComboBox1.Text = row.Cells("Type").Value.ToString
            ' TextBox4.Text = row.Cells("Nature").Value.ToString
            TextBox5.Text = row.Cells("Price").Value.ToString
            TextBox6.Text = row.Cells("Details").Value.ToString
            TextBox7.Text = row.Cells("Validity").Value.ToString
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        TextBox1.Clear()
        ComboBox2.Text = ""
        ComboBox1.Text = ""
        'TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MySqlConn = New MySqlConnection
        MySqlConn.ConnectionString = "server='" & Form1.TextBox4.Text & "';userid=root;password=root;database=user_data"
        Dim READER As MySqlDataReader
        If TextBox1.Text = "" And ComboBox2.Text = "" And ComboBox1.Text = "" And TextBox5.Text = "" And TextBox6.Text = "" And TextBox7.Text = "" Then
            MessageBox.Show("Please enter all the fields!")
        Else

            Try
                MySqlConn.Open()
                Dim Query As String
                Query = "insert into user_data.plans (ID,ServiceProvider,Type,Price,Details,Validity) values ('" & TextBox1.Text & "','" & ComboBox2.Text & "','" & ComboBox1.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & TextBox7.Text & "')"
                mycom = New MySqlCommand(Query, MySqlConn)
                READER = mycom.ExecuteReader
                MessageBox.Show("Data Saved")
                TextBox1.Clear()
                ComboBox2.Text = ""
                ComboBox1.Text = ""
                'TextBox4.Clear()
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
            Catch ex As MySqlException
                MessageBox.Show(ex.Message)
            Finally
                MySqlConn.Dispose()
            End Try
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MySqlConn = New MySqlConnection
        MySqlConn.ConnectionString = "server='" & Form1.TextBox4.Text & "';userid=root;password=root;database=user_data"
        Dim READER As MySqlDataReader
        If TextBox1.Text = "" And ComboBox2.Text = "" And ComboBox1.Text = "" And TextBox5.Text = "" And TextBox6.Text = "" And TextBox7.Text = "" Then
            MessageBox.Show("Please enter all the fields!")
        Else

            Try
                Dim count As Integer = 0
                Dim Query As String
                MySqlConn.Open()
                Query = "select count(*) from user_data.user_table where planid_t = '" & TextBox1.Text & "' or planid_d ='" & TextBox1.Text & "' "
                mycom = New MySqlCommand(Query, MySqlConn)
                READER = mycom.ExecuteReader
                READER.Read()
                count = READER("count(*)")
                MySqlConn.Close()
                If count = 0 Then
                    MySqlConn.Open()
                    Query = "Delete from user_data.plans where ID='" & TextBox1.Text & "'"
                    mycom = New MySqlCommand(Query, MySqlConn)
                    READER = mycom.ExecuteReader

                    MessageBox.Show("Data Deleted")
                    TextBox1.Clear()
                    ComboBox2.Text = ""
                    ComboBox1.Text = ""
                    'TextBox4.Clear()
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
                Else
                    MessageBox.Show("plans are in use so you cant delete it")
                End If
            Catch ex As MySqlException
                MessageBox.Show(ex.Message)
            Finally
                MySqlConn.Dispose()
            End Try
        End If

    End Sub
End Class