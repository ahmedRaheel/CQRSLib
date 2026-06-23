using Microsoft.EntityFrameworkCore;
using LibraryService.Api.Domain.Entities;
using LibraryService.Api.Domain.Interfaces.Commands;
using LibraryService.Api.Domain.Interfaces;

namespace LibraryService.Api.Infrastructure.Data.Commands;
public sealed class ReservationCommandRepository : IReservationCommandRepository
{
    private readonly IApplicationDbContext _context;
    public ReservationCommandRepository(IApplicationDbContext context) => _context = context;
    public async Task InsertAsync(ReservationEntity entity, CancellationToken cancellationToken = default)
    {
        await _context.Set<ReservationEntity>().AddAsync(entity, cancellationToken).ConfigureAwait(false);
        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }

    public async Task UpdateAsync(Guid id, ReservationEntity entity, CancellationToken cancellationToken = default)
    {
        _context.Set<ReservationEntity>().Update(entity);
        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await _context.Set<ReservationEntity>().FirstOrDefaultAsync(x => x.Id.Equals(id), cancellationToken).ConfigureAwait(false);
        if (entity is null)
            return;
        _context.Set<ReservationEntity>().Remove(entity);
        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }
}