using InsideCase.Core.Schema.OrderSchema.SearchOrderSchema.Request;
using InsideCase.Core.Schema.ProductSchema.SearchProductSchema.Request;
using InsideCase.Domain.Entities;
using InsideCase.Tests.Application.Services.ServicesBase;
using InsideCase.Tests.Mock.RepositoryMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsideCase.Tests.Application.Services.ProductServices.SearchProduct
{
    public class GetProductTests : SearchProductServiceBaseTests
    {
        [Fact(DisplayName = "GetProduct returns issuccess true and data null")]
        public async Task GetProduct_Returns_IsSuccess_True_And_DataNull()
        {
            _productRepositoryMock.Setup(s => s.GetById(1)).Returns(ProductRepositoryMock.GetProduct());

            var productRequest = new ProductByIdRequest(1);
            var getProduct = await _searchProductService.GetProduct(productRequest);

            Assert.True(getProduct.IsSuccess && getProduct.Data != null);
        }

        [Fact(DisplayName = "GetProduct returns issuccess false and data null")]
        public async Task GetProduct_Returns_IsSuccess_False_And_DataNull()
        {
            _productRepositoryMock.Setup(s => s.GetById(0)).Returns(new Product());

            var productRequest = new ProductByIdRequest(0);
            var getProduct = await _searchProductService.GetProduct(productRequest);

            Assert.False(getProduct.IsSuccess && getProduct.Data == null);
        }
    }
}
