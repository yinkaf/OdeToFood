@ModelType Restaurant
@Code
    ViewData("Title") = "Index"
End Code



<h2>Reviews for @Model.Name with @Model.Reviews.Count</h2>

@Html.Partial("_Reviews", Model.Reviews)

<p>
    @Html.ActionLink("Create New", "Create", New With {.restaurantId = Model.Id})
</p>
