@ModelType IEnumerable(Of RestaurantListViewModel)
@Code
    ViewData("Title") = "Home Page"
End Code
@*<form method="get">
    <input type="search" name="searchTerm" value="@Request("searchTerm")"/>
    <input type="submit" value="Search"/>
</form>*@
<br/>
<br />
<br />
<br />

<br />
@Using (Ajax.BeginForm(New AjaxOptions() With {.HttpMethod = "get", .InsertionMode = InsertionMode.Replace, .UpdateTargetId = "restaurantList"}))
    @<input type="search" name="searchTerm"/>
    @<input type="submit" value="Search By Name" />
End Using

@Html.Partial("_Restaurants", Model)

