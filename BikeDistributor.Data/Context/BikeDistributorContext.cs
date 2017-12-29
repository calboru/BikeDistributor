using BikeDistributor.Data.Entities;
using System.Data.Entity;
using DbContext = System.Data.Entity.DbContext;

namespace BikeDistributor.Data.Context
{
    public class BikeDistributorContext: DbContext
    {
         
        public  DbSet<Product> Products { get; set; }
        public DbSet<BusinessEntity> BusinessEntities { get; set; }

        public BikeDistributorContext() :base("name=CompactDB")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BusinessEntity>()
                .HasMany(l => l.Location)
                .WithRequired()
                .HasForeignKey(x => x.BusinessEntityId)
                .WillCascadeOnDelete();
        }
    }
}
