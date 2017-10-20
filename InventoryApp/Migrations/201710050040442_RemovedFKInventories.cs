namespace InventoryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedFKInventories : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Inventories", "StoreID", "dbo.Stores");
            DropIndex("dbo.Inventories", new[] { "StoreID" });
            RenameColumn(table: "dbo.Inventories", name: "StoreID", newName: "Stores_ID");
            AlterColumn("dbo.Inventories", "Stores_ID", c => c.Int());
            CreateIndex("dbo.Inventories", "Stores_ID");
            AddForeignKey("dbo.Inventories", "Stores_ID", "dbo.Stores", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inventories", "Stores_ID", "dbo.Stores");
            DropIndex("dbo.Inventories", new[] { "Stores_ID" });
            AlterColumn("dbo.Inventories", "Stores_ID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Inventories", name: "Stores_ID", newName: "StoreID");
            CreateIndex("dbo.Inventories", "StoreID");
            AddForeignKey("dbo.Inventories", "StoreID", "dbo.Stores", "ID", cascadeDelete: true);
        }
    }
}
