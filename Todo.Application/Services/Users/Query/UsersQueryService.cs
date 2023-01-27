using ErrorOr;
using Todo.Application.Common.Repository;
using Todo.Domain.Common.Errors;
using Todo.Domain.Entities;

namespace Todo.Application.Services.Users.Query;

public class UsersQueryService : IUsersQueryService{
    private readonly IUserRepository _userRepository;

    public UsersQueryService(IUserRepository userRepository){
        _userRepository = userRepository;
    }

    public ErrorOr<User> GetUser(string id){
        User? user = _userRepository.Get(id);
        if (user is null){
            return Errors.User.UserNotFound;
        }

        return user;
    }
}