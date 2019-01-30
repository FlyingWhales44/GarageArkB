namespace ArkBarGarage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserID : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IdCar = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CarsModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Brand = c.String(),
                        Model = c.String(),
                        YearOfProduction = c.Int(nullable: false),
                        VIN = c.Int(nullable: false),
                        Series = c.String(),
                        PhotoURL = c.String(),
                        PuchaseDate = c.DateTime(nullable: false),
                        SaleDate = c.DateTime(nullable: false),
                        PuchasePrice = c.Single(nullable: false),
                        SellingPrice = c.Single(nullable: false),
                        OwnerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.OwnerModels", t => t.OwnerId, cascadeDelete: true)
                .Index(t => t.OwnerId);
            
            CreateTable(
                "dbo.OwnerModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.String(),
                        Name = c.String(),
                        Surname = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PartsModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IdCar = c.Int(nullable: false),
                        Name = c.String(),
                        CatalogNr = c.String(),
                        PurchasePrice = c.Single(nullable: false),
                        SellingPrice = c.Single(nullable: false),
                        PurchaseDate = c.DateTime(nullable: false),
                        SellingDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.RepairsModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IdCar = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        RepairPrice = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CarsModels", "OwnerId", "dbo.OwnerModels");
            DropIndex("dbo.CarsModels", new[] { "OwnerId" });
            DropTable("dbo.RepairsModels");
            DropTable("dbo.PartsModels");
            DropTable("dbo.OwnerModels");
            DropTable("dbo.CarsModels");
            DropTable("dbo.AdModels");
        }
    }
}
