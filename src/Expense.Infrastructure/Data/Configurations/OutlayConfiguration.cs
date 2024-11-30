using Bogus;
using Expense.Domain.Entities.Outlays;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Expense.Infrastructure.Data.Configurations;

public class OutlayConfiguration : IEntityTypeConfiguration<Outlay>
{
    public void Configure(EntityTypeBuilder<Outlay> builder)
    {
        builder.ToTable("outlays");

        builder.Property(outlay => outlay.CategoryId)
            .IsRequired();

        builder.Property(outlay => outlay.Date)
            .IsRequired()
            .HasConversion(
                dateOnly => dateOnly.ToDateTime(TimeOnly.MinValue, DateTimeKind.Utc),
                dateTime => DateOnly.FromDateTime(dateTime));

        builder.Property(outlay => outlay.Price)
            .IsRequired();

        builder.HasOne(outlay => outlay.Category)
            .WithMany()
            .HasForeignKey(outlay => outlay.CategoryId);

        builder.Property(outlay => outlay.Comment)
            .HasMaxLength(200);

        builder.HasData(GetOutlays());
    }

    private IEnumerable<Outlay> GetOutlays()
    {
        var outlays = new List<Outlay>();
        var faker = new Faker();

        for (long i = 1; i <= 1000; i++)
        {
            var date = faker.Date.BetweenDateOnly(new DateOnly(2024, 1, 1), new DateOnly(2024, 12, 31));
            
            outlays.Add(new()
            {
                Id = i,
                CategoryId = faker.Random.Long(1, 5),
                Date = date,
                Price = faker.Random.Decimal(1, 200),
                Comment = faker.Commerce.ProductDescription(),
                CreatedAt = faker.Date.Between(
                    date.ToDateTime(TimeOnly.MinValue, DateTimeKind.Utc),
                    date.AddDays(2).ToDateTime(TimeOnly.MinValue, DateTimeKind.Utc))
            });
        }
        
        return outlays;
    }
}