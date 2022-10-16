using Microsoft.EntityFrameworkCore;
using MovieApp.Application.Repositories.Base;
using MovieApp.Domain.Abstract;
using System.Linq.Expressions;

namespace MovieApp.Persistence.Repositories.Base.Ef.Repository
{
    public class EfRepository<T, TContext> : IRepository<T> where T : BaseEntity
                                                            where TContext : DbContext
    {

        private TContext _context;
        private DbSet<T> _table;

        public EfRepository(TContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public T Add(T entity)
        {
            _table.Add(entity);
            return entity;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _table.AddAsync(entity);
            return entity;
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _table.AddRange(entities);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _table.AddRangeAsync(entities);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? predicate = null, int pageSize = 20, int pageNumber = 0)
        {
            IQueryable<T> queryable = _table;
            if (predicate != null) queryable = _table.Where(predicate);
            return queryable.Skip(pageSize * pageNumber).Take(pageSize).ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, int pageSize = 20, int pageNumber = 0)
        {
            IQueryable<T> queryable = _table;
            if (predicate != null) queryable = _table.Where(predicate);
            return await queryable.Skip(pageSize * pageNumber).Take(pageSize).ToListAsync();
        }

        public T GetById(Guid id)
        {
            return _table.Find(id);
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _table.FindAsync(id);
        }

        public void Remove(T entity)
        {
            _table.Remove(entity);
        }

        public T Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
