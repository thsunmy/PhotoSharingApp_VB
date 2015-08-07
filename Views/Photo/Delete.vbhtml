@ModelType PhotoSharingApplication.Photo

@Code
    Layout = Nothing
End Code

<!DOCTYPE html>

<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Delete</title>
</head>
<body>
    <h3>Are you sure you want to delete this?</h3>
    <div>
        <h4>Photo</h4>
        <hr />
        <dl class="dl-horizontal">
            <dt>
                @Html.DisplayNameFor(Function(model) model.Title)
            </dt>
    
            <dd>
                @Html.DisplayFor(Function(model) model.Title)
            </dd>
    
            <dt>
                @Html.DisplayNameFor(Function(model) model.PhotoFile)
            </dt>
    
            <dd>
                @Html.DisplayFor(Function(model) model.PhotoFile)
            </dd>
    
            <dt>
                @Html.DisplayNameFor(Function(model) model.ImageMimeType)
            </dt>
    
            <dd>
                @Html.DisplayFor(Function(model) model.ImageMimeType)
            </dd>
    
            <dt>
                @Html.DisplayNameFor(Function(model) model.Description)
            </dt>
    
            <dd>
                @Html.DisplayFor(Function(model) model.Description)
            </dd>
    
            <dt>
                @Html.DisplayNameFor(Function(model) model.CreatedDate)
            </dt>
    
            <dd>
                @Html.DisplayFor(Function(model) model.CreatedDate)
            </dd>
    
            <dt>
                @Html.DisplayNameFor(Function(model) model.UserName)
            </dt>
    
            <dd>
                @Html.DisplayFor(Function(model) model.UserName)
            </dd>
    
        </dl>
        @Using (Html.BeginForm())
            @Html.AntiForgeryToken()
    
            @<div class="form-actions no-color">
                <input type="submit" value="Delete" class="btn btn-default" /> |
                @Html.ActionLink("Back to List", "Index")
            </div>
        End Using
    </div>
</body>
</html>
