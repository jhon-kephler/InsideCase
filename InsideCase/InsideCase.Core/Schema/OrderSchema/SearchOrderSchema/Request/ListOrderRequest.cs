using InsideCase.Core.Schema.OrderSchema.SearchOrderSchema.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsideCase.Core.Schema.OrderSchema.SearchOrderSchema.Request
{
    public class ListOrderRequest : IRequest<PaginatedResult<OrderResponse>>
    {
        public ListOrderRequest() { }

        public ListOrderRequest(bool? closed, int pageNumber, int pageSize)
        {
            Closed = closed;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public bool? Closed { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}