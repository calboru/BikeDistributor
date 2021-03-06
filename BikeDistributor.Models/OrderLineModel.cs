﻿using BikeDistributor.Models.Common;

namespace BikeDistributor.Models
{
    public class OrderLineModel: BaseModel<int>
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public ProductModel Product { get; set; }
        public int Quantity { get; set; }
  
    }
}
