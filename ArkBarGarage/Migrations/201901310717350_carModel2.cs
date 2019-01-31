namespace ArkBarGarage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class carModel2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CarsModels", "Phonenumber", c => c.String());
            AddColumn("dbo.CarsModels", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CarsModels", "Description");
            DropColumn("dbo.CarsModels", "Phonenumber");
        }
    }
}
