namespace InventoryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedForiegnKeyStoreId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Inventories", "Stores_ID", "dbo.Stores");
            DropIndex("dbo.Inventories", new[] { "Stores_ID" });
            RenameColumn(table: "dbo.Inventories", name: "Stores_ID", newName: "StoreID");
            AlterColumn("dbo.Inventories", "StoreID", c => c.Int(nullable: false));
            CreateIndex("dbo.Inventories", "StoreID");
            AddForeignKey("dbo.Inventories", "StoreID", "dbo.Stores", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inventories", "StoreID", "dbo.Stores");
            DropIndex("dbo.Inventories", new[] { "StoreID" });
            AlterColumn("dbo.Inventories", "StoreID", c => c.Int());
            RenameColumn(table: "dbo.Inventories", name: "StoreID", newName: "Stores_ID");
            CreateIndex("dbo.Inventories", "Stores_ID");
            AddForeignKey("dbo.Inventories", "Stores_ID", "dbo.Stores", "ID");
        }
    }
}
