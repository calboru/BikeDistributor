using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeDistributor.Models.Common;

namespace BikeDistributor.Models.Product
{
   public class ProductModel: BaseModel<int>
    {
        public string Brand { get; set; }
        public string Model { get; set; }

        public string Make { get; set; }
    }
}
