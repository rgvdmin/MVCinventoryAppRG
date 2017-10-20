namespace InventoryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovingManagerFunction : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Stores", "EmployeeID", "dbo.Employees");
            DropIndex("dbo.Stores", new[] { "EmployeeID" });
            DropColumn("dbo.Stores", "EmployeeID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stores", "EmployeeID", c => c.Int(nullable: false));
            CreateIndex("dbo.Stores", "EmployeeID");
            AddForeignKey("dbo.Stores", "EmployeeID", "dbo.Employees", "ID", cascadeDelete: true);
        }
    }
}
