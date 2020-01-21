namespace ShoppingDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carousels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Photo = c.String(),
                        Url = c.String(),
                        Published = c.Boolean(nullable: false),
                        Locked = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Clothings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ModelNo = c.String(),
                        Price = c.Int(nullable: false),
                        Description = c.String(),
                        Size = c.String(),
                        Category = c.String(),
                        Target = c.String(),
                        Tags = c.String(),
                        Materials = c.String(),
                        MainPhoto = c.String(),
                        Photos = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Shoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ModelNo = c.String(),
                        Price = c.Int(nullable: false),
                        Description = c.String(),
                        Size = c.String(),
                        Category = c.String(),
                        Target = c.String(),
                        Tags = c.String(),
                        Materials = c.String(),
                        MainPhoto = c.String(),
                        Photos = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Shoes");
            DropTable("dbo.Clothings");
            DropTable("dbo.Carousels");
        }
    }
}
