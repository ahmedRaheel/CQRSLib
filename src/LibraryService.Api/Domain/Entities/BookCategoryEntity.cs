namespace LibraryService.Api.Domain.Entities;
/// <summary>
/// Represents the BookCategory domain entity.
/// </summary>
public sealed class BookCategoryEntity
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
    /// Gets the CategoryId value.
    /// </summary>
    public Guid CategoryId { get; private set; }
    /// <summary>
    /// Gets related Book.
    /// </summary>
    public BookEntity Book { get; private set; }
    /// <summary>
    /// Gets related Category.
    /// </summary>
    public CategoryEntity Category { get; private set; }

    /// <summary>
    /// Initializes a new instance of the BookCategoryEntity class for EF Core.
    /// </summary>
    private BookCategoryEntity()
    {
    }

    /// <summary>
    /// Initializes a new instance of the BookCategoryEntity class.
    /// </summary>
    private BookCategoryEntity(Guid bookId, Guid categoryId)
    {
        Id = Guid.NewGuid();
        BookId = bookId;
        CategoryId = categoryId;
    }

    /// <summary>
    /// Creates a new BookCategoryEntity.
    /// </summary>
    public static BookCategoryEntity Create(Guid bookId, Guid categoryId)
    {
        return new BookCategoryEntity(bookId, categoryId);
    }

    /// <summary>
    /// Updates the BookCategoryEntity state.
    /// </summary>
    public void Update(Guid bookId, Guid categoryId)
    {
        Id = Guid.NewGuid();
        BookId = bookId;
        CategoryId = categoryId;
    }
}