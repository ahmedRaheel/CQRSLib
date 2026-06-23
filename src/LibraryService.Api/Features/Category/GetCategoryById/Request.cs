using FastCqrs;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.Category.GetCategoryById;
/// <summary>
/// Represents the GetCategoryByIdQuery request.
/// </summary>
public sealed record GetCategoryByIdQuery(Guid Id) : IRequest<Result<CategoryDto?>>;