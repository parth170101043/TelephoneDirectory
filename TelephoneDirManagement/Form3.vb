Public Class RegForm2

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MessageBox.Show("Are you sure that all give information correct?", "", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
            Me.Hide()
            RegForm3.Show()
        End If
    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        RegForm1.Show()
    End Sub


End Class