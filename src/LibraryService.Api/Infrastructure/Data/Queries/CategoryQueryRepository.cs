using Dapper;
using LibraryService.Api.Domain.Interfaces;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Entities;
using LibraryService.Api.Domain.Interfaces.Queries;

namespace LibraryService.Api.Infrastructure.Data.Queries;
public sealed class CategoryQueryRepository : ICategoryQueryRepository
{
    private readonly IApplicationDbConnectionFactory _connectionFactory;
    public CategoryQueryRepository(IApplicationDbConnectionFactory connectionFactory) => _connectionFactory = connectionFactory;
    public async Task<CategoryEntity?> GetEntityByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        const string sql = "SELECT Id, Name FROM Categories WHERE Id = @Id";
        await using var connection = await _connectionFactory.CreateOpenConnectionAsync(cancellationToken);
        return await connection.QueryFirstOrDefaultAsync<CategoryEntity>(new CommandDefinition(sql, new { Id = id }, cancellationToken: cancellationToken)).ConfigureAwait(false);
    }

    public async Task<CategoryDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        const string sql = "SELECT Id, Name FROM Categories WHERE Id = @Id";
        await using var connection = await _connectionFactory.CreateOpenConnectionAsync(cancellationToken);
        return await connection.QueryFirstOrDefaultAsync<CategoryDto>(new CommandDefinition(sql, new { Id = id }, cancellationToken: cancellationToken)).ConfigureAwait(false);
    }

    public async Task<CategoryDetailDto?> GetDetailByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        const string sql = "SELECT Id, Name FROM Categories WHERE Id = @Id";
        await using var connection = await _connectionFactory.CreateOpenConnectionAsync(cancellationToken);
        var flat = await connection.QueryFirstOrDefaultAsync<CategoryDto>(new CommandDefinition(sql, new { Id = id }, cancellationToken: cancellationToken)).ConfigureAwait(false);
        return flat is null ? null : new CategoryDetailDto(flat.Id, flat.Name, Array.Empty<BookCategoryDto>());
    }

    public async Task<PagedResult<CategoryDto>> GetPagedAsync(int pageNumber, int pageSize, string? search, CancellationToken cancellationToken = default)
    {
        const string sql = "SELECT Id, Name FROM Categories ORDER BY Id OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";
        const string countSql = "SELECT COUNT(1) FROM Categories";
        var parameters = new
        {
            Offset = (pageNumber - 1) * pageSize,
            PageSize = pageSize,
            Search = search
        };
        await using var connection = await _connectionFactory.CreateOpenConnectionAsync(cancellationToken);
        var items = (await connection.QueryAsync<CategoryDto>(new CommandDefinition(sql, parameters, cancellationToken: cancellationToken)).ConfigureAwait(false)).AsList();
        var total = await connection.ExecuteScalarAsync<int>(new CommandDefinition(countSql, parameters, cancellationToken: cancellationToken)).ConfigureAwait(false);
        return new PagedResult<CategoryDto>(items, pageNumber, pageSize, total);
    }
}