using AutoMapper;
using InsideCase.Core.Schema;
using InsideCase.Domain.Entities;
using InsideCase.Domain.Repositories;
using InsideCase.Core.Schema.InternSchema;
using InsideCase.Data.Command.OrderCommand;
using InsideCase.Data.Command.ProductOrderCommand;
using InsideCase.Application.Services.OrderService.Interfaces;
using InsideCase.Core.Schema.OrderSchema.ManageOrderSchema.Request;
using InsideCase.Core.Schema.OrderSchema.ManageOrderSchema.Response;
using InsideCase.Data.Command.ProductCommand;

namespace InsideCase.Application.Services.OrderService
{
    public class ManageOrderService : IManageOrderService
    {
        private readonly IMapper _mapper;
        private readonly ISaveOrderCommand _saveOrderCommand;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUpdateOrderCommand _updateOrderCommand;
        private readonly IRemoveOrderCommand _removeOrderCommand;
        private readonly IUpdateProductCommand _updateProductCommand;
        private readonly ISaveProductOrderCommand _saveProductOrderCommand;

        public ManageOrderService(IMapper mapper,
            ISaveOrderCommand saveOrderCommand,
            IOrderRepository orderRepository,
            IProductRepository productRepository,
            IUpdateOrderCommand updateOrderCommand,
            IRemoveOrderCommand removeOrderCommand,
            IUpdateProductCommand updateProductCommand,
            ISaveProductOrderCommand saveProductOrderCommand)
        {
            _mapper = mapper;
            _saveOrderCommand = saveOrderCommand;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _updateOrderCommand = updateOrderCommand;
            _removeOrderCommand = removeOrderCommand;
            _updateProductCommand = updateProductCommand;
            _saveProductOrderCommand = saveProductOrderCommand;
        }

        public async Task<Result<OrderIdResponse>> StartOrder()
        {
            var result = new Result<OrderIdResponse>();

            try
            {
                var order = new OrderSchema(0, 0);
                var orderId = await _saveOrderCommand.SaveOrder(_mapper.Map<Order>(order));
                if(orderId == null || orderId.Id == 0)
                {
                    result.SetError("Error of start order");
                    return result;
                }

                var orderIdResponse = new OrderIdResponse(orderId.Id);

                result.SetSuccess(orderIdResponse);
            }
            catch (Exception ex)
            {
                result.SetError(ex.Message);
            }

            return result;
        }

        public async Task<Result> CloseOrder(NewOrderRequest request)
        {
            var result = new Result();

            try
            {
                var order = new OrderSchema(request.Order_Id);
                var listProductOrder = new List<ProductOrderSchema>();

                var productIds = request.Produtos.Select(p => p.Id).ToList();
                var products = _productRepository.GetAllByIds(productIds);
                if(products == null || products.Count == 0)
                {
                    result.SetError("Invalid products");
                    return result;
                }

                var productQuantities = request.Produtos.ToDictionary(p => p.Id, p => p.Quantidade);

                foreach (var product in products)
                {
                    var quantity = productQuantities.GetValueOrDefault(product.Id, 0);

                    order.Total_Price += product.Price * quantity;
                    order.Total_Amount += quantity;
                    product.Stock -= quantity;

                    var productOrder = new ProductOrderSchema
                    {
                        Order_Id = request.Order_Id,
                        Product_Id = product.Id,
                        Amount = quantity
                    };

                    listProductOrder.Add(productOrder);
                }

                var saveProductOrder = await _saveProductOrderCommand.SaveProductOrder(_mapper.Map<List<ProductOrder>>(listProductOrder));
                if (saveProductOrder != null)
                {
                    result.SetError(saveProductOrder);
                    return result;
                }

                await _updateOrderCommand.UpdateOrder(_mapper.Map<Order>(order));

                await _updateProductCommand.UpdateList(products);

                result.SetSuccess();
            }
            catch (Exception ex)
            {
                result.SetError(ex.Message);
            }

            return result;
        }

        public async Task<Result> RemoveOrder(RemoveOrderRequest request)
        {
            var result = new Result();

            try
            {
                var order = _orderRepository.GetById(request.Id);
                if (order == null)
                {
                    result.SetError("Invalid id");
                    return result;
                }

                if (order.Closed)
                {
                    order.Removed = true;
                    await _updateOrderCommand.UpdateOrder(order);
                    result.SetSuccess();
                }
                else
                {
                    await _removeOrderCommand.RemoveOrder(request.Id);
                    result.SetSuccess();
                }
            }
            catch (Exception ex)
            {
                result.SetError(ex.Message);
            }

            return result;
        }
    }
}