using System.Text.Json.Serialization;

namespace RinhaDeDev.Application.Adapters;

public record BankTransactionResponse(
    [property: JsonPropertyName("valor")] int Value,
    [property: JsonPropertyName("tipo")] string Type,
    [property: JsonPropertyName("descricao")] string Description,
    [property: JsonPropertyName("realizada_em")] DateTimeOffset CreatedAt);
