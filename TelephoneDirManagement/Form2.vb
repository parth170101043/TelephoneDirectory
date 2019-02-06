Public Class RegForm1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button1.BackColor = Color.Gray
        Button1.ForeColor = Color.WhiteSmoke
    End Sub
    Dim noval As String = "!~`#$%^&*()_-+=/*<>.,?;:0123465789"
    Dim noval1 As String = ".+-="
    Private Sub TextBox1_MouseLeave(sender As Object, e As EventArgs) Handles TextBox1.MouseLeave
        If TextBox1.TextLength > 0 And TextBox2.TextLength > 0 And TextBox3.TextLength > 0 Then
            Button1.BackColor = Color.LimeGreen
            Button1.ForeColor = Color.White
        Else
            Button1.BackColor = Color.Gray
            Button1.ForeColor = Color.WhiteSmoke
        End If
    End Sub
    Private Sub TextBox2_MouseLeave(sender As Object, e As EventArgs) Handles TextBox2.MouseLeave
        If TextBox1.TextLength > 0 And TextBox2.TextLength > 0 And TextBox3.TextLength > 0 Then
            Button1.BackColor = Color.LimeGreen
            Button1.ForeColor = Color.White
        Else
            Button1.BackColor = Color.Gray
            Button1.ForeColor = Color.WhiteSmoke
        End If
    End Sub
    Private Sub TextBox3_MouseLeave(sender As Object, e As EventArgs) Handles TextBox3.MouseLeave
        If TextBox1.TextLength > 0 And TextBox2.TextLength > 0 And TextBox3.TextLength > 0 Then
            Button1.BackColor = Color.LimeGreen
            Button1.ForeColor = Color.White
        Else
            Button1.BackColor = Color.Gray
            Button1.ForeColor = Color.WhiteSmoke
        End If
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
    
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Me.Hide()
        ' Form2.Show()
        Label5.Text = ""
        If TextBox1.TextLength = 0 And TextBox2.TextLength = 0 And TextBox3.TextLength = 0 Then
            Label5.Text = "write your Name,Email and PhoneNumber"
        ElseIf TextBox1.TextLength = 0 And TextBox2.TextLength = 0 Then
            Label5.Text = "write your Name and Email"
        ElseIf TextBox1.TextLength = 0 And TextBox3.TextLength = 0 Then
            Label5.Text = "write your Name and Phonenumber"
        ElseIf TextBox2.TextLength = 0 And TextBox3.TextLength = 0 Then
            Label5.Text = "write your Email and Phonenumber"
        ElseIf TextBox1.TextLength = 0 Then
            Label5.Text = "write your Name "
        ElseIf TextBox2.TextLength = 0 Then
            Label5.Text = "write your Email"
        ElseIf TextBox3.TextLength = 0 Then
            Label5.Text = "write your PhoneNumber"
        ElseIf TextBox1.TextLength <> 0 And TextBox2.TextLength <> 0 And TextBox3.TextLength <> 0 Then
            If IsNumeric(TextBox3.Text) And IsValidFileNameOrPath(TextBox3.Text, noval1) Then
                If IsValidFileNameOrPath(TextBox1.Text, noval) Then
                    Me.Hide()
                    RegForm2.Show()
                Else
                    Label5.Text = "Invalid Name"
                End If
            Else
                Label5.Text = "Phone number Invalid"

            End If
        End If

    End Sub


End Class
