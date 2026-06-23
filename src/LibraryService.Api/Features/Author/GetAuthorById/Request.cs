using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;
using FastCqrs;

namespace LibraryService.Api.Features.Author.GetAuthorById;
/// <summary>
/// Represents the GetAuthorByIdQuery request.
/// </summary>
public sealed record GetAuthorByIdQuery(Guid Id) : IRequest<Domain.Shared.Result<AuthorDto?>>;