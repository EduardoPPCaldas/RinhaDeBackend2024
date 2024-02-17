using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RinhaDeDev.Application.Adapters;

public record TransactionRequest(
    [property: JsonPropertyName("valor")][property: Required] int Value,
    [property: JsonPropertyName("tipo")][property: Required] string Type,
    [property: JsonPropertyName("descricao")][property: Required] string Description);
