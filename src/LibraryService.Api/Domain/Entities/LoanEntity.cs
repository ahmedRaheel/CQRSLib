namespace LibraryService.Api.Domain.Entities;
/// <summary>
/// Represents the Loan domain entity.
/// </summary>
public sealed class LoanEntity
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
    /// Gets the LoanDate value.
    /// </summary>
    public DateTime LoanDate { get; private set; }
    /// <summary>
    /// Gets the DueDate value.
    /// </summary>
    public DateTime DueDate { get; private set; }
    /// <summary>
    /// Gets related Fine.
    /// </summary>
    public FineEntity? Fine { get; private set; }
    /// <summary>
    /// Gets related Book.
    /// </summary>
    public BookEntity Book { get; private set; }
    /// <summary>
    /// Gets related Member.
    /// </summary>
    public MemberEntity Member { get; private set; }

    /// <summary>
    /// Initializes a new instance of the LoanEntity class for EF Core.
    /// </summary>
    private LoanEntity()
    {
    }

    /// <summary>
    /// Initializes a new instance of the LoanEntity class.
    /// </summary>
    private LoanEntity(Guid bookId, Guid memberId, DateTime loanDate, DateTime dueDate)
    {
        Id = Guid.NewGuid();
        BookId = bookId;
        MemberId = memberId;
        LoanDate = loanDate;
        DueDate = dueDate;
    }

    /// <summary>
    /// Creates a new LoanEntity.
    /// </summary>
    public static LoanEntity Create(Guid bookId, Guid memberId, DateTime loanDate, DateTime dueDate)
    {
        return new LoanEntity(bookId, memberId, loanDate, dueDate);
    }

    /// <summary>
    /// Updates the LoanEntity state.
    /// </summary>
    public void Update(Guid bookId, Guid memberId, DateTime loanDate, DateTime dueDate)
    {
        Id = Guid.NewGuid();
        BookId = bookId;
        MemberId = memberId;
        LoanDate = loanDate;
        DueDate = dueDate;
    }
}