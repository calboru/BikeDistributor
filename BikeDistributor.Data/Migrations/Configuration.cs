namespace BikeDistributor.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BikeDistributor.Data.Context.BikeDistributorContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
        

        protected override void Seed(BikeDistributor.Data.Context.BikeDistributorContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
