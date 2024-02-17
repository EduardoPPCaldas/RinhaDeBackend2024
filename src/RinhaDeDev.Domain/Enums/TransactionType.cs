using System.ComponentModel;

namespace RinhaDeDev.Domain.Enums;

public enum TransactionType
{
    [Description("c")]
    Credit = 1,

    [Description("d")]
    Debit
}
