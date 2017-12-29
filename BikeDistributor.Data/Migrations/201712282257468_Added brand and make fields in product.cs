namespace BikeDistributor.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedbrandandmakefieldsinproduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Model", c => c.String(maxLength: 4000));
            AddColumn("dbo.Products", "Make", c => c.String(maxLength: 4000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Make");
            DropColumn("dbo.Products", "Model");
        }
    }
}
