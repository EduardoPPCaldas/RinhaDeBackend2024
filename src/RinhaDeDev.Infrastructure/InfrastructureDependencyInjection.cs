using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using RinhaDeDev.Domain.Repositories;
using RinhaDeDev.Infrastructure.Persistance;
using RinhaDeDev.Infrastructure.Persistance.Repositories;

namespace RinhaDeDev.Infrastructure;

public static class InfrastructureDependencyInjectio
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDatabase>((sp, conf) => conf.UseNpgsql(sp.GetRequiredService<IConfiguration>()
            .GetConnectionString(ApplicationDatabase.ConnectionString),
            x => x.MigrationsAssembly(typeof(ApplicationDatabase).Assembly.GetName().Name)));

        services.AddScoped<IClientRepository, ClientRepository>();

        return services;
    }
}
