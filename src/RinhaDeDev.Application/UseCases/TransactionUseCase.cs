using FluentResults;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using RinhaDeDev.Application.Adapters;
using RinhaDeDev.Application.Exceptions;
using RinhaDeDev.Application.Utils;
using RinhaDeDev.Domain.Entities;
using RinhaDeDev.Domain.Enums;
using RinhaDeDev.Domain.Errors;
using RinhaDeDev.Domain.Repositories;
using RinhaDeDev.Domain.Utils;

namespace RinhaDeDev.Application.UseCases;

[GenerateAutomaticInterface]
public class TransactionUseCase : ITransactionUseCase
{
    private readonly IClientRepository _clientRepository;

    public TransactionUseCase(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public async Task<TransactionResponse> ExecuteAsync(TransactionRequest request, int id, CancellationToken cancellationToken)
    {
        var client = await _clientRepository.GetById(id);

        if(client is null)
        {
            throw new HttpErrorResponseException
            {
                ProblemDetails = new ProblemDetails(),
                StatusCode = StatusCodes.Status404NotFound
            };
        }

        var transaction = new BankTransaction(request.Value, request.Description, request.Type.MapToTransactionType());
        if(client.Limit < client.Balance - transaction.Value && transaction.Type == TransactionType.Debit)
        {
            throw new HttpErrorResponseException
            {
                ProblemDetails = new ProblemDetails
                {
                    Title = "Invalid transaction",
                    Detail = "Client does not have enough balance"
                },
                StatusCode = StatusCodes.Status422UnprocessableEntity
            };
        }

        client.Transactions.Add(transaction);
        client.Balance -= transaction.Value;
        await _clientRepository.Update(client, client.Id, cancellationToken);

        return new TransactionResponse(client.Limit, client.Balance);
    }
}
