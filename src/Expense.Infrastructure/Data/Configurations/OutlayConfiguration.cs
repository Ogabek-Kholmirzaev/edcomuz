using Expense.Domain.Entities.Outlays;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Expense.Infrastructure.Data.Configurations;

public class OutlayConfiguration : IEntityTypeConfiguration<Outlay>
{
    public void Configure(EntityTypeBuilder<Outlay> builder)
    {
        builder.ToTable("outlays");
        builder.HasKey(outlay => outlay.Id);

        builder.Property(outlay => outlay.CategoryId)
            .IsRequired();

        builder.Property(outlay => outlay.Date)
            .IsRequired()
            .HasConversion(
                dateOnly => dateOnly.ToDateTime(TimeOnly.MinValue),
                dateTime => DateOnly.FromDateTime(dateTime));

        builder.Property(outlay => outlay.Price)
            .IsRequired();

        builder.HasOne(outlay => outlay.Category)
            .WithMany()
            .HasForeignKey(outlay => outlay.CategoryId);

        builder.Property(outlay => outlay.Comment)
            .HasMaxLength(200);
    }
}