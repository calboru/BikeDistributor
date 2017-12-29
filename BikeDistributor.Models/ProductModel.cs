using BikeDistributor.Models.Common;

namespace BikeDistributor.Models
{
   public class ProductModel: BaseModel<int>
    {
        public string Brand { get; set; }
        public string Model { get; set; }

        public string Make { get; set; }
        public string Sku { get; set; }
    }
}
