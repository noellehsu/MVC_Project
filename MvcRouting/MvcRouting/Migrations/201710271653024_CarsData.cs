namespace MvcRouting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CarsData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "SoldNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cars", "SoldNumber");
        }
    }
}
