using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using RinhaDeDev.Domain.Entities;

namespace RinhaDeDev.Infrastructure.Persistance.Mappings;

public class ClientDbMapping : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder
            .HasMany(e => e.Transactions)
            .WithOne(e => e.Client)
            .HasForeignKey("ClientId");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Balance);
        builder.Property(e => e.Limit);
    }
}
