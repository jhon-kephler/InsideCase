using InsideCase.Data.Command.ProductCommand;
using InsideCase.Domain.Entities;
using InsideCase.Domain.Repositories;

namespace InsideCase.Data.Command.OrderCommand
{
    public interface IUpdateOrderCommand { Task UpdateOrder(Order order); }

    public class UpdateOrderCommand : IUpdateOrderCommand
    {
        private IOrderRepository _repository;

        public UpdateOrderCommand(IOrderRepository repository)
        {
            _repository = repository;
        }

        public Task UpdateOrder(Order order)
        {
            try
            {
                _repository.Update(order.Id, order);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                return Task.FromException(ex);
            }
        }
    }
}