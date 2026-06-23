namespace LibraryService.Api.Domain.Dtos;
/// <summary>
/// Represents the detailed BookCategory DTO used only when children/parents are explicitly requested.
/// </summary>
public sealed record BookCategoryDetailDto(Guid Id, Guid BookId, Guid CategoryId, BookDto? Book, CategoryDto? Category);