using InsideCase.Core.Schema;
using InsideCase.Core.Schema.OrderSchema.ManageOrderSchema.Request;
using InsideCase.Core.Schema.OrderSchema.ManageOrderSchema.Response;
using InsideCase.Core.Schema.OrderSchema.SearchOrderSchema.Request;
using InsideCase.Core.Schema.OrderSchema.SearchOrderSchema.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InsideCase.API.Controllers
{
    [ApiController]
    [Route("api/order/[controller]")]
    [ApiExplorerSettings(GroupName = "order")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IMediator _mediator;

        public OrderController(ILogger<OrderController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet()]
        public Task<Result<OrderResponse>> GetById([FromQuery] OrderByIdRequest request) =>
                _mediator.Send(request);

        [HttpGet("List")]
        public Task<PaginatedResult<OrderResponse>> List([FromQuery] ListOrderRequest request) =>
                _mediator.Send(request);

        [HttpPost("Create")]
        public Task<Result<OrderIdResponse>> Create() =>
                _mediator.Send(new StartOrderRequest());

        [HttpPost("Close")]
        public Task<Result> Close([FromBody] NewOrderRequest request) =>
                _mediator.Send(request);

        [HttpDelete("Delete")]
        public Task<Result> Delete([FromQuery] RemoveOrderRequest request) =>
                _mediator.Send(request);
    }
}
