namespace BikeDistributor.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addingentities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DiscountCodes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CampainCode = c.String(maxLength: 4000),
                        QuantityRange1 = c.Int(nullable: false),
                        QuantityRange2 = c.Int(nullable: false),
                        Flag = c.String(maxLength: 4000),
                        DiscountRate = c.Double(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Name = c.String(maxLength: 4000),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 4000),
                        ModifiedBy = c.String(maxLength: 4000),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderLines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        Name = c.String(maxLength: 4000),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 4000),
                        ModifiedBy = c.String(maxLength: 4000),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        Name = c.String(maxLength: 4000),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 4000),
                        ModifiedBy = c.String(maxLength: 4000),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        DiscountCode_Id = c.Int(),
                        OrderedBy_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DiscountCodes", t => t.DiscountCode_Id)
                .ForeignKey("dbo.BusinessEntities", t => t.OrderedBy_Id)
                .Index(t => t.DiscountCode_Id)
                .Index(t => t.OrderedBy_Id);
            
            AddColumn("dbo.Products", "Sku", c => c.String(maxLength: 4000));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderLines", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "OrderedBy_Id", "dbo.BusinessEntities");
            DropForeignKey("dbo.Orders", "DiscountCode_Id", "dbo.DiscountCodes");
            DropForeignKey("dbo.OrderLines", "Product_Id", "dbo.Products");
            DropIndex("dbo.Orders", new[] { "OrderedBy_Id" });
            DropIndex("dbo.Orders", new[] { "DiscountCode_Id" });
            DropIndex("dbo.OrderLines", new[] { "Product_Id" });
            DropIndex("dbo.OrderLines", new[] { "OrderId" });
            DropColumn("dbo.Products", "Sku");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderLines");
            DropTable("dbo.DiscountCodes");
        }
    }
}
