using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LibraryService.Api.Domain.Entities;

namespace LibraryService.Api.Infrastructure.Data.Persistence.Configurations;
public sealed class MemberEntityConfiguration : IEntityTypeConfiguration<MemberEntity>
{
    public void Configure(EntityTypeBuilder<MemberEntity> builder)
    {
        builder.ToTable("Members");
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.Loans).WithOne().HasForeignKey("MemberId").OnDelete(DeleteBehavior.Restrict);
        builder.HasMany(x => x.Reservations).WithOne().HasForeignKey("MemberId").OnDelete(DeleteBehavior.Restrict);
    }
}