namespace BikeDistributor.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakingproductIdrequiredinorderline : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderLines", "Product_Id", "dbo.Products");
            DropIndex("dbo.OrderLines", new[] { "Product_Id" });
            AlterColumn("dbo.OrderLines", "Product_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.OrderLines", "Product_Id");
            AddForeignKey("dbo.OrderLines", "Product_Id", "dbo.Products", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderLines", "Product_Id", "dbo.Products");
            DropIndex("dbo.OrderLines", new[] { "Product_Id" });
            AlterColumn("dbo.OrderLines", "Product_Id", c => c.Int());
            CreateIndex("dbo.OrderLines", "Product_Id");
            AddForeignKey("dbo.OrderLines", "Product_Id", "dbo.Products", "Id");
        }
    }
}
