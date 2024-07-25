using InsideCase.Domain.Entities;
using InsideCase.Domain.Repositories;

namespace InsideCase.Data.Command.ProductOrderCommand
{
    public interface ISaveProductOrderCommand { Task<string?> SaveProductOrder(List<ProductOrder> productOrder); }

    public class SaveProductOrderCommand : ISaveProductOrderCommand
    {
        private readonly IProductOrderRepository _repository;

        public SaveProductOrderCommand(IProductOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<string?> SaveProductOrder(List<ProductOrder> productOrder)
        {
            try
            {
                await _repository.AddRangeAsync(productOrder);
                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
