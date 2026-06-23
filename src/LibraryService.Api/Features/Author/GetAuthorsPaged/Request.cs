using FastCqrs;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.Author.GetAuthorsPaged;
/// <summary>
/// Represents the GetAuthorsPagedQuery request.
/// </summary>
public sealed record GetAuthorsPagedQuery(int PageNumber, int PageSize, string? Search) : IRequest<Domain.Shared.Result<PagedResult<AuthorDto>>>;