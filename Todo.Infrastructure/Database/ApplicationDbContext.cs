using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;

namespace Todo.Infrastructure.Database;

public class ApplicationDbContext : DbContext{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){
    }

    public DbSet<User> Users{ get; set; }
    public DbSet<TodoSubTask> TodoSubTasks{ get; set; }
    public DbSet<TodoTask> Todos{ get; set; }
}