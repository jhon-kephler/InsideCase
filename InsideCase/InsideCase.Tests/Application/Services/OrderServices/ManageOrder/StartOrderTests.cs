using InsideCase.Core.Schema.InternSchema;
using InsideCase.Core.Schema.OrderSchema.ManageOrderSchema.Request;
using InsideCase.Domain.Entities;
using InsideCase.Tests.Application.Services.ServicesBase;
using InsideCase.Tests.Mock.RepositoryMock;
using InsideCase.Tests.Mock.SchemaMock.OrderRequest;
using Moq;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace InsideCase.Tests.Application.Services.OrderServices.ManageOrder
{
    public class StartOrderTests : ManageOrderServiceBaseTests
    {
        [Fact(DisplayName = "StartOrder returns issuccess true and statuscode 200")]
        public async Task StartOrder_Returns_IsSuccess_True_And_StatusCode_200()
        {
            _saveOrderCommandMock.Setup(s => s.SaveOrder(It.IsAny<Order>())).ReturnsAsync(OrderRepositoryMock.SaveOrder());

            var startOrder = await _manageOrderServiceMock.StartOrder();

            Assert.True(startOrder.IsSuccess && startOrder.StatusCode == 200);
        }

        [Fact(DisplayName = "StartOrder returns issuccess false and statuscode 500")]
        public async Task StartOrder_Returns_IsSuccess_False_And_StatusCode_500()
        {
            _saveOrderCommandMock.Setup(s => s.SaveOrder(OrderSchemaMock.StartOrder()));

            var startOrder = await _manageOrderServiceMock.StartOrder();

            Assert.False(startOrder.IsSuccess && startOrder.StatusCode == 500);
        }
    }
}
