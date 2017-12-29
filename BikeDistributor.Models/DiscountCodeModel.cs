using System;
using BikeDistributor.Models.Common;

namespace BikeDistributor.Models
{
    public class DiscountCodeModel: BaseModel<int>
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
