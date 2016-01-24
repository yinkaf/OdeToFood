Imports System.Data.Entity
Imports System.Web.Mvc
Imports OdeToFood


Namespace Controllers
    Public Class ReviewController
        Inherits Controller

        Public Property _db As OdeToFoodDb = New OdeToFoodDb()
        ' GET: Review
        Function Index(<Bind(Prefix:="id")> restaurantId As Integer) As ActionResult
            Dim restaurant = _db.Restaurants.Find(restaurantId)
            If (restaurant IsNot Nothing) Then
                Return View(restaurant)
            End If
            Return HttpNotFound()
        End Function

        <HttpGet> Public Function Create(restaurantId As Integer) As ActionResult
            Return View()
        End Function

        <HttpPost> Public Function Create(review As RestaurantReview) As ActionResult
            If ModelState.IsValid Then
                _db.Reviews.Add(review)
                _db.SaveChanges()
                Return RedirectToAction("Index", New With {.id = review.RestaurantId})
            End If
            Return View(review)
        End Function

        <HttpGet> Public Function Edit(id As Integer) As ActionResult
            Dim model = _db.Reviews.Find(id)
            Return View(model)
        End Function

        <HttpPost> Public Function Edit(review As RestaurantReview) As ActionResult
            If ModelState.IsValid() Then
                _db.Entry(review).State = EntityState.Modified
                _db.SaveChanges()

                Return RedirectToAction("Index", New With {.id = review.RestaurantId})
            End If


            Return View(review)
        End Function

        Protected Overrides Sub Dispose(disposing As Boolean)
            _db.Dispose()
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace