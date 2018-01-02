namespace BikeDistributor.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Movingpricepropertiestoproduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "TaxedPrice", c => c.Double(nullable: false));
            AddColumn("dbo.Products", "DiscountedPrice", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "DiscountedPrice");
            DropColumn("dbo.Products", "TaxedPrice");
        }
    }
}
