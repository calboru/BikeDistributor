using System;
using System.Collections.Generic;
using System.Linq;
using BikeDistributor.Models.Common;

namespace BikeDistributor.Models
{
    public class OrderModel: BaseModel<int>
    {
        public virtual DateTime OrderDate { get; set; }
        public virtual BusinessEntityModel OrderedBy { get; set; }
        public virtual DiscountCodeModel DiscountCode { get; set; }
        public virtual ICollection<OrderLineModel> Products { get; set; }

    }
}
