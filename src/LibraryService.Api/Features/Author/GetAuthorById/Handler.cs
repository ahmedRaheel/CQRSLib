using LibraryService.Api.Domain.Interfaces.Queries;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;
using FastCqrs;

namespace LibraryService.Api.Features.Author.GetAuthorById;
public sealed class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, Domain.Shared.Result<AuthorDto?>>
{
    private readonly IAuthorQueryRepository _query;
    public GetAuthorByIdQueryHandler(IAuthorQueryRepository query) => _query = query;
    public async ValueTask<Domain.Shared.Result<AuthorDto?>> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _query.GetByIdAsync(request.Id, cancellationToken).ConfigureAwait(false);
        if (value is null)
            return Errors.NotFound<AuthorDto?>("Author with ID {request.Id} was not found.");
        return Domain.Shared.Result<AuthorDto?>.Success(value, "Author retrieved successfully.");
    }
}