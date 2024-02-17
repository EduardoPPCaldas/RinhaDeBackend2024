using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using RinhaDeDev.Application.Adapters;
using RinhaDeDev.Application.Exceptions;
using RinhaDeDev.Domain.Enums;
using RinhaDeDev.Domain.Repositories;
using RinhaDeDev.Domain.Utils;

namespace RinhaDeDev.Application.UseCases;

[GenerateAutomaticInterface]
public class ExtractUseCase : IExtractUseCase
{
    private readonly IClientRepository _clientRepository;

    public ExtractUseCase(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public async Task<ExtractResponse> ExecuteAsync(int id, CancellationToken cancellationToken)
    {
        var client = await _clientRepository.GetById(id, cancellationToken);
        if(client is null)
        {
            throw new HttpErrorResponseException()
            {
                ProblemDetails = new ProblemDetails(),
                StatusCode = StatusCodes.Status404NotFound
            };
        }

        return new ExtractResponse(
            new BalanceResponse(client.Balance, DateTimeOffset.Now, client.Limit),
            client.Transactions.ToList().ConvertAll(
                x => new BankTransactionResponse(x.Value, TransactionTypeHelper.GetDescriptionFast(x.Type), x.Description, x.CreatedAt))
                .OrderBy(x => x.CreatedAt)
                .Take(10)
                .ToList());
    }
}
