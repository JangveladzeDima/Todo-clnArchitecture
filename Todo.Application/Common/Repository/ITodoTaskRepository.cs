using Todo.Domain.Entities;

namespace Todo.Application.Common.Repository;

public interface ITodoTaskRepository{
    void Add(TodoTask todoTask);
    TodoTask? Get(string id);
    TodoTask? GetByUserId(string userId);
    void Save();
}