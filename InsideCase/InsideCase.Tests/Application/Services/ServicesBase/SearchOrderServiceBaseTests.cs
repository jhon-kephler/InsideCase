using AutoMapper;
using InsideCase.Application.Services.OrderService;
using InsideCase.Application.Services.OrderService.Interfaces;
using InsideCase.Core.Mapper;
using InsideCase.Core.Schema.OrderSchema.SearchOrderSchema.Request;
using InsideCase.Domain.Entities;
using InsideCase.Domain.Repositories;
using InsideCase.Tests.Mock.RepositoryMock;
using Moq;

namespace InsideCase.Tests.Application.Services.ServicesBase
{
    public class SearchOrderServiceBaseTests
    {
        protected readonly IMapper _mapper;
        protected readonly Mock<IOrderRepository> _orderRepositoryMock;
        protected readonly SearchOrderService _searchOrderService;

        public SearchOrderServiceBaseTests()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<OrderProfile>();
                cfg.AddProfile<ProductProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            _orderRepositoryMock = new Mock<IOrderRepository>();

            _searchOrderService = new SearchOrderService(_mapper, _orderRepositoryMock.Object);
        }
    }
}