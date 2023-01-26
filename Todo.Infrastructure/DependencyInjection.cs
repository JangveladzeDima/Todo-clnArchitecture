using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Todo.Application.Common.Authentication;
using Todo.Application.Common.Repository;
using Todo.Infrastructure.Authentication;
using Todo.Infrastructure.Database;
using Todo.Infrastructure.Persistence.Repositories;

namespace Todo.Infrastructure;

public static class DependencyInjection{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        ConfigurationManager configuration){
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        AddPersistence(services);
        return services;
    }

    public static IServiceCollection AddPersistence(this IServiceCollection services){
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}