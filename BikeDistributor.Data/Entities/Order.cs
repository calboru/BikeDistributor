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

        public virtual DateTime OrderDate { get; set; }
        public virtual BusinessEntity OrderedBy { get; set; }
        public virtual DiscountCode DiscountCode { get; set; }
        public virtual ICollection<OrderLine> Products { get; set; }

    }
}
