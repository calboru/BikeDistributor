using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeDistributor.Interfaces.CommonServices;
using Unity.Attributes;

namespace BikeDistributor.Services.Common
{
    public class BaseService
    {

        [Dependency]
        public ILogService LogService { get; set; }
    }
}
