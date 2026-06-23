namespace LibraryService.Api.Domain.Dtos;
/// <summary>
/// Represents the detailed Publisher DTO used only when children/parents are explicitly requested.
/// </summary>
public sealed record PublisherDetailDto(Guid Id, string Name, IReadOnlyList<BookPublisherDto> BookPublishers);