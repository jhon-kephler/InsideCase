using AutoMapper;
using InsideCase.Core.Schema;
using InsideCase.Domain.Entities;
using InsideCase.Domain.Repositories;
using InsideCase.Application.Services.OrderService.Interfaces;
using InsideCase.Core.Schema.OrderSchema.SearchOrderSchema.Request;
using InsideCase.Core.Schema.OrderSchema.SearchOrderSchema.Response;

namespace InsideCase.Application.Services.OrderService
{
    public class SearchOrderService : ISearchOrderService
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;

        public SearchOrderService(IMapper mapper, IOrderRepository? orderRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        public async Task<PaginatedResult<OrderResponse>> GetListOrder(ListOrderRequest request)
        {
            var result = new PaginatedResult<OrderResponse>();

            try
            {
                var listOrder = await _orderRepository.GetAllOrders(request.Closed);
                if(listOrder == null || listOrder.Count == 0 )
                {
                    result.SetError("Orders is null");
                    return result;
                }

                result = new PaginatedResult<OrderResponse>(_mapper.Map<List<OrderResponse>>(listOrder), request.PageNumber, request.PageSize);
            }
            catch (Exception ex)
            {
                result.SetError(ex.Message);
            }

            return result;
        }

        public async Task<Result<OrderResponse>> GetOrderById(OrderByIdRequest request)
        {
            var result = new Result<OrderResponse>();

            try
            {
                var order = _orderRepository.GetOrderById(request.Id);
                if(order == null)
                {
                    result.SetError("Invalid id");
                    return result;
                }

                result.SetSuccess(_mapper.Map<OrderResponse>(order));
            }
            catch (Exception ex)
            {
                result.SetError(ex.Message);
            }

            return result;
        }
    }
}