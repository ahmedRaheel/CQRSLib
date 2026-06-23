using FastCqrs;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.Category.CreateCategory;
/// <summary>
/// Represents the CreateCategoryCommand request.
/// </summary>
public sealed record CreateCategoryCommand(string Name) : IRequest<Result<CategoryDto>>;