using InsideCase.Domain.Entities;

namespace InsideCase.Domain.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task UpdateAsync(List<Product> entities);
    }
}
