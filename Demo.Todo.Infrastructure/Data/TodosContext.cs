using Demo.SharedKernel.Data;
using Microsoft.EntityFrameworkCore;
using Demo.Todo.Core.Entities;
using Demo.Users.Core.Entities;

namespace Demo.Todo.Infrastructure.Data
{
    public class TodosContext : BaseContext<TodosContext>, IDbContextMarker
    {
        public TodosContext(DbContextOptions<TodosContext> options) : base(options)
        {

        }
        public DbSet<TodoItem> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Model.SetDefaultSchema("Todos");

            //   modelBuilder.Ignore<AspNetUsers>();

            //More Configuration Here 

            base.OnModelCreating(modelBuilder);
        }
    }
}
