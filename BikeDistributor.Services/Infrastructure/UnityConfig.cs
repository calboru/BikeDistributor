using System.Data.Entity;
using BikeDistributor.Data.Common;
using BikeDistributor.Data.Context;
using BikeDistributor.Data.Interfaces.Common;
using BikeDistributor.Interfaces;
using BikeDistributor.Interfaces.CommonServices;
using BikeDistributor.Interfaces.Services;
using BikeDistributor.Services.Common;
using BikeDistributor.Services.Data;
using BikeDistributor.Services.Receipt;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace BikeDistributor.Services.Infrastructure
{
    public static class UnityConfig
    {
        public static IUnityContainer Container { get; set; }

        public static IUnityContainer Register()
        {

            var container = new UnityContainer();
            container.RegisterType<IEntityMappingService, EntityMappingService>();
            container.RegisterType<IAppSettingsService, AppSettingsService>();
            container.RegisterType<ILogService, LogService>();
            container.RegisterType<IJsonSerializerService, JsonSerializerService>();
            container.RegisterType<IFileService, FileService>();
            container.RegisterType<IDiscountService, DiscountService>();
            container.RegisterType(typeof(IRepository), typeof(EntityFrameworkRepository<DbContext>), 
                new InjectionConstructor(Startup.BikeDistribitorDb));
            container.RegisterType<IRandomValueService, RandomValueService>();
            container.RegisterType<IDataRepositoryService, DataRepositoryService>();
            container.RegisterType<IOrderService, OrderService>();
            container.RegisterType<IReceiptService, HtmlReceiptService>();
            container.RegisterType<IReceiptContentService, OrderedReceiptListService>("OrderedList");
            container.RegisterType<IReceiptContentService, TableReceiptListService>("TableList");
         
            Container = container;
            return container;
        }

        
    }
}
