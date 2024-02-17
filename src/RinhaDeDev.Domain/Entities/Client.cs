namespace RinhaDeDev.Domain.Entities;

public class Client
{
    public Client(int id, int limit, int balance)
    {
        Id = id;
        Limit = limit;
        Balance = balance;
    }

    public int Id { get; set; }
    public int Limit { get; set; }
    public int Balance { get; set; }
    public ICollection<BankTransaction> Transactions { get; } = [];
}
