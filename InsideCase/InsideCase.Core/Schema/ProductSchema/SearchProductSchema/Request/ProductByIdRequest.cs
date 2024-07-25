using InsideCase.Core.Schema.ProductSchema.SearchProductSchema.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsideCase.Core.Schema.ProductSchema.SearchProductSchema.Request
{
    public class ProductByIdRequest : IRequest<Result<ProductResponse>>
    {
        public ProductByIdRequest() { }

        public ProductByIdRequest(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
