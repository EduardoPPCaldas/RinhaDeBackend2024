using RinhaDeDev.WebApi.Middlewares;

namespace RinhaDeDev.WebApi;

public static class WebApiDependencyInjection
{
    public static IServiceCollection AddWebApiServices(this IServiceCollection services)    
    {
        services.AddTransient<HttpErrorResponseMiddleware>();
        
        return services;
    }
}
