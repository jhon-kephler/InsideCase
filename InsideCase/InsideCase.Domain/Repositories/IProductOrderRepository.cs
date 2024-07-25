using InsideCase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsideCase.Domain.Repositories
{
    public interface IProductOrderRepository : IRepository<ProductOrder>
    {
        List<ProductOrder> GetAllByOrderId(int id);
        List<ProductOrder> GetAllByProductId(int id);
    }
}
