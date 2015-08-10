
@Code
    Layout = Nothing
End Code


<!DOCTYPE html>

<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>@ViewBag.Title</title>
    <link type="text/css" rel="stylesheet" href="http://code.jquery.com/ui/1.9.2/themes/base/jquery-ui.css" />
    <link type="text/css" rel="stylesheet" href="~/Content/PhotoSharingStyles.css" />
    <script src="http://ajax.aspnetcdn.com/ajax/jquery/jquery-1.8.0.min.js" type="text/javascript"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/mvc/3.0/jquery.unobtrusive-ajax.js" type="text/javascript"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.0/jquery-ui.min.js" type="text/javascript"></script>
</head>
<body>
    <h1 class="site-page-title">
        Adventure Works Photo Sharing
    </h1>

    <div class="login-controls">
        @If (Request.IsAuthenticated) Then
            @<text>
                <div>
                    Hello, @System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(User.Identity.Name).
                    @Html.ActionLink("Log Off", "LogOff", "Account")
                    @Html.ActionLink("Reset", "ResetPassword", "Account")
                </div>
            </text>

        Else
            @<text>
        <div>
            @Html.ActionLink("Log In", "Login", "Account")
            @Html.ActionLink("Register", "Register", "Account")
        </div>
            </text>
        End If
    </div>
    <div class="clear-floats" />

    <div id="topmenu">

    </div>

    <div id="breadcrumb">

    </div>

    <div>
        @RenderBody()
    </div>
</body>
</html>
