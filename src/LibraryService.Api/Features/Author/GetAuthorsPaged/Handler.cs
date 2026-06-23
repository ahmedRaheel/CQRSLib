using LibraryService.Api.Domain.Interfaces.Queries;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;
using FastCqrs;

namespace LibraryService.Api.Features.Author.GetAuthorsPaged;
public sealed class GetAuthorsPagedQueryHandler : IRequestHandler<GetAuthorsPagedQuery, Domain.Shared.Result<PagedResult<AuthorDto>>>
{
    private readonly IAuthorQueryRepository _query;
    public GetAuthorsPagedQueryHandler(IAuthorQueryRepository query) => _query = query;
    public async ValueTask<Domain.Shared.Result<PagedResult<AuthorDto>>> Handle(GetAuthorsPagedQuery request, CancellationToken cancellationToken)
    {
        var value = await _query.GetPagedAsync(request.PageNumber, request.PageSize, request.Search, cancellationToken).ConfigureAwait(false);
        return Domain.Shared.Result<PagedResult<AuthorDto>>.Success(value, "Author retrieved successfully.");
    }
}