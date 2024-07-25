using InsideCase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsideCase.Tests.Mock.RepositoryMock
{
    public class ProductOrderRepositoryMock
    {
        public static List<ProductOrder> GetAllByProductId()
        {
            var listProduct = new List<ProductOrder>
            {
                new ProductOrder
                {
                    Id = 1,
                    Order_Id = 1,
                    Product_Id = 1,
                    Amount = 1,
                    Created_At = DateTime.Now,
                    Product = new Product
                    {
                        Id = 1,
                        Name_Product = "Agua",
                        Price = 5,
                        Stock = 100,
                        Removed = false,
                        Created_At = DateTime.Now,
                    }
                },
                new ProductOrder
                {
                    Id = 2,
                    Order_Id = 1,
                    Product_Id = 2,
                    Amount = 1,
                    Created_At = DateTime.Now,
                    Product = new Product
                    {
                        Id = 2,
                        Name_Product = "Refri",
                        Price = 10,
                        Stock = 100,
                        Removed = false,
                        Created_At = DateTime.Now,
                    }
                },
                new ProductOrder
                {
                    Id = 3,
                    Order_Id = 1,
                    Product_Id = 3,
                    Amount = 1,
                    Created_At = DateTime.Now,
                    Product = new Product
                    {
                        Id = 3,
                        Name_Product = "Suco",
                        Price = 11,
                        Stock = 100,
                        Removed = false,
                        Created_At = DateTime.Now,
                    }
                },
            };

            return listProduct;
        }
    }
}
