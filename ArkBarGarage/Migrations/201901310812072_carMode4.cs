namespace ArkBarGarage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class carMode4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PartsModels", "description", c => c.String());
            AlterColumn("dbo.PartsModels", "SellingPrice", c => c.String());
            DropColumn("dbo.PartsModels", "IdCar");
            DropColumn("dbo.PartsModels", "PurchasePrice");
            DropColumn("dbo.PartsModels", "PurchaseDate");
            DropColumn("dbo.PartsModels", "SellingDate");
            DropColumn("dbo.RepairsModels", "IdCar");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RepairsModels", "IdCar", c => c.Int(nullable: false));
            AddColumn("dbo.PartsModels", "SellingDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.PartsModels", "PurchaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.PartsModels", "PurchasePrice", c => c.Single(nullable: false));
            AddColumn("dbo.PartsModels", "IdCar", c => c.Int(nullable: false));
            AlterColumn("dbo.PartsModels", "SellingPrice", c => c.Single(nullable: false));
            DropColumn("dbo.PartsModels", "description");
        }
    }
}
