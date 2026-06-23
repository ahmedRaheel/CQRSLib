namespace LibraryService.Api.Domain.Entities;
/// <summary>
/// Represents the Category domain entity.
/// </summary>
public sealed class CategoryEntity
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
    /// Gets related BookCategories.
    /// </summary>
    public ICollection<BookCategoryEntity> BookCategories { get; private set; } = new List<BookCategoryEntity>();

    /// <summary>
    /// Initializes a new instance of the CategoryEntity class for EF Core.
    /// </summary>
    private CategoryEntity()
    {
    }

    /// <summary>
    /// Initializes a new instance of the CategoryEntity class.
    /// </summary>
    private CategoryEntity(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }

    /// <summary>
    /// Creates a new CategoryEntity.
    /// </summary>
    public static CategoryEntity Create(string name)
    {
        return new CategoryEntity(name);
    }

    /// <summary>
    /// Updates the CategoryEntity state.
    /// </summary>
    public void Update(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }
}