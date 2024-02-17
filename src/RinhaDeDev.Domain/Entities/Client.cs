using FluentResults;

using RinhaDeDev.Domain.Enums;

namespace RinhaDeDev.Domain.Entities;

public class Client
{
    public Client(int id, int limit, int balance)
    {
        Id = id;
        Limit = limit;
        Balance = balance;
    }

    public int Id { get; }
    public int Limit { get; }
    public int Balance { get; private set; }
    public ICollection<BankTransaction> Transactions { get; } = [];
    public Result AddTransaction(BankTransaction transaction)
    {
        if (transaction.Type == TransactionType.Debit && Limit * -1 < Balance - transaction.Value)
        {
            return Result.Fail("Not enough limit");
        }

        Transactions.Add(transaction);
        var signedValue = transaction.Type == TransactionType.Debit ? transaction.Value * -1 : transaction.Value;
        Balance += signedValue;
        return Result.Ok();
    }
}
