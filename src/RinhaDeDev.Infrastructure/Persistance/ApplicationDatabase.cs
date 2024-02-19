using Microsoft.EntityFrameworkCore;

using RinhaDeDev.Domain.Entities;
using RinhaDeDev.Infrastructure.Persistance.Mappings;

namespace RinhaDeDev.Infrastructure.Persistance;

public class ApplicationDatabase(DbContextOptions<ApplicationDatabase> options) : DbContext(options)
{
    public const string ConnectionString = "RinhaDatabase";
    public DbSet<Client> Clients => Set<Client>();
    public DbSet<BankTransaction> Transactions => Set<BankTransaction>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ClientDbMapping());
        modelBuilder.ApplyConfiguration(new BankTransactionDbMapping());
    }
}
