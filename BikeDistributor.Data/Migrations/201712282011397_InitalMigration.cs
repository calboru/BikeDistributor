namespace BikeDistributor.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitalMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Brand = c.String(maxLength: 4000),
                        Name = c.String(maxLength: 4000),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 4000),
                        ModifiedBy = c.String(maxLength: 4000),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Products");
        }
    }
}
