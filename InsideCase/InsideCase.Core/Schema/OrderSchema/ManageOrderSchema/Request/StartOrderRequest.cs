using InsideCase.Core.Schema.OrderSchema.ManageOrderSchema.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsideCase.Core.Schema.OrderSchema.ManageOrderSchema.Request
{
    public class StartOrderRequest : IRequest<Result<OrderIdResponse>>
    {
    }
}
