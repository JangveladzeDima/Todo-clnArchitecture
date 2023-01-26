using ErrorOr;

namespace Todo.Application.Services.Authentication.Commands;

public interface IAuthenticationCommandService{
    public ErrorOr<AuthenticationResult> Register(string email, string firstName, string lastName, string password);

    public ErrorOr<string> Login(string email, string password);
}