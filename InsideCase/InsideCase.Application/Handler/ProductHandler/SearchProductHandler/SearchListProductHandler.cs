using MediatR;
using InsideCase.Core.Schema;
using InsideCase.Application.Services.ProductService.Interfaces;
using InsideCase.Core.Schema.ProductSchema.SearchProductSchema.Request;
using InsideCase.Core.Schema.ProductSchema.SearchProductSchema.Response;

namespace InsideCase.Application.Handler.ProductHandler.SearchProductHandler
{
    public class RemoveProductHandler : IRequestHandler<ListProductRequest, PaginatedResult<ProductResponse>>
    {
        private readonly ISearchProductService _searchProductService;

        public RemoveProductHandler(ISearchProductService searchProductService)
        {
            _searchProductService = searchProductService;
        }

        public async Task<PaginatedResult<ProductResponse>> Handle(ListProductRequest request, CancellationToken cancellationToken) =>
                            await _searchProductService.ListProduct();
    }
}