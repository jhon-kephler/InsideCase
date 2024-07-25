using InsideCase.Application.Services.OrderService.Interfaces;
using InsideCase.Core.Schema;
using MediatR;
using InsideCase.Core.Schema.OrderSchema.ManageOrderSchema.Request;
using InsideCase.Core.Schema.OrderSchema.ManageOrderSchema.Response;

namespace InsideCase.Application.Handler.OrderHandler.ManageOrderHandler
{
    public class StartOrderHandler : IRequestHandler<StartOrderRequest, Result<OrderIdResponse>>
    {
        private readonly IManageOrderService _manageOrderService;

        public StartOrderHandler(IManageOrderService manageOrderService)
        {
            _manageOrderService = manageOrderService;
        }

        public async Task<Result<OrderIdResponse>> Handle(StartOrderRequest request, CancellationToken cancellationToken) =>
                            await _manageOrderService.StartOrder();
    }
}
