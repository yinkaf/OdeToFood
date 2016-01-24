Public Class Restaurant
    Public Property Id As Integer
    Public Property Name As String
    Public Property City As String
    Public Property Country As String
    Public Overridable Property Reviews As ICollection(Of RestaurantReview)
End Class
