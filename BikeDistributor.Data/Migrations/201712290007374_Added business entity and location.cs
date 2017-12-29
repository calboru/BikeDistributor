namespace BikeDistributor.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedbusinessentityandlocation : DbMigration
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
                        CreatedDate = c.DateTime(nullable: false),
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
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 4000),
                        ModifiedBy = c.String(maxLength: 4000),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BusinessEntities", t => t.BusinessEntityId, cascadeDelete: true)
                .Index(t => t.BusinessEntityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Locations", "BusinessEntityId", "dbo.BusinessEntities");
            DropIndex("dbo.Locations", new[] { "BusinessEntityId" });
            DropTable("dbo.Locations");
            DropTable("dbo.BusinessEntities");
        }
    }
}
