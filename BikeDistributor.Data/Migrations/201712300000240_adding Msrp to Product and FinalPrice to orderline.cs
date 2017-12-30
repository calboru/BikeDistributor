namespace BikeDistributor.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingMsrptoProductandFinalPricetoorderline : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderLines", "FinalPrice", c => c.Double(nullable: false));
            AddColumn("dbo.Products", "Msrp", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Msrp");
            DropColumn("dbo.OrderLines", "FinalPrice");
        }
    }
}
