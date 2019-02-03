namespace ArkBarGarage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kippo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CarsModels", "IdCar", c => c.Int(nullable: false));
            AddColumn("dbo.PartsModels", "IdCar", c => c.Int(nullable: false));
            AddColumn("dbo.RepairsModels", "IdCar", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RepairsModels", "IdCar");
            DropColumn("dbo.PartsModels", "IdCar");
            DropColumn("dbo.CarsModels", "IdCar");
        }
    }
}
