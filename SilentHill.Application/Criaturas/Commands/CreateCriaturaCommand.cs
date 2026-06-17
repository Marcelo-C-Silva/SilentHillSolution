using MediatR;
using SilentHill.Domain;
using SilentHill.Shared;

namespace SilentHill.Application.Criaturas.Commands;

public record CreateCriaturaCommand(
    string Nome,
    string Descricao,
    string JogoOrigem,
    string ImagemUrl,
    int NivelPerigo
) : IRequest<CriaturaDto>;

public class CreateCriaturaCommandHandler : IRequestHandler<CreateCriaturaCommand, CriaturaDto>
{
    private readonly ICriaturaRepository _repository;

    public CreateCriaturaCommandHandler(ICriaturaRepository repository)
    {
        _repository = repository;
    }

    public async Task<CriaturaDto> Handle(CreateCriaturaCommand request, CancellationToken cancellationToken)
    {
        var criatura = new Criatura
        {
            Nome = request.Nome,
            Descricao = request.Descricao,
            JogoOrigem = request.JogoOrigem,
            ImagemUrl = request.ImagemUrl,
            NivelPerigo = request.NivelPerigo
        };

        var saved = await _repository.AddAsync(criatura, cancellationToken);

        return new CriaturaDto
        {
            Id = saved.Id,
            Nome = saved.Nome,
            Descricao = saved.Descricao,
            JogoOrigem = saved.JogoOrigem,
            ImagemUrl = saved.ImagemUrl,
            NivelPerigo = saved.NivelPerigo
        };
    }
}
