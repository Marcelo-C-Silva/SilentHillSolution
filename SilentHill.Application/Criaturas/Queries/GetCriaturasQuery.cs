using MediatR;
using SilentHill.Shared;

namespace SilentHill.Application.Criaturas.Queries;

public record GetCriaturasQuery : IRequest<List<CriaturaDto>>;

public class GetCriaturasQueryHandler : IRequestHandler<GetCriaturasQuery, List<CriaturaDto>>
{
    public Task<List<CriaturaDto>> Handle(GetCriaturasQuery request, CancellationToken cancellationToken)
    {
        var monstrosDaNevoa = new List<CriaturaDto>
        {
            new() { Id = 1, Nome = "Pyramid Head", Descricao = "O executor de Silent Hill 2.", JogoOrigem = "Silent Hill 2", NivelPerigo = 5, ImagemUrl = "https://static.wikia.nocookie.net/silent/images/c/c9/Red_Pyramid.png/revision/latest?cb=20241231221947" },
            new() { Id = 2, Nome = "Bubble Head Nurse", Descricao = "Enfermeira sinistra.", JogoOrigem = "Silent Hill 2", NivelPerigo = 3, ImagemUrl = "https://static.wikia.nocookie.net/silent/images/7/71/Hellooo_nurse%21.png/revision/latest?cb=20131222015921" }
        };

        return Task.FromResult(monstrosDaNevoa);
    }
}