using System.Linq.Expressions;

namespace TodoApi.Repository.Generics
{
    public interface IGenericRepository <T> where T : class
    {
        T GetById(Expression<Func<T, bool>> predicate, List<string>? includes = null);
        IEnumerable<T> GetAll(List<string>? includes = null);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate, List<string>? includes = null);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);
    }
}
