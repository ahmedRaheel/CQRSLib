using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LibraryService.Api.Domain.Entities;

namespace LibraryService.Api.Infrastructure.Data.Persistence.Configurations;
public sealed class PublisherEntityConfiguration : IEntityTypeConfiguration<PublisherEntity>
{
    public void Configure(EntityTypeBuilder<PublisherEntity> builder)
    {
        builder.ToTable("Publishers");
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.BookPublishers).WithOne().HasForeignKey("PublisherId").OnDelete(DeleteBehavior.Restrict);
    }
}