namespace LibraryService.Api.Domain.Dtos;
/// <summary>
/// Represents the flat BookPublisher data transfer object. It intentionally excludes parent/child navigation data.
/// </summary>
public sealed record BookPublisherDto(Guid Id, Guid BookId, Guid PublisherId);