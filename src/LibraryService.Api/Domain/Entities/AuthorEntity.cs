namespace LibraryService.Api.Domain.Entities;
/// <summary>
/// Represents the Author domain entity.
/// </summary>
public sealed class AuthorEntity
{
    /// <summary>
    /// Gets the Id value.
    /// </summary>
    public Guid Id { get; private set; }
    /// <summary>
    /// Gets the Name value.
    /// </summary>
    public string Name { get; private set; } = string.Empty;
    /// <summary>
    /// Gets related BookAuthors.
    /// </summary>
    public ICollection<BookAuthorEntity> BookAuthors { get; private set; } = new List<BookAuthorEntity>();

    /// <summary>
    /// Initializes a new instance of the AuthorEntity class for EF Core.
    /// </summary>
    private AuthorEntity()
    {
    }

    /// <summary>
    /// Initializes a new instance of the AuthorEntity class.
    /// </summary>
    private AuthorEntity(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }

    /// <summary>
    /// Creates a new AuthorEntity.
    /// </summary>
    public static AuthorEntity Create(string name)
    {
        return new AuthorEntity(name);
    }

    /// <summary>
    /// Updates the AuthorEntity state.
    /// </summary>
    public void Update(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }
}