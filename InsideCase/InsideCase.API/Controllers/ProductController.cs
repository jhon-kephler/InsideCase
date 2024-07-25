using InsideCase.Core.Schema;
using InsideCase.Core.Schema.ProductSchema.ManageProductSchema.Request;
using InsideCase.Core.Schema.ProductSchema.SearchProductSchema.Request;
using InsideCase.Core.Schema.ProductSchema.SearchProductSchema.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InsideCase.API.Controllers
{
    [ApiController]
    [Route("api/product/[controller]")]
    [ApiExplorerSettings(GroupName = "product")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IMediator _mediator;

        public ProductController(ILogger<ProductController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet()]
        public Task<Result<ProductResponse>> GetById([FromQuery] ProductByIdRequest request) =>
                _mediator.Send(request);

        [HttpGet("List")]
        public Task<PaginatedResult<ProductResponse>> List([FromQuery] ListProductRequest request) =>
                _mediator.Send(request);

        [HttpPost("Create")]
        public Task<Result> Create([FromBody] NewProductRequest request) =>
                _mediator.Send(request);

        [HttpDelete("Delete")]
        public Task<Result> Delete([FromQuery] RemoveProductRequest request) =>
                _mediator.Send(request);
    }
}