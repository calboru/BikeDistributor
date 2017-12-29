using BikeDistributor.Data.Common;

namespace BikeDistributor.Data.Entities
{
    public class Product: BaseEntity<int>
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Make { get; set; }
    }
}
