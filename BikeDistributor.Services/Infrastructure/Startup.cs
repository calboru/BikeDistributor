using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeDistributor.Data.Context;
using Unity;

namespace BikeDistributor.Services.Infrastructure
{
    public static class Startup
    {
        public static DbContext BikeDistribitorDb { get; set; }
        public static IUnityContainer UnityContainer { get; set; }

        public static void Load()
        {
            BikeDistribitorDb = new BikeDistributorContext();
            UnityContainer = UnityConfig.Register();
          

        }
    }
}
