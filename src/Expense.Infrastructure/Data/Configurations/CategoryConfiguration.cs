using Expense.Domain.Entities.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Expense.Infrastructure.Data.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("categories");
        builder.HasKey(category => category.Id);

        builder.Property(category => category.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasData(new List<Category>
        {
            new()
            {
                Id = 1,
                Name = "Oziq-ovqat",
                CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = 2,
                Name = "Transport",
                CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = 3,
                Name = "Mobil aloqa",
                CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = 4,
                Name = "Internet",
                CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = 5,
                Name = "O'yin-kulgi",
                CreatedAt = DateTime.UtcNow
            }
        });
    }
}