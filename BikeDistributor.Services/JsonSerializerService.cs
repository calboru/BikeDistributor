using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeDistributor.Interfaces.Services;
using BikeDistributor.Services.Common;
using Newtonsoft.Json;

namespace BikeDistributor.Services
{
    public class JsonSerializerService: BaseService, IJsonSerializerService
    {
        public List<T> DeserializeObject<T>(string source) where T : class
        {
            try
            {
                return JsonConvert.DeserializeObject<List<T>>(source);
            }
            catch (Exception e)
            {
                LogService.Error(e);
                throw;
            }
            
        }
    }
}
