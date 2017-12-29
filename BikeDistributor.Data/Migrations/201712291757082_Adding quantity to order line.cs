namespace BikeDistributor.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addingquantitytoorderline : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderLines", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderLines", "Quantity");
        }
    }
}
