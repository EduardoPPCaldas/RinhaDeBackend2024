using System.Text.Json.Serialization;

namespace RinhaDeDev.Application.Adapters;

public record TransactionResponse(
    [property: JsonPropertyName("limite")] int Limit,
    [property: JsonPropertyName("saldo")] int Decimal);

