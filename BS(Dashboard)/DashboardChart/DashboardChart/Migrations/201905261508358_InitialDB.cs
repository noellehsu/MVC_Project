namespace DashboardChart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clothings",
                c => new
                    {
                        ClothingId = c.Int(nullable: false),
                        Size = c.Int(nullable: false),
                        Description = c.String(),
                        UnitInStock = c.Int(nullable: false),
                        Product_ProductId = c.Int(),
                    })
                .PrimaryKey(t => t.ClothingId)
                .ForeignKey("dbo.Products", t => t.Product_ProductId)
                .Index(t => t.Product_ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PhotosJson = c.String(),
                    })
                .PrimaryKey(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clothings", "Product_ProductId", "dbo.Products");
            DropIndex("dbo.Clothings", new[] { "Product_ProductId" });
            DropTable("dbo.Products");
            DropTable("dbo.Clothings");
        }
    }
}
