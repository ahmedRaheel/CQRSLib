namespace LibraryService.Api.Domain.Entities;
/// <summary>
/// Represents the Book domain entity.
/// </summary>
public sealed class BookEntity
{
    /// <summary>
    /// Gets the Id value.
    /// </summary>
    public Guid Id { get; private set; }
    /// <summary>
    /// Gets the Isbn value.
    /// </summary>
    public string Isbn { get; private set; } = string.Empty;
    /// <summary>
    /// Gets the Title value.
    /// </summary>
    public string Title { get; private set; } = string.Empty;
    /// <summary>
    /// Gets related Publishers.
    /// </summary>
    public ICollection<PublisherEntity> Publishers { get; private set; } = new List<PublisherEntity>();
    /// <summary>
    /// Gets related Authors.
    /// </summary>
    public ICollection<AuthorEntity> Authors { get; private set; } = new List<AuthorEntity>();
    /// <summary>
    /// Gets related Categories.
    /// </summary>
    public ICollection<CategoryEntity> Categories { get; private set; } = new List<CategoryEntity>();
    /// <summary>
    /// Gets related Loans.
    /// </summary>
    public ICollection<LoanEntity> Loans { get; private set; } = new List<LoanEntity>();
    /// <summary>
    /// Gets related Reservations.
    /// </summary>
    public ICollection<ReservationEntity> Reservations { get; private set; } = new List<ReservationEntity>();
    /// <summary>
    /// Gets related BookPublishers.
    /// </summary>
    public ICollection<BookPublisherEntity> BookPublishers { get; private set; } = new List<BookPublisherEntity>();
    /// <summary>
    /// Gets related BookAuthors.
    /// </summary>
    public ICollection<BookAuthorEntity> BookAuthors { get; private set; } = new List<BookAuthorEntity>();
    /// <summary>
    /// Gets related BookCategories.
    /// </summary>
    public ICollection<BookCategoryEntity> BookCategories { get; private set; } = new List<BookCategoryEntity>();

    /// <summary>
    /// Initializes a new instance of the BookEntity class for EF Core.
    /// </summary>
    private BookEntity()
    {
    }

    /// <summary>
    /// Initializes a new instance of the BookEntity class.
    /// </summary>
    private BookEntity(string isbn, string title)
    {
        Id = Guid.NewGuid();
        Isbn = isbn;
        Title = title;
    }

    /// <summary>
    /// Creates a new BookEntity.
    /// </summary>
    public static BookEntity Create(string isbn, string title)
    {
        return new BookEntity(isbn, title);
    }

    /// <summary>
    /// Updates the BookEntity state.
    /// </summary>
    public void Update(string isbn, string title)
    {
        Id = Guid.NewGuid();
        Isbn = isbn;
        Title = title;
    }
}