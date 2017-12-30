using BikeDistributor.Data.Common;

namespace BikeDistributor.Data.Entities
{
    public class Product: BaseEntity<int>
    {
        public virtual string Brand { get; set; }
        public virtual string Model { get; set; }
        public virtual string Make { get; set; }
        public virtual string Sku { get; set; }
        public double Msrp { get; set; }
    }
}
