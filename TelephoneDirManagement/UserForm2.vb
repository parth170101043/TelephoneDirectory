Public Class UserForm2
    Private Sub UserForm2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
End Class