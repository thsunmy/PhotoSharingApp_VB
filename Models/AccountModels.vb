Imports System.ComponentModel.DataAnnotations
Imports System.Data.Entity

Namespace Models
    Public Class UsersContext
        Inherits DbContext
        Public Sub New()

            MyBase.New("PhotoAppServices")
        End Sub
    End Class

    'A model for logging in
    Public Class LoginModel
        'UserName
        <Required> _
        <Display(Name:="User name")> _
        Public Property UserName() As String
            Get
                Return m_UserName
            End Get
            Set(value As String)
                m_UserName = value
            End Set
        End Property
        Private m_UserName As String

        'Password
        <Required> _
        <DataType(DataType.Password)> _
        Public Property Password() As String
            Get
                Return m_Password
            End Get
            Set(value As String)
                m_Password = value
            End Set
        End Property
        Private m_Password As String

        'Remember Me
        <Display(Name:="Remember me?")> _
        Public Property RememberMe() As Boolean
            Get
                Return m_RememberMe
            End Get
            Set(value As Boolean)
                m_RememberMe = value
            End Set
        End Property
        Private m_RememberMe As Boolean
    End Class

    'A  model for registering
    Public Class RegisterModel
        'UserName
        <Required> _
        <Display(Name:="User name")> _
        Public Property UserName() As String
            Get
                Return m_UserName
            End Get
            Set(value As String)
                m_UserName = value
            End Set
        End Property
        Private m_UserName As String

        'Password
        <Required> _
        <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=6)> _
        <DataType(DataType.Password)> _
        <Display(Name:="Password")> _
        Public Property Password() As String
            Get
                Return m_Password
            End Get
            Set(value As String)
                m_Password = value
            End Set
        End Property
        Private m_Password As String

        'Confirm Password
        <DataType(DataType.Password)> _
        <Display(Name:="Confirm password")> _
        <Compare("Password", ErrorMessage:="The password and confirmation password do not match.")> _
        Public Property ConfirmPassword() As String
            Get
                Return m_ConfirmPassword
            End Get
            Set(value As String)
                m_ConfirmPassword = value
            End Set
        End Property
        Private m_ConfirmPassword As String
    End Class

    'This model is for resetting the password
    Public Class LocalPasswordModel
        <Required> _
        <DataType(DataType.Password)> _
        <Display(Name:="Current password")> _
        Public Property OldPassword() As String
            Get
                Return m_OldPassword
            End Get
            Set(value As String)
                m_OldPassword = value
            End Set
        End Property
        Private m_OldPassword As String

        <Required> _
        <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=6)> _
        <DataType(DataType.Password)> _
        <Display(Name:="New password")> _
        Public Property NewPassword() As String
            Get
                Return m_NewPassword
            End Get
            Set(value As String)
                m_NewPassword = value
            End Set
        End Property
        Private m_NewPassword As String

        <DataType(DataType.Password)> _
        <Display(Name:="Confirm new password")> _
        <Compare("NewPassword", ErrorMessage:="The new password and confirmation password do not match.")> _
        Public Property ConfirmPassword() As String
            Get
                Return m_ConfirmPassword
            End Get
            Set(value As String)
                m_ConfirmPassword = value
            End Set
        End Property
        Private m_ConfirmPassword As String
    End Class
End Namespace

