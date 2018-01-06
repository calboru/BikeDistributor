using AutoMapper;
using BikeDistributor.Data.Entities;
using BikeDistributor.Models;

namespace BikeDistributor.Services.Infrastructure
{
    public class ClientMappingProfile : Profile
    {
        public ClientMappingProfile()
        {

            CreateMap<OrderModel, Order>();
            CreateMap<OrderLineModel, OrderLine>();
            CreateMap<HtmlTemplateModel, HtmlTemplate>();
            CreateMap<Order, OrderModel>()
                .ForMember(x => x.SubTotal, opt => opt.Ignore())
                .ForMember(x => x.TaxTotal, opt => opt.Ignore())
                .ForMember(x => x.DiscountTotal, opt => opt.Ignore());


        }
    }
}
