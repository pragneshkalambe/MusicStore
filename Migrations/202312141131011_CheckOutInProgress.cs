namespace TestStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CheckOutInProgress : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Album_AlbumID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Albums", t => t.Album_AlbumID)
                .Index(t => t.Album_AlbumID);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        AlbumID = c.Int(nullable: false),
                        Item_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Items", t => t.Item_Id)
                .Index(t => t.Item_Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        CodeCus = c.Int(nullable: false),
                        Album_AlbumID = c.Int(),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Albums", t => t.Album_AlbumID)
                .Index(t => t.Album_AlbumID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Album_AlbumID", "dbo.Albums");
            DropForeignKey("dbo.OrderDetails", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.Items", "Album_AlbumID", "dbo.Albums");
            DropIndex("dbo.Orders", new[] { "Album_AlbumID" });
            DropIndex("dbo.OrderDetails", new[] { "Item_Id" });
            DropIndex("dbo.Items", new[] { "Album_AlbumID" });
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Items");
        }
    }
}
