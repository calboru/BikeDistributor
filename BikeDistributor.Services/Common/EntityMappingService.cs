using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BikeDistributor.Interfaces.CommonServices;
using BikeDistributor.Services.Infrastructure;

namespace BikeDistributor.Services.Common
{
    public class EntityMappingService: IEntityMappingService
    {
        private readonly IMapper _mapper;

        public EntityMappingService()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ClientMappingProfile>();
            });
            _mapper = config.CreateMapper();

          
        }

        public virtual TDestination Map<TSource, TDestination>(TSource source) where TSource : class where TDestination : class
        {
            return _mapper.Map<TSource, TDestination>(source);
        }
    }
}
