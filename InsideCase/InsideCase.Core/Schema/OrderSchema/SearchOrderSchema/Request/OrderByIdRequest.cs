using InsideCase.Core.Schema.OrderSchema.SearchOrderSchema.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsideCase.Core.Schema.OrderSchema.SearchOrderSchema.Request
{
    public class OrderByIdRequest : IRequest<Result<OrderResponse>>
    {
        public OrderByIdRequest() { }

        public OrderByIdRequest(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}