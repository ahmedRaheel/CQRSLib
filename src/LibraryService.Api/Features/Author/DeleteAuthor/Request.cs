using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;
using FastCqrs;

namespace LibraryService.Api.Features.Author.DeleteAuthor;
/// <summary>
/// Represents the DeleteAuthorCommand request.
/// </summary>
public sealed record DeleteAuthorCommand(Guid Id) : IRequest<Domain.Shared.Result<Unit>>;