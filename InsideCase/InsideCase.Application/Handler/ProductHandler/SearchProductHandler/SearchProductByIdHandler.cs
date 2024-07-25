using MediatR;
using InsideCase.Core.Schema;
using InsideCase.Application.Services.ProductService.Interfaces;
using InsideCase.Core.Schema.ProductSchema.SearchProductSchema.Request;
using InsideCase.Core.Schema.ProductSchema.SearchProductSchema.Response;

namespace InsideCase.Application.Handler.ProductHandler.SearchProductHandler
{
    public class SearchProductByIdHandler : IRequestHandler<ProductByIdRequest, Result<ProductResponse>>
    {
        private readonly ISearchProductService _searchProductService;

        public SearchProductByIdHandler(ISearchProductService searchProductService)
        {
            _searchProductService = searchProductService;
        }

        public async Task<Result<ProductResponse>> Handle(ProductByIdRequest request, CancellationToken cancellationToken) =>
                            await _searchProductService.GetProduct(request);
    }
}