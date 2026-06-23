using FastCqrs;
using LibraryService.Api.Domain.Interfaces.Queries;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.Book.GetBookById;
public sealed class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, Domain.Shared.Result<BookDto?>>
{
    private readonly IBookQueryRepository _query;
    public GetBookByIdQueryHandler(IBookQueryRepository query) => _query = query;
    public async ValueTask<Domain.Shared.Result<BookDto?>> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _query.GetByIdAsync(request.Id, cancellationToken).ConfigureAwait(false);
        if (value is null)
            return Errors.NotFound<BookDto?>("Book with ID {request.Id} was not found.");
        return Domain.Shared.Result<BookDto?>.Success(value, "Book retrieved successfully.");
    }   
}