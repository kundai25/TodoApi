using TodoApi.Model;
using TodoApi.Repository.Generics;

namespace TodoApi.Repository.TodoTasks
{
    public interface ITodoTaskRepository : IGenericRepository<TodoTask>
    {
    }
}
