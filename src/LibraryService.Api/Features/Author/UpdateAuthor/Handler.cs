using LibraryService.Api.Domain.Interfaces.Commands;
using LibraryService.Api.Domain.Interfaces.Queries;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Entities;
using LibraryService.Api.Domain.Shared;
using FastCqrs;

namespace LibraryService.Api.Features.Author.UpdateAuthor;
public sealed class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, Result<Unit>>
{
    private readonly IAuthorCommandRepository _commands;
    private readonly IAuthorQueryRepository _query;
    public UpdateAuthorCommandHandler(IAuthorCommandRepository commands, IAuthorQueryRepository query)
    {
        _commands = commands;
        _query = query;
    }

    public async ValueTask<Result<Unit>> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
    {
        var entity = await _query.GetEntityByIdAsync(request.Id, cancellationToken).ConfigureAwait(false);
        if (entity is null)
            return Errors.NotFound<Unit>("Author with ID {request.Id} was not found.");
        entity.Update(request.Name);
        await _commands.UpdateAsync(request.Id, entity, cancellationToken).ConfigureAwait(false);
        return Result<Unit>.Success(Unit.Value, "Author successfully updated.");
    }
}