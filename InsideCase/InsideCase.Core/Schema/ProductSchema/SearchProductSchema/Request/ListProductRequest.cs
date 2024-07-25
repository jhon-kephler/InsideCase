using InsideCase.Core.Schema.ProductSchema.SearchProductSchema.Response;
using MediatR;

namespace InsideCase.Core.Schema.ProductSchema.SearchProductSchema.Request
{
    public class ListProductRequest : IRequest<PaginatedResult<ProductResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
