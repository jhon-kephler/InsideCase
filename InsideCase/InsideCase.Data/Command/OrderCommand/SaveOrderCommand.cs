using InsideCase.Data.Command.ProductCommand;
using InsideCase.Domain.Entities;
using InsideCase.Domain.Repositories;

namespace InsideCase.Data.Command.OrderCommand
{
    public interface ISaveOrderCommand { Task<Order> SaveOrder(Order order); }

    public class SaveOrderCommand : ISaveOrderCommand
    {
        private IRepository<Order> _repository;

        public SaveOrderCommand(IRepository<Order> repository)
        {
            _repository = repository;
        }

        public Task<Order> SaveOrder(Order order)
        {
            try
            {
                return _repository.AddAsync(order);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}