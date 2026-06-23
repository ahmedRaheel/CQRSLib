namespace LibraryService.Api.Domain.Entities;
/// <summary>
/// Represents the BookAuthor domain entity.
/// </summary>
public sealed class BookAuthorEntity
{
    /// <summary>
    /// Gets the Id value.
    /// </summary>
    public Guid Id { get; private set; }
    /// <summary>
    /// Gets the BookId value.
    /// </summary>
    public Guid BookId { get; private set; }
    /// <summary>
    /// Gets the AuthorId value.
    /// </summary>
    public Guid AuthorId { get; private set; }
    /// <summary>
    /// Gets related Book.
    /// </summary>
    public BookEntity Book { get; private set; }
    /// <summary>
    /// Gets related Author.
    /// </summary>
    public AuthorEntity Author { get; private set; }

    /// <summary>
    /// Initializes a new instance of the BookAuthorEntity class for EF Core.
    /// </summary>
    private BookAuthorEntity()
    {
    }

    /// <summary>
    /// Initializes a new instance of the BookAuthorEntity class.
    /// </summary>
    private BookAuthorEntity(Guid bookId, Guid authorId)
    {
        Id = Guid.NewGuid();
        BookId = bookId;
        AuthorId = authorId;
    }

    /// <summary>
    /// Creates a new BookAuthorEntity.
    /// </summary>
    public static BookAuthorEntity Create(Guid bookId, Guid authorId)
    {
        return new BookAuthorEntity(bookId, authorId);
    }

    /// <summary>
    /// Updates the BookAuthorEntity state.
    /// </summary>
    public void Update(Guid bookId, Guid authorId)
    {
        Id = Guid.NewGuid();
        BookId = bookId;
        AuthorId = authorId;
    }
}