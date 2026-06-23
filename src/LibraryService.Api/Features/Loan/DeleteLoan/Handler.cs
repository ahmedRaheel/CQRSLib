using FastCqrs;
using LibraryService.Api.Domain.Interfaces.Commands;
using LibraryService.Api.Domain.Interfaces.Queries;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Entities;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.Loan.DeleteLoan;
public sealed class DeleteLoanCommandHandler : IRequestHandler<DeleteLoanCommand, Result<Unit>>
{
    private readonly ILoanCommandRepository _commands;
    private readonly ILoanQueryRepository _query;
    public DeleteLoanCommandHandler(ILoanCommandRepository commands, ILoanQueryRepository query)
    {
        _commands = commands;
        _query = query;
    }

    public async ValueTask<Result<Unit>> Handle(DeleteLoanCommand request, CancellationToken cancellationToken)
    {
        var entity = await _query.GetEntityByIdAsync(request.Id, cancellationToken).ConfigureAwait(false);
        if (entity is null)
            return Errors.NotFound<Unit>("Loan with ID {request.Id} was not found.");
        await _commands.DeleteAsync(request.Id, cancellationToken).ConfigureAwait(false);
        return Result<Unit>.Success(Unit.Value, "Loan successfully deleted.");
    }
}