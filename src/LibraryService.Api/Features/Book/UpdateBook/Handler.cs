using LibraryService.Api.Domain.Interfaces.Commands;
using LibraryService.Api.Domain.Interfaces.Queries;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Entities;
using LibraryService.Api.Domain.Shared;
using FastCqrs;

namespace LibraryService.Api.Features.Book.UpdateBook;
public sealed class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Result<Unit>>
{
    private readonly IBookCommandRepository _commands;
    private readonly IBookQueryRepository _query;
    public UpdateBookCommandHandler(IBookCommandRepository commands, IBookQueryRepository query)
    {
        _commands = commands;
        _query = query;
    }

    public async ValueTask<Result<Unit>> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var entity = await _query.GetEntityByIdAsync(request.Id, cancellationToken).ConfigureAwait(false);
        if (entity is null)
            return Errors.NotFound<Unit>("Book with ID {request.Id} was not found.");
        entity.Update(request.Isbn, request.Title);
        await _commands.UpdateAsync(request.Id, entity, cancellationToken).ConfigureAwait(false);
        return Result<Unit>.Success(Unit.Value, "Book successfully updated.");
    }
}