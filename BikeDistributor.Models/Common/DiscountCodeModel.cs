using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeDistributor.Models.Common
{
    public class DiscountCodeModel
    {
        public string Id { get; set; }
        public string CampainCode { get; set; }
        public int QuantityRange1 { get; set; }
        public int QuantityRange2 { get; set; }

        public string Flag { get; set; }

        public double DiscountRate { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
