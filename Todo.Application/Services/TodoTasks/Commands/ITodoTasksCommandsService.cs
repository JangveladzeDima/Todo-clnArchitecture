using ErrorOr;
using Todo.Domain.Entities;

namespace Todo.Application.Services.TodoTasks.Commands;

public interface ITodoTasksCommandsService{
    public ErrorOr<TodoTask> AddTodoTask(string userId, string name, string description);
}