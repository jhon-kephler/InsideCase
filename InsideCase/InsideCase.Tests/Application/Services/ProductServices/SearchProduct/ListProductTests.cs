using InsideCase.Domain.Entities;
using InsideCase.Tests.Application.Services.ServicesBase;
using InsideCase.Tests.Mock.RepositoryMock;

namespace InsideCase.Tests.Application.Services.ProductServices.SearchProduct
{
    public class ListProductTests : SearchProductServiceBaseTests
    {
        [Fact(DisplayName = "ListProduct returns issuccess true and is not null data")]
        public async Task ListProduct_Returns_IsSuccess_True_And_IsNotNull_Data()
        {
            _productRepositoryMock.Setup(s => s.GetAll()).Returns(ProductRepositoryMock.ListProduct());

            var getListProduct = await _searchProductService.ListProduct();

            Assert.True(getListProduct.IsSuccess && getListProduct.Data != null);
        }

        [Fact(DisplayName = "ListProduct returns issuccess false and is null data")]
        public async Task ListProduct_Returns_IsSuccess_False_And_IsNull_Data()
        {
            _productRepositoryMock.Setup(s => s.GetAll()).Returns(new List<Product>());

            var getListProduct = await _searchProductService.ListProduct();

            Assert.False(getListProduct.IsSuccess && getListProduct.Data == null);
        }
    }
}
