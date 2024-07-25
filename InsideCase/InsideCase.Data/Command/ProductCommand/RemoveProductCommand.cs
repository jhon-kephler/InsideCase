using InsideCase.Domain.Entities;
using InsideCase.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsideCase.Data.Command.ProductCommand
{
    public interface IRemoveProductCommand { Task RemoveProduct(int id); }

    public class RemoveProductCommand : IRemoveProductCommand
    {
        private readonly IRepository<Product> _repository;

        public RemoveProductCommand(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public Task RemoveProduct(int id)
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
