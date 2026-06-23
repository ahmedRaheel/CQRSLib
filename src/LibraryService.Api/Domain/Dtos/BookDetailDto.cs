namespace LibraryService.Api.Domain.Dtos;
/// <summary>
/// Represents the detailed Book DTO used only when children/parents are explicitly requested.
/// </summary>
public sealed record BookDetailDto(Guid Id, string Isbn, string Title, IReadOnlyList<PublisherDto> Publishers, IReadOnlyList<AuthorDto> Authors, IReadOnlyList<CategoryDto> Categories, IReadOnlyList<LoanDto> Loans, IReadOnlyList<ReservationDto> Reservations, IReadOnlyList<BookPublisherDto> BookPublishers, IReadOnlyList<BookAuthorDto> BookAuthors, IReadOnlyList<BookCategoryDto> BookCategories);