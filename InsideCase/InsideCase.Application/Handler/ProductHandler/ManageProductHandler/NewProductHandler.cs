using MediatR;
using InsideCase.Core.Schema;
using InsideCase.Application.Services.ProductService.Interfaces;
using InsideCase.Core.Schema.ProductSchema.ManageProductSchema.Request;

namespace InsideCase.Application.Handler.ProductHandler.ManageProductHandler
{
    public class NewProductHandler : IRequestHandler<NewProductRequest, Result>
    {
        private readonly IManageProductService _manageProductService;

        public NewProductHandler(IManageProductService manageProductService)
        {
            _manageProductService = manageProductService;
        }

        public async Task<Result> Handle(NewProductRequest request, CancellationToken cancellationToken) =>
                            await _manageProductService.NewProduct(request);
    }
}