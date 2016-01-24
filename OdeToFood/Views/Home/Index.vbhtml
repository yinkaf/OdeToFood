@ModelType IEnumerable(Of RestaurantListViewModel)
@Code
    ViewData("Title") = "Home Page"
End Code

<p>Searh for restaurants</p>
<form method="get" action="@Url.Action("Index")"
      data-otf-ajax="true" data-otf-target="#restaurantList">
    <input type="search" name="searchTerm" data-otf-autocomplete="@Url.Action("Autocomplete")"/>
    <input type="submit" value="Search"/>
</form>

@Html.Partial("_Restaurants", Model)

