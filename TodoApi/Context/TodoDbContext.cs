using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using TodoApi.Model;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TodoApi.Context
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<TodoTask> Tasks { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
