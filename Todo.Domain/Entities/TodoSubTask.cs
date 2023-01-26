namespace Todo.Domain.Entities;

public class TodoSubTask{
    public string Id{ get; set; } = null!;
    public string TodoTaskId{ get; set; } = null!;
    public string Name{ get; set; } = null!;
    public string Description{ get; set; } = null!;

    public DateTime CreatedAt{ get; set; }
    public DateTime UpdatedAt{ get; set; }

    public TodoTask TodoTask{ get; set; }

    public TodoSubTask Create(string todoTaskId, string name, string description){
        return new TodoSubTask{
            Id = Guid.NewGuid().ToString(),
            TodoTaskId = todoTaskId,
            Name = name,
            Description = description
        };
    }
}