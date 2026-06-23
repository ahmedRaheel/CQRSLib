using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LibraryService.Api.Domain.Entities;

namespace LibraryService.Api.Infrastructure.Data.Persistence.Configurations;
public sealed class BookAuthorEntityConfiguration : IEntityTypeConfiguration<BookAuthorEntity>
{
    public void Configure(EntityTypeBuilder<BookAuthorEntity> builder)
    {
        builder.ToTable("BookAuthors");
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Book).WithMany().HasForeignKey(x => x.BookId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(x => x.Author).WithMany().HasForeignKey(x => x.AuthorId).OnDelete(DeleteBehavior.Cascade);
    }
}