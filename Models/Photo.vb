Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel

Public Class Photo
    Public Property PhotoID() As Integer
 
    <Required> _
    Public Property Title() As String
 
    <DisplayName("Picture")> _
    <MaxLength> _
    Public Property PhotoFile() As Byte()

    <HiddenInput(DisplayValue:=False)> _
    Public Property ImageMimeType() As String

    <DataType(DataType.MultilineText)> _
    Public Property Description() As String

    <DataType(DataType.DateTime)> _
    <DisplayName("Created Date")> _
    <DisplayFormat(DataFormatString:="{0:MM/dd/yy}", ApplyFormatInEditMode:=True)> _
    Public Property CreatedDate() As DateTime
  
    Public Property UserName() As String

    Public Overridable Property Comments() As ICollection(Of Comment)

End Class
