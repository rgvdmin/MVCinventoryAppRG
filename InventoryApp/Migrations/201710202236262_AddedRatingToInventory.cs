namespace InventoryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRatingToInventory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inventories", "Rating", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Inventories", "Rating");
        }
    }
}
