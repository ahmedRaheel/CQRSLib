using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LibraryService.Api.Domain.Entities;

namespace LibraryService.Api.Infrastructure.Data.Persistence.Configurations;
public sealed class BookEntityConfiguration : IEntityTypeConfiguration<BookEntity>
{
    public void Configure(EntityTypeBuilder<BookEntity> builder)
    {
        builder.ToTable("Books");
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.Publishers).WithMany().UsingEntity<BookPublisherEntity>();
        
       
        builder.HasMany(x => x.Loans).WithOne().HasForeignKey("BookId").OnDelete(DeleteBehavior.Restrict);
        builder.HasMany(x => x.Reservations).WithOne().HasForeignKey("BookId").OnDelete(DeleteBehavior.Restrict);
        builder.HasMany(x => x.BookPublishers).WithOne().HasForeignKey("BookId").OnDelete(DeleteBehavior.Restrict);
        builder.HasMany(x => x.BookAuthors).WithOne().HasForeignKey("BookId").OnDelete(DeleteBehavior.Restrict);
        builder.HasMany(x => x.BookCategories).WithOne().HasForeignKey("BookId").OnDelete(DeleteBehavior.Restrict);
    }
}