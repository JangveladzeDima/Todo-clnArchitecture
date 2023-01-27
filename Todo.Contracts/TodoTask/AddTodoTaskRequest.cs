namespace Todo.Contracts.TodoTask;

public record AddTodoTaskRequest(
    string Name,
    string Description,
    string UserId
);