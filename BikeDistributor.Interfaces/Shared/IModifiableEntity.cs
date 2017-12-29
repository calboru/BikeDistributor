using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeDistributor.Interfaces.Shared
{
   public interface IModifiableEntity
    {
        string Name { get; set; }
    }
}
