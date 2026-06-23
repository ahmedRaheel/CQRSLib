using FastCqrs;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.Loan.DeleteLoan;
/// <summary>
/// Represents the DeleteLoanCommand request.
/// </summary>
public sealed record DeleteLoanCommand(Guid Id) : IRequest<Result<Unit>>;