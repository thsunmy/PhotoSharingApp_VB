@ModelType PhotoSharingApplication.Models.LoginModel
@Code
    ViewBag.Title = "Log in"
End Code

<hgroup class="title">
    <h2>@ViewBag.Title.</h2>
    <p>You must log in to complete that action. Enter your credentials below.</p>
    
</hgroup>

@Using (Html.BeginForm(New With {.ReturnUrl = ViewBag.ReturnUrl}))
    @Html.ValidationSummary(True, "Log in was unsuccessful. Please correct the errors and try again.")
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

    <div class="editorfield">
    @Html.CheckBoxFor(Function(m)  m.RememberMe)
    @Html.LabelFor(Function(m) m.RememberMe, New With {.class = "checkbox"})
    </div>
    <input type="submit" value="Log in" />

    <p>
    @Html.ActionLink("Register", "Register") if you don't have an account.
    </p>
</text>
End Using