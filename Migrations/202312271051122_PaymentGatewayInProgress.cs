namespace TestStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaymentGatewayInProgress : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Album_AlbumID", "dbo.Albums");
            DropForeignKey("dbo.Orders", "Customer_CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Orders", "Item_Id", "dbo.Items");
            DropIndex("dbo.Orders", new[] { "Album_AlbumID" });
            DropIndex("dbo.Orders", new[] { "Customer_CustomerID" });
            DropIndex("dbo.Orders", new[] { "Item_Id" });
            CreateTable(
                "dbo.OrderEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(),
                        Email = c.String(),
                        Mobile = c.String(),
                        TotalAmount = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Orders");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        Description = c.String(),
                        Album_AlbumID = c.Int(),
                        Customer_CustomerID = c.Int(),
                        Item_Id = c.Int(),
                    })
                .PrimaryKey(t => t.OrderID);
            
            DropTable("dbo.OrderEntities");
            CreateIndex("dbo.Orders", "Item_Id");
            CreateIndex("dbo.Orders", "Customer_CustomerID");
            CreateIndex("dbo.Orders", "Album_AlbumID");
            AddForeignKey("dbo.Orders", "Item_Id", "dbo.Items", "Id");
            AddForeignKey("dbo.Orders", "Customer_CustomerID", "dbo.Customers", "CustomerID");
            AddForeignKey("dbo.Orders", "Album_AlbumID", "dbo.Albums", "AlbumID");
        }
    }
}
