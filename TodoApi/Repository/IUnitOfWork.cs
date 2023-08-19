using System.Threading.Tasks;
using TodoApi.Repository.Categories;
using TodoApi.Repository.TodoTasks;

namespace TodoApi.Repository
{
    public interface IUnitOfWork : IDisposable
    {
       ICategoryRepository CategoryRepository { get; }
       ITodoTaskRepository TodoTaskRepository { get; }

        Task<int> Save();
    }
}
