using Microsoft.AspNetCore.Mvc;

namespace RinhaDeDev.Application.Exceptions;

public class HttpErrorResponseException : Exception
{
    public required ProblemDetails ProblemDetails { get; set; }
    public required int StatusCode { get; set; }
}
