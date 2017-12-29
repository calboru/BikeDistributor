using System;
using System.Collections.Generic;
using System.Linq;
using BikeDistributor.Models.Common;

namespace BikeDistributor.Models
{
    public class OrderModel: BaseModel<int>
    {

        public DateTime OrderDate { get; set; }
        public BusinessEntityModel OrderedBy { get; set; }
        public DiscountCodeModel DiscountCode { get; set; }

        public int TotalQuantity
        {
            get { return Products.Sum(x => x.Quantity); }
        }

        public ICollection<OrderLineModel> Products { get; set; }

    }
}
