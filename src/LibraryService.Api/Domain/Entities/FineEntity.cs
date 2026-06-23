namespace LibraryService.Api.Domain.Entities;
/// <summary>
/// Represents the Fine domain entity.
/// </summary>
public sealed class FineEntity
{
    /// <summary>
    /// Gets the Id value.
    /// </summary>
    public Guid Id { get; private set; }
    /// <summary>
    /// Gets the LoanId value.
    /// </summary>
    public Guid LoanId { get; private set; }
    /// <summary>
    /// Gets the Amount value.
    /// </summary>
    public decimal Amount { get; private set; }
    /// <summary>
    /// Gets related Loan.
    /// </summary>
    public LoanEntity Loan { get; private set; }

    /// <summary>
    /// Initializes a new instance of the FineEntity class for EF Core.
    /// </summary>
    private FineEntity()
    {
    }

    /// <summary>
    /// Initializes a new instance of the FineEntity class.
    /// </summary>
    private FineEntity(Guid loanId, decimal amount)
    {
        Id = Guid.NewGuid();
        LoanId = loanId;
        Amount = amount;
    }

    /// <summary>
    /// Creates a new FineEntity.
    /// </summary>
    public static FineEntity Create(Guid loanId, decimal amount)
    {
        return new FineEntity(loanId, amount);
    }

    /// <summary>
    /// Updates the FineEntity state.
    /// </summary>
    public void Update(Guid loanId, decimal amount)
    {
        Id = Guid.NewGuid();
        LoanId = loanId;
        Amount = amount;
    }
}