using AutoMapper;
using InsideCase.Application.Services.ProductService.Interfaces;
using InsideCase.Core.Schema;
using InsideCase.Core.Schema.ProductSchema.SearchProductSchema.Request;
using InsideCase.Core.Schema.ProductSchema.SearchProductSchema.Response;
using InsideCase.Domain.Repositories;

namespace InsideCase.Application.Services.ProductService
{
    public class SearchProductService : ISearchProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public SearchProductService(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<Result<ProductResponse>> GetProduct(ProductByIdRequest request)
        {
            var result = new Result<ProductResponse>();

            try
            {
                var product = _productRepository.GetById(request.Id);
                if(product == null || product.Removed)
                {
                    result.SetError("Invalid product id");
                    return result;
                }

                result.SetSuccess(_mapper.Map<ProductResponse>(product));
            }
            catch (Exception ex)
            {
                result.SetError(ex.Message);
            }

            return result;
        }

        public async Task<PaginatedResult<ProductResponse>> ListProduct()
        {
            var result = new PaginatedResult<ProductResponse>();

            try
            {
                var products = _productRepository.GetAll();
                if(products == null ||products.Count == 0)
                {
                    result.SetError("Product is null");
                    return result;
                }

                result.SetSuccess(_mapper.Map<List<ProductResponse>>(products));
            }
            catch (Exception ex)
            {
                result.SetError(ex.Message);
            }

            return result;
        }
    }
}
