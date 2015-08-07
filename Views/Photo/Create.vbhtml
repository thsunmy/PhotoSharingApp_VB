@ModelType PhotoSharingApplication.Photo
@Code
    ViewData("Title") = "Create"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Create</h2>
@Using (Html.BeginForm("Create", "Photo", FormMethod.Post, New With {Key .enctype = "multipart/form-data"}))
        
    @Html.ValidationSummary(True)

            @<p>
    @Html.LabelFor(Function(Model) Model.Title):
    @Html.EditorFor(Function(Model) Model.Title)
    @Html.ValidationMessageFor(Function(Model) Model.Title)
            </p>

            @<p>
    @Html.LabelFor(Function(Model) Model.PhotoFile)
                <input type="file" name="Image" />
            </p>

            @<p>
    @Html.LabelFor(Function(Model) Model.Description):
    @Html.EditorFor(Function(Model) Model.Description)
    @Html.ValidationMessageFor(Function(Model) Model.Description)
            </p>

            @<p>
    @Html.LabelFor(Function(Model) Model.UserName):
    @Html.DisplayFor(Function(Model) Model.UserName)
            </p>

            @<p>
    @Html.LabelFor(Function(Model) Model.CreatedDate):
    @Html.DisplayFor(Function(Model) Model.CreatedDate)
            </p>

            @<p>
                <input type="submit" value="Create" />
    @Html.ActionLink("Back to List", "Index")
            </p>
End Using
    
