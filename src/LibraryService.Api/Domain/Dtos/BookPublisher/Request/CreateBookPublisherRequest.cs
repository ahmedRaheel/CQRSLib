namespace LibraryService.Api.Domain.Dtos.BookPublisher.Request;
public sealed record CreateBookPublisherRequest(Guid BookId, Guid PublisherId);