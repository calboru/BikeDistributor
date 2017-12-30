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
       
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string CompanyName { get; set; }
        public virtual ICollection<Location> Location { get; set; }
    }
}
