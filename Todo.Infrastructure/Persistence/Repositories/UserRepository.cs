using Todo.Application.Common.Repository;
using Todo.Domain.Entities;
using Todo.Infrastructure.Database;

namespace Todo.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context){
        _context = context;
    }

    public User? Get(string id){
        return _context.Users.Find(id);
    }

    public User? GetByEmail(string email){
        return _context.Users.FirstOrDefault(u => u.Email == email);
    }

    public void Add(User user){
        _context.Users.Add(user);
    }

    public void Save(){
        _context.SaveChanges();
    }
}