using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LibraryService.Api.Domain.Entities;

namespace LibraryService.Api.Infrastructure.Data.Persistence.Configurations;
public sealed class AuthorEntityConfiguration : IEntityTypeConfiguration<AuthorEntity>
{
    public void Configure(EntityTypeBuilder<AuthorEntity> builder)
    {
        builder.ToTable("Authors");
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.BookAuthors).WithOne().HasForeignKey("AuthorId").OnDelete(DeleteBehavior.Restrict);
    }
}