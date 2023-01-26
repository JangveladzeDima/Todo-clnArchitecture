namespace Todo.Domain.Entities;

public class TodoTask{
    public string Id{ get; set; } = null!;
    public string UserId{ get; set; } = null!;
    public string Name{ get; set; } = null!;
    public string Description{ get; set; } = null!;

    public DateTime CreatedAt{ get; set; }
    public DateTime UpdatedAt{ get; set; }

    public List<TodoSubTask>? TodoSubTasks{ get; set; }
    public User User{ get; set; }

    public TodoTask Create(string userId, string name, string description){
        return new TodoTask{
            Id = Guid.NewGuid().ToString(),
            UserId = userId,
            Name = name,
            Description = description
        };
    }
}