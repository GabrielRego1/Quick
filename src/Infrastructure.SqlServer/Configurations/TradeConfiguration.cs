using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.SqlServer.Configurations;

internal class TradeConfiguration : IEntityTypeConfiguration<Trade>
{
    public void Configure(EntityTypeBuilder<Trade> builder)
    {
        builder.ToTable("Trades");

        builder.HasKey(t => new { t.Ticker, t.Account });

        builder.Property(t => t.Ticker)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(t => t.Account)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(t => t.SettlementAccount)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(t => t.Side)
            .IsRequired();

        builder.Property(t => t.Quantity)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(t => t.Price)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(t => t.TradeDate)
            .IsRequired();
    }
}