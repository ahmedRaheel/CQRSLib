using Dapper;
using LibraryService.Api.Domain.Interfaces;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Entities;
using LibraryService.Api.Domain.Interfaces.Queries;

namespace LibraryService.Api.Infrastructure.Data.Queries;
public sealed class AuthorQueryRepository : IAuthorQueryRepository
{
    private readonly IApplicationDbConnectionFactory _connectionFactory;
    public AuthorQueryRepository(IApplicationDbConnectionFactory connectionFactory) => _connectionFactory = connectionFactory;
    public async Task<AuthorEntity?> GetEntityByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        const string sql = "SELECT Id, Name FROM Authors WHERE Id = @Id";
        await using var connection = await _connectionFactory.CreateOpenConnectionAsync(cancellationToken);
        return await connection.QueryFirstOrDefaultAsync<AuthorEntity>(new CommandDefinition(sql, new { Id = id }, cancellationToken: cancellationToken)).ConfigureAwait(false);
    }

    public async Task<AuthorDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        const string sql = "SELECT Id, Name FROM Authors WHERE Id = @Id";
        await using var connection = await _connectionFactory.CreateOpenConnectionAsync(cancellationToken);
        return await connection.QueryFirstOrDefaultAsync<AuthorDto>(new CommandDefinition(sql, new { Id = id }, cancellationToken: cancellationToken)).ConfigureAwait(false);
    }

    public async Task<AuthorDetailDto?> GetDetailByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        const string sql = "SELECT Id, Name FROM Authors WHERE Id = @Id";
        await using var connection = await _connectionFactory.CreateOpenConnectionAsync(cancellationToken);
        var flat = await connection.QueryFirstOrDefaultAsync<AuthorDto>(new CommandDefinition(sql, new { Id = id }, cancellationToken: cancellationToken)).ConfigureAwait(false);
        return flat is null ? null : new AuthorDetailDto(flat.Id, flat.Name, Array.Empty<BookAuthorDto>());
    }

    public async Task<PagedResult<AuthorDto>> GetPagedAsync(int pageNumber, int pageSize, string? search, CancellationToken cancellationToken = default)
    {
        const string sql = "SELECT Id, Name FROM Authors ORDER BY Id OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";
        const string countSql = "SELECT COUNT(1) FROM Authors";
        var parameters = new
        {
            Offset = (pageNumber - 1) * pageSize,
            PageSize = pageSize,
            Search = search
        };
        await using var connection = await _connectionFactory.CreateOpenConnectionAsync(cancellationToken);
        var items = (await connection.QueryAsync<AuthorDto>(new CommandDefinition(sql, parameters, cancellationToken: cancellationToken)).ConfigureAwait(false)).AsList();
        var total = await connection.ExecuteScalarAsync<int>(new CommandDefinition(countSql, parameters, cancellationToken: cancellationToken)).ConfigureAwait(false);
        return new PagedResult<AuthorDto>(items, pageNumber, pageSize, total);
    }
}