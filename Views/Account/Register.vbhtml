@ModelType PhotoSharingApplication.Models.RegisterModel 
@Code
    ViewBag.Title = "Register"
End Code

<hgroup class="title">
    <h1>@ViewBag.Title.</h1>
    <h2>Create a new account.</h2>
</hgroup>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()
    @Html.ValidationSummary()
@<text>

    <div>
        <span class="editor-label">
    @Html.LabelFor(Function(m)  m.UserName)
        </span>
        <span class="editor-field">
    @Html.TextBoxFor(Function(m) m.UserName, New With {.class = "text-box"})
        </span>
    </div>

    <div>
        <span class="editor-label">
    @Html.LabelFor(Function(m)  m.Password)
        </span>
        <span class="editor-field">
    @Html.PasswordFor(Function(m) m.Password, New With {.class = "text-box"})
        </span>
    </div>

    <div>
        <span class="editor-label">
    @Html.LabelFor(Function(m)  m.ConfirmPassword)
        </span>
        <span class="editor-field">
    @Html.PasswordFor(Function(m) m.ConfirmPassword, New With {.class = "text-box"})
        </span>
    </div>

    <input type="submit" value="Register" />

</text>
End Using 