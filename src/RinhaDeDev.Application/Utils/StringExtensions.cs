using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using RinhaDeDev.Application.Exceptions;
using RinhaDeDev.Domain.Enums;

namespace RinhaDeDev.Application.Utils;

public static class StringExtensions
{
    public static TransactionType MapToTransactionType(this string str)
    {
        return str switch
        {
            "c" => TransactionType.Credit,
            "d" => TransactionType.Debit,
            _ => throw new HttpErrorResponseException
            {
                ProblemDetails = new ProblemDetails
                {
                    Title = "Invalid transaction type",
                    Detail = "The type of the transaction must be 'd' for debit or 'c' for credit"
                },
                StatusCode = StatusCodes.Status400BadRequest
            }            
        };
    }
}
