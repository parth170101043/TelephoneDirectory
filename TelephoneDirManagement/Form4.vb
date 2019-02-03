Public Class RegForm3
    Dim y As Integer = 0
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label3.Hide()
        TextBox3.Hide()
        PictureBox1.Hide()

    End Sub
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

        ' If TextBox1.TextLength = 0 And TextBox2.TextLength = 0 And TextBox3.TextLength = 0 Then
        ' Label5.Text = "write your Username,Password and Confirm Password"
        ' ElseIf TextBox1.TextLength = 0 And TextBox2.TextLength = 0 Then
        '  Label5.Text = "write your Username and Password"
        '  TextBox3.Text = ""
        ' ElseIf TextBox1.TextLength = 0 And TextBox3.TextLength = 0 Then
        ' Label5.Text = "write your Username "
        ' ElseIf TextBox2.TextLength = 0 And TextBox3.TextLength = 0 Then
        ' Label5.Text = "write your Password "
        ' ElseIf TextBox1.TextLength = 0 Then
        ' Label5.Text = "write your Username "
        ' ElseIf TextBox2.TextLength = 0 Then
        ' Label5.Text = "write your Password"
        ' TextBox3.Text = ""
        ' ElseIf TextBox3.TextLength = 0 Then
        ' Label5.Text = "Confirm Password"
        ' ElseIf TextBox1.TextLength <> 0 And TextBox2.TextLength <> 0 And TextBox3.TextLength <> 0 Then
        ' If TextBox2.Text = TextBox3.Text Then
        Me.Hide()
        MessageBox.Show("Request sent To Admin")
        ' Else
        ' Label5.Text = "Password did't match "
        'TextBox3.Text = ""
        'End If
        'End If

    End Sub

    Private Sub TextBox2_MouseLeave(sender As Object, e As EventArgs) Handles TextBox2.MouseLeave
        If TextBox2.TextLength = 0 Then
            TextBox3.Text = ""
            Label3.Hide()
            TextBox3.Hide()
            PictureBox1.Hide()
            Label5.Text = ""

        ElseIf TextBox2.TextLength > 0 Then
            If TextBox1.TextLength > 0 Then
                Label3.Show()
                TextBox3.Show()

                Label5.Text = ""
            End If


        End If


    End Sub

    Private Sub TextBox1_MouseLeave(sender As Object, e As EventArgs) Handles TextBox1.MouseLeave
        If TextBox1.TextLength > 0 And TextBox2.TextLength > 0 Then
            Label3.Show()
            TextBox3.Show()

            Label5.Text = ""
        Else
            Label3.Hide()
            TextBox3.Hide()
            PictureBox1.Hide()

            Label5.Text = ""
        End If
    End Sub

    Private Sub TextBox3_MouseLeave(sender As Object, e As EventArgs) Handles TextBox3.MouseLeave
        If TextBox3.TextLength > 0 Then
            If TextBox3.Text = TextBox2.Text Then
                PictureBox1.Show()
                Label5.Text = ""
            Else
                Label5.Text = "Password did't match "
                TextBox3.Text = ""
                PictureBox1.Hide()
            End If
        Else
            PictureBox1.Hide()
        End If

    End Sub





End Class