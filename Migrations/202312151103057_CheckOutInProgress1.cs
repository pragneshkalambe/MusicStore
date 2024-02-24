namespace TestStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CheckOutInProgress1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "CodeCus", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "Description", c => c.String());
            AddColumn("dbo.Orders", "Item_Id", c => c.Int());
            AlterColumn("dbo.Customers", "Address", c => c.String(nullable: false));
            CreateIndex("dbo.Orders", "Item_Id");
            AddForeignKey("dbo.Orders", "Item_Id", "dbo.Items", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Item_Id", "dbo.Items");
            DropIndex("dbo.Orders", new[] { "Item_Id" });
            AlterColumn("dbo.Customers", "Address", c => c.String());
            DropColumn("dbo.Orders", "Item_Id");
            DropColumn("dbo.Orders", "Description");
            DropColumn("dbo.Customers", "CodeCus");
        }
    }
}
