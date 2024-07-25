using AutoMapper;
using InsideCase.Application.Services.OrderService;
using InsideCase.Core.Mapper;
using InsideCase.Data.Command.OrderCommand;
using InsideCase.Data.Command.ProductCommand;
using InsideCase.Data.Command.ProductOrderCommand;
using InsideCase.Domain.Repositories;
using Moq;

namespace InsideCase.Tests.Application.Services.ServicesBase
{
    public class ManageOrderServiceBaseTests
    {
        protected readonly IMapper _mapper;
        protected readonly Mock<ISaveOrderCommand> _saveOrderCommandMock;
        protected readonly Mock<IOrderRepository> _orderRepositoryMock;
        protected readonly Mock<IProductRepository> _productRepositoryMock;
        protected readonly Mock<IUpdateOrderCommand> _updateOrderCommandMock;
        protected readonly Mock<IRemoveOrderCommand> _removeOrderCommandMock;
        protected readonly Mock<IUpdateProductCommand> _updateProductCommandMock;
        protected readonly Mock<ISaveProductOrderCommand> _saveProductOrderCommandMock;
        protected readonly ManageOrderService _manageOrderServiceMock;

        public ManageOrderServiceBaseTests()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<OrderProfile>();
                cfg.AddProfile<ProductProfile>();
                cfg.AddProfile<ProductOrderProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            _saveOrderCommandMock = new Mock<ISaveOrderCommand>();
            _orderRepositoryMock = new Mock<IOrderRepository>();
            _productRepositoryMock = new Mock<IProductRepository>();
            _updateOrderCommandMock = new Mock<IUpdateOrderCommand>();
            _removeOrderCommandMock = new Mock<IRemoveOrderCommand>();
            _updateProductCommandMock = new Mock<IUpdateProductCommand>();
            _saveProductOrderCommandMock = new Mock<ISaveProductOrderCommand>();

            _manageOrderServiceMock = new ManageOrderService(_mapper, _saveOrderCommandMock.Object, _orderRepositoryMock.Object, _productRepositoryMock.Object,
                                                             _updateOrderCommandMock.Object, _removeOrderCommandMock.Object, _updateProductCommandMock.Object,
                                                             _saveProductOrderCommandMock.Object);
        }
    }
}
