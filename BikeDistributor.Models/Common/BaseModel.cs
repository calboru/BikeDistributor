using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeDistributor.Shared.Interfaces;

namespace BikeDistributor.Models.Common
{
    public abstract class BaseModel<T>:IEntity<T>

    {
        public string Name { get; set; }
        object IEntity.Id { get; }
        public T Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public byte[] Version { get; set; }

    }
}
