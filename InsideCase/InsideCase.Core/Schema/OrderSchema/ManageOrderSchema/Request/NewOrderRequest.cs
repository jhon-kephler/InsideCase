using InsideCase.Core.Schema.InternSchema;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsideCase.Core.Schema.OrderSchema.ManageOrderSchema.Request
{
    public class NewOrderRequest : IRequest<Result>
    {
        public NewOrderRequest() { }

        public int Order_Id { get; set; }
        public List<ProductsSchema> Produtos { get; set; }
    }
}