using FastCqrs;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.Loan.GetLoanById;
/// <summary>
/// Represents the GetLoanByIdQuery request.
/// </summary>
public sealed record GetLoanByIdQuery(Guid Id) : IRequest<Result<LoanDto?>>;