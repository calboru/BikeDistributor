namespace BikeDistributor.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BusinessEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 4000),
                        LastName = c.String(maxLength: 4000),
                        CompanyName = c.String(maxLength: 4000),
                        Name = c.String(maxLength: 4000),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 4000),
                        ModifiedBy = c.String(maxLength: 4000),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BusinessEntityId = c.Int(nullable: false),
                        Type = c.String(maxLength: 4000),
                        AddressLine1 = c.String(maxLength: 4000),
                        AddressLine2 = c.String(maxLength: 4000),
                        Zip = c.String(maxLength: 4000),
                        City = c.String(maxLength: 4000),
                        State = c.String(maxLength: 4000),
                        Country = c.String(maxLength: 4000),
                        TaxRate = c.Double(nullable: false),
                        Name = c.String(maxLength: 4000),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 4000),
                        ModifiedBy = c.String(maxLength: 4000),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BusinessEntities", t => t.BusinessEntityId, cascadeDelete: true)
                .Index(t => t.BusinessEntityId);
            
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
                "dbo.HtmlTemplates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(maxLength: 4000),
                        Content = c.String(maxLength: 4000),
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
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Name = c.String(maxLength: 4000),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 4000),
                        ModifiedBy = c.String(maxLength: 4000),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Brand = c.String(maxLength: 4000),
                        Model = c.String(maxLength: 4000),
                        Make = c.String(maxLength: 4000),
                        Sku = c.String(maxLength: 4000),
                        Msrp = c.Double(nullable: false),
                        TaxedPrice = c.Double(nullable: false),
                        DiscountedPrice = c.Double(nullable: false),
                        Name = c.String(maxLength: 4000),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 4000),
                        ModifiedBy = c.String(maxLength: 4000),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        OrderedById = c.Int(nullable: false),
                        DiscountCodeId = c.Int(nullable: false),
                        Name = c.String(maxLength: 4000),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 4000),
                        ModifiedBy = c.String(maxLength: 4000),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DiscountCodes", t => t.DiscountCodeId, cascadeDelete: true)
                .ForeignKey("dbo.BusinessEntities", t => t.OrderedById, cascadeDelete: true)
                .Index(t => t.OrderedById)
                .Index(t => t.DiscountCodeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderLines", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "OrderedById", "dbo.BusinessEntities");
            DropForeignKey("dbo.Orders", "DiscountCodeId", "dbo.DiscountCodes");
            DropForeignKey("dbo.OrderLines", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Locations", "BusinessEntityId", "dbo.BusinessEntities");
            DropIndex("dbo.Orders", new[] { "DiscountCodeId" });
            DropIndex("dbo.Orders", new[] { "OrderedById" });
            DropIndex("dbo.OrderLines", new[] { "ProductId" });
            DropIndex("dbo.OrderLines", new[] { "OrderId" });
            DropIndex("dbo.Locations", new[] { "BusinessEntityId" });
            DropTable("dbo.Orders");
            DropTable("dbo.Products");
            DropTable("dbo.OrderLines");
            DropTable("dbo.HtmlTemplates");
            DropTable("dbo.DiscountCodes");
            DropTable("dbo.Locations");
            DropTable("dbo.BusinessEntities");
        }
    }
}
