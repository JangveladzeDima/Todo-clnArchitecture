using ErrorOr;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Todo.Api.Controllers;

[Authorize]
public class ApiController : ControllerBase{
    public IActionResult Problem(Error error){
        var statusCode = error.Type switch{
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.NotFound => StatusCodes.Status404NotFound
        };
        return Problem(statusCode: statusCode, title: error.Description);
    }
}