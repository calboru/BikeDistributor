using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeDistributor.Data.Common;

namespace BikeDistributor.Data.Entities
{
    public class OrderLine: BaseEntity<int>
    {
        public virtual int OrderId { get; set; }
        public virtual Product Product { get; set; }
        public virtual int Quantity { get; set; }
    }
}
