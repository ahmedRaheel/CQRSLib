using FastCqrs;
using LibraryService.Api.Domain.Interfaces.Queries;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.Publisher.GetPublisherById;
public sealed class GetPublisherByIdQueryHandler : IRequestHandler<GetPublisherByIdQuery, Result<PublisherDto?>>
{
    private readonly IPublisherQueryRepository _query;
    public GetPublisherByIdQueryHandler(IPublisherQueryRepository query) => _query = query;
    public async ValueTask<Result<PublisherDto?>> Handle(GetPublisherByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _query.GetByIdAsync(request.Id, cancellationToken).ConfigureAwait(false);
        if (value is null)
            return Errors.NotFound<PublisherDto?>("Publisher with ID {request.Id} was not found.");
        return Result<PublisherDto?>.Success(value, "Publisher retrieved successfully.");
    }
}