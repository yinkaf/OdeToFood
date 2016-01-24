@ModelType IEnumerable(Of RestaurantListViewModel)
<div id="restaurantList">
    @For Each item In Model
        @<div>
            <h4>@item.Name</h4>
            <div>@item.City, @item.Country</div>
            <div>Reviews: @item.CountOfReviews</div>
            <hr />
        </div>
    Next

</div>
