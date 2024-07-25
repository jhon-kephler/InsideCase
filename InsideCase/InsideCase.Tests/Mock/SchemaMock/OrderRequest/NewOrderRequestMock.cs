using InsideCase.Core.Schema.InternSchema;
using InsideCase.Core.Schema.OrderSchema.ManageOrderSchema.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsideCase.Tests.Mock.SchemaMock.OrderRequest
{
    public static class NewOrderRequestMock
    {
        public static NewOrderRequest OrderRequest()
        {
            var orderRequest = new NewOrderRequest()
            {
                Order_Id = 1,
                Produtos = new List<ProductsSchema>
                {
                    new ProductsSchema
                    {
                        Id = 1,
                        Quantidade = 1,
                    },
                    new ProductsSchema
                    {
                        Id = 2,
                        Quantidade = 5,
                    },
                    new ProductsSchema
                    {
                        Id = 3,
                        Quantidade = 4,
                    },
                }
            };
            return orderRequest;
        }
    }
}
