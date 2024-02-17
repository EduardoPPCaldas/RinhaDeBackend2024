using System.Text.Json.Serialization;

namespace RinhaDeDev.Application.Adapters;

public record BalanceResponse(
    [property: JsonPropertyName("total")] int Total,
    [property: JsonPropertyName("data_extrato")] DateTimeOffset DateTimeExtract,
    [property: JsonPropertyName("limite")] int Limit);
