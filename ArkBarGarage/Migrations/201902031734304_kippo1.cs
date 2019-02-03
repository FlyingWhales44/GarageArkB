namespace ArkBarGarage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kippo1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PartsModels", "OwnerModels_ID", c => c.Int());
            AddColumn("dbo.RepairsModels", "OwnerModels_ID", c => c.Int());
            CreateIndex("dbo.PartsModels", "OwnerModels_ID");
            CreateIndex("dbo.RepairsModels", "OwnerModels_ID");
            AddForeignKey("dbo.PartsModels", "OwnerModels_ID", "dbo.OwnerModels", "ID");
            AddForeignKey("dbo.RepairsModels", "OwnerModels_ID", "dbo.OwnerModels", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RepairsModels", "OwnerModels_ID", "dbo.OwnerModels");
            DropForeignKey("dbo.PartsModels", "OwnerModels_ID", "dbo.OwnerModels");
            DropIndex("dbo.RepairsModels", new[] { "OwnerModels_ID" });
            DropIndex("dbo.PartsModels", new[] { "OwnerModels_ID" });
            DropColumn("dbo.RepairsModels", "OwnerModels_ID");
            DropColumn("dbo.PartsModels", "OwnerModels_ID");
        }
    }
}
