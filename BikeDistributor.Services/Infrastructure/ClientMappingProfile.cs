using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BikeDistributor.Data.Entities;
using BikeDistributor.Models;

namespace BikeDistributor.Services.Infrastructure
{
    public class ClientMappingProfile : Profile
    {
        public ClientMappingProfile()
        {

            CreateMap<Order, OrderModel>()
                .ForMember(x => x.SubTotal, opt => opt.Ignore())
                .ForMember(x => x.TaxTotal, opt => opt.Ignore())
                .ForMember(x => x.DiscountTotal, opt => opt.Ignore());

            //CreateMap<OrderLine, OrderLineModel>()
            //    .ForMember(x => x.Product.DiscountedPrice, opt => opt.Ignore())
            //    .ForMember(x => x.Product.TaxedPrice, opt => opt.Ignore());


        }
    }
}
