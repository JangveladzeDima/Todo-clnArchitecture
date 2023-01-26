namespace Todo.Domain.Entities;

public class User{
    public string Id{ get; set; }
    public string Email{ get; set; } = null!;
    public string FirstName{ get; set; } = null!;
    public string LastName{ get; set; } = null!;
    public string Password{ get; set; } = null!;
    public DateTime CreatedAt{ get; set; }
    public DateTime UpdateAt{ get; set; }

    public List<TodoTask>? TodoTasks{ get; set; }

    public static User Create(string email, string firstName, string lastName, string password){
        return new User{
            Id = Guid.NewGuid().ToString(),
            Email = email,
            FirstName = firstName,
            LastName = lastName,
            Password = password
        };
    }
}