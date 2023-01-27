using Todo.Application.Common.Repository;
using Todo.Domain.Entities;
using Todo.Infrastructure.Database;

namespace Todo.Infrastructure.Persistence.Repositories;

public class TodoTaskRepository : ITodoTaskRepository{
    private readonly ApplicationDbContext _context;

    public TodoTaskRepository(
        ApplicationDbContext context
    ){
        _context = context;
    }

    public TodoTask? Get(string id){
        return _context.Todos.Find(id);
    }

    public TodoTask? GetByUserId(string userId){
        return _context.Todos.FirstOrDefault(t => t.UserId == userId);
    }

    public void Add(TodoTask todoTask){
        _context.Todos.Add(todoTask);
    }

    public void Save(){
        _context.SaveChanges();
    }
}