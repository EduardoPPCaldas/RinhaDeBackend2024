using System.ComponentModel;

namespace RinhaDeDev.Domain.Enums;

[GenerateHelper(GenerateHelperOption.UseItselfWhenNoDescription)]
public enum TransactionType
{
    [Description("c")]
    Credit = 1,

    [Description("d")]
    Debit
}
