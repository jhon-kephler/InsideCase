using InsideCase.Domain.Entities;
using InsideCase.Domain.Repositories;

namespace InsideCase.Data.Command.ProductCommand
{
    public interface IUpdateProductCommand { Task SetRemovedProduct(Product product); Task UpdateList(List<Product> product); }

    public class UpdateProductCommand : IUpdateProductCommand
    {
        private IProductRepository _repository;

        public UpdateProductCommand(IProductRepository repository)
        {
            _repository = repository;
        }

        public Task SetRemovedProduct(Product product)
        {
            try
            {
                _repository.Update(product.Id, product);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                return Task.FromException(ex);
            }
        }

        public Task UpdateList(List<Product> product)
        {
            try
            {
                _repository.UpdateAsync(product);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                return Task.FromException(ex);
            }
        }
    }
}