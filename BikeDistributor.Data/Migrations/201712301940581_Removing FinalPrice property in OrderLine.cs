namespace BikeDistributor.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovingFinalPricepropertyinOrderLine : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.OrderLines", "FinalPrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderLines", "FinalPrice", c => c.Double(nullable: false));
        }
    }
}
