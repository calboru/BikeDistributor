using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeDistributor.Interfaces.CommonServices;

namespace BikeDistributor.Services.Common
{
    public class AppSettingsService: BaseService, IAppSettingsService
    {
        public string Get(string key)
        {
            try
            {
                return ConfigurationManager.AppSettings[key];
            }
            catch (Exception e)
            {
                LogService.Error(e);
                throw;
            }
        }
    }
}
