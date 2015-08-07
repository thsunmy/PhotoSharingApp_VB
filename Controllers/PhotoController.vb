Imports System.Web.Mvc

Namespace Controllers
    Public Class PhotoController
        Inherits Controller

        ' GET: Photo
        Function Index() As ActionResult
            Return View("Index")
        End Function

        Function Create() As ActionResult
            Dim newPhoto As New Photo()

            newPhoto.CreatedDate = DateTime.Today

            Return View("Create", newPhoto)
        End Function

        Function Display(photo As Photo) As ActionResult

            Return View("Display", Photo)
        End Function

        <HttpPost> _
        Function Create(ByVal photo As Photo, ByVal image As HttpPostedFileBase) As ActionResult


            photo.CreatedDate = DateTime.Today

            If Not (ModelState.IsValid) Then
                Return View("Create", photo)
            Else

                If Not IsNothing(image) Then

                    photo.ImageMimeType = image.ContentType
                    photo.PhotoFile = New Byte(image.ContentLength - 1) {}
                    image.InputStream.Read(photo.PhotoFile, 0, image.ContentLength)

                End If

                Return View("Display", photo)
            End If
        End Function

        Function GetImage(id As Int32) As FileContentResult

            Return Nothing

        End Function


          

    End Class
End Namespace