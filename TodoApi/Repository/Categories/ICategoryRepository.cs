using TodoApi.Model;
using TodoApi.Repository.Generics;

namespace TodoApi.Repository.Categories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
    }
}
