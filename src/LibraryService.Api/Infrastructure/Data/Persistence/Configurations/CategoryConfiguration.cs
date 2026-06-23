using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LibraryService.Api.Domain.Entities;

namespace LibraryService.Api.Infrastructure.Data.Persistence.Configurations;
public sealed class CategoryEntityConfiguration : IEntityTypeConfiguration<CategoryEntity>
{
    public void Configure(EntityTypeBuilder<CategoryEntity> builder)
    {
        builder.ToTable("Categories");
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.BookCategories).WithOne().HasForeignKey("CategoryId").OnDelete(DeleteBehavior.Restrict);
    }
}