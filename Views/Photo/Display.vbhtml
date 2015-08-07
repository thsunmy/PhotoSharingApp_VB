@ModelType PhotoSharingApplication.Photo
@Code
    ViewData("Title") = "Display"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Display</h2>
@*<img width="800" src="@Url.Action("GetImage", "Photo", New With {Key .photoFile = Model.PhotoFile, .imageMimeType = Model.ImageMimeType})" />*@

<p>
    @Html.DisplayFor(Function(Model) Model.Description)
</p>

<p>
    @Html.DisplayNameFor(Function(Model) Model.UserName):
    @Html.DisplayFor(Function(Model) Model.UserName)
</p>

<p>
    @Html.DisplayNameFor(Function(Model) Model.CreatedDate):
    @Html.DisplayFor(Function(Model) Model.CreatedDate)
</p>

<p>
    @Html.ActionLink("Back to List", "Index")
</p>

