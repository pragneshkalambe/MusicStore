namespace TestStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LoginInProgress : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RoleMappings", "EmployeeID", "dbo.Employees");
            DropIndex("dbo.RoleMappings", new[] { "EmployeeID" });
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        AccountID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AccountID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);
            
            AddColumn("dbo.RoleMappings", "CustomerID", c => c.Int(nullable: false));
            AddColumn("dbo.RoleMappings", "Account_AccountID", c => c.Int());
            CreateIndex("dbo.RoleMappings", "Account_AccountID");
            AddForeignKey("dbo.RoleMappings", "Account_AccountID", "dbo.Accounts", "AccountID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoleMappings", "Account_AccountID", "dbo.Accounts");
            DropForeignKey("dbo.Accounts", "CustomerID", "dbo.Customers");
            DropIndex("dbo.RoleMappings", new[] { "Account_AccountID" });
            DropIndex("dbo.Accounts", new[] { "CustomerID" });
            DropColumn("dbo.RoleMappings", "Account_AccountID");
            DropColumn("dbo.RoleMappings", "CustomerID");
            DropTable("dbo.Accounts");
            CreateIndex("dbo.RoleMappings", "EmployeeID");
            AddForeignKey("dbo.RoleMappings", "EmployeeID", "dbo.Employees", "EmployeeID", cascadeDelete: true);
        }
    }
}
