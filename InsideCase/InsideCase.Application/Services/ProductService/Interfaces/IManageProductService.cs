using InsideCase.Core.Schema.ProductSchema.ManageProductSchema.Request;
using InsideCase.Core.Schema;

namespace InsideCase.Application.Services.ProductService.Interfaces
{
    public interface IManageProductService
    {
        Task<Result> NewProduct(NewProductRequest request);
        Task<Result> RemoveProduct(RemoveProductRequest request);
    }
}