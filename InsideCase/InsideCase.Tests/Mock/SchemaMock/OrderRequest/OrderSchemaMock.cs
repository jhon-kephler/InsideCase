using InsideCase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsideCase.Tests.Mock.SchemaMock.OrderRequest
{
    public static class OrderSchemaMock
    {
        public static Order StartOrder()
        {
            var order = new Order
            {
                Total_Amount = 0,
                Total_Price = 0,
            };
            return order;
        }
    }
}
