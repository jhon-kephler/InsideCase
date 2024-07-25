using AutoMapper;
using InsideCase.Core.Schema.InternSchema;
using InsideCase.Domain.Entities;

namespace InsideCase.Core.Mapper
{
    public class ProductOrderProfile : Profile
    {
        public ProductOrderProfile()
        {
            CreateMap<ProductOrderSchema, ProductOrder>()
                .ForMember(dest => dest.Order_Id, src => src.MapFrom(x => x.Order_Id))
                .ForMember(dest => dest.Product_Id, src => src.MapFrom(x => x.Product_Id))
                .ForMember(dest => dest.Amount, src => src.MapFrom(x => x.Amount));
        }
    }
}
