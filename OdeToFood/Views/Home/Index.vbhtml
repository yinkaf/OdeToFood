@ModelType IEnumerable(Of RestaurantListViewModel)
@Code
    ViewData("Title") = "Home Page"
End Code
<form method="get">
    <input type="search" name="searchTerm" value="@Request("searchTerm")"/>
    <input type="submit" value="Search"/>
</form>
@For Each item In Model
    @<div>
        <h4>@item.Name</h4>
        <div>@item.City, @item.Country</div>
        <div>Reviews: @item.CountOfReviews</div>
    <hr />
</div>
Next
