using FastCqrs;
using LibraryService.Api.Domain.Interfaces.Commands;
using LibraryService.Api.Domain.Interfaces.Queries;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Entities;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.Book.DeleteBook;
public sealed class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, Result<Unit>>
{
    private readonly IBookCommandRepository _commands;
    private readonly IBookQueryRepository _query;
    public DeleteBookCommandHandler(IBookCommandRepository commands, IBookQueryRepository query)
    {
        _commands = commands;
        _query = query;
    }

    public async ValueTask<Result<Unit>> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var entity = await _query.GetEntityByIdAsync(request.Id, cancellationToken).ConfigureAwait(false);
        if (entity is null)
            return Errors.NotFound<Unit>("Book with ID {request.Id} was not found.");
        await _commands.DeleteWithChildrenAsync(request.Id, cancellationToken).ConfigureAwait(false);
        return Result<Unit>.Success(Unit.Value, "Book successfully deleted.");
    }
}