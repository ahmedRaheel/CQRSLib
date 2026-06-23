using Microsoft.EntityFrameworkCore;
using LibraryService.Api.Domain.Interfaces;
using LibraryService.Api.Domain.Entities;

namespace LibraryService.Api.Infrastructure.Data.Persistence.Context;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options), IApplicationDbContext
{
    public DbSet<BookEntity> Books => Set<BookEntity>();
    public DbSet<AuthorEntity> Authors => Set<AuthorEntity>();
    public DbSet<CategoryEntity> Categories => Set<CategoryEntity>();
    public DbSet<PublisherEntity> Publishers => Set<PublisherEntity>();
    public DbSet<MemberEntity> Members => Set<MemberEntity>();
    public DbSet<LoanEntity> Loans => Set<LoanEntity>();
    public DbSet<ReservationEntity> Reservations => Set<ReservationEntity>();
    public DbSet<FineEntity> Fines => Set<FineEntity>();
    public DbSet<BookPublisherEntity> BookPublishers => Set<BookPublisherEntity>();
    public DbSet<BookAuthorEntity> BookAuthors => Set<BookAuthorEntity>();
    public DbSet<BookCategoryEntity> BookCategories => Set<BookCategoryEntity>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}