using InsideCase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsideCase.Tests.Mock.RepositoryMock
{
    public static class ProductRepositoryMock
    {
        public static Product GetProduct()
        {
            var product = new Product
            {
                Id = 1,
                Name_Product = "Agua",
                Price = 5,
                Stock = 100,
                Removed = false,
                Created_At = DateTime.Now,
            };
            return product;
        }

        public static List<Product> ListProduct()
        {
            var listProduct = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name_Product = "Agua",
                    Price = 5,
                    Stock = 100,
                    Removed = false,
                    Created_At = DateTime.Now,
                },
                new Product
                {
                    Id = 2,
                    Name_Product = "Refri",
                    Price = 10,
                    Stock = 100,
                    Removed = false,
                    Created_At = DateTime.Now,
                },
                new Product
                {
                    Id = 3,
                    Name_Product = "Suco",
                    Price = 11,
                    Stock = 100,
                    Removed = false,
                    Created_At = DateTime.Now,
                },
                new Product
                {
                    Id = 4,
                    Name_Product = "Papel",
                    Price = 5,
                    Stock = 100,
                    Removed = false,
                    Created_At = DateTime.Now,
                },
            };
            return listProduct;
        }
    }
}
