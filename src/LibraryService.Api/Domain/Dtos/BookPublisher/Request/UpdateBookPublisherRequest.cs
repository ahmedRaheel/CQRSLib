namespace LibraryService.Api.Domain.Dtos.BookPublisher.Request;
public sealed record UpdateBookPublisherRequest(Guid BookId, Guid PublisherId);