using AutoMapper;
using InsideCase.Core.Schema;
using InsideCase.Data.Command.ProductCommand;
using InsideCase.Application.Services.ProductService.Interfaces;
using InsideCase.Core.Schema.ProductSchema.ManageProductSchema.Request;
using InsideCase.Domain.Entities;
using InsideCase.Domain.Repositories;

namespace InsideCase.Application.Services.ProductService
{
    public class ManageProductService : IManageProductService
    {
        private readonly IMapper _mapper;
        private readonly ISaveProductCommand _saveProductCommand;
        private readonly IRemoveProductCommand _removeProductCommand;
        private readonly IUpdateProductCommand _updateProductCommand;
        private readonly IProductOrderRepository _productOrderRepository;

        public ManageProductService(IMapper mapper, 
            ISaveProductCommand saveProductCommand, 
            IRemoveProductCommand removeProductCommand, 
            IUpdateProductCommand updateProductCommand,
            IProductOrderRepository productOrderRepository)
        {
            _mapper = mapper;
            _saveProductCommand = saveProductCommand;
            _removeProductCommand = removeProductCommand;
            _updateProductCommand = updateProductCommand;
            _productOrderRepository = productOrderRepository;
        }

        public async Task<Result> NewProduct(NewProductRequest request)
        {
            var result = new Result();

            try
            {
                await _saveProductCommand.SaveProduct(_mapper.Map<Product>(request));
                result.SetCreate();
            }
            catch (Exception ex)
            {
                result.SetError(ex.Message);
            }

            return result;
        }

        public async Task<Result> RemoveProduct(RemoveProductRequest request)
        {
            var result = new Result();
            try
            {
                var productOrder = _productOrderRepository.GetAllByProductId(request.Id);

                if(productOrder.Count() == 0)
                    await _removeProductCommand.RemoveProduct(request.Id);
                else
                    await _updateProductCommand.SetRemovedProduct(productOrder.Select(s => s.Product).FirstOrDefault());
                
                result.SetSuccess();
            }
            catch (Exception ex)
            {
                result.SetError(ex.Message);
            }

            return result;
        }
    }
}