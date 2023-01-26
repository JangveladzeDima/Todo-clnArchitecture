namespace Todo.Application.Services.Authentication;

public record AuthenticationResult(
    string FirstName,
    string LastName,
    string Email,
    string Token
);