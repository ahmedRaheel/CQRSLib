namespace LibraryService.Api.Domain.Entities;
/// <summary>
/// Represents the Member domain entity.
/// </summary>
public sealed class MemberEntity
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
    /// Gets the Email value.
    /// </summary>
    public string Email { get; private set; } = string.Empty;
    /// <summary>
    /// Gets related Loans.
    /// </summary>
    public ICollection<LoanEntity> Loans { get; private set; } = new List<LoanEntity>();
    /// <summary>
    /// Gets related Reservations.
    /// </summary>
    public ICollection<ReservationEntity> Reservations { get; private set; } = new List<ReservationEntity>();

    /// <summary>
    /// Initializes a new instance of the MemberEntity class for EF Core.
    /// </summary>
    private MemberEntity()
    {
    }

    /// <summary>
    /// Initializes a new instance of the MemberEntity class.
    /// </summary>
    private MemberEntity(string name, string email)
    {
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
    }

    /// <summary>
    /// Creates a new MemberEntity.
    /// </summary>
    public static MemberEntity Create(string name, string email)
    {
        return new MemberEntity(name, email);
    }

    /// <summary>
    /// Updates the MemberEntity state.
    /// </summary>
    public void Update(string name, string email)
    {
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
    }
}