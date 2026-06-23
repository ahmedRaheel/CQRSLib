using FastCqrs;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.Category.DeleteCategory;
/// <summary>
/// Represents the DeleteCategoryCommand request.
/// </summary>
public sealed record DeleteCategoryCommand(Guid Id) : IRequest<Result<Unit>>;