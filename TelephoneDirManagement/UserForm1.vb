Public Class UserForm1
    Private Sub bus_Click(sender As Object, e As EventArgs) Handles bus.Click
        UserForm2.Show()
        Me.Hide()
    End Sub
End Class