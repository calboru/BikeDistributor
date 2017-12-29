using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeDistributor.Data.Common;

namespace BikeDistributor.Data.Entities
{
    public class Order: BaseEntity<int>
    {

        public DateTime OrderDate { get; set; }
        public BusinessEntity OrderedBy { get; set; }
        public DiscountCode DiscountCode { get; set; }
        public ICollection<OrderLine> Products { get; set; }

    }
}
