using InsideCase.Core.Schema.OrderSchema.SearchOrderSchema.Request;
using InsideCase.Domain.Entities;
using InsideCase.Tests.Application.Services.ServicesBase;
using InsideCase.Tests.Mock.RepositoryMock;
using Moq;

namespace InsideCase.Tests.Application.Services.OrderServices.SearchOrder
{
    public class GetListOrderTests : SearchOrderServiceBaseTests
    {
        [Fact(DisplayName = "GetListOrder returns data")]
        public async Task GetListOrder_ReturnsData()
        {
            _orderRepositoryMock.Setup(s => s.GetAllOrders(null)).ReturnsAsync(OrderRepositoryMock.GetAllOrdersMock().Result);

            var listOrderRequest = new ListOrderRequest(null, 1, 10);
            var getListOrder = await _searchOrderService.GetListOrder(listOrderRequest);

            Assert.True(getListOrder.IsSuccess && getListOrder.Data != null);
        }

        [Fact(DisplayName = "GetListOrder filter by closed true")]
        public async Task GetListOrder_FilterByClosedTrue()
        {
            _orderRepositoryMock.Setup(s => s.GetAllOrders(true)).ReturnsAsync(OrderRepositoryMock.GetAllOrdersMock().Result);

            var listOrderRequest = new ListOrderRequest(true, 1, 10);
            var getListOrder = await _searchOrderService.GetListOrder(listOrderRequest);

            Assert.True(getListOrder.IsSuccess && getListOrder.Data != null);
        }

        [Fact(DisplayName = "GetListOrder filter by closed false")]
        public async Task GetListOrder_FilterByClosedFalse()
        {
            _orderRepositoryMock.Setup(s => s.GetAllOrders(false)).ReturnsAsync(OrderRepositoryMock.GetAllOrdersMock().Result);

            var listOrderRequest = new ListOrderRequest(false, 1, 10);
            var getListOrder = await _searchOrderService.GetListOrder(listOrderRequest);

            Assert.True(getListOrder.IsSuccess && getListOrder.Data != null);
        }

        [Fact(DisplayName = "GetListOrder returns false")]
        public async Task GetListOrder_ReturnsFalse()
        {
            _orderRepositoryMock.Setup(s => s.GetAllOrders(null)).ReturnsAsync(new List<Order>());

            var listOrderRequest = new ListOrderRequest(null, 1, 10);
            var getListOrder = await _searchOrderService.GetListOrder(listOrderRequest);

            Assert.False(getListOrder.IsSuccess);
        }
    }
}
