Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class InitialCreate
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.Restaurants",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .Name = c.String(),
                        .City = c.String(),
                        .Country = c.String()
                    }) _
                .PrimaryKey(Function(t) t.Id)
            
            CreateTable(
                "dbo.RestaurantReviews",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .Rating = c.Int(nullable := False),
                        .Body = c.String(),
                        .RestaurantId = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.Restaurants", Function(t) t.RestaurantId, cascadeDelete := True) _
                .Index(Function(t) t.RestaurantId)
            
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.RestaurantReviews", "RestaurantId", "dbo.Restaurants")
            DropIndex("dbo.RestaurantReviews", New String() { "RestaurantId" })
            DropTable("dbo.RestaurantReviews")
            DropTable("dbo.Restaurants")
        End Sub
    End Class
End Namespace
