namespace ArkBarGarage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class carMode5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CarsModels", "OwnerId", "dbo.OwnerModels");
            DropIndex("dbo.CarsModels", new[] { "OwnerId" });
            RenameColumn(table: "dbo.CarsModels", name: "OwnerId", newName: "OwnerModels_ID");
            AlterColumn("dbo.CarsModels", "OwnerModels_ID", c => c.Int());
            CreateIndex("dbo.CarsModels", "OwnerModels_ID");
            AddForeignKey("dbo.CarsModels", "OwnerModels_ID", "dbo.OwnerModels", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CarsModels", "OwnerModels_ID", "dbo.OwnerModels");
            DropIndex("dbo.CarsModels", new[] { "OwnerModels_ID" });
            AlterColumn("dbo.CarsModels", "OwnerModels_ID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.CarsModels", name: "OwnerModels_ID", newName: "OwnerId");
            CreateIndex("dbo.CarsModels", "OwnerId");
            AddForeignKey("dbo.CarsModels", "OwnerId", "dbo.OwnerModels", "ID", cascadeDelete: true);
        }
    }
}
