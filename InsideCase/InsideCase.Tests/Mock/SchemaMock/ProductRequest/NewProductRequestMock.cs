using InsideCase.Core.Schema.ProductSchema.ManageProductSchema.Request;

namespace InsideCase.Tests.Mock.SchemaMock.ProductRequest
{
    public static class NewProductRequestMock
    {
        public static NewProductRequest NewProduct()
        {
            var request = new NewProductRequest()
            {
                Name_Product = "Agua",
                Price = 10,
                Stock = 100
            };
            return request;
        }
    }
}
