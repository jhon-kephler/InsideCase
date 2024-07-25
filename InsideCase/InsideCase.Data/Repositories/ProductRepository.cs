using InsideCase.Domain.Entities;
using InsideCase.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InsideCase.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task UpdateAsync(List<Product> entities)
        {
            foreach (var entity in entities)
            {
                var existingEntity = await _dbSet.FindAsync(entity.Id);
                if (existingEntity != null)
                {
                    var properties = typeof(Product).GetProperties();
                    foreach (var property in properties)
                    {
                        var newValue = property.GetValue(entity);
                        var oldValue = property.GetValue(existingEntity);
                        var propertyName = property.Name;

                        if (newValue != null && !newValue.Equals(oldValue))
                        {
                            if (!IsZero(newValue))
                            {
                                property.SetValue(existingEntity, newValue);
                                _dbContext.Entry(existingEntity).Property(propertyName).IsModified = true;
                            }
                        }
                    }
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
