namespace TruYum_ASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AfterException : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cart",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        MenuItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MenuItems", t => t.MenuItemId, cascadeDelete: true)
                .Index(t => t.MenuItemId);
            
            CreateTable(
                "dbo.MenuItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Price = c.Single(nullable: false),
                        isActive = c.Boolean(nullable: false),
                        FreeDelivery = c.Boolean(nullable: false),
                        DateOfLaunch = c.DateTime(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cart", "MenuItemId", "dbo.MenuItems");
            DropForeignKey("dbo.MenuItems", "CategoryId", "dbo.Category");
            DropIndex("dbo.MenuItems", new[] { "CategoryId" });
            DropIndex("dbo.Cart", new[] { "MenuItemId" });
            DropTable("dbo.Category");
            DropTable("dbo.MenuItems");
            DropTable("dbo.Cart");
        }
    }
}
