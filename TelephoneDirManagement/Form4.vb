Public Class RegForm3

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

        If TextBox1.TextLength = 0 And TextBox2.TextLength = 0 And TextBox3.TextLength = 0 Then
            Label5.Text = "write your Username,Password and Confirm Password"
        ElseIf TextBox1.TextLength = 0 And TextBox2.TextLength = 0 Then
            Label5.Text = "write your Username and Password"
            TextBox3.Text = ""
        ElseIf TextBox1.TextLength = 0 And TextBox3.TextLength = 0 Then
            Label5.Text = "write your Username "
        ElseIf TextBox2.TextLength = 0 And TextBox3.TextLength = 0 Then
            Label5.Text = "write your Password "
        ElseIf TextBox1.TextLength = 0 Then
            Label5.Text = "write your Username "
        ElseIf TextBox2.TextLength = 0 Then
            Label5.Text = "write your Password"
            TextBox3.Text = ""
        ElseIf TextBox3.TextLength = 0 Then
            Label5.Text = "Confirm Password"
        ElseIf TextBox1.TextLength <> 0 And TextBox2.TextLength <> 0 And TextBox3.TextLength <> 0 Then
            If TextBox2.Text = TextBox3.Text Then
                Me.Hide()
                MessageBox.Show("Request sent To Admin")
            Else
                Label5.Text = "Password did't match "
                TextBox3.Text = ""
            End If
        End If

    End Sub
End Class