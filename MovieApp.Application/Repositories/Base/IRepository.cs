using MovieApp.Domain.Abstract;
using System.Linq.Expressions;

namespace MovieApp.Application.Repositories.Base
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Add(T entity);
        Task<T> AddAsync(T entity);
        void AddRange(IEnumerable<T> entities);
        Task AddRangeAsync(IEnumerable<T> entities);

        T Update(T entity);
        void Remove(T entity);
        T GetById(Guid id);
        Task<T> GetByIdAsync(Guid id);
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? predicate = null, int pageSize = 20, int pageNumber = 0);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, int pageSize = 20, int pageNumber = 0);

    }
}
