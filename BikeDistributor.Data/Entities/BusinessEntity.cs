using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeDistributor.Data.Common;

namespace BikeDistributor.Data.Entities
{
    public class BusinessEntity: BaseEntity<int>
    {
       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public ICollection<Location> Location { get; set; }
    }
}
