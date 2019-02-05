Public Class Form3

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim f As Integer = 0
        With Combo.Items
            .Add("Tour/Travel")
            .Add("Transport")
            .Add("Hotel")
            .Add("Restaurants")
            .Add("Car")
            .Add("Pets")
            .Add("Doctors/Medical")
            .Add("Pharmacy")
            .Add("Shopping Mall")
            .Add("Coaching Centre")
            .Add("Add New Item")

        End With
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class