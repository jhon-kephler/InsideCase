using InsideCase.Core.Schema;
using InsideCase.Core.Schema.ProductSchema.SearchProductSchema.Request;
using InsideCase.Core.Schema.ProductSchema.SearchProductSchema.Response;

namespace InsideCase.Application.Services.ProductService.Interfaces
{
    public interface ISearchProductService
    {
        Task<Result<ProductResponse>> GetProduct(ProductByIdRequest request);
        Task<PaginatedResult<ProductResponse>> ListProduct();
    }
}