Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports PhotoSharingApplication

Namespace Controllers
    Public Class PhotoController
        Inherits System.Web.Mvc.Controller

        Private db As New PhotoSharingContext

        ' GET: Photo
        Function Index() As ActionResult
            Return View(db.Photos.ToList())
        End Function

        ' GET: Photo/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim photo As Photo = db.Photos.Find(id)
            If IsNothing(photo) Then
                Return HttpNotFound()
            End If
            Return View(photo)
        End Function

        ' GET: Photo/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Photo/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="PhotoID,Title,PhotoFile,ImageMimeType,Description,CreatedDate,UserName")> ByVal photo As Photo) As ActionResult
            If ModelState.IsValid Then
                db.Photos.Add(photo)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(photo)
        End Function

        ' GET: Photo/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim photo As Photo = db.Photos.Find(id)
            If IsNothing(photo) Then
                Return HttpNotFound()
            End If
            Return View(photo)
        End Function

        ' POST: Photo/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="PhotoID,Title,PhotoFile,ImageMimeType,Description,CreatedDate,UserName")> ByVal photo As Photo) As ActionResult
            If ModelState.IsValid Then
                db.Entry(photo).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(photo)
        End Function

        ' GET: Photo/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim photo As Photo = db.Photos.Find(id)
            If IsNothing(photo) Then
                Return HttpNotFound()
            End If
            Return View(photo)
        End Function

        ' POST: Photo/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim photo As Photo = db.Photos.Find(id)
            db.Photos.Remove(photo)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Public Function GetImage(PhotoId As Integer) As FileContentResult
            'Get the right photo
            Dim requestedPhoto As Photo = db.Photos.FirstOrDefault(Function(p) p.PhotoID = PhotoId)
            If requestedPhoto IsNot Nothing Then
                Return File(requestedPhoto.PhotoFile, requestedPhoto.ImageMimeType)
            Else
                Return Nothing
            End If
        End Function


        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
