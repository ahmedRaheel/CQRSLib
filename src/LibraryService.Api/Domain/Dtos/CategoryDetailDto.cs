namespace LibraryService.Api.Domain.Dtos;
/// <summary>
/// Represents the detailed Category DTO used only when children/parents are explicitly requested.
/// </summary>
public sealed record CategoryDetailDto(Guid Id, string Name, IReadOnlyList<BookCategoryDto> BookCategories);