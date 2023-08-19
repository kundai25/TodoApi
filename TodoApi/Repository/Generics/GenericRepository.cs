using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TodoApi.Context;

namespace TodoApi.Repository.Generics
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public readonly TodoDbContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(TodoDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
        }

        public IEnumerable<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> predicate, List<string>? includes = null)
        {
            IQueryable<T> query = _dbSet;
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }

            }

            return query.AsNoTracking().Where(predicate);
        }

        public IEnumerable<T> GetAll(List<string>? includes = null)
        {
            IQueryable<T> query = _dbSet;
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query.AsNoTracking().ToList();

        }

        public T GetById(Expression<Func<T, bool>> expression, List<string>? includes = null)
        {
            IQueryable<T> query = _dbSet;
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query.AsNoTracking().Where(expression).FirstOrDefault();
        }



        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            _dbSet.AttachRange(entities);
        }
    }
}

