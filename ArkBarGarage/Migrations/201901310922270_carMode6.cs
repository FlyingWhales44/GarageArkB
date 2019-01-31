namespace ArkBarGarage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class carMode6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PartsModels", "data", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PartsModels", "data");
        }
    }
}
