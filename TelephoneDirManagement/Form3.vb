Public Class RegForm2
    Dim noval As String = "!~`#$%^&*()_+=/*<>.,?;:0123465789"

    Shared Property MySqlConn As MySql.Data.MySqlClient.MySqlConnection

    Function IsValidFileNameOrPath(ByVal name As String) As Boolean
        ' Determines if the name is Nothing.
        If name Is Nothing Then
            Return False
        End If

        ' Determines if there are bad characters in the name.
        For Each badChar As Char In noval
            If InStr(name, badChar) > 0 Then
                Return False
            End If
        Next

        ' The name passes basic validation.
        Return True
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Label7.Text = ""
        If IsValidFileNameOrPath(TextBox3.Text) Then
            If MessageBox.Show("Are you sure that all give information correct?", "", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                Me.Hide()
                RegForm3.Show()
            End If
        Else
            Label7.Text = "invalid occupation"
        End If
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        RegForm1.Show()
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs)

    End Sub
End Class