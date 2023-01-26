using Todo.Domain.Entities;

namespace Todo.Application.Common.Repository;

public interface IUserRepository{
    User? Get(string id);
    
    User? GetByEmail(string email);
    void Add(User user);

    void Save();
}