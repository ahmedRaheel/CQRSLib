using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;
using FastCqrs;

namespace LibraryService.Api.Features.Author.CreateAuthor;
/// <summary>
/// Represents the CreateAuthorCommand request.
/// </summary>
public sealed record CreateAuthorCommand(string Name) : IRequest<Domain.Shared.Result<AuthorDto>>;