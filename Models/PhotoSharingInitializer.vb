Imports System.Data.Entity
Imports System.IO

Public Class PhotoSharingInitializer
    Inherits DropCreateDatabaseAlways(Of PhotoSharingContext)
    'This method puts sample data into the database
    Protected Overrides Sub Seed(context As PhotoSharingContext)
        MyBase.Seed(context)

        'Create some photos
        Dim photos = New List(Of Photo)() From { _
            New Photo() With { _
                 .Title = "Me standing on top of a mountain", _
                 .Description = "I was very impressed with myself", _
                 .UserName = "Fred", _
                 .PhotoFile = getFileBytes("\Images\flower.jpg"), _
                 .ImageMimeType = "image/jpeg", _
                 .CreatedDate = DateTime.Today _
            }, _
            New Photo() With { _
                 .Title = "My New Adventure Works Bike", _
                 .Description = "It's the bees knees!", _
                 .UserName = "Fred", _
                 .PhotoFile = getFileBytes("\Images\orchard.jpg"), _
                 .ImageMimeType = "image/jpeg", _
                 .CreatedDate = DateTime.Today _
            }, _
            New Photo() With { _
                 .Title = "View from the start line", _
                 .Description = "I took this photo just before we started over my handle bars.", _
                 .UserName = "Sue", _
                 .PhotoFile = getFileBytes("\Images\path.jpg"), _
                 .ImageMimeType = "image/jpeg", _
                 .CreatedDate = DateTime.Today _
            } _
        }
        photos.ForEach(Function(s) context.Photos.Add(s))
        context.SaveChanges()

        'Create some comments
        Dim comments = New List(Of Comment)() From { _
            New Comment() With { _
                 .PhotoID = 1, _
                 .UserName = "Bert", _
                 .Subject = "A Big Mountain", _
                 .Body = "That looks like a very high mountain you have climbed" _
            }, _
            New Comment() With { _
                 .PhotoID = 1, _
                 .UserName = "Sue", _
                 .Subject = "So?", _
                 .Body = "I climbed a mountain that high before breakfast everyday" _
            }, _
            New Comment() With { _
                 .PhotoID = 2, _
                 .UserName = "Fred", _
                 .Subject = "Jealous", _
                 .Body = "Wow, that new bike looks great!" _
            } _
        }
        comments.ForEach(Function(s) context.Comments.Add(s))
        context.SaveChanges()
    End Sub

    'This gets a byte array for a file at the path specified
    'The path is relative to the route of the web site
    'It is used to seed images
    Private Function getFileBytes(path As String) As Byte()
        Dim fileOnDisk As New FileStream(HttpRuntime.AppDomainAppPath + path, FileMode.Open)
        Dim fileBytes As Byte()
        Using br As New BinaryReader(fileOnDisk)
            fileBytes = br.ReadBytes(CInt(fileOnDisk.Length))
        End Using
        Return fileBytes
    End Function

End Class
