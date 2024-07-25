using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsideCase.Core.Schema.ProductSchema.ManageProductSchema.Request
{
    public class NewProductRequest : IRequest<Result>
    {
        public string Name_Product { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
