using FastCqrs;
using LibraryService.Api.Domain.Interfaces.Commands;
using LibraryService.Api.Domain.Interfaces.Queries;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Entities;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.Loan.CreateLoan;
public sealed class CreateLoanCommandHandler : IRequestHandler<CreateLoanCommand, Result<LoanDto>>
{
    private readonly ILoanCommandRepository _commands;
    private readonly ILoanQueryRepository _query;
    public CreateLoanCommandHandler(ILoanCommandRepository commands, ILoanQueryRepository query)
    {
        _commands = commands;
        _query = query;
    }

    public async ValueTask<Result<LoanDto>> Handle(CreateLoanCommand request, CancellationToken cancellationToken)
    {
        var entity = LoanEntity.Create(request.BookId, request.MemberId, request.LoanDate, request.DueDate);
        await _commands.InsertAsync(entity, cancellationToken).ConfigureAwait(false);
        var response = new LoanDto(entity.Id, entity.BookId, entity.MemberId, entity.LoanDate, entity.DueDate);
        return Result<LoanDto>.Success(response, "Loan successfully created.");
    }
}