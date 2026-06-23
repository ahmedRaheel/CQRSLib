using LibraryService.Api.Domain.Interfaces.Queries;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;
using FastCqrs;

namespace LibraryService.Api.Features.BookAuthor.GetBookAuthorById;
public sealed class GetBookAuthorByIdQueryHandler : IRequestHandler<GetBookAuthorByIdQuery, Result<BookAuthorDto?>>
{
    private readonly IBookAuthorQueryRepository _query;
    public GetBookAuthorByIdQueryHandler(IBookAuthorQueryRepository query) => _query = query;
    public async ValueTask<Result<BookAuthorDto?>> Handle(GetBookAuthorByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _query.GetByIdAsync(request.Id, cancellationToken).ConfigureAwait(false);
        if (value is null)
            return Errors.NotFound<BookAuthorDto?>("BookAuthor with ID {request.Id} was not found.");
        return Result<BookAuthorDto?>.Success(value, "BookAuthor retrieved successfully.");
    }
}