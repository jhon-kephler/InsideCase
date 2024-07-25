using InsideCase.Application.Services.OrderService.Interfaces;
using InsideCase.Core.Schema;
using MediatR;
using InsideCase.Core.Schema.OrderSchema.ManageOrderSchema.Request;

namespace InsideCase.Application.Handler.OrderHandler.ManageOrderHandler
{
    public class NewOrderHandler : IRequestHandler<NewOrderRequest, Result>
    {
        private readonly IManageOrderService _manageOrderService;

        public NewOrderHandler(IManageOrderService manageOrderService)
        {
            _manageOrderService = manageOrderService;
        }

        public async Task<Result> Handle(NewOrderRequest request, CancellationToken cancellationToken) =>
                            await _manageOrderService.CloseOrder(request);
    }
}
