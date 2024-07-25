using MediatR;

namespace InsideCase.Core.Schema.OrderSchema.ManageOrderSchema.Request
{
    public class RemoveOrderRequest : IRequest<Result>
    {
        public RemoveOrderRequest() { }

        public RemoveOrderRequest(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
