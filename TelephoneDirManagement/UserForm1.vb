Imports MySql.Data.MySqlClient
Public Class UserForm1
    Dim Red, Blue, Green, Yellow As String
   
    Private Sub bus_Click(sender As Object, e As EventArgs)
        UserForm2.Show()
        Me.Hide()
    End Sub

    Private Sub UserForm1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Timer1.Enabled = True
        ' Timer1.Start()
        Panel1.BackColor = Color.Transparent
        Label1.Text = Label1.Text + Form1.TextBox1.Text

        Try
            Dim MysqlConn As MySqlConnection
            MysqlConn = New MySqlConnection
            Dim MyCom As MySqlCommand
            Dim planid_d As Integer = 0
            Dim planid_t As Integer = 0
            Dim reader As MySqlDataReader

            MysqlConn.ConnectionString = "server='" & Form1.TextBox4.Text & "';userid=root;password=root;database=user_data"
            MysqlConn.Open()
            Dim query As String


            query = "Select * from user_data.user_table where userName='" & Form1.TextBox1.Text & "'"
            MyCom = New MySqlCommand(query, MysqlConn)
            reader = MyCom.ExecuteReader()
            reader.Read()
            Label2.Text = Label2.Text + CStr(reader("Balance"))
            Label4.Text = reader("ISP")
            Label7.Text = reader("UID")
            If IsDBNull(reader("planid_d")) = False Then
                planid_d = reader("planid_d")
            Else
                planid_d = -1
            End If
            If IsDBNull(reader("planid_t")) = False Then
                planid_t = reader("planid_t")
            Else
                planid_t = -1
            End If



            ' Console.Write(CStr(planid_d))
            '  Console.Write(CStr(planid_t))

            MysqlConn.Close()
            MysqlConn.Open()
            If planid_d >= 0 Then
                query = "select * from user_data.plans where ID = '" & planid_d & "'"
                MyCom = New MySqlCommand(query, MysqlConn)
                reader = MyCom.ExecuteReader()
                reader.Read()
                TextBox1.Text = reader("details")
                reader.Close()
            End If

            If planid_t >= 0 Then
                query = "select * from user_data.plans where ID = '" & planid_t & "'"
                MyCom = New MySqlCommand(query, MysqlConn)
                reader = MyCom.ExecuteReader()
                reader.Read()
                TextBox2.Text = reader("details")
                reader.Close()
            End If

            MysqlConn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
      
       

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




    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        browseplan.Show()
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        recharge.Label2.Text = "Hi, " + Form1.TextBox1.Text
        recharge.Label3.Text = "Current " + Label2.Text
        recharge.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        history.Show()
    End Sub


    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        contact_us.Show()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Red = Int(Rnd() * 255)
        Blue = Int(Rnd() * 255)
        Yellow = Int(Rnd() * 255)


        Button2.ForeColor = Color.FromArgb(Blue, Red, Yellow)
    End Sub

    
End Class