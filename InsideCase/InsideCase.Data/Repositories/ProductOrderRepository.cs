using InsideCase.Domain.Entities;
using InsideCase.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InsideCase.Data.Repositories
{
    public class ProductOrderRepository : Repository<ProductOrder>, IProductOrderRepository
    {
        public ProductOrderRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public List<ProductOrder> GetAllByOrderId(int id)
        {
            return _dbContext.Set<ProductOrder>()
                        .Include(po => po.Product)
                        .Where(po => po.Order_Id == id)
                        .ToList();
        }

        public List<ProductOrder> GetAllByProductId(int id)
        {
            return _dbContext.Set<ProductOrder>()
                        .Include(po => po.Product)
                        .Where(po => po.Product_Id == id)
                        .ToList();
        }
    }
}
