Imports System
Imports System.Data.Entity
Imports System.Data.Entity.Migrations
Imports System.Linq

Namespace Migrations

    Friend NotInheritable Class Configuration 
        Inherits DbMigrationsConfiguration(Of OdeToFoodDb)

        Public Sub New()
            AutomaticMigrationsEnabled = True
            ContextKey = "OdeToFood.OdeToFoodDb"
        End Sub

        Protected Overrides Sub Seed(context As OdeToFoodDb)
            '  This method will be called after migrating to the latest version.

            '  You can use the DbSet(Of T).AddOrUpdate() helper extension method 
            '  to avoid creating duplicate seed data. E.g.
            '
            '    context.People.AddOrUpdate(
            '       Function(c) c.FullName,
            '       New Customer() With {.FullName = "Andrew Peters"},
            '       New Customer() With {.FullName = "Brice Lambson"},
            '       New Customer() With {.FullName = "Rowan Miller"})

            context.Restaurants.AddOrUpdate(
                Function(c) c.Name,
                New Restaurant() With {.Name = "Sabatino's", .City = "Baltimore", .Country = "USA"},
                New Restaurant() With {.Name = "Great Lake", .City = "Chicago", .Country = "USA"},
                New Restaurant() With {
                    .Name = "Smaka", .City = "Gothenburg", .Country = "Sweden", .Reviews = New List(Of RestaurantReview)() From {New RestaurantReview() With {.Body = "Nice food", .Rating = 11, .Reviewer = "Bob The Builder"}}
              })

        End Sub
        '    .Reviews = New List(Of RestaurantReview)() With {
        ''                       New RestaurantReview() With {.Rating = 9, .Body = "Great food!!"}
        '                  }
    End Class

End Namespace
