using System.Collections.Generic;
using BikeDistributor.Models.Common;

namespace BikeDistributor.Models
{
    public class BusinessEntityModel:BaseModel<int>
    {
        public string FirstName { get; set; }
        public string LastName  { get; set; }
        public string CompanyName { get; set; }
        public ICollection<LocationModel> Location { get; set; }
    }
}
