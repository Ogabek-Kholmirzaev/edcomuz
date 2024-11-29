using Expense.Domain.Entities.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Expense.Infrastructure.Data.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("categories");

        builder.Property(category => category.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasData(GetCategories());
    }

    private IEnumerable<Category> GetCategories()
    {
        var createdDateTime = new DateTime(2024, 11, 29, 0, 0, 0, DateTimeKind.Utc);

        return new List<Category>
        {
            new()
            {
                Id = 1,
                Name = "Oziq-ovqat",
                CreatedAt = createdDateTime
            },
            new()
            {
                Id = 2,
                Name = "Transport",
                CreatedAt = createdDateTime
            },
            new()
            {
                Id = 3,
                Name = "Mobil aloqa",
                CreatedAt = createdDateTime
            },
            new()
            {
                Id = 4,
                Name = "Internet",
                CreatedAt = createdDateTime
            },
            new()
            {
                Id = 5,
                Name = "O'yin-kulgi",
                CreatedAt = createdDateTime
            }
        };
    }
}