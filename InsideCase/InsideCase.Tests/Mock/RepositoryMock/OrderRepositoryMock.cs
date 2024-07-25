using InsideCase.Domain.Entities;

namespace InsideCase.Tests.Mock.RepositoryMock
{
    public static class OrderRepositoryMock
    {
        public static Order SaveOrder()
        {
            var order = new Order
            {
                Id = 1,
            };
            return order;
        }

        public static Order GetOrderRemovedTrue()
        {
            var order = new Order
            {
                Id = 1,
                Total_Amount = 1,
                Total_Price = 10,
                Closed = true,
                Removed = true,
                Created_At = DateTime.UtcNow,
                ProductOrder = new List<ProductOrder>
                {
                   new ProductOrder
                   {
                       Id = 1,
                       Order_Id = 1,
                       Product_Id = 1,
                       Amount = 1,
                       Created_At = DateTime.UtcNow,
                       Product = new Product
                       {
                           Id = 1,
                           Name_Product = "Agua",
                           Price = 10,
                           Stock = 20,
                           Removed = false,
                           Created_At= DateTime.UtcNow,
                       }
                   }
                }
            };
            return order;
        }
        public static Order GetOrderClosedFalse()
        {
            var order = new Order
            {
                Id = 1,
                Total_Amount = 1,
                Total_Price = 10,
                Closed = false,
                Removed = false,
                Created_At = DateTime.UtcNow,
                ProductOrder = new List<ProductOrder>
                {
                   new ProductOrder
                   {
                       Id = 1,
                       Order_Id = 1,
                       Product_Id = 1,
                       Amount = 1,
                       Created_At = DateTime.UtcNow,
                       Product = new Product
                       {
                           Id = 1,
                           Name_Product = "Agua",
                           Price = 10,
                           Stock = 20,
                           Removed = false,
                           Created_At= DateTime.UtcNow,
                       }
                   }
                }
            };
            return order;
        }

        public static Order GetOrderById()
        {
            var order = new Order
            {
                Id = 1,
                Total_Amount = 1,
                Total_Price = 10,
                Closed = true,
                Removed = false,
                Created_At = DateTime.UtcNow,
                ProductOrder = new List<ProductOrder>
                {
                   new ProductOrder
                   {
                       Id = 1,
                       Order_Id = 1,
                       Product_Id = 1,
                       Amount = 1,
                       Created_At = DateTime.UtcNow,
                       Product = new Product
                       {
                           Id = 1,
                           Name_Product = "Agua",
                           Price = 10,
                           Stock = 20,
                           Removed = false,
                           Created_At= DateTime.UtcNow,
                       }
                   }
                }
            };
            return order;
        }

        public static async Task<List<Order>> GetAllOrdersMock()
        {
            var listOrder = new List<Order>
            {
                new Order
                {
                    Id = 1,
                    Total_Amount = 1,
                    Total_Price = 10,
                    Closed = true,
                    Removed = false,
                    Created_At = DateTime.UtcNow,
                    ProductOrder = new List<ProductOrder>
                    {
                       new ProductOrder
                       {
                           Id = 1,
                           Order_Id = 1,
                           Product_Id = 1,
                           Amount = 1,
                           Created_At = DateTime.UtcNow,
                           Product = new Product
                           {
                               Id = 1,
                               Name_Product = "Agua",
                               Price = 10,
                               Stock = 20,
                               Removed = false,
                               Created_At= DateTime.UtcNow,
                           }
                       }
                    }
                },
                new Order
                {
                    Id = 2,
                    Total_Amount = 3,
                    Total_Price = 30,
                    Closed = false,
                    Removed = false,
                    Created_At = DateTime.UtcNow,
                    ProductOrder = new List<ProductOrder>
                    {
                       new ProductOrder
                       {
                           Id = 2,
                           Order_Id = 2,
                           Product_Id = 1,
                           Amount = 1,
                           Created_At = DateTime.UtcNow,
                           Product = new Product
                           {
                               Id = 1,
                               Name_Product = "Agua",
                               Price = 10,
                               Stock = 20,
                               Removed = false,
                               Created_At= DateTime.UtcNow,
                           }
                       },
                       new ProductOrder
                       {
                           Id = 3,
                           Order_Id = 2,
                           Product_Id = 2,
                           Amount = 1,
                           Created_At = DateTime.UtcNow,
                           Product = new Product
                           {
                               Id = 2,
                               Name_Product = "Refri",
                               Price = 10,
                               Stock = 20,
                               Removed = false,
                               Created_At= DateTime.UtcNow,
                           }
                       },
                       new ProductOrder
                       {
                           Id = 4,
                           Order_Id = 2,
                           Product_Id = 3,
                           Amount = 1,
                           Created_At = DateTime.UtcNow,
                           Product = new Product
                           {
                               Id = 3,
                               Name_Product = "Papel",
                               Price = 10,
                               Stock = 20,
                               Removed = false,
                               Created_At= DateTime.UtcNow,
                           }
                       }
                    }
                },
            };

            return listOrder;
        }
    }
}
