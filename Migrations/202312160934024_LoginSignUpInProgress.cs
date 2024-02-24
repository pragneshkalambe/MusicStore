﻿namespace TestStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LoginSignUpInProgress : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Customer_CustomerID", c => c.Int());
            CreateIndex("dbo.Orders", "Customer_CustomerID");
            AddForeignKey("dbo.Orders", "Customer_CustomerID", "dbo.Customers", "CustomerID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Customer_CustomerID", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "Customer_CustomerID" });
            DropColumn("dbo.Orders", "Customer_CustomerID");
        }
    }
}
