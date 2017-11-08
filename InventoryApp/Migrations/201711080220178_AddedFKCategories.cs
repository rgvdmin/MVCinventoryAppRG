namespace InventoryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFKCategories : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StoreCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Stores", "CategoryID", c => c.Int(nullable: true));
            CreateIndex("dbo.Stores", "CategoryID");
            AddForeignKey("dbo.Stores", "CategoryID", "dbo.StoreCategories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stores", "CategoryID", "dbo.StoreCategories");
            DropIndex("dbo.Stores", new[] { "CategoryID" });
            DropColumn("dbo.Stores", "CategoryID");
            DropTable("dbo.StoreCategories");
        }
    }
}
