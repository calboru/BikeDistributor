using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeDistributor.Data.Common;

namespace BikeDistributor.Data.Entities
{
    public class Location: BaseEntity<int>
    {
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
