using InsideCase.Domain.Entities;
using InsideCase.Domain.Repositories;

namespace InsideCase.Data.Command.ProductCommand
{
    public interface ISaveProductCommand { Task SaveProduct(Product product); }

    public class SaveProductCommand : ISaveProductCommand
    {
        private IRepository<Product> _repository;

        public SaveProductCommand(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public Task SaveProduct(Product product)
        {
            try
            {
                _repository.Add(product);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                return Task.FromException(ex);
            }
        }
    }
}