using InsideCase.Application.Services.OrderService.Interfaces;
using InsideCase.Core.Schema;
using MediatR;
using InsideCase.Core.Schema.OrderSchema.ManageOrderSchema.Request;

namespace InsideCase.Application.Handler.OrderHandler.ManageOrderHandler
{
    public class RemoveOrderHandler : IRequestHandler<RemoveOrderRequest, Result>
    {
        private readonly IManageOrderService _manageOrderService;

        public RemoveOrderHandler(IManageOrderService manageOrderService)
        {
            _manageOrderService = manageOrderService;
        }

        public async Task<Result> Handle(RemoveOrderRequest request, CancellationToken cancellationToken) =>
                            await _manageOrderService.RemoveOrder(request);
    }
}
