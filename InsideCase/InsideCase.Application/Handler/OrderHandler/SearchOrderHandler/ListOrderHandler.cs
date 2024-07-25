using InsideCase.Application.Services.OrderService.Interfaces;
using InsideCase.Core.Schema;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsideCase.Core.Schema.OrderSchema.SearchOrderSchema.Request;
using InsideCase.Core.Schema.OrderSchema.SearchOrderSchema.Response;

namespace InsideCase.Application.Handler.OrderHandler.SearchOrderHandler
{
    public class ListOrderHandler : IRequestHandler<ListOrderRequest, PaginatedResult<OrderResponse>>
    {
        private readonly ISearchOrderService _searchOrderService;

        public ListOrderHandler(ISearchOrderService searchOrderService)
        {
            _searchOrderService = searchOrderService;
        }

        public async Task<PaginatedResult<OrderResponse>> Handle(ListOrderRequest request, CancellationToken cancellationToken) =>
                            await _searchOrderService.GetListOrder(request);
    }
}