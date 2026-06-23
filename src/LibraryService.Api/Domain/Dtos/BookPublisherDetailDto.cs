namespace LibraryService.Api.Domain.Dtos;
/// <summary>
/// Represents the detailed BookPublisher DTO used only when children/parents are explicitly requested.
/// </summary>
public sealed record BookPublisherDetailDto(Guid Id, Guid BookId, Guid PublisherId, BookDto? Book, PublisherDto? Publisher);