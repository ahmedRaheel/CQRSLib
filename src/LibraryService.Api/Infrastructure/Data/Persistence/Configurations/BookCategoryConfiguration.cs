using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LibraryService.Api.Domain.Entities;

namespace LibraryService.Api.Infrastructure.Data.Persistence.Configurations;
public sealed class BookCategoryEntityConfiguration : IEntityTypeConfiguration<BookCategoryEntity>
{
    public void Configure(EntityTypeBuilder<BookCategoryEntity> builder)
    {
        builder.ToTable("BookCategories");
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Book).WithMany().HasForeignKey(x => x.BookId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(x => x.Category).WithMany().HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.Cascade);
    }
}