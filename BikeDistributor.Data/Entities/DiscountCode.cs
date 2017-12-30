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
        public virtual string CampainCode { get; set; }
        public virtual int QuantityRange1 { get; set; }
        public virtual int QuantityRange2 { get; set; }

        public virtual string Flag { get; set; }

        public virtual double DiscountRate { get; set; }

        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }
    }
}
