using FastCqrs;
using LibraryService.Api.Domain.Interfaces.Queries;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.BookPublisher.GetBookPublisherById;
public sealed class GetBookPublisherByIdQueryHandler : IRequestHandler<GetBookPublisherByIdQuery, Result<BookPublisherDto?>>
{
    private readonly IBookPublisherQueryRepository _query;
    public GetBookPublisherByIdQueryHandler(IBookPublisherQueryRepository query) => _query = query;
    public async ValueTask<Result<BookPublisherDto?>> Handle(GetBookPublisherByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _query.GetByIdAsync(request.Id, cancellationToken).ConfigureAwait(false);
        if (value is null)
            return Errors.NotFound<BookPublisherDto?>("BookPublisher with ID {request.Id} was not found.");
        return Result<BookPublisherDto?>.Success(value, "BookPublisher retrieved successfully.");
    }
}