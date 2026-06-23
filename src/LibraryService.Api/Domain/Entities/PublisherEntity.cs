namespace LibraryService.Api.Domain.Entities;
/// <summary>
/// Represents the Publisher domain entity.
/// </summary>
public sealed class PublisherEntity
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
    /// Gets related BookPublishers.
    /// </summary>
    public ICollection<BookPublisherEntity> BookPublishers { get; private set; } = new List<BookPublisherEntity>();

    /// <summary>
    /// Initializes a new instance of the PublisherEntity class for EF Core.
    /// </summary>
    private PublisherEntity()
    {
    }

    /// <summary>
    /// Initializes a new instance of the PublisherEntity class.
    /// </summary>
    private PublisherEntity(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }

    /// <summary>
    /// Creates a new PublisherEntity.
    /// </summary>
    public static PublisherEntity Create(string name)
    {
        return new PublisherEntity(name);
    }

    /// <summary>
    /// Updates the PublisherEntity state.
    /// </summary>
    public void Update(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }
}