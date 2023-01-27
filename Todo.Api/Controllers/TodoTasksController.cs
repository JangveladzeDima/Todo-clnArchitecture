using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.Services.TodoTasks.Commands;
using Todo.Contracts.TodoTask;
using Todo.Domain.Entities;

namespace Todo.Api.Controllers;

[ApiController]
[Route("/TodoTask")]
public class TodoTasksController : ApiController{
    private readonly ITodoTasksCommandsService _todoTasksCommandsService;

    public TodoTasksController(
        ITodoTasksCommandsService todoTasksCommandsService
    ){
        _todoTasksCommandsService = todoTasksCommandsService;
    }

    [HttpPost("add")]
    public IActionResult AddTodoTask(AddTodoTaskRequest request){
        ErrorOr<TodoTask> result =
            _todoTasksCommandsService.AddTodoTask(request.UserId, request.Name, request.Description);
        return result.MatchFirst(
            todoTask => Ok(todoTask),
            Problem
        );
    }
}