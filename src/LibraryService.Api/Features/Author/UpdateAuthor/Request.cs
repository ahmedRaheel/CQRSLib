using FastCqrs;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.Author.UpdateAuthor;
/// <summary>
/// Represents the UpdateAuthorCommand request.
/// </summary>
public sealed record UpdateAuthorCommand(Guid Id, string Name) : IRequest<Domain.Shared.Result<Unit>>;