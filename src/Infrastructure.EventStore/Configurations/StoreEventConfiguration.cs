using Infrastructure.EventStore.Converters;
using Infrastructure.EventStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EventStore.Configurations;

public class StoreEventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.ToTable("Events");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd();

        builder.Property(e => e.Version)
            .IsRequired();

        builder.Property(e => e.AggregateId)
            .IsRequired()
            .HasMaxLength(Event.AggregateIdMaxLength);

        builder.Property(e => e.AggregateName)
            .IsRequired()
            .HasMaxLength(Event.AggregateNameMaxLength);

        builder.Property(e => e.EventName)
            .IsRequired()
            .HasMaxLength(Event.MessageNameMaxLength);

        builder.Property(e => e.Data)
            .IsRequired()
            .HasConversion<EventConverter>();
            
        builder.Property(e => e.Timestamp)
            .IsRequired();

        builder.HasIndex(x => x.AggregateId);
        builder.HasIndex(x => x.Timestamp);
        builder.HasIndex(x => new { x.AggregateId, x.Version }).IsUnique();
    }
}