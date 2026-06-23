using LibraryService.Api.Domain.Interfaces.Commands;
using LibraryService.Api.Domain.Interfaces.Queries;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Entities;
using LibraryService.Api.Domain.Shared;
using FastCqrs;

namespace LibraryService.Api.Features.Author.CreateAuthor;
public sealed class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, Domain.Shared.Result<AuthorDto>>
{
    private readonly IAuthorCommandRepository _commands;    
    public CreateAuthorCommandHandler(IAuthorCommandRepository commands)
    {
        _commands = commands;        
    }

    public async ValueTask<Domain.Shared.Result<AuthorDto>> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
    {
        var entity = AuthorEntity.Create(request.Name);
        await _commands.InsertAsync(entity, cancellationToken).ConfigureAwait(false);
        var response = new AuthorDto(entity.Id, entity.Name);
        return Domain.Shared.Result<AuthorDto>.Success(response, "Author successfully created.");
    }
}