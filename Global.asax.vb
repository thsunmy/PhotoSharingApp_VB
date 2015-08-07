Imports System.Web.Optimization
Imports System.Data.Entity

Public Class MvcApplication
    Inherits System.Web.HttpApplication

    Protected Sub Application_Start()

        'Seed the database with sample data for development. This code should be removed for production.
        Database.SetInitializer(Of PhotoSharingContext)(New PhotoSharingInitializer())


        AreaRegistration.RegisterAllAreas()
        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters)
        RouteConfig.RegisterRoutes(RouteTable.Routes)
        BundleConfig.RegisterBundles(BundleTable.Bundles)
    End Sub
End Class
