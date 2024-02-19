using Microsoft.EntityFrameworkCore;

using RinhaDeDev.Infrastructure.Persistance;

namespace RinhaDeDev.WebApi.Extensions;

public static class HostExtensions
{
    public static async Task<IHost> MigrateDatabase(this IHost app)
    {
        await using var scope = app.Services.CreateAsyncScope();
        var database = scope.ServiceProvider.GetRequiredService<ApplicationDatabase>();
        await database.Database.MigrateAsync();

        return app;
    }
}
