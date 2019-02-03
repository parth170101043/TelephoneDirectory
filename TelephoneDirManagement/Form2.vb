Public Class RegForm1

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
            If IsNumeric(TextBox3.Text) Then
                Me.Hide()
                RegForm2.Show()
            Else
                Label5.Text = "Phone number Invalid"
            End If
        End If

    End Sub


    Private Sub RegForm1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class