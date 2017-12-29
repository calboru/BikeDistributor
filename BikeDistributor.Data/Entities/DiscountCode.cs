using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeDistributor.Data.Common;

namespace BikeDistributor.Data.Entities
{
   public class DiscountCode : BaseEntity<int>
    {
        public string CampainCode { get; set; }
        public int QuantityRange1 { get; set; }
        public int QuantityRange2 { get; set; }

        public string Flag { get; set; }

        public double DiscountRate { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
