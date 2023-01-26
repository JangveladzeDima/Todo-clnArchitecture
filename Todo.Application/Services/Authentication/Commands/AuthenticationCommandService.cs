using ErrorOr;
using Todo.Application.Common.Authentication;
using Todo.Application.Common.Repository;
using Todo.Domain.Common.Errors;
using Todo.Domain.Entities;

namespace Todo.Application.Services.Authentication.Commands;

public class AuthenticationCommandService : IAuthenticationCommandService{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationCommandService(
        IUserRepository userRepository,
        IJwtTokenGenerator jwtTokenGenerator
    ){
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public ErrorOr<AuthenticationResult> Register(string email, string firstName, string lastName, string password){
        if (_userRepository.GetByEmail(email) is not null){
            return Errors.User.DuplicateEmail;
        }

        User user = User.Create(email, firstName, lastName, password);
        _userRepository.Add(user);
        _userRepository.Save();
        String token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(firstName, lastName, email, token);
    }

    public ErrorOr<string> Login(string email, string password){
        User? user = _userRepository.GetByEmail(email);
        if (user is null){
            return Errors.Authentication.InvalidCredentials;
        }

        if (user.Password != password){
            return Errors.Authentication.InvalidCredentials;
        }

        return _jwtTokenGenerator.GenerateToken(user);
    }
}