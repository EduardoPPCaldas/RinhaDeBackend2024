using RinhaDeDev.Domain.Enums;

namespace RinhaDeDev.Domain.Entities;

public class BankTransaction
{
    public BankTransaction(int value, string description, TransactionType type)
    {
        Value = value;
        Description = description;
        Type = type;
    }

    public int Id { get; set; }
    public int Value { get; set; }
    public string Description { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public TransactionType Type { get; set; }
    public Client Client { get; set; } = null!;
}
