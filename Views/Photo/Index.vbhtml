@ModelType IEnumerable(Of PhotoSharingApplication.Photo)

@Code
    Layout = Nothing
End Code

<!DOCTYPE html>

<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Index</title>
</head>
<body>
    <p>
        @Html.ActionLink("Create New", "Create")
    </p>
    <table class="table">
        <tr>
            <th>
                @Html.DisplayNameFor(Function(model) model.Title)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.PhotoFile)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.ImageMimeType)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.Description)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.CreatedDate)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.UserName)
            </th>
            <th></th>
        </tr>
    
    @For Each item In Model
        @<tr>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Title)
            </td>
            <td>
                @*@Html.DisplayFor(Function(modelItem) item.PhotoFile)*@
                <div class="photo-display">
                    <img width="800" src="@Url.Action("GetImage", "Photo", New With {item.PhotoID})" />
                </div>
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.ImageMimeType)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Description)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.CreatedDate)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.UserName)
            </td>
            <td>
                @Html.ActionLink("Edit", "Edit", New With {.id = item.PhotoID }) |
                @Html.ActionLink("Details", "Details", New With {.id = item.PhotoID }) |
                @Html.ActionLink("Delete", "Delete", New With {.id = item.PhotoID })
            </td>
        </tr>
    Next
    
    </table>
</body>
</html>
