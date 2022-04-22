namespace Groupon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mg3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Product_ProductID", "dbo.Products");
            DropForeignKey("dbo.Products", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.Orders", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.Products", "Order_OrderID", "dbo.Orders");
            DropForeignKey("dbo.Orders", "Product_ProductID1", "dbo.Products");
            DropIndex("dbo.Products", new[] { "User_UserID" });
            DropIndex("dbo.Products", new[] { "Order_OrderID" });
            DropIndex("dbo.Orders", new[] { "Product_ProductID" });
            DropIndex("dbo.Orders", new[] { "User_UserID" });
            DropIndex("dbo.Orders", new[] { "Product_ProductID1" });
            CreateTable(
                "dbo.OrderLines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.OrderID)
                .Index(t => t.ProductID);
            
            AddColumn("dbo.Orders", "OrderNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "OrderDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "FullName", c => c.String());
            AddColumn("dbo.Orders", "AdresBasligi", c => c.String());
            AddColumn("dbo.Orders", "Adres", c => c.String());
            AddColumn("dbo.Orders", "Sehir", c => c.String());
            AddColumn("dbo.Orders", "Semt", c => c.String());
            AddColumn("dbo.Orders", "Mahalle", c => c.String());
            AddColumn("dbo.Orders", "PostaKodu", c => c.String());
            DropColumn("dbo.Products", "User_ID");
            DropColumn("dbo.Products", "Order_ID");
            DropColumn("dbo.Products", "User_UserID");
            DropColumn("dbo.Products", "Order_OrderID");
            DropColumn("dbo.Orders", "Quantity");
            DropColumn("dbo.Orders", "User_ID");
            DropColumn("dbo.Orders", "Product_ID");
            DropColumn("dbo.Orders", "Product_ProductID");
            DropColumn("dbo.Orders", "User_UserID");
            DropColumn("dbo.Orders", "Product_ProductID1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Product_ProductID1", c => c.Int());
            AddColumn("dbo.Orders", "User_UserID", c => c.Int());
            AddColumn("dbo.Orders", "Product_ProductID", c => c.Int());
            AddColumn("dbo.Orders", "Product_ID", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "User_ID", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "Order_OrderID", c => c.Int());
            AddColumn("dbo.Products", "User_UserID", c => c.Int());
            AddColumn("dbo.Products", "Order_ID", c => c.Int());
            AddColumn("dbo.Products", "User_ID", c => c.Int());
            DropForeignKey("dbo.OrderLines", "ProductID", "dbo.Products");
            DropForeignKey("dbo.OrderLines", "OrderID", "dbo.Orders");
            DropIndex("dbo.OrderLines", new[] { "ProductID" });
            DropIndex("dbo.OrderLines", new[] { "OrderID" });
            DropColumn("dbo.Orders", "PostaKodu");
            DropColumn("dbo.Orders", "Mahalle");
            DropColumn("dbo.Orders", "Semt");
            DropColumn("dbo.Orders", "Sehir");
            DropColumn("dbo.Orders", "Adres");
            DropColumn("dbo.Orders", "AdresBasligi");
            DropColumn("dbo.Orders", "FullName");
            DropColumn("dbo.Orders", "OrderDate");
            DropColumn("dbo.Orders", "OrderNumber");
            DropTable("dbo.OrderLines");
            CreateIndex("dbo.Orders", "Product_ProductID1");
            CreateIndex("dbo.Orders", "User_UserID");
            CreateIndex("dbo.Orders", "Product_ProductID");
            CreateIndex("dbo.Products", "Order_OrderID");
            CreateIndex("dbo.Products", "User_UserID");
            AddForeignKey("dbo.Orders", "Product_ProductID1", "dbo.Products", "ProductID");
            AddForeignKey("dbo.Products", "Order_OrderID", "dbo.Orders", "OrderID");
            AddForeignKey("dbo.Orders", "User_UserID", "dbo.Users", "UserID");
            AddForeignKey("dbo.Products", "User_UserID", "dbo.Users", "UserID");
            AddForeignKey("dbo.Orders", "Product_ProductID", "dbo.Products", "ProductID");
        }
    }
}
