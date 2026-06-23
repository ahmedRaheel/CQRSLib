using Microsoft.EntityFrameworkCore;
using LibraryService.Api.Domain.Entities;

namespace LibraryService.Api.Domain.Interfaces;

public interface IApplicationDbContext
{
    DbSet<BookEntity> Books { get; }
    DbSet<AuthorEntity> Authors { get; }
    DbSet<CategoryEntity> Categories { get; }
    DbSet<PublisherEntity> Publishers { get; }
    DbSet<MemberEntity> Members { get; }
    DbSet<LoanEntity> Loans { get; }
    DbSet<ReservationEntity> Reservations { get; }
    DbSet<FineEntity> Fines { get; }
    DbSet<BookPublisherEntity> BookPublishers { get; }
    DbSet<BookAuthorEntity> BookAuthors { get; }
    DbSet<BookCategoryEntity> BookCategories { get; }

    DbSet<TEntity> Set<TEntity>() where TEntity : class;
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}