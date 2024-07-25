using InsideCase.Domain.Entities;
using InsideCase.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsideCase.Data.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public Order GetOrderById(int id)
        {
            return _dbContext.Set<Order>()
                        .Include(po => po.ProductOrder)
                            .ThenInclude(po => po.Product)
                        .Where(po => po.Id == id)
                        .SingleOrDefault();
        }

        public async Task<List<Order>> GetAllOrders(bool? closed)
        {
            var query = _dbContext.Set<Order>()
                .Include(o => o.ProductOrder)
                    .ThenInclude(po => po.Product)
                .AsQueryable();

            if (closed.HasValue)
                query = query.Where(w => w.Closed == closed.Value);

            return query.ToList();
        }
    }
}
