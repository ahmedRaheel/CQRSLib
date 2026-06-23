using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LibraryService.Api.Domain.Entities;

namespace LibraryService.Api.Infrastructure.Data.Persistence.Configurations;
public sealed class FineEntityConfiguration : IEntityTypeConfiguration<FineEntity>
{
    public void Configure(EntityTypeBuilder<FineEntity> builder)
    {
        builder.ToTable("Fines");
        builder.HasKey(x => x.Id);
        //builder.HasOne(x => x.Loan).WithOne().HasForeignKey<FineEntity>(x => x.LoanId).OnDelete(DeleteBehavior.Cascade);
    }
}