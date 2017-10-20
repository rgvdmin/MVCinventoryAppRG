namespace InventoryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedStoreIdtoEmployee : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.Employees", "StoreId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employees", "StoreId");
            AddForeignKey("dbo.Employees", "StoreId", "dbo.Stores", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "StoreId", "dbo.Stores");
            DropIndex("dbo.Employees", new[] { "StoreId" });
            DropColumn("dbo.Employees", "StoreId");
        }
    }
}
