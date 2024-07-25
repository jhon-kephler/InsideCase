using AutoMapper;
using InsideCase.Core.Schema.InternSchema;
using InsideCase.Core.Schema.OrderSchema.SearchOrderSchema.Response;
using InsideCase.Domain.Entities;

namespace InsideCase.Core.Mapper
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderResponse>()
                .ForMember(dest => dest.Id, src => src.MapFrom(x => x.Id))
                .ForMember(dest => dest.Closed, src => src.MapFrom(x => x.Closed))
                .ForMember(dest => dest.Total_Amount, src => src.MapFrom(x => x.Total_Amount))
                .ForMember(dest => dest.Total_Price, src => src.MapFrom(x => x.Total_Price))
                .ForPath(dest => dest.Products, src => src.MapFrom(x => x.ProductOrder.Select(s => s.Product)));

            CreateMap<OrderSchema, Order>()
                .ForMember(dest => dest.Id, src => src.MapFrom(x => x.Id))
                .ForMember(dest => dest.Total_Price, src => src.MapFrom(x => x.Total_Price))
                .ForMember(dest => dest.Total_Amount, src => src.MapFrom(x => x.Total_Amount))
                .ForMember(dest => dest.Closed, src => src.MapFrom(x => true));
        }
    }
}
