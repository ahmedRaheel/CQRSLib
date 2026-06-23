using Microsoft.EntityFrameworkCore;
using LibraryService.Api.Domain.Entities;
using LibraryService.Api.Domain.Interfaces.Commands;
using LibraryService.Api.Domain.Interfaces;

namespace LibraryService.Api.Infrastructure.Data.Commands;
public sealed class BookPublisherCommandRepository : IBookPublisherCommandRepository
{
    private readonly IApplicationDbContext _context;
    public BookPublisherCommandRepository(IApplicationDbContext context) => _context = context;
    public async Task InsertAsync(BookPublisherEntity entity, CancellationToken cancellationToken = default)
    {
        await _context.Set<BookPublisherEntity>().AddAsync(entity, cancellationToken).ConfigureAwait(false);
        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }

    public async Task UpdateAsync(Guid id, BookPublisherEntity entity, CancellationToken cancellationToken = default)
    {
        _context.Set<BookPublisherEntity>().Update(entity);
        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await _context.Set<BookPublisherEntity>().FirstOrDefaultAsync(x => x.Id.Equals(id), cancellationToken).ConfigureAwait(false);
        if (entity is null)
            return;
        _context.Set<BookPublisherEntity>().Remove(entity);
        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }
}