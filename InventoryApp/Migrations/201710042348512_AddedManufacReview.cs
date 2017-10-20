namespace InventoryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedManufacReview : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inventories", "PictureUrl", c => c.String());
            AddColumn("dbo.Inventories", "Manufacture", c => c.String());
            AddColumn("dbo.Inventories", "NumReview", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Inventories", "NumReview");
            DropColumn("dbo.Inventories", "Manufacture");
            DropColumn("dbo.Inventories", "PictureUrl");
        }
    }
}
