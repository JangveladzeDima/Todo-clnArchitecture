using Todo.Domain.Entities;

namespace Todo.Application.Common.Authentication;

public interface IJwtTokenGenerator{
    string GenerateToken(User user);
}