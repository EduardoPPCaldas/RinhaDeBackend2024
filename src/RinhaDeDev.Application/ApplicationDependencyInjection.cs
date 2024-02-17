using Microsoft.Extensions.DependencyInjection;

using RinhaDeDev.Application.UseCases;

namespace RinhaDeDev.Application;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ITransactionUseCase, TransactionUseCase>();
        services.AddScoped<IExtractUseCase, ExtractUseCase>();

        return services;
    }
}
