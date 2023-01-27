using System.Security.Claims;
using ErrorOr;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Todo.Application.Services.Users.Query;
using Todo.Domain.Entities;

namespace Todo.Api.Controllers;

[ApiController]
[Route("/user")]
// [Authorize]
public class UserController : ApiController{
    private readonly IUsersQueryService _usersQueryService;
    private readonly string? _userId;

    public UserController(
        IUsersQueryService usersQueryService,
        IHttpContextAccessor accessor
    ){
        _usersQueryService = usersQueryService;
        _userId = accessor.HttpContext?.User.Claims.FirstOrDefault()?.Value;
    }

    [HttpGet("")]
    public IActionResult GetUser(){
        ErrorOr<User> result = _usersQueryService.GetUser(_userId);
        return result.MatchFirst(
            user => Ok(user),
            Problem
        );
    }
}