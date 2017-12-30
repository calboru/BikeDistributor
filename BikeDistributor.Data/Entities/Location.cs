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
        public virtual int BusinessEntityId { get; set; }
        public virtual string Type { get; set; }

        public virtual string AddressLine1 { get; set; }

        public virtual string AddressLine2 { get; set; }
        public virtual string Zip { get; set; }
        public virtual string City { get; set; }

        public virtual string State { get; set; }
        public virtual string Country { get; set; }

        public virtual double TaxRate { get; set; }
    }
}
