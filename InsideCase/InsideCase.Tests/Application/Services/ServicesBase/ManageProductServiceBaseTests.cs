using AutoMapper;
using InsideCase.Application.Services.ProductService;
using InsideCase.Core.Mapper;
using InsideCase.Data.Command.ProductCommand;
using InsideCase.Domain.Repositories;
using Moq;

namespace InsideCase.Tests.Application.Services.ServicesBase
{
    public class ManageProductServiceBaseTests
    {
        protected readonly IMapper _mapper;
        protected readonly Mock<ISaveProductCommand> _saveProductCommandMock;
        protected readonly Mock<IRemoveProductCommand> _removeProductCommandMock;
        protected readonly Mock<IUpdateProductCommand> _updateProductCommandMock;
        protected readonly Mock<IProductOrderRepository> _productOrderRepositoryMock;
        protected readonly ManageProductService _manageProductServiceMock;

        public ManageProductServiceBaseTests()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            _saveProductCommandMock = new Mock<ISaveProductCommand>();
            _removeProductCommandMock = new Mock<IRemoveProductCommand>();
            _updateProductCommandMock = new Mock<IUpdateProductCommand>();
            _productOrderRepositoryMock = new Mock<IProductOrderRepository>();

            _manageProductServiceMock = new ManageProductService(_mapper, _saveProductCommandMock.Object, _removeProductCommandMock.Object,
                                                                 _updateProductCommandMock.Object, _productOrderRepositoryMock.Object);
        }
    }
}
