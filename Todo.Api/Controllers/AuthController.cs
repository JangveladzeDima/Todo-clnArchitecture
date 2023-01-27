using ErrorOr;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.Services.Authentication;
using Todo.Application.Services.Authentication.Commands;
using Todo.Contracts.Authentication;

namespace Todo.Api.Controllers;

[AllowAnonymous]
[ApiController]
[Route("auth")]
public class AuthController : ApiController{
    private readonly IAuthenticationCommandService _authenticationCommandService;

    public AuthController(
        IAuthenticationCommandService authenticationCommandService
    ){
        _authenticationCommandService = authenticationCommandService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request){
        ErrorOr<AuthenticationResult> result =
            _authenticationCommandService.Register(request.Email, request.FirstName, request.LastName,
                request.Password);
        return result.MatchFirst(
            result => Ok(new RegisterResponse(result.FirstName, result.LastName, request.Email, result.Token)),
            Problem
        );
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request){
        ErrorOr<string> result = _authenticationCommandService.Login(request.Email, request.Password);
        return result.MatchFirst(
            result => Ok(new LoginResponse(result)),
            Problem
        );
    }
}