using FastCqrs;
using LibraryService.Api.Domain.Interfaces.Queries;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.Fine.GetFineById;
public sealed class GetFineByIdQueryHandler : IRequestHandler<GetFineByIdQuery, Result<FineDto?>>
{
    private readonly IFineQueryRepository _query;
    public GetFineByIdQueryHandler(IFineQueryRepository query) => _query = query;
    public async ValueTask<Result<FineDto?>> Handle(GetFineByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _query.GetByIdAsync(request.Id, cancellationToken).ConfigureAwait(false);
        if (value is null)
            return Errors.NotFound<FineDto?>("Fine with ID {request.Id} was not found.");
        return Result<FineDto?>.Success(value, "Fine retrieved successfully.");
    }
}