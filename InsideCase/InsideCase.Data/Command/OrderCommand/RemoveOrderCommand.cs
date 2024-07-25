using InsideCase.Data.Command.ProductCommand;
using InsideCase.Domain.Entities;
using InsideCase.Domain.Repositories;

namespace InsideCase.Data.Command.OrderCommand
{
    public interface IRemoveOrderCommand { Task RemoveOrder(int id); }

    public class RemoveOrderCommand : IRemoveOrderCommand
    {
        private IRepository<Order> _repository;

        public RemoveOrderCommand(IRepository<Order> repository)
        {
            _repository = repository;
        }

        public Task RemoveOrder(int id)
        {
            try
            {
                _repository.Delete(id);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                return Task.FromException(ex);
            }
        }
    }
}