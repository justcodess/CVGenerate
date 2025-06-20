using CVGenerate.Core.Interfaces;
using CVGenerate.Infrastructure.Data;
using CVGenerate.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CVGenerate.Infrastructure.Extensions;

public static class ServiceRegistration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // DbContext
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        // Generic Repository
        services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

        // User özel repository
        services.AddScoped<IUserRepository, EfUserRepository>();

        return services;
    }
}