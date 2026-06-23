using LibraryService.Api.Domain.Interfaces.Commands;
using LibraryService.Api.Domain.Interfaces.Queries;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Entities;
using LibraryService.Api.Domain.Shared;
using FastCqrs;

namespace LibraryService.Api.Features.BookAuthor.DeleteBookAuthor;
public sealed class DeleteBookAuthorCommandHandler : IRequestHandler<DeleteBookAuthorCommand, Result<Unit>>
{
    private readonly IBookAuthorCommandRepository _commands;
    private readonly IBookAuthorQueryRepository _query;
    public DeleteBookAuthorCommandHandler(IBookAuthorCommandRepository commands, IBookAuthorQueryRepository query)
    {
        _commands = commands;
        _query = query;
    }

    public async ValueTask<Result<Unit>> Handle(DeleteBookAuthorCommand request, CancellationToken cancellationToken)
    {
        var entity = await _query.GetEntityByIdAsync(request.Id, cancellationToken).ConfigureAwait(false);
        if (entity is null)
            return Errors.NotFound<Unit>("BookAuthor with ID {request.Id} was not found.");
        await _commands.DeleteAsync(request.Id, cancellationToken).ConfigureAwait(false);
        return Result<Unit>.Success(Unit.Value, "BookAuthor successfully deleted.");
    }
}