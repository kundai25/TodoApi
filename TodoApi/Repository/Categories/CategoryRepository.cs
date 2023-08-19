using TodoApi.Context;
using TodoApi.Model;
using TodoApi.Repository.Generics;

namespace TodoApi.Repository.Categories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
       public CategoryRepository(TodoDbContext context) :base(context)
       {
            
       }
    }
}
