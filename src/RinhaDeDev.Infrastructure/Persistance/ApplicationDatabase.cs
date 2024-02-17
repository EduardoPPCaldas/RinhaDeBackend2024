using Microsoft.EntityFrameworkCore;

using RinhaDeDev.Domain.Entities;
using RinhaDeDev.Infrastructure.Persistance.Mappings;

namespace RinhaDeDev.Infrastructure.Persistance;

public class ApplicationDatabase : DbContext
{
    public const string ConnectionString = "RinhaDatabase";
    public DbSet<Client> Clients => Set<Client>();
    public DbSet<BankTransaction> Transactions => Set<BankTransaction>();
    public ApplicationDatabase(DbContextOptions<ApplicationDatabase> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration<Client>(new ClientDbMapping());
    }
}
