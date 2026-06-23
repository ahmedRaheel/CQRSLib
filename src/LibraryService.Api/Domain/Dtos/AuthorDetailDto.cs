namespace LibraryService.Api.Domain.Dtos;
/// <summary>
/// Represents the detailed Author DTO used only when children/parents are explicitly requested.
/// </summary>
public sealed record AuthorDetailDto(Guid Id, string Name, IReadOnlyList<BookAuthorDto> BookAuthors);