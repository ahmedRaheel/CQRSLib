using FastCqrs;
using LibraryService.Api.Domain.Interfaces.Commands;
using LibraryService.Api.Domain.Interfaces.Queries;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Entities;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.BookCategory.DeleteBookCategory;
public sealed class DeleteBookCategoryCommandHandler : IRequestHandler<DeleteBookCategoryCommand, Result<Unit>>
{
    private readonly IBookCategoryCommandRepository _commands;
    private readonly IBookCategoryQueryRepository _query;
    public DeleteBookCategoryCommandHandler(IBookCategoryCommandRepository commands, IBookCategoryQueryRepository query)
    {
        _commands = commands;
        _query = query;
    }

    public async ValueTask<Result<Unit>> Handle(DeleteBookCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await _query.GetEntityByIdAsync(request.Id, cancellationToken).ConfigureAwait(false);
        if (entity is null)
            return Errors.NotFound<Unit>("BookCategory with ID {request.Id} was not found.");
        await _commands.DeleteAsync(request.Id, cancellationToken).ConfigureAwait(false);
        return Result<Unit>.Success(Unit.Value, "BookCategory successfully deleted.");
    }
}