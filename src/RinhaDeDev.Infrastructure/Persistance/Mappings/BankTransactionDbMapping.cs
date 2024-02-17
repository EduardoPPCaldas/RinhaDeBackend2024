using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RinhaDeDev.Domain.Entities;

namespace RinhaDeDev.Infrastructure.Persistance.Mappings;

public class BankTransactionDbMapping : IEntityTypeConfiguration<BankTransaction>
{
    public void Configure(EntityTypeBuilder<BankTransaction> builder)
    {
        builder
            .HasOne(e => e.Client)
            .WithMany(e => e.Transactions)
            .HasForeignKey("ClientId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasKey(e => e.Id);
        builder.Property(e => e.CreatedAt).HasConversion<string>().ValueGeneratedOnAdd();
        builder.Property(e => e.Description).HasMaxLength(10);
        builder.Property(e => e.Value);
        builder.Property(e => e.Type).HasConversion<string>();
    }
}
