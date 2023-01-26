using Microsoft.Extensions.DependencyInjection;
using Todo.Application.Services.Authentication.Commands;

namespace Todo.Application;

public static class DependencyInjection{
    public static IServiceCollection AddApplication(this IServiceCollection services){
        services.AddScoped<IAuthenticationCommandService, AuthenticationCommandService>();
        return services;
    }
}