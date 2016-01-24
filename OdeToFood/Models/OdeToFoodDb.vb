Imports System.Data.Entity

Public Class OdeToFoodDb
    Inherits DbContext

    Public Property Restaurants As DbSet(Of Restaurant)
    Public Property Reviews As DbSet(Of RestaurantReview)

    Sub New()
        MyBase.New("DefaultConnection")
    End Sub


End Class
