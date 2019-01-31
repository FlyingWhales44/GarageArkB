namespace ArkBarGarage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class carModel3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CarsModels", "YearOfProduction", c => c.String());
            AlterColumn("dbo.CarsModels", "VIN", c => c.String());
            DropColumn("dbo.CarsModels", "PuchaseDate");
            DropColumn("dbo.CarsModels", "SaleDate");
            DropColumn("dbo.CarsModels", "PuchasePrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CarsModels", "PuchasePrice", c => c.Single(nullable: false));
            AddColumn("dbo.CarsModels", "SaleDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.CarsModels", "PuchaseDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.CarsModels", "VIN", c => c.Int(nullable: false));
            AlterColumn("dbo.CarsModels", "YearOfProduction", c => c.Int(nullable: false));
        }
    }
}
