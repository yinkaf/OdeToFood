@ModelType IEnumerable(Of OdeToFood.RestaurantReview)


<table>
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.Rating)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Body)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Reviewer)
        </th>
    </tr>
    

    @For Each item In Model

        @<tr>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Rating)
            </td>
             <td>
                 @Html.DisplayFor(Function(modelItem) item.Body)
             </td>
             <td>
                 @Html.DisplayFor(Function(modelItem) item.Reviewer)
             </td>
             <td>
                 @Html.ActionLink("Edit", "Edit", New With {.id = item.Id}) 
             </td>
        </tr>
    Next

 </table>

