Imports System.Data.Entity

Public Class PhotoSharingContext
    Inherits System.Data.Entity.DbContext

    Public Property Photos() As DbSet(Of Photo)
    Public Property Comments() As DbSet(Of Comment)

End Class
