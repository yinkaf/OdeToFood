Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Dim _db As OdeToFoodDb = New OdeToFoodDb()

    Function Index(searchTerm As String) As ActionResult
        'Dim model = From r In _db.Restaurants
        '            Order By r.Reviews.Average(Function(review) review.Rating) Descending
        '            Select New RestaurantListViewModel() With {.Id = r.Id, .Name = r.Name, .City = r.City, .Country = r.Country, .CountOfReviews = r.Reviews.Count()}

        Dim model = _db.Restaurants.OrderByDescending(Function(r) r.Reviews.Average(Function(review) review.Rating)).
                    Where(Function(r) searchTerm Is Nothing Or r.Name.StartsWith(searchTerm)).
                    Select(Function(r) New RestaurantListViewModel() With {.Id = r.Id, .Name = r.Name, .City = r.City, .Country = r.Country, .CountOfReviews = r.Reviews.Count()})
        If Request.IsAjaxRequest Then
            Return PartialView("_Restaurants", model)
        End If
        Return View(model)
    End Function
    Function About() As ActionResult
        ViewData("Message") = "Your application description page."
        Dim model As AboutModel = New AboutModel()
        model.Name = "Yinka"
        model.Location = "USA"

        Return View(model)
    End Function

    Function Contact() As ActionResult
        ViewData("Message") = "Your contact page."

        Return View()
    End Function

    Protected Overrides Sub Dispose(disposing As Boolean)
        If (_db IsNot Nothing) Then
            _db.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub
End Class
