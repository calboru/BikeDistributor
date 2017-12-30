namespace BikeDistributor.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakingOrderedByIdrequiredinOrder : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "OrderedBy_Id", "dbo.BusinessEntities");
            DropIndex("dbo.Orders", new[] { "OrderedBy_Id" });
            AlterColumn("dbo.Orders", "OrderedBy_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "OrderedBy_Id");
            AddForeignKey("dbo.Orders", "OrderedBy_Id", "dbo.BusinessEntities", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "OrderedBy_Id", "dbo.BusinessEntities");
            DropIndex("dbo.Orders", new[] { "OrderedBy_Id" });
            AlterColumn("dbo.Orders", "OrderedBy_Id", c => c.Int());
            CreateIndex("dbo.Orders", "OrderedBy_Id");
            AddForeignKey("dbo.Orders", "OrderedBy_Id", "dbo.BusinessEntities", "Id");
        }
    }
}
