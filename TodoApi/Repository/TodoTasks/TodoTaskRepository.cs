using TodoApi.Context;
using TodoApi.Model;
using TodoApi.Repository.Generics;

namespace TodoApi.Repository.TodoTasks
{
    public class TodoTaskRepository : GenericRepository<TodoTask>, ITodoTaskRepository
    {
        public TodoTaskRepository(TodoDbContext context) : base (context)
        {
            
        }
    }
}
