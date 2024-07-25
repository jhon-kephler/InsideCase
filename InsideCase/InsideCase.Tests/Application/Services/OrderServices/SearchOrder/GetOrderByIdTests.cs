using InsideCase.Core.Schema.OrderSchema.SearchOrderSchema.Request;
using InsideCase.Domain.Entities;
using InsideCase.Tests.Application.Services.ServicesBase;
using InsideCase.Tests.Mock.RepositoryMock;
using Moq;

namespace InsideCase.Tests.Application.Services.OrderServices.SearchOrder
{
    public class GetOrderByIdTests : SearchOrderServiceBaseTests
    {
        [Fact(DisplayName = "GetOrderById returns issuccess true and data null")]
        public async Task GetOrderById_ReturnsData()
        {
            _orderRepositoryMock.Setup(s => s.GetOrderById(1)).Returns(OrderRepositoryMock.GetOrderById());

            var orderRequest = new OrderByIdRequest(1);
            var getOrder = await _searchOrderService.GetOrderById(orderRequest);

            Assert.True(getOrder.IsSuccess && getOrder.Data != null);
        }

        [Fact(DisplayName = "GetOrderById returns issuccess false and data null")]
        public async Task GetOrderById_Returns_IsSuccess_False_And_DataNull()
        {
            _orderRepositoryMock.Setup(s => s.GetOrderById(0)).Returns(new Order());

            var orderRequest = new OrderByIdRequest(0);
            var getOrder = await _searchOrderService.GetOrderById(orderRequest);

            Assert.False(getOrder.IsSuccess && getOrder.Data == null);
        }
    }
}