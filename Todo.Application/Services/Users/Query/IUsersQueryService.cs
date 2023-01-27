using ErrorOr;
using Todo.Domain.Entities;

namespace Todo.Application.Services.Users.Query;

public interface IUsersQueryService{
    public ErrorOr<User> GetUser(string id);
}