using BikeDistributor.Models.Common;

namespace BikeDistributor.Models
{
    public class LocationModel: BaseModel<int>
    {
        /// <summary>
        /// Location type such as Billing, Mailing, Shipping
        /// </summary>
        /// 
        /// 

        public int BusinessEntityId { get; set; }

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
