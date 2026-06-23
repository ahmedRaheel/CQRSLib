using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LibraryService.Api.Domain.Entities;

namespace LibraryService.Api.Infrastructure.Data.Persistence.Configurations;
public sealed class BookPublisherEntityConfiguration : IEntityTypeConfiguration<BookPublisherEntity>
{
    public void Configure(EntityTypeBuilder<BookPublisherEntity> builder)
    {
        builder.ToTable("BookPublishers");
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Book).WithMany().HasForeignKey(x => x.BookId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(x => x.Publisher).WithMany().HasForeignKey(x => x.PublisherId).OnDelete(DeleteBehavior.Cascade);
    }
}