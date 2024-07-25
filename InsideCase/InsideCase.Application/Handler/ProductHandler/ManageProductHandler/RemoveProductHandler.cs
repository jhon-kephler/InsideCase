using MediatR;
using InsideCase.Core.Schema;
using InsideCase.Application.Services.ProductService.Interfaces;
using InsideCase.Core.Schema.ProductSchema.ManageProductSchema.Request;

namespace InsideCase.Application.Handler.ProductHandler.ManageProductHandler
{
    public class RemoveProductHandler : IRequestHandler<RemoveProductRequest, Result>
    {
        private readonly IManageProductService _manageProductService;

        public RemoveProductHandler(IManageProductService manageProductService)
        {
            _manageProductService = manageProductService;
        }

        public async Task<Result> Handle(RemoveProductRequest request, CancellationToken cancellationToken) =>
                            await _manageProductService.RemoveProduct(request);
    }
}