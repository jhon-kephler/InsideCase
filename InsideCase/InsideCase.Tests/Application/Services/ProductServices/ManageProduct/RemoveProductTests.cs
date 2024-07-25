using InsideCase.Core.Schema.ProductSchema.ManageProductSchema.Request;
using InsideCase.Domain.Entities;
using InsideCase.Tests.Application.Services.ServicesBase;
using InsideCase.Tests.Mock.RepositoryMock;
using InsideCase.Tests.Mock.SchemaMock.ProductRequest;

namespace InsideCase.Tests.Application.Services.ProductServices.ManageProduct
{
    public class RemoveProductTests : ManageProductServiceBaseTests
    {
        [Fact(DisplayName = "RemoveProduct ProductOrder count bigger 0 returns issuccess true and statuscode 200")]
        public async Task RemoveProduct_ProductOrder_Count_Bigger_0_Returns_IsSuccess_True_And_StatusCode_200()
        {
            _productOrderRepositoryMock.Setup(s => s.GetAllByProductId(1)).Returns(ProductOrderRepositoryMock.GetAllByProductId());
            _saveProductCommandMock.Setup(s => s.SaveProduct(new Product())).Returns(Task.CompletedTask);
            _updateProductCommandMock.Setup(s => s.SetRemovedProduct(ProductRepositoryMock.GetProduct())).Returns(Task.CompletedTask);

            var newProduct = await _manageProductServiceMock.RemoveProduct(new RemoveProductRequest(1));

            Assert.True(newProduct.IsSuccess && newProduct.StatusCode == 200);
        }

        [Fact(DisplayName = "RemoveProduct ProductOrder count bigger 0 SetRemovedProduct error returns issuccess false and statuscode 500")]
        public async Task RemoveProduct_ProductOrder_Count_Bigger_0_SetRemovedProduct_Error_Returns_IsSuccess_False_And_StatusCode_500()
        {
            _productOrderRepositoryMock.Setup(s => s.GetAllByProductId(1)).Returns(ProductOrderRepositoryMock.GetAllByProductId());
            _saveProductCommandMock.Setup(s => s.SaveProduct(new Product())).Returns(Task.CompletedTask);
            _updateProductCommandMock.Setup(s => s.SetRemovedProduct(ProductRepositoryMock.GetProduct())).Returns(Task.FromException(new Exception()));

            var newProduct = await _manageProductServiceMock.RemoveProduct(new RemoveProductRequest(1));

            Assert.False(newProduct.IsSuccess && newProduct.StatusCode == 500);
        }

        [Fact(DisplayName = "RemoveProduct ProductOrder count equal 0 returns issuccess true and statuscode 200")]
        public async Task RemoveProduct_ProductOrder_Count_Equal_0_Returns_IsSuccess_True_And_StatusCode_200()
        {
            _productOrderRepositoryMock.Setup(s => s.GetAllByProductId(1)).Returns(new List<ProductOrder>());
            _saveProductCommandMock.Setup(s => s.SaveProduct(new Product())).Returns(Task.CompletedTask);
            _removeProductCommandMock.Setup(s => s.RemoveProduct(1)).Returns(Task.CompletedTask);

            var newProduct = await _manageProductServiceMock.RemoveProduct(new RemoveProductRequest(1));

            Assert.True(newProduct.IsSuccess && newProduct.StatusCode == 200);
        }

        [Fact(DisplayName = "RemoveProduct ProductOrder count equal 0 RemoveProduct error returns issuccess false and statuscode 500")]
        public async Task RemoveProduct_ProductOrder_Count_Equal_0_RemoveProduct_Error_Returns_IsSuccess_False_And_StatusCode_500()
        {
            _productOrderRepositoryMock.Setup(s => s.GetAllByProductId(1)).Returns(new List<ProductOrder>());
            _saveProductCommandMock.Setup(s => s.SaveProduct(new Product())).Returns(Task.CompletedTask);
            _removeProductCommandMock.Setup(s => s.RemoveProduct(1)).Returns(Task.FromException(new Exception()));

            var newProduct = await _manageProductServiceMock.RemoveProduct(new RemoveProductRequest(1));

            Assert.False(newProduct.IsSuccess && newProduct.StatusCode == 500);
        }
    }
}
