namespace LibraryService.Api.Domain.Entities;
/// <summary>
/// Represents the Reservation domain entity.
/// </summary>
public sealed class ReservationEntity
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
    /// Gets the MemberId value.
    /// </summary>
    public Guid MemberId { get; private set; }
    /// <summary>
    /// Gets the ReservedAt value.
    /// </summary>
    public DateTime ReservedAt { get; private set; }
    /// <summary>
    /// Gets related Book.
    /// </summary>
    public BookEntity Book { get; private set; }
    /// <summary>
    /// Gets related Member.
    /// </summary>
    public MemberEntity Member { get; private set; }

    /// <summary>
    /// Initializes a new instance of the ReservationEntity class for EF Core.
    /// </summary>
    private ReservationEntity()
    {
    }

    /// <summary>
    /// Initializes a new instance of the ReservationEntity class.
    /// </summary>
    private ReservationEntity(Guid bookId, Guid memberId, DateTime reservedAt)
    {
        Id = Guid.NewGuid();
        BookId = bookId;
        MemberId = memberId;
        ReservedAt = reservedAt;
    }

    /// <summary>
    /// Creates a new ReservationEntity.
    /// </summary>
    public static ReservationEntity Create(Guid bookId, Guid memberId, DateTime reservedAt)
    {
        return new ReservationEntity(bookId, memberId, reservedAt);
    }

    /// <summary>
    /// Updates the ReservationEntity state.
    /// </summary>
    public void Update(Guid bookId, Guid memberId, DateTime reservedAt)
    {
        Id = Guid.NewGuid();
        BookId = bookId;
        MemberId = memberId;
        ReservedAt = reservedAt;
    }
}