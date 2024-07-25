using InsideCase.Core.Schema.OrderSchema.ManageOrderSchema.Request;
using InsideCase.Core.Schema;
using InsideCase.Core.Schema.OrderSchema.ManageOrderSchema.Response;

namespace InsideCase.Application.Services.OrderService.Interfaces
{
    public interface IManageOrderService
    {
        Task<Result<OrderIdResponse>> StartOrder();
        Task<Result> CloseOrder(NewOrderRequest request);
        Task<Result> RemoveOrder(RemoveOrderRequest request);
    }
}