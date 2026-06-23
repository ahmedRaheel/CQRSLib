using FastCqrs;
using LibraryService.Api.Domain.Interfaces.Queries;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.Loan.GetLoanById;
public sealed class GetLoanByIdQueryHandler : IRequestHandler<GetLoanByIdQuery, Result<LoanDto?>>
{
    private readonly ILoanQueryRepository _query;
    public GetLoanByIdQueryHandler(ILoanQueryRepository query) => _query = query;
    public async ValueTask<Result<LoanDto?>> Handle(GetLoanByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _query.GetByIdAsync(request.Id, cancellationToken).ConfigureAwait(false);
        if (value is null)
            return Errors.NotFound<LoanDto?>("Loan with ID {request.Id} was not found.");
        return Result<LoanDto?>.Success(value, "Loan retrieved successfully.");
    }
}