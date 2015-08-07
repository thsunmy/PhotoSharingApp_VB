Imports System.ComponentModel.DataAnnotations

Public Class Comment
    Public Property CommentID() As Integer

    Public Property PhotoID() As Integer
 
    Public Property UserName() As String

    <Required> _
    <StringLength(250)> _
    Public Property Subject() As String
 
    <DataType(DataType.MultilineText)> _
    Public Property Body() As String
 
    Public Overridable Property Photo() As Photo

End Class
