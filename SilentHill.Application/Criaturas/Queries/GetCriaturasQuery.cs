using MediatR;
using SilentHill.Shared;

namespace SilentHill.Application.Criaturas.Queries;

public record GetCriaturasQuery : IRequest<List<CriaturaDto>>;

public class GetCriaturasQueryHandler : IRequestHandler<GetCriaturasQuery, List<CriaturaDto>>
{
    private readonly ICriaturaRepository _repository;

    public GetCriaturasQueryHandler(ICriaturaRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<CriaturaDto>> Handle(GetCriaturasQuery request, CancellationToken cancellationToken)
    {
        var criaturas = await _repository.GetAllAsync(cancellationToken);

        return criaturas.Select(c => new CriaturaDto
        {
            Id = c.Id,
            Nome = c.Nome,
            Descricao = c.Descricao,
            JogoOrigem = c.JogoOrigem,
            ImagemUrl = c.ImagemUrl,
            NivelPerigo = c.NivelPerigo
        }).ToList();
    }
}
