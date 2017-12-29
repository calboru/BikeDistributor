using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeDistributor.Data.Common;

namespace BikeDistributor.Data.Entities
{
    public class OrderLine: BaseEntity<int>
    {
        public Product Product { get; set; }
    }
}
