namespace LibraryService.Api.Domain.Entities;
/// <summary>
/// Represents the BookPublisher domain entity.
/// </summary>
public sealed class BookPublisherEntity
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
    /// Gets the PublisherId value.
    /// </summary>
    public Guid PublisherId { get; private set; }
    /// <summary>
    /// Gets related Book.
    /// </summary>
    public BookEntity Book { get; private set; }
    /// <summary>
    /// Gets related Publisher.
    /// </summary>
    public PublisherEntity Publisher { get; private set; }

    /// <summary>
    /// Initializes a new instance of the BookPublisherEntity class for EF Core.
    /// </summary>
    private BookPublisherEntity()
    {
    }

    /// <summary>
    /// Initializes a new instance of the BookPublisherEntity class.
    /// </summary>
    private BookPublisherEntity(Guid bookId, Guid publisherId)
    {
        Id = Guid.NewGuid();
        BookId = bookId;
        PublisherId = publisherId;
    }

    /// <summary>
    /// Creates a new BookPublisherEntity.
    /// </summary>
    public static BookPublisherEntity Create(Guid bookId, Guid publisherId)
    {
        return new BookPublisherEntity(bookId, publisherId);
    }

    /// <summary>
    /// Updates the BookPublisherEntity state.
    /// </summary>
    public void Update(Guid bookId, Guid publisherId)
    {
        Id = Guid.NewGuid();
        BookId = bookId;
        PublisherId = publisherId;
    }
}