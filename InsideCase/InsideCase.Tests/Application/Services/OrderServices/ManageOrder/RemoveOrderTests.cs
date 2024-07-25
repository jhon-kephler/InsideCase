using InsideCase.Core.Schema.OrderSchema.ManageOrderSchema.Request;
using InsideCase.Core.Schema.ProductSchema.ManageProductSchema.Request;
using InsideCase.Domain.Entities;
using InsideCase.Tests.Application.Services.ServicesBase;
using InsideCase.Tests.Mock.RepositoryMock;

namespace InsideCase.Tests.Application.Services.OrderServices.ManageOrder
{
    public class RemoveOrderTests : ManageOrderServiceBaseTests
    {
        [Fact(DisplayName = "RemoveOrder null returns issuccess false and statuscode 500")]
        public async Task RemoveOrder_Null_Returns_IsSuccess_False_And_StatusCode_500()
        {
            _orderRepositoryMock.Setup(s => s.GetById(0)).Returns(new Order());

            var removeOrder = await _manageOrderServiceMock.RemoveOrder(new RemoveOrderRequest(1));

            Assert.False(removeOrder.IsSuccess && removeOrder.StatusCode == 500);
        }

        [Fact(DisplayName = "UpdateOrder order closed true returns issuccess true and statuscode 200")]
        public async Task UpdateOrder_Order_Closed_True_Returns_IsSuccess_True_And_StatusCode_200()
        {
            _orderRepositoryMock.Setup(s => s.GetById(1)).Returns(OrderRepositoryMock.GetOrderById());
            _updateOrderCommandMock.Setup(s => s.UpdateOrder(OrderRepositoryMock.GetOrderRemovedTrue())).Returns(Task.CompletedTask);

            var removeOrder = await _manageOrderServiceMock.RemoveOrder(new RemoveOrderRequest(1));

            Assert.True(removeOrder.IsSuccess && removeOrder.StatusCode == 200);
        }

        [Fact(DisplayName = "UpdateOrder order closed true returns issuccess false and statuscode 500")]
        public async Task UpdateOrder_Order_Closed_True_Returns_IsSuccess_False_And_StatusCode_500()
        {
            _orderRepositoryMock.Setup(s => s.GetById(1)).Returns(OrderRepositoryMock.GetOrderById());
            _updateOrderCommandMock.Setup(s => s.UpdateOrder(OrderRepositoryMock.GetOrderRemovedTrue())).Returns(Task.FromException(new Exception()));

            var removeOrder = await _manageOrderServiceMock.RemoveOrder(new RemoveOrderRequest(1));

            Assert.False(removeOrder.IsSuccess && removeOrder.StatusCode == 500);
        }

        [Fact(DisplayName = "RemoveOrder order closed false returns issuccess true and statuscode 200")]
        public async Task RemoveOrder_Order_Closed_False_Returns_IsSuccess_True_And_StatusCode_200()
        {
            _orderRepositoryMock.Setup(s => s.GetById(1)).Returns(OrderRepositoryMock.GetOrderClosedFalse());
            _removeOrderCommandMock.Setup(s => s.RemoveOrder(1)).Returns(Task.CompletedTask);

            var removeOrder = await _manageOrderServiceMock.RemoveOrder(new RemoveOrderRequest(1));

            Assert.True(removeOrder.IsSuccess && removeOrder.StatusCode == 200);
        }

        [Fact(DisplayName = "RemoveOrder order closed false returns issuccess false and statuscode 500")]
        public async Task RemoveOrder_Order_Closed_False_Returns_IsSuccess_False_And_StatusCode_500()
        {
            _orderRepositoryMock.Setup(s => s.GetById(1)).Returns(OrderRepositoryMock.GetOrderClosedFalse());
            _removeOrderCommandMock.Setup(s => s.RemoveOrder(1)).Returns(Task.FromException(new Exception()));

            var removeOrder = await _manageOrderServiceMock.RemoveOrder(new RemoveOrderRequest(1));

            Assert.False(removeOrder.IsSuccess && removeOrder.StatusCode == 500);
        }
    }
}
