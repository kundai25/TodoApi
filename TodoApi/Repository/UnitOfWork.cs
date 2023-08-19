using Microsoft.EntityFrameworkCore;
using TodoApi.Context;
using TodoApi.Repository.Categories;
using TodoApi.Repository.TodoTasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TodoApi.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly TodoDbContext _context;
        public UnitOfWork(TodoDbContext context)
        {
            _context = context;

            CategoryRepository = new CategoryRepository (_context);
            TodoTaskRepository = new TodoTaskRepository(_context);

          

        }

       public ICategoryRepository CategoryRepository { get; private set; }
       public ITodoTaskRepository TodoTaskRepository { get; private set; }





        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }

        void IDisposable.Dispose()
        {
            _context.Dispose();
        }

        async Task<int> IUnitOfWork.Save()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
