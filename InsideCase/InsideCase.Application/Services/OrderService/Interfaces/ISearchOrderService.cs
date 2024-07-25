using InsideCase.Core.Schema;
using InsideCase.Core.Schema.OrderSchema.SearchOrderSchema.Request;
using InsideCase.Core.Schema.OrderSchema.SearchOrderSchema.Response;

namespace InsideCase.Application.Services.OrderService.Interfaces
{
    public interface ISearchOrderService
    {
        Task<PaginatedResult<OrderResponse>> GetListOrder(ListOrderRequest request);
        Task<Result<OrderResponse>> GetOrderById(OrderByIdRequest request);
    }
}
