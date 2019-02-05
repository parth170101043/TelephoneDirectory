Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button1.FlatStyle = FlatStyle.Flat
        Button1.FlatAppearance.BorderSize = 0
        Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Button1.BackColor = System.Drawing.Color.Transparent
        Button2.FlatStyle = FlatStyle.Flat
        Button2.FlatAppearance.BorderSize = 0
        Button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Button2.BackColor = System.Drawing.Color.Transparent
        bus.FlatStyle = FlatStyle.Flat
        bus.FlatAppearance.BorderSize = 0
        bus.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        bus.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        bus.BackColor = System.Drawing.Color.Transparent
        Button4.FlatStyle = FlatStyle.Flat
        Button4.FlatAppearance.BorderSize = 0
        Button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Button4.BackColor = System.Drawing.Color.Transparent
        Button5.FlatStyle = FlatStyle.Flat
        Button5.FlatAppearance.BorderSize = 0
        Button5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Button5.BackColor = System.Drawing.Color.Transparent
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles bus.Click
        Form3.Show()
    End Sub

End Class
