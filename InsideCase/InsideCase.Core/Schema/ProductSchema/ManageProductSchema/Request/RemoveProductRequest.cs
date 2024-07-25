using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsideCase.Core.Schema.ProductSchema.ManageProductSchema.Request
{
    public class RemoveProductRequest : IRequest<Result>
    {
        public RemoveProductRequest() { }

        public RemoveProductRequest(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
