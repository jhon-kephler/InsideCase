using InsideCase.Domain.Entities;

namespace InsideCase.Domain.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        Order GetOrderById(int id);
        Task<List<Order>> GetAllOrders(bool? closed);
    }
}
