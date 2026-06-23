using Dapper;
using LibraryService.Api.Domain.Interfaces;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Entities;
using LibraryService.Api.Domain.Interfaces.Queries;

namespace LibraryService.Api.Infrastructure.Data.Queries;
public sealed class ReservationQueryRepository : IReservationQueryRepository
{
    private readonly IApplicationDbConnectionFactory _connectionFactory;
    public ReservationQueryRepository(IApplicationDbConnectionFactory connectionFactory) => _connectionFactory = connectionFactory;
    public async Task<ReservationEntity?> GetEntityByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        const string sql = "SELECT Id, BookId, MemberId, ReservedAt FROM Reservations WHERE Id = @Id";
        await using var connection = await _connectionFactory.CreateOpenConnectionAsync(cancellationToken);
        return await connection.QueryFirstOrDefaultAsync<ReservationEntity>(new CommandDefinition(sql, new { Id = id }, cancellationToken: cancellationToken)).ConfigureAwait(false);
    }

    public async Task<ReservationDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        const string sql = "SELECT Id, BookId, MemberId, ReservedAt FROM Reservations WHERE Id = @Id";
        await using var connection = await _connectionFactory.CreateOpenConnectionAsync(cancellationToken);
        return await connection.QueryFirstOrDefaultAsync<ReservationDto>(new CommandDefinition(sql, new { Id = id }, cancellationToken: cancellationToken)).ConfigureAwait(false);
    }

    public async Task<ReservationDetailDto?> GetDetailByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        const string sql = "SELECT Id, BookId, MemberId, ReservedAt FROM Reservations WHERE Id = @Id";
        await using var connection = await _connectionFactory.CreateOpenConnectionAsync(cancellationToken);
        var flat = await connection.QueryFirstOrDefaultAsync<ReservationDto>(new CommandDefinition(sql, new { Id = id }, cancellationToken: cancellationToken)).ConfigureAwait(false);
        return flat is null ? null : new ReservationDetailDto(flat.Id, flat.BookId, flat.MemberId, flat.ReservedAt, null, null);
    }

    public async Task<PagedResult<ReservationDto>> GetPagedAsync(int pageNumber, int pageSize, string? search, CancellationToken cancellationToken = default)
    {
        const string sql = "SELECT Id, BookId, MemberId, ReservedAt FROM Reservations ORDER BY Id OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";
        const string countSql = "SELECT COUNT(1) FROM Reservations";
        var parameters = new
        {
            Offset = (pageNumber - 1) * pageSize,
            PageSize = pageSize,
            Search = search
        };
        await using var connection = await _connectionFactory.CreateOpenConnectionAsync(cancellationToken);
        var items = (await connection.QueryAsync<ReservationDto>(new CommandDefinition(sql, parameters, cancellationToken: cancellationToken)).ConfigureAwait(false)).AsList();
        var total = await connection.ExecuteScalarAsync<int>(new CommandDefinition(countSql, parameters, cancellationToken: cancellationToken)).ConfigureAwait(false);
        return new PagedResult<ReservationDto>(items, pageNumber, pageSize, total);
    }
}