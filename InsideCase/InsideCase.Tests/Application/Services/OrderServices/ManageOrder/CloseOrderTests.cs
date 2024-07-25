using InsideCase.Domain.Entities;
using InsideCase.Tests.Application.Services.ServicesBase;
using InsideCase.Tests.Mock.RepositoryMock;
using InsideCase.Tests.Mock.SchemaMock.OrderRequest;
using Moq;

namespace InsideCase.Tests.Application.Services.OrderServices.ManageOrder
{
    public class CloseOrderTests : ManageOrderServiceBaseTests
    {
        [Fact(DisplayName = "CloseOrder returns issuccess true and statuscode 200")]
        public async Task CloseOrder_Returns_IsSuccess_True_And_StatusCode_200()
        {
            _productRepositoryMock.Setup(s => s.GetAllByIds(It.IsAny<IEnumerable<int>>())).Returns(ProductRepositoryMock.ListProduct());
            _saveProductOrderCommandMock.Setup(s => s.SaveProductOrder(new List<ProductOrder>()));
            _updateOrderCommandMock.Setup(s => s.UpdateOrder(new Order())).Returns(Task.CompletedTask);
            _updateProductCommandMock.Setup(s => s.UpdateList(new List<Product>())).Returns(Task.CompletedTask);

            var closeOrder = await _manageOrderServiceMock.CloseOrder(NewOrderRequestMock.OrderRequest());

            Assert.True(closeOrder.IsSuccess && closeOrder.StatusCode == 200);
        }

        [Fact(DisplayName = "GetAllByIds invalid products returns issuccess false and statuscode 500")]
        public async Task GetAllByIds_Invalid_Products_Returns_IsSuccess_False_And_StatusCode_500()
        {
            _productRepositoryMock.Setup(s => s.GetAllByIds(It.IsAny<IEnumerable<int>>()));

            var closeOrder = await _manageOrderServiceMock.CloseOrder(NewOrderRequestMock.OrderRequest());

            Assert.False(closeOrder.IsSuccess && closeOrder.StatusCode == 500);
        }

        [Fact(DisplayName = "SaveProductOrder returns issuccess false and statuscode 500")]
        public async Task SaveProductOrder_Returns_IsSuccess_False_And_StatusCode_500()
        {
            _productRepositoryMock.Setup(s => s.GetAllByIds(It.IsAny<IEnumerable<int>>())).Returns(ProductRepositoryMock.ListProduct());
            _saveProductOrderCommandMock.Setup(s => s.SaveProductOrder(new List<ProductOrder>())).ReturnsAsync("");

            var closeOrder = await _manageOrderServiceMock.CloseOrder(NewOrderRequestMock.OrderRequest());

            Assert.False(closeOrder.IsSuccess && closeOrder.StatusCode == 500);
        }

        [Fact(DisplayName = "UpdateOrder returns issuccess false and statuscode 500")]
        public async Task UpdateOrder_Returns_IsSuccess_False_And_StatusCode_500()
        {
            _productRepositoryMock.Setup(s => s.GetAllByIds(It.IsAny<IEnumerable<int>>())).Returns(ProductRepositoryMock.ListProduct());
            _saveProductOrderCommandMock.Setup(s => s.SaveProductOrder(new List<ProductOrder>()));
            _updateOrderCommandMock.Setup(s => s.UpdateOrder(new Order())).Returns(Task.FromException(new Exception()));

            var closeOrder = await _manageOrderServiceMock.CloseOrder(NewOrderRequestMock.OrderRequest());

            Assert.False(closeOrder.IsSuccess && closeOrder.StatusCode == 500);
        }

        [Fact(DisplayName = "UpdateList returns issuccess false and statuscode 500")]
        public async Task UpdateList_Returns_IsSuccess_False_And_StatusCode_500()
        {
            _productRepositoryMock.Setup(s => s.GetAllByIds(It.IsAny<IEnumerable<int>>())).Returns(ProductRepositoryMock.ListProduct());
            _saveProductOrderCommandMock.Setup(s => s.SaveProductOrder(new List<ProductOrder>()));
            _updateOrderCommandMock.Setup(s => s.UpdateOrder(new Order())).Returns(Task.CompletedTask);
            _updateProductCommandMock.Setup(s => s.UpdateList(new List<Product>())).Returns(Task.FromException(new Exception()));

            var closeOrder = await _manageOrderServiceMock.CloseOrder(NewOrderRequestMock.OrderRequest());

            Assert.False(closeOrder.IsSuccess && closeOrder.StatusCode == 500);
        }

    }
}