using BikeDistributor.Models.Common;
using Microsoft.Build.Framework;

namespace BikeDistributor.Models
{
    public class LocationModel: BaseModel<int>
    {
       
        public int BusinessEntityId { get; set; }

        /// <summary>
        /// Billing, Shipping
        /// </summary>
        [Required]
        public string Type { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }

        public string State { get; set; }
        public string Country { get; set; }

        public double TaxRate { get; set; }
    }
}
