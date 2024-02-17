using System.Text.Json.Serialization;

namespace RinhaDeDev.Application.Adapters;

public record ExtractResponse(
    [property: JsonPropertyName("saldo")] BalanceResponse Balance,
    [property: JsonPropertyName("ultimas_transacoes")] List<BankTransactionResponse> LastTransactions);

