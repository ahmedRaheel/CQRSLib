using FastCqrs;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.Category.UpdateCategory;
/// <summary>
/// Represents the UpdateCategoryCommand request.
/// </summary>
public sealed record UpdateCategoryCommand(Guid Id, string Name) : IRequest<Result<Unit>>;