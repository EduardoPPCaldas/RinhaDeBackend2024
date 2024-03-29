using Microsoft.AspNetCore.Mvc;

using RinhaDeDev.Application.Adapters;
using RinhaDeDev.Application.UseCases;

namespace RinhaDeDev.WebApi.Endpoints;

public static class ClientEndpoints
{
    private const string EndpointGroup = "clientes";
    public static IEndpointRouteBuilder AddClientEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup(EndpointGroup);

        group.MapPost("{id}/transacoes", CreateTransaction);
        group.MapGet("{id}/extrato", Extract);

        return app;
    }

    public static async Task<IResult> CreateTransaction(
        [FromServices] ITransactionUseCase useCase,
        [FromRoute] int id,
        [FromBody] TransactionRequest request,
        CancellationToken cancellationToken)
    {
        var result = await useCase.ExecuteAsync(request, id, cancellationToken);

        return TypedResults.Ok(result);
    }

    public static async Task<IResult> Extract(
        [FromServices] IExtractUseCase useCase,
        [FromRoute] int id,
        CancellationToken cancellationToken)
    {
        return TypedResults.Ok(await useCase.ExecuteAsync(id, cancellationToken));
    }
}
