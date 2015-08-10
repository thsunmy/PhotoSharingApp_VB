Imports System.Globalization
Imports System.Security.Claims
Imports System.Threading.Tasks
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.Owin
Imports Microsoft.Owin.Security
Imports Owin
Imports PhotoSharingApplication.Models

<Authorize> _
Public Class AccountController
    Inherits Controller

    '
    ' GET: /Account/Login
    <AllowAnonymous> _
    Public Function Login(returnUrl As String) As ActionResult
        ViewBag.ReturnUrl = returnUrl
        Return View()
    End Function

    '
    ' POST: /Account/Login
    <AllowAnonymous> _
    <HttpPost> _
    Public Function Login(model As LoginModel, returnUrl As String) As ActionResult
        If ModelState.IsValid Then
            If Membership.ValidateUser(model.UserName, model.Password) Then
                FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe)

                If Url.IsLocalUrl(returnUrl) Then
                    Return Redirect(returnUrl)
                Else
                    Return RedirectToAction("Index", "Home")
                End If
            Else
                ModelState.AddModelError("", "The user name or password provided is incorrect.")
            End If
        End If

        Return View(model)
    End Function

    '
    ' GET: /Account/LogOff
    Public Function LogOff() As ActionResult
        FormsAuthentication.SignOut()
        Return RedirectToAction("Index", "Home")
    End Function

    '
    ' GET: /Account/Register
    <AllowAnonymous> _
    Public Function Register() As ActionResult
        Return View()
    End Function

    '
    ' POST: /Account/Register
    <AllowAnonymous> _
    <HttpPost> _
    <ValidateAntiForgeryToken> _
    Public Function Register(model As RegisterModel) As ActionResult
        If ModelState.IsValid Then
            ' Attempt to register the user
            Try
                Dim NewUser As MembershipUser = Membership.CreateUser(model.UserName, model.Password)
                'Log the user on with the new account
                FormsAuthentication.SetAuthCookie(model.UserName, False)
                Return RedirectToAction("Index", "Home")
            Catch e As MembershipCreateUserException
                ModelState.AddModelError("Registration Error", "Registration error: " & e.StatusCode.ToString())
            End Try
        End If

        Return View(model)
    End Function

    Public Enum ManageMessageId
        ChangePasswordSuccess
        SetPasswordSuccess
    End Enum

    '
    ' GET: /Account/ResetPassword
    Public Function ResetPassword(message As System.Nullable(Of ManageMessageId)) As ActionResult
        ViewBag.StatusMessage = If(message = ManageMessageId.ChangePasswordSuccess, "Your password has been changed.", If(message = ManageMessageId.SetPasswordSuccess, "Your password has been set.", ""))
        ViewBag.ReturnUrl = Url.Action("ResetPassword")
        Return View()
    End Function

    '
    ' POST: /Account/ResetPassword
    <HttpPost> _
    <ValidateAntiForgeryToken> _
    Public Function ResetPassword(model As LocalPasswordModel) As ActionResult
        ViewBag.ReturnUrl = Url.Action("ResetPassword")
        If ModelState.IsValid Then
            ' ChangePassword will throw an exception rather than return false in certain failure scenarios.
            Dim changePasswordSucceeded As Boolean
            Try
                changePasswordSucceeded = Membership.Provider.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword)
            Catch generatedExceptionName As Exception
                changePasswordSucceeded = False
            End Try

            If changePasswordSucceeded Then
                Return RedirectToAction("ResetPassword", New With { _
                    Key .Message = ManageMessageId.ChangePasswordSuccess _
                })
            Else
                ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.")
            End If
        End If

        ' If we got this far, something failed, redisplay form
        Return View(model)
    End Function



End Class

