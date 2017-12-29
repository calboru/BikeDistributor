namespace BikeDistributor.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedcreatedatetimetonull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BusinessEntities", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.Locations", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.Products", "CreatedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Locations", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.BusinessEntities", "CreatedDate", c => c.DateTime(nullable: false));
        }
    }
}
