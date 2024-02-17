
using RinhaDeDev.Application.Exceptions;

namespace RinhaDeDev.WebApi.Middlewares;

public class HttpErrorResponseMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (HttpErrorResponseException ex)
        {
            await Results.Json(ex.ProblemDetails, statusCode: ex.StatusCode).ExecuteAsync(context);
        }
    }
}
