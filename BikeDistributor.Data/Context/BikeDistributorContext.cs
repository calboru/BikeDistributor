using BikeDistributor.Data.Entities;
using System.Data.Entity;
using DbContext = System.Data.Entity.DbContext;

namespace BikeDistributor.Data.Context
{
    public class BikeDistributorContext: DbContext
    {
        public  DbSet<Product> Products { get; set; }
        public DbSet<BusinessEntity> BusinessEntities { get; set; }
        public DbSet<Location> Locations { get; set; }

        public DbSet<DiscountCode> DiscountCodes { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderLine> OrderLines { get; set; }

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

            modelBuilder.Entity<Order>()
                .HasMany(ol => ol.Products)
                .WithRequired()
                .HasForeignKey(x => x.OrderId)
                .WillCascadeOnDelete();

            modelBuilder.Entity<OrderLine>()
                .HasRequired(x => x.Product);

            modelBuilder.Entity<Order>()
                .HasRequired(x => x.OrderedBy);
            

        }
    }
}
