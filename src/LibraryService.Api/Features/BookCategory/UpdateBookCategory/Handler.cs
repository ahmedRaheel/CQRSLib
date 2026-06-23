using FastCqrs;
using LibraryService.Api.Domain.Interfaces.Commands;
using LibraryService.Api.Domain.Interfaces.Queries;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Entities;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.BookCategory.UpdateBookCategory;
public sealed class UpdateBookCategoryCommandHandler : IRequestHandler<UpdateBookCategoryCommand, Result<Unit>>
{
    private readonly IBookCategoryCommandRepository _commands;
    private readonly IBookCategoryQueryRepository _query;
    public UpdateBookCategoryCommandHandler(IBookCategoryCommandRepository commands, IBookCategoryQueryRepository query)
    {
        _commands = commands;
        _query = query;
    }

    public async ValueTask<Result<Unit>> Handle(UpdateBookCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await _query.GetEntityByIdAsync(request.Id, cancellationToken).ConfigureAwait(false);
        if (entity is null)
            return Errors.NotFound<Unit>("BookCategory with ID {request.Id} was not found.");
        entity.Update(request.BookId, request.CategoryId);
        await _commands.UpdateAsync(request.Id, entity, cancellationToken).ConfigureAwait(false);
        return Result<Unit>.Success(Unit.Value, "BookCategory successfully updated.");
    }
}