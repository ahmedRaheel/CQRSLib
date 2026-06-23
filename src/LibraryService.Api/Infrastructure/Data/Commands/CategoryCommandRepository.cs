using Microsoft.EntityFrameworkCore;
using LibraryService.Api.Domain.Entities;
using LibraryService.Api.Domain.Interfaces.Commands;
using LibraryService.Api.Domain.Interfaces;

namespace LibraryService.Api.Infrastructure.Data.Commands;
public sealed class CategoryCommandRepository : ICategoryCommandRepository
{
    private readonly IApplicationDbContext _context;
    public CategoryCommandRepository(IApplicationDbContext context) => _context = context;
    public async Task InsertAsync(CategoryEntity entity, CancellationToken cancellationToken = default)
    {
        await _context.Set<CategoryEntity>().AddAsync(entity, cancellationToken).ConfigureAwait(false);
        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }

    public async Task UpdateAsync(Guid id, CategoryEntity entity, CancellationToken cancellationToken = default)
    {
        _context.Set<CategoryEntity>().Update(entity);
        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await _context.Set<CategoryEntity>().FirstOrDefaultAsync(x => x.Id.Equals(id), cancellationToken).ConfigureAwait(false);
        if (entity is null)
            return;
        _context.Set<CategoryEntity>().Remove(entity);
        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }

    public async Task DeleteWithChildrenAsync(Guid id, CancellationToken cancellationToken = default)
    {
        await DeleteChildrenAsync(id, cancellationToken).ConfigureAwait(false);
        await DeleteAsync(id, cancellationToken).ConfigureAwait(false);
    }

    private Task DeleteChildrenAsync(Guid id, CancellationToken cancellationToken) => Task.CompletedTask;
}