using InsideCase.Domain.Entities;
using InsideCase.Tests.Application.Services.ServicesBase;
using InsideCase.Tests.Mock.SchemaMock.ProductRequest;

namespace InsideCase.Tests.Application.Services.ProductServices.ManageProduct
{
    public class NewProductTests : ManageProductServiceBaseTests
    {
        [Fact(DisplayName = "NewProduct returns issuccess true and statuscode 201")]
        public async Task NewProduct_Returns_IsSuccess_True_And_StatusCode_201()
        {
            _saveProductCommandMock.Setup(s => s.SaveProduct(new Product())).Returns(Task.CompletedTask);

            var newProduct = await _manageProductServiceMock.NewProduct(NewProductRequestMock.NewProduct());

            Assert.True(newProduct.IsSuccess && newProduct.StatusCode == 201);
        }

        [Fact(DisplayName = "NewProduct returns issuccess false and statuscode 500")]
        public async Task NewProduct_Returns_IsSuccess_False_And_StatusCode_500()
        {
            _saveProductCommandMock.Setup(s => s.SaveProduct(new Product())).Returns(Task.FromException(new Exception()));

            var newProduct = await _manageProductServiceMock.NewProduct(NewProductRequestMock.NewProduct());

            Assert.False(newProduct.IsSuccess && newProduct.StatusCode == 500);
        }
    }
}
