using ErrorOr;
using Todo.Application.Common.Repository;
using Todo.Domain.Common.Errors;
using Todo.Domain.Entities;

namespace Todo.Application.Services.TodoTasks.Commands;

public class TodoTasksCommandService : ITodoTasksCommandsService{
    private readonly IUserRepository _userRepository;
    private readonly ITodoTaskRepository _todoTaskRepository;

    public TodoTasksCommandService(
        IUserRepository userRepository,
        ITodoTaskRepository todoTaskRepository
    ){
        _userRepository = userRepository;
        _todoTaskRepository = todoTaskRepository;
    }

    public ErrorOr<TodoTask> AddTodoTask(string userId, string name, string description){
        if (_userRepository.Get(userId) is null){
            return Errors.User.UserNotFound;
        }

        TodoTask todoTask = TodoTask.Create(userId, name, description);
        _todoTaskRepository.Add(todoTask);
        _todoTaskRepository.Save();
        return _todoTaskRepository.Get(todoTask.Id);
        return todoTask;
    }
}