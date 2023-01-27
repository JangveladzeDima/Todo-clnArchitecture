using Microsoft.Extensions.DependencyInjection;
using Todo.Application.Services.Authentication.Commands;
using Todo.Application.Services.TodoTasks.Commands;
using Todo.Application.Services.Users.Query;

namespace Todo.Application;

public static class DependencyInjection{
    public static IServiceCollection AddApplication(this IServiceCollection services){
        services.AddScoped<IAuthenticationCommandService, AuthenticationCommandService>();
        services.AddScoped<IUsersQueryService, UsersQueryService>();
        services.AddScoped<ITodoTasksCommandsService, TodoTasksCommandService>();
        return services;
    }
}