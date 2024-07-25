using InsideCase.Domain.Entities;

namespace InsideCase.Domain.Repositories
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Update(int id, T entity);
        void Delete(int id);
        T GetById(int id);
        Task<T> AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        List<T> GetAll();
        List<T> GetAllByIds(IEnumerable<int> ids);
    }
}