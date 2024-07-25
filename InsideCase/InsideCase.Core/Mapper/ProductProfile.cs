using AutoMapper;
using InsideCase.Domain.Entities;
using InsideCase.Core.Schema.ProductSchema.ManageProductSchema.Request;
using InsideCase.Core.Schema.ProductSchema.SearchProductSchema.Response;

namespace InsideCase.Core.Mapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductResponse>()
                    .ForMember(dest => dest.Id, src => src.MapFrom(x => x.Id))
                    .ForMember(dest => dest.Nome_Produto, src => src.MapFrom(x => x.Name_Product))
                    .ForMember(dest => dest.Preco, src => src.MapFrom(x => x.Price))
                    .ForMember(dest => dest.Estoque, src => src.MapFrom(x => x.Stock))
                    .ForMember(dest => dest.Data_Criacao, src => src.MapFrom(x => x.Created_At));

            CreateMap<NewProductRequest, Product>()
                    .ForMember(dest => dest.Name_Product, src => src.MapFrom(x => x.Name_Product))
                    .ForMember(dest => dest.Price, src => src.MapFrom(x => x.Price))
                    .ForMember(dest => dest.Stock, src => src.MapFrom(x => x.Stock))
                    .ForMember(dest => dest.Removed, src => src.MapFrom(x => false));
        }
    }
}
